using System.Windows;

namespace AppDesktop.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour ReferenceSimple.xaml
    /// </summary>
    public partial class ReferenceSimple : Window
    {
        public ReferenceSimple()
        {
            InitializeComponent();
            Classes.ReferencesSimples r = new Classes.ReferencesSimples();
            grid.DataContext = r;
            

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e){ Close(); }
        private void BtnCancel_Click(object sender, RoutedEventArgs e){}

        private void BtnValidate_Click(object sender, RoutedEventArgs e)
        {
            Classes.ReferencesSimples r = grid.DataContext as Classes.ReferencesSimples;
            Item f = Owner as Item;
            string s = label.Content.ToString();
            switch(s)
            {
                case "NEW COLOR":
                    if(r != null)
                    {
                       int cle =  new RDMS.Item().SetColor(r.Label);
                       if (cle > 0)
                        {
                            f.cbColor.ItemsSource = new RDMS.Item().GetColors();
                            btnValidate.IsEnabled = false;
                        }

                    }

                    break;
                case "NEW CLASS":
                    if (r != null)
                    {
                        int cle = new RDMS.Item().SetCategorie(r.Label);
                        if (cle > 0)
                        {
                            f.cbCategory.ItemsSource = new RDMS.Item().GetCategories();
                            btnValidate.IsEnabled = false;
                        }

                    }
                    break;
                case "NEW BRAND":
                    if (r != null)
                    {
                        int cle = new RDMS.Brand().SetBrand(0,r.Label,null);
                        if (cle > 0)
                        {
                            f.cbCategory.ItemsSource = new RDMS.Brand().GetBrands();
                            btnValidate.IsEnabled = false;
                        }

                    }
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
