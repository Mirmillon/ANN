

namespace AppDesktop.Classes
{
    class Payments : Credits
    {
        double paiement;
        System.DateTime datePaiement;

        public double Paiement { get => paiement; set => paiement = value; }
        public System.DateTime DatePaiement { get => datePaiement; set => datePaiement = value; }
    }
}
