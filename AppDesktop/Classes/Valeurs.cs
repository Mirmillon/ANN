

namespace AppDesktop.Classes
{
    public class Valeurs : Price
    {
        int cleBundle;
        int nbItems = 0;
        double valeur;

        public int CleBundle { get => cleBundle; set => cleBundle = value; }
        public int NbItems { get => nbItems; set => nbItems = value; }
        public double Valeur {
            get => Prix * nbItems;
            set => valeur = value;
        }
        
    }
}
