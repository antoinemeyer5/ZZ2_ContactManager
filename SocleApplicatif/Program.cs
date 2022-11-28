using Cryptage;
using Modele;
using Serialisation;
using System;
using System.Collections.Generic;

namespace SocleApplicatif
{
    public class Program
    {

        private static void AfficheMessagesErreurs()
        {
            // ordre alphabetique
            Console.WriteLine("Commandes possibles :");
            Console.WriteLine("\n- afficher :");
            Console.WriteLine("  Affiche la structure hiérarchique des dossiers.");

            Console.WriteLine("\n- ajoutercontact : TODO");

            Console.WriteLine("\n- ajouterdossier :");
            Console.WriteLine("  Crée et ajoute un dossier dans la hiérarchie.");
            Console.WriteLine("  Paramètres : [string] ([int])");
            Console.WriteLine("  -> [string] = nom du nouveau dossier");
            Console.WriteLine("  -> [int], optionnel = dossier n°[int] en partant du dossier Root; sinon dans le dossier courant (dernier dossier créé).");

            Console.WriteLine("\n  Exemple 1 :");
            Console.WriteLine("  >ajouterdossier NomDuNewDossier");
            Console.WriteLine("  [D] Root (création 27/11/2022 17:05:10)");
            Console.WriteLine("   [D] NomDuNewDossier(création 27/11/2022 17:05:10)");

            Console.WriteLine("\n  Exemple 2 :");
            Console.WriteLine("  >afficher");
            Console.WriteLine("  [D] Root (création 27/11/2022 17:05:10)");
            Console.WriteLine("   [D] Documents(création 27/11/2022 17:05:10)");
            Console.WriteLine("   [D] Téléchargements(création 27/11/2022 17:05:10)");
            Console.WriteLine("  >ajouterdossier NomDuNewDossier 2");
            Console.WriteLine("  [D] Root (création 27/11/2022 17:05:10)");
            Console.WriteLine("   [D] Documents(création 27/11/2022 17:05:10)");
            Console.WriteLine("    [D] NomDuNewDossier(création 27/11/2022 17:05:10)");
            Console.WriteLine("   [D] Téléchargements(création 27/11/2022 17:05:10)");

            Console.WriteLine("\n- charger : TODO");

            Console.WriteLine("\n- enregistrer : TODO");

            Console.WriteLine("\n- help :");
            Console.WriteLine("  Affiche le manuel des commandes.");

            Console.WriteLine("\n- sortir :");
            Console.WriteLine("  Ferme l'application.");
        }

        private static void AfficheStructureHierarchique(List<Dossier> ListeDesDossiers)
        {
            foreach (Dossier parent in ListeDesDossiers)
            {
                for (int i = 0; i < parent.ParentId; i++)
                {
                    Console.Write(" ");
                }
                parent.AfficherDossier();
            }
        }

        private static void AjouterDossierDansStructureHierarchique(string[] input, List<Dossier> ListeDesDossiers, int IdDossierCourant)
        {
            if (input.Length == 2)
            {
                Dossier NouveauDossier = new Dossier(input[1], ListeDesDossiers[IdDossierCourant - 1].Id);
                ListeDesDossiers.Insert(IdDossierCourant, NouveauDossier);
                Console.WriteLine("Dossier '{0}' ajouté sous {1} en position {2}", input[1], ListeDesDossiers[IdDossierCourant - 1].Nom, 1);
                IdDossierCourant = NouveauDossier.Id;
            }
            else if (input.Length == 3)
            {
                int IdDossierDestination = 0;
                int.TryParse(input[2], out IdDossierDestination);
                if ((IdDossierDestination != 0) && (IdDossierDestination <= ListeDesDossiers.Count) && (0 < IdDossierDestination))
                {
                    Dossier NouveauDossier = new Dossier(input[1], ListeDesDossiers[IdDossierDestination - 1].Id);
                    ListeDesDossiers.Insert(IdDossierDestination, NouveauDossier);
                    IdDossierCourant = NouveauDossier.Id;
                    Console.WriteLine("Dossier '{0}' ajouté sous {1} en position {2}", input[1], ListeDesDossiers[IdDossierDestination - 1].Nom, 1);
                }
                else
                {
                    Console.WriteLine("Mauvaise utilisation : problème avec le 2ème paramètre; taper 'help' pour obtenir le manuel.");
                }
            }
            else
            {
                Console.WriteLine("Mauvaise utilisation : taper 'help' pour obtenir le manuel.");
            }
        }

        static void Main(string[] args)
        {
            List<Dossier> ListeDesDossiers = new List<Dossier>();
            int IdDossierCourant = 1;
            Dossier root = new Dossier("Root", 0);
            ListeDesDossiers.Add(root);

            bool running = true;
            string[] input;

            SerialisationBinaire sb = new SerialisationBinaire();
            sb.yes();

            CryptageReversible cr = new CryptageReversible();
            cr.afficherChein();
            
            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(">");
                input = Console.ReadLine().Split(' ');
                Console.ForegroundColor = ConsoleColor.White;

                switch (input[0])
                {
                    case "sortir":
                        running = false;
                        break;
                    case "afficher":
                        AfficheStructureHierarchique(ListeDesDossiers);
                        break;
                    case "charger":
                        Console.WriteLine("TODO");
                        break;
                    case "enregistrer":
                        Console.WriteLine("TODO");
                        break;
                    case "ajouterdossier":
                        AjouterDossierDansStructureHierarchique(input, ListeDesDossiers, IdDossierCourant);
                        break;
                    case "ajoutercontact":
                        Console.WriteLine("TODO");
                        break;
                    case "help":
                        AfficheMessagesErreurs();
                        break;
                    default:
                        Console.WriteLine("Instruction inconnue : taper 'help' pour obtenir le manuel.");
                        break;
                }
            }


        }

        
    }
}
