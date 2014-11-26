using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class StrategySmall : IStrategy
    {
        public StrategySmall() { }
    
        public Map instantiate()
        {
            Map mapSmall = new Map(MapSize.Small);
            return mapSmall;
        }
    }
}
