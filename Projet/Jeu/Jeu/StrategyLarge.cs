using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class StrategyLarge : IStrategy
    {
        public StrategyLarge() { }
        public Map instantiate()
        {
            Map mapLarge = new Map(MapSize.Large);
            return mapLarge;
        }
    }
}
