using System;
namespace Jeu
{
    public abstract class Unit
    {
        public Unit()
        {
            hp = 5;
            movePoints = 1;
        }

        public Space Space
        {
            get;
            private set;
        }

        public static int hp
        {
            get;
            private set;
        }

        public static int movePoints
        {
            get;
            private set;
        }

        public void attack()
        {
            if (hp == 0)
            {
                die();
            }
        }

        public void defend()
        {
            if (hp == 0)
            {
                die();
            }
        }

        public void move(int x, int y)
        {
            if (movePoints == 0)
            {
                Console.WriteLine("Not enough points to move !");
            }
            else
            {
                movePoints--;
            }
        }

        public void die()
        {
            Console.WriteLine("Dead unit !");
        }
    }
}
