using System;

namespace Projet2Chess
{
    class Program
    {
        
        static PartieEchecs laPartie;

        static string nomJoueur1, nomJoueur2;

        static void Main(string[] args)
        {
            

            //Encodage pour les caractères spéciaux
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            InitialiserPartie();
            
            //Affiche le plateaux et fais jouer les joueurs
            while(true)
            {
                laPartie.AfficherPlateau();
                CoupJoueur1();
                laPartie.AfficherPlateau();
                CoupJoueur2();
            }
        }

        /// <summary>
        /// Fait jouer le joueur 1
        /// </summary>
        private static void CoupJoueur1()
        {
            CoupJoueur(ConsoleColor.White, nomJoueur1);
        }

        /// <summary>
        /// Fait jouer le joueur 2
        /// </summary>
        private static void CoupJoueur2()
        {
            CoupJoueur(ConsoleColor.Black, nomJoueur2);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="couleurJoueur"></param>
        /// <param name="nomJoueur"></param>
        private static void CoupJoueur(ConsoleColor couleurJoueur, string nomJoueur)
        {
            //
            Console.WriteLine("C'est le tour de " + nomJoueur + ", choisissez une pièce à bouger.");

           
            Coordonnee coordonneeDestination;

            //Vérifie si la pièce ou il veut jouer est disponible et si son déplacement est possible
            do
            {
                
                bool sourceValide = false;

                
                while (!sourceValide)
                {
                    Coordonnee coordonneeABouger = DemanderCoordonnees("Entrez la coordonnée de la pièce que vous voulez bouger : ");

                    sourceValide = laPartie.SelectionnerPieceEtAfficher(coordonneeABouger, couleurJoueur);
                }

                //demande au utilisateur de rentrer les coordonné ou il veut envoyer son pion 
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

        //lance la partie en créant un objet parti et en nommant les deux joueurs
        private static void InitialiserPartie()
        {
            //instanciation de l'objet VraiePartieEchec
            laPartie = new VraiePartieEchec();

            //lecture du nom du joueur 1
            Console.WriteLine("Quel est le nom du joueur 1?");
            nomJoueur1 = Console.ReadLine();

            //Lecture du nom de joueur 2
            Console.WriteLine("Quel est le nom du joueur 2?");
            nomJoueur2 = Console.ReadLine();
        }
    }
}
