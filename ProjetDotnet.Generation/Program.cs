using ProjetDotnet.Generation;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Test de la génération du fichier XML...");

        XMLGeneratorService xmlService = new XMLGeneratorService();

        xmlService.GenerateXMLFile();

        Console.WriteLine("Le fichier XML a été généré avec succès !");
    }
}