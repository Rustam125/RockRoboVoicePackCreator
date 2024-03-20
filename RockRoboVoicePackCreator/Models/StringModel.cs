using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RockRoboVoicePackCreator.Models
{
    public class StringModel : INotifyPropertyChanged
    {
        private string? _value;

        public StringModel(string? value)
        {
            Value = value;
        }

        public string? Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public bool HasValue => string.IsNullOrEmpty(_value) == false;

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
