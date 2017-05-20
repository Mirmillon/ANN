

namespace AppDesktop.Utilitaires
{
    internal class GestionComboBox
    {
        internal void SetCountry(System.Collections.Generic.List<Classes.Countries> l, System.Windows.Controls.ComboBox cb)
        {
            cb.ItemsSource = l;
            cb.SelectedValuePath = "Cle";
            cb.DisplayMemberPath = "Label";
        }
    }
}
