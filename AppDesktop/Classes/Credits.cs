


namespace AppDesktop.Classes
{
    class Credits : System.ComponentModel.INotifyPropertyChanged
    {
        private int cle;
        private System.DateTime dateDue;
        private Customers client = null;
        private Sellings vente = null;
        private double montantPaye;


        public Credits()
        {
            client = new Customers();
            vente = new Sellings();
        }

        public int Cle { get => cle; set => cle = value; }
        internal Customers Client { get => client; set => client = value; }
        internal Sellings Vente { get => vente; set => vente = value; }



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
