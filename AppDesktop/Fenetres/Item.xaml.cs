using System.Windows;

namespace AppDesktop.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Item.xaml
    /// </summary>
    public partial class Item : Window
    {
        public Item()
        {
            InitializeComponent();

            new Utilitaires.GestionComboBox().SetBrand(cbBrand);
            new Utilitaires.GestionComboBox().SetSize(cbSize);
            new Utilitaires.GestionComboBox().SetColor(cbColor);
            new Utilitaires.GestionComboBox().SetKindClothes(cbCategory);
            new Utilitaires.GestionComboBox().SetKindBundle(cbKindBundle);
            new Utilitaires.GestionComboBox().SetGender(cbGender);

            Classes.Items item = new Classes.Items();
            gridItem.DataContext = item;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e) { Close(); }
        private void BtnCancel_Click(object sender, RoutedEventArgs e) { }

        private void BtnValidate_Click(object sender, RoutedEventArgs e)
        {
            Classes.Items item = gridItem.DataContext as Classes.Items;
            if(item != null)
            {
                if(item.CleArticle >0)
                {
                    new RDMS.Item().SetItem(item.RefArticle,item.Categorie, item.TypeArticle, item.Size, item.GenderArticle, item.Color, item.Brand, item.Description, item.Prix);
                }
                else
                {
                    new RDMS.Item().UpdItem(item.CleArticle,item.RefArticle, item.Categorie, item.TypeArticle,item.Size,item.GenderArticle,item.Color,item.Brand,item.Description,item.Prix);
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button b = sender as  System.Windows.Controls.Button;
            int i = System.Windows.Controls.Grid.GetRow(b);
            switch(i)
            {
                case 4://color
                    ReferenceSimple color = new ReferenceSimple();
                    color.lbTitre.Content = "NEW COLOR";
                    color.label.Content = "NEW COLOR";
                    color.lbox.ItemsSource = new RDMS.Item().GetColors();
                    color.lbox.DisplayMemberPath = "Label";
                    color.Owner = this;
                    color.Show();

              
                    break;
                case 6://categorie
                    ReferenceSimple categorie = new ReferenceSimple();
                    categorie.Owner = this;
                    categorie.lbTitre.Content = "NEW CLASS";
                    categorie.label.Content = "NEW CLASS";
                    categorie.lbox.ItemsSource = new RDMS.Item().GetCategories();
                    categorie.lbox.DisplayMemberPath = "Label";
                    categorie.Show();

                    break;
                case 9://picture
              
                    break;

            }
        }
    }
}
