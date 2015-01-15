using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public abstract class People
    {

        public string Nickname
        {
            get;
            protected set;
        }

        public void surnom(string s)
        {
            Nickname = s;
        }

        public People(int nb)
        {
            nbUnits = nb;
            nbPoints = 0;
        }

        public Unit[] units
        {
            get;
            protected set;
        }
        public int nbUnits
        {
            get;
            private set;
        }

        public void place(int x, int y, Map m)
        {
            if (m.ValidCoordinates(x, y))
            {
                foreach (Unit u in units)
                {
                    u.placer(x, y);
                }
            }
        }

        public int nbPoints
        {
            get;
            private set;
        }
        public enum Type { DwarfP, ElfP, OrcP, People };
        public virtual Type getType()
        {
            return Type.People;
        }
    }
}
