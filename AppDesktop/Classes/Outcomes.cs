

namespace AppDesktop.Classes
{
    internal class Outcomes : System.ComponentModel.INotifyPropertyChanged
    {
        private int cle;
        private System.DateTime dateOutcome = System.DateTime.Today;
        private int cleTypeOutcome;
        private double montant;
        private string note;
        private int categorie;

        public int Cle { get => cle; set => cle = value; }
        public System.DateTime DateOutcome { get => dateOutcome; set => dateOutcome = value; }
        public int CleTypeOutcome { get => cleTypeOutcome; set => cleTypeOutcome = value; }
        public double Montant { get => montant; set => montant = value; }
        public string Note { get => note; set => note = value; }
        public int Categorie { get => categorie; set => categorie = value; }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propName));
            }
        }
    }
}
