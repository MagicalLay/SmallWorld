using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class Map
    {

        public Map(int choose)
        {

            switch (choose)
            {
                case 1 :
                    size = 6;
                    break;

                case 2 :
                    size = 10;
                    break;

                case 3 :
                    size = 14;
                    break;

                default:
                    //printf("Erreur de sélection de taille, taille invalide !")
                    break;
            }

            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<Jeu.Space> Space
        {
            get
            {
                return Space;
            }
            set
            {
            }
        }

        public int size
        {
            get
            {
                return size;
                //throw new System.NotImplementedException();
            }
            set
            {
                size = value;
            }
        }
    }
}
