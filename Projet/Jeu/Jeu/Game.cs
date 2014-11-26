using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class Game
    {
        public Game()
        {
            GameOnGoing = true;
            NbAlive = People.nbUnits * 2;
            Turn = new Turn(0);
            Peoples = new People[2];
        }

        public Turn Turn
        {
            get;
            private set;
        }

        public static int NbTurnsLeft
        {
            get;
            private set;
        }

        public static Boolean GameOnGoing
        {
            get;
            private set;
        }

        public int NbAlive
        {
            get;
            private set;
        }

        //public System.Collections.Generic.IEnumerable<Jeu.People> Peoples
        //{
        //    get;
        //    private set;
        //}

        public static People[] Peoples 
        {
            get;
            private set;
        }

        public Map Map
        {
            get;
            private set;
        }

        public bool save()
        {
            throw new System.NotImplementedException();
        }

        public static void endGame()
        {
            GameOnGoing = false;
            Console.WriteLine("End of the game !");
        }
    }
}
