

namespace AppDesktop.Classes
{
    class Items:Sellings
    {
        int cleArticle;
        string refArticle;
        int typeArticle;//vetement homme , femme, enfant
        int categorie;//veste, jupe, robe etc...
        int genderArticle;
        int color;
        int size;
        int brand;
        string description;
        double prix;
       

        public int CleArticle { get => cleArticle; set => cleArticle = value; }
        public string RefArticle { get => refArticle; set => refArticle = value; }
        public int TypeArticle { get => typeArticle; set => typeArticle = value; }
        public string Description { get => description; set => description = value; }
        public double Prix { get => prix; set => prix = value; }
        public int GenderArticle { get => genderArticle; set => genderArticle = value; }
        public int Color { get => color; set => color = value; }
        public int Size { get => size; set => size = value; }
        public int Brand { get => brand; set => brand = value; }
        public int Categorie { get => categorie; set => categorie = value; }
    }
}
