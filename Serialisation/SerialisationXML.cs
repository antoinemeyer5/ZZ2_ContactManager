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
<<<<<<< HEAD

        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Remove(0, 6);

=======
>>>>>>> 21eb8362710ee8bd2cd9b428fb040a7614af29f2
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
<<<<<<< HEAD
            XmlSerializer xs = new XmlSerializer(typeof(List<Dossier>));
            string pathToSave = "C:\\Users\\" + userName + "\\Documents\\ContactManager.xml";
            FileStream fsout = new FileStream(pathToSave, FileMode.Create, FileAccess.Write, FileShare.None);
            Console.WriteLine("Enregistrement du fichier '" + pathToSave + "'");
=======

            XmlSerializer xs = new XmlSerializer(typeof(List<Dossier>));
            FileStream fsout = new FileStream("ContactManager.xml", FileMode.Create, FileAccess.Write, FileShare.None);
            Console.WriteLine("Enregistrement du fichier 'C:\\Users\\[FIND-THE-PLACE]'...");
>>>>>>> 21eb8362710ee8bd2cd9b428fb040a7614af29f2
            try
            {
                using (fsout)
                {
                    xs.Serialize(fsout, listeDossiers);
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
            XmlSerializer xs = new XmlSerializer(typeof(List<Dossier>));
<<<<<<< HEAD
            string pathToSave = "C:\\Users\\" + userName + "\\Documents\\ContactManager.xml";
            FileStream fsin = new FileStream(pathToSave, FileMode.Open, FileAccess.Read, FileShare.None);
            Console.WriteLine("Chargement du fichier '" + pathToSave + "'");
=======
            FileStream fsin = new FileStream("ContactManager.xml", FileMode.Open, FileAccess.Read, FileShare.None);
            Console.WriteLine("Chargement du fichier 'C:\\Users\\[FIND-THE-PLACE]'...");
>>>>>>> 21eb8362710ee8bd2cd9b428fb040a7614af29f2
            try
            {
                using (fsin)
                {
                    response = (List<Dossier>)xs.Deserialize(fsin);
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
