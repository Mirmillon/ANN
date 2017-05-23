


namespace AppDesktop.Classes
{
    class Credits : System.ComponentModel.INotifyPropertyChanged
    {
        private int cle;
        private System.DateTime dateDue;
        private int cleClient;
        private int cleVente;
        private double montantPaye;

        public int Cle { get => cle; set => cle = value; }
        public int CleClient { get => cleClient; set => cleClient = value; }
        public int CleVente { get => cleVente; set => cleVente = value; }

        public System.DateTime DateDue
        {
            get => dateDue;
            set
            {
                if(dateDue != value)
                {
                    dateDue = value;
                    OnPropertyChanged("DateDue");
                }
            }
        }

        public double MontantDu
        {
            get => montantPaye;
            set
            {
                if (montantPaye != value)
                {
                    montantPaye = value;
                    OnPropertyChanged("MontantPaye");
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
