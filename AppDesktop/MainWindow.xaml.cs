using System;
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


            dgBrand.SelectionChanged += DgBrand_SelectionChanged;
            cbbCountryBrand.SelectionChanged += CbbCountryBrand_SelectionChanged;
            radioButtonNewBrand.Checked += RadioNew_Checked;
            radioButtonModifyBrand.Checked += RadioModify_Checked;
        }

        private void RadioModify_Checked(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.RadioButton rb = sender as System.Windows.Controls.RadioButton;
            switch (rb.Content.ToString())
            {
                case "Modify a brand":
                    gbNewBrand.IsEnabled = false;
                    gbModifyBrand.IsEnabled = true;
                    tbNewBrand.Text = String.Empty;
                    tbNoteNewBrand.Text = String.Empty;
                    cbbCountryNewBrand.SelectedIndex = -1;
                    break;
            }
        }

        private void RadioNew_Checked(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.RadioButton rb = sender as System.Windows.Controls.RadioButton;
            switch(rb.Content.ToString())
            {
                case "Add a new brand":
                    gbNewBrand.IsEnabled = true;
                    gbModifyBrand.IsEnabled = false;
                    tbModifyBrand.Text = String.Empty;
                    tbNoteModifyBrand.Text = String.Empty;
                    cbbCountryModifyBrand.SelectedIndex = -1;
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //BRAND
            //Get countries
            System.Collections.Generic.List<Classes.Countries> lc = new RDMS.Country().GetCountries();
            //Set up cbb countries
            new Utilitaires.GestionComboBox().SetCountry(lc, cbbCountryBrand);
            new Utilitaires.GestionComboBox().SetCountry(lc, cbbCountryNewBrand);
            new Utilitaires.GestionComboBox().SetCountry(lc, cbbCountryModifyBrand);
            //Binding dataGrid
            dgBrand.ItemsSource = new RDMS.Brand().GetBrands();
            viewBrand = (System.Windows.Data.CollectionView)System.Windows.Data.CollectionViewSource.GetDefaultView(dgBrand.ItemsSource);
            new Utilitaires.GestionDgColumn().ColumnLabel(dgBrand, "BRAND");
            new Utilitaires.GestionDgColumn().ColumnCountry(dgBrand, lc);

            
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
                        break;
                    case "SELLINGS":
                        lbTitle.Content = "ANN'S BUSINESS - SELLINGS MANAGEMENT";
                        break;
                    case "CREDITS":
                        lbTitle.Content = "ANN'S BUSINESS - CREDITS MANAGEMENT";
                        break;
                    case "STOCKS":
                        lbTitle.Content = "ANN'S BUSINESS - STOCKS MANAGEMENT";
                        break;
                    case "PROVIDERS":
                        lbTitle.Content = "ANN'S BUSINESS - PROVIDERS MANAGEMENT : SEE, MODIFY AND DELETE PROVIDER";
                        break;
                    case "BUNDLES":
                        lbTitle.Content = "ANN'S BUSINESS - BUNDLES  MANAGEMENT";
                        break;
                    case "BRANDS":
                        lbTitle.Content = "ANN'S BUSINESS - BRANDS  MANAGEMENT";
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

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

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

            if (cbbCountryBrand.SelectedItem is Classes.Countries)
            {
                viewBrand.Filter = FilterBrand;
            }
        }

        private bool FilterBrand(object o)
        {
            
                return (o as Classes.Brands).CleCountry == (int)cbbCountryBrand.SelectedValue;

           
        }


    }
}
