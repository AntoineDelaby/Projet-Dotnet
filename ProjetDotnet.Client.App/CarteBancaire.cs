using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotnet.Client.App
{
    public class CarteBancaire
    {
        public string NumeroCarte { get; set; }
        public int Identifiant { get; set; }
        

        public CarteBancaire(string numeroCarte, int identifiant)
        {
            this.NumeroCarte = numeroCarte;
            this.Identifiant = identifiant;


        }

    }
}

