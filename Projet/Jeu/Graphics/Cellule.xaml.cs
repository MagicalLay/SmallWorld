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
    /// Logique d'interaction pour Cellule1.xaml
    /// </summary>
    public partial class Cellule : UserControl
    {
        public Cellule()
        {
            InitializeComponent();
        }

        public Cellule(Space c, int x, int y)
        {
            InitializeComponent();
            //this.bgPath.Fill = (Brush)grid.Resources[brushResourceNameFromCellType[(int)c.getType()]];
            //lblCoords.Content = x + "," + y;
        }

        private void hexagonPath_MouseEnter(object sender, MouseEventArgs e) { }
        public void hexagonPath_MouseLeave(object sender, MouseEventArgs e) { }
        public void bgPath_MouseLeftButtonDown(object sender, MouseEventArgs e) { }
        public void bgPath_MouseRightButtonDown(object sender, MouseEventArgs e) { }
    }
}
