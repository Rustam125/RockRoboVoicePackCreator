namespace RockRoboVoicePackCreator.Models
{
    public class FinalFileInfoModel
    {
        public FinalFileInfoModel(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }

        public FileInfoModel? File { get; set; }
    }
}
