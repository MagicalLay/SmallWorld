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

namespace Graphics
{
    /// <summary>
    /// Logique d'interaction pour ecranAccueil.xaml
    /// </summary>
    public partial class ecranAccueil : Window
    {
        public ecranAccueil()
        {
            InitializeComponent();
        }

        private void ClickValidate(object sender, RoutedEventArgs e)
        {
            SelectionPeuple peuples = new SelectionPeuple();
            peuples.Show();
            this.Close();
        }

        private void ClickAnnuler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
