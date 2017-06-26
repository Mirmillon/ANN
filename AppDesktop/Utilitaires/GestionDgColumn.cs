
namespace AppDesktop.Utilitaires
{
    internal class GestionDgColumn
    {
        internal System.Windows.Controls.DataGridTextColumn ColumnLabelNote(System.Windows.Controls.DataGrid dg)
        {
            System.Windows.Controls.DataGridTextColumn d = new System.Windows.Controls.DataGridTextColumn();
            System.Windows.Data.Binding bdgDgTextOrgane = new System.Windows.Data.Binding("Note");
            //Set the properties on the new column
            d.Binding = bdgDgTextOrgane;
            d.Header = "NOTE";
            //Add the column to the DataGrid
            dg.Columns.Add(d);
            return d;
        }


        internal System.Windows.Controls.DataGridTextColumn ColumnLabel(System.Windows.Controls.DataGrid dg, System.String header)
        {
            System.Windows.Controls.DataGridTextColumn d = new System.Windows.Controls.DataGridTextColumn();
            System.Windows.Data.Binding bdgDgTextOrgane = new System.Windows.Data.Binding("Label");
            //Set the properties on the new column
            d.Binding = bdgDgTextOrgane;
            d.Header = header;
            //Add the column to the DataGrid
            dg.Columns.Add(d);
            return d;
        }

        internal System.Windows.Controls.DataGridTextColumn ColumnLabel(System.Windows.Controls.DataGrid dg, System.String header, string b)
        {
            System.Windows.Controls.DataGridTextColumn d = new System.Windows.Controls.DataGridTextColumn();
            System.Windows.Data.Binding bi = new System.Windows.Data.Binding(b);
            //Set the properties on the new column
            d.Binding = bi;
            d.Header = header;
            //Add the column to the DataGrid
            dg.Columns.Add(d);
            return d;
        }

        internal System.Windows.Controls.DataGridTextColumn ColumnDate(System.Windows.Controls.DataGrid dg, System.String header, string b)
        {
            System.Windows.Controls.DataGridTextColumn d = new System.Windows.Controls.DataGridTextColumn();
            System.Windows.Data.Binding bi = new System.Windows.Data.Binding(b);
            //Set the properties on the new column
            bi.StringFormat = "MM/dd/yyyy";
            d.Binding = bi;
            d.Header = header;
            //Add the column to the DataGrid
            dg.Columns.Add(d);
            return d;
        }

        internal System.Windows.Controls.DataGridComboBoxColumn ColumnCountry(System.Windows.Controls.DataGrid dg, System.Collections.Generic.List<Classes.Countries> l)
        {
            System.Windows.Controls.DataGridComboBoxColumn d = new System.Windows.Controls.DataGridComboBoxColumn();
            System.Windows.Data.Binding b = new System.Windows.Data.Binding("CleCountry");
            //Set the properties on the new column
            d.ItemsSource = l;
            d.SelectedValuePath = "Cle";
            d.DisplayMemberPath = "Label";
            d.SelectedValueBinding = b;
            d.Header = "COUNTRY";
            //Add the column to the DataGrid
            dg.Columns.Add(d);
            return d;
        }

        internal System.Windows.Controls.DataGridComboBoxColumn ColumnBrand(System.Windows.Controls.DataGrid dg, string s)
        {
            System.Windows.Controls.DataGridComboBoxColumn d = new System.Windows.Controls.DataGridComboBoxColumn();
            System.Windows.Data.Binding b = new System.Windows.Data.Binding(s);
            //Set the properties on the new column
            d.ItemsSource = new RDMS.Brand().GetBrands();
            d.SelectedValuePath = "Cle";
            d.DisplayMemberPath = "Label";
            d.SelectedValueBinding = b;
            d.Header = "BRAND";
            //Add the column to the DataGrid
            dg.Columns.Add(d);
            return d;
        }

        private System.Windows.Controls.DataGridComboBoxColumn ColumnReferenceSimple(System.Windows.Controls.DataGrid dg, System.Collections.Generic.List<Classes.ReferencesSimples> l, string s, string s1)
        {
            System.Windows.Controls.DataGridComboBoxColumn d = new System.Windows.Controls.DataGridComboBoxColumn();
            System.Windows.Data.Binding b = new System.Windows.Data.Binding(s1);
            //Set the properties on the new column
            d.ItemsSource = l;
            d.SelectedValuePath = "Cle";
            d.DisplayMemberPath = "Label";
            d.SelectedValueBinding = b;
            d.Header = s;
            //Add the column to the DataGrid
            dg.Columns.Add(d);
            return d;
        }

        internal System.Windows.Controls.DataGridComboBoxColumn ColumnCbKindPayment(System.Windows.Controls.DataGrid dg, string s )
        {

            return ColumnReferenceSimple(dg, new RDMS.Payment().GetKindPayment(), "KIND PAYMENT",s);
        }

        internal System.Windows.Controls.DataGridComboBoxColumn ColumnCbKindOutcome(System.Windows.Controls.DataGrid dg)
        {

            return ColumnReferenceSimple(dg, new RDMS.Outcome().GetKindOutcome(), "OUTCOME KIND", "CleTypeOutcome");
        }

