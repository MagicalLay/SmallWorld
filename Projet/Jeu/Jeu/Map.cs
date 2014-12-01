using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapper;

namespace Jeu
{
    public enum MapSize{Small, Medium, Large}
    public class Map
    {
        private Space[,] spaces;

        unsafe public Map(MapSize mapSize)
        {
            size = mapSize;
            FlyweightSpace primarySpaces = new FlyweightSpace();
            WrapperAlgo algo = new WrapperAlgo();

            switch (mapSize)
            {
                case MapSize.Small:
                    Size = 6;

                    break;
                case MapSize.Medium:
                    Size = 10;
                    break;
                case MapSize.Large:
                    Size = 14;
                    break;
                default:
                    Console.WriteLine("Invalid size !");
                    break;
            }
            int** map = algo.fillMap(Size);
            spaces = new Space[Size, Size];
            /* replaces ints by spaces */
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                /*    if (map[i,j] == 0)
                    {
                        spaces[i, j] = primarySpaces.getDesert();
                    } */
                }
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
