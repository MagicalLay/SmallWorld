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

        public static int size;
        private void ClickValidate(object sender, RoutedEventArgs e)
        {
            if(comboBoxTaille.SelectedItem==comboBoxTaille.Items[0]) {
                size = 0;
            }
            else if (comboBoxTaille.SelectedItem == comboBoxTaille.Items[1])
            {
                size = 1;
            }
            else if (comboBoxTaille.SelectedItem == comboBoxTaille.Items[2])
            {
                size = 2;
            }
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
