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

        public void placer(Space s) {
            Space = s;
        }

        public int hp
        {
            get;
            private set;
        }

        public double movePoints
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

        public Boolean fight(Unit attacked, Game g)
        {
            Boolean b;
            if (attacked.Space.axis < 0 || attacked.Space.axis > g.getMapSize()-1 || attacked.Space.ordinate < 0 || attacked.Space.ordinate > g.getMapSize()- 1)
            {
                Console.WriteLine("Attacked space does not exist !");
                b = false;
                return b;
            }
            /*else if (!this.Space.isNeighbour(Game.Map[attacked.Space.axis, attacked.Space.ordinate]))
            {
                Console.WriteLine("You can't attack this space !");
                b = false;
                return b;
            }*/
            else
            {
                b = true;
                // number of fights
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

                // chances of losing hp for the attacker
                double attackerChancesOfLosingHp = 0.5 + 0.5 * (attackPoints / (attacked.defencePoints));
                
                // probabilities for attacker and defender
                double probaAttacker = (this.hp / 5) * this.attackPoints;
                double probaDefender = (attacked.hp / 5) * attacked.attackPoints;

                for (int i = 0; i < nbFights; i++) 
                {
                    if (i % 2 == 0 && attacked.hp != 0 && attacked.defencePoints != 0) 
                    {
                        attacked.hp--;
                        attacked.defencePoints--;
                        attackPoints--;
                    }
                    else if (i % 2 == 0 && (attacked.hp == 0 || attacked.defencePoints == 0))
                    {
                        attacked.die();
                        //move(attacked.Space.axis, attacked.Space.ordinate);
                        Console.WriteLine("End of fight - Attacker wins");
                        return b;
                    }
                    else if (i % 2 == 1 && (hp == 0 || defencePoints == 0))
                    {
                        die();
                        //attacked.move(Space.axis, Space.ordinate);
                        Console.WriteLine("End of fight - Defender wins");
                        return b;
                    }
                    else
                    {
                        hp--;
                        defencePoints--;
                        attacked.attackPoints--;
                    }
                }
                return b;
            }
        }

        public Boolean move(int x, int y, Game g)
        {
            Space sp = g.getSpace(x, y);
            if (movePoints == 0 || Space.isNeighbour(sp))
            {
                return false;
            }
            else 
            {
                placer(g.getSpace(x,y));
                movePoints--;
                return true;
            }
        }

        public void die()
        {
            Console.WriteLine("Dead unit");
        }
    }
}
