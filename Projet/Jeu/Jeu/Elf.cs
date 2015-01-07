using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapper;

namespace Jeu
{
    public class Elf : People
    {
        public Elf(int nbUnits) : base(nbUnits, Species.Elf) { }

        public System.Collections.Generic.IEnumerable<Jeu.UnitElf> UnitsElves
        {
            get;
            private set;
        }
        unsafe public void move(int x, int y)
        {
            WrapperAlgo algo = new WrapperAlgo();
            foreach (UnitElf u in UnitsElves)
            {
                Map m = Jeu.Game.Map;
                double* costs = null;
                int* moves = null;
                double mp = u.movePoints;
                algo.WrapperElfMvt(m.toInt(), m.Size, x, y, costs, moves, mp);
            }
        }
    }
}
