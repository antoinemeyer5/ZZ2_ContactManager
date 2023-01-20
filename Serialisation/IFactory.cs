using Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialisation
{
    public interface IFactory
    {
        void PrintSerialisation(string toTestToPrint);

        void DoTheSerialisation(List<Dossier> listeDossiers);

        List<Dossier> UndoTheSerialisation();
    }
}
