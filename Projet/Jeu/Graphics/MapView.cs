using System;
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

            // Creation of the bitmap images used to illustrate peoples
            BitmapImage bi_dwarf = new BitmapImage();
            bi_dwarf.BeginInit();
            bi_dwarf.UriSource = new Uri(@"peoples/dwarf.png", UriKind.RelativeOrAbsolute);
            bi_dwarf.EndInit();
            BitmapImage bi_elf = new BitmapImage();
            bi_elf.BeginInit();
            bi_elf.UriSource = new Uri(@"peoples/elf.png", UriKind.RelativeOrAbsolute);
            bi_elf.EndInit();
            BitmapImage bi_orc = new BitmapImage();
            bi_orc.BeginInit();
            bi_orc.UriSource = new Uri(@"peoples/orc.png", UriKind.RelativeOrAbsolute);
            bi_orc.EndInit();
            //Space[,] mapSpaces = Game.Map.spaces;
            //int sizeMap = Game.Map.Size;
            Rect rectxy;
            int size = 6;
            FlyweightSpace fw = new FlyweightSpace();
            Space[,] mapSpaces = new Space[size,size];
                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        /* calculate coordinates on the map */
                        if (y % 2 == 0)
                        {
                            rectxy = new Rect(1 + x * 69, 1 + y * 59.74, 69, 79);
                            mapSpaces[x, y] = fw.getField();
                        }
                        else
                        {
                            mapSpaces[x, y] = fw.getDesert();
                            rectxy = new Rect(34.5 + x * 69, 59.74 + (y - 1) * 59.74, 69, 79);
                        }
                        /* get the type of space */
                        Space sp = mapSpaces[x, y];
                        /* drawings of the images */
                        if (sp.Equals(fw.getDesert()))
                        {
                            dc.DrawImage(bi_desert, rectxy);
                        }
                        else if (sp.Equals(fw.getField()))
                        {
                            dc.DrawImage(bi_field, rectxy);
                        }
                        else if (sp.Equals(fw.getForest()))
                        {
                            dc.DrawImage(bi_forest, rectxy);
                        }
                        else
                        {
                            dc.DrawImage(bi_mountain, rectxy);
                        }
                    }
                }
        }
    }
}
