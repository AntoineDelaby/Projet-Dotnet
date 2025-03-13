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

            for (int i = 0; i < 100; i++)
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
            string directoryBackup = Path.Combine(solutionRoot, "ProjetDotnet.Generation", "Backup");

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            if (!Directory.Exists(directoryBackup))
                Directory.CreateDirectory(directoryBackup);

            string fileName = $"{DateTime.Now:yyyy_MM_dd_HH_mm_ss}_enregistrement.xml";
            string filePath = Path.Combine(directoryPath, fileName);
            string filePathBackup = Path.Combine(directoryBackup, fileName);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Enregistrements>));
            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                serializer.Serialize(writer, enregistrements);
            }

            using (StreamWriter writer = new StreamWriter(filePathBackup, false, Encoding.UTF8))
            {
                serializer.Serialize(writer, enregistrements);
            }

            Console.WriteLine($"Fichier XML généré avec succès : {filePath}");
        }

        private string GenerateRandomCardNumber()
        {
            string baseNumber = "4974 0185 0223 1";
            string lastDigits = random.Next(200, 299).ToString(); 
            return baseNumber + lastDigits;
        }

        private decimal GenerateRandomAmount()
        {
            return Math.Round((decimal)(random.NextDouble() * (500 - 10) + 10), 2);
        }
    }
}
