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

        public override List<Coordonnee> DeterminerPositionsValides(Piece[,] lePlateau, Coordonnee maPosition)
        {
            
            return base.DeterminerPositionsValides(lePlateau, maPosition);
        }
    }
}
