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
            //NbAlive = People.nbUnits * 2;
            Turn = new Turn(0);
        }

        public Turn Turn
        {
            get;
            private set;
        }

        public int NbTurnsLeft
        {
            get;
            private set;
        }

        public Boolean GameOnGoing
        {
            get;
            private set;
        }

        public int NbAlive
        {
            get;
            private set;
        }

        public System.Collections.Generic.IEnumerable<Jeu.People> Peoples
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Map Map
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public bool save()
        {
            throw new System.NotImplementedException();
        }

        public void endGame()
        {
            throw new System.NotImplementedException();
        }
    }
}
