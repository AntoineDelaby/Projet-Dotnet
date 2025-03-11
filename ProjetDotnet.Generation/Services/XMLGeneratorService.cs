using System.Text;
using System.Xml.Serialization;

namespace ProjetDotnet.Generation
{
    public class XMLGeneratorService
    {

        private static readonly Random random = new Random();

        public void GenerateXMLFile()
        {
            List<Enregistrements> enregistrements = new List<Enregistrements>();

            for (int i =0; i<100; i++)
            {
                enregistrements.Add(new Enregistrements(
                    GenerateRandomCardNumber(),
                    GenerateRandomAmount(),
                    (TypeOperation)random.Next(Enum.GetValues(typeof(TypeOperation)).Length),
                    DateTime.Now.AddDays(-random.Next(30)),
                    (Devise)random.Next(Enum.GetValues(typeof(Devise)).Length)
                ));
            }

            string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string solutionRoot = Directory.GetParent(projectRoot).FullName;
            string directoryPath = Path.Combine(solutionRoot, "ProjetDotnet.Generation", "Import");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string fileName = $"{DateTime.Now:yyyy_MM_dd}_enregistrement.xml";
            string filePath = Path.Combine(directoryPath, fileName);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Enregistrements>));
            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                serializer.Serialize(writer, enregistrements);
            }

            Console.WriteLine($"Fichier XML généré avec succès : {filePath}");
        }

        private string GenerateRandomCardNumber()
        {
            string baseNumber = "4974 0185 0223 ";
            string lastDigits = random.Next(1000, 9999).ToString(); 
            return baseNumber + lastDigits;
        }

        private decimal GenerateRandomAmount()
        {
            return Math.Round((decimal)(random.NextDouble() * (500 - 10) + 10), 2);
        }
    }
}
