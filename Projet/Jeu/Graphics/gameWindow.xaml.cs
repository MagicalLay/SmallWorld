﻿using Jeu;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Logique d'interaction pour gameWindow.xaml
    /// </summary>
    public partial class gameWindow : Window
    {

        Game game;
        public List<MapUnitView> unitViews = new List<MapUnitView>();
        
        MapView mapView;

        bool IsPaused
        {
            get;
            set;
        }

        private float moveOffsetX, moveOffsetY;

        /// <summary>
        /// Constructor for gameWindow
        /// </summary>
        public gameWindow(CreateBuilder cB)
        {
            this.Background = Brushes.Black;
            game = cB.game;
            InitializeComponent();
            IsPaused = false;
            mapView = new MapView(cB.map, mapGrid, cB.game, this);

            //to move the map at the center (depending on the size of the map)
            switch (MapView.Map.Size)
            {
                case 6:
                    moveOffsetX = (MapView.Map.Size * 55);
                    moveOffsetY = (MapView.Map.Size * 40);
                    break;
                case 10:
                    moveOffsetX = (MapView.Map.Size * 65);
                    moveOffsetY = (MapView.Map.Size * 40);
                    break;
                case 14:
                    moveOffsetX = (MapView.Map.Size * 61);
                    moveOffsetY = (MapView.Map.Size * 45);
                    break;
            }

            game.selectionUnite(Game.CurrentPlayer.units[0]);
            mapGrid.Margin = new Thickness(-moveOffsetX, -moveOffsetY, 0, 0);

            // Populate the map with the units
            foreach (Unit u in cB.p[0].units)
            {
                unitViews.Add(new MapUnitView(u, cB.game));
            }
            foreach (Unit u in cB.p[1].units)
            {
                unitViews.Add(new MapUnitView(u, cB.game));
            }
            foreach (MapUnitView uv in unitViews)
            {
                mapGrid.Children.Add(uv);
            }
            

            this.DataContext = this;
            
            lblCurrentPlayer.Content = Game.CurrentPlayer.Nickname;
            lblRemainingTurns.Content = Game.NbTurnsLeft + " turns left.";

            lblVictoryPointsP1.Content = "Victory points : 1";
            lblVictoryPointsP2.Content = "Victory points : 1";

            game.PropertyChanged += new PropertyChangedEventHandler(update); // Souscription au OnPropertyChanged*/
        }

        /// <summary>
        /// Delegate called when a property is changed in Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        public void update(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "CurrentPlayer":
                    TryEndGame();
                    lblCurrentPlayer.Content = Game.CurrentPlayer.Nickname;
                    break;
                case "RemainingTurns":
                    lblRemainingTurns.Content = Game.NbTurnsLeft + " turns left.";
                    break;
                case "LastCombatReport":
                    deleteDeadUnits();
                    updateListUnits();
                    TryEndGame();
                    break;
                case "XSelected":
                case "YSelected":
                    updateListUnits();
                    break;
            }
        }


        /// <summary>
        /// Clears and updates the list of units of the selected cell
        /// </summary>
        public void updateListUnits()
        {
            listUnitGrid.Children.Clear();
            List<Unit> all = Game.Peoples[0].units.Concat(Game.Peoples[1].units).ToList();
            foreach (Unit u in all.Where(u => u.axis == game.SelectionX && u.ordinate == game.SelectionY))
            {
                listUnitGrid.Children.Add(new ListUnite(u, game));
            }
        }


        /// <summary>
        /// Delegete called when the end turn button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndTurn_Click(object sender, RoutedEventArgs e)
        {
            if (Game.NbTurnsLeft == 0)
            {
                TryEndGame();
            }

            if (!IsPaused)
            {
                game.nextTurn();
                lblVictoryPointsP1.Content = "Victory points : " + Game.Peoples[0].nbPoints;
                lblVictoryPointsP2.Content = "Victory points : " + Game.Peoples[1].nbPoints;
                lblRemainingTurns.Content = Game.NbTurnsLeft + " turns left.";
            }

        }

        /// <summary>
        /// Ends the game if a player has won
        /// </summary>
        private void TryEndGame()
        {
            if (Game.endGame())
            {
                IsPaused = true;
                btnBack.Visibility = System.Windows.Visibility.Visible;
                People Winner = Game.Winner;
                if (Winner != null)
                    lblVictory.Content = Winner.Nickname + " won !";
                else
                    lblVictory.Content = "It's a tie !";
                lblVictory.Visibility = System.Windows.Visibility.Visible;
            }

        }

        /// <summary>
        /// Delegate called when a key is pressed in the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowInGame_KeyUp(object sender, KeyEventArgs e)
        {

            int x = game.SelectionUnit.axis;
            int y = game.SelectionUnit.ordinate;
            Unit u = game.SelectionUnit;
            switch (e.Key)
            {
                case Key.Enter:
                    btnEndTurn_Click(sender, e);
                    break;
                case Key.Escape:
                    toggleMenu();
                    break;
                case Key.NumPad1:
                    game.moveUnit(u, y % 2 == 0 ? x + 1 : x, y % 2 == 0 ? y : y + 1);
                    break;
                case Key.NumPad3:
                    game.moveUnit(u, y % 2 == 0 ? x : x + 1, y + 1);
                    break;
                case Key.NumPad4:
                    game.moveUnit(u, x - 1, y);
                    break;
                case Key.NumPad6:
                    game.moveUnit(u, x + 1, y);
                    break;
                case Key.NumPad7:
                    game.moveUnit(u, y % 2 == 0 ? x - 1 : x, y - 1);
                    break;
                case Key.NumPad9:
                    game.moveUnit(u, y % 2 == 0 ? x : x + 1, y - 1);
                    break;
            }
        }

        /// <summary>
        /// Toggles the menu
        /// </summary>
        private void toggleMenu()
        {
            IsPaused = !IsPaused;
            main.Stretch = main.Stretch == Stretch.Uniform ? Stretch.UniformToFill : Stretch.Uniform;
            MenuRectangle.IsEnabled = !MenuRectangle.IsEnabled;
            MenuRectangle.Visibility = MenuRectangle.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            btnContinue.Visibility = btnContinue.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            btnQuit.Visibility = btnQuit.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            //btnSaveGame.Visibility = btnSaveGame.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            lblGamePaused.Visibility = lblGamePaused.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <summary>
        /// Delegate called when the continue button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            toggleMenu();
            main.Stretch = Stretch.Uniform;
        }

        /// <summary>
        /// Delegate called when the quit button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to quit this game?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        /// Delegate called when the save game button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveGame_Click(object sender, RoutedEventArgs e)
        {
            /*
            SaveGame saveGameWindow = new SaveGame();
            saveGameWindow.Show();*/
        }

        /// <summary>
        /// Deletes the dead units's views from the map
        /// </summary>
        public void deleteDeadUnits()
        {
            foreach (UIElement uv in mapGrid.Children.Cast<UIElement>().ToArray())
            {
                if (uv is MapUnitView && ((MapUnitView)uv).Unit.isDead())
                {
                    mapGrid.Children.Remove(uv);
                }
            }
            foreach (UIElement uv in listUnitGrid.Children.Cast<UIElement>().ToArray())
            {
                if (uv is ListUnite && ((ListUnite)uv).Unit.isDead())
                {
                    mapGrid.Children.Remove(uv);
                }
            }
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }
    }
}
