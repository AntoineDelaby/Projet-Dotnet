using ProjetDotnet.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjetDotnet.Client.App.Controllers
{
    class ClientController
    {
        public ClientController() { }

        // Récupère la liste des transactions effectuées par un compte bancaire
        //public async Task<List<Historique>?> GetTransactionsById(List<CarteBancaire> cartes)
        //{
        //    // Chemin d'accès au fichier json
        //    string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        //    string solutionRoot = Directory.GetParent(projectRoot).FullName;
        //    string filePath = Path.Combine(solutionRoot, "ProjetDotnet.Client.App", "Json\\export.json");

        //    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        //    {
        //        List<Historique>? historique = await JsonSerializer.DeserializeAsync<List<Historique>>(fs);

        //        return historique
        //            .Where<Historique>(h => cartes.Where<CarteBancaire>(c => c.NumeroCarte.Equals(h.NumCarte)))
        //            .ToList<Historique>();
        //    }
        //}

        public async Task<List<Historique>?> GetTransactionsBetweenDates(int id, DateTime begDate, DateTime endDate)
        {
            // Chemin d'accès au fichier json
            string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string solutionRoot = Directory.GetParent(projectRoot).FullName;
            string filePath = Path.Combine(solutionRoot, "ProjetDotnet.Client.App", "Json\\export.json");

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                List<Historique>? historique = await JsonSerializer.DeserializeAsync<List<Historique>>(fs);

                return historique
                    .Where<Historique>(h => h.Id == id && h.DateOperation > begDate && h.DateOperation < endDate)
                    .ToList<Historique>();
            }
        }
    }
}
