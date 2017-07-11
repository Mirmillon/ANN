using System.Windows;


namespace AppDesktop.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Stock.xaml
    /// </summary>
    public partial class Stock : Window
    {
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
           
            foreach (Classes.ItemStock s in l)
            {
                if(s.Quantite > 0)
                {
                    new RDMS.Stock().UptadeStock(s.ClePrix, s.Quantite);
                }
            }
           
            //Récupération du owner
            MainWindow f = (MainWindow)Owner;
            //Mise à jour des données sur la grille des stocks de la fiche principale.
            f.dgValuesTotal.ItemsSource = new RDMS.Stock().GetValeursTotal();
        }

        private System.Collections.Generic.List<Classes.ItemStock> GetListeSimple()
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

            System.Collections.Generic.List<Classes.ItemStock> liste = new System.Collections.Generic.List<Classes.ItemStock>();
            System.Collections.IEnumerable l = dgStock.ItemsSource;
            foreach (var i in l)
            {
                liste.Add((Classes.ItemStock)i);
            }
            return liste;
        }
    }
}
