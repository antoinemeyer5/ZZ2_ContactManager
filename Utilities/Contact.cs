using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    [Serializable]
    public class Contact
    {
        private string Nom;
        private string Prenom;
        private string Courriel;
        private string Societe;
        private string Lien;
        private DateTime DateDeCreation;
        private DateTime DateDeModification;
        private enum EnumerationLien
        {
            Friend,
            Colleague,
            Relationship,
            Network,
            Other
        }

        public Contact(string p, string n, string s, string c, string l)
        {
            Prenom = p;
            Societe = s;
            Courriel = c;
            if ( Enum.IsDefined(typeof(EnumerationLien), l) )
            {
                Lien = l;
            }
            else
            {
                Lien = "Other";
            }
            DateDeCreation = DateTime.Now;
            DateDeModification = DateDeCreation;
        }

        public string AfficherContact()
        {
            string Resultat = String.Format(
                "| [C] {0}, {1} ({2}), Email:{3}, Link:{4}",
                Prenom, Nom, Societe, Courriel, Lien);
            return Resultat;
        }

        public void AfficherCompletementContact()
        {
            string Resultat = String.Format(
                "[C] {0}, {1} ({2}), Email:{3}, Link:{4}, DateCrea:{5}, DateModi:{6}",
                Prenom, Nom, Societe, Courriel, Lien, DateDeCreation, DateDeModification);
            Console.WriteLine(Resultat);
        }
    }
}
