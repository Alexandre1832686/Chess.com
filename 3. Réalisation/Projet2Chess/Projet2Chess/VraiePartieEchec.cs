using System;

namespace Projet2Chess
{
    class VraiePartieEchec : PartieEchecs
    {
        private object lesPieces;

        //places les pieces dans le tableu lesPieces
        public VraiePartieEchec()
        {
            //pieces autre que les pion (blanc)
            base.lesPieces = new Piece[8, 8];
            base.lesPieces[0, 0] = new VraieTour(ConsoleColor.White);
            base.lesPieces[1, 0] = new VraiCavalier(ConsoleColor.White);
            base.lesPieces[2, 0] = new VraiFou(ConsoleColor.White);
            base.lesPieces[3, 0] = new VraieReine(ConsoleColor.White);
            base.lesPieces[7, 0] = new VraieTour(ConsoleColor.White);
            base.lesPieces[6, 0] = new VraiCavalier(ConsoleColor.White);
            base.lesPieces[5, 0] = new VraiFou(ConsoleColor.White);
            base.lesPieces[4, 0] = new VraiRoi(ConsoleColor.White);

            //les pions avec leurs couleus
            for (int i = 0; i < 8; i++)
            {
                base.lesPieces[i, 1] = new VraiPion(ConsoleColor.White);
                base.lesPieces[i, 6] = new VraiPion(ConsoleColor.Black);
                base.lesPieces[i, 2] = new PieceVide();
                base.lesPieces[i, 3] = new PieceVide();
                base.lesPieces[i, 4] = new PieceVide();
                base.lesPieces[i, 5] = new PieceVide();
            }

            //pieces autre que les pion (noir)
            base.lesPieces[0, 7] = new VraieTour(ConsoleColor.Black);
            base.lesPieces[1, 7] = new VraiCavalier(ConsoleColor.Black);
            base.lesPieces[2, 7] = new VraiFou(ConsoleColor.Black);
            base.lesPieces[3, 7] = new VraieReine(ConsoleColor.Black);
            base.lesPieces[7, 7] = new VraieTour(ConsoleColor.Black);
            base.lesPieces[6, 7] = new VraiCavalier(ConsoleColor.Black);
            base.lesPieces[5, 7] = new VraiFou(ConsoleColor.Black);
            base.lesPieces[4, 7] = new VraiRoi(ConsoleColor.Black);
        }
    }
}
