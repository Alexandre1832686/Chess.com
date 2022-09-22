using System;

namespace Projet2Chess
{
    class Program
    {
        static PartieEchecs laPartie;

        static string nomJoueur1, nomJoueur2;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            InitialiserPartie();
            
            while(true)
            {
                laPartie.AfficherPlateau();
                CoupJoueur1();
                laPartie.AfficherPlateau();
                CoupJoueur2();
            }
        }

        private static void CoupJoueur1()
        {
            CoupJoueur(ConsoleColor.White, nomJoueur1);
        }

        private static void CoupJoueur2()
        {
            CoupJoueur(ConsoleColor.Black, nomJoueur2);
        }

        private static void CoupJoueur(ConsoleColor couleurJoueur, string nomJoueur)
        {
            Console.WriteLine("C'est le tour de " + nomJoueur + ", choisissez une pièce à bouger.");
            Coordonnee coordonneeDestination;

            do
            {
                bool sourceValide = false;

                while (!sourceValide)
                {
                    Coordonnee coordonneeABouger = DemanderCoordonnees("Entrez la coordonnée de la pièce que vous voulez bouger : ");

                    sourceValide = laPartie.SelectionnerPieceEtAfficher(coordonneeABouger, couleurJoueur);
                }

                coordonneeDestination = DemanderCoordonnees("Entrez la coordonnée de destination : ");

            } while (!laPartie.EntrerDestinationEtConfirmer(coordonneeDestination, couleurJoueur));
        }

        private static Coordonnee DemanderCoordonnees(string messageAAfficher)
        {
            throw new NotImplementedException();
        }

        private static Coordonnee DecortiquerCoordonnee(string coordonneeADecortiquer)
        {
            throw new NotImplementedException();
        }

        private static void InitialiserPartie()
        {
            laPartie = new VraiePartieEchec();

            Console.WriteLine("Quel est le nom du joueur 1?");
            nomJoueur1 = Console.ReadLine();

            Console.WriteLine("Quel est le nom du joueur 2?");
            nomJoueur2 = Console.ReadLine();
        }
    }
}
