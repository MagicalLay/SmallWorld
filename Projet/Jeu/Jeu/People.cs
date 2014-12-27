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
            nbUnits = nb;
            nbPoints = 0;
            units = new Unit[nb];
        }

        public Unit[] units
        {
            get;
            private set;
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
