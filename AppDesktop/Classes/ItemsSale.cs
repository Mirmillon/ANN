

namespace AppDesktop.Classes
{
    class ItemsSale : Items
    {
        int nombre;
        double cout;
        string label;
        string categorieVente;//clothes, loan, beauty
        int cleGender = -1;

        public int Nombre
        {
            get => nombre;

            set
            {

                if(nombre != value)
                {
                    nombre = value;
                    OnPropertyChanged("Nombre");
                }
            }
        }
        public double Cout {
            get
            {
                if(nombre > 0)
                {
                    return nombre * Prix;
                }
                else { return 0; }
            }

            set => cout = value;
        }

        public string Label { get => label; set => label = value; }
        public string CategorieVente { get => categorieVente; set => categorieVente = value; }
        public int CleGender
        {
            get => cleGender;
            set
            {
                if ((categorieVente.Equals("Load")) || (categorieVente.Equals("Beauty")))
                {
                    cleGender = 0;
                }
                else
                {
                    cleGender = value;
                }

            }
        }
    }
}
