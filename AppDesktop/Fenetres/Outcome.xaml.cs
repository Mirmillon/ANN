using System.Windows;

namespace AppDesktop.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Outcome.xaml
    /// </summary>
    public partial class Outcome : Window
    {
        public Outcome()
        {
            InitializeComponent();
            Classes.Outcomes outcome = new Classes.Outcomes();
            gridMain.DataContext = outcome;

            new Utilitaires.GestionComboBox().SetKindOutcome(cbTypeOutcome);
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e){ Close();}

        private void BtnValidate_Click(object sender, RoutedEventArgs e)
        {
            Classes.Outcomes outcome = gridMain.DataContext as Classes.Outcomes;
            if(tbMontant.Text.Trim().Length > 0 && cbTypeOutcome.SelectedIndex != -1)
            {
                int c = new RDMS.Outcome().SetOutcome(outcome.DateOutcome, outcome.CleTypeOutcome, outcome.Montant, outcome.Note);
                MainWindow f = (MainWindow)Owner;
                if (c>0)
                {
                   
                    f.btnOK.Background = System.Windows.Media.Brushes.Green;
                }
                else { f.btnOK.Background = System.Windows.Media.Brushes.Red; }

            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e){}
    }
}