        internal System.Windows.Controls.DataGridComboBoxColumn ColumnCustomer(System.Windows.Controls.DataGrid dg)
        {
            System.Windows.Controls.DataGridComboBoxColumn d = new System.Windows.Controls.DataGridComboBoxColumn();
            System.Windows.Data.Binding b = new System.Windows.Data.Binding("Cle");
            //Set the properties on the new column
            d.ItemsSource = new RDMS.Customer().GetCustomers();
            d.SelectedValuePath = "Cle";
            d.DisplayMemberPath = "FullName";
            d.SelectedValueBinding = b;
            d.Header = "CUSTOMER";
            //Add the column to the DataGrid
            dg.Columns.Add(d);
            return d;
        }

        internal System.Windows.Controls.DataGridComboBoxColumn ColumnCustomerCredit(System.Windows.Controls.DataGrid dg)
        {
            System.Windows.Controls.DataGridComboBoxColumn d = new System.Windows.Controls.DataGridComboBoxColumn();
            System.Windows.Data.Binding b = new System.Windows.Data.Binding("CleClient");
            //Set the properties on the new column
            d.ItemsSource = new RDMS.Customer().GetCustomers();
            d.SelectedValuePath = "Cle";
            d.DisplayMemberPath = "FullName";
            d.SelectedValueBinding = b;
            d.Header = "CUSTOMER";
            //Add the column to the DataGrid
            dg.Columns.Add(d);
            return d;
        }

        //internal System.Windows.Controls.DataGridComboBoxColumn ColumnCodeItems(System.Windows.Controls.DataGrid dg)
        //{
        //    System.Windows.Controls.DataGridComboBoxColumn d = new System.Windows.Controls.DataGridComboBoxColumn();
        //    System.Windows.Data.Binding b = new System.Windows.Data.Binding("Cle");
        //    //Set the properties on the new column
        //    d.ItemsSource = new RDMS.Stock().GetPrices();
        //    d.SelectedValuePath = "Cle";
        //    d.DisplayMemberPath = "Code";
        //    d.SelectedValueBinding = b;
        //    d.Header = "CODE";
        //    //Add the column to the DataGrid
        //    dg.Columns.Add(d);
        //    return d;
        //}

        internal System.Windows.Controls.DataGridComboBoxColumn ColumnCodeItem(System.Windows.Controls.DataGrid dg)
        {
            System.Windows.Controls.DataGridComboBoxColumn d = new System.Windows.Controls.DataGridComboBoxColumn();
            System.Windows.Data.Binding b = new System.Windows.Data.Binding("ClePrix");
            //Set the properties on the new column
            d.ItemsSource = new RDMS.Stock().GetPrices();
            d.SelectedValuePath = "ClePrix";
            d.DisplayMemberPath = "Prix";
            d.SelectedValueBinding = b;
            d.Header = "PRICE";
            //Add the column to the DataGrid
            dg.Columns.Add(d);
            return d;
        }

        internal System.Windows.Controls.DataGridComboBoxColumn ColumnPriceItems(System.Windows.Controls.DataGrid dg)
        {
            System.Windows.Controls.DataGridComboBoxColumn d = new System.Windows.Controls.DataGridComboBoxColumn();
            System.Windows.Data.Binding b = new System.Windows.Data.Binding("ClePrix");
            //Set the properties on the new column
            d.ItemsSource = new RDMS.Stock().GetPrices();
            d.SelectedValuePath = "ClePrix";
            d.DisplayMemberPath = "Prix";
            d.SelectedValueBinding = b;
            d.Header = "PRICE";
            //Add the column to the DataGrid
            dg.Columns.Add(d);
            return d;
        }

        internal System.Windows.Controls.DataGridComboBoxColumn ColumnCbKindItem(System.Windows.Controls.DataGrid dg, string s)
        {

            return ColumnReferenceSimple(dg, new RDMS.Bundle().GetKindBundles(), "ITEM KIND" , s);
        }

        internal System.Windows.Controls.DataGridComboBoxColumn ColumnCbSize(System.Windows.Controls.DataGrid dg, string s)
        {

            return ColumnReferenceSimple(dg, new RDMS.Item().GetSizes(), "SIZE", s);
        }

        internal System.Windows.Controls.DataGridComboBoxColumn ColumnCbColor(System.Windows.Controls.DataGrid dg, string s)
        {

            return ColumnReferenceSimple(dg, new RDMS.Item().GetColors(), "COLOR", s);
        }

        internal System.Windows.Controls.DataGridComboBoxColumn ColumnCbTypeClothe(System.Windows.Controls.DataGrid dg, string s)
        {

            return ColumnReferenceSimple(dg, new RDMS.Item().GetCategories(), "CLASS", s);
        }

        internal System.Windows.Controls.DataGridComboBoxColumn ColumnCbGender(System.Windows.Controls.DataGrid dg, string s)
        {

            return ColumnReferenceSimple(dg, new RDMS.Item().GetGenders(), "GENDER", s);
        }
    }
}
