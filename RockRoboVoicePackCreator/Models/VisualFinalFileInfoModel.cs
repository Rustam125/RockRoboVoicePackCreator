using RockRoboVoicePackCreator.Dictionaries;
using RockRoboVoicePackCreator.Helpers;
using RockRoboVoicePackCreator.Interfaces;

namespace RockRoboVoicePackCreator.Models
{
    public class VisualFinalFileInfoModel : FinalFileInfoModel, IColored, ITextContains
    {
        public VisualFinalFileInfoModel(string text) : base(text)
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; private set; }

        public string VisualText
        {
            get
            {
                return $"{Text}";
            }
        }

        public string ToolTip
        {
            get
            {
                FinalFileStateModel state = GetState();
                string? fileInfo = File?.GetSummary();
                fileInfo = fileInfo.HasValue() ?
                    Environment.NewLine + fileInfo :
                    string.Empty;
                return $"{Text}{Environment.NewLine}" +
                    $"Статус: {state.Text}" +
                    fileInfo;
            }
        }

        public Color GetColor() => GetState().StateType.Color;

        public string GetText() => VisualText;

        public bool IsExistsFile() => System.IO.File.Exists(File?.Path);

        public void SetColor(Color color)
        {
            throw new NotImplementedException();
        }

        private FinalFileStateModel GetState()
        {
            if (File == null)
            {
                return FinalFileState.EmptyFile;
            }

            if (string.IsNullOrEmpty(File.Path) ||
                IsExistsFile() == false)
            {
                return FinalFileState.EmptyFilePath;
            }

            return FinalFileState.IsGood;
        }
    }
}