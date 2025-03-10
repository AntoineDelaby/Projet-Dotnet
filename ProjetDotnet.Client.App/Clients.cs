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

        public string Libelle_Adresse { get; set; }
        public string Complement_Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }


        public string Mail { get; set; }



        public Clients(int identifiant, string nom, string mail, string libelle_adresse,
            string complement_adresse, string codepostal, string ville)

        {
            this.Identifiant = identifiant;
            this.Nom = nom;
            this.Mail = mail;
            this.Libelle_Adresse = libelle_adresse;
            this.Complement_Adresse = complement_adresse;
            this.CodePostal = codepostal;
            this.Ville = ville;
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

        // Validation de l'adresse
        public void SetAdresse(string libelle_adresse, string complement_adresse, string codePostal, string ville)
        {
            if (libelle_adresse.Length == 0 || codePostal.Length != 5 || ville.Length == 0)
                throw new ClientsException(ClientsExceptionType.InvalidAdresse);

            this.Libelle_Adresse = libelle_adresse;
            this.Complement_Adresse = complement_adresse;
            this.CodePostal = codePostal;
            this.Ville = ville;
        }

        public abstract void AfficherInfos();
    

        public void AfficherAdresse()
        {
            Console.WriteLine($"Adresse : {Libelle_Adresse}, {Complement_Adresse}, {CodePostal} {Ville}");
        }
    }
}
