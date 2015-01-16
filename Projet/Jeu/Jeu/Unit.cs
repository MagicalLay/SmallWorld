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
                ((m.ValidCoordinates(x,y) && getType() == Type.Dwarf && m[x, y].getType() == Space.Type.Mountain && movePoints >= 1 && m.zeroUnit(x, y, g.getPeople(opponent(g)))) ||
                (isNeighbour(x, y, m) && getType() == Type.Elf && m[x, y].getType() == Space.Type.Desert && movePoints == 2) ||
                (isNeighbour(x, y, m) && m[x, y].getType() == favoriteSpace && movePoints >= 0.5) ||
                (isNeighbour(x, y, m) && m[x, y].getType() != favoriteSpace && movePoints >= 1));
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
        
        // Effectue le déplacement de l'unité sur la case [x,y] de m, si c'est possible
        public void move(int x, int y, Game g) 
            // Les nains peuvent accéder aux cases Mountain si ils ont assez de points de mouvement et si cette case
            // ne contient pas d'unité adverse
        {
            Map m = g.Map;
                if (getType() == Type.Dwarf && m[x, y].getType() == Space.Type.Mountain && movePoints >= 1 && opponent(g) != -1
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
                placer(x, y);
                movePoints = 0;
            }
            if (isNeighbour(x, y, m) && m[x, y].getType() == favoriteSpace && movePoints >= 0.5)
            {
                placer(x, y);
                movePoints = movePoints - 0.5;
            }
            if (isNeighbour(x, y, m) && m[x, y].getType() != favoriteSpace && movePoints >= 1)
            {
                placer(x, y);
                movePoints--;
            } 
        }
        // Renvoie pour une case[x,y] la meilleure unité défensive adverse présente
        // cette fonction sera utilisée dans la fonction fight qui vérifie déjà la validité de [x,y]
        // ainsi que l'existence de l'adversaire dans g
        Unit bestDefensiveUnit(int x, int y, Game g)
        {
            People opp = g.getPeople(opponent(g));
            Unit attacked = opp.units[0]; // par défaut
            foreach (Unit u in opp.units)
            {
                if (u.axis == x && u.ordinate == y && u.hp >= attacked.hp) { attacked = u; }
            }
            return attacked;
        }
        // Algorithme simplifié des combats : renvoie vrai si le combat a eu lieu, faux sinon
        // L'unité tuée à la fin est choisie de façon aléatoire
        public Boolean SimpleFight(int x, int y, Game g)
        {
            Boolean b;
            if (attackPoints == 0 || g.Map.zeroUnit(x, y, g.getPeople(opponent(g))))
            {
                Console.WriteLine("You can't attack this space");
                b = false;
                return b;
            }
            else
            {
                b = true;
                // choice of the defensive Unit
                Unit attacked = bestDefensiveUnit(x, y, g);
                Random rnd2 = new Random();
                int noLuck = rnd2.Next(0, 2);
                if (noLuck == 0)
                {
                    die(g);
                }
                else
                {
                    attacked.die(g);
                    if (g.Map.zeroUnit(x, y, g.getPeople(opponent(g))))
                    {
                        move(x, y, g);
                    }
                }
                return b;
            }
        }
        // Algorithme des combats : renvoie vrai si le combat a eu lieu, faux sinon
        public Boolean fight(int x, int y, Game g)
        {
            Boolean b;
            if (attackPoints == 0 || g.Map.zeroUnit(x,y,g.getPeople(opponent(g))))
            {
                Console.WriteLine("You can't attack this space");
                b = false;
                return b;
            }
            else 
            {
                b = true;
                // choice of the defensive Unit
                Unit attacked = bestDefensiveUnit(x, y, g);
                // number of rounds
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
                        attacked.die(g);
                        //move(attacked.Space.axis, attacked.Space.ordinate);
                        Console.WriteLine("End of fight - Attacker wins");
                        return b;
                    }
                    else if (i % 2 == 1 && (hp == 0 || defencePoints == 0))
                    {
                        die(g);
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
