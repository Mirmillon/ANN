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
            gridItems.ItemsSource = GetListeSimple();
            new Utilitaires.GestionDgColumn().ColumnCbKindItem(gridItems, "TypeArticle");
            new Utilitaires.GestionDgColumn().ColumnLabel(gridItems, "NOMBRE" , "Nombre");
            gridItems.Columns[0].IsReadOnly = true;
            gridItems.RowEditEnding += GridItems_RowEditEnding;

        }

        private void GridItems_RowEditEnding(object sender, System.Windows.Controls.DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == System.Windows.Controls.DataGridEditAction.Commit)
            {
                SetNombre();
            }
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
                        cleSale = SetSale(sale);
                        sale.Cle = cleSale;
                        SetIncome(sale);
                        SetListeItems(cleSale);
                        f.dgSelling.ItemsSource = new RDMS.Selling().GetSellings();
                        break;
                    case "CASH-CREDIT":
                        cleSale = SetSale(sale);
                        sale.Cle = cleSale;
                        SetIncome(sale);
                        SetListeItems(cleSale);
                        cleCustomer = SetCustomer(customer);
                        cleCredit = SetCredit(cleCustomer, cleSale, credit);
                        new RDMS.Customer().SetCustomerSale(cleSale, cleCustomer);
                        f.dgSelling.ItemsSource = new RDMS.Selling().GetSellings();
                        break;
                    case "CREDIT":
                        cleSale = SetSale(sale);
                        sale.Cle = cleSale;
                        SetIncome(sale);
                        SetListeItems(cleSale);
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
                    cle = new RDMS.Credit().SetCredit(cleClient, cleSelling, s.DateDue, System.Convert.ToDouble(tbDue.Text));
                }
            }
            return cle;
        }

        private int SetSale(Classes.Sellings s)
        {
            int cle = 0;
            if (s != null)
            {
                if (cbbTypePayment.SelectedIndex != -1 && tbNbItem.Text.Trim().Length > 0 && tbAmount.Text.Trim().Length > 0 && tbCash.Text.Trim().Length > 0)
                {
                   cle = new  RDMS.Selling().SetSale(s.TypePayment, s.DateSelling, System.Convert.ToInt32(tbNbItem.Text), s.Amount, System.Convert.ToDouble( tbCash.Text));
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

        private void BtnCancel_Click(object sender, RoutedEventArgs e){ }

        private void CbbTypePayment_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Classes.ReferencesSimples r = cbbTypePayment.SelectedItem as Classes.ReferencesSimples;

            if (r != null)
            {
                SetNombre();
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
        
        private int GetNombre()
        {
            int nombre = 0;
            System.Collections.Generic.List<Classes.ItemsSale> liste = GetListeItems();
            for (int i = 0;i < liste.Count;++i)
            {
                nombre += liste[i].Nombre;
            }

            return nombre;
        }

        private void SetNombre()
        {
            tbNbItem.Text = System.String.Empty;
            tbNbItem.Text = GetNombre().ToString();
        }

        private System.Collections.Generic.List<Classes.ItemsSale>  GetListeItems()
        {

            System.Collections.Generic.List<Classes.ItemsSale> liste = new System.Collections.Generic.List<Classes.ItemsSale>();
            System.Collections.IEnumerable l = gridItems.ItemsSource;
            foreach (var i in l)
            {
                liste.Add((Classes.ItemsSale)i);
            }
            return liste;
        }

        private void  SetListeItems(int cleVente)
        {
            System.Collections.Generic.List<Classes.ItemsSale> liste = GetListeItems();
            foreach(Classes.ItemsSale item in liste)
            {
                if(item.Nombre > 0)
                {
                    new RDMS.Selling().SetItemSale(cleVente, item.TypeArticle, item.Nombre);
                }
            }
        }
    }
}
