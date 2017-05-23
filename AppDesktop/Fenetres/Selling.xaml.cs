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
            Classes.Sellings selling = new Classes.Sellings();
            dgSelling.DataContext = selling;
            Classes.Credits credit = new Classes.Credits();
            dgCredit.DataContext = credit;
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

                int cleSelling = 0;
                int cleCustomer = 0;
                int cleCredit = 0;
                Classes.Credits credit = dgCredit.DataContext as Classes.Credits;
                Classes.Sellings s = dgSelling.DataContext as Classes.Sellings;
                switch (r.Label)
                {
                   
                    case "CASH":
                        cleSelling = SetSelling(s);
                        break;
                    case "CASH-CREDIT":
                        cleSelling = SetSelling(s);
                        cleCustomer = SetCustomer(credit.Client);
                        cleCredit = SetCredit(cleCustomer, cleSelling, credit);
                        break;
                    case "CREDIT":
                        cleSelling = SetSelling(s);
                        cleCustomer = SetCustomer(credit.Client);
                        cleCredit = SetCredit(cleCustomer, cleSelling, credit);
                        break;
                }
            }
        }


        private int SetCredit(int cleClient, int cleSelling, Classes.Credits s)
        {
            int cle = 0;
            if (s != null)
            {
                if (cbbTypePayment.SelectedIndex != -1 &&  tbDue.Text.Trim().Length > 0)
                {
                    cle = new RDMS.Credit().SetCredit(cleClient, cleSelling, s.DateDue);
                }
            }
            return cle;
        }

        private int SetSelling(Classes.Sellings s)
        {
            int cle = 0;
            if (s != null)
            {
                if (cbbTypePayment.SelectedIndex != -1 && tbNbItem.Text.Trim().Length > 0 && tbAmount.Text.Trim().Length > 0 && tbCash.Text.Trim().Length > 0)
                {
                   cle = new  RDMS.Selling().SetSelling((int)cbbTypePayment.SelectedValue, s.DateSelling, s.NbItems, s.Amount, s.Cash);
                }
            }
            return cle;
        }

        private int SetCustomer(Classes.Customers s)
        {
            int cle = 0;
            if (s != null)
            {
                if (tbName.Text.Trim().Length > 0 && tbLName.Text.Trim().Length > 0)
                {
                    cle = new RDMS.Customer().SetCustomer(s.Name, s.MiddleName, s.LastName, s.Phone);
                }
            }
            return cle;
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
