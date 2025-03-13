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
                Console.WriteLine("Début du traitement du fichier XML");
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
                        var result = await historiqueService.InsertHistorique(historiqueDto);
                        Console.WriteLine("Ajout en base terminé, code : " + result);
                    }
                }

                xmlfs.Close();

                // Suppression du fichier XML pour la prochaine génération automatique
                File.Delete(filePath);
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
