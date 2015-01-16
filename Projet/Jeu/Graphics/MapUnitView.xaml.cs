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

using Jeu;

namespace Graphics
{
    /// <summary>
    /// Logique d'interaction pour MapUnitView.xaml
    /// </summary>
    public partial class MapUnitView : UserControl
    {

        public Game game;
        protected static Random rand = new Random();

        public Unit Unit { 
            get; 
            private set; 
        }


        public MapUnitView(Unit u, Game g)
        {
            game = g;
            this.Unit = u;
            InitializeComponent();
            u.PropertyChanged += new PropertyChangedEventHandler(update);
        }
        
        protected virtual void update(object sender, PropertyChangedEventArgs e)
        {
            if (e == null || e.PropertyName == "X" || e.PropertyName == "Y")
            {
                TranslateTransform trTns = new TranslateTransform(Unit.axis * 60 + ((Unit.ordinate % 2 == 0) ? 0 : 30), Unit.ordinate * 50);
                TransformGroup trGrp = new TransformGroup();
                trGrp.Children.Add(trTns);
                grid.RenderTransform = trGrp;
                if (game.Map.zeroUnit(Unit.axis, Unit.ordinate, Game.NotCurrentPlayer)==false)
                {
                    int randMarginX = rand.Next(-10, 15);
                    int randMarginY = rand.Next(-20, 15);

                    this.Margin = new Thickness(randMarginX, randMarginY, -randMarginX, -randMarginY);
                }
            }
        }

        protected void OnUnitLoaded(object sender, RoutedEventArgs e)
        {
            update(this, null);
            this.imgUnit.Source = Util.getImageResourceFromFaction(Unit.getType());
        }
    }
}
