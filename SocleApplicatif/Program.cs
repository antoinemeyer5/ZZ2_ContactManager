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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n- afficher : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Affiche la structure hiérarchique des dossiers.");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n- ajoutercontact :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  Crée et ajoute un contact dans la hiérarchie.");
            Console.WriteLine("  Paramètres : [string-1] [string-2] [string-3] [string-4] [string-5] ([int])");
            Console.WriteLine("  -> [string-1] = prénom du nouveau contact");
            Console.WriteLine("  -> [string-2] = nom du nouveau contact");
            Console.WriteLine("  -> [string-3] = société du nouveau contact");
            Console.WriteLine("  -> [string-4] = courriel du nouveau contact");
            Console.WriteLine("  -> [string-5] = lien du nouveau contact");
            Console.WriteLine("  -> ([int]), optionnel = dossier n°[int] en partant du dossier Root égal à 1; sinon dans le dossier courant (dernier dossier créé).");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n  Exemple 1 :");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  >ajoutercontact Antoine Meyer Isima antoine.meyer@etu.uca.fr Friend");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  Contact 'Antoine' ajouté sous Root en position 1");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  >afficher");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  [D] Root (création 27/12/2022 17:03:15)");
            Console.WriteLine("  | [C] Antoine, Meyer (Isima), Email: antoine.meyer@etu.uca.fr, Link:Friend");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n  Exemple 2 :");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  >afficher");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  [D] Root (création 27/11/2022 17:05:10)");
            Console.WriteLine("   [D] Documents(création 27/11/2022 17:05:15)");
            Console.WriteLine("   [D] Téléchargements(création 27/11/2022 17:05:30)");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  >ajoutercontact Antoine Meyer Isima antoine.meyer@etu.uca.fr Friend 2");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  Contact 'Antoine' ajouté sous Documents en position 1");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  >afficher");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  [D] Root (création 27/11/2022 17:05:10)");
            Console.WriteLine("   [D] Documents(création 27/11/2022 17:05:15)");
            Console.WriteLine("   | [C] Antoine, Meyer (Isima), Email: antoine.meyer@etu.uca.fr, Link:Friend");
            Console.WriteLine("   [D] Téléchargements(création 27/11/2022 17:05:30)");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n- ajouterdossier :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  Crée et ajoute un dossier dans la hiérarchie.");
            Console.WriteLine("  Paramètres : [string] ([int])");
            Console.WriteLine("  -> [string] = nom du nouveau dossier");
            Console.WriteLine("  -> ([int]), optionnel = dossier n°[int] en partant du dossier Root égal à 1; sinon dans le dossier courant (dernier dossier créé).");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n  Exemple 1 :");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  >ajouterdossier NomDuNewDossier");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  [D] Root (création 27/11/2022 17:05:10)");
            Console.WriteLine("   [D] NomDuNewDossier(création 27/11/2022 17:05:15)");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n  Exemple 2 :");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  >afficher");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  [D] Root (création 27/11/2022 17:05:10)");
            Console.WriteLine("   [D] Documents(création 27/11/2022 17:05:15)");
            Console.WriteLine("   [D] Téléchargements(création 27/11/2022 17:05:30)");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  >ajouterdossier NomDuNewDossier 2");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  [D] Root (création 27/11/2022 17:05:10)");
            Console.WriteLine("   [D] Documents(création 27/11/2022 17:05:15)");
            Console.WriteLine("    [D] NomDuNewDossier(création 27/11/2022 17:05:45)");
            Console.WriteLine("   [D] Téléchargements(création 27/11/2022 17:05:30)");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n- charger :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  Désérialise et charge une hiérarchie.");
            Console.WriteLine("  Paramètres : [string]");
            Console.WriteLine("  -> [string] = type de sérialisation au choix entre 'xml' et 'binaire'");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n- enregistrer :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  Sérialise et enregistrer la hiérarchie dans l'état courant.");
            Console.WriteLine("  Paramètres : [string]");
            Console.WriteLine("  -> [string] = type de sérialisation au choix entre 'xml' et 'binaire'");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n- help : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Affiche le manuel des commandes.");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n- sortir : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Ferme l'application.");
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

        private static int AjouterDossierDansStructureHierarchique(string[] input, List<Dossier> ListeDesDossiers, int IdDossierCourant)
        {
            if (input.Length == 2)
            {
                Dossier NouveauDossier = new Dossier(input[1], IdDossierCourant);
                ListeDesDossiers.Insert(IdDossierCourant, NouveauDossier);
                IdDossierCourant = NouveauDossier.Id;
                Console.WriteLine("Dossier '{0}' ajouté sous {1} en position {2}", input[1], ListeDesDossiers.Find(x => x.Id == NouveauDossier.ParentId).Nom, 1); 
            }
            else if (input.Length == 3)
            {
                int IdDossierDestination = -1;
                int.TryParse(input[2], out IdDossierDestination);
                if ((IdDossierDestination != 0) && (IdDossierDestination <= ListeDesDossiers.Count) && (0 < IdDossierDestination))
                {
                    Dossier NouveauDossier = new Dossier(input[1], ListeDesDossiers[IdDossierDestination - 1].Id);
                    IdDossierCourant = NouveauDossier.Id;
                    ListeDesDossiers.Insert(IdDossierDestination, NouveauDossier);
                    Console.WriteLine("Dossier '{0}' ajouté sous {1} en position {2}", input[1], ListeDesDossiers.Find(x => x.Id == NouveauDossier.ParentId).Nom, 1);
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
            return IdDossierCourant;
        }

        private static void AjouterContactDansStructureHierarchique(string[] input, List<Dossier> ListeDesDossiers, int IdDossierCourant)
        {
            if (input.Length == 6)
            {
                // verifie l'email
                if (RegexUtilities.IsValidEmail(input[4]))
                {
                    // met le contact dans le dossier courrant
                    Contact NouveauContact = new Contact(input[1], input[2], input[3], input[4], input[5]);
                    ListeDesDossiers[IdDossierCourant - 1].AjouterContact(NouveauContact);
                    Console.WriteLine("Contact '{0}' ajouté sous {1} en position {2}", input[1], ListeDesDossiers[IdDossierCourant - 1].Nom, 1);
                }
                else
                {
                    Console.WriteLine("Mauvaise utilisation : problème avec le 4ème paramètre : une adresse email valide est attendue; taper 'help' pour obtenir le manuel.");
                }
            }
            else if (input.Length == 7)
            {
                // verifie l'email
                if (RegexUtilities.IsValidEmail(input[4]))
                {
                    // met le contact dans le dossier choisi
                    int IdDossierDestination = -1;
                    int.TryParse(input[6], out IdDossierDestination);
                    if ((IdDossierDestination != 0) && (IdDossierDestination <= ListeDesDossiers.Count) && (0 < IdDossierDestination))
                    {
                        Contact NouveauContact = new Contact(input[1], input[2], input[3], input[4], input[5]);
                        ListeDesDossiers[IdDossierDestination - 1].AjouterContact(NouveauContact);
                        Console.WriteLine("Contact '{0}' ajouté sous {1} en position {2}", input[1], ListeDesDossiers[IdDossierDestination - 1].Nom, 1);
                    }
                    else
                    {
                        Console.WriteLine("Mauvaise utilisation : problème avec le 6ème paramètre; taper 'help' pour obtenir le manuel.");
                    }
                }
                else
                {
                    Console.WriteLine("Mauvaise utilisation : problème avec le 4ème paramètre : une adresse email valide est attendue; taper 'help' pour obtenir le manuel.");
                }
            }
            else
            {
                Console.WriteLine("Mauvaise utilisation : problèmes d'arguments; taper 'help' pour obtenir le manuel.");
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

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Taper 'help' pour obtenir le manuel.\n");
            Console.ForegroundColor = ConsoleColor.White;

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
                        if (input.Length == 2)
                        {
                            SerialisationFactory factory = new ConcreteSerialisationFactory();
                            IFactory serialisation_type;
                            switch (input[1])
                            {
                                case "xml":
                                    serialisation_type = factory.GetSerialisation("XML");
                                    Console.WriteLine("todo");
                                    break;
                                case "binaire":
                                    serialisation_type = factory.GetSerialisation("Binary");
                                    ListeDesDossiers = serialisation_type.UndoTheSerialisation();
                                    IdDossierCourant = 1;
                                    break;
                                default:
                                    Console.WriteLine("Méthode de chargement/désérialisation inconnue.");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Mauvaise utilisation : taper 'help' pour obtenir le manuel.");
                        }
                        break;
                    case "enregistrer":
                        if (input.Length == 2)
                        {
                            SerialisationFactory factory = new ConcreteSerialisationFactory();
                            // choose the serialisation type : XML or Binary
                            IFactory serialisation_type;
                            switch (input[1])
                            {
                                case "xml":
                                    serialisation_type = factory.GetSerialisation("XML");
                                    Console.WriteLine("todo");
                                    break;
                                case "binaire":
                                    serialisation_type = factory.GetSerialisation("Binary");
                                    serialisation_type.DoTheSerialisation(ListeDesDossiers);
                                    break;
                                default:
                                    Console.WriteLine("Méthode d'enregistrement/sérialisation inconnue.");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Mauvaise utilisation : taper 'help' pour obtenir le manuel.");
                        }
                        break;
                    case "ajouterdossier":
                        IdDossierCourant = AjouterDossierDansStructureHierarchique(input, ListeDesDossiers, IdDossierCourant);
                        break;
                    case "ajoutercontact":
                        AjouterContactDansStructureHierarchique(input, ListeDesDossiers, IdDossierCourant);
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
