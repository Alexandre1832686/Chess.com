using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            ConsoleColor maCouleur= lePlateau[maPosition.X, maPosition.Y].couleurPiece;
            Coordonnee maCoord;
            // si la couleur du pions est égale a blanc && et que sa position est =  2, il peut avancer de 2 ou si sa couleur est égale a noire [...]position est = 7[...]  

            if (maPosition.Y==1 && maCouleur==ConsoleColor.White)
            {
                maCoord = new Coordonnee(maPosition.X, maPosition.Y+2);
                result.Add(maCoord); 
                maCoord = new Coordonnee(maPosition.X,maPosition.Y+1);
                result.Add(maCoord);
            }
            if (maPosition.Y == 6 && maCouleur == ConsoleColor.Black)
            {
                maCoord = new Coordonnee(maPosition.X, maPosition.Y - 2);
                result.Add(maCoord);
                maCoord = new Coordonnee(maPosition.X, maPosition.Y - 1);
                result.Add(maCoord);
            }
            //Si la postion +1 ou -1 est plus grand ou plus petit que les limitte du tableau 
          
            if((maPosition.Y+1<8 && maPosition.Y-1>0) && (maPosition.X + 1 < 8 && maPosition.X - 1 > 0) && (lePlateau[maPosition.X,maPosition.Y+1].couleurPiece != ConsoleColor.White  || lePlateau[maPosition.X,maPosition.Y+1].couleurPiece != ConsoleColor.Black))
            {
                maCoord = new Coordonnee(maPosition.X, maPosition.Y+1);
                result.Add(maCoord);
                //vérification manger blanc
                if (lePlateau[maPosition.X, maPosition.Y].couleurPiece== ConsoleColor.White && lePlateau[maPosition.X+1, maPosition.Y+1].couleurPiece == ConsoleColor.Black)
                {
                    maCoord = new Coordonnee(maPosition.X+1,maPosition.Y+1 );
                    result.Add(maCoord);
                }
                else if (lePlateau[maPosition.X, maPosition.Y].couleurPiece == ConsoleColor.White && lePlateau[maPosition.X - 1, maPosition.Y + 1].couleurPiece == ConsoleColor.Black)

                {
                    maCoord = new Coordonnee(maPosition.X - 1, maPosition.Y + 1);
                    result.Add(maCoord);
                }
                //noir
                if (lePlateau[maPosition.X, maPosition.Y].couleurPiece == ConsoleColor.Black && lePlateau[maPosition.X + 1, maPosition.Y - 1].couleurPiece == ConsoleColor.White)
                {
                    maCoord = new Coordonnee(maPosition.X + 1, maPosition.Y - 1);
                    result.Add(maCoord);
                }
                else if (lePlateau[maPosition.X, maPosition.Y].couleurPiece == ConsoleColor.White && lePlateau[maPosition.X - 1, maPosition.Y - 1].couleurPiece == ConsoleColor.White)

                {
                    maCoord = new Coordonnee(maPosition.X - 1, maPosition.Y - 1);
                    result.Add(maCoord);
                }
            }
            //MAnger un pions si la pièce a la postion x+1 et y+1
            

            

            return result;
        }

    }
}
