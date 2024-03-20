namespace RockRoboVoicePackCreator.Models
{
    public class FinalFileStateModel
    {
        public FinalFileStateModel(string text, FinalFileStateTypeModel stateType)
        {
            Text = text;
            StateType = stateType;
        }

        public string Text { get; private set; }

        public FinalFileStateTypeModel StateType { get; private set; }
    }
}
