﻿using System;
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
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public bool endTurn()
        {
            throw new System.NotImplementedException();
        }

        public void followingUnit()
        {
            throw new System.NotImplementedException();
        }
    }
}