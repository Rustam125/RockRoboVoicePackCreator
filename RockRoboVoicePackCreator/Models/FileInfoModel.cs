using RockRoboVoicePackCreator.Dictionaries;
using RockRoboVoicePackCreator.Helpers;
using RockRoboVoicePackCreator.Interfaces;

namespace RockRoboVoicePackCreator.Models
{
    public class FileInfoModel : IColored, ITextContains
    {
        private string? _path;
        private Color _color;

        public FileInfoModel(string? path)
        {
            Path = path;
            ID = Guid.NewGuid();
            _color = Colors.Transparent;
        }

        public string? Name { get; private set; }

        public string? Path
        {
            set
            {
                _path = value;

                if (value.HasValue())
                {
                    Name = System.IO.Path.GetFileName(value);
                }
            }
            get
            {
                return _path;
            }
        }

        public Guid ID { get; private set; }

        public string Extension
        {
            get
            {
                return _path.HasValue() ? System.IO.Path.GetExtension(_path!) : string.Empty;
            }
        }

        public string GetSummary()
        {
            string fileName = Name.HasValue() ? $"Имя файла: {Name}{Environment.NewLine}" : string.Empty;
            string path = _path.HasValue() ? $"Путь: {_path}{Environment.NewLine}" : string.Empty;
            string extension = Extension.HasValue() ? $"Расширение файла: {Extension}{Environment.NewLine}" : string.Empty;
            return $"{fileName}{path}{extension}";
        }

        public void SetColor(Color color) => _color = color;

        public Color GetColor() => _color;

        public string GetText() => Name.HasValue() ? Name! : string.Empty;
    }
}