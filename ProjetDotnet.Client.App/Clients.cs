using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotnet.Client.App
{
    public abstract class Clients
    {
        public int Identifiant { get; set; }
        public string Nom { get; set; }

        public string AdressePostal { get; set; }

        public string Mail { get; set; }



        public Clients(int identifiant, string nom, string adressepostal, string mail)

        {
            this.Identifiant = identifiant;
            this.Nom = nom;
            this.AdressePostal = adressepostal;
            this.Mail = mail;

        }





        // Valider le nom (50 char)
        public void SetNom(string nom)
        {
            if (nom.Length > 50)
                throw new ClientsException(ClientsExceptionType.InvalidName);
            this.Nom = nom;
        }


        // Valider le mail (doit contenir @)

        public void SetMail(string mail)
        {

            if (!mail.Contains("@"))
                throw new ClientsException(ClientsExceptionType.InvalidMail);
            this.Mail = mail;
        }



        public abstract void AfficherInfos();
    }


}
