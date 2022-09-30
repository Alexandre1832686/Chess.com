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
        {
            //throw new NotImplementedException();
            //Vous pouvez utiliser la ligne qui suit pour vérifier le comportement attendu
            return base.DeterminerPositionsValides(lePlateau, maPosition);
        }

        public override string ToString()
        {
            return " \u2655 ";
        }
    }
}
