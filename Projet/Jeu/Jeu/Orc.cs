using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class Orc : People
    {
        public Orc(int nbUnits) : base(nbUnits, Species.Orc) { }
        public System.Collections.Generic.IEnumerable<Jeu.UnitOrc> UnitsOrc
        {
            get;
            private set;
        }
    }
}
