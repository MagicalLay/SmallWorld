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

        public int attackPoints
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
            Boolean b;
            if (attacked.Space.axis < 0 || attacked.Space.axis > Game.Map.Size - 1 || attacked.Space.ordinate < 0 || attacked.Space.ordinate > Game.Map.Size - 1)
            {
                Console.WriteLine("Attacked space does not exist !");
                b = false;
            }
            else if (!this.Space.isNeighbour(Game.Map[attacked.Space.axis, attacked.Space.ordinate]))
            {
                Console.WriteLine("You can't attack this space !");
                b = false;
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
                    nbFights--;
                    if (hp == 0)
                    {
                        die();
                        Console.WriteLine("End of fight - defender wins !");
                        b = true;
                    }
                    else if (attacked.hp == 0)
                    {
                        attacked.die();
                        Console.WriteLine("End of fight - attacker wins !");
                        move(attacked.Space.axis, attacked.Space.ordinate);
                        b = true;
                    }
                    else
                    {
                        Console.WriteLine("Defender turn");
                        attacked.defend(this, nbFights);
                        b = true;
                    }
                }
                else
                {
                    Console.WriteLine("End of fight - no turns left");
                    b = true;
                }
            }
            return b;
        }

        public Boolean defend(Unit attacker, int nbFights)
        {
            Boolean b;
            if (attacker.hp == 0)
            {
                attacker.die();
                Console.WriteLine("End of fight - defender wins !");
                b = true;
            }
            else if (hp == 0)
            {
                die();
                Console.WriteLine("End of fight - attacker wins !");
                b = true;
            }
            else
            {
                b = false;
            }
            return b;
        }

        public Boolean move(int x, int y)
        {
            Boolean b;
            if (movePoints == 0)
            {
                Console.WriteLine("Not enough points to move !");
                b = false;
            }
            else if (x < 0 || x > Game.Map.Size || y < 0 || y > Game.Map.Size)
            {
                Console.WriteLine("Space does not exist");
                b = false;
            }
            else if (!Space.isNeighbour(Game.Map[x, y]))
            {
                Console.WriteLine("Impossible move to this space");
                b = false;
            }
            else
            {
                Space = Game.Map[x, y];
                movePoints--;
                b = true;
            }
            return b;
        }

        public void die()
        {
            Console.WriteLine("Dead unit !");
        }
    }
}
