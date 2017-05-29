using System.Windows;


namespace AppDesktop.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Item.xaml
    /// </summary>
    public partial class Item : Window
    {
        private Classes.Items article = null;

        public Item()
        {
            InitializeComponent();

            new Utilitaires.GestionComboBox().SetBrand(cbBrand);
            new Utilitaires.GestionComboBox().SetSize(cbSize);
            new Utilitaires.GestionComboBox().SetColor(cbColor);
            new Utilitaires.GestionComboBox().SetKindClothes(cbCategory);
            new Utilitaires.GestionComboBox().SetKindBundle(cbKindBundle);
            new Utilitaires.GestionComboBox().SetGender(cbGender);
            article = new Classes.Items();
            gridItem.DataContext = article;



        }

        public Item(int cle):this()
        {
            article = new RDMS.Item().GetItemsInStockByKey(cle);
            gridItem.DataContext = null;
            gridItem.DataContext = article;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (article != null && article.ImageSource != null)
            {
                System.Uri uri = new System.Uri(article.ImageSource);
                System.Windows.Media.Imaging.BitmapImage bitmap = new System.Windows.Media.Imaging.BitmapImage(uri);
                image.Source = bitmap;
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e) {
  
            MainWindow f = Owner as MainWindow;
            if(f!= null)
            {
                f.dgItem.ItemsSource = new RDMS.Item().GetItemsInStock();
            }
           
            Close();

        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e) {

            MessageBox.Show(Owner.GetType().ToString());
        }

        private void BtnValidate_Click(object sender, RoutedEventArgs e)
        {
            Classes.Items item = gridItem.DataContext as Classes.Items;
            if(item != null)
            {
                if(item.Cle == 0)
                {
                    new RDMS.Item().SetItem(item.RefArticle, item.Categorie, item.TypeArticle, item.Size, item.GenderArticle, item.Color, item.Brand, tbDescription.Text, System.Convert.ToDouble(tbPrix.Text),tbFileImage.Text);
                  
                }
                else
                {
                    new RDMS.Item().UpdItem(item.Cle, item.RefArticle, item.Categorie, item.TypeArticle, item.Size, item.GenderArticle, item.Color, item.Brand, tbDescription.Text, System.Convert.ToDouble(tbPrix.Text), tbFileImage.Text);
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button b = sender as  System.Windows.Controls.Button;
            int i = System.Windows.Controls.Grid.GetRow(b);
            switch(i)
            {
                case 1://color
                    ReferenceSimple brand = new ReferenceSimple();
                    brand.lbTitre.Content = "NEW BRAND";
                    brand.label.Content = "NEW BRAND";
                    brand.lbox.ItemsSource = new RDMS.Brand().GetBrands();
                    brand.lbox.DisplayMemberPath = "Label";
                    brand.Owner = this;
                    brand.Show();
                    break;

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
                    Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                    openFileDialog.Filter = "Image files (*.png;*.jpg;*.bmp;*.tiff)|*.png;*.jpg;*.bmp;*.tiff|All files (*.*)|*.*";
                    openFileDialog.InitialDirectory = @"B:\Images";
                    if (openFileDialog.ShowDialog() == true)
                    {
                        // Open document
                        string filename = openFileDialog.FileName;
                        tbFileImage.Text = filename;
                        System.Uri uri = new System.Uri(filename);
                        System.Windows.Media.Imaging.BitmapImage bitmap = new System.Windows.Media.Imaging.BitmapImage(uri);
                        image.Source = bitmap;
                    }

                    break;

            }
        }
    }
}
