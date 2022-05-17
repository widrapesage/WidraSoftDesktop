namespace WidraSoft.UI
{
    partial class FirmeDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirmeDetail));
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btSupprimer = new System.Windows.Forms.Button();
            this.btModifier = new System.Windows.Forms.Button();
            this.btAjouter = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDateCreation = new System.Windows.Forms.TextBox();
            this.txtBadge = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdresse = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodePostal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLocalite = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPays = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNumTVA = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSiteWebUrl = new System.Windows.Forms.TextBox();
            this.chx_Valide = new System.Windows.Forms.CheckBox();
            this.chx_Bloque = new System.Windows.Forms.CheckBox();
            this.txtBlocage = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chx_Attention = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAlerte = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtObservations = new System.Windows.Forms.TextBox();
            this.txtValide = new System.Windows.Forms.TextBox();
            this.txtBloque = new System.Windows.Forms.TextBox();
            this.txtAttention = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.splitter2, "splitter2");
            this.splitter2.Name = "splitter2";
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.MediumSeaGreen;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btSupprimer);
            this.groupBox1.Controls.Add(this.btModifier);
            this.groupBox1.Controls.Add(this.btAjouter);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btSupprimer
            // 
            this.btSupprimer.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btSupprimer, "btSupprimer");
            this.btSupprimer.ForeColor = System.Drawing.Color.Black;
            this.btSupprimer.Image = global::WidraSoft.UI.Properties.Resources.button_delete;
            this.btSupprimer.Name = "btSupprimer";
            this.btSupprimer.UseVisualStyleBackColor = false;
            this.btSupprimer.Click += new System.EventHandler(this.btSupprimer_Click);
            this.btSupprimer.MouseEnter += new System.EventHandler(this.btSupprimer_MouseEnter);
            this.btSupprimer.MouseLeave += new System.EventHandler(this.btSupprimer_MouseLeave);
            // 
            // btModifier
            // 
            this.btModifier.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btModifier.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btModifier, "btModifier");
            this.btModifier.ForeColor = System.Drawing.Color.Black;
            this.btModifier.Image = global::WidraSoft.UI.Properties.Resources.button_edit;
            this.btModifier.Name = "btModifier";
            this.btModifier.UseVisualStyleBackColor = false;
            this.btModifier.Click += new System.EventHandler(this.btModifier_Click);
            this.btModifier.MouseEnter += new System.EventHandler(this.btModifier_MouseEnter);
            this.btModifier.MouseLeave += new System.EventHandler(this.btModifier_MouseLeave);
            // 
            // btAjouter
            // 
            this.btAjouter.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btAjouter, "btAjouter");
            this.btAjouter.ForeColor = System.Drawing.Color.Black;
            this.btAjouter.Image = global::WidraSoft.UI.Properties.Resources.button_add;
            this.btAjouter.Name = "btAjouter";
            this.btAjouter.UseVisualStyleBackColor = false;
            this.btAjouter.Click += new System.EventHandler(this.btAjouter_Click);
            this.btAjouter.MouseEnter += new System.EventHandler(this.btAjouter_MouseEnter);
            this.btAjouter.MouseLeave += new System.EventHandler(this.btAjouter_MouseLeave);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtDateCreation
            // 
            resources.ApplyResources(this.txtDateCreation, "txtDateCreation");
            this.txtDateCreation.Name = "txtDateCreation";
            this.txtDateCreation.ReadOnly = true;
            // 
            // txtBadge
            // 
            resources.ApplyResources(this.txtBadge, "txtBadge");
            this.txtBadge.Name = "txtBadge";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtId
            // 
            resources.ApplyResources(this.txtId, "txtId");
            this.txtId.Name = "txtId";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtDesignation
            // 
            resources.ApplyResources(this.txtDesignation, "txtDesignation");
            this.txtDesignation.Name = "txtDesignation";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtAdresse
            // 
            resources.ApplyResources(this.txtAdresse, "txtAdresse");
            this.txtAdresse.Name = "txtAdresse";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtCodePostal
            // 
            resources.ApplyResources(this.txtCodePostal, "txtCodePostal");
            this.txtCodePostal.Name = "txtCodePostal";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtLocalite
            // 
            resources.ApplyResources(this.txtLocalite, "txtLocalite");
            this.txtLocalite.Name = "txtLocalite";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtPays
            // 
            resources.ApplyResources(this.txtPays, "txtPays");
            this.txtPays.Name = "txtPays";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // txtTelephone
            // 
            resources.ApplyResources(this.txtTelephone, "txtTelephone");
            this.txtTelephone.Name = "txtTelephone";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // txtEmail
            // 
            resources.ApplyResources(this.txtEmail, "txtEmail");
            this.txtEmail.Name = "txtEmail";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // txtNumTVA
            // 
            resources.ApplyResources(this.txtNumTVA, "txtNumTVA");
            this.txtNumTVA.Name = "txtNumTVA";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // txtSiteWebUrl
            // 
            resources.ApplyResources(this.txtSiteWebUrl, "txtSiteWebUrl");
            this.txtSiteWebUrl.Name = "txtSiteWebUrl";
            // 
            // chx_Valide
            // 
            resources.ApplyResources(this.chx_Valide, "chx_Valide");
            this.chx_Valide.Name = "chx_Valide";
            this.chx_Valide.UseVisualStyleBackColor = true;
            this.chx_Valide.CheckedChanged += new System.EventHandler(this.chx_Valide_CheckedChanged);
            // 
            // chx_Bloque
            // 
            resources.ApplyResources(this.chx_Bloque, "chx_Bloque");
            this.chx_Bloque.Name = "chx_Bloque";
            this.chx_Bloque.UseVisualStyleBackColor = true;
            this.chx_Bloque.CheckedChanged += new System.EventHandler(this.chx_Bloque_CheckedChanged);
            // 
            // txtBlocage
            // 
            resources.ApplyResources(this.txtBlocage, "txtBlocage");
            this.txtBlocage.Name = "txtBlocage";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // chx_Attention
            // 
            resources.ApplyResources(this.chx_Attention, "chx_Attention");
            this.chx_Attention.Name = "chx_Attention";
            this.chx_Attention.UseVisualStyleBackColor = true;
            this.chx_Attention.CheckedChanged += new System.EventHandler(this.chx_Attention_CheckedChanged);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // txtAlerte
            // 
            resources.ApplyResources(this.txtAlerte, "txtAlerte");
            this.txtAlerte.Name = "txtAlerte";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // txtObservations
            // 
            resources.ApplyResources(this.txtObservations, "txtObservations");
            this.txtObservations.Name = "txtObservations";
            // 
            // txtValide
            // 
            resources.ApplyResources(this.txtValide, "txtValide");
            this.txtValide.Name = "txtValide";
            // 
            // txtBloque
            // 
            resources.ApplyResources(this.txtBloque, "txtBloque");
            this.txtBloque.Name = "txtBloque";
            // 
            // txtAttention
            // 
            resources.ApplyResources(this.txtAttention, "txtAttention");
            this.txtAttention.Name = "txtAttention";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // FirmeDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtAttention);
            this.Controls.Add(this.txtBloque);
            this.Controls.Add(this.txtValide);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtObservations);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtAlerte);
            this.Controls.Add(this.chx_Attention);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtBlocage);
            this.Controls.Add(this.chx_Bloque);
            this.Controls.Add(this.chx_Valide);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtSiteWebUrl);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtNumTVA);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPays);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLocalite);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCodePostal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAdresse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDesignation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDateCreation);
            this.Controls.Add(this.txtBadge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.MaximizeBox = false;
            this.Name = "FirmeDetail";
            this.Load += new System.EventHandler(this.FirmeDetail_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btSupprimer;
        private System.Windows.Forms.Button btModifier;
        private System.Windows.Forms.Button btAjouter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDateCreation;
        private System.Windows.Forms.TextBox txtBadge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAdresse;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodePostal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLocalite;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPays;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNumTVA;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSiteWebUrl;
        private System.Windows.Forms.CheckBox chx_Valide;
        private System.Windows.Forms.CheckBox chx_Bloque;
        private System.Windows.Forms.TextBox txtBlocage;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chx_Attention;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAlerte;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtObservations;
        private System.Windows.Forms.TextBox txtValide;
        private System.Windows.Forms.TextBox txtBloque;
        private System.Windows.Forms.TextBox txtAttention;
        private System.Windows.Forms.Label label16;
    }
}