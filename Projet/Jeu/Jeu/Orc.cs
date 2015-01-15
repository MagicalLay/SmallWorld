using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapper;

namespace Jeu
{
    public class Orc : People
    {
        public Orc(int nbUnits) : base(nbUnits) {
            int i;
            units = new Unit[nbUnits];
            for (i = 0; i < nbUnits; i++)
            {
                units[i] = new UnitOrc();
            }
        }
        public System.Collections.Generic.IEnumerable<Jeu.UnitOrc> UnitsOrcs
        {
            get;
            private set;
        }

        public void move(int x, int y)
        {
            WrapperAlgo algo = new WrapperAlgo();
            foreach (UnitOrc u in UnitsOrcs)
            {
                if (u.Space.isNeighbour(Game.Map[x, y]))
                {
                    u.move(x,y);
                }
            }
        }
    }
}
