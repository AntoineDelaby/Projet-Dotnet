using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjetDotnet.Client.App.Repositories
{
    class ClientRepository : IRepository<Clients>
    {
        public ClientRepository()
        {
            InitializeDatabase();
        }

        // Initialisation de la base de données
        private void InitializeDatabase()
        {
            using var context = new ClientDBContext();
            context.Database.EnsureCreated();
        }

        // Récupération des donnees
        public async Task<List<Clients>> GetAll()
        {
            using var context = new ClientDBContext();
            var clients = await context.ClientParticulier
                .ToListAsync<Clients>();

            return clients ;
        }

        // Récupération d'un enregistrement historisé via son ID
        public async Task<Clients?> GetById(int identifiant)
        {
            using var context = new ClientDBContext();
            var client = await context.Clients.Where<Clients>(c => c.Identifiant == identifiant).SingleOrDefaultAsync<Clients>();

            return client ;
        }

        // Ajout d'un nouvel enregistrement valide dans la table client
        public async Task<int> InsertClient(Clients client)
        {
            using var context = new ClientDBContext();
            context.Clients.Add(client);
            await context.SaveChangesAsync();

            return client.Identifiant;
        }
    }







}

