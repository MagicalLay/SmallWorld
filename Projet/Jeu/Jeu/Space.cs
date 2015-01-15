using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public abstract class Space
    {
        public int axis
        {
            get;
            private set;
        }
        public int ordinate
        {
            get;
            private set;
        }

        public enum Type{ Desert, Field, Forest, Mountain, Space};

        public Type getType(){
            return Type.Space;
        }

        public Boolean isNeighbour(Space sp)
        {
            return 
                (sp.axis == axis + 1 && sp.ordinate == ordinate) ||
                (sp.axis == axis - 1 && sp.ordinate == ordinate) ||
                (sp.axis == axis + 1 && sp.ordinate == ordinate + 1) ||
                (sp.axis == axis + 1 && sp.ordinate == ordinate - 1) ||
                (sp.axis == axis - 1 && sp.ordinate == ordinate + 1) ||
                (sp.axis == axis - 1 && sp.ordinate == ordinate - 1);
        }
    }
}
