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

        /*
         * 
         * on recoit une string qui est le message d'affichage
         * on l'affiche et prend une lecture de ligne console
         * on prend cette lecture et prend le premier et deuxieme charactère de celle-ci
         * on prend le premier charactère et on transform le charactère en chiffre ex: 1=A 2=B etc...
         * ensuite on créer une coordoné on attribue la valeur x et y a la coordonée et on la renvoie.
         * 
         */
        private static Coordonnee DemanderCoordonnees(string messageAAfficher)
        {
            int x = 0;

            int y = 0;

            Console.WriteLine(messageAAfficher);

            string reponse = Console.ReadLine().ToLower();

            //verification

            return DecortiquerCoordonnee(reponse);

        }

        /*
         *Recoit un string veux prendre le premier charactère et transformer le charactère en chiffre ex: 1=A 2=B etc...
         *ensuite on créer une coordoné on attribue le premier et deuxieme charactère a la coordonée et on la renvoie.
         *
         */
        private static Coordonnee DecortiquerCoordonnee(string coordonneeADecortiquer)
        {
            int x = 0;
            int y = 0;

            string coordonneeADecortiquerX = coordonneeADecortiquer.Substring(0, 1);

            string coordonneeADecortiquerY = coordonneeADecortiquer.Substring(1, 1);

            y = Convert.ToInt32(coordonneeADecortiquerY);
                
            switch (coordonneeADecortiquerX)
            {
                case "a":
                    x = 0;
                    break;

                case "b":
                    x = 1;
                    break;

                case "c":
                    x = 2;
                    break;

                case "d":
                    x = 3;
                    break;

                case "e":
                    x = 4;
                    break;

                case "f":
                    x = 5;
                    break;

                case "g":
                    x = 6;
                    break;

                case "h":
                    x = 7;
                    break;

                default:
                    break;
            }

        return new Coordonnee(x, y);
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
