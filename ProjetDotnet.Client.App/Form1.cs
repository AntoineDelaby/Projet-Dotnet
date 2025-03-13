using ProjetDotnet.Client.App.Controllers;
using ProjetDotnet.Client.App.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetDotnet.Client.App
{
    public partial class Form1 : Form
    {
        private TabPage hiddenCompte;
        private TabPage hiddenJSON;
        private TabPage hiddenDate;
        private readonly ClientController clientController;

        public Form1()
        {
            InitializeComponent();
            indentBox.KeyDown += new KeyEventHandler(Enter_KeyDown);
            mdpBox.KeyDown += new KeyEventHandler(Enter_KeyDown);
            onglet();
            initialisation_label();
            initialiastion_data_view();
            //getTaux();

            clientController = new ClientController();
            fillComboBox();
        }

        public void onglet()
        {
            // Initialisation pour la connexion
            hiddenDate = tabControl1.TabPages[3];
            tabControl1.TabPages.Remove(tabControl1.TabPages[3]);

            hiddenJSON = tabControl1.TabPages[2];
            tabControl1.TabPages.Remove(tabControl1.TabPages[2]);

            hiddenCompte = tabControl1.TabPages[1];
            tabControl1.TabPages.Remove(tabControl1.TabPages[1]);
        }

        public void initialisation_label()
        {
            // Initialisation des différents label d'erreur/réussite
            label13.Text = "";
            label14.Text = "";
            label17.Text = "";
            label16.Text = "";
            labelError.Text = "";
            label18.Text = "";
            dollarsBox.Enabled = false;
            livreBox.Enabled = false;
            yenBox.Enabled = false;
        }

        public async void initialiastion_data_view()
        {
            string jsonResponse = await new ClientController().GetAllAccountsWithClients();
            var accounts = JsonSerializer.Deserialize<List<dynamic>>(jsonResponse);
            if (accounts != null && accounts.Count > 0)
            {
                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add("Identifiant_Client", "ID Client");
                dataGridView1.Columns.Add("Nom_Client", "Nom Client");
                dataGridView1.Columns.Add("Id_CompteBancaire", "ID Compte Bancaire");
                dataGridView1.Columns.Add("DateOuverture_CompteBancaire", "Date d'ouverture");
                dataGridView1.Columns.Add("Solde_CompteBancaire", "Solde du compte (€)");
                dataGridView1.Columns.Add("NumeroCarte", "Numéro de Carte");

                foreach (var account in accounts)
                {
                    string identifiantClient = account.GetProperty("Identifiant_Client").ToString();
                    string nomClient = account.GetProperty("Nom_Client").ToString();
                    string idCompteBancaire = account.GetProperty("Id_CompteBancaire").ToString();
                    string dateOuverture = account.GetProperty("DateOuverture_CompteBancaire").ToString();
                    double solde = account.GetProperty("Solde_CompteBancaire").GetDouble();
                    string numeroCarte = account.GetProperty("CartesBancaires").ToString();



                    dataGridView1.Rows.Add(new string[]
                      {
                    identifiantClient,
                    nomClient,
                    idCompteBancaire,
                    dateOuverture,
                    solde.ToString(),
                    numeroCarte
                      });
                }
                dataGridView1.Columns["NumeroCarte"].Visible = false;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private async void getTaux()
        {
            var controller = new ClientController();

            try
            {
                var tauxDeChange = await controller.GetTauxDeChange();

                dollarsBox.Text = $"{tauxDeChange["USD"]}";
                livreBox.Text = $"{tauxDeChange["GBP"]}";
                yenBox.Text = $"{tauxDeChange["JPY"]}";
            }
            catch (Exception ex)
            {
                label17.Text = $"Erreur : {ex.Message}";
            }
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tabControl1.SelectedIndex == 0)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    // Simuler un clic sur button1
                    button1.PerformClick();

                    // Empêcher le  "ding" de Windows
                    e.SuppressKeyPress = true;
                }
            }
        }

        private async void fillComboBox()
        {
            List<CompteBancaire> comptes = await clientController.getAll();
            foreach (var item in comptes)
            {
                comboBox1.Items.Add(item.Id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = indentBox.Text;
            string password = mdpBox.Text;

            if (username == "admin" && password == "admin")
            {
                label13.Text = "";
                label14.Text = "Connexion réussie !";
                tabControl1.TabPages.Insert(1, hiddenCompte);
                tabControl1.TabPages.Insert(2, hiddenJSON);
                indentBox.Enabled = false;
                mdpBox.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                label13.Text = "Nom d'utilisateur ou mot de passe incorrect";
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            label17.Text = "";
            label16.Text = "";

            string apiUrl = "https://localhost:7075/api/historique/jsonHistory";
            var httpClient = new HttpClient();

            decimal tauxDollars, tauxLivre, tauxYen;

            if (!decimal.TryParse(dollarsBox.Text, out tauxDollars) ||
                !decimal.TryParse(livreBox.Text, out tauxLivre) ||
                !decimal.TryParse(yenBox.Text, out tauxYen))
            {
                label17.Text = "Veuillez générer les taux du jour.";
                button2.Enabled = true;
                return;
            }

            var tauxDevises = new Dictionary<string, decimal>
            {
                { "USD", tauxDollars },
                { "GBP", tauxLivre },
                { "JPY", tauxYen }
            };

            string jsonContent = JsonSerializer.Serialize(tauxDevises);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                label16.Text = "Fichier JSON généré avec succès";
                button2.Enabled = true;
                maj_solde();
                if (tabControl1.TabPages.Count <= 3)
                    tabControl1.TabPages.Insert(3, hiddenDate);
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                label17.Text = $"Erreur : {errorMessage}";
                button2.Enabled = true;
            }
        }

        public async void maj_solde()
        {
            try
            {
                string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
                string solutionRoot = Directory.GetParent(projectRoot).FullName;
                string filePath = Path.Combine(solutionRoot, "ProjetDotnet.Client.App", "Json", "export.json");

                string jsonContent = await File.ReadAllTextAsync(filePath);
                var transactions = JsonSerializer.Deserialize<List<dynamic>>(jsonContent);

                if (transactions == null || transactions.Count == 0)
                {
                    label15.Text = "Aucune transaction trouvée dans le fichier JSON.";
                    return;
                }

                Dictionary<string, decimal> misesAJourSoldes = new Dictionary<string, decimal>();

                foreach (var transaction in transactions)
                {
                    string numCarte = transaction.GetProperty("NumCarte").GetString();
                    decimal montant = transaction.GetProperty("Montant").GetDecimal();
                    string typeOperation = transaction.GetProperty("TypeOperation").GetString();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Id_CompteBancaire"].Value != null)
                        {
                            string idCompte = row.Cells["Id_CompteBancaire"].Value.ToString();

                            string numeroCarteStockee = row.Cells["NumeroCarte"].Value?.ToString();

                            List<string> cartesAssociees = JsonSerializer.Deserialize<List<string>>(numeroCarteStockee);

                            if (cartesAssociees != null && cartesAssociees.Contains(numCarte))
                            {

                                misesAJourSoldes[idCompte] = decimal.Parse(row.Cells["Solde_CompteBancaire"].Value.ToString());

                                if (typeOperation == "DepotGuichet")
                                {
                                    misesAJourSoldes[idCompte] += montant;
                                }
                                else if (typeOperation == "RetraitGuichet" || typeOperation == "FactureCarteBleue")
                                {
                                    misesAJourSoldes[idCompte] -= montant;
                                }

                                row.Cells["Solde_CompteBancaire"].Value = misesAJourSoldes[idCompte].ToString("0.00");
                                await clientController.UpdageCompteBancaireSolde(idCompte, misesAJourSoldes[idCompte]);
                            }
                        }
                    }
                }
                dataGridView1.Refresh();
                label16.Text += " et solde mise à jours";
            }
            catch (Exception ex)
            {
                label15.Text = "Erreur lors de la mise à jour du solde : " + ex.Message;
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            // Réinitialisation des labels
            labelError.Text = "";
            label18.Text = "";

            // Récupération des données
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;
            string compteBancaireId = "";

            if (comboBox1.SelectedItem == null || comboBox1.SelectedItem == "")
            {
                labelError.Text = "Veuillez sélectionner un compte";
                return;
            }

            if (date1 == null || date2 == null)
            {
                labelError.Text = "Veuillez sélectionner une date de début et une date de fin";
                return;
            }

            if (date1 > date2)
            {
                labelError.Text = "La date de début doit être antérieure à la date de fin";
                return;
            }
            if (date1 > DateTime.Now || date2 > DateTime.Now)
            {
                labelError.Text = "Les dates doivent être antérieures ou égales à la date du jour";
                return;
            }

            compteBancaireId = comboBox1.SelectedItem.ToString();
            CompteBancaire compte = await clientController.getById(compteBancaireId);

            string fileName = $"transacitons_{compteBancaireId}_" +
                        $"{date1.ToString("yyyy-MM-dd")}_{date2.ToString("yyyy-MM-dd")}.xml";
            await clientController.GenrerateXMLReport(fileName,
                        await clientController.GetTransactionsBetweenDates(compte.CarteBancaires, date1, date2));
            label18.Text = "Fichier XML généré avec succès";
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            getTaux();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
