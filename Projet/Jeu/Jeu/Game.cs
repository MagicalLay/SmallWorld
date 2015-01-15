using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Wrapper;

namespace Jeu
{
    public class Game
    {
        public static People[] Peoples
        {
            get;
            private set;
        }

        public People getPeople(int x)
        {
            return Peoples[x];
        }
        public int getMapSize()
        {
            return Map.Size;
        }
        public Space getSpace(int x, int y)
        {
            return Map[x, y];
        }

        public Game(Map m, People p1, People p2)
        {
            // initializations
            Map = m;
            SelectionX = 0;
            SelectionY = 0;
            Peoples = new People[2];
            Peoples[0] = p1;
            Peoples[1] = p2;
            GameOnGoing = true;
            NbUnitsAlive = People.nbUnits * 2;
            Turn = new Turn(0);
            switch (m.Size)
            {
                case (6):
                    NbTurns = 5;
                    break;
                case (10):
                    NbTurns = 20;
                    break;
                case (14):
                    NbTurns = 30;
                    break;
                default:
                    break;
            }
            NbTurnsLeft = NbTurns;
            SaveName = "";

            // initial position of peoples
            initialPosPeople(p1, p2);

            // defines the first player
            Random rnd = new Random();
            int player = rnd.Next(2);
            CurrentPlayer = Peoples[player]; // First player = current player
        }

        public static Turn Turn
        {
            get;
            private set;
        }
        public static String SaveName
        {
            get;
            private set;
        }

        public static int NbTurnsLeft
        {
            get;
            private set;
        }

        public static People CurrentPlayer
        {
            get;
            private set;
        }

        public static Boolean GameOnGoing
        {
            get;
            private set;
        }

        public static int NbTurns
        {
            get;
            private set;
        }

        public int NbUnitsAlive
        {
            get;
            private set;
        }

        public Map Map
        {
            get;
            private set;
        }

        public Unit SelectionUnit
        {
            get;
            private set;
        }

        public void selectionUnite(Unit unit)
        {
            SelectionUnit = unit;
        }

        public int SelectionX
        {
            get;
            private set;
        }

        public int SelectionY
        {
            get;
            private set;
        }

        public void moveUnit(Unit u, int x, int y)
        {
            u.move(x, y, Map);
        }

        public void selection(int x, int y)
        {
            SelectionX = x;
            SelectionY = y;
        }

        public static void nextTurn()
        {
            if (Turn.numTurn + 1 < NbTurns)
            {
                changePlayer();
                int newTurn = Turn.numTurn + 1;
                Turn = new Turn(newTurn);
                NbTurnsLeft--;
            }
            else
            {
                endGame();
            }
        }

        public static void changePlayer()
        {
            People p = CurrentPlayer;
            if (p.Equals(Peoples[0]))
            {
                CurrentPlayer = Peoples[1];
            }
            else
            {
                CurrentPlayer = Peoples[0];
            }
        }

        public static void endGame()
        {
            GameOnGoing = false;
            Console.WriteLine("End of the game !");
        }

        public unsafe void initialPosPeople(People p1, People p2)
        {
            WrapperAlgo algo = new WrapperAlgo();
            int* tabMap = Map.toInt();
            int* pos = algo.WrapperInitialCoord(tabMap, Map.Size);
            p1.place(pos[0], pos[1], Map);
            p2.place(pos[2], pos[3], Map);
        }
    }
}
