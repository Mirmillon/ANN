

namespace AppDesktop.Classes
{
    class ItemsSale : Items
    {
        int nombre;
        double cout;

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

            set => cout = value; }
    }
}
