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
        

        public ClientProfessionnel(int identifiant, string nom, string mail, string libelle_adresse, string complement_adresse,
            string codepostal, string ville, string siret, string statutJuridique)
               : base(identifiant, nom, mail, libelle_adresse, complement_adresse, codepostal, ville)

        {
            this.Siret = siret;
            this.StatutJuridique = statutJuridique;
            


            // Validation Siret
            if (siret.Length != 14 || !long.TryParse(siret, out _))
                throw new ClientsException(ClientsExceptionType.InvalidSiret);

        }

        public override void AfficherInfos()
        {
            Console.WriteLine($"ID: {Identifiant}, Nom: {Nom}, Mail: {Mail}");
            Console.WriteLine($"Siret: {Siret}, Statut Juridique: {StatutJuridique}");
            AfficherAdresse();
        }
    }
}
