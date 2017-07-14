using System.Windows;

namespace AppDesktop.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Price.xaml
    /// </summary>
    public partial class Price : Window
    {
        public Price()
        {
            InitializeComponent();

            gridMain.DataContext = new Classes.Price();

            cbCategorie.ItemsSource = new RDMS.Selling().GetCategoriesVente();
            cbCategorie.SelectedValuePath = "Cle";
            cbCategorie.DisplayMemberPath = "Label";

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnValidate_Click(object sender, RoutedEventArgs e)
        {
            if((tbLabel.Text.Trim().Length > 0) && (tbPrice.Text.Trim().Length > 0) && (cbCategorie.SelectedIndex != 0))
            {
                Classes.Price p = gridMain.DataContext as Classes.Price;
                new RDMS.Stock().SetPrice(p.Prix, p.Label, p.Categorie);
                Stock f = (Stock)Owner;
                f.dgStock.ItemsSource = f.GetListeSimple();
            }
        }
    }
}
