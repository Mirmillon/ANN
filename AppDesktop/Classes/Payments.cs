

namespace AppDesktop.Classes
{
    class Payments : Credits
    {
        double paiement;
        System.DateTime datePaiement = System.DateTime.Today;

        public double Paiement { get => paiement; set => paiement = value; }
        public System.DateTime DatePaiement { get => datePaiement; set => datePaiement = value; }
    }
}
