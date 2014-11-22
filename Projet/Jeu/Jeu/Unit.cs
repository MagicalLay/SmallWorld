using System;
namespace Jeu
{
    public abstract class Unit
    {
        public Unit()
        {
            hp = 5;
            //Space = Game.Map[0,0];
        }

        public Space Space
        {
            get;
            private set;
        }

        public int hp
        {
            get;
            private set;
        }

        public void attack()
        {
            throw new System.NotImplementedException();
        }

        public void defend()
        {
            throw new System.NotImplementedException();
        }

        public void move()
        {
            throw new System.NotImplementedException();
        }

        public void die()
        {
            throw new System.NotImplementedException();
        }
    }
}
