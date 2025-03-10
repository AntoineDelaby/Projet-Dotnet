namespace ProjetDotnet.Server.API.Services
{
    public class XMLGeneratorService
    {
        private static readonly Random random = new Random();

        public void GenerateXMLFile()
        {
            List<Enregistrements> enregistrements = new List<Enregistrements>();

            for (int i =0; i<10; i++)
            {
                enregistrements.Add(new Enregistrements(
                    GenerateRandomCardNumber(),
                    GenerateRandomAmount(),
                    (TypeOperation)random.Next(Enum.GetValues(typeof(TypeOperation)).Length),
                    DateTime.Now.AddDays(-random.Next(30)),
                    (Devise)random.Next(Enum.GetValues(typeof(Devise)).Length)
                ));
            }

        }
    }
}
