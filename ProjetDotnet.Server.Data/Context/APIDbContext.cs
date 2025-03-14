﻿using Microsoft.EntityFrameworkCore;

namespace ProjetDotnet.Server.Data.Context
{
    public class APIDbContext : DbContext
    {
        public DbSet<Historique> Historique { get; set; }
        public DbSet<HistoriqueErreur> HistoriqueErreur { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbProj;" +
                "Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;" +
                "Application Intent=ReadWrite;Multi Subnet Failover=False");

        }
    }
}
