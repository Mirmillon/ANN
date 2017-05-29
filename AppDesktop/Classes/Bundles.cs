
namespace AppDesktop.Classes
{
    internal class Bundles : System.ComponentModel.INotifyPropertyChanged
    {
        private int cle;
        private int cleBrand;
        private int cleCountry;
        private int cleKind;
        private string label;
        private int weight;
        private string note;
        private int cleProvider;
        private double prix;
        private int cleStock;
        private int nbItems;
        private System.DateTime dateAchat = System.DateTime.Today;
        private double priceItem;

        public System.DateTime DateAchat { get => dateAchat; set => dateAchat = value; }
        public int Cle { get => cle; set => cle = value; }
        public int CleBrand { get => cleBrand; set => cleBrand = value; }
        public string Label { get => label; set => label = value; }
        public int Weight { get => weight; set => weight = value; }
        public string Note { get => note; set => note = value; }
        public int CleCountry { get => cleCountry; set => cleCountry = value; }
        public int CleKind { get => cleKind; set => cleKind = value; }
        public int CleProvider { get => cleProvider; set => cleProvider = value; }
        public double Prix { get => prix; set => prix = value; }
        public int CleStock { get => cleStock; set => cleStock = value; }

        public int NbItems
        {
            get => nbItems;
            set
            {
                if (nbItems != value)
                {
                    nbItems = value;
                    OnPropertyChanged("NbItems");
                }
            }
        }
      
        public double PriceItem
        {
            get => priceItem;

            set
            {
                if(nbItems > 0)
                {
                    priceItem = prix/nbItems;
                    if(priceItem != value)
                    {
                        priceItem = value;
                        OnPropertyChanged("PriceItem");
                    }
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
