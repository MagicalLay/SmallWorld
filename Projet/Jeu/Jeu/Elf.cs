using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapper;

namespace Jeu
{
    public class Elf : People
    {

        public Elf(int nbU) : base(nbU){
            int i;
            units = new Unit[nbU];
            for (i = 0; i < nbUnits; i++)
            {
                units[i] = new UnitElf();
            }
        }

        public System.Collections.Generic.IEnumerable<Jeu.UnitElf> UnitsElves
        {
            get;
            private set;
        }
        unsafe public void move(int x, int y)
        {
            WrapperAlgo algo = new WrapperAlgo();
            foreach (UnitElf u in UnitsElves)
            {
                if (u.Space.isNeighbour(Game.Map[x, y]))
                {
                    //u.move(x,y);
                }
            }
        }
    }
}
