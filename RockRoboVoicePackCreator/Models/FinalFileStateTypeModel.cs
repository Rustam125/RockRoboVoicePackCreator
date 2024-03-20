using RockRoboVoicePackCreator.Enums;

namespace RockRoboVoicePackCreator.Models
{
    public class FinalFileStateTypeModel
    {
        public FinalFileStateTypeModel(FinalFileStateTypesEnum stateType, Color color)
        {
            StateType = stateType;
            Color = color;
        }

        public FinalFileStateTypesEnum StateType { get; private set; }

        public Color Color { get; private set; }
    }
}