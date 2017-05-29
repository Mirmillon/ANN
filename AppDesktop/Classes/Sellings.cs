

namespace AppDesktop.Classes
{
    public  class Sellings : System.ComponentModel.INotifyPropertyChanged
    {
        int cle;
        System.DateTime dateSelling = System.DateTime.Today;
        int nbItems;
        double amount;
        int typePayment;
        double cash;
        double credit;
        int customer;
        System.DateTime dateDue = System.DateTime.Today.AddDays(1);



        public int Cle { get => cle; set => cle = value; }
        public System.DateTime DateSelling { get => dateSelling; set => dateSelling = value; }
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
        public double Amount { get => amount; set => amount = value; }
        public int TypePayment { get => typePayment; set => typePayment = value; }
        public double Cash
        {
            get => cash;
            set
            {
                if (cash != value)
                {
                    cash = value;
                    OnPropertyChanged("Cash");
                }
            }
        }
        public double Credit
        {
            get
            {
                if(amount > cash)
                {
                    return amount - cash;
                }
                else
                {
                    return 0;
                }
                
            }
            set => credit = value;

        }
        public System.DateTime DateDue { get => dateDue; set => dateDue = value; }
        public int CleClient { get => customer; set => customer = value; }

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
