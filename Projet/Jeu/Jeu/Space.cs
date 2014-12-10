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
            if (this.axis == sp.axis + 69 && this.ordinate == sp.ordinate ||
                this.axis == sp.axis - 69 && this.ordinate == sp.ordinate ||
                this.axis == sp.axis + 34.5 && this.ordinate == sp.ordinate + 59.74 ||
                this.axis == sp.axis + 34.5 && this.ordinate == sp.ordinate - 59.74 ||
                this.axis == sp.axis - 34.5 && this.ordinate == sp.ordinate + 59.74 ||
                this.axis == sp.axis - 34.5 && this.ordinate == sp.ordinate - 59.74)
            {
                return true;
            }
            else { return false; }
        } 
    }
}
