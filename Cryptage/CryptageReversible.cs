using Modele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptage
{
    public class CryptageReversible
    {
        public void CryptageSerialisation(List<Dossier> listeDossiers, byte[] key)
        {
            // user name
            String[]        userName    = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\');
            // db formated name
            String          fileName    = "cryptaSeri_" + userName[1] + ".dat";
            // open a stream
            FileStream      fsout       = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName), FileMode.Create);
            BinaryFormatter bf          = new BinaryFormatter();
            // write in the file
            try
            {
                // cryptage when write in the stream
                AesCryptoServiceProvider AES = new AesCryptoServiceProvider();
                AES.Key = SHA256Managed.Create().ComputeHash(key);
                AES.IV = MD5.Create().ComputeHash(key);
                // save
                using (CryptoStream cryptStream = new CryptoStream(fsout, AES.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    // try to read
                    bf.Serialize(cryptStream, listeDossiers);
                }
                Console.WriteLine("Fichier '" + fileName + "' chiffré et enregistré.");
            }
            // exception when write
            catch (Exception e)
            {
                Console.WriteLine("Une erreur s'est produite ... Details: " + e.Message);
                throw;
            }
            finally
            {
                // close file
                fsout.Close();
            }
        }

        public List<Dossier> DecryptionSerialisation(byte[] key)
        {
            List<Dossier> response = new List<Dossier>();
            // user name
            String[] userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\');
            // db formated name
            String fileName = "cryptaSeri_" + userName[1] + ".dat";
            // open a stream
            FileStream fsout = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName), FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                // try to open a file
                using (FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName), FileMode.Open))
                {
                    // try to decryption
                    AesCryptoServiceProvider AES = new AesCryptoServiceProvider();
                    AES.Key = SHA256Managed.Create().ComputeHash(key);
                    AES.IV = MD5.Create().ComputeHash(key);
                    using (CryptoStream cs = new CryptoStream(fsout, AES.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        // try to read file
                        response = bf.Deserialize(cs) as List<Dossier>;
                    }
                    Console.WriteLine("Fichier '" + fileName + "' déchiffré et chargé.");
                }
            }
            // file not existing
            catch (FileNotFoundException)
            {
                Console.WriteLine("Fichier inconnu ou corrompu.");
            }
            // bad key
            catch (CryptographicException)
            {
                Console.WriteLine("Mauvaise clé de déchiffrage");
            }
            // others
            catch (Exception e)
            {
                Console.WriteLine("Une erreur s'est produite ... Details: " + e.Message);
                throw;
            }
            return response;
        }


    }

    
}
