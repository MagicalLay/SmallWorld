using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public enum MapSize{Small, Medium, Large}
    public class Map
    {
        private Space[,] spaces;

        public Map(MapSize mapSize)
        {
            switch (mapSize)
            {
                case MapSize.Small:
                    Size = 6;
                    spaces = new Space[6, 6];
                    break;
                case MapSize.Medium:
                    Size = 10;
                    spaces = new Space[10, 10];
                    break;
                case MapSize.Large:
                    Size = 14;
                    spaces = new Space[14, 14];
                    break;
                default:
                    Console.WriteLine("Invalid size !");
                    break;
            }
        }

        public Jeu.Space this[int x, int y]
        {
            get
            {
                return spaces[x,y];
            }
            private set
            {
            spaces[x,y] = value;
            }
        }

        public int Size
        {
            get;
            private set;
        }
    }
}
