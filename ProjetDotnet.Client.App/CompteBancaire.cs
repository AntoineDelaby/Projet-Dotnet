using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotnet.Client.App
{
    public class CompteBancaire
    {
        public string NumeroCompte { get; set; }
        public DateTime DateOuverture { get; set; }
        public decimal Solde { get; set; }


        //public List<CarteBancaire> CartesBancaires { get; set; }


        public CompteBancaire(string numeroCompte, DateTime dateOuverture, decimal solde = 1000.00M)
        {
            this.NumeroCompte = numeroCompte;
            this.DateOuverture = dateOuverture;
            this.Solde = solde;
            //CartesBancaires = new List<CarteBancaire>();
        }


        // Ajout d'une carte bancaire au compte
        //public void AjouterCarteBancaire(CarteBancaire carte)
        //{
        //    CartesBancaires.Add(carte);
        //}



        public void AfficherCompte()
        {
            Console.WriteLine($"Numéro de Compte: {NumeroCompte}, Ouvert le: {DateOuverture.ToShortDateString()}, Solde: {Solde} €");
        }

    }
}
