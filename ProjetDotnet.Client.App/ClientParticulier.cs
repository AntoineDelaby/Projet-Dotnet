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
    public enum ESexe { F, M };



    public class ClientParticulier : Clients
    {
        private ESexe sexe;

        private string prenom;

        public DateTime DateDeNaissance { get; set; }

        public ESexe Sexe
        {
            get { return sexe; }
            set
            {
                if (sexe is not (ESexe)'M' and not (ESexe)'F')
                {
                    throw new ClientsException(ClientsExceptionType.InvalidSex);
                }


                sexe = value;
            }
        }

        // Valider le Prenom (50 char)
        public string Prenom
        {
            get { return prenom; }
            set
            {
                prenom = value;
                if (prenom.Length > 50)
                {
                    throw new ClientsException(ClientsExceptionType.InvalidNom);
                }

                prenom = value;

            }
        }


        public ClientParticulier(int identifiant, string nom, string mail, string libelle_adresse, string complement_adresse,
            string codePostal, string ville, string prenom, ESexe sexe, DateTime dateDeNaissance)
            : base(identifiant, nom, mail, libelle_adresse, complement_adresse, codePostal, ville)



        {
            this.Prenom = prenom;
            this.Sexe = sexe;
            this.DateDeNaissance = dateDeNaissance;


        }

        public override void AfficherInfos()
        {
            Console.WriteLine($"ID: {Identifiant}, Nom: {Nom}, Mail: {Mail}");

            Console.WriteLine($"Client Particulier: {Nom} {Prenom}, Sexe: {Sexe}, Date de Naissance: {DateDeNaissance.ToShortDateString()}");
            AfficherAdresse();
        }
    }
}

