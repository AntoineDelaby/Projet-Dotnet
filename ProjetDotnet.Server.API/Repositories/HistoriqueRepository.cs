using Microsoft.EntityFrameworkCore;
using ProjetDotnet.Server.API.Context;
using Recap.Datas.Repositories;

namespace ProjetDotnet.Server.API.Repositories
{
    public class HistoriqueRepository : IRepository<Historique>
    {

        public HistoriqueRepository() {
            InitializeDatabase();
        }

        // Initialisation de la base de données
        private void InitializeDatabase()
        {
            using var context = new APIDbContext();
            context.Database.EnsureCreated();
        }

        // Récupération de tous les enregistrements historisés
        public async Task<List<Historique>> GetAll()
        {
            using var context = new APIDbContext();
            var historique = await context.Historique
                .ToListAsync<Historique>();

            return historique;
        }

        // Récupération d'un enregistrement historisé via son ID
        public async Task<Historique?> GetById(int id)
        {
            using var context = new APIDbContext();
            var historique = await context.Historique.Where<Historique>(h => h.Id == id).SingleOrDefaultAsync<Historique>();

            return historique;
        }

        // Ajout d'un nouvel enregistrement valide dans la table d'historique
        public async Task<int> InsertHistorique(Historique historique)
        {
            using var context = new APIDbContext();
            context.Historique.Add(historique);
            await context.SaveChangesAsync();

            return historique.Id;
        }
    }
}
