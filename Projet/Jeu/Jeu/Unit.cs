using System;
namespace Jeu
{
    public abstract class Unit
    {
        public Unit()
        {
            throw new System.NotImplementedException();
        }
    
        public Space Space
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int hp
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
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
