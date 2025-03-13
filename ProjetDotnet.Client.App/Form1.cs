using ProjetDotnet.Client.App.Controllers;
using ProjetDotnet.Client.App.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            hiddenDate = tabControl1.TabPages[3];
            tabControl1.TabPages.Remove(tabControl1.TabPages[3]);

            hiddenJSON = tabControl1.TabPages[2];
            tabControl1.TabPages.Remove(tabControl1.TabPages[2]);

            hiddenCompte = tabControl1.TabPages[1];
            tabControl1.TabPages.Remove(tabControl1.TabPages[1]);

            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            label16.Text = "";
            labelError.Text = "";

            clientController = new ClientController();
            fillComboBox();
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
                tabControl1.TabPages.Insert(3, hiddenDate);
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
            label15.Text = "";
            label16.Text = "";

            string apiUrl = "https://localhost:7075/api/historique/jsonHistory";
            var httpClient = new HttpClient();

            decimal tauxDollars, tauxLivre, tauxYen;

            if (!decimal.TryParse(dollarsBox.Text, out tauxDollars) ||
                !decimal.TryParse(livreBox.Text, out tauxLivre) ||
                !decimal.TryParse(yenBox.Text, out tauxYen))
            {
                label15.Text = "Veuillez saisir des valeurs numériques valides pour les taux de change.";
                return;
            }

            var tauxDevises = new Dictionary<string, decimal>
            {
                { "USD", tauxDollars },
                { "LBP", tauxLivre },
                { "JPY", tauxYen }
            };

            string jsonContent = JsonSerializer.Serialize(tauxDevises);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                label16.Text = "Historique JSON généré avec succès";
                button2.Enabled = true;
                dollarsBox.Text = "";
                livreBox.Text = "";
                yenBox.Text = "";
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();    
                label15.Text = $"Erreur : {errorMessage}";
            }
        } 

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            // Réinitialisation du label d'erreurs
            labelError.Text = "";

            // Récupération des données
            DateTime date1 = monthCalendar1.SelectionRange.Start;
            DateTime date2 = monthCalendar2.SelectionRange.Start;
            string compteBancaireId = "";

            if(comboBox1.SelectedItem == null)
            {
                labelError.Text = "Veuillez sélectionner un compte";
                return;
            }

            if(date1 == null || date2 == null)
            {
                labelError.Text = "Veuillez sélectionner une date de début et une date de fin";
                return;
            }

            if(date1 > date2)
            {
                labelError.Text = "La date de début doit être antérieure à la date de fin";
                return;
            }

            compteBancaireId = comboBox1.SelectedItem.ToString();
            CompteBancaire compte = await clientController.getById(compteBancaireId);

            string fileName = $"transacitons_{compteBancaireId}_{date1.ToString("yyyy-MM-dd")}_{date2.ToString("yyyy-MM-dd")}.xml";
            await clientController.GenrerateXMLReport(fileName, await clientController.GetTransactionsBetweenDates(compte.CarteBancaires, date1, date2));
        }
    }
}
