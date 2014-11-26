using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class Elf : People
    {
        public Elf(int nbUnits) : base(nbUnits, Species.Elf) { }

        public System.Collections.Generic.IEnumerable<Jeu.UnitElf> UnitsElf
        {
            get;
            private set;
        }
    }
}
