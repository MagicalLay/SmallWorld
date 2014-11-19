using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class Dwarf : People
    {
        public Dwarf(int nbUnite) : base(nbUnite, "Dwarf")
        {
            throw new System.NotImplementedException();
        }
    
        public System.Collections.Generic.IEnumerable<Jeu.UnitDwarf> UnitDwarf
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
