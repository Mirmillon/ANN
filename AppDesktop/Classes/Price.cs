﻿namespace AppDesktop.Classes
{
    public class Price
    {
        int cle;
        string code;
        double prix;
        string label;
        string categorie;

        public string Code { get => code; set => code = value; }
        public double Prix { get => prix; set => prix = value; }
        public int ClePrix { get => cle; set => cle = value; }
        public string Label { get => label; set => label = value; }
        public string Categorie { get => categorie; set => categorie = value; }
    }
}
