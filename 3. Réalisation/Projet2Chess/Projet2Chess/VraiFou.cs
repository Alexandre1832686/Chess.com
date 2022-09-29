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

            List<Coordonnee> result = new List<Coordonnee>();

            int[,] montab = new int[4, 2];
            montab[0, 0] = 1;
            montab[0, 1] = 1;

            montab[1, 0] = 1;
            montab[1, 1] = -1;

            montab[2, 0] = -1;
            montab[2, 1] = 1;

            montab[3, 0] = -1;
            montab[3, 1] = -1;

            for (int  i=0;i<4;i++)
            {
                int dirX = montab[i, 0];
                int dirY = montab[i, 1];

                bool verif = true;
                int compteur = 1;

                while(verif==true)
                {

                    ConsoleColor maCouleur = lePlateau[maPosition.X, maPosition.Y].couleurPiece;
                    
                    if (maPosition.X + dirX*compteur > 7 || maPosition.X + dirX * compteur < 0)
                    {
                        verif = false;
                    }

                    if(maPosition.Y + dirY * compteur > 7 || maPosition.Y + dirY * compteur < 0)
                    {
                        verif = false;
                    }

                    if (lePlateau[maPosition.X + dirX * compteur, maPosition.Y + dirY * compteur].couleurPiece == maCouleur)
                    {
                        verif = false;
                    }
                   
                    if(maCouleur == ConsoleColor.Black && lePlateau[maPosition.X + dirX * (compteur), maPosition.Y + dirY * (compteur - 1)].couleurPiece == ConsoleColor.White ||
                       maCouleur == ConsoleColor.White && lePlateau[maPosition.X + dirX * (compteur), maPosition.Y + dirY * (compteur - 1)].couleurPiece == ConsoleColor.Black)
                    {
                        verif = false;
                    }

                    if(verif==true)
                    {
                        Coordonnee maCoo = new Coordonnee(maPosition.X + dirX * compteur, maPosition.Y + dirY * compteur);
                        result.Add(maCoo);
                    }

                    compteur++;
                }
            }

            return result;
            //return base.DeterminerPositionsValides(lePlateau, maPosition);

            
           
        }
    }
}
