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
        public Space[,] spaces
        {
            get;
            private set;
        }

        unsafe public Map(MapSize mapSize)
        {
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
            int** map = algo.WrapperFillMap(Size);
            spaces = new Space[Size, Size];
            /* replaces ints by spaces */
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (map[i][j] == 0)
                    {
                        spaces[i, j] = primarySpaces.getDesert();
                    }
                    else if (map[i][j] == 1)
                    {
                        spaces[i, j] = primarySpaces.getField();
                    }
                    else if (map[i][j] == 2)
                    {
                        spaces[i, j] = primarySpaces.getForest();
                    }
                    else
                    {
                        spaces[i, j] = primarySpaces.getMountain();
                    } 
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

        unsafe public int* toInt()
        {
            FlyweightSpace fw = new FlyweightSpace();
            int i, j;
            int* result = null;
            for (i = 0; i < Size; i++)
            {
                for (j = 0; j < Size; j++)
                {
                    Space sp = this[i, j];
                    if(sp.Equals(fw.getDesert())) 
                    {
                        result[i * Size + j] = 0;
                    }
                    else if (sp.Equals(fw.getField()))
                    {
                        result[i * Size + j] = 1;
                    }
                    else if (sp.Equals(fw.getForest()))
                    {
                        result[i * Size + j] = 2;
                    }
                    else
                    {
                        result[i * Size + j] = 3;
                    }
                }
            }
            return result;
        }
    }
}
