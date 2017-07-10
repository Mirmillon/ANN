
namespace AppDesktop.Classes
{
    public class Sales
    {
        int cleVente; 
        System.DateTime dateVente;
        int cleType;
        int nombre;
        double  amount;
        string categorie;
        int moisVente;

        public int CleVente { get => cleVente; set => cleVente = value; }
        public System.DateTime DateVente { get => dateVente; set => dateVente = value; }
        public int CleType { get => cleType; set => cleType = value; }
        public double Amount { get => amount; set => amount = value; }
        public int Nombre { get => nombre; set => nombre = value; }
        public string Categorie { get => categorie; set => categorie = value; }
        public int MoisVente { get => moisVente; set => moisVente = value; }
    }
}
