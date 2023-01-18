using Modele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialisation
{
    public class SerialisationXML : IFactory
    {

        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Remove(0, 6);


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
            string pathToSave = "C:\\Users\\" + userName + "\\Documents\\ContactManager.xml";
            FileStream fsout = new FileStream(pathToSave, FileMode.Create, FileAccess.Write, FileShare.None);
            Console.WriteLine("Enregistrement du fichier '" + pathToSave + "'");
            try
            {
                using (fsout)
                {
                    xs.Serialize(fsout, listeDossiers);
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
            XmlSerializer xs = new XmlSerializer(typeof(List<Dossier>));
            string pathToSave = "C:\\Users\\" + userName + "\\Documents\\ContactManager.xml";
            FileStream fsin = new FileStream(pathToSave, FileMode.Open, FileAccess.Read, FileShare.None);
            Console.WriteLine("Chargement du fichier '" + pathToSave + "'");
            try
            {
                using (fsin)
                {
                    response = (List<Dossier>)xs.Deserialize(fsin);
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
