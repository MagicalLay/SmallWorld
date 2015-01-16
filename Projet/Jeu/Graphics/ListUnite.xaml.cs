using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
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
    /// Logique d'interaction pour ListUnite.xaml
    /// </summary>
    public partial class ListUnite : UserControl
    {

        public Unit Unit
        {
            get;
            private set;
        }

        public Game game;

        public ListUnite(Unit u, Game g)
        {
            game = g;
            Unit = u;
            InitializeComponent();
            //u.PropertyChanged += new PropertyChangedEventHandler(update);
            //game.PropertyChanged += new PropertyChangedEventHandler(update);
            //pbHealth.Maximum = 5 - u.hp;
           // pbHealth.Minimum = 0;
            //pbMovingPoints.Maximum = 2;
            //pbMovingPoints.Minimum = 0;
            //lblAttack.Content = Unit.attackPoints;
            //lblDefense.Content = Unit.defencePoints;
            grid.AddHandler(FrameworkElement.MouseDownEvent, new MouseButtonEventHandler(grid_MouseLeftButtonDown), true);
        }

        protected void update(object sender, PropertyChangedEventArgs e)
        {
            pbHealth.Value = Unit.hp;
            lblHealth.Content = Unit.hp + "/" + 5;
            pbMovingPoints.Value = Unit.movePoints;
            lblMovingPoints.Content = Unit.movePoints + "/" + 2;

            if (Object.ReferenceEquals(game.SelectionUnit, this.Unit))
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        protected void OnUnitLoaded(object sender, RoutedEventArgs e)
        {
            update(this, null);
            //imgUnit.Source = Util.getImageResourceFromFaction(Unit.getType());
        }

        private void grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Game.CurrentPlayer.units.Contains(this.Unit))
                game.selectionUnite(this.Unit);
        }
    }
}
