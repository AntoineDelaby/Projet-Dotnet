﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetDotnet.Server.Data
{
    public class HistoriqueErreur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NumCarte { get; set; }
        public decimal Montant { get; set; }
        public string TypeOperation { get; set; }
        public DateTime DateOperation { get; set; }
        public string Devise { get; set; }





        public HistoriqueErreur(int id, string numCarte, decimal montant, string typeOperation, DateTime dateOperation, string devise)

        {
            this.Id = id;
            this.NumCarte = numCarte;
            this.Montant = montant;
            this.TypeOperation = typeOperation;
            this.DateOperation = dateOperation;
            this.Devise = devise;
        }

        public HistoriqueErreur()
        {
        }



    }
}
