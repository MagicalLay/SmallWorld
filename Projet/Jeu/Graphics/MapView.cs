using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Graphics
{
    public class MapView : Panel
    {
        protected override void OnRender(DrawingContext dc)
        {
            // Creation of the bitmap images used on the map view
            BitmapImage bi_desert = new BitmapImage();
            bi_desert.BeginInit();
            bi_desert.UriSource = new Uri(@"textures/desert.png", UriKind.RelativeOrAbsolute);
            bi_desert.EndInit();
            BitmapImage bi_field = new BitmapImage();
            bi_field.BeginInit();
            bi_field.UriSource = new Uri(@"textures/plaine.png", UriKind.RelativeOrAbsolute);
            bi_field.EndInit();
            BitmapImage bi_forest = new BitmapImage();
            bi_forest.BeginInit();
            bi_forest.UriSource = new Uri(@"textures/foret.png", UriKind.RelativeOrAbsolute);
            bi_forest.EndInit();
            BitmapImage bi_mountain = new BitmapImage();
            bi_mountain.BeginInit();
            bi_mountain.UriSource = new Uri(@"textures/ocean.png", UriKind.RelativeOrAbsolute);
            bi_mountain.EndInit();
            Rect rect = new Rect(1, 1, 69, 79);
            Rect rect2 = new Rect(70, 1, 69, 79);
            Rect rect3 = new Rect(70+34.5, 59.74, 69, 79);
            Rect rect4 = new Rect(70+69, 1, 69, 79);
            dc.DrawImage(bi_forest, rect);
            dc.DrawImage(bi_field, rect2);
            dc.DrawImage(bi_desert, rect3);
            dc.DrawImage(bi_mountain, rect4);
        }
    }
}
