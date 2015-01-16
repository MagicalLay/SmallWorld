using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Jeu
{
    public abstract class Unit : INotifyPropertyChanged
    {
        public Unit()
        {
            hp = 5;
            movePoints = 2; // initialisé à 2 pour pouvoir décrémenter de 2 quand un Elf va sur une case Desert 
            attackPoints = 2;  
            defencePoints = 1;
            bonusPoints = 0;
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
        public int bonusPoints
        {
            get;
            protected set;
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
        public void placer(int x, int y) {
            axis = x;
            ordinate = y;
        }
        public void initMovePoints()
        {
            movePoints = 2;
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

        public virtual Type getType()
        {
            return Type.Unit;
        }
        public Space.Type favoriteSpace
        {
            get;
            protected set;
        }

        // Renvoie vrai si la case [x,y] de m est accessible par l'unité
        public Boolean possibleMove(int x, int y, Game g)
        {
            Map m = g.Map;
            return
                (
                (m[axis, ordinate].getType() == Space.Type.Mountain && m.ValidCoordinates(x,y) && getType() == Type.Dwarf && m[x, y].getType() == Space.Type.Mountain && movePoints >= 1 && m.zeroUnit(x, y, g.getPeople(opponent(g)))) ||
                (isNeighbour(x, y, m) && getType() == Type.Elf && m[x, y].getType() == Space.Type.Desert && movePoints == 2) ||
                (isNeighbour(x, y, m) && m[x, y].getType() == favoriteSpace && movePoints >= 0.5) ||
                (isNeighbour(x, y, m) && m[x, y].getType() != favoriteSpace && movePoints >= 1)
                );
        }

        // Renvoie le numéro du peuple adversaire de l'unité courante dans le jeu g, 
        // renvoie -1 si le type de l'unité courante n'est pas dans g
        public int opponent(Game g)
        {
            if (g.getPeople(0).units[0].getType() == getType())
            {
                return 1;
            }
            else if (g.getPeople(1).units[0].getType() == getType())
            {
                return 0;
            }
            else 
            { 
                return -1; 
            }
        }
        
        // Effectue le déplacement de l'unité sur la case [x,y] de m, si c'est possible, en sachant que
        // les nains peuvent accéder à n'importe quelle case Mountain depuis une case Mountain si ils ont assez de points 
        // de mouvement et si la case visée ne contient pas d'unité adverse
        public void move(int x, int y, Game g) 
        {
            Map m = g.Map;
            Space.Type st = m[axis, ordinate].getType();
                if (st == Space.Type.Mountain && getType() == Type.Dwarf  && m[x, y].getType() == Space.Type.Mountain && movePoints >= 1 && opponent(g) != -1
                    && m.zeroUnit(x,y,g.getPeople(opponent(g))))
                {
                    placer(x, y);
                    movePoints--;
                }
            if (!isNeighbour(x,y,m) || movePoints == 0) 
            {
                Console.WriteLine("Impossible to move here");
            }
            if (isNeighbour(x,y,m) && getType() == Type.Elf && m[x, y].getType() == Space.Type.Desert && movePoints == 2)
            {
                if (!m.zeroUnit(x, y, g.getPeople(opponent(g))))
                {
                    movePoints = movePoints - 2;
                    fight(x, y, g);
                    if (!isDead() && m.zeroUnit(x, y, g.getPeople(opponent(g))))
                    {
                        placer(x, y);
                    }
                }
                else
                {
                    placer(x, y);
                    movePoints = movePoints - 2;
                }
            }
            if (isNeighbour(x, y, m) && m[x, y].getType() == favoriteSpace && movePoints >= 0.5)
            {
                if (!m.zeroUnit(x, y, g.getPeople(opponent(g))))
                {
                    movePoints = movePoints - 0.5;
                    fight(x, y, g);
                    if (!isDead() && m.zeroUnit(x, y, g.getPeople(opponent(g))))
                    {
                        placer(x, y);
                    }
                }
                else
                {
                    placer(x, y);
                    movePoints = movePoints - 0.5;
                }
            }
            if (isNeighbour(x, y, m) && m[x, y].getType() != favoriteSpace && movePoints >= 1)
            {
                if (!m.zeroUnit(x, y, g.getPeople(opponent(g))))
                {
                    movePoints--;
                    fight(x, y, g);
                    if (!isDead() && m.zeroUnit(x, y, g.getPeople(opponent(g))))
                    {
                        placer(x, y);
                    }
                }
                else
                {
                    placer(x, y);
                    movePoints--;
                }
            } 
        }
        // Renvoie pour une case[x,y] la meilleure unité défensive adverse présente
        // Cette fonction sera utilisée dans la fonction fight qui vérifie déjà la validité de [x,y]
        // ainsi que l'existence de l'adversaire dans g
        Unit bestDefensiveUnit(int x, int y, Game g)
        {
            People opp = g.getPeople(opponent(g));
            Unit attacked = opp.units[0]; // par défaut
            foreach (Unit u in opp.units)
            {
                if (u.axis == x && u.ordinate == y && u.hp > attacked.hp) { attacked = u; }
            }
            return attacked;
        }

        // Premier essai : algorithme simplifié des combats
        // L'unité tuée à la fin est choisie de façon aléatoire
        public void SimpleFight(int x, int y, Game g)
        {
            if (attackPoints == 0 || g.Map.zeroUnit(x, y, g.getPeople(opponent(g))))
            {
                Console.WriteLine("You can't attack this space");
            }
            else
            {
                Unit attacked = bestDefensiveUnit(x, y, g);

                Random rnd2 = new Random();
                int badLuck = rnd2.Next(0, 2);
                if (badLuck == 0)
                {
                    die(g);
                }
                else
                {
                    attacked.die(g);
                    if (this.getType() == Type.Orc)
                    {
                        bonusPoints++;
                    }
                }
            }
        }

        // Algorithme des combats respectant le cahier des charges
        public void fight(int x, int y, Game g)
        {
            if (attackPoints == 0 || g.Map.zeroUnit(x,y,g.getPeople(opponent(g))))
            {
                Console.WriteLine("You can't attack this space");
            }
            else 
            {
                Unit attacked = bestDefensiveUnit(x, y, g);

                int nbFights;
                Random rnd = new Random();
                nbFights = rnd.Next(3, Math.Max(hp + 3, attacked.hp +3));

                double probaAttacker = (this.hp / 5) * this.attackPoints;
                double probaDefender = (attacked.hp / 5) * attacked.attackPoints;

                double dieProbaAttacker = 0.5;

                double ratio = ((double)Math.Abs(probaAttacker - probaDefender) / Math.Max(probaAttacker, probaDefender));
                if (probaAttacker > probaDefender)
                {
                    dieProbaAttacker -= ratio;
                }
                else
                {
                    dieProbaAttacker += ratio;
                }
                Random random = new Random();
                while(hp > 0 && attacked.hp > 0 && nbFights > 0) 
                {
                    double r = random.Next(100);
                    if (r < dieProbaAttacker * 100)
                    {
                        hp--;
                    }
                    else
                    {
                        attacked.hp--;
                    }
                    nbFights--;
                }
                if (hp == 0) { die(g); }
                if (attacked.hp == 0) 
                { 
                    attacked.die(g);
                    if (this.getType() == Type.Orc)
                    {
                        bonusPoints++;
                    }
                }
            }
        }

        #region INotifyPropertyChanged

        [field: NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        public Boolean isDead()
        {
            return hp == 0;
        }
        public void die(Game g)
        {
            hp = 0;
            if (opponent(g) == 0)
            {
                g.getPeople(1).decUnits();
            }
            else
            {
                g.getPeople(0).decUnits();
            }
        }
    }
}
