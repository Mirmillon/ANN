
namespace AppDesktop.Classes
{
    internal class Brands : System.ComponentModel.INotifyPropertyChanged
    {
        int cle;
        int cleCountry;
        string label;
        string note;

      
        public  int Cle { get => cle; set => cle = value; }

        public int CleCountry {
            get => cleCountry;
            set
            {
                if (cleCountry != value)
                {
                    cleCountry = value;
                    OnPropertyChanged("CleCountry");
                }
            }
        }

        public string Label {
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

        public  string Note {
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
