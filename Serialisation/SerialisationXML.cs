using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialisation
{
    public class SerialisationXML : IFactory
    {
        public void PrintSerialisation(string toTestToPrint)
        {
            Console.WriteLine("Seria. XML : " + toTestToPrint);
        }

        public void DoTheSerialisation(List<Dossier> listeDossiers)
        {
            /*
            Serialize object in XML format,
            For xml serialization use XmlSerializer instead of BinaryFormatter.
            XmlSerializer xs = new XmlSerializer(typeof(Employee));
            Change the filename from "employee.binary" to "employee.xml".
            and use[Xmlgnore] instead of[NonSerialized] in Employee class. The rest will be the same
            */

            XmlSerializer xs = new XmlSerializer(typeof(List<Dossier>));
            FileStream fsout = new FileStream("ContactManager.xml", FileMode.Create, FileAccess.Write, FileShare.None);
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
            XmlSerializer xs = new XmlSerializer(typeof(List<Dossier>));
            FileStream fsin = new FileStream("ContactManager.xml", FileMode.Open, FileAccess.Read, FileShare.None);
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
