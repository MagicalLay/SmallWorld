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

        protected override void OnRender(DrawingContext dc)
        {
            // Creation of the bitmap images used on the map view
            BitmapImage bi_desert = new BitmapImage();
            bi_desert.BeginInit();
            bi_desert.UriSource = new Uri("./textures/desert.png", UriKind.Relative);
            bi_desert.EndInit();
            BitmapImage bi_field = new BitmapImage();
            bi_field.BeginInit();
            bi_field.UriSource = new Uri("./textures/field.png", UriKind.Relative);
            bi_field.EndInit();
            BitmapImage bi_forest = new BitmapImage();
            bi_forest.BeginInit();
            bi_forest.UriSource = new Uri("./textures/forest.png", UriKind.Relative);
            bi_forest.EndInit();
            BitmapImage bi_mountain = new BitmapImage();
            bi_mountain.BeginInit();
            bi_mountain.UriSource = new Uri("./textures/mountain.png", UriKind.Relative);
            bi_mountain.EndInit();

            // Creation of the bitmap images used to illustrate peoples
            BitmapImage bi_dwarf = new BitmapImage();
            bi_dwarf.BeginInit();
            bi_dwarf.UriSource = new Uri("./peoples/dwarf.png", UriKind.Relative);
            bi_dwarf.EndInit();
            BitmapImage bi_elf = new BitmapImage();
            bi_elf.BeginInit();
            bi_elf.UriSource = new Uri("./peoples/elf.png", UriKind.Relative);
            bi_elf.EndInit();
            BitmapImage bi_orc = new BitmapImage();
            bi_orc.BeginInit();
            bi_orc.UriSource = new Uri("./peoples/orc.png", UriKind.Relative);
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
                        // Coordinates on the map
                        if (y % 2 == 0)
                        {
                            rectxy = new Rect(1 + x * 69, 1 + y * 59.7, 69, 79);
                            if (x % 2 == 0)
                            {
                                mapSpaces[x, y] = fw.getField();
                            }
                            else
                            {
                                mapSpaces[x, y] = fw.getDesert();
                            }
                        }
                        else
                        {
                            rectxy = new Rect(34.5 + x * 69, 59.7 + (y - 1) * 59.7, 69, 79);
                            if (x % 2 == 0)
                            {
                                mapSpaces[x, y] = fw.getMountain();
                            }
                            else
                            {
                                mapSpaces[x, y] = fw.getForest();
                            }
                        }

                        // Type of space
                        Space sp = mapSpaces[x, y];

                        // Draws the images
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