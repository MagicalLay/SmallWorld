using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class Dwarf : People
    {
        public Dwarf(int nbUnits) : base(nbUnits, Species.Dwarf) { }

        public System.Collections.Generic.IEnumerable<Jeu.UnitDwarf> UnitsDwarf
        {
            get;
            private set;
        }
    }
}
