using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public abstract class People
    {
        public People(int nb, Species race)
        {
            throw new System.NotImplementedException();
            //nbPoints = 0;
        }

        public void placerUnits(int rnd)
        {
            throw new System.NotImplementedException();
        }

        public static int nbUnits
        {
            get;
            private set;
        }

        public int nbPoints
        {
            get;
            private set;
        }
    }
}
