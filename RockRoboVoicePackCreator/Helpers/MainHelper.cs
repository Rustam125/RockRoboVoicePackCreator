using NLog;
using RockRoboVoicePackCreator.Dictionaries;
using RockRoboVoicePackCreator.Interfaces;
using RockRoboVoicePackCreator.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Media;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using FileInfoModel = RockRoboVoicePackCreator.Models.FileInfoModel;

namespace RockRoboVoicePackCreator.Helpers
{
    public static class MainHelper
    {
        #region Fields

        private static readonly string _wavExtension = "wav";
        private static SoundPlayer? _soundPlayer;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Public methods

        public static bool HasValue(this string? value) => string.IsNullOrEmpty(value) == false;

        public static Collection<FileInfoModel> GetFileInfoList()
        {
            Collection<FileInfoModel> files = new();
            using OpenFileDialog openFileDialog = new();
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in openFileDialog.FileNames)
                {
                    files.Add(new FileInfoModel(filePath));
                }
            }

            return files;
        }

        public static void ListClearAndFillInAgain<T>(this Collection<T> firstList, Collection<T> listToFill)
        {
            if (listToFill.Any() == false)
            {
                return;
            }

            firstList.Clear();

            foreach (var item in listToFill)
            {
                firstList.Add(item);
            }
        }

        public static bool CollectionHasAnyValue<T>(this Collection<T>? collection)
            => collection != null && collection.Any();

        public static Collection<VisualFinalFileInfoModel> CreateFinalListFromTxt()
        {
            Collection<VisualFinalFileInfoModel> files = new();

            using OpenFileDialog openFileDialog = new();
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "txt only (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return files;
            }

            try
            {
                string? line;
                using StreamReader reader = new(openFileDialog.FileName);

                while ((line = reader.ReadLine()) != null)
                {
                    files.Add(new VisualFinalFileInfoModel(line));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return files;
        }

        public static void PlayAudio(FileInfoModel? fileInfo)
        {
            if (fileInfo == null)
            {
                return;
            }

            if (IsWavExtension(fileInfo))
            {
                PlayWav(fileInfo);
            }
            else
            {
                PlayAnyFileWithCmd(fileInfo);
            }
        }

        public static void StopAudio(FileInfoModel? fileInfo)
        {
            if (fileInfo != null &&
                IsWavExtension(fileInfo))
            {
                StopWav();
            }
        }

        public static void TryAddFileToFinalList(
            FileInfoModel? fileInfo,
            Collection<VisualFinalFileInfoModel> visualFinalFiles,
            int finalFileSelectedIndex)
        {
            if (fileInfo == null)
            {
                ShowAndLogError("Не удалось определить выбранный файл.");
                return;
            }

            if (visualFinalFiles == null ||
                visualFinalFiles.Any() == false ||
                finalFileSelectedIndex == -1 ||
                visualFinalFiles.Count - 1 < finalFileSelectedIndex)
            {
                ShowAndLogError("Не удалось определить элемент итогового списка.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show(
                $"Вы хотите добавить файл \"{fileInfo.Name}\" к элементу " +
                $"\"{visualFinalFiles[finalFileSelectedIndex].VisualText}\".{Environment.NewLine}" +
                $"Подтвердите действие.",
                "Подтверждение",
                MessageBoxButtons.YesNo);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            fileInfo.SetColor(Colors.LightGreen);
            visualFinalFiles[finalFileSelectedIndex].File = fileInfo;
        }

        public static void SaveFinalList(Collection<VisualFinalFileInfoModel> visualFinalFiles)
        {
            if (visualFinalFiles == null ||
                visualFinalFiles.Any() == false)
            {
                ShowAndLogError("Итоговый список пуст.");
                return;
            }

            string saveDirectory = SelectFolderPath();
            string fileName = "RockRoboVoicePack.json";

            if (string.IsNullOrEmpty(saveDirectory))
            {
                return;
            }

            var fileInfoModels = visualFinalFiles.Cast<FinalFileInfoModel>();
            string filePath = Path.Combine(saveDirectory, fileName);
            string json = JsonSerializer.Serialize(
                fileInfoModels,
                new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                });

            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.WriteLine(json);
            }

            ShowInfo("Файл успешно сохранен!");
        }

        public static void OpenFinalList(Collection<VisualFinalFileInfoModel> visualFinalFiles)
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "json only (*.json)|*.json";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                using StreamReader reader = new(openFileDialog.FileName);
                string jsonString = reader.ReadToEnd();
                var deserializedJson = JsonSerializer.Deserialize<Collection<VisualFinalFileInfoModel>>(jsonString);

                if (deserializedJson != null)
                {
                    visualFinalFiles.ListClearAndFillInAgain(deserializedJson);
                }
            }
            catch (Exception ex)
            {
                ShowAndLogError(ex.Message);
            }
        }

        public static void GenerateFiles(
            Collection<VisualFinalFileInfoModel> visualFinalFiles,
            StringModel finalFileNameMask,
            BooleanModel _isUseFileNameFromFinalList)
        {
            string saveDirectory = SelectFolderPath();

            if (string.IsNullOrEmpty(saveDirectory))
            {
                return;
            }


            foreach (VisualFinalFileInfoModel finalFile in visualFinalFiles.Where(file => file.IsExistsFile()))
            {
                string newFileName = finalFile!.File!.Name!;

                if (_isUseFileNameFromFinalList.Value.HasValue &&
                    _isUseFileNameFromFinalList.Value.Value &&
                    finalFileNameMask.HasValue &&
                    TryGetRegexFileName(finalFile!.Text, finalFileNameMask.Value!, out string regexResult) &&
                    string.IsNullOrEmpty(regexResult) == false)
                {
                    newFileName = regexResult;
                }

                string newFileNameExt = Path.GetExtension(newFileName);

                if (newFileNameExt.HasValue() &&
                    newFileName != newFileNameExt)
                {
                    newFileName = newFileName.Replace(newFileNameExt, string.Empty);
                }

                File.Copy(finalFile!.File!.Path!, Path.Combine(saveDirectory, newFileName + finalFile!.File!.Extension), true);
            }

            ShowInfo("Файлы успешно сформированы!");
        }

        private static bool TryGetRegexFileName(string text, string regex, out string result)
        {
            result = string.Empty;

            try
            {
                Match match = Regex.Match(text, regex);

                if (match.Success)
                {
                    result = match.Value;
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return false;
        }

        public static void SetColorRow(this Collection<FileInfoModel> collection, FileInfoModel? row)
        {
            if (row == null)
            {
                return;
            }

            FileInfoModel? findedRow = collection.FirstOrDefault(item => item.ID == row.ID);
            findedRow?.SetColor(row.GetColor());
        }

        public static FileInfoModel? GetSelectedFileInfo(object sender)
        {
            ListBox? listbox = sender as ListBox;
            return listbox?.SelectedItem != null ? listbox.SelectedItem as FileInfoModel : null;
        }

        public static int GetListBoxSelectedIndex(object sender) => ((ListBox)sender)?.SelectedIndex ?? -1;

        public static bool HasFilesListBox_RightMouseUp(
            object sender,
            MouseEventArgs e,
            ContextMenuStrip contextMenuStrip)
        {
            bool result = false;

            if (e.Button != MouseButtons.Right)
            {
                return result;
            }

            ListBox lb = (ListBox)sender;
            lb.SelectedIndex = lb.IndexFromPoint(e.Location);

            if (lb.SelectedIndex != -1)
            {
                result = true;
                contextMenuStrip.Show(Cursor.Position);
            }

            return result;
        }

        public static void SelectNextItemInListBox(ListBox lb)
        {
            if (lb.Items.Count == 0)
            {
                return;
            }

            if (lb.SelectedIndex < lb.Items.Count - 1 ||
                lb.SelectedIndex == -1)
            {
                lb.SelectedIndex++;
            }
            else
            {
                lb.SelectedIndex = 0;
            }
        }

        public static void SelectPreviousItemInListBox(ListBox lb)
        {
            if (lb.Items.Count == 0)
            {
                return;
            }

            if (lb.SelectedIndex > 0)
            {
                lb.SelectedIndex--;
            }
            else
            {
                lb.SelectedIndex = lb.Items.Count - 1;
            }
        }

        public static void MarkProcessedLinesInOtherLists(
            Collection<VisualFinalFileInfoModel> finalFiles,
            Collection<FileInfoModel> firstListFiles,
            Collection<FileInfoModel> secondListFiles)
        {
            foreach (VisualFinalFileInfoModel finalFile in finalFiles
                .Where(finalFile => finalFile.File?.Path.HasValue() ?? false))
            {
                MarkFileRowByPath(finalFile.File!.Path!, firstListFiles);
                MarkFileRowByPath(finalFile.File!.Path!, secondListFiles);
            }
        }

        #endregion

        #region Private methods

        private static void PlayWav(FileInfoModel fileInfo)
        {
            try
            {
                (_soundPlayer = new(fileInfo.Path)).Play();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        private static void StopWav()
        {
            try
            {
                _soundPlayer?.Stop();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        public static Task<int> PlayAnyFileWithCmd(FileInfoModel fileInfo)
        {
            TaskCompletionSource<int> tcs = new();

            try
            {
                Process process = new()
                {
                    StartInfo = {
                    FileName = "cmd.exe",
                    Arguments = $"/c {fileInfo!.Path}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                },
                    EnableRaisingEvents = true
                };

                process.Exited += (sender, args) =>
                {
                    tcs.SetResult(process.ExitCode);
                    process.Dispose();
                };

                process.Start();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return tcs.Task;
        }

        private static bool IsWavExtension(FileInfoModel fileInfo) => fileInfo.Extension.Replace(".", "").ToLower() == _wavExtension;

        private static void ShowAndLogError(string text)
        {
            _logger.Error(text);
            MessageBox.Show(
                    text,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private static void ShowInfo(string text)
        {
            MessageBox.Show(
                    text,
                    "Информация",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private static string SelectFolderPath()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    return fbd.SelectedPath;
                }
            }

            return string.Empty;
        }

        private static void MarkFileRowByPath(
            string path,
            Collection<FileInfoModel> fileInfoModels)
        {
            foreach (FileInfoModel file in fileInfoModels.Where(file => file.Path == path))
            {
                file.SetColor(Colors.LightGreen);
            }
        }

        #endregion
    }
}