using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public abstract class People
    {
        public People(Species race, int nb)
        {
            throw new System.NotImplementedException();
            //nbPoints = 0;
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
