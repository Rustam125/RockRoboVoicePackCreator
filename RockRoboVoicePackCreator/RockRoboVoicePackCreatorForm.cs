using System.ComponentModel;
using RockRoboVoicePackCreator.Enums;
using RockRoboVoicePackCreator.Helpers;
using RockRoboVoicePackCreator.Interfaces;
using RockRoboVoicePackCreator.Models;
using FileInfoModel = RockRoboVoicePackCreator.Models.FileInfoModel;

namespace RockRoboVoicePackCreator
{
    public partial class RockRoboVoicePackCreatorForm : Form
    {
        #region Fields

        private readonly BindingList<FileInfoModel> _filesFirstList;
        private readonly BindingList<FileInfoModel> _filesSecondList;
        private FileInfoModel? _firstSelectedFileInfo = null;
        private FileInfoModel? _secondSelectedFileInfo = null;
        private readonly BindingList<VisualFinalFileInfoModel> _finalFileModels;
        private int _finalFileModelsListBoxHoveredIndex = -1;
        private int _finalFileModelsListBoxSelectedIndex = -1;
        private StringModel _finalFileNameMask = new("(?:(?!:).)*");
        private BooleanModel _isUseFileNameFromFinalList = new(true);
        private FilesListBoxNumber _filesListBoxMenuStripSelected = FilesListBoxNumber.None;

        #endregion

        #region Constructors

        public RockRoboVoicePackCreatorForm()
        {
            InitializeComponent();
            _filesFirstList = new BindingList<FileInfoModel>();
            _filesSecondList = new BindingList<FileInfoModel>();
            _finalFileModels = new BindingList<VisualFinalFileInfoModel>();

            SetBindings();
        }

        #endregion

        #region Bindings

        private void SetBindings()
        {
            // список файлов 1
            filesListBoxFirst.DataSource = _filesFirstList;
            filesListBoxFirst.DisplayMember = "Name";
            filesListBoxFirst.ValueMember = "ID";

            // список файлов 2
            filesListBoxSecond.DataSource = _filesSecondList;
            filesListBoxSecond.DisplayMember = "Name";
            filesListBoxSecond.ValueMember = "ID";

            // итоговый список
            FinalFileModelsListBox.DataSource = _finalFileModels;
            FinalFileModelsListBox.DisplayMember = "VisualText";
            FinalFileModelsListBox.ValueMember = "ID";

            // чекбокс наименования файла из списка
            IsUseFileNameFromFinalListCheckBox.DataBindings.Add("Checked", _isUseFileNameFromFinalList, "Value");

            // маска наименования файла
            FinalFileNameMaskTextBox.DataBindings.Add("Text", _finalFileNameMask, "Value");
            FinalFileNameMaskTextBox.DataBindings.Add("Visible", _isUseFileNameFromFinalList, "Value");
            FinalFileNameMaskLabel.DataBindings.Add("Visible", _isUseFileNameFromFinalList, "Value");
        }

        #endregion

        #region Actions

        #region First list box controls actions

        private void AddFilesButtonFirst_Click(object sender, EventArgs e)
        {
            _filesFirstList.ListClearAndFillInAgain(MainHelper.GetFileInfoList());
        }

        private void FilesListBoxFirst_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_filesFirstList.CollectionHasAnyValue() == false)
            {
                return;
            }

