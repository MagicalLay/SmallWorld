﻿using System;
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
    /// Logique d'interaction pour Cellule1.xaml
    /// </summary>
    public partial class Cellule : UserControl
    {

        public Game game
        {
            get;
            private set;
        }

        public bool IsSelected
        {
            get
            {
                return game.SelectionX == Y && game.SelectionY == X;
            }
            set
            {
                if (value)
                {
                    Cellule selectedCell;
                    try
                    {
                        if (MapView.cellules.TryGetValue(game.Map.getIndexFromCoordinates(game.SelectionX, game.SelectionY), out  selectedCell))
                            selectedCell.IsSelected = false;
                    }
                    catch (Exception)
                    {
                        // No Cell previously selected
                    }
                    game.selection(X, Y);
                    this.bgPath.Opacity = 0.4;
                    game.selectionUnite(Game.CurrentPlayer.units.Where(u => u.axis == this.X && u.ordinate == this.Y).FirstOrDefault());

                }
                else
                {
                    game.selection(-1, -1);
                    this.bgPath.Opacity = 1;
                }
            }
        }

        static Cellule()
        {/*
            brushResourceNameFromCellType = new string[4];
            brushResourceNameFromCellType[(int)CellType.Desert] = "BrushDesertCell";
            brushResourceNameFromCellType[(int)CellType.Plains] = "BrushPlainCell"; 
            brushResourceNameFromCellType[(int)CellType.Forest] = "BrushForestCell";
            brushResourceNameFromCellType[(int)CellType.Mountain] = "BrushMountainCell";*/
        }

        public int X
        {
            get;
            private set;
        }

        public int Y
        {
            get;
            private set;
        }

        static string[] brushResourceNameFromCellType;

        public Cellule(Space c, int x, int y, Game g)
        {
            InitializeComponent();
            //this.bgPath.Fill = (Brush)grid.Resources[brushResourceNameFromCellType[(int)c.getType()]];
            game = g;
            X = x;
            Y = y;
            //GameImpl.INSTANCE.PropertyChanged += new PropertyChangedEventHandler(update);
            //lblCoords.Content = x + "," + y;
        }

        private void OnCellViewLoaded(object sender, RoutedEventArgs e)
        {
            // Set position (hexagon disposition)
            //TranslateTransform trTns = new TranslateTransform(X * 60 + ((Y % 2 == 0) ? 0 : 30) - 640, Y * 50 - 370);
            TranslateTransform trTns = new TranslateTransform(X * 60 + ((Y % 2 == 0) ? 0 : 30), Y * 50);
            TransformGroup trGrp = new TransformGroup();
            trGrp.Children.Add(trTns);

            grid.RenderTransform = trGrp;
        }

        private void hexagonPath_MouseEnter(object sender, MouseEventArgs e) {
            this.hexagonPath.Opacity = 1;
        }
        public void hexagonPath_MouseLeave(object sender, MouseEventArgs e) {
            this.hexagonPath.Opacity = 0;
        }
        public void bgPath_MouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            MapView.cellules[game.Map.getIndexFromCoordinates(game.SelectionX, game.SelectionY)].IsSelected = false;
            this.IsSelected = true;
        }
        public void bgPath_MouseRightButtonDown(object sender, MouseEventArgs e) { }
    }
}
