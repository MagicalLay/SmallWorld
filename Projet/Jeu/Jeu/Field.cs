using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class Field : Space
    {
        public Field() { }

        public override Type getType()
        {
            return Type.Field;
        }
    }
}
