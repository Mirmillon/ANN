
using System.Windows;

namespace AppDesktop
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        System.Windows.Data.CollectionView viewBrand = null;

        public MainWindow()
        {
            InitializeComponent();
            //BRAND
            dgBrand.SelectionChanged += DgBrand_SelectionChanged;
            cbbCountryBrand.SelectionChanged += CbbCountryBrand_SelectionChanged;
            radioButtonNewBrand.Checked += RadioNew_Checked;
            radioButtonModifyBrand.Checked += RadioModify_Checked;
            //BUNDLE
            dgBundle.SelectionChanged += DgBundle_SelectionChanged;
            radioButtonNewBundle.Checked += RadioNew_Checked;
            radioButtonModifyBundle.Checked += RadioModify_Checked;
            //
            dgProvider.SelectionChanged += DgProvider_SelectionChanged;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //PROVIDER
            dgProvider.ItemsSource = new RDMS.Provider().GetProviders();
            dgProviderBundle.ItemsSource = new RDMS.Bundle().GetProviderBundles();
            new Utilitaires.GestionComboBox().SetKindBundle(cbbKindNewBundle);
            new Utilitaires.GestionComboBox().SetProvider(cbbProviderNewBundle);
            new Utilitaires.GestionComboBox().SetCountry(cbbCountryNewBundle);

            //BUNDLES
            new Utilitaires.GestionComboBox().SetBrand(cbbBrandNewBundle);
            new Utilitaires.GestionComboBox().SetBrand(cbbBrandModifyBundle);
            //
            dgBundle.ItemsSource = new RDMS.Bundle().GetBundles();
            new Utilitaires.GestionDgColumn().ColumnLabel(dgBundle, "LABEL");
            new Utilitaires.GestionDgColumn().ColumnBrand(dgBundle, "CleBrand");
            new Utilitaires.GestionDgColumn().ColumnLabel(dgBundle, "WEIGHT", "Weight");
            new Utilitaires.GestionDgColumn().ColumnLabelNote(dgBundle);




            //BRAND
            //Set up cbb countries
            new Utilitaires.GestionComboBox().SetCountry(cbbCountryBrand);
            new Utilitaires.GestionComboBox().SetCountry(cbbCountryNewBrand);
            new Utilitaires.GestionComboBox().SetCountry(cbbCountryModifyBrand);
            //Binding dataGrid
            dgBrand.ItemsSource = new RDMS.Brand().GetBrands();
            viewBrand = (System.Windows.Data.CollectionView)System.Windows.Data.CollectionViewSource.GetDefaultView(dgBrand.ItemsSource);
            new Utilitaires.GestionDgColumn().ColumnLabel(dgBrand, "BRAND");
            new Utilitaires.GestionDgColumn().ColumnCountry(dgBrand, new RDMS.Country().GetCountries());
        }



        private void RadioModify_Checked(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.RadioButton rb = sender as System.Windows.Controls.RadioButton;
            switch (rb.Name)
            {
                case "radioButtonModifyBrand":
                    gbNewBrand.IsEnabled = false;
                    gbModifyBrand.IsEnabled = true;
                    tbNewBrand.Text = System.String.Empty;
                    tbNoteNewBrand.Text = System.String.Empty;
                    cbbCountryNewBrand.SelectedIndex = -1;
                    break;
                case "radioButtonModifyBundle":
                    gbNewBundle.IsEnabled = false;
                    gbModifyBundle.IsEnabled = true;
                    tbNewBundle.Text = System.String.Empty;
                    tbNoteNewBundle.Text = System.String.Empty;
                    tbWeightNewBundle.Text = System.String.Empty;
                    cbbBrandNewBundle.SelectedIndex = -1;
                    break;
            }
        }

        private void RadioNew_Checked(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.RadioButton rb = sender as System.Windows.Controls.RadioButton;
            switch (rb.Name)
            {
                case "radioButtonNewBrand":
                    gbNewBrand.IsEnabled = true;
                    gbModifyBrand.IsEnabled = false;
                    tbModifyBrand.Text = System.String.Empty;
                    tbNoteModifyBrand.Text = System.String.Empty;
                    cbbCountryModifyBrand.SelectedIndex = -1;
                    break;
                case "radioButtonNewBundle":
                    gbNewBundle.IsEnabled = true;
                    gbModifyBundle.IsEnabled = false;
                    tbModifyBundle.Text = System.String.Empty;
                    tbNoteModifyBundle.Text = System.String.Empty;
                    tbWeightModifyBundle.Text = System.String.Empty;
                    cbbBrandModifyBundle.SelectedIndex = -1;
                    break;
            }
        }

        private void BtnLateralGauche_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button bt = sender as System.Windows.Controls.Button;
            if (bt.Content != null)
            {
                switch (bt.Content.ToString())
                {
                    case "DASHBOARD":
                        lbTitle.Content = "ANN'S BUSINESS - DASHBOARDS";
                        btnNew.Visibility = Visibility.Collapsed;
                        break;
                    case "SELLINGS":
                        lbTitle.Content = "ANN'S BUSINESS - SELLINGS MANAGEMENT";
                        btnNew.Visibility = Visibility.Collapsed;
                        break;
                    case "CREDITS":
                        lbTitle.Content = "ANN'S BUSINESS - CREDITS MANAGEMENT";
                        btnNew.Visibility = Visibility.Collapsed;
                        break;
                    case "STOCKS":
                        lbTitle.Content = "ANN'S BUSINESS - STOCKS MANAGEMENT";
                        btnNew.Visibility = Visibility.Collapsed;
                        break;
                    case "PROVIDERS":
                        lbTitle.Content = "ANN'S BUSINESS - PROVIDERS MANAGEMENT : SEE, MODIFY AND DELETE PROVIDER AND CHOOSE BUNDLES";
                        btnNew.Visibility = Visibility.Visible;
                        btnNew.Content = "NEW PROVIDER";
                        break;
                    case "BUNDLES":
                        lbTitle.Content = "ANN'S BUSINESS - BUNDLES  MANAGEMENT";
                        btnNew.Visibility = Visibility.Collapsed;
                        break;
                    case "BRANDS":
                        lbTitle.Content = "ANN'S BUSINESS - BRANDS  MANAGEMENT";
                        btnNew.Visibility = Visibility.Collapsed;
                        break;
                    case "OUTCOMES":
                        lbTitle.Content = "ANN'S BUSINESS - OUTCOME  MANAGEMENT";
                        btnNew.Visibility = Visibility.Visible;
                        btnNew.Content = "NEW OUTCOME";
                        break;
                }
            }
            new Personnes.Classes.Utilitaires.GestionGrille().GridVisibilty(gridCentre, stackPanelGauche.Children.IndexOf((UIElement)sender));
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e )  {Close();}

        private void BtnValidate_Click(object sender, RoutedEventArgs e)
        {
            switch (new Personnes.Classes.Utilitaires.GestionGrille().GetIndexGrille(gridCentre))
            {
                case 0:

                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                   
                    break;
                case 5:
                    if (radioButtonNewBundle.IsChecked == true)
                    {
                        if (cbbBrandNewBundle.SelectedIndex != -1 && tbNewBundle.Text.Trim().Length > 1 && tbWeightNewBundle.Text.Trim().Length > 1)
                        {
                            Classes.Brands c = cbbBrandNewBundle.SelectedItem as Classes.Brands;
                            int cleBundle = new RDMS.Bundle().SetBundle(c.Cle, (int)cbbKindNewBundle.SelectedValue,(int)cbbCountryNewBundle.SelectedValue, tbNewBundle.Text, System.Convert.ToInt32(tbWeightNewBundle.Text), tbNoteNewBundle.Text);
                            if (cleBundle > 0)
                            {
                                btnOK.Background = System.Windows.Media.Brushes.Green;
                                dgBundle.ItemsSource = null;
                                dgBundle.ItemsSource = new RDMS.Bundle().GetBundles();
                            }
                            else
                            {
                                btnOK.Background = System.Windows.Media.Brushes.Red;
                            }
                            if(cbbProviderNewBundle.SelectedIndex != -1)
                            {
                                int i = new RDMS.Bundle().SetBundleProvider((int)cbbProviderNewBundle.SelectedValue, cleBundle, System.Convert.ToDouble(tbPriceNewBundle.Text), null);
                            }
                        }
                    }
                    else
                    {
                       

                    }

                    break;
                case 6://Brands
                    if (radioButtonNewBrand.IsChecked == true)
                    {
                        if(cbbCountryNewBrand.SelectedIndex != -1 && tbNewBrand.Text.Trim().Length > 1)
                        {
                            Classes.Countries c = cbbCountryNewBrand.SelectedItem as Classes.Countries; 
                            int cleBrand = new RDMS.Brand().SetBrand(c.Cle, tbNewBrand.Text,tbNoteNewBrand.Text);
                            if(cleBrand > 0)
                            {
                                btnOK.Background = System.Windows.Media.Brushes.Green;
                                dgBrand.ItemsSource = null;
                                dgBrand.ItemsSource = new RDMS.Brand().GetBrands();
                            }
                            else
                            {
                                btnOK.Background = System.Windows.Media.Brushes.Red;
                            }
                        }
                    }
                    else
                    {
                        Classes.Brands brand = gbModifyBrand.DataContext as Classes.Brands;
                        if(brand != null)
                        {
                            new RDMS.Brand().UpdBrand(brand.Cle, brand.Label, brand.Note);
                        }
                        
                    }
                    break;
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            switch (new Personnes.Classes.Utilitaires.GestionGrille().GetIndexGrille(gridCentre))
            {
                case 0:

                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:
                    Fenetres.Provider f = new Fenetres.Provider();
                    f.ShowDialog();
                    if (f.DialogResult == true)
                    {
                        btnOK.Background = System.Windows.Media.Brushes.Green;
                    }

                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:


                    break;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        #region ONGLET PROVIDER
        private void DgProvider_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Classes.Providers p = dgProvider.SelectedItem as Classes.Providers;
            if(p != null)
            {

            }
        }


        private bool FilterBundleProvider(object o)
        {
            return (o as Classes.Bundles).CleProvider == (int)dgProvider.SelectedValue;
        }
        #endregion END ONGLET PROVIDER

        #region ONGLET BUNDLE
        private void DgBundle_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Classes.Bundles bundle = dgBundle.SelectedItem as Classes.Bundles;
            if(bundle != null)
            {
                gbModifyBundle.DataContext = bundle;
                System.Windows.Data.Binding b = new System.Windows.Data.Binding("Label");
                tbModifyBundle.SetBinding(System.Windows.Controls.TextBox.TextProperty, b);
                System.Windows.Data.Binding b1 = new System.Windows.Data.Binding("CleBrand");
                cbbBrandModifyBundle.SetBinding(System.Windows.Controls.ComboBox.SelectedValueProperty, b1);
                System.Windows.Data.Binding b3 = new System.Windows.Data.Binding("Weight");
                tbWeightModifyBundle.SetBinding(System.Windows.Controls.TextBox.TextProperty, b3);
                System.Windows.Data.Binding b2 = new System.Windows.Data.Binding("Note");
                tbNoteModifyBundle.SetBinding(System.Windows.Controls.TextBox.TextProperty, b2);
            }
        }
        #endregion FIN ONGLET BUNDLE

        #region ONGLET BRAND
        private void DgBrand_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Classes.Brands brand = dgBrand.SelectedItem as Classes.Brands;
            if (brand != null)
            {
                gbModifyBrand.DataContext = brand;
                System.Windows.Data.Binding b = new System.Windows.Data.Binding("Label");
                tbModifyBrand.SetBinding(System.Windows.Controls.TextBox.TextProperty, b);
                System.Windows.Data.Binding b1 = new System.Windows.Data.Binding("CleCountry");
                cbbCountryModifyBrand.SetBinding(System.Windows.Controls.ComboBox.SelectedValueProperty, b1);
                System.Windows.Data.Binding b2 = new System.Windows.Data.Binding("Note");
                tbNoteModifyBrand.SetBinding(System.Windows.Controls.TextBox.TextProperty, b2);
            }
        }

        private void CbbCountryBrand_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbbCountryBrand.SelectedItem is Classes.Countries) { viewBrand.Filter = FilterBrand; }
        }

        private bool FilterBrand(object o) { return (o as Classes.Brands).CleCountry == (int)cbbCountryBrand.SelectedValue; }

        #endregion FIN ONGLET BRAND


    }
}
