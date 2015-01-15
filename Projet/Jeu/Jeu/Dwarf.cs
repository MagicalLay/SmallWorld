﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapper;

namespace Jeu
{
    public class Dwarf : People
    {
        public Dwarf(int nbUnits) : base(nbUnits) {
            int i;
            units = new Unit[nbUnits];
            for (i = 0; i < nbUnits; i++)
            {
                units[i] = new UnitDwarf();
            }
        }

        public System.Collections.Generic.IEnumerable<Jeu.UnitDwarf> UnitsDwarves
        {
            get;
            private set;
        }
        public void move(int x, int y, Game g)
        {
            foreach (UnitDwarf u in UnitsDwarves)
            {
                if (u.isNeighbour(x, y, g.Map))
                {
                    u.move(x, y, g);
                }
            }
        }
        public Type getType()
        {
            return Type.DwarfP;
        }
    }
}
