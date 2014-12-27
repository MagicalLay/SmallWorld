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
            People = Game.CurrentPlayer;
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

        public void followingUnit()
        {
            throw new System.NotImplementedException();
        }
    }
}
