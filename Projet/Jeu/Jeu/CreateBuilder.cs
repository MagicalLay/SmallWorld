using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class CreateBuilder : IBuilderGame
    {
        public CreateBuilder(MapSize size, Species people1, Species people2)
        {
            Map map = createMap(size);
            People[] p = createPeoples(people1, people2, map);
            Game game = createGame(map, p[0], p[1]);
        }

        public Game createGame(Map map, People p1, People p2)
        {
            return new Game(map, p1, p2);
        }

        public People[] createPeoples(Species people1, Species people2, Map m)
        {
            FactoryPeople fp = new FactoryPeople();
            People[] p = new People[2];
            p = fp.makePeoples(people1, people2, m);
            return p;
        }

        public Map createMap(MapSize size)
        {
            switch (size)
            {
                case MapSize.Small:
                    StrategySmall sts = new StrategySmall();
                    return sts.instantiate();
                case MapSize.Medium:
                    StrategyMedium stm = new StrategyMedium();
                    return stm.instantiate();
                case MapSize.Large:
                    StrategyLarge stl = new StrategyLarge();
                    return stl.instantiate();
                default:
                    throw new System.NotImplementedException("Erreur dans la taille de la carte !!");
            }

        }

        public Game createGame()
        {
            throw new NotImplementedException();
        }
    }
}
