
namespace WidraSoft.UI
{
    partial class UtilisateurSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UtilisateurSearch));
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.cbGroupe = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btRecherche = new System.Windows.Forms.Button();
            this.btAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.Gray;
            this.splitter2.Enabled = false;
            this.splitter2.Location = new System.Drawing.Point(24, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(10, 436);
            this.splitter2.TabIndex = 17;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(24, 436);
            this.splitter1.TabIndex = 16;
            this.splitter1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Capriola", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label1.Location = new System.Drawing.Point(48, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 35);
            this.label1.TabIndex = 18;
            this.label1.Text = "Rechercher par:";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(184, 92);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(396, 31);
            this.txtNom.TabIndex = 19;
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(184, 139);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(396, 31);
            this.txtPrenom.TabIndex = 20;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(184, 186);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(396, 31);
            this.txtLogin.TabIndex = 21;
            // 
            // cbGroupe
            // 
            this.cbGroupe.FormattingEnabled = true;
            this.cbGroupe.Location = new System.Drawing.Point(184, 233);
            this.cbGroupe.Name = "cbGroupe";
            this.cbGroupe.Size = new System.Drawing.Size(396, 33);
            this.cbGroupe.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "Nom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "Prénom";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 25);
            this.label4.TabIndex = 25;
            this.label4.Text = "Login";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 25);
            this.label5.TabIndex = 26;
            this.label5.Text = "Groupe";
            // 
            // btRecherche
            // 
            this.btRecherche.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btRecherche.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRecherche.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btRecherche.ForeColor = System.Drawing.Color.Black;
            this.btRecherche.Image = ((System.Drawing.Image)(resources.GetObject("btRecherche.Image")));
            this.btRecherche.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btRecherche.Location = new System.Drawing.Point(184, 305);
            this.btRecherche.Name = "btRecherche";
            this.btRecherche.Padding = new System.Windows.Forms.Padding(0, 18, 0, 6);
            this.btRecherche.Size = new System.Drawing.Size(194, 86);
            this.btRecherche.TabIndex = 27;
            this.btRecherche.Text = "Rechercher";
            this.btRecherche.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btRecherche.UseVisualStyleBackColor = false;
            this.btRecherche.Click += new System.EventHandler(this.btRecherche_Click);
            // 
            // btAnnuler
            // 
            this.btAnnuler.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btAnnuler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAnnuler.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btAnnuler.ForeColor = System.Drawing.Color.Black;
            this.btAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("btAnnuler.Image")));
            this.btAnnuler.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAnnuler.Location = new System.Drawing.Point(384, 305);
            this.btAnnuler.Name = "btAnnuler";
            this.btAnnuler.Padding = new System.Windows.Forms.Padding(0, 18, 0, 6);
            this.btAnnuler.Size = new System.Drawing.Size(196, 86);
            this.btAnnuler.TabIndex = 28;
            this.btAnnuler.Text = "Liste complète";
            this.btAnnuler.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btAnnuler.UseVisualStyleBackColor = false;
            this.btAnnuler.Click += new System.EventHandler(this.btAnnuler_Click);
            // 
            // UtilisateurSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(661, 436);
            this.Controls.Add(this.btAnnuler);
            this.Controls.Add(this.btRecherche);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbGroupe);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UtilisateurSearch";
            this.Text = "Recherche utilisateurs";
            this.Load += new System.EventHandler(this.UtilisateurSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.ComboBox cbGroupe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btRecherche;
        private System.Windows.Forms.Button btAnnuler;
    }
}