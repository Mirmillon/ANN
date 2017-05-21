

namespace AppDesktop.Classes
{
    internal class ReferencesSimples : System.ComponentModel.INotifyPropertyChanged
    {
        int cle;
        string label;

        public int Cle { get => cle; set => cle = value; }

        public string Label
        {
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

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propName));
            }
        }
    }
}
