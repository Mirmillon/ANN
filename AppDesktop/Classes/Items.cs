

namespace AppDesktop.Classes
{
    class Items:Sellings
    {
        int cleArticle;
        int refArticle;
        int typeArticle;
        string description;
        double prix;

        public int CleArticle { get => cleArticle; set => cleArticle = value; }
        public int RefArticle { get => refArticle; set => refArticle = value; }
        public int TypeArticle { get => typeArticle; set => typeArticle = value; }
        public string Description { get => description; set => description = value; }
        public double Prix { get => prix; set => prix = value; }
    }
}
