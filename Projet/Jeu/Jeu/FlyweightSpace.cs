using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class FlyweightSpace : ISpace
    {
        private static FlyweightSpace instance_Space;

        private Desert desert;
        private Forest forest;
        private Mountain mountain;
        private Field field;
        public FlyweightSpace()
        {
            desert = new Desert();
            forest = new Forest();
            mountain = new Mountain();
            field = new Field();
        }
        public static FlyweightSpace Instance_Space
        {
            get
            {
                if (instance_Space == null)
                {
                    instance_Space = new FlyweightSpace();
                }
                return instance_Space;
            }
        }

        public Space getDesert()
        {
            return desert;
        }
        public Space getField()
        {
            return field;
        }
        public Space getMountain()
        {
            return mountain;
        }
        public Space getForest()
        {
            return forest;
        }
    }
}
