using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptage
{
    public class CryptageReversible
    {
        private string NoN;

        public CryptageReversible()
        {
            NoN = "petit chien";
        } 

        public void afficherChein()
        {
            Console.WriteLine("Oui, !!: " + NoN);
        }
    }
}
