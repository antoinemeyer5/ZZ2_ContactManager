﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    [Serializable]
    public class Dossier
    {
        public string Nom { get; set; }
        private DateTime DateDeCreation;
        private DateTime DateDeModification;
        private List<Contact> ListeDesContacts;
        public int ParentId { get; }
        public static int CompteurDossier;
        public int Id { get; }

        public Dossier(string n, int pi)
        {
            Nom = n;
            DateDeCreation = DateTime.Now;
            DateDeModification = DateDeCreation;
            ListeDesContacts = new List<Contact>();
            ParentId = pi; // root = 0
            CompteurDossier++;
            Id = CompteurDossier;
        }

        public void AjouterContact(Contact c)
        {
            ListeDesContacts.Add(c);
        }

        public void AfficherDossier()
        {
            string Resultat = String.Format(
                "[D] {0} (création {1}) - [Id:{2}][ParentId:{3}]",
                Nom, DateDeCreation, Id, ParentId);
            foreach (Contact contact in ListeDesContacts)
            {
                Resultat = Resultat + '\n';
                for (int i = 0; i < this.ParentId; i++)
                {
                    Resultat = Resultat + " ";
                }
                Resultat = Resultat + contact.AfficherContact();
            }
            Console.WriteLine(Resultat);
        }
    }
}
