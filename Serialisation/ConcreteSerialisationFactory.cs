using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialisation
{
    public class ConcreteSerialisationFactory : SerialisationFactory
    {
        public override IFactory GetSerialisation(string SerialisationName)
        {
            switch (SerialisationName)
            {
                case "Binary":
                    return new SerialisationBinaire();
                case "XML":
                    return new SerialisationXML();
                default:
                    throw new ApplicationException(string.Format("Serialisation {0} ne peut pas être créée", SerialisationName));
            }
        }
    }
}
