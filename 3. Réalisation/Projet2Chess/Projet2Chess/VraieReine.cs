using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet2Chess
{
    class VraieReine : Reine
    {
        public VraieReine(ConsoleColor laCouleur) : base(laCouleur)
        { }

        public override List<Coordonnee> DeterminerPositionsValides(Piece[,] lePlateau, Coordonnee maPosition)
        {//création de la liste pour les positions disponibles
            List<Coordonnee> result = new List<Coordonnee>();

            //instanciation des direction
            int[,] direction = new int[8, 2];
            direction[0, 0] = 1;
            direction[0, 1] = 0;

            direction[1, 0] = 0;
            direction[1, 1] = 1;

            direction[2, 0] = -1;
            direction[2, 1] = 0;

            direction[3, 0] = 0;
            direction[3, 1] = -1;

            direction[4, 0] = 1;
            direction[4, 1] = 1;

            direction[5, 0] = 1;
            direction[5, 1] = -1;

            direction[6, 0] = -1;
            direction[6, 1] = -1;

            direction[7, 0] = -1;
            direction[7, 1] = 1;

            //Boucle sur les 4 directions
            for (int i = 0; i < 8; i++)
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

                        //ajoute la coordoné dans le tableau si elle est valide
                        if (verif == true)
                        {
                            Coordonnee maCoo = new Coordonnee(maPosition.X + dirX * compteur, maPosition.Y + dirY * compteur);
                            result.Add(maCoo);

                        }

                        //Vérifi s'il peux manger un pion
                        if (maCouleur == ConsoleColor.Black && lePlateau[maPosition.X + dirX * (compteur), maPosition.Y + dirY * (compteur)].couleurPiece == ConsoleColor.White ||
                           maCouleur == ConsoleColor.White && lePlateau[maPosition.X + dirX * (compteur), maPosition.Y + dirY * (compteur)].couleurPiece == ConsoleColor.Black)
                        {
                           

                            verif = false;
                        }


                        

                        
                    }
                    compteur++;

                }

            }
            return result;
        }

        public override string ToString()
        {
            return " \u2655 ";
        }
    }
}
