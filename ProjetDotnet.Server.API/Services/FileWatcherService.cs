using ProjetDotnet.Enregistrement.Mapping;
using System.Reflection.PortableExecutable;

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
                using (StreamReader reader = new StreamReader(xmlfs))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var values = line.Split(',');
                        HistoriqueDto historiqueDto = new HistoriqueDto
                        {
                            Id = Int32.Parse(values[0]),
                            Montant = Decimal.Parse(values[1]),
                            TypeOperation = (TypeOperation)Enum.Parse(typeof(TypeOperation), values[2]),
                            DateOperation = DateTime.Parse(values[3]),
                            Devise = values[4],
                            NumeroCarteBancaire = values[5]
                        };
                        await historiqueService.InsertHistorique(historiqueDto);

                    }
                }

                xmlfs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du traitement : {ex.Message}");
            }
        }
    }
}
