using System;

namespace Jeu
{
    public abstract class Unit
    {
        public Unit()
        {
            hp = 5;
            movePoints = 2; // initialisé à 2 pour pouvoir décrémenter de 2 quand un Elf va sur une case Desert 
            attackPoints = 2;  
            defencePoints = 1;
        }
        public int axis
        {
            get;
            protected set;
        }
        public int ordinate
        {
            get;
            protected set;
        } 
        public void placer(int x, int y) {
            axis = x;
            ordinate = y;
        }

        public int hp
        {
            get;
            protected set;
        }

        public double movePoints
        {
            get;
            protected set;
        }

        public int attackPoints
        {
            get;
            protected set;
        }
        public int defencePoints
        {
            get;
            protected set;
        }
        public Boolean isNeighbour(int x, int y, Map m)
        {
            if (!m.ValidCoordinates(x, y) || !m.ValidCoordinates(axis,ordinate)) { return false; }
            else {
                if (axis % 2 == 0)
                {
                    return
                        (x == axis + 1 && y == ordinate) ||
                        (x == axis - 1 && y == ordinate) ||
                        (x == axis - 1 && y == ordinate + 1) ||
                        (x == axis - 1 && y == ordinate - 1) ||
                        (x == axis && y == ordinate + 1) ||
                        (x == axis && y == ordinate - 1);
                }
                else
                {
                    return
                        (x == axis + 1 && y == ordinate) ||
                        (x == axis - 1 && y == ordinate) ||
                        (x == axis + 1 && y == ordinate + 1) ||
                        (x == axis + 1 && y == ordinate - 1) ||
                        (x == axis && y == ordinate + 1) ||
                        (x == axis && y == ordinate - 1);
                }
            }
        }
        public enum Type { Dwarf, Elf, Orc, Unit };

        public Type getType()
        {
            return Type.Unit;
        }
        public Space.Type favoriteSpace
        {
            get;
            protected set;
        }

        public void move(int x, int y, Map m) 
        {
            if (getType() == Type.Dwarf && m[x, y].getType() == Space.Type.Mountain)
            {
                placer(x, y);
                movePoints--;
            }
            else if (!isNeighbour(x,y,m) || movePoints == 0) 
            {
                Console.WriteLine("Impossible to move here");
            }
            else if (isNeighbour(x,y,m) && getType() == Type.Elf && m[x, y].getType() == Space.Type.Desert)
            {
                placer(x, y);
                movePoints = movePoints - 2;
            }
            else if (isNeighbour(x, y, m) && m[x, y].getType() == favoriteSpace)
            {
                placer(x, y);
                movePoints = movePoints - 0.5;
            }
            else
            {
                placer(x, y);
                movePoints--;
            }
        }
        public Boolean fight(Unit attacked, Game g)
        {
            Boolean b;
            if (!isNeighbour(attacked.axis, attacked.ordinate, g.Map))
            {
                Console.WriteLine("You can't attack this space !");
                b = false;
                return b;
            }
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

        public void die()
        {
            Console.WriteLine("Dead unit");
        }
    }
}
