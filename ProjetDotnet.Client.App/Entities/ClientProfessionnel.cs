using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ProjetDotnet.Client.App
{
    public class ClientProfessionnel : Clients
    {
        public string Siret { get; set; }
        public string StatutJuridique { get; set; }
        public string Libelle_AdresseSiege { get; set; }
        public string Complement_AdresseSiege { get; set; }
        public string Codepostal_Siege { get; set; }
        public string Ville_Siege { get; set; }
        
        public ClientProfessionnel() { }
        public ClientProfessionnel(int identifiant, string nom, string mail, string libelle_adresse, string complement_adresse,
            string codepostal, string ville, string siret, string statutJuridique, string libelle_adressesiege, string complement_adressesiege,
            string codepostal_siege, string ville_siege)
               : base(identifiant, nom, mail, libelle_adresse, complement_adresse, codepostal, ville)

        {
            Siret = siret;
            StatutJuridique = statutJuridique;
            Libelle_AdresseSiege = libelle_adressesiege;
            Complement_AdresseSiege = complement_adressesiege;
            Codepostal_Siege = codepostal_siege;
            Ville_Siege = ville_siege;




            // Validation Siret
            if (siret.Length != 14 || !long.TryParse(siret, out _))
                throw new ClientsException(ClientsExceptionType.InvalidSiret);

        }

     
    }
}
