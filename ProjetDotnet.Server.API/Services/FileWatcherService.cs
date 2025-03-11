using ProjetDotnet.Enregistrement.Mapping;
using ProjetDotnet.Generation;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.PortableExecutable;
using System.Xml.Serialization;

namespace ProjetDotnet.Server.API.Services
{
    public class FileWatcherService
    {
        private readonly string _watchPath;
        private readonly FileSystemWatcher _fileWatcher;

        public FileWatcherService(string watchPath)
        {
            _watchPath = watchPath;
            _fileWatcher = new FileSystemWatcher(_watchPath, "*.xml")
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite
            };

            _fileWatcher.Created += OnFileCreated;
            _fileWatcher.EnableRaisingEvents = true;
        }

        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Nouveau fichier détecté : {e.FullPath}");
            Task.Run(() => AddHistorique(e.FullPath));
        }

        private async void AddHistorique(string filePath)
        {
            HistoriqueService historiqueService = new HistoriqueService();

            try
            {
                FileStream xmlfs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Enregistrements>));
                using (StreamReader reader = new StreamReader(xmlfs))
                {
                    List<Enregistrements> enregistrements = (List<Enregistrements>)serializer.Deserialize(reader);
                    foreach (var enregistrement in enregistrements)
                    {
                        HistoriqueDto historiqueDto = new HistoriqueDto
                        {
                            Montant = enregistrement.Montant,
                            TypeOperation = enregistrement.TypeOperation,
                            DateOperation = enregistrement.DateOperation,
                            Devise = enregistrement.Devise,
                            NumCarte = enregistrement.NumCarte
                        };
                        await historiqueService.InsertHistorique(historiqueDto);
                    }
                }
                //using (StreamReader reader = new StreamReader(xmlfs))
                //{
                //    //string line;
                //    //while ((line = reader.ReadLine()) != null)
                //    //{
                //    //    var values = line.Split(',');
                //    //    HistoriqueDto historiqueDto = new HistoriqueDto
                //    //    {
                //    //        Id = Int32.Parse(values[0]),
                //    //        Montant = Decimal.Parse(values[1]),
                //    //        TypeOperation = (TypeOperation)Enum.Parse(typeof(TypeOperation), values[2]),
                //    //        DateOperation = DateTime.Parse(values[3]),
                //    //        Devise = (Devise)Enum.Parse(typeof(Devise), values[4]),
                //    //        NumeroCarteBancaire = values[5]
                //    //    };
                //    //    await historiqueService.InsertHistorique(historiqueDto);

                //    //}
                //    List<Enregistrements> enregistrements = (List<Enregistrements>)serializer.Deserialize(reader);
                //}

                xmlfs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du traitement : {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Détails de l'erreur : " + ex.InnerException.Message);
                }
            }
        }
    }
}
