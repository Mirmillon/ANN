using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDesktop.Classes
{
    public class Price
    {
        int cle;
        string code;
        double prix;
        string label;

        public string Code { get => code; set => code = value; }
        public double Prix { get => prix; set => prix = value; }
        public int ClePrix { get => cle; set => cle = value; }
        public string Label { get => label; set => label = value; }
    }
}
