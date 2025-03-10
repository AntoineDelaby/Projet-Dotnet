using Microsoft.EntityFrameworkCore;
using ProjetDotnet.Server.API.Context;
using Recap.Datas.Repositories;

namespace ProjetDotnet.Server.API.Repositories
{
    public class HistoriqueErreurRepository : IRepository<Historique>
    {

        public HistoriqueErreurRepository() {
            InitializeDatabase();
        }

        // Initialisation de la base de données
        private void InitializeDatabase()
        {
            using var context = new APIDbContext();
            context.Database.EnsureCreated();
        }

        // Récupération de tous les enregistrements défaillants
        public async Task<List<Historique>> GetAll()
        {
            using var context = new APIDbContext();
            var historique = await context.HistoriqueErreur
                .ToListAsync<Historique>();

            return historique;
        }

        // Récupération d'un enregistrement défaillant via son ID
        public async Task<Historique?> GetById(int id)
        {
            using var context = new APIDbContext();
            var historique = await context.HistoriqueErreur
                .Where<Historique>(h => h.Id == id)
                .SingleOrDefaultAsync<Historique>();

            return historique;
        }

        // Ajout d'un nouvel enregistrement dans la table d'historique défaillant
        public async Task<int> InsertHistorique(Historique historique)
        {
            using var context = new APIDbContext();
            context.HistoriqueErreur.Add(historique);
            await context.SaveChangesAsync();

            return historique.Id;
        }
    }
}
