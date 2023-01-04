using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialisation
{
    public abstract class SerialisationFactory
    {
        public abstract IFactory GetSerialisation(string SerialisationName);
    }
}
