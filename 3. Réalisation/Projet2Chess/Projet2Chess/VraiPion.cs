using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Projet2Chess
{
    class VraiPion : Pion
    {
        public VraiPion(ConsoleColor laCouleur) : base(laCouleur)
        { }

        public override List<Coordonnee> DeterminerPositionsValides(Piece[,] lePlateau, Coordonnee maPosition)
        {
            List<Coordonnee> result = new List<Coordonnee>();
            ConsoleColor maCouleur = lePlateau[maPosition.X, maPosition.Y].couleurPiece;
            Coordonnee maCoord;
            //Si la postion +1 ou -1 est plus grand ou plus petit que les limitte du tableau 
            //if des blancs
            if (maPosition.Y + 1 < 8 && (lePlateau[maPosition.X, maPosition.Y + 1].couleurPiece != ConsoleColor.White
                || lePlateau[maPosition.X, maPosition.Y + 1].couleurPiece != ConsoleColor.Black) && maCouleur == ConsoleColor.White)
            {
                maCoord = new Coordonnee(maPosition.X, maPosition.Y + 1);
                result.Add(maCoord);
                // si la couleur du pions est égale a blanc && et que sa position est =  2, il peut avancer de 2 ou si sa couleur est égale a noire [...]position est = 7[...]  
                if (maPosition.Y == 1 && maCouleur == ConsoleColor.White)
                {
                    maCoord = new Coordonnee(maPosition.X, maPosition.Y + 2);
                    result.Add(maCoord);
                    maCoord = new Coordonnee(maPosition.X, maPosition.Y + 1);
                    result.Add(maCoord);
                }
                //MAnger un pions si la pièce a la postion x+1 et y+1
                if (maPosition.X != 7 && lePlateau[maPosition.X, maPosition.Y].couleurPiece == ConsoleColor.White && lePlateau[maPosition.X + 1, maPosition.Y + 1].couleurPiece == ConsoleColor.Black)
                {
                    maCoord = new Coordonnee(maPosition.X + 1, maPosition.Y + 1);
                    result.Add(maCoord);
                }
                //MAnger un pions si la pièce a la postion x-1 et y+1

                if (maPosition.X != 0 && lePlateau[maPosition.X, maPosition.Y].couleurPiece == ConsoleColor.White && lePlateau[maPosition.X - 1, maPosition.Y + 1].couleurPiece == ConsoleColor.Black)

                {
                    maCoord = new Coordonnee(maPosition.X - 1, maPosition.Y + 1);
                    result.Add(maCoord);
                }
            }
            //if des noir
            if (maPosition.Y - 1 > 0 && (lePlateau[maPosition.X, maPosition.Y - 1].couleurPiece != ConsoleColor.White
                || lePlateau[maPosition.X, maPosition.Y - 1].couleurPiece != ConsoleColor.Black) && maCouleur == ConsoleColor.Black)
            {
                maCoord = new Coordonnee(maPosition.X, maPosition.Y -1);
                result.Add(maCoord);
                if (maPosition.Y == 6 && maCouleur == ConsoleColor.Black)
                {
                    maCoord = new Coordonnee(maPosition.X, maPosition.Y - 2);
                    result.Add(maCoord);
                    maCoord = new Coordonnee(maPosition.X, maPosition.Y - 1);
                    result.Add(maCoord);
                }
                //MAnger un pions si la pièce a la postion x+1 et y-1

                if (maPosition.X != 7 && lePlateau[maPosition.X, maPosition.Y].couleurPiece == ConsoleColor.Black && lePlateau[maPosition.X + 1, maPosition.Y - 1].couleurPiece == ConsoleColor.White)
                {
                    maCoord = new Coordonnee(maPosition.X + 1, maPosition.Y - 1);
                    result.Add(maCoord);
                }
                //MAnger un pions si la pièce a la postion x-1 et y-1

                if (maPosition.X != 0 && lePlateau[maPosition.X, maPosition.Y].couleurPiece == ConsoleColor.Black && lePlateau[maPosition.X - 1, maPosition.Y - 1].couleurPiece == ConsoleColor.White)
                {
                    maCoord = new Coordonnee(maPosition.X - 1, maPosition.Y - 1);
                    result.Add(maCoord);
                }


            }



            //Vous pouvez utiliser la ligne qui suit pour vérifier le comportement attendu
            // return base.DeterminerPositionsValides(lePlateau, maPosition);
            return result;
        }
        //si on pouvait call la fonction voici comment on tranformerait le pions en reine ; si la position d'un pions est sur une limite y du tableau alors tranformer la pièce a sa positions en reine
        public void ChangerPiondEnReine(Coordonnee maPosition, Piece[,] lePlateau)
        {
            ConsoleColor maCouleur = lePlateau[maPosition.X, maPosition.Y].couleurPiece;

            //blanc 
            if (maPosition.Y == 7 && maCouleur == ConsoleColor.White)
            {
                VraieReine nouvelleReine = new VraieReine(ConsoleColor.White);
                lePlateau[maPosition.X, maPosition.Y] = nouvelleReine;
            }
            //noir
            if (maPosition.Y == 0 && maCouleur == ConsoleColor.Black)
            {
                VraieReine nouvelleReine = new VraieReine(ConsoleColor.Black);
                lePlateau[maPosition.X, maPosition.Y] = nouvelleReine;
            }
        }

    }
}
