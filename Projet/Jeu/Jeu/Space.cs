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

        public Boolean isNeighbour(Space sp)
        {
            if (this.axis != sp.axis - 1 && this.axis != sp.axis + 1 && ordinate != sp.ordinate - 1 && ordinate != sp.ordinate + 1)
            {
                return false;
            }
            else { return true; }
        }
        
        }
}
