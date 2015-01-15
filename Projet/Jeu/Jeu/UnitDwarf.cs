using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class UnitDwarf : Unit
    {
        public UnitDwarf()
        {
            favoriteSpace = Space.Type.Field;
        }
        public override Type getType()
        {
            return Type.Dwarf;
        }
    }
}
