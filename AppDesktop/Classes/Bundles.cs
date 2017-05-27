

namespace AppDesktop.Classes
{
    internal class Bundles
    {
        int cle;
        int cleBrand;
        int cleCountry;
        int cleKind;
        string label;
        int weight;
        string note;
        int cleProvider;
        double prix;
        int cleStock;
        int nbItems;

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
        public int NbItems { get => nbItems; set => nbItems = value; }
    }
}
