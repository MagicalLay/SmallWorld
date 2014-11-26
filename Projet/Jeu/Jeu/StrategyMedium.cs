using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class StrategyMedium : IStrategy
    {
        public StrategyMedium() {}
    
        public Map instantiate()
        {
            Map mapMedium = new Map(MapSize.Medium);
            return mapMedium;
        }
    }
}
