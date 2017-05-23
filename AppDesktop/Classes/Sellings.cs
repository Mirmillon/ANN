

namespace AppDesktop.Classes
{
    internal class Sellings
    {
        int cle;
        System.DateTime dateSelling;
        int nbItems;
        double amount;
        int typePayment;
        double cash;
        double credit;
        int customer;
        System.DateTime dateDue;

        public int Cle { get => cle; set => cle = value; }
        public System.DateTime DateSelling { get => dateSelling; set => dateSelling = value; }
        public int NbItems { get => nbItems; set => nbItems = value; }
        public double Amount { get => amount; set => amount = value; }
        public int TypePayment { get => typePayment; set => typePayment = value; }
        public double Cash { get => cash; set => cash = value; }
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
        public int Customer { get => customer; set => customer = value; }
    }
}
