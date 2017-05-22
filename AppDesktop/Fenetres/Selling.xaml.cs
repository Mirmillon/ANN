using System.Windows;

namespace AppDesktop.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Selling.xaml
    /// </summary>
    public partial class Selling : Window
    {
        public Selling()
        {
            InitializeComponent();
            cbbTypePayment.SelectionChanged += CbbTypePayment_SelectionChanged;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new Utilitaires.GestionComboBox().SetKindPayment(cbbTypePayment);
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e){Close();}

        private void BtnValidate_Click(object sender, RoutedEventArgs e)
        {
            Classes.ReferencesSimples r = cbbTypePayment.SelectedItem as Classes.ReferencesSimples;
            if (r != null)
            {
                switch (r.Label)
                {
                    case "CASH":
                         
                        break;
                    case "CASH-CREDIT":
                     
                        break;
                    case "CREDIT":
                     
                        break;
                }
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CbbTypePayment_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Classes.ReferencesSimples r = cbbTypePayment.SelectedItem as Classes.ReferencesSimples;
            if (r != null)
            {
                switch (r.Label)
                {
                    case "CASH":
                        dgCredit.IsEnabled = false;
                        System.Windows.Data.Binding b = new System.Windows.Data.Binding("Text");
                        b.ElementName = "tbAmount";
                        tbCash.SetBinding(System.Windows.Controls.TextBox.TextProperty, b);
                        break;
                    case "CASH-CREDIT":
                        dgCredit.IsEnabled = true;
                        System.Windows.Data.BindingOperations.ClearBinding(tbCash, System.Windows.Controls.TextBox.TextProperty);
                        break;
                    case "CREDIT":
                        dgCredit.IsEnabled = true;
                        System.Windows.Data.BindingOperations.ClearBinding(tbCash, System.Windows.Controls.TextBox.TextProperty);
                        System.Windows.Data.Binding b2 = new System.Windows.Data.Binding("Text");
                        b2.ElementName = "tbAmount";
                        tbDue.SetBinding(System.Windows.Controls.TextBox.TextProperty, b2);
                        tbCash.Text = "0";
                        break;
                }
            }
        }
    }
}
