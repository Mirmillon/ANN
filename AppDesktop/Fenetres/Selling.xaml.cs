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
            tbCash.TextChanged += TbCash_TextChanged;
            System.Collections.Generic.List<Classes.ReferencesSimples> l = new RDMS.Bundle().GetKindBundles();
            gridItems.ItemsSource = GetListeSimple();
            new Utilitaires.GestionDgColumn().ColumnCbKindItem(gridItems, "TypeArticle");
            new Utilitaires.GestionDgColumn().ColumnLabel(gridItems, "NOMBRE" , "Nombre");
            gridItems.Columns[0].IsReadOnly = true;
        }
       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new Utilitaires.GestionComboBox().SetKindPayment(cbbTypePayment);
            //SALE
            Classes.Sellings sale = new Classes.Sellings();
            dgSelling.DataContext = sale;
            //CREDIT
            Classes.Credits credit = new Classes.Credits();
            dgCredit.DataContext = credit;
            //CUSTOMER
            Classes.Customers customer = new Classes.Customers();
            dgCustomer.DataContext = customer;
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
                Classes.Customers customer = dgCustomer.DataContext as Classes.Customers;
                switch (r.Label)
                {
                   
                    case "CASH":
                        cleSale = SetSelling(sale);
                        sale.Cle = cleSale;
                        SetIncome(sale);
                        f.dgSelling.ItemsSource = new RDMS.Selling().GetSellings();
                        break;
                    case "CASH-CREDIT":
                        cleSale = SetSelling(sale);
                        sale.Cle = cleSale;
                        SetIncome(sale);
                        cleCustomer = SetCustomer(customer);
                        cleCredit = SetCredit(cleCustomer, cleSale, credit);
                        new RDMS.Customer().SetCustomerSale(cleSale, cleCustomer);
                        f.dgSelling.ItemsSource = new RDMS.Selling().GetSellings();
                        break;
                    case "CREDIT":
                        cleSale = SetSelling(sale);
                        sale.Cle = cleSale;
                        SetIncome(sale);
                        cleCustomer = SetCustomer(customer);
                        cleCredit = SetCredit(cleCustomer, cleSale, credit);
                        new RDMS.Customer().SetCustomerSale(cleSale, cleCustomer);
                        f.dgSelling.ItemsSource = new RDMS.Selling().GetSellings();
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

        private int SetCustomer(Classes.Customers s)
        {
            int cle = 0;
            if (s != null)
            {
                if (tbName.Text.Trim().Length > 0 && tbLName.Text.Trim().Length > 0)
                {
                    cle = new RDMS.Customer().SetCustomer(s.Name, s.LastName, s.Phone);
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

        private void BtnCancel_Click(object sender, RoutedEventArgs e) {}

        private void CbbTypePayment_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Classes.ReferencesSimples r = cbbTypePayment.SelectedItem as Classes.ReferencesSimples;
            if (r != null)
            {
                switch (r.Label)
                {
                    case "CASH":
                        dgCredit.IsEnabled = false;
                        dgCustomer.IsEnabled = false;
                        tbCash.Text = tbAmount.Text;
                        break;
                    case "CASH-CREDIT":
                        dgCredit.IsEnabled = true;
                        dgCustomer.IsEnabled = true;
                        break;
                    case "CREDIT":
                        dgCredit.IsEnabled = true;
                        dgCustomer.IsEnabled = true;
                        tbDue.Text = tbAmount.Text;
                        tbCash.Text = "0";
                        break;
                }
            }
        }

        private void TextBoxNombre_Changed(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //int total = 0;
            //foreach (System.Windows.Controls.Control c in gridItems.Children)
            //{
            //        System.Windows.Controls.TextBox t = c as System.Windows.Controls.TextBox;
                
            //        if (t != null && t.Text.Trim().Length >0)
            //        {
            //            int i = System.Convert.ToInt32(t.Text);
            //            total += i;
            //            tbNbItem.Text = total.ToString();

            //        }
            //}
        }

        private System.Collections.Generic.List<Classes.ItemsSale> GetListeSimple()
        {
            System.Collections.Generic.List<Classes.ItemsSale> l = new System.Collections.Generic.List<Classes.ItemsSale>();
            System.Collections.Generic.List<Classes.ReferencesSimples> type = new RDMS.Bundle().GetKindBundles();
            for (int i = 0; i < type.Count; ++i)
            {
                Classes.ItemsSale s = new Classes.ItemsSale();
                s.TypeArticle = type[i].Cle;
                l.Add(s);
            }
            return l;
        }    
    }
}
