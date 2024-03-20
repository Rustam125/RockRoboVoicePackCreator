using RockRoboVoicePackCreator.Models;

namespace RockRoboVoicePackCreator.Dictionaries
{
    public static class FinalFileState
    {
        public static readonly FinalFileStateModel EmptyFile = new("Отсутствует файл", FinalFileStateType.Error);

        public static readonly FinalFileStateModel EmptyFilePath = new("Отсутствует путь до файла", FinalFileStateType.Warning);

        public static readonly FinalFileStateModel IsGood = new("Файл создан!", FinalFileStateType.Good);
    }
}