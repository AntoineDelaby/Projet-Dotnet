using ProjetDotnet.Client.App;
using ProjetDotnet.Client.App.Repositories;

namespace ProjetDotnet.Client.App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            try
            {

                // Clients particuliers 1 valide
                ClientParticulier client1 = new ClientParticulier(1, "BETY", "bety@gmail.com",
                       "12, rue des Oliviers", "", "94000", "Creteil",
                       "Daniel", ESexe.M, new DateTime(1985, 11, 12));

                ClientRepository repo = new ClientRepository();
                repo.InsertClient(client1);
                Console.ReadLine();

                // Clients particuliers 3 valide
                ClientParticulier client3 = new ClientParticulier(3, "BODIN", "bodin@gmail.com",
                    "10, rue des Oliviers", "etage 2", "94300", "Vincennes",
                    "Justin", ESexe.M, new DateTime(1965, 5, 5));
                


                // Clients particuliers 5 valide
                ClientParticulier client5 = new ClientParticulier(5, "BERRIS", "berris@gmail.com",
                    "15, rue de la Repiblique", "", "94120", "FONTENAY SOUS BOIS",
                    "Karine", ESexe.F, new DateTime(1977, 6, 6));
                


                // client particulier 7 valide
                ClientParticulier client7 = new ClientParticulier(7, "ABENIR",
                    "abenir@gmail.com", "25, rue de la Paix", "", "92100", "LA DEFENCE", "Alexandra", ESexe.F, new DateTime(1977, 4, 12));
                


                // client particulier 9 valide
                ClientParticulier client9 = new ClientParticulier(9, "BENSAID",
                    "bensaid@gmail.com", "3, avenue des Parcs", "", "93500", "ROISSY EN FRANCE", "Georgia", ESexe.F, new DateTime(1976, 4, 16));
                



                // client particulier 11 valide
                ClientParticulier client11 = new ClientParticulier(
                    11, "Teddy", "abadou@gmail.com",
                    "3, rue Lecourbe", "", "93200", "BAGNOLET",
                    "ABADOU", ESexe.M, new DateTime(1970, 10, 10));
               


                // Clients professionnels 2 valide
                ClientProfessionnel client2 = new ClientProfessionnel(2, "AXA", "info@axa.fr",
                "125, rue LaFayette", "Digicode 1432", "94120", "FONTENAY SOUS BOIS",
                "12548795641122", "SARL", "125,rue lafayette", "digicode 1432", "94120", "FONTENAY SOUS BOIS");
                

                // Clients professionnels 10 valide

                ClientProfessionnel client10 = new ClientProfessionnel(
                    10, "LEONIDAS", "contact@leonidas.fr",
                    "15, place de la Bastille", "Fond de Cour", "75003", "Paris",
                    "91235987456832", "SAS", "10, rue de la paix", "", "75008", "Paris");
                



            }
            catch (ClientsException ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }

           


            // Exemple d'un client particulier avec un nom invalide (>50)
            try
            {
                ClientParticulier clientInvalidNom = new ClientParticulier(7, "ABENIRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR",
                    "abenir@gmail.com", "25, rue de la Paix", " ", "92100", "LA DEFENCE", "Alexandra", ESexe.F, new DateTime(1977, 4, 12));
                
            }
            catch (ClientsException ex)
            {
                Console.WriteLine($"Erreur lors de la création du client: {ex.Message}");

            }

            // client particulier avec un mail invalide (sans @)
            try
            {
                ClientParticulier clientInvalidMail = new ClientParticulier(
                    9, "Teddy", "abadougmail.com",
                    "3, rue Lecourbe", "", "93200", "BAGNOLET",
                    "ABADOU", ESexe.M, new DateTime(1970, 10, 10));
                
            }
            catch (ClientsException ex)
            {
                Console.WriteLine($"Erreur lors de la création du client: {ex.Message}");
            }


            // client professionnel avec un Siret invalide ( < 14)
            try
            {
                ClientProfessionnel clientInvalidSiret = new ClientProfessionnel(
                    10, "LEONIDAS", "contact@leonidas.fr",
                    "15, place de la Bastille", "Fond de Cour", "75003", "Paris",
                    "9123598", "SAS", "10, rue de la paix", "", "75008", "Paris");
                
            }
            catch (ClientsException ex)
            {
                Console.WriteLine($"Erreur lors de la création du client professionnel: {ex.Message}");
            }


            Console.ReadLine();
        }
    }
}
