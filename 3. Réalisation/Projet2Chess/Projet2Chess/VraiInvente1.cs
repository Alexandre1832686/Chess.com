using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet2Chess
{
    class vraiInvente1 // : Invente1
    {

        /*public vraiInvente1(ConsoleColor laCouleur) : base(laCouleur)
        { }
        */

        /***********************************************************************************************************
         * 
         *la piece qu'on a inventé est très simple mais ce n'est pas par débaras. on aurait très bien pu faire un cavalier
         *qui peut faire le mouvement du fou ca aurait été comme notre inventé deux mais avec les possibilités du fou au lieu de la tour.
         * 
         *on est concient que la verification qui se fait en initiant le board pourrait créer un echeque sur le roi puisqu'on joue avec des random... 
         *ca deveint compliquer à traité mais on trouvait le concept cool!
         *
         *on est concient que on peut gagner la partie au premier tour c'est ce qui rend la piece interessante.
         *
         *on est concient que la piece peut manger nos propre piece, c'est ce qui rend la piece encore plus interessante.
         *
         *
         *
         *
         *
         *on créer une liste de coordonée qui contiendra un seul coups mais qui sera random dans nimportequel case du tableau.
         *
         * 
         ***********************************************************************************************************/
        public /*override*/ List<Coordonnee> DeterminerPositionsValides(Piece[,] lePlateau, Coordonnee maPosition)
        {
            //création de la liste pour les positions disponibles
            List<Coordonnee> result = new List<Coordonnee>();

            //cree un rand
            Random rand = new Random();
            
            //ajoute la coordonee 
            Coordonnee maCoo = new Coordonnee(rand.Next(0,8), rand.Next(0, 8));
            result.Add(maCoo);
                      

            return result;
            //return base.DeterminerPositionsValides(lePlateau, maPosition);
        }
    }
}
