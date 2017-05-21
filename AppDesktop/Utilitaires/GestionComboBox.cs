

namespace AppDesktop.Utilitaires
{
    internal class GestionComboBox
    {
        internal void SetCountry(System.Windows.Controls.ComboBox cb)
        {
            cb.ItemsSource = new RDMS.Country().GetCountries();
            cb.SelectedValuePath = "Cle";
            cb.DisplayMemberPath = "Label";
        }

        internal void SetBrand(System.Windows.Controls.ComboBox cb)
        {
            cb.ItemsSource = new RDMS.Brand().GetBrands();
            cb.SelectedValuePath = "Cle";
            cb.DisplayMemberPath = "Label";
        }

        internal void SetProvider(System.Windows.Controls.ComboBox cb)
        {
            cb.ItemsSource = new RDMS.Provider().GetProviders();
            cb.SelectedValuePath = "Cle";
            cb.DisplayMemberPath = "FullName";
        }

        internal void SetKindBundle(System.Windows.Controls.ComboBox cb)
        {
            cb.ItemsSource = new RDMS.Bundle().GetKindBundles();
            cb.SelectedValuePath = "Cle";
            cb.DisplayMemberPath = "Label";
        }

        internal void SetKindPayment(System.Windows.Controls.ComboBox cb)
        {
            cb.ItemsSource = new RDMS.Payment().GetKindPayment();
            cb.SelectedValuePath = "Cle";
            cb.DisplayMemberPath = "Label";
        }

        internal void SetKindOutcome(System.Windows.Controls.ComboBox cb)
        {
            cb.ItemsSource = new RDMS.Outcome().GetKindOutcome();
            cb.SelectedValuePath = "Cle";
            cb.DisplayMemberPath = "Label";
        }
    }
}
