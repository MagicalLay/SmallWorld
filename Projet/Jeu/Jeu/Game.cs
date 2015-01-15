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

        public Game()
        {
            Peoples = new People[2];
        }
        public Game(Map m, People p1, People p2)
        {
            // initializations
            Map = m;
            Peoples = new People[2];
            Peoples[0] = p1;
            Peoples[1] = p2;
            GameOnGoing = true;
            NbUnitsAlive = People.nbUnits * 2;
            Turn = new Turn(0);
            switch (m.Size)
            {
                case(6):
                    NbTurns = 5;
                    break;
                case(10):
                    NbTurns = 20;
                    break;
                case(14):
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

        public static Map Map
        {
            get;
            private set;
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
            foreach (Unit u in p1.units)
            {
                u.move(pos[0], pos[1]);

            }
            foreach (Unit u in p2.units)
            {
                u.move(pos[2], pos[3]);

            }
        } 

        /* the 3 following functions are used to save or load a game */
        public bool save()
        {
            {
                if (SaveName != "")
                {
                    this.saveUnder(SaveName);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void saveUnder(String fileName)
        {
            FileStream stream = File.Create(fileName);
            BinaryFormatter formatter = new BinaryFormatter();
            Console.WriteLine("Serializing");
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public Game loadGame(string fileName)
        {
            FileStream stream = File.OpenRead(fileName);
            BinaryFormatter formatter = new BinaryFormatter();
            Game g = (Game)formatter.Deserialize(stream);
            stream.Close();
            return g;
        }
    }
}
