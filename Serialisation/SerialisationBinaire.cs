using Modele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialisation
{
    public class SerialisationBinaire : IFactory
    {
        public void PrintSerialisation(string toTestToPrint)
        {
            Console.WriteLine("Seria. Binaire : " + toTestToPrint);
        }

        public void DoTheSerialisation(List<Dossier> listeDossiers)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsout = new FileStream("ContactManager.binary", FileMode.Create, FileAccess.Write, FileShare.None);
            Console.WriteLine("Enregistrement du fichier 'C:\\Users\\[FIND-THE-PLACE]'...");
            try
            {
                using (fsout)
                {
                    bf.Serialize(fsout, listeDossiers);
                    Console.WriteLine("Fichier 'C:\\Users\\[FIND-THE-PLACE]' enregistré.");
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
            FileStream fsin = new FileStream("ContactManager.binary", FileMode.Open, FileAccess.Read, FileShare.None);
            Console.WriteLine("Chargement du fichier 'C:\\Users\\[FIND-THE-PLACE]'...");
            try
            {
                using (fsin)
                {
                    response = (List<Dossier>)bf.Deserialize(fsin);
                    Console.WriteLine("Fichier 'C:\\Users\\[FIND-THE-PLACE]' chargé.");
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
