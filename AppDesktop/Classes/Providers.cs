﻿

namespace AppDesktop.Classes
{
    class Providers : System.ComponentModel.INotifyPropertyChanged
    {
        int cle;
        string name;
        string middleName;
        string lastName;
        string phone;
        string note;

        public int Cle { get => cle; set => cle = value; }

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string MiddleName
        {
            get => middleName;
            set
            {
                if (middleName != value)
                {
                    middleName = value;
                    OnPropertyChanged("MiddleName");
                }
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public string Phone
        {
            get => phone;
            set
            {
                if (phone != value)
                {
                    note = value;
                    OnPropertyChanged("Phone");
                }
            }
        }

        public string Note
        {
            get => note;
            set
            {
                if (note != value)
                {
                    note = value;
                    OnPropertyChanged("Note");
                }
            }
        }

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
