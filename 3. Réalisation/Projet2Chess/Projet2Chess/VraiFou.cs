using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet2Chess
{
    class VraiFou : Fou
    {
        public VraiFou(ConsoleColor laCouleur):base(laCouleur)
        {}


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
        public override List<Coordonnee> DeterminerPositionsValides(Piece[,] lePlateau, Coordonnee maPosition)
        {
            //création de la liste pour les positions disponibles
            List<Coordonnee> result = new List<Coordonnee>();

            //instanciation des direction
            int[,] montab = new int[4, 2];
            montab[0, 0] = 1;
            montab[0, 1] = 1;

            montab[1, 0] = 1;
            montab[1, 1] = -1;

            montab[2, 0] = -1;
            montab[2, 1] = 1;

            montab[3, 0] = -1;
            montab[3, 1] = -1;

            //récupère la couleur du pion
            ConsoleColor maCouleur = lePlateau[maPosition.X, maPosition.Y].couleurPiece;

            //Boucle sur les 4 directions
            for (int  i=0;i<4;i++)
            {
                int dirX = montab[i, 0];
                int dirY = montab[i, 1];

                bool verif = true;
                int compteur = 1;

                while(verif==true)
                {
                    //verification pour ne pas que le pions ne dépasse pas les limites du tableau
                    if (maPosition.X + dirX*compteur > 7 || maPosition.X + dirX * compteur < 0)
                    {
                        verif = false;
                    }

                    if(maPosition.Y + dirY * compteur > 7 || maPosition.Y + dirY * compteur < 0)
                    {

                        verif = false;
                    }

                    if(verif==true)
                    {
                        //vérifi si le pion tombe sur un pion de son équipe
                        if (lePlateau[maPosition.X + dirX * compteur, maPosition.Y + dirY * compteur].couleurPiece == maCouleur)
                        {
                            verif = false;
                        }
                        
                        //vérifi si le pion tombe sur un pion de son équipe
                        if (maCouleur == ConsoleColor.Black && lePlateau[maPosition.X + dirX * (compteur), maPosition.Y + dirY * (compteur)].couleurPiece == ConsoleColor.White ||
                           maCouleur == ConsoleColor.White && lePlateau[maPosition.X + dirX * (compteur), maPosition.Y + dirY * (compteur)].couleurPiece == ConsoleColor.Black)
                        {
                            verif = false;

                        }

                        //Vérifi s'il peux manger un pion
                        if (verif==true)
                        {
                            Coordonnee maCoo = new Coordonnee(maPosition.X + dirX * compteur, maPosition.Y + dirY * compteur);
                            result.Add(maCoo);
                        }
                    }

                    compteur++;
                }
            }

            return result;
            //return base.DeterminerPositionsValides(lePlateau, maPosition);

            
           
        }
    }
}
