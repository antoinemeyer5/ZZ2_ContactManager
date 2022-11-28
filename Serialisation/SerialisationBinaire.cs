using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialisation
{
    public class SerialisationBinaire
    {
        private string oui;
        public SerialisationBinaire()
        {
            oui = "salut";
        }

        public void yes()
        {
            Console.WriteLine(oui + " : super !");
        }
    }
}
