using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public abstract class People
    {
        public string Nickname
        {
            get;
            protected set;
        }

        public void surnom(string s)
        {
            Nickname = s;
        }

        public People(int nb)
        {
            nbUnits = nb;
            nbPoints = 0;
        }

        public Unit[] units
        {
            get;
            protected set;
        }
        public int nbPoints
        {
            get;
            private set;
        }
        public int nbUnits
        {
            get;
            private set;
        }
        // Renvoie vrai s'il existe au moins une unité du peuple sur la case[x,y] du jeu g
        // Les unités Nain sur les cases Plaine ne rapportent aucun point donc sont considérées inexistantes
        // Idem pour les Orcs sur les cases Forêt
        public Boolean existOn(int x, int y, Map m)
        {
            Boolean b = false;
            Space.Type t = m[x, y].getType();
            for (int i = 0; i < units.Length; i++)
            {
                if (m.ValidCoordinates(x, y) && units[i].axis == x && units[i].ordinate == y
                    && t == Space.Type.Field && getType() != Type.DwarfP)
                {
                    b = true;
                    break;
                }
                if (m.ValidCoordinates(x, y) && units[i].axis == x && units[i].ordinate == y
                    && t == Space.Type.Forest && getType() != Type.OrcP)
                {
                    b = true;
                    break;
                }
                if (m.ValidCoordinates(x, y) && units[i].axis == x && units[i].ordinate == y
                    && t != Space.Type.Field && t != Space.Type.Forest)
                {
                    b = true;
                    break;
                }
            }
            return b;
        }

        public int countPoints(Map m)
        {
            int res = 0;
            for (int i = 0; i < m.Size; i++)
            {
                for (int j = 0; j < m.Size; j++)
                {
                    if (existOn(i, j, m))
                    {
                            res++;
                    }
                }
            }
            if (getType() == Type.OrcP)
            {
                foreach (Unit u in units)
                {
                    res += u.bonusPoints;
                }
            } 
            return res;
        }
        public void majPoints(Map m)
        {
            nbPoints = countPoints(m);
        }
        public void initMovePoints()
        {
            foreach (Unit u in units)
            {
                u.initMovePoints();
            }
        }
        public void decUnits()
        {
            if (nbUnits > 0) { nbUnits--;  }
        }
        public void place(int x, int y, Map m)
        {
            if (m.ValidCoordinates(x, y))
            {
                foreach (Unit u in units)
                {
                    u.placer(x, y);
                }
            }
        }

        public enum Type { DwarfP, ElfP, OrcP, People };
        public virtual Type getType()
        {
            return Type.People;
        }
    }
}
