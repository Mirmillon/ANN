

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
    }
}
