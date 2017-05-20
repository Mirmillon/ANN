
namespace AppDesktop.Classes
{
    internal class Brands : System.ComponentModel.INotifyPropertyChanged
    {
        int cle;
        string label;
        string note;

        internal int Cle { get => cle; set => cle = value; }

        internal string Label {
            get => label;
            set
            {
                if (label != value)
                {
                    label = value;
                    OnPropertyChanged("Label");
                }
            }
        }

        internal string Note {
            get => note;
            set
            {
                if(note != value)
                {
                    note = value;
                    OnPropertyChanged("Note");
                }
               
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propName));
            }
        }
    }
}
