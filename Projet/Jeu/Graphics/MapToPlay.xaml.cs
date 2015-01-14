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
        public MapToPlay()
        {
            InitializeComponent();
        }

        public MapToPlay(Map _map) {
			for (int y = 0; y < _map.Size; y++)
			{
				for (int x = 0; x < _map.Size; x++)
				{
					Cellule cell = new Cellule(_map.spaces[x,y],x,y);
					GridMap.Children.Add(cell);
				}
			}
		}
    }
}
