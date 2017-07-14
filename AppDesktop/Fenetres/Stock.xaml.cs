
using System.Windows;


namespace AppDesktop.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Stock.xaml
    /// </summary>
    public partial class Stock : Window
    {
        System.Collections.Generic.List<Classes.ItemStock> liste = null;

        public System.Collections.Generic.List<Classes.ItemStock> Liste { get => liste; set => liste = value; }

        public Stock()
        {
            InitializeComponent();
            dgStock.ItemsSource = GetListeSimple();

            new Utilitaires.GestionDgColumn().ColumnLabel(dgStock, "CODE", "ClePrix");
            new Utilitaires.GestionDgColumn().ColumnLabel(dgStock, "PRIX", "Prix");
            new Utilitaires.GestionDgColumn().ColumnLabel(dgStock, "QUANTITE", "Quantite");

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e) { Close(); }

        private void BtnValidate_Click(object sender, RoutedEventArgs e)
        {
            //Récupération de la liste des ItemStock
            System.Collections.Generic.List<Classes.ItemStock> l = GetListeItems();
            //Qui est le sender
            System.Windows.Controls.Button b = sender as System.Windows.Controls.Button;
            if(b.Name.Equals("btnValidate"))
            {
                foreach (Classes.ItemStock s in l)
                {
                    if (s.Quantite > 0)
                    {
                        new RDMS.Stock().AddStock(s.ClePrix, s.Quantite);
                    }
                }
            }
            else
            {
                foreach (Classes.ItemStock s in l)
                {
                    if (s.Quantite > 0)
                    {
                        new RDMS.Stock().RemoveStock(s.ClePrix, s.Quantite);
                    }
                }

            }


           
           
            //Récupération du owner
            MainWindow f = (MainWindow)Owner;
            //Mise à jour des données sur la grille des stocks de la fiche principale.
            f.dgValuesTotal.ItemsSource = new RDMS.Stock().GetValeursTotal();
        }

        public System.Collections.Generic.List<Classes.ItemStock> GetListeSimple()
        {
            System.Collections.Generic.List<Classes.ItemStock> l = new System.Collections.Generic.List<Classes.ItemStock>();
            System.Collections.Generic.List<Classes.Price> type = new RDMS.Stock().GetPricesClothes();
            for (int i = 0; i < type.Count; ++i)
            {
                Classes.ItemStock s = new Classes.ItemStock();
                s.ClePrix = type[i].ClePrix;
                s.Prix = type[i].Prix;
                s.Label = type[i].Label;
                l.Add(s);
            }
            return l;
        }

        private System.Collections.Generic.List<Classes.ItemStock> GetListeItems()
        {

            liste = new System.Collections.Generic.List<Classes.ItemStock>();
            System.Collections.IEnumerable l = dgStock.ItemsSource;
            foreach (var i in l)
            {
                liste.Add((Classes.ItemStock)i);
            }
            return liste;
        }

        private void BtnPrice_Click(object sender, RoutedEventArgs e)
        {
            Price f = new Price();
            f.Owner = this;
            f.Show();
        }
    }
}
