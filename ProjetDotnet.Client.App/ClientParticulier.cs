using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProjetDotnet.Client.App
{
    public enum ESexe {F,M};

    public class ClientParticulier : Clients
    {
        public string Prénom { get; set; }

        public ESexe Sexe { get; set; }

        public DateTime DateDeNaissance { get; set; }

        public ClientParticulier(int identifiant, string nom, string mail, string adressepostal, string prénom, ESexe sexe, DateTime dateDeNaissance)
        : base(identifiant, nom, adressepostal, mail)

        {
            this.Prénom = prénom;
            this.Sexe = sexe;
            this.DateDeNaissance = dateDeNaissance;


            // Validation du Prenoet Sexe
            if (prénom.Length > 50)
                throw new ClientsException(ClientsExceptionType.InvalidPrénom);
            if (sexe != "M" && sexe != "F")
                throw new ClientsException(ClientsExceptionType.InvalidSex);

        }

        public override void AfficherInfos()
        {
            Console.WriteLine($"ID: {Identifiant}, Nom: {Nom}, Mail: {Mail}");

            Console.WriteLine($"Client Particulier: {Nom} {Prénom}, Sexe: {Sexe}, Date de Naissance: {DateDeNaissance.ToShortDateString()}");
        }
    }
}

