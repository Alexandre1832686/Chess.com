using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet2Chess
{
    class vraiInvente2 // : Invente2
    {

        /*public vraiInvente2(ConsoleColor laCouleur) : base(laCouleur)
        { }
        */

        /***********************************************************************************************************
         * 
         * créer un tableau pour les directions possibles.
         * remplir le tableau
         * 
         * boucler sur le tableau des direction 
         *      dans cette boucle on créer une nouvelle boucle jsuqua la sortie du board ou l'atteinte d'une piece pour confirmé que cette case est valide
         *      si la verification est vrai on ajoute la coordonnée a la liste.
         * 
         * revoyer la liste
         * 
         ***********************************************************************************************************/
        public /*override*/ List<Coordonnee> DeterminerPositionsValides(Piece[,] lePlateau, Coordonnee maPosition)
        {
            //création de la liste pour les positions disponibles
            List<Coordonnee> result = new List<Coordonnee>();

            //instanciation des direction
            int[,] montab = new int[12, 2];
            montab[0, 0] = 1;
            montab[0, 1] = 2;

            montab[1, 0] = -1;
            montab[1, 1] = 2;

            montab[2, 0] = 2;
            montab[2, 1] = 1;

            montab[3, 0] = 2;
            montab[3, 1] = -1;

            montab[4, 0] = 1;
            montab[4, 1] = -2;

            montab[5, 0] = -1;
            montab[5, 1] = -2;

            montab[6, 0] = -2;
            montab[6, 1] = 1;

            montab[7, 0] = -2;
            montab[7, 1] = -1;

            montab[8, 0] = 1;
            montab[8, 1] = 0;

            montab[9, 0] = 0;
            montab[9, 1] = 1;

            montab[10, 0] = -1;
            montab[10, 1] = 0;

            montab[10, 0] = 0;
            montab[10, 1] = -1;

            //Boucle sur les 12 directions
            for (int i = 0; i < 12; i++)
            {
                int dirX = montab[i, 0];
                int dirY = montab[i, 1];

                bool verif = true;
                int compteur = 1;

                //récupère la couleur du pion
                ConsoleColor maCouleur = lePlateau[maPosition.X, maPosition.Y].couleurPiece;


                //verification pour ne pas que le pions ne dépasse pas les limites du tableau
                if (maPosition.X + dirX * compteur > 7 || maPosition.X + dirX * compteur < 0)
                {
                    verif = false;
                }

                if (maPosition.Y + dirY * compteur > 7 || maPosition.Y + dirY * compteur < 0)
                {
                    verif = false;
                }

                if (verif == true)
                {
                    //vérifi si le pion tombe sur un pion de son équipe
                    if (lePlateau[maPosition.X + dirX * compteur, maPosition.Y + dirY * compteur].couleurPiece != maCouleur)
                    {
                        if (verif == true)
                        {
                            //ajoute la coordoné dans le tableau si elle est valide
                            Coordonnee maCoo = new Coordonnee(maPosition.X + dirX * compteur, maPosition.Y + dirY * compteur);
                            result.Add(maCoo);
                        }
                    }
                }
            }

            return result;
            //return base.DeterminerPositionsValides(lePlateau, maPosition);
        }
    }
}