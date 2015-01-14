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
    /// Logique d'interaction pour SelectionPeuple.xaml
    /// </summary>
    public partial class SelectionPeuple : Window
    {
        public SelectionPeuple()
        {
            InitializeComponent();
        }
        private void ClickAnnuler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ClickValidate(object sender, RoutedEventArgs e)
        {
            if (Peuple1.SelectedItem.ToString() == Peuple2.SelectedItem.ToString())
            {
                MessageBox.Show("Les deux joueurs ne peuvent pas avoir le même peuple", "Confirmation", MessageBoxButton.OKCancel);
            }
            else
            {
                String tailleSt;
                String peuple1St;
                String peuple2St;
                if (ecranAccueil.size == 0) tailleSt = "petite (6x6)";
                else if (ecranAccueil.size == 1) tailleSt = "moyenne (10x10)";
                else tailleSt = "grande (14x14)";

                if (Peuple1.SelectedItem==Peuple1.Items[0]) peuple1St = "Elfe";
                else if (Peuple1.SelectedItem==Peuple1.Items[1]) peuple1St = "Orc";
                else peuple1St = "Nain";

                if (Peuple2.SelectedItem==Peuple2.Items[0]) peuple2St = "Elfe";
                else if (Peuple2.SelectedItem==Peuple2.Items[1]) peuple2St = "Orc";
                else peuple2St = "Nain";
                MessageBox.Show("La sélection suivante vous convient-elle ? \n taille : " + tailleSt + "\n peuple1 : " + peuple1St + "\n peuple2 : " + peuple2St, "Confirmation", MessageBoxButton.OKCancel);
                MapToPlay carte = new MapToPlay();
                Close();
                carte.Show();
                this.Close();
            }
        }

    }
}
