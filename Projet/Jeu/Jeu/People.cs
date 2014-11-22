using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public abstract class People
    {
        public People(int nb, string race)
        {
            nbUnits=nb;
        }

        public int nbUnits
        {
            get;
            private set;
        }

        public int nbPoints
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
