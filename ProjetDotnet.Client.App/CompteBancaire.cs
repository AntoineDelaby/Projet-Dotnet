using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotnet.Client.App
{
    public class CompteBancaire
    {
        public string NuméroCompte { get; set; }
        public DateTime DateOuverture { get; set; }
        public decimal Solde { get; set; }

        public CompteBancaire(string numéroCompte)
        {
            this.NuméroCompte = numéroCompte;
            DateOuverture = DateTime.Now;
            Solde = 1000.00m; 
        }

        public void AfficherCompte()
        {
            Console.WriteLine($"Numéro de Compte: {NuméroCompte}, Ouvert le: {DateOuverture.ToShortDateString()}, Solde: {Solde}€");
        }

    }
}
