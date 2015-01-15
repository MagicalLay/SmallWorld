using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public abstract class Space
    {
        public Space() { }
        public enum Type{ Desert, Field, Forest, Mountain, Space};

        public Type getType()
        {
            return Type.Space;
        }
    }
}
