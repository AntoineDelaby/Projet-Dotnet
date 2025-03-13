namespace ProjetDotnet.Client.App
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label14 = new Label();
            label13 = new Label();
            button1 = new Button();
            mdpBox = new TextBox();
            indentBox = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            dataGridView1 = new DataGridView();
            label4 = new Label();
            tabPage3 = new TabPage();
            label17 = new Label();
            label16 = new Label();
            button2 = new Button();
            groupBox1 = new GroupBox();
            button5 = new Button();
            yenBox = new TextBox();
            livreBox = new TextBox();
            dollarsBox = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            tabPage4 = new TabPage();
            label18 = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            labelError = new Label();
            label15 = new Label();
            comboBox1 = new ComboBox();
            button4 = new Button();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage3.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.AccessibleName = "";
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Font = new Font("Segoe UI", 9F);
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(785, 435);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label14);
            tabPage1.Controls.Add(label13);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(mdpBox);
            tabPage1.Controls.Add(indentBox);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(777, 407);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Connexion";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 16F);
            label14.ForeColor = Color.Green;
            label14.Location = new Point(282, 313);
            label14.Name = "label14";
            label14.Size = new Size(195, 30);
            label14.TabIndex = 7;
            label14.Text = "Connexion réussie!";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = Color.Red;
            label13.Location = new Point(244, 223);
            label13.Name = "label13";
            label13.Size = new Size(39, 15);
            label13.TabIndex = 6;
            label13.Text = "blabla";
            // 
            // button1
            // 
            button1.Location = new Point(306, 266);
            button1.Name = "button1";
            button1.Size = new Size(123, 23);
            button1.TabIndex = 5;
            button1.Text = "Se connecter";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // mdpBox
            // 
            mdpBox.Location = new Point(244, 157);
            mdpBox.Name = "mdpBox";
            mdpBox.Size = new Size(309, 23);
            mdpBox.TabIndex = 4;
            mdpBox.UseSystemPasswordChar = true;
            // 
            // indentBox
            // 
            indentBox.Location = new Point(244, 92);
            indentBox.Name = "indentBox";
            indentBox.Size = new Size(309, 23);
            indentBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(148, 160);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 2;
            label3.Text = "Mot de passe";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(148, 100);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 1;
            label2.Text = "Identifiant";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(326, 20);
            label1.Name = "label1";
            label1.Size = new Size(70, 30);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Controls.Add(label4);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(777, 407);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Liste utilisateur";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new Point(85, 84);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(603, 268);
            dataGridView1.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label4.Location = new Point(270, 22);
            label4.Name = "label4";
            label4.Size = new Size(210, 30);
            label4.TabIndex = 0;
            label4.Text = "Comptes bancaires";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label17);
            tabPage3.Controls.Add(label16);
            tabPage3.Controls.Add(button2);
            tabPage3.Controls.Add(groupBox1);
            tabPage3.Controls.Add(label5);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(777, 407);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Mettre à jour solde";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.ForeColor = Color.Red;
            label17.Location = new Point(174, 70);
            label17.Name = "label17";
            label17.Size = new Size(44, 15);
            label17.TabIndex = 5;
            label17.Text = "label17";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.ForeColor = Color.Green;
            label16.Location = new Point(174, 345);
            label16.Name = "label16";
            label16.Size = new Size(44, 15);
            label16.TabIndex = 4;
            label16.Text = "label16";
            // 
            // button2
            // 
            button2.Location = new Point(328, 299);
            button2.Name = "button2";
            button2.Size = new Size(122, 23);
            button2.TabIndex = 2;
            button2.Text = "Mettre à jour";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(yenBox);
            groupBox1.Controls.Add(livreBox);
            groupBox1.Controls.Add(dollarsBox);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Location = new Point(174, 88);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(427, 205);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // button5
            // 
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.Location = new Point(376, 17);
            button5.Name = "button5";
            button5.Size = new Size(26, 26);
            button5.TabIndex = 6;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // yenBox
            // 
            yenBox.Location = new Point(128, 142);
            yenBox.Name = "yenBox";
            yenBox.Size = new Size(216, 23);
            yenBox.TabIndex = 6;
            // 
            // livreBox
            // 
            livreBox.Location = new Point(128, 100);
            livreBox.Name = "livreBox";
            livreBox.Size = new Size(216, 23);
            livreBox.TabIndex = 5;
            // 
            // dollarsBox
            // 
            dollarsBox.Location = new Point(128, 60);
            dollarsBox.Name = "dollarsBox";
            dollarsBox.Size = new Size(216, 23);
            dollarsBox.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(23, 23);
            label9.Name = "label9";
            label9.Size = new Size(347, 15);
            label9.TabIndex = 3;
            label9.Text = "Veuillez (re)générer les taux avant de mettre à jour les soldes";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(26, 145);
            label8.Name = "label8";
            label8.Size = new Size(73, 15);
            label8.TabIndex = 2;
            label8.Text = "Yen japonais";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(26, 103);
            label7.Name = "label7";
            label7.Size = new Size(74, 15);
            label7.TabIndex = 1;
            label7.Text = "Livre sterling";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 68);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 0;
            label6.Text = "Dollars";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label5.Location = new Point(246, 35);
            label5.Name = "label5";
            label5.Size = new Size(317, 30);
            label5.TabIndex = 0;
            label5.Text = "Mise à jour: Compte bancaire";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(label18);
            tabPage4.Controls.Add(dateTimePicker2);
            tabPage4.Controls.Add(dateTimePicker1);
            tabPage4.Controls.Add(labelError);
            tabPage4.Controls.Add(label15);
            tabPage4.Controls.Add(comboBox1);
            tabPage4.Controls.Add(button4);
            tabPage4.Controls.Add(label12);
            tabPage4.Controls.Add(label11);
            tabPage4.Controls.Add(label10);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(777, 407);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Transaction entre deux dates";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.ForeColor = Color.Green;
            label18.Location = new Point(277, 317);
            label18.Name = "label18";
            label18.Size = new Size(23, 15);
            label18.TabIndex = 12;
            label18.Text = "OK";
            label18.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(374, 226);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(374, 176);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 10;
            // 
            // labelError
            // 
            labelError.AutoSize = true;
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(242, 65);
            labelError.Name = "labelError";
            labelError.Size = new Size(38, 15);
            labelError.TabIndex = 9;
            labelError.Text = "Erreur";
            labelError.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.ForeColor = SystemColors.ActiveCaptionText;
            label15.Location = new Point(178, 138);
            label15.Name = "label15";
            label15.Size = new Size(190, 15);
            label15.TabIndex = 8;
            label15.Text = "Sélectionner un compte bancaire : ";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(374, 135);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(161, 23);
            comboBox1.TabIndex = 7;
            // 
            // button4
            // 
            button4.Location = new Point(301, 277);
            button4.Name = "button4";
            button4.Size = new Size(128, 23);
            button4.TabIndex = 6;
            button4.Text = "Générer rapport XML";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(309, 232);
            label12.Name = "label12";
            label12.Size = new Size(48, 15);
            label12.TabIndex = 4;
            label12.Text = "Date fin";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(292, 182);
            label11.Name = "label11";
            label11.Size = new Size(65, 15);
            label11.TabIndex = 3;
            label11.Text = "Date début";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label10.Location = new Point(222, 25);
            label10.Name = "label10";
            label10.Size = new Size(313, 30);
            label10.TabIndex = 0;
            label10.Text = "Transaction entre deux dates";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Button button1;
        private TextBox mdpBox;
        private TextBox indentBox;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox livreBox;
        private TextBox dollarsBox;
        private Label label9;
        private Button button2;
        private TextBox yenBox;
        private Button button4;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private ComboBox comboBox1;
        //private Label labelError2;
        private Label labelError;
        private Label label17;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label18;
        private Button button5;
    }
}