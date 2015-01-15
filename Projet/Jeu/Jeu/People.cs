﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public abstract class People
    {
        public People(int nb)
        {
            nbUnits = nb;
            nbPoints = 0;
        }

        public Unit[] units
        {
            get;
            protected set;
        }
        public static int nbUnits
        {
            get;
            private set;
        }

        public void move(int x, int y)
        {
        }

        public int nbPoints
        {
            get;
            private set;
        }
    }
}
