using RockRoboVoicePackCreator.Enums;
using RockRoboVoicePackCreator.Models;

namespace RockRoboVoicePackCreator.Dictionaries
{
    public static class FinalFileStateType
    {
        public static readonly FinalFileStateTypeModel Error = new(FinalFileStateTypesEnum.Error, Colors.LightRed);

        public static readonly FinalFileStateTypeModel Warning = new(FinalFileStateTypesEnum.Warning, Colors.LightYellow);

        public static readonly FinalFileStateTypeModel None = new(FinalFileStateTypesEnum.None, Colors.Transparent);

        public static readonly FinalFileStateTypeModel Good = new(FinalFileStateTypesEnum.Good, Colors.LightGreen);
    }
}