

namespace AppDesktop.Classes
{
    public class Items : System.ComponentModel.INotifyPropertyChanged
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
        string imageSource = null;
        string code;
        int clePrix;

       

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
        public string ImageSource { get => imageSource; set => imageSource = value; }
        public string Code { get => code; set => code = value; }
        public int ClePrix { get => clePrix; set => clePrix = value; }

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
