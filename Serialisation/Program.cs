using SocleApplicatif;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialisation
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Contact c = new Contact("", null, "", null, null);
            c.AfficherContact();
            Console.WriteLine("");
        }
    }
}
