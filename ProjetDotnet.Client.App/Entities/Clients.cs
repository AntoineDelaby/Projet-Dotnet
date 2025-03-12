using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotnet.Client.App
{
    public abstract class Clients
    {
        
        private string nom;
        private string mail;


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Identifiant { get; set; }
        public string Libelle_Adresse { get; set; }
        public string Complement_Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }



        // Valider le nom (50 char)
        public string Nom
        {
            get { return nom; }
            set
            {

                if (value.Length > 50)
                {
                    throw new ClientsException(ClientsExceptionType.InvalidNom);
                }

                nom = value;
            }
        }

        // Valider le mail (doit contenir @)
        public string Mail
        {
            get { return mail; }
            set
            {

                if (!value.Contains("@"))
                {
                    throw new ClientsException(ClientsExceptionType.InvalidMail);
                }

                mail = value;
            }
        }
        public Clients() { }


        public Clients(int identifiant, string nom, string mail, string libelle_adresse,
            string complement_adresse, string codepostal, string ville)

        {
            Identifiant = identifiant;
            Mail = mail;
            Nom = nom;
            Libelle_Adresse = libelle_adresse;
            Complement_Adresse = complement_adresse;
            CodePostal = codepostal;
            Ville = ville;
        }

    } 
}

       


       

