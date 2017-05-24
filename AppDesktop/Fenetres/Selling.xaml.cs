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
            dpDateSale.SelectedDate = System.DateTime.Today;
            tbCash.TextChanged += TbCash_TextChanged;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new Utilitaires.GestionComboBox().SetKindPayment(cbbTypePayment);
            //SALE
            Classes.Sellings sale = new Classes.Sellings();
            dgSelling.DataContext = sale;
            //System.Windows.Data.Binding b1 = new System.Windows.Data.Binding("DateSelling");
            //dpDateSale.SetBinding(System.Windows.Controls.DatePicker.TextProperty, b1);
            System.Windows.Data.Binding b2 = new System.Windows.Data.Binding("NbItems");
            tbNbItem.SetBinding(System.Windows.Controls.TextBox.TextProperty, b2);
            System.Windows.Data.Binding b3 = new System.Windows.Data.Binding("Amount");
            tbAmount.SetBinding(System.Windows.Controls.TextBox.TextProperty, b3);
            System.Windows.Data.Binding b5 = new System.Windows.Data.Binding("Cash");
            tbCash.SetBinding(System.Windows.Controls.TextBox.TextProperty, b5);
            //CREDIT
            Classes.Credits credit = new Classes.Credits();
            dgCredit.DataContext = credit;
            System.Windows.Data.Binding c1 = new System.Windows.Data.Binding("MontantDu");
            tbDue.SetBinding(System.Windows.Controls.DatePicker.TextProperty, c1);
            System.Windows.Data.Binding c2 = new System.Windows.Data.Binding("DateDue");
            dpDateDue.SetBinding(System.Windows.Controls.DatePicker.TextProperty, c2);
            System.Windows.Data.Binding c3 = new System.Windows.Data.Binding("Provider.Name");
            tbName.SetBinding(System.Windows.Controls.TextBox.TextProperty, c3);
            System.Windows.Data.Binding c4 = new System.Windows.Data.Binding("Provider.LastName");
            tbLName.SetBinding(System.Windows.Controls.TextBox.TextProperty, c4);
            System.Windows.Data.Binding c5 = new System.Windows.Data.Binding("Provider.Phone");
            tbPhone.SetBinding(System.Windows.Controls.TextBox.TextProperty, c5);




        }

        private void BtnClose_Click(object sender, RoutedEventArgs e){Close();}

        private void BtnValidate_Click(object sender, RoutedEventArgs e)
        {
            Classes.ReferencesSimples r = cbbTypePayment.SelectedItem as Classes.ReferencesSimples;

            if (r != null)
            {

                int cleSale = 0;
                int cleCustomer = 0;
                int cleCredit = 0;
                MainWindow f = (MainWindow)Owner;
                Classes.Credits credit = dgCredit.DataContext as Classes.Credits;
                Classes.Sellings sale = dgSelling.DataContext as Classes.Sellings;
                switch (r.Label)
                {
                   
                    case "CASH":
                        cleSale = SetSelling(sale);
                        sale.Cle = cleSale;
                        f.dgSelling.ItemsSource = new RDMS.Selling().GetSellings();
                        SetIncome(sale);
                        tbCash.TextChanged -= TbCash_TextChanged;
                        break;
                    case "CASH-CREDIT":
                        cleSale = SetSelling(sale);
                        sale.Cle = cleSale;
                        SetIncome(sale);
                        cleCustomer = SetCustomer(credit);
                        cleCredit = SetCredit(cleCustomer, cleSale, credit);
                        new RDMS.Customer().SetCustomerSale(cleSale, cleCustomer);
                        f.dgSelling.ItemsSource = new RDMS.Selling().GetSellings();
                      
                        break;
                    case "CREDIT":
                        cleSale = SetSelling(sale);
                        sale.Cle = cleSale;
                        SetIncome(sale);
                        cleCustomer = SetCustomer(credit);
                        cleCredit = SetCredit(cleCustomer, cleSale, credit);
                        new RDMS.Customer().SetCustomerSale(cleSale, cleCustomer);
                        f.dgSelling.ItemsSource = new RDMS.Selling().GetSellings();
                        tbCash.TextChanged -= TbCash_TextChanged;
                        break;
                }
            }
        }

        private void TbCash_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
           if(tbCash.Text.Trim().Length>1)
           {
                tbDue.Text = System.Convert.ToString(System.Convert.ToDouble(tbAmount.Text) - System.Convert.ToDouble(tbCash.Text));
           }
        }

        private int SetCredit(int cleClient, int cleSelling, Classes.Credits s)
        {
            int cle = 0;
            if (s != null)
            {
                if (cbbTypePayment.SelectedIndex != -1 &&  tbDue.Text.Trim().Length > 0)
                {
                    cle = new RDMS.Credit().SetCredit(cleClient, cleSelling, System.Convert.ToDateTime(dpDateDue.Text), System.Convert.ToDouble(tbDue.Text));
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
                   cle = new  RDMS.Selling().SetSale((int)cbbTypePayment.SelectedValue, System.Convert.ToDateTime( dpDateSale.Text), s.NbItems, s.Amount, System.Convert.ToDouble( tbCash.Text));
                }
            }
            return cle;
        }

        private int SetCustomer(Classes.Credits s)
        {
            int cle = 0;
            if (s != null)
            {
                if (tbName.Text.Trim().Length > 0 && tbLName.Text.Trim().Length > 0)
                {
                    cle = new RDMS.Customer().SetCustomer(tbName.Text, tbLName.Text, tbPhone.Text);
                }
            }
            return cle;
        }

        private int SetIncome(Classes.Sellings s)
        {
            int cle = 0;
            if (s != null)
            {

                    cle = new RDMS.Income().SetIncome(s.Cle, System.Convert.ToDouble(tbCash.Text),s.DateSelling);
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
                        tbCash.Text = tbAmount.Text;
                        //System.Windows.Data.Binding b = new System.Windows.Data.Binding("Text");
                        //b.ElementName = "tbAmount";
                        //tbCash.SetBinding(System.Windows.Controls.TextBox.TextProperty, b);
                        break;
                    case "CASH-CREDIT":
                        dgCredit.IsEnabled = true;
                        //System.Windows.Data.BindingOperations.ClearBinding(tbCash, System.Windows.Controls.TextBox.TextProperty);
                        break;
                    case "CREDIT":
                        dgCredit.IsEnabled = true;
                        //System.Windows.Data.BindingOperations.ClearBinding(tbCash, System.Windows.Controls.TextBox.TextProperty);
                        //System.Windows.Data.Binding b2 = new System.Windows.Data.Binding("Text");
                        //b2.ElementName = "tbAmount";
                        //tbDue.SetBinding(System.Windows.Controls.TextBox.TextProperty, b2);
                        tbDue.Text = tbAmount.Text;
                        tbCash.Text = "0";
                        break;
                }
            }
        }
    }
}
