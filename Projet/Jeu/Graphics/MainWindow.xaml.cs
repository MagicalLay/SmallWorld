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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Jeu;

namespace Graphics
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClickLoad(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure you want to quit this game ?", "Confirmation" , MessageBoxButton.OKCancel);
            Jeu.Game.endGame();
        }
        private void ClickSave(object sender, RoutedEventArgs e)
        {
            if (Jeu.Game.SaveName != "")
            {
                //Jeu.Game.save();  --> pb static à régler
                MessageBox.Show("Game successfully saved !");
            }
            else
            {
                //TODO
            }
        }
        private void ClickNext(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are sure you want to move to the next turn ?", "Confirmation", MessageBoxButton.OKCancel);
            Jeu.Game.nextTurn();
        }

        private void ClickNewGame(object sender, RoutedEventArgs e)
        {
            ecranAccueil fenetre = new ecranAccueil();
            fenetre.Show();
            //this.Close();
        }

        private void ClickLoadGame(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
