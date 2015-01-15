using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class UnitOrc : Unit
    {
        public UnitOrc()
        {
            favoriteSpace = Space.Type.Field;
        }
        public override Type getType()
        {
            return Type.Orc;
        }
    }
}
