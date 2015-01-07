using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapper;

namespace Jeu
{
    public class Dwarf : People
    {
        public Dwarf(int nbUnits) : base(nbUnits, Species.Dwarf) { }

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
                Map m = Jeu.Game.Map;
                double* costs = null;
                int* moves = null;
                double mp = u.movePoints;
                algo.WrapperDwarfMvt(m.toInt(), m.Size, x, y, costs, moves, mp);
            }
        }
    }
}
