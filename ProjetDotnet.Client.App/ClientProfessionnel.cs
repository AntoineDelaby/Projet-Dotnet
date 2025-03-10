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
        public string AdresseDuSiège { get; set; }





        public ClientProfessionnel(int identifiant, string nom, string mail, string adressepostal, string siret, string statutJuridique, string adresseDuSiège)
               : base(identifiant, nom, adressepostal, mail)

        {
            this.Siret = siret;
            this.StatutJuridique = statutJuridique;
            this.AdresseDuSiège = adresseDuSiège;


            // Validation Siret
            if (siret.Length != 14 || !long.TryParse(siret, out _))
                throw new ClientsException(ClientsExceptionType.InvalidSiret);

        }

        public override void AfficherInfos()
        {
            Console.WriteLine($"ID: {Identifiant}, Nom: {Nom}, Mail: {Mail}");
            Console.WriteLine($"Siret: {Siret}, Statut Juridique: {StatutJuridique},Adresse du Siège: {AdresseDuSiège}");
        }
    }
}
