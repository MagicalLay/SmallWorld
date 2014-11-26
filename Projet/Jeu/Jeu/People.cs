using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public abstract class People
    {
        public People(int nb, Jeu.Species race)
        {
            throw new System.NotImplementedException();
        }
        public int nbUnits
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
