using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapper;

namespace Jeu
{
    public class Orc : People
    {
        public Orc(int nbUnits) : base(nbUnits, Species.Orc) { }
        public System.Collections.Generic.IEnumerable<Jeu.UnitOrc> UnitsOrcs
        {
            get;
            private set;
        }

        unsafe public void move(int x, int y)
        {
            WrapperAlgo algo = new WrapperAlgo();
            foreach (UnitOrc u in UnitsOrcs)
            {
                Map m = Jeu.Game.Map;
                double* costs = null;
                int* moves = null;
                double mp = u.movePoints;
                algo.WrapperOrcMvt(m.toInt(), m.Size, x, y, costs, moves, mp);
            }
        }
    }
}
