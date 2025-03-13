using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotnet.Client.App.Entities
{
    public class CompteBancaire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public DateTime DateOuverture { get; set; }
        public decimal Solde { get; set; }
        public int ClientId { get; set; }
        public ICollection<CarteBancaire> CarteBancaires { get; set; }
        public virtual Clients Client { get; set; }

        public CompteBancaire()
        {
            
        }

    }
}
