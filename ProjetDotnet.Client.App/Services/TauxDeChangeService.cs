using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjetDotnet.Client.App.Services
{
    public class TauxDeChangeService
    {
        private readonly HttpClient _httpClient;

        public TauxDeChangeService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Dictionary<string, decimal>> GetTauxDeChangeAsync()
        {
            string apiUrl = $"https://api.exchangerate-api.com/v4/latest/EUR";

            var response = await _httpClient.GetStringAsync(apiUrl);
            var data = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

            if (!data.ContainsKey("rates"))
                throw new Exception("Erreur : Réponse API invalide.");

            // Désérialisation du dictionnaire des taux
            var rates = JsonSerializer.Deserialize<Dictionary<string, decimal>>(data["rates"].ToString());

            if (rates == null)
                throw new Exception("Erreur : Impossible de récupérer les taux de change.");

            // On extrait uniquement les taux souhaités : GBP, USD, JPY
            return new Dictionary<string, decimal>
                {
                    { "GBP", rates.ContainsKey("GBP") ? rates["GBP"] : 0 },
                    { "USD", rates.ContainsKey("USD") ? rates["USD"] : 0 },
                    { "JPY", rates.ContainsKey("JPY") ? rates["JPY"] : 0 }
                };
        }
    }
}
