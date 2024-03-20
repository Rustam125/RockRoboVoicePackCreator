using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RockRoboVoicePackCreator.Models
{
    public class BooleanModel : INotifyPropertyChanged
    {
        private bool? _value;

        public BooleanModel(bool? value)
        {
            Value = value;
        }

        public bool? Value
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

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}