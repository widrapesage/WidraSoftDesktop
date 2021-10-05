
namespace WidraSoft.UI
{
    partial class UtilisateurDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UtilisateurDetail));
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cbGroupeId = new System.Windows.Forms.ComboBox();
            this.txtDateCreation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btSupprimer = new System.Windows.Forms.Button();
            this.btModifier = new System.Windows.Forms.Button();
            this.btAjouter = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(215, 168);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(150, 31);
            this.txtId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(215, 259);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(370, 31);
            this.txtNom.TabIndex = 2;
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(215, 302);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(370, 31);
            this.txtPrenom.TabIndex = 3;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(215, 346);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(370, 31);
            this.txtLogin.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(215, 390);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(370, 31);
            this.txtPassword.TabIndex = 5;
            // 
            // cbGroupeId
            // 
            this.cbGroupeId.FormattingEnabled = true;
            this.cbGroupeId.Location = new System.Drawing.Point(215, 434);
            this.cbGroupeId.Name = "cbGroupeId";
            this.cbGroupeId.Size = new System.Drawing.Size(370, 33);
            this.cbGroupeId.TabIndex = 6;
            // 
            // txtDateCreation
            // 
            this.txtDateCreation.Location = new System.Drawing.Point(215, 215);
            this.txtDateCreation.Name = "txtDateCreation";
            this.txtDateCreation.ReadOnly = true;
            this.txtDateCreation.Size = new System.Drawing.Size(370, 31);
            this.txtDateCreation.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Date création";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nom";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Prénom";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Login";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 393);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Mot de passe";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 437);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Groupe";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(24, 678);
            this.splitter1.TabIndex = 14;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.Gray;
            this.splitter2.Enabled = false;
            this.splitter2.Location = new System.Drawing.Point(24, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(10, 678);
            this.splitter2.TabIndex = 15;
            this.splitter2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btSupprimer);
            this.groupBox1.Controls.Add(this.btModifier);
            this.groupBox1.Controls.Add(this.btAjouter);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1.Font = new System.Drawing.Font("Corbel", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.groupBox1.Location = new System.Drawing.Point(40, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(982, 133);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // btSupprimer
            // 
            this.btSupprimer.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSupprimer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btSupprimer.ForeColor = System.Drawing.Color.Black;
            this.btSupprimer.Image = global::WidraSoft.UI.Properties.Resources.button_delete;
            this.btSupprimer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSupprimer.Location = new System.Drawing.Point(603, 28);
            this.btSupprimer.Name = "btSupprimer";
            this.btSupprimer.Padding = new System.Windows.Forms.Padding(0, 18, 0, 6);
            this.btSupprimer.Size = new System.Drawing.Size(112, 86);
            this.btSupprimer.TabIndex = 2;
            this.btSupprimer.Text = "Supprimer";
            this.btSupprimer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSupprimer.UseVisualStyleBackColor = false;
            this.btSupprimer.Click += new System.EventHandler(this.btSupprimer_Click);
            this.btSupprimer.MouseEnter += new System.EventHandler(this.btSupprimer_MouseEnter);
            this.btSupprimer.MouseLeave += new System.EventHandler(this.btSupprimer_MouseLeave);
            // 
            // btModifier
            // 
            this.btModifier.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btModifier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btModifier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btModifier.ForeColor = System.Drawing.Color.Black;
            this.btModifier.Image = global::WidraSoft.UI.Properties.Resources.button_edit;
            this.btModifier.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btModifier.Location = new System.Drawing.Point(419, 28);
            this.btModifier.Name = "btModifier";
            this.btModifier.Padding = new System.Windows.Forms.Padding(0, 18, 0, 6);
            this.btModifier.Size = new System.Drawing.Size(112, 86);
            this.btModifier.TabIndex = 1;
            this.btModifier.Text = "Modifier";
            this.btModifier.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btModifier.UseVisualStyleBackColor = false;
            this.btModifier.Click += new System.EventHandler(this.btModifier_Click);
            this.btModifier.MouseEnter += new System.EventHandler(this.btModifier_MouseEnter);
            this.btModifier.MouseLeave += new System.EventHandler(this.btModifier_MouseLeave);
            // 
            // btAjouter
            // 
            this.btAjouter.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAjouter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btAjouter.ForeColor = System.Drawing.Color.Black;
            this.btAjouter.Image = global::WidraSoft.UI.Properties.Resources.button_add;
            this.btAjouter.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAjouter.Location = new System.Drawing.Point(233, 28);
            this.btAjouter.Name = "btAjouter";
            this.btAjouter.Padding = new System.Windows.Forms.Padding(0, 18, 0, 6);
            this.btAjouter.Size = new System.Drawing.Size(112, 86);
            this.btAjouter.TabIndex = 0;
            this.btAjouter.Text = "Ajouter";
            this.btAjouter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btAjouter.UseVisualStyleBackColor = false;
            this.btAjouter.Click += new System.EventHandler(this.btAjouter_Click);
            this.btAjouter.MouseEnter += new System.EventHandler(this.btAjouter_MouseEnter);
            this.btAjouter.MouseLeave += new System.EventHandler(this.btAjouter_MouseLeave);
            // 
            // UtilisateurDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1034, 678);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDateCreation);
            this.Controls.Add(this.cbGroupeId);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UtilisateurDetail";
            this.Text = "Utilisateur";
            this.Load += new System.EventHandler(this.UtilisateurDetail_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cbGroupeId;
        private System.Windows.Forms.TextBox txtDateCreation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btAjouter;
        private System.Windows.Forms.Button btSupprimer;
        private System.Windows.Forms.Button btModifier;
    }
}