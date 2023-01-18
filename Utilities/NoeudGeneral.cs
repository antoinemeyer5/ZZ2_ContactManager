using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class NoeudGeneral
    {
        public string Nom { get; set; }
        public DateTime DateDeCreation;
        public DateTime DateDeModification;
        public static int CompteurDossier;
        public int Id { get; set; }
        public int ParentId { get; set; }

        public NoeudGeneral()
        {
            Nom = "void";
            DateDeCreation = DateTime.Now;
            DateDeModification = DateDeCreation;
            CompteurDossier++;
            Id = CompteurDossier;
            ParentId = 0; // root = 0
        }

        public NoeudGeneral(string n)
        {
            Nom = n;
            DateDeCreation = DateTime.Now;
            DateDeModification = DateDeCreation;
            CompteurDossier++;
            Id = CompteurDossier;
            ParentId = -1; // root = 0
        }

        public NoeudGeneral(string n, int pi)
        {
            Nom = n;
            DateDeCreation = DateTime.Now;
            DateDeModification = DateDeCreation;
            CompteurDossier++;
            Id = CompteurDossier;
            ParentId = pi; // root = 0
        }

    }
}
