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

        public Boolean init_attack(Unit attacked)
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

                /* chances of losing hp for the attacker */
                double attackerChancesOfLosingHp = 0.5 + 0.5 * (attackPoints / (attacked.defencePoints));
                
                /* probabilities for attacker and defender */
                double probabilityAttacker = (this.hp / 5) * this.attackPoints;
                double probabilityDefender = (attacked.hp / 5) * attacked.attackPoints;

                /* Attack begins */
                this.attack(attacked, nbFights);
                b = true;
            }
            return b;
        }

        public Boolean attack(Unit attacked, int nbFights)
        {
            Boolean b;
            if (nbFights != 0)
            {
                nbFights--;
                if (attacked.hp == 0)
                {
                    attacked.die();
                    Console.WriteLine("End of fight - defender wins !");
                    b = true;
                    this.move(attacked.Space.axis, attacked.Space.ordinate);
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
            }
            else 
            {
                Console.WriteLine("End of fight !");
                b = true; 
            }
            return b;
        }
        public Boolean defend(Unit attacker, int nbFights)
        {
            Boolean b;
            if (nbFights != 0)
            {
                nbFights--;
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
            }
            else 
            {
                Console.WriteLine("End of fight");
                b = true; 
            }
            return b;
        }
        public Boolean move(int x, int y)
        {
            Boolean b;
            if (movePoints == 0)
            {
                Console.WriteLine("Not enough points to move");
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
                this.Space = Game.Map[x, y];
                movePoints--;
                b = true;
                Console.WriteLine("Movement achieved");
            }
            return b;
        }

        public void die()
        {
            Console.WriteLine("Dead unit");
        }
    }
}
