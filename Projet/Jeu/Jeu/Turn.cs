using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class Turn
    {
        public Turn(int num)
        {
            numTurn = num;
        }

        public int numTurn
        {
            get;
            private set;
        }

        public People People
        {
            get;
            private set;
        }

        public bool endTurn()
        {
            numTurn++;
            if(numTurn < Game.NbTurnsLeft) 
            {
                return true;
            }
            else
            {
                Game.endGame();
                return false;
            }
        }

        public void followingUnit()
        {
            throw new System.NotImplementedException();
        }
    }
}
