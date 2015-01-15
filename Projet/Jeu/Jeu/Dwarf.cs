using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapper;

namespace Jeu
{
    public class Dwarf : People
    {
        public Dwarf(int nbUnits) : base(nbUnits) {
            units = new UnitDwarf[nbUnits];
        }

        public System.Collections.Generic.IEnumerable<Jeu.UnitDwarf> UnitsDwarves
        {
            get;
            private set;
        }
        unsafe public void move(int x, int y)
        {
            WrapperAlgo algo = new WrapperAlgo();
            foreach (UnitDwarf u in UnitsDwarves)
            {
                if (u.Space.isNeighbour(Game.Map[x, y]))
                {
                    u.Space = Game.Map[x, y];
                }
            }
        }
    }
}
