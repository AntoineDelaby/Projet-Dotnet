using Microsoft.EntityFrameworkCore;
using ProjetDotnet.Client.App.Entities;
using ProjetDotnet.Client.App.Services;
using ProjetDotnet.Server.Data;
using ProjetDotnet.Server.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static ProjetDotnet.Client.App.Form1;
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
            using var context = new ClientDBContext();
            context.Database.EnsureCreated();
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

        public async Task<List<Historique>?> GetTransactionsBetweenDates(ICollection<CarteBancaire> cartes, DateTime begDate, DateTime endDate)
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
                                        && h.DateOperation >= begDate 
                                        && h.DateOperation <= endDate)
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

        public async Task<int> GenrerateXMLReport(string fileName, List<Historique> data)
        {
            // Chemin d'accès au fichier XML
            // fileName = transacitons_{begDate}_{endDate}.xml
            string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string solutionRoot = Directory.GetParent(projectRoot).FullName;
            string filePath = Path.Combine(solutionRoot, "ProjetDotnet.Client.App", "XML\\", fileName);

            // Si le fichier existe déjà, on le supprime (Plusieurs demandes de rapport dans la même journée)
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Historique>));
            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                serializer.Serialize(writer, data);
            }

            return 0;
        }

        public async Task<List<CompteBancaire>> getAll()
        {
            using var context = new ClientDBContext();
            var comptes = await context.CompteBancaire
                .ToListAsync<CompteBancaire>();

            return comptes;
        }

        public async Task<CompteBancaire> getById(string id)
        {
            using var context = new ClientDBContext();
            var compte = await context.CompteBancaire
                .Include(c => c.CarteBancaires)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync<CompteBancaire>();
            return compte;
        }

        public async Task<Dictionary<string, decimal>> GetTauxDeChange()
        {
            var service = new TauxDeChangeService();
            return await service.GetTauxDeChangeAsync();
        }
    }
}
