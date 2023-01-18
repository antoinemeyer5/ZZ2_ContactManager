using Modele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialisation
{
    public class SerialisationBinaire : IFactory
    {
<<<<<<< HEAD
        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Remove(0, 6);
        
=======
>>>>>>> 21eb8362710ee8bd2cd9b428fb040a7614af29f2
        public void PrintSerialisation(string toTestToPrint)
        {
            Console.WriteLine("Seria. Binaire : " + toTestToPrint);
        }

        public void DoTheSerialisation(List<Dossier> listeDossiers)
        {
            BinaryFormatter bf = new BinaryFormatter();
<<<<<<< HEAD
            string pathToSave = "C:\\Users\\" + userName + "\\Documents\\ContactManager.binary";
            FileStream fsout = new FileStream(pathToSave, FileMode.Create, FileAccess.Write, FileShare.None);
            Console.WriteLine("Enregistrement du fichier '"+ pathToSave +"'");
=======
            FileStream fsout = new FileStream("ContactManager.binary", FileMode.Create, FileAccess.Write, FileShare.None);
            Console.WriteLine("Enregistrement du fichier 'C:\\Users\\[FIND-THE-PLACE]'...");
>>>>>>> 21eb8362710ee8bd2cd9b428fb040a7614af29f2
            try
            {
                using (fsout)
                {
                    bf.Serialize(fsout, listeDossiers);
<<<<<<< HEAD
                    Console.WriteLine("Fichier '" + pathToSave + "' enregistré.");
=======
                    Console.WriteLine("Fichier 'C:\\Users\\[FIND-THE-PLACE]' enregistré.");
>>>>>>> 21eb8362710ee8bd2cd9b428fb040a7614af29f2
                }
            }
            catch
            {
                Console.WriteLine("Une erreur s'est produite ...");
            }
        }

        public List<Dossier> UndoTheSerialisation()
        {
            List<Dossier> response = new List<Dossier>();
            BinaryFormatter bf = new BinaryFormatter();
<<<<<<< HEAD
            string pathToSave = "C:\\Users\\" + userName + "\\Documents\\ContactManager.binary";
            FileStream fsin = new FileStream(pathToSave, FileMode.Open, FileAccess.Read, FileShare.None);
            Console.WriteLine("Chargement du fichier '" + pathToSave + "'");
=======
            FileStream fsin = new FileStream("ContactManager.binary", FileMode.Open, FileAccess.Read, FileShare.None);
            Console.WriteLine("Chargement du fichier 'C:\\Users\\[FIND-THE-PLACE]'...");
>>>>>>> 21eb8362710ee8bd2cd9b428fb040a7614af29f2
            try
            {
                using (fsin)
                {
                    response = (List<Dossier>)bf.Deserialize(fsin);
<<<<<<< HEAD
                    Console.WriteLine("Fichier '" + pathToSave + "' chargé.");
=======
                    Console.WriteLine("Fichier 'C:\\Users\\[FIND-THE-PLACE]' chargé.");
>>>>>>> 21eb8362710ee8bd2cd9b428fb040a7614af29f2
                }
            }
            catch
            {
                Console.WriteLine("Une erreur s'est produite ...");
            }
            return response;
        }
    }

}
