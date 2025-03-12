using Microsoft.EntityFrameworkCore;
using ProjetDotnet.Server.Data;
using ProjetDotnet.Server.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ProjetDotnet.Client.App.Controllers
{
    class ClientController
    {
        public ClientController() {
            InitializeDatabase();
        }

        // Initialisation de la base de données
        private void InitializeDatabase()
        {
            //using var context = new ClientDbContext();
            //context.Database.EnsureCreated();
        }

        //Récupère la liste des transactions effectuées par un compte bancaire
        public async Task<List<Historique>?> GetTransactionsById(List<CarteBancaire> cartes)
        {
            // Chemin d'accès au fichier json
            string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string solutionRoot = Directory.GetParent(projectRoot).FullName;
            string filePath = Path.Combine(solutionRoot, "ProjetDotnet.Client.App", "Json\\export.json");

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                List<Historique>? historique = await JsonSerializer.DeserializeAsync<List<Historique>>(fs);

                return historique
                    .Where<Historique>(h => cartes.Any(c => c.NumeroCarte == h.NumCarte))
                    .ToList<Historique>();
            }
        }

        public async Task<List<Historique>?> GetTransactionsBetweenDates(List<CarteBancaire> cartes, DateTime begDate, DateTime endDate)
        {
            // Chemin d'accès au fichier json
            string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string solutionRoot = Directory.GetParent(projectRoot).FullName;
            string filePath = Path.Combine(solutionRoot, "ProjetDotnet.Client.App", "Json\\export.json");

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                List<Historique>? historique = await JsonSerializer.DeserializeAsync<List<Historique>>(fs);
                return historique
                    .Where<Historique>(h => cartes.Any(c => c.NumeroCarte == h.NumCarte)
                                        && h.DateOperation > begDate 
                                        && h.DateOperation < endDate)
                    .ToList<Historique>();
            }
        }

        public async Task<string> GetAllAccountsWithClients()
        {
            using var context = new ClientDBContext();

            var result = await context.CompteBancaire
                .Include(cb => cb.Client)  
                .Include(cb => cb.CarteBancaires)
                .Select(cb => new
                {
                    Identifiant_Client = cb.ClientId,
                    Nom_Client = cb.Client.Nom,
                    Id_CompteBancaire = cb.Id,
                    DateOuverture_CompteBancaire = cb.DateOuverture,
                    Solde_CompteBancaire = cb.Solde,
                    CartesBancaires = cb.CarteBancaires.Select(c => c.NumeroCarte).ToList()
                })
                .ToListAsync();

            // Sérialisation en JSON
            return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
