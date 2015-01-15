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
            units = new UnitOrc[nbUnits];
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
                    u.Space = Game.Map[x, y];
                }
            }
        }
    }
}
