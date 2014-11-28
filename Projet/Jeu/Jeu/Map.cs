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
            FlyweightSpace primarySpaces = new FlyweightSpace();
            Random rnd = new Random();
            int nbDesert, nbMountain, nbField, nbForest, nbEmptySpaces;

            switch (mapSize)
            {
                case MapSize.Small:
                    nbDesert = 9;
                    nbMountain = 9;
                    nbField = 9;
                    nbForest = 9;
                    nbEmptySpaces = 36;
                    Size = 6;
                    spaces = new Space[6, 6];
                    do
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                int typeOfSpace = rnd.Next(1, 5);
                                if (typeOfSpace == 1 && nbDesert != 0)
                                {
                                    spaces[i, j] = primarySpaces.getDesert();
                                    nbDesert--;
                                    nbEmptySpaces--;
                                }
                                else if (typeOfSpace == 2 && nbMountain != 0)
                                {
                                    spaces[i, j] = primarySpaces.getMountain();
                                    nbMountain--;
                                    nbEmptySpaces--;
                                }
                                else if (typeOfSpace == 3 && nbField != 0)
                                {
                                    spaces[i, j] = primarySpaces.getField();
                                    nbField--;
                                    nbEmptySpaces--;
                                }
                                else if (typeOfSpace == 4 && nbForest != 0)
                                {
                                    spaces[i, j] = primarySpaces.getForest();
                                    nbForest--;
                                    nbEmptySpaces--;
                                }
                            }
                        }
                    } while (nbEmptySpaces != 0);
                    break;
                case MapSize.Medium:

                    nbDesert = 25;
                    nbMountain = 25;
                    nbField = 25;
                    nbForest = 25;
                    nbEmptySpaces = 100;

                    Size = 10;
                    spaces = new Space[10, 10];
                    do
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                int typeOfSpace = rnd.Next(1, 5);
                                if (typeOfSpace == 1 && nbDesert != 0)
                                {
                                    spaces[i, j] = primarySpaces.getDesert();
                                    nbDesert--;
                                    nbEmptySpaces--;
                                }
                                else if (typeOfSpace == 2 && nbMountain != 0)
                                {
                                    spaces[i, j] = primarySpaces.getMountain();
                                    nbMountain--;
                                    nbEmptySpaces--;
                                }
                                else if (typeOfSpace == 3 && nbField != 0)
                                {
                                    spaces[i, j] = primarySpaces.getField();
                                    nbField--;
                                    nbEmptySpaces--;
                                }
                                else if (typeOfSpace == 4 && nbForest != 0)
                                {
                                    spaces[i, j] = primarySpaces.getForest();
                                    nbForest--;
                                    nbEmptySpaces--;
                                }
                            }
                        }
                    } while (nbEmptySpaces != 0);
                    break;
                case MapSize.Large:
                    nbDesert = 49;
                    nbMountain = 49;
                    nbField = 49;
                    nbForest = 49;
                    nbEmptySpaces = 196;

                    Size = 14;
                    spaces = new Space[14, 14];
                    do
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                int typeOfSpace = rnd.Next(1, 5);
                                if (typeOfSpace == 1 && nbDesert != 0)
                                {
                                    spaces[i, j] = primarySpaces.getDesert();
                                    nbDesert--;
                                    nbEmptySpaces--;
                                }
                                else if (typeOfSpace == 2 && nbMountain != 0)
                                {
                                    spaces[i, j] = primarySpaces.getMountain();
                                    nbMountain--;
                                    nbEmptySpaces--;
                                }
                                else if (typeOfSpace == 3 && nbField != 0)
                                {
                                    spaces[i, j] = primarySpaces.getField();
                                    nbField--;
                                    nbEmptySpaces--;
                                }
                                else if (typeOfSpace == 4 && nbForest != 0)
                                {
                                    spaces[i, j] = primarySpaces.getForest();
                                    nbForest--;
                                    nbEmptySpaces--;
                                }
                            }
                        }
                    } while (nbEmptySpaces != 0);
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
