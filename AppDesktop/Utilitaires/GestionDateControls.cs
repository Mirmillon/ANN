

namespace AppDesktop.Utilitaires
{
    internal class GestionDateControls
    {
        internal void SetDatePicker(System.Windows.Controls.DatePicker dp)
        {
            dp.DisplayDateStart = new System.DateTime(System.DateTime.Today.Year, System.DateTime.Today.Month, System.DateTime.Today.Day);
            dp.DisplayDate = new System.DateTime(System.DateTime.Today.Year, System.DateTime.Today.Month, System.DateTime.Today.Day);
        }


    }
}
