using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Wrapper;

namespace Jeu
{
    public class Game : INotifyPropertyChanged
    {
        public static People[] Peoples
        {
            get;
            private set;
        }

        #region INotifyPropertyChanged

        [field: NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

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
            Peoples[0].surnom("Joueur 1");
            Peoples[0].surnom("Joueur 2");
            GameOnGoing = true;
            NbUnitsAlive = Peoples[0].nbUnits * 2;
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
            if (player == 0) NotCurrentPlayer = Peoples[1];
            else NotCurrentPlayer = Peoples[0];
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
            u.move(x, y, this);
        }

        public void selection(int x, int y)
        {
            SelectionX = x;
            SelectionY = y;
        }

        public static void nextTurn()
        {
            if (NbTurnsLeft > 0)
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

        public static People Winner
        {
            get;
            private set;
        }

        public static People NotCurrentPlayer
        {
            get;
            private set;
        }

        public static void changePlayer()
        {
            People p = CurrentPlayer;
            if (p.Equals(Peoples[0]))
            {
                CurrentPlayer = Peoples[1];
                NotCurrentPlayer = Peoples[0];
            }
            else
            {
                CurrentPlayer = Peoples[0];
                NotCurrentPlayer = Peoples[1];
            }
        }

        public static bool endGame()
        {
            if (NbTurnsLeft == 0 || Game.Peoples[0].nbUnits == 0 || Game.Peoples[1].nbUnits == 0)
            {
                GameOnGoing = false;
                Console.WriteLine("End of the game !");
                return true;
            }
            else{
                return false;
            }
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
