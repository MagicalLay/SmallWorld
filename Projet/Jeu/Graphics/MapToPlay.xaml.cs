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
    /// Logique d'interaction pour MapToPlay.xaml
    /// </summary>
    public partial class MapToPlay : Window
    {
        private float moveOffsetX, moveOffsetY;
        public static Map Map { get; protected set; }
        public static Dictionary<int, Cellule> cellules { get; protected set; }

        public MapToPlay(Map _map) {
            InitializeComponent();
            Map = _map;
            cellules = new Dictionary<int, Cellule>();
			for (int y = 0; y < Map.Size; y++)
			{
				for (int x = 0; x < Map.Size; x++)
				{
					Cellule cell = new Cellule(_map[x,y],x,y);
					gridMap.Children.Add(cell);
                    cellules.Add(Map.getIndexFromCoodinates(x, y), cell);
				}
			}
            switch (Map.Size)
            {
                case 6:
                    moveOffsetX = (Map.Size * 55);
                    moveOffsetY = (Map.Size * 40);
                    break;
                case 10:
                    moveOffsetX = (Map.Size * 65);
                    moveOffsetY = (Map.Size * 40);
                    break;
                case 14:
                    moveOffsetX = (Map.Size * 61);
                    moveOffsetY = (Map.Size * 45);
                    break;
            }

            mapGrid.Margin = new Thickness(-moveOffsetX, -moveOffsetY, 0, 0);
		}
    }
}
