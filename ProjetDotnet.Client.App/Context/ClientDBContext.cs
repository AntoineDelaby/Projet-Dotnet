using Microsoft.EntityFrameworkCore;


namespace ProjetDotnet.Client.App

{
    public class ClientDBContext : DbContext
    {
        public DbSet<Clients> Clients { get; set; }
        public DbSet<ClientParticulier> ClientParticulier { get; set; }

        public DbSet<ClientProfessionnel> ClientProfessionnel { get; set; }
        public DbSet<CarteBancaire> CarteBancaire { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbClient;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>().ToTable("Clients");
            modelBuilder.Entity<ClientProfessionnel>().ToTable("ClientProfessionnel");
            modelBuilder.Entity<ClientParticulier>().ToTable("ClientParticulier");
        }




    }





}
