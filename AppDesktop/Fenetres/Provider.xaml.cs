using System.Windows;

namespace AppDesktop.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Provider.xaml
    /// </summary>
    public partial class Provider : Window
    {
        Classes.Providers provider = null;

        public Provider()
        {
            InitializeComponent();
            provider = new Classes.Providers();
            mainGrid.DataContext = provider;

            System.Windows.Data.Binding b1 = new System.Windows.Data.Binding("Name");
            tbName.SetBinding(System.Windows.Controls.TextBox.TextProperty, b1);

            System.Windows.Data.Binding b2 = new System.Windows.Data.Binding("MiddleName");
            tbMName.SetBinding(System.Windows.Controls.TextBox.TextProperty, b2);

            System.Windows.Data.Binding b3 = new System.Windows.Data.Binding("LastName");
            tbLName.SetBinding(System.Windows.Controls.TextBox.TextProperty, b3);

            System.Windows.Data.Binding b4 = new System.Windows.Data.Binding("Phone");
            tbPhone.SetBinding(System.Windows.Controls.TextBox.TextProperty, b4);

            System.Windows.Data.Binding b5 = new System.Windows.Data.Binding("Note");
            tbNote.SetBinding(System.Windows.Controls.TextBox.TextProperty, b5);


        }

        private void BtnClose_Click(object sender, RoutedEventArgs e) {Close();}

        private void BtnValidate_Click(object sender, RoutedEventArgs e)
        {
            Classes.Providers p = mainGrid.DataContext as Classes.Providers;
            if(p.Cle == 0)
            {
               int c =  new RDMS.Provider().SetProvider(p.Name,p.MiddleName,p.LastName,p.Phone,p.Note);
               if(c > 0) { DialogResult = true; }
            }
            else
            {

            }

            
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

        }
    }
}
