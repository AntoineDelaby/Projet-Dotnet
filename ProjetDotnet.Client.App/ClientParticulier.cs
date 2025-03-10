using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
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

        public ClientParticulier(int identifiant, string nom, string mail, string prénom,
            ESexe sexe, string libelle_adresse, string complement_adresse, string codepostal, string ville, DateTime dateDeNaissance)
        : base(identifiant, nom, mail, libelle_adresse,complement_adresse, codepostal, ville)

        {
            this.Prénom = prénom;
            this.Sexe = sexe;
            this.DateDeNaissance = dateDeNaissance;


            // Validation du Prenom et Sexe
            if (prénom.Length > 50)
                throw new ClientsException(ClientsExceptionType.InvalidPrénom);
            if (sexe is not (ESexe)'M' and not (ESexe)'F')
                throw new ClientsException(ClientsExceptionType.InvalidSex);

        }

        public override void AfficherInfos()
        {
            Console.WriteLine($"ID: {Identifiant}, Nom: {Nom}, Mail: {Mail}");

            Console.WriteLine($"Client Particulier: {Nom} {Prénom}, Sexe: {Sexe}, Date de Naissance: {DateDeNaissance.ToShortDateString()}");
            AfficherAdresse();
        }
    }
}

