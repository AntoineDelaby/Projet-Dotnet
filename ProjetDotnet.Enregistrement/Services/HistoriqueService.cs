using AutoMapper;
using Newtonsoft.Json.Linq;
using ProjetDotnet.Enregistrement;
using ProjetDotnet.Enregistrement.Mapping;
using ProjetDotnet.Server.Data;
using ProjetDotnet.Server.Data.Repositories;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Xml.Serialization;

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
            Console.WriteLine("Insertion de l'historique : " + historique.Id + " " + historique.Montant + " " + historique.Devise);
            var insertResult = -1;
            if(IsValidCardNumber(historique.NumCarte))
            {
                Console.WriteLine("Carte valide : " + historique.NumCarte);
                insertResult = await _repo.InsertHistorique(_mapper.Map<Historique>(historique));
            } else
            {
                Console.WriteLine("Carte invalide : " + historique.NumCarte);
                insertResult = await _repoErreur.InsertHistorique(_mapper.Map<Historique>(historique));
            }
            return insertResult;
        }

        // Génère le fichier JSON de l'historique des enregistrements validés
        public async Task<string> GenerateHistoriqueJson(Dictionary<string, decimal> tauxDevise)
        {
            // Récupération des enregistrements validés
            var histEntities = await _repo.GetAll();

            List<Historique> jsonList = new List<Historique>();
            foreach (var item in histEntities)
            {
                if(!item.Devise.Equals("EUR"))
                {
                    // On fait la conversion en euros avec les taux qu'on récupère de la requête
                    item.MontantEuros = item.Montant / tauxDevise[item.Devise];
                    item.Taux = tauxDevise[item.Devise];
                } else
                {
                    item.MontantEuros = item.Montant;
                    item.Taux = 1;
                }
                jsonList.Add(item);
            }

            // Destination du fichier JSON
            // Destination sur le serveur
            //string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Exports\\export.json");
            // Destination sur le client
            string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string solutionRoot = Directory.GetParent(projectRoot).FullName;
            string directoryPath = Path.Combine(solutionRoot, "ProjetDotnet.Client.App", "Json");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, "export.json");

            // Suppression du fichier JSON précédent
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Création du nouveau fichier d'export
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                await JsonSerializer.SerializeAsync(fs, jsonList, new JsonSerializerOptions { WriteIndented = true });
            }

            return JsonSerializer.Serialize(jsonList, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
