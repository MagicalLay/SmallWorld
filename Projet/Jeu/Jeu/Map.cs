using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapper;
using System.Runtime.InteropServices;

namespace Jeu
{
    public enum MapSize{Small, Medium, Large}
    public class Map
    {
        public Space[,] Spaces
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
            int* map = algo.WrapperFillMap(Size);
            /* replaces ints by spaces */
            Spaces = new Jeu.Space[Size,Size];
            Space sp_field = primarySpaces.getField();
            Space sp_forest = primarySpaces.getForest();
            Space sp_desert = primarySpaces.getDesert();
            Space sp_mountain = primarySpaces.getMountain();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (map[i*Size+j] == 0)
                    {
                        this[i, j] = sp_desert;
                    }
                    else if (map[i*Size+j] == 1)
                    {
                        this[i, j] = sp_field;
                    }
                    else if (map[i*Size+j] == 2)
                    {
                        this[i, j] = sp_forest;
                    }
                    else
                    {
                        this[i, j] = sp_mountain;
                    } 
                }
            }
        }
        public Space this[int x, int y]
        {
            get
            {
                return Spaces[x,y];
            }
            private set
            {
                Spaces[x,y] = value;
            }
        }

        public int Size
        {
            get;
            private set;
        }

        unsafe public int* toInt()
        {
            IntPtr pNative = IntPtr.Zero;
            int i, j;
            int* result = stackalloc int[Size*Size + 1];
            for (i = 0; i < Size; i++)
            {
                for (j = 0; j < Size; j++)
                {
                    Space sp = this[i, j];
                    if(sp.getType() == Space.Type.Desert) 
                    {
                        result[i * Size + j] = 0;
                    }
                    else if (sp.getType() == Space.Type.Field)
                    {
                        result[i * Size + j] = 1;
                    }
                    else if (sp.getType() == Space.Type.Forest)
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

        public int getIndexFromCoordinates(int x, int y)
        {
            if (ValidCoordinates(x, y))
                return x * Size + y;
            else
                throw new Exception();
        }

        public bool ValidCoordinates(int x, int y)
        {
            return x >= 0 && y >= 0 && x < Size && y < Size;
        }

        // Renvoie vrai s'il n'y a aucune unité du peuple p sur la case[x,y]
        public Boolean zeroUnit(int x, int y, People p)
        {
            Boolean b = true;
            if (ValidCoordinates(x, y))
            {
                foreach (Unit u in p.units)
                {
                    if (u.axis == x && u.ordinate == y) { b = false; }
                }
            }
            else { b = false; }
            return b;
        }
    }
}
