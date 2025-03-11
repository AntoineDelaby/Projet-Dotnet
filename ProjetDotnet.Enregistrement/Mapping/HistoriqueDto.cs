using ProjetDotnet.Generation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotnet.Enregistrement.Mapping
{

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
        public Devise Devise { get; set; }

        private string _numCarte;

        [Required(ErrorMessage = "Le numéro de carte bancaire est requis.")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Le numéro de carte doit contenir 16 chiffres.")]
        public string NumCarte
        {
            get => _numCarte;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Le numéro de carte bancaire ne peut pas être vide.");
                }

                _numCarte = value.Replace(" ", "").Trim();

                if (!_numCarte.All(char.IsDigit))
                {
                    // exception
                }

                if (_numCarte.Length != 16)
                {
                    // exception
                }
            }
        }
    }
}
