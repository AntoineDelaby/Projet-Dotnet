using AutoMapper;
using ProjetDotnet.Enregistrement;
using ProjetDotnet.Enregistrement.Mapping;
using ProjetDotnet.Server.Data;
using ProjetDotnet.Server.Data.Repositories;
using System.Linq;

namespace ProjetDotnet.Server.API.Services
{
    public class HistoriqueService
    {
        private readonly HistoriqueRepository _repo;
        private readonly HistoriqueErreurRepository _repoErreur;
        private readonly IMapper _mapper;

        public HistoriqueService()
        {
            _repo = new HistoriqueRepository();
            _repoErreur = new HistoriqueErreurRepository();
            _mapper = MappingConfig.Mapper;
        }
        public bool IsValidCardNumber(string cardNumber)
        {
            // Verification que cardNumber n'est pas null
            if (string.IsNullOrWhiteSpace(cardNumber))
                return false;

            // Verification que cardNumber n'a que des chiffres
            cardNumber = cardNumber.Replace(" ", "");
            if (!cardNumber.All(char.IsDigit))
                return false;

            // Calcul luhn
            int sum = 0;
            // Permet de definir si c'est pair ou non, si c'est impair, ca veut dire qu'on mutliplie par 2
            bool alternate = false;
            int digit = 0;
            for(int i = cardNumber.Length-1;i >= 0; i--)
            {
                digit = cardNumber[i] - '0';

                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit -= 9;
                }

                sum += digit;
                // on passe de pair/impair à impair/pair
                alternate = !alternate;
            }

            // Si la somme est un multiple de 10 alors c'est bon
            return (sum % 10 == 0);
        }
        
        // Récupère l'historique des enregistrements
        public async Task<List<HistoriqueDto>> GetHistorique()
        {
            var histEntities = await _repo.GetAll();
            var histDto = histEntities.Select(hist => _mapper.Map<HistoriqueDto>(hist)).ToList<HistoriqueDto>();

            return histDto;
        }

        // Récupère un enregistrement historisé via son ID
        public async Task<HistoriqueDto> GetHistoriqueById(int id)
        {
            var histEntity = await _repo.GetById(id);
            var histDto = _mapper.Map<HistoriqueDto>(histEntity);

            return histDto;
        }

        // Ajoute un nouvel enregistrement historisé s'il est validé
        public async Task<int> InsertHistorique(HistoriqueDto historique)
        {
            var insertResult = -1;
            if(IsValidCardNumber(historique.NumeroCarteBancaire))
            {
                insertResult = await _repo.InsertHistorique(_mapper.Map<Historique>(historique));
            } else
            {
                insertResult = await _repoErreur.InsertHistorique(_mapper.Map<Historique>(historique));
            }
            return insertResult;
        }
    }
}
