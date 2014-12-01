using System;
namespace Jeu
{
    public abstract class Unit
    {
        public Unit()
        {
            hp = 5;
            movePoints = 1;
            attackPoints = 2;
            defencePoints = 1;
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

        public static int movePoints
        {
            get;
            private set;
        }

        public static int attackPoints
        {
            get;
            private set;
        }
        public int defencePoints
        {
            get;
            private set;
        }

        public Boolean attack(Unit attacked)
        {
            if (attacked.Space.axis < 0 || attacked.Space.axis > Game.Map.Size - 1 || attacked.Space.ordinate < 0 || attacked.Space.ordinate > Game.Map.Size - 1)
            {
                Console.WriteLine("Attacked space does not exist !");
                return false;
            }
            else if (!this.Space.isNeighbour(Game.Map[attacked.Space.axis, attacked.Space.ordinate]))
            {
                Console.WriteLine("You can't attack that space !");
                return false;
            }
            else
            {
                /* number of fights */
                int nbFights;
                Random rnd = new Random();
                if (hp > attacked.hp)
                {
                    nbFights = rnd.Next(3, hp + 3);
                }
                else
                {
                    nbFights = rnd.Next(3, attacked.hp + 3);
                }

                /* chances of winning for the attacker */
                double chancesOfWin = 0.5 + 0.5 * (attackPoints / (attacked.defencePoints));
                
                /* what happens during the attack */
                if (nbFights != 0)
                {
                    if (hp == 0)
                    {
                        die();
                        Console.WriteLine("End of fight");
                        return true;
                    }
                    else if (attacked.hp == 0)
                    {
                        attacked.die();
                        Console.WriteLine("End of fight");
                        return true;
                    }
                    else if (attacked.defencePoints == 0)
                    {
                        Console.WriteLine("End of fight");
                        attacked.hp--;
                        return true;
                    }
                    else
                    {
                        attacked.defend(this);
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("End of fight");
                    move(attacked.Space.axis, attacked.Space.ordinate);
                    return true;
                }
            }
        }

        public void defend(Unit attacker)
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
