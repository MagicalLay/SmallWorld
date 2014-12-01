using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class CreateBuilder : IBuilderGame
    {
        public CreateBuilder(MapSize size, String people1, String people2)
        {
            Map map = createMap(size);
            People p1 = createPeople(people1, map);
            People p2 = createPeople(people2, map);
            Game game = createGame(map, p1, p2);
        }

        public Game createGame(Map map, People p1, People p2)
        {
            return new Game(map, p1, p2);
        }

        public People createPeople(String People, Map m)
        {
            throw new System.NotImplementedException();
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
