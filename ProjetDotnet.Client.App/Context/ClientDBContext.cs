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


            //Stocker en base la chaine de caracteres
            modelBuilder.Entity<ClientParticulier>().Property(c => c.Sexe).HasConversion<string>();

            modelBuilder.Entity<ClientParticulier>().HasData(
            new ClientParticulier
            {
                Identifiant = 1,
                Nom = "BETY",
                Prenom = "Daniel",
                Sexe = ESexe.M,
                DateDeNaissance = new DateTime(1985 - 11 - 12),
                Mail = "bety@gmail.com",
                Libelle_Adresse = "12, rue des Oliviers",
                Complement_Adresse = "",
                CodePostal = "94000",
                Ville = "Creteil",


            });


            modelBuilder.Entity<ClientParticulier>().HasData(
            new ClientParticulier
            {
                Identifiant = 3,
                Nom = "BODIN",
                Prenom = "Justin",
                Sexe = ESexe.M,
                DateDeNaissance = new DateTime(1965 - 05 - 05),
                Mail = "bodin@gmail.com",
                Libelle_Adresse = "10, rue des Oliviers",
                Complement_Adresse = "etage 2",
                CodePostal = "94300",
                Ville = "Vincennes",


            });

            modelBuilder.Entity<ClientParticulier>().HasData(
            new ClientParticulier
            {
                Identifiant = 5,
                Nom = "BERRIS",
                Prenom = "Karine",
                Sexe = ESexe.F,
                DateDeNaissance = new DateTime(1977 - 06 - 06),
                Mail = "berris@gmail.com",
                Libelle_Adresse = "15, rue de la Republique ",
                Complement_Adresse = "",
                CodePostal = "94120",
                Ville = "FONTENAY SOUS BOIS",

            });

            modelBuilder.Entity<ClientParticulier>().HasData(
            new ClientParticulier
            {
                Identifiant = 7,
                Nom = "ABENIR",
                Prenom = "Alevandra",
                Sexe = ESexe.F,
                DateDeNaissance = new DateTime(1977 - 04 - 12),
                Mail = "abenir@gmail.com",
                Libelle_Adresse = "25, rue de la Paix ",
                Complement_Adresse = "",
                CodePostal = "92100",
                Ville = "LA DEFENSE",

            });

            modelBuilder.Entity<ClientParticulier>().HasData(
            new ClientParticulier
            {
                Identifiant = 9,
                Nom = "BENSAID",
                Prenom = "Georgia",
                Sexe = ESexe.F,
                DateDeNaissance = new DateTime(1976 - 04 - 16),
                Mail = "bensaid@gmail.com",
                Libelle_Adresse = "3, avenue des Parcs ",
                Complement_Adresse = "",
                CodePostal = "93500",
                Ville = "ROISSY EN France",

            });

            modelBuilder.Entity<ClientParticulier>().HasData(
            new ClientParticulier
            {
                Identifiant = 11,
                Nom = "ABABOU",
                Prenom = "Teddy",
                Sexe = ESexe.M,
                DateDeNaissance = new DateTime(1970 - 10 - 10),
                Mail = "ababou@gmail.com",
                Libelle_Adresse = "3, rue Lecourbe ",
                Complement_Adresse = "",
                CodePostal = "93200",
                Ville = "BAGNOLET",

            });

            modelBuilder.Entity<ClientProfessionnel>().HasData(
            new ClientProfessionnel
            {
                Identifiant = 2,
                Nom = "AXA",
                Mail = "info@axa.fr",
                Libelle_Adresse = "125, rue LaFayette",
                Complement_Adresse = "Digicode 1432",
                CodePostal = "94120",
                Ville = "FONTENAY SOUS BOIS",
                Siret = "12548795641122",
                StatutJuridique = "SARL",
                Libelle_AdresseSiege = "125,rue lafayette",
                Complement_AdresseSiege = "digicode 1432",
                Codepostal_Siege = "94120",
                Ville_Siege = "FONTENAY SOUS BOIS"

            });

            modelBuilder.Entity<ClientProfessionnel>().HasData(
            new ClientProfessionnel
            {
                Identifiant = 4,
                Nom = "PAUL",
                Mail = "info@paul.fr",
                Libelle_Adresse = "36, quai des Orfevres",
                Complement_Adresse = "",
                CodePostal = "93500",
                Ville = "ROISSY EN FRANCE",
                Siret = "87459564455444",
                StatutJuridique = "EURL",
                Libelle_AdresseSiege = "10, esplandade de la Defense",
                Complement_AdresseSiege = "",
                Codepostal_Siege = "92060",
                Ville_Siege = "LA DEFENSE"

            });

            modelBuilder.Entity<ClientProfessionnel>().HasData(
            new ClientProfessionnel
            {
                Identifiant = 6,
                Nom = "PRIMARK",
                Mail = "info@primark.fr",
                Libelle_Adresse = "32, rue E. Renan ",
                Complement_Adresse = "Bat.C",
                CodePostal = "75002",
                Ville = "PARIS",
                Siret = "08755897458455",
                StatutJuridique = "SARL",
                Libelle_AdresseSiege = "32, rue E. Renan",
                Complement_AdresseSiege = "Bat.C",
                Codepostal_Siege = "75002",
                Ville_Siege = "PARIS"

            });


            modelBuilder.Entity<ClientProfessionnel>().HasData(
            new ClientProfessionnel
            {
                Identifiant = 8,
                Nom = "ZARA",
                Mail = "info@zara.fr",
                Libelle_Adresse = "23, av P. Valery ",
                Complement_Adresse = "",
                CodePostal = "92100",
                Ville = "LA DEFENSE",
                Siret = "65895874587854",
                StatutJuridique = "SA",
                Libelle_AdresseSiege = "24, esplanade de la Defense",
                Complement_AdresseSiege = " Tour Franklin",
                Codepostal_Siege = "92060",
                Ville_Siege = "LA DEFENSE"

            });


            modelBuilder.Entity<ClientProfessionnel>().HasData(
            new ClientProfessionnel
            {
                Identifiant = 10,
                Nom = "LEONIDAS",
                Mail = "contact@leonidas.fr",
                Libelle_Adresse = "15, place de la Bastille",
                Complement_Adresse = "Fond de Cour",
                CodePostal = "75003",
                Ville = "Paris",
                Siret = "91235987456832",
                StatutJuridique = "SAS",
                Libelle_AdresseSiege = "10, rue de la paix",
                Complement_AdresseSiege = "",
                Codepostal_Siege = "75008",
                Ville_Siege = "Paris"

            });



        }



    }





}
