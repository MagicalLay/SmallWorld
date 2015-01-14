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
using Jeu;

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
                MapSize t;
                if (ecranAccueil.size == 0) {tailleSt = "petite (6x6)"; t=MapSize.Small; }
                else if (ecranAccueil.size == 1) { tailleSt = "moyenne (10x10)"; t = MapSize.Medium; }
                else {tailleSt = "grande (14x14)"; t=MapSize.Large;}

                Species s1;
                if (Peuple1.SelectedItem==Peuple1.Items[0]) {peuple1St = "Elfe"; s1=Species.Elf;}
                else if (Peuple1.SelectedItem==Peuple1.Items[1]) {peuple1St = "Orc"; s1=Species.Orc;}
                else { peuple1St = "Nain"; s1 = Species.Dwarf; }

                Species s2;
                if (Peuple2.SelectedItem==Peuple2.Items[0]) {peuple2St = "Elfe"; s2=Species.Elf;}
                else if (Peuple2.SelectedItem == Peuple2.Items[1]) { peuple2St = "Orc"; s2 = Species.Orc; }
                else { peuple2St = "Nain"; s2 = Species.Dwarf; }
                MessageBox.Show("La sélection suivante vous convient-elle ? \n taille : " + tailleSt + "\n peuple1 : " + peuple1St + "\n peuple2 : " + peuple2St, "Confirmation", MessageBoxButton.OKCancel);
                CreateBuilder cB = new CreateBuilder(t, s1, s2);
                MapToPlay carte = new MapToPlay(cB.map);
                Close();
                carte.Show();
                this.Close();
            }
        }

    }
}
