using Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialisation
{
    public class SerialisationBinaire : IFactory
    {
        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Remove(0, 6);
        
        public void PrintSerialisation(string toTestToPrint)
        {
            Console.WriteLine("Seria. Binaire : " + toTestToPrint);
        }

        public void DoTheSerialisation(List<Dossier> listeDossiers)
        {
            BinaryFormatter bf = new BinaryFormatter();
            string pathToSave = "C:\\Users\\" + userName + "\\Documents\\ContactManager.binary";
            FileStream fsout = new FileStream(pathToSave, FileMode.Create, FileAccess.Write, FileShare.None);
            Console.WriteLine("Enregistrement du fichier '"+ pathToSave +"'");
            try
            {
                using (fsout)
                {
                    bf.Serialize(fsout, listeDossiers);
                    Console.WriteLine("Fichier '" + pathToSave + "' enregistré.");
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
            string pathToSave = "C:\\Users\\" + userName + "\\Documents\\ContactManager.binary";
            FileStream fsin = new FileStream(pathToSave, FileMode.Open, FileAccess.Read, FileShare.None);
            Console.WriteLine("Chargement du fichier '" + pathToSave + "'");
            try
            {
                using (fsin)
                {
                    response = (List<Dossier>)bf.Deserialize(fsin);
                    Console.WriteLine("Fichier '" + pathToSave + "' chargé.");
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
