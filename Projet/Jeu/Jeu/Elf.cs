using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class Elf : People
    {
        public Elf(int nbUnite) : base(nbUnite, "Elf")
        {
            throw new System.NotImplementedException();
        }
    
        public System.Collections.Generic.IEnumerable<Jeu.UnitElf> UnitElf
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
