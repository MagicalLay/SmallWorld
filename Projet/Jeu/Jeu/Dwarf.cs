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
            int i;
            units = new Unit[nbUnits];
            for (i = 0; i < nbUnits; i++)
            {
                units[i] = new UnitDwarf();
            }
        }

        public System.Collections.Generic.IEnumerable<Jeu.UnitDwarf> UnitsDwarves
        {
            get;
            private set;
        }
        unsafe public void move(int x, int y, Game g)
        {
            WrapperAlgo algo = new WrapperAlgo();
            foreach (UnitDwarf u in UnitsDwarves)
            {
                if (u.Space.isNeighbour(g.getSpace(x, y)))
                {
                    u.move(x, y, g);
                }
            }
        }
    }
}
