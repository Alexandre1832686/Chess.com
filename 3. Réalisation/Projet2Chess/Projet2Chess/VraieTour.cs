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
         *      dans cette boucle on créer une nouvelle boucle jsuqua la sortie du board ou l'atteinte d'une piece pour confirmé que cette case est valide
         *      si la verification est vrai on ajoute la coordonnée a la liste.
         *      la vérification est en deux partie l première qui vérifie l'axe des x donc nous devons boucler sur les x
         *      ensuite nous bouclerons sur l'axe des y
         * 
         * revoyer la liste
         * 
         ***********************************************************************************************************/
        public override List<Coordonnee> DeterminerPositionsValides(Piece[,] lePlateau, Coordonnee maPosition)
        {
            //instanciation des direction
            int[,] direction = new int[4, 2];
            direction[0, 0] = 1;
            direction[0, 1] = 1;

            direction[1, 0] = 1;
            direction[1, 1] = -1;

            direction[2, 0] = -1;
            direction[2, 1] = 1;

            direction[3, 0] = -1;
            direction[3, 1] = -1;

            //Boucle sur les 4 directions
            for (int i = 0; i < 4; i++)
            {
                int dirX = direction[i, 0];
                int dirY = direction[i, 1];

                bool verif = true;
                int compteur = 1;

                //verification pour ne pas que le pions ne dépasse pas les limites du tableau
                if (maPosition.X + dirX * compteur > 7 || maPosition.X + dirX * compteur < 0)
                {
                    verif = false;
                }

                if (maPosition.Y + dirY * compteur > 7 || maPosition.Y + dirY * compteur < 0)
                {
                    verif = false;
                }

                while (verif == true)
                {
                    


                    if (verif == true)
                    {
                        Coordonnee maCoo = new Coordonnee(maPosition.X + dirX * compteur, maPosition.Y + dirY * compteur);
                        //result.Add(maCoo);
                    }

                    compteur++;
                }


            }


                return base.DeterminerPositionsValides(lePlateau, maPosition);
        }
    }
}
