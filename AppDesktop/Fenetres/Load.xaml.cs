using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppDesktop.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Load.xaml
    /// </summary>
    public partial class Load : Window
    {
        public Load()
        {
            InitializeComponent();

            DataContext = new Classes.Sellings();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnValidate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
