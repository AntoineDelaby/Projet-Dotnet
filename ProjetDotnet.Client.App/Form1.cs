using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetDotnet.Client.App
{
    public partial class Form1 : Form
    {
        private TabPage hiddenCompte;
        private TabPage hiddenJSON;
        private TabPage hiddenDate;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = indentBox.Text;
            string password = mdpBox.Text;

            if (username == "admin"  && password == "admin")
            {
                label13.Text = "";
                label14.Text = "Connexion réussie !";
                tabControl1.TabPages.Insert(1, hiddenCompte);
                tabControl1.TabPages.Insert(2, hiddenJSON);
                tabControl1.TabPages.Insert(3, hiddenDate);
            }
            else
            {
                label13.Text = "Nom d'utilisateur ou mot de passe incorrect";
            }

            
        }
    }
}
