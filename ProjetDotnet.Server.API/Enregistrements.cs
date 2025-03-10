namespace ProjetDotnet.Server.API
{
    public enum TypeOperation
    {
        RetraitEffectue,
        FactureCarteBleue,
        DepotGuichet
    }
    public enum Devise { EUR, USD, JPY, LBP };
    public class Enregistrements
    {
        public string NumCarte { get; set; }
        public decimal Montant { get; set; }
        public TypeOperation TypeOperation { get; set; }
        public DateTime DateOperation { get; set; }
        public Devise Devise { get; set; }





        public Enregistrements(string numCarte, decimal montant, string typeOperation, DateTime dateOperation, string devise)

        {
            this.NumCarte = numCarte;
            this.Montant = montant;
            this.TypeOperation = typeOperation;
            this.DateOperation = dateOperation;
            this.Devise = devise;
        }





    }
}
