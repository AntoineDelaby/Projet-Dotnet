using Microsoft.EntityFrameworkCore;
using ProjetDotnet.Server.Data.Context;
using ProjetDotnet.Server.Datas.Repositories;

namespace ProjetDotnet.Server.Data.Repositories
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
                .ToListAsync<HistoriqueErreur>();

            List<Historique> histList = new List<Historique>();
            foreach (var herr in historique)
            {
                histList.Add(convertToHistorique(herr));
            }

            return histList;
        }

        // Récupération d'un enregistrement défaillant via son ID
        public async Task<Historique?> GetById(int id)
        {
            using var context = new APIDbContext();
            var historique = await context.HistoriqueErreur
                .Where<HistoriqueErreur>(h => h.Id == id)
                .SingleOrDefaultAsync<HistoriqueErreur>();

            return convertToHistorique(historique);
        }

        // Ajout d'un nouvel enregistrement dans la table d'historique défaillant
        public async Task<int> InsertHistorique(Historique historique)
        {
            Console.WriteLine(historique.Id + " " + historique.Montant + " " + historique.Devise
                + " " + historique.TypeOperation + " " + historique.DateOperation + " Numcarte : " + historique.NumCarte);
            using var context = new APIDbContext();
            context.HistoriqueErreur.Add(convertToHistoriqueErreur(historique));
            await context.SaveChangesAsync();

            return historique.Id;
        }

        private Historique convertToHistorique(HistoriqueErreur herr)
        {
            return new Historique(herr.Id, herr.NumCarte, herr.Montant, herr.TypeOperation, herr.DateOperation, herr.Devise);
        }

        private HistoriqueErreur convertToHistoriqueErreur(Historique hist)
        {
            return new HistoriqueErreur(hist.Id, hist.NumCarte, hist.Montant, hist.TypeOperation, hist.DateOperation, hist.Devise);
        }
    }
}
