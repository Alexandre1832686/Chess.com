using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet2Chess
{
    class VraieTour : Tour
    {
        public VraieTour(ConsoleColor laCouleur) : base(laCouleur)
        { }

        /***********************************************************************************************************
         * 
         * créer un tableau pour les directions possibles.
         * remplir le tableau
         * 
         * boucler sur le tableau des direction 
         * Cette boucle va me permettre de simplement changer les valeurs pour qu'elle vérifi toutes les directions spécifique àla case
         *      dans cette boucle on créer une nouvelle boucle jsuqu'à la sortie du board ou l'atteinte d'une piece pour confirmé que cette case est valide
         *      si la verification est vrai on ajoute la coordonnée a la liste.
         *      
         * 
         * revoyer la liste
         * 
         ***********************************************************************************************************/
        public override List<Coordonnee> DeterminerPositionsValides(Piece[,] lePlateau, Coordonnee maPosition)
        {
            //création de la liste pour les positions disponibles
            List<Coordonnee> result = new List<Coordonnee>();

            //instanciation des direction
            int[,] direction = new int[4, 2];
            direction[0, 0] = 1;
            direction[0, 1] = 0;

            direction[1, 0] = 0;
            direction[1, 1] = 1;

            direction[2, 0] = -1;
            direction[2, 1] = 0;

            direction[3, 0] = 0;
            direction[3, 1] = -1;

            //Boucle sur les 4 directions
            for (int i = 0; i < 4; i++)
            {
                int dirX = direction[i, 0];
                int dirY = direction[i, 1];

                bool verif = true;
                int compteur = 1;

                //récupère la couleur du pion
                ConsoleColor maCouleur = lePlateau[maPosition.X, maPosition.Y].couleurPiece;

                while (verif == true)
                {

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
                        if (lePlateau[maPosition.X + dirX * compteur, maPosition.Y + dirY * compteur].couleurPiece == maCouleur)
                        {
                            verif = false;
                        }

                        //Vérifi s'il peux manger un pion
                        if (maCouleur == ConsoleColor.Black && lePlateau[maPosition.X + dirX * (compteur), maPosition.Y + dirY * (compteur - 1)].couleurPiece == ConsoleColor.White ||
                           maCouleur == ConsoleColor.White && lePlateau[maPosition.X + dirX * (compteur), maPosition.Y + dirY * (compteur - 1)].couleurPiece == ConsoleColor.Black)
                        {
                            verif = false;
                        }


                        //ajoute la coordoné dans le tableau si elle est valide
                        if (verif == true)
                        {
                            Coordonnee maCoo = new Coordonnee(maPosition.X + dirX * compteur, maPosition.Y + dirY * compteur);
                            result.Add(maCoo);

                        }
                    }


                }

            }
            return result;
        }
    }
}
