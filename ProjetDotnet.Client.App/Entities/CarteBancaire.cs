using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotnet.Client.App
{
    public class CarteBancaire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Identifiant { get; set; }
        public string NumeroCarte { get; set; }
        
        
        public CarteBancaire() { }
        public CarteBancaire(string numeroCarte, int identifiant)
        {   
            NumeroCarte = numeroCarte;
            Identifiant = identifiant;


        }

    }
}

