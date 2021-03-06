﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Jeu;

namespace Graphics
{
    public class MapView : Panel
    {

        public static Map Map { get; protected set; }
        public static Grid MapViewGrid { get; protected set; }
        public static Dictionary<int, Cellule> cellules { get; protected set; }

        public MapView(Map _map, Grid grid, Game g, gameWindow gW) {
            Map = _map;
            MapViewGrid = grid;
            cellules = new Dictionary<int, Cellule>();

			for (int y = 0; y < Map.Size; y++)
			{
				for (int x = 0; x < Map.Size; x++)
				{
					Cellule cell = new Cellule(_map.Spaces[x,y],x,y,g, gW);
					grid.Children.Add(cell);
                    cellules.Add(_map.getIndexFromCoordinates(x, y), cell);
				}
			}
		}
    }
}
