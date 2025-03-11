namespace ProjetDotnet.Generation
{
    public class Enregistrements
    {
        public string NumCarte { get; set; }
        public decimal Montant { get; set; }
        public TypeOperation TypeOperation { get; set; }
        public DateTime DateOperation { get; set; }
        public Devise Devise { get; set; }

        public Enregistrements() { }

        public Enregistrements(string numCarte, decimal montant, TypeOperation typeOperation, DateTime dateOperation, Devise devise)

        {
            this.NumCarte = numCarte;
            this.Montant = montant;
            this.TypeOperation = typeOperation;
            this.DateOperation = dateOperation;
            this.Devise = devise;
        }

    }
}
