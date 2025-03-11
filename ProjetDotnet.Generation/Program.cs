using ProjetDotnet.Generation;
using System.Timers;

internal class Program
{
    private static void Main(string[] args)
    {
        CreateXml();
        System.Timers.Timer aTimer = new System.Timers.Timer(60 * 1000);
        //System.Timers.Timer aTimer = new System.Timers.Timer(60 * 60 * 1000);
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Start();

        Console.ReadLine();
    }

    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        CreateXml();
    }

    private static void CreateXml()
    {
        Console.WriteLine("Une heure de passée ! (Heure : " + DateTime.Now + ")");

        Console.WriteLine("Test de la génération du fichier XML...");

        XMLGeneratorService xmlService = new XMLGeneratorService();

        xmlService.GenerateXMLFile();

        Console.WriteLine("Le fichier XML a été généré avec succès !");
        Console.WriteLine("----------------------------------------------------------------------------------------------------");
        Console.WriteLine("Appuyez sur la touche ENTER pour arrêter le processus ...");
        Console.WriteLine("----------------------------------------------------------------------------------------------------");
    }
}