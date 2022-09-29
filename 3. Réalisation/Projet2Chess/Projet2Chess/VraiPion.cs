using System;
using System.Collections.Generic;
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

            //throw new NotImplementedException();
            //Vous pouvez utiliser la ligne qui suit pour vérifier le comportement attendu
            // return base.DeterminerPositionsValides(lePlateau, maPosition);
            return result;
        }

    }
}