            MainHelper.TryAddFileToFinalList(_firstSelectedFileInfo, _finalFileModels, _finalFileModelsListBoxSelectedIndex);
            _filesFirstList.SetColorRow(_firstSelectedFileInfo);
        }

        private void PlayButtonFirst_Click(object sender, EventArgs e)
        {
            MainHelper.PlayAudio(_firstSelectedFileInfo);
        }

        private void StopButtonFirst_Click(object sender, EventArgs e)
        {
            MainHelper.StopAudio(_firstSelectedFileInfo);
        }

        private void FilesListBoxFirst_SelectedIndexChanged(object sender, EventArgs e)
            => _firstSelectedFileInfo = MainHelper.GetSelectedFileInfo(sender);

        private void FilesListBoxFirst_RightMouseUp(object sender, MouseEventArgs e)
        {
            _filesListBoxMenuStripSelected = FilesListBoxNumber.None;

            if (MainHelper.HasFilesListBox_RightMouseUp(sender, e, FilesListBoxContextMenuStrip))
            {
                _filesListBoxMenuStripSelected = FilesListBoxNumber.First;
            }
        }

        #endregion

        #region Second list box controls actions

        private void AddFilesButtonSecond_Click(object sender, EventArgs e)
        {
            _filesSecondList.ListClearAndFillInAgain(MainHelper.GetFileInfoList());
        }

        private void PlayButtonSecond_Click(object sender, EventArgs e)
        {
            MainHelper.PlayAudio(_secondSelectedFileInfo);
        }

        private void StopButtonSecond_Click(object sender, EventArgs e)
        {
            MainHelper.StopAudio(_secondSelectedFileInfo);
        }

        private void FilesListBoxSecond_SelectedIndexChanged(object sender, EventArgs e)
            => _secondSelectedFileInfo = MainHelper.GetSelectedFileInfo(sender);

        private void FilesListBoxSecond_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_filesSecondList.CollectionHasAnyValue() == false)
            {
                return;
            }

            MainHelper.TryAddFileToFinalList(_secondSelectedFileInfo, _finalFileModels, _finalFileModelsListBoxSelectedIndex);
        }

        private void FilesListBoxSecond_RightMouseUp(object sender, MouseEventArgs e)
        {
            _filesListBoxMenuStripSelected = FilesListBoxNumber.None;

            if (MainHelper.HasFilesListBox_RightMouseUp(sender, e, FilesListBoxContextMenuStrip))
            {
                _filesListBoxMenuStripSelected = FilesListBoxNumber.Second;
            }
        }

        #endregion

        #region Final list box controls actions

        private void FinalFileModelsListBox_MouseMove(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            int currentHoveredIndex = listBox.IndexFromPoint(e.Location);

            if (_finalFileModelsListBoxHoveredIndex != currentHoveredIndex)
            {
                _finalFileModelsListBoxHoveredIndex = currentHoveredIndex;

                if (_finalFileModelsListBoxHoveredIndex > -1)
                {
                    toolTip1.Active = false;
                    VisualFinalFileInfoModel listBoxItem =
                        (VisualFinalFileInfoModel)listBox.Items[_finalFileModelsListBoxHoveredIndex];
                    toolTip1.SetToolTip(listBox, listBoxItem.ToolTip);
                    toolTip1.Active = true;
                }
            }
        }

        private void FinalFileModelsListBox_SelectedIndexChanged(object sender, EventArgs e)
            => _finalFileModelsListBoxSelectedIndex = MainHelper.GetListBoxSelectedIndex(sender);

        private void IsUseFileNameFromFinalListCheckBox_CheckedChanged(object sender, EventArgs e)
            => _isUseFileNameFromFinalList.Value = ((CheckBox)sender).Checked;

        #endregion

        #region Menu strip

        private void CreateFromTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var finalFileModels = MainHelper.CreateFinalListFromTxt();
            _finalFileModels.ListClearAndFillInAgain(finalFileModels);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainHelper.SaveFinalList(_finalFileModels);
        }

        private void ToolStripMenuItem1_DropDownOpening(object sender, EventArgs e)
        {
            SaveToolStripMenuItem.Enabled = _finalFileModels.Any();
            CheckFilesToolStripMenuItem.Enabled = _finalFileModels.Any();
            GenerateFilesToolStripMenuItem.Enabled = _finalFileModels.Any(file => file.IsExistsFile());
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainHelper.OpenFinalList(_finalFileModels);
        }

        private void GenerateFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainHelper.GenerateFiles(_finalFileModels, _finalFileNameMask, _isUseFileNameFromFinalList);
        }

        #endregion

        private void RowsListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }

            e.DrawBackground();

            Graphics g = e.Graphics;
            ListBox lb = (ListBox)sender;
            IColored rowValue = (IColored)lb.Items[e.Index];
            g.FillRectangle(new SolidBrush(rowValue.GetColor()), e.Bounds);
            g.DrawString(
                ((ITextContains)lb.Items[e.Index]).GetText(),
                e.Font!,
                new SolidBrush(e.ForeColor),
                new PointF(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }

        #region Files listBox context menu

        private void RemoveRowColorContextStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_filesListBoxMenuStripSelected == FilesListBoxNumber.First)
            {
                _firstSelectedFileInfo?.SetColor(Color.Transparent);
            }
            else if (_filesListBoxMenuStripSelected == FilesListBoxNumber.Second)
            {
                _secondSelectedFileInfo?.SetColor(Color.Transparent);
            }
        }

        #endregion

        #endregion
    }
}