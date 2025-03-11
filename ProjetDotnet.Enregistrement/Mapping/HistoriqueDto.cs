using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotnet.Enregistrement.Mapping
{
    public enum TypeOperation
    {
        RetraitEffectue,
        FactureCarteBleue,
        DepotGuichet
    }
    public class HistoriqueDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le montant est requis.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le montant doit être supérieur à 0.")]
        public decimal Montant { get; set; }

        [Required(ErrorMessage = "Le type d'opération est requis.")]
        public TypeOperation TypeOperation { get; set; }

        [Required(ErrorMessage = "La date de l'opération est requise.")]
        public DateTime DateOperation { get; set; }

        [Required(ErrorMessage = "La devise est requise.")]
        public string Devise { get; set; }

        private string _numeroCarteBancaire;

        [Required(ErrorMessage = "Le numéro de carte bancaire est requis.")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Le numéro de carte doit contenir 16 chiffres.")]
        public string NumeroCarteBancaire
        {
            get => _numeroCarteBancaire;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Le numéro de carte bancaire ne peut pas être vide.");
                }

                _numeroCarteBancaire = value.Replace(" ", "").Trim();

                if (!_numeroCarteBancaire.All(char.IsDigit))
                {
                    // exception
                }

                if (_numeroCarteBancaire.Length != 16)
                {
                    // exception
                }
            }
        }
    }
}
