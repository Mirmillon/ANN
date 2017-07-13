

namespace AppDesktop.Utilitaires
{
    internal class GestionComboBox
    {
        internal void SetCountry(System.Windows.Controls.ComboBox cb)
        {
            SetCbReferenceSimple(cb).ItemsSource =  new RDMS.Country().GetCountries();
        }

        internal void SetBrand(System.Windows.Controls.ComboBox cb)
        {
            SetCbReferenceSimple(cb).ItemsSource = new RDMS.Brand().GetBrands();
        }

        internal void SetProvider(System.Windows.Controls.ComboBox cb)
        {
            cb.ItemsSource = new RDMS.Provider().GetProviders();
            cb.SelectedValuePath = "Cle";
            cb.DisplayMemberPath = "FullName";
        }

        internal void SetKindBundle(System.Windows.Controls.ComboBox cb)
        {
            SetCbReferenceSimple(cb).ItemsSource = new RDMS.Bundle().GetKindBundles();
        }

        internal void SetKindPayment(System.Windows.Controls.ComboBox cb)
        {
            SetCbReferenceSimple(cb).ItemsSource = new RDMS.Payment().GetKindPayment();
        }

        internal void SetKindOutcome(System.Windows.Controls.ComboBox cb)
        {
            SetCbReferenceSimple(cb).ItemsSource = new RDMS.Outcome().GetKindOutcome();
        }

        internal void SetCategoriesOutcome(System.Windows.Controls.ComboBox cb)
        {
            SetCbReferenceSimple(cb).ItemsSource = new RDMS.Outcome().GetCatagoriesOutcome();
        }

        internal void SetCustomer(System.Windows.Controls.ComboBox cb)
        {
            cb.ItemsSource = new RDMS.Customer().GetCustomers();
            cb.SelectedValuePath = "Cle";
            cb.DisplayMemberPath = "FullName";
        }

        internal void SetOutcome(System.Windows.Controls.ComboBox cb)
        {
            SetCbReferenceSimple(cb).ItemsSource = new RDMS.Outcome().GetKindOutcome();
        }

        internal void SetGender(System.Windows.Controls.ComboBox cb)
        {
            SetCbReferenceSimple(cb).ItemsSource = new RDMS.Item().GetGenders();
        }

        internal void SetSize(System.Windows.Controls.ComboBox cb)
        {
            SetCbReferenceSimple(cb).ItemsSource = new RDMS.Item().GetSizes();
        }

        internal void SetColor(System.Windows.Controls.ComboBox cb)
        {
            SetCbReferenceSimple(cb).ItemsSource = new RDMS.Item().GetColors();
        }


        internal void SetKindClothes(System.Windows.Controls.ComboBox cb)
        {
            SetCbReferenceSimple(cb).ItemsSource = new RDMS.Item().GetCategories();
        }

        private System.Windows.Controls.ComboBox SetCbReferenceSimple(System.Windows.Controls.ComboBox cb)
        {
            cb.SelectedValuePath = "Cle";
            cb.DisplayMemberPath = "Label";
            return cb;
        }



    }
}
