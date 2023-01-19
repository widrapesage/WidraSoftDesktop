namespace WidraSoft.UI
{
    partial class ProduitDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProduitDetail));
            this.panelLang = new System.Windows.Forms.Panel();
            this.pbUpdating = new System.Windows.Forms.PictureBox();
            this.Spain_flag = new System.Windows.Forms.PictureBox();
            this.England_flag = new System.Windows.Forms.PictureBox();
            this.France_flag = new System.Windows.Forms.PictureBox();
            this.cbLang = new System.Windows.Forms.ComboBox();
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lbModifier = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbAjouter = new System.Windows.Forms.LinkLabel();
            this.lbSupprimer = new System.Windows.Forms.LinkLabel();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDateCreation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbGroupeProduitId = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chx_EstEntrant = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chx_Valide = new System.Windows.Forms.CheckBox();
            this.chx_EstSortant = new System.Windows.Forms.CheckBox();
            this.txtEstSortant = new System.Windows.Forms.TextBox();
            this.txtEstEntrant = new System.Windows.Forms.TextBox();
            this.txtValide = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chx_ActiverAlerteMin = new System.Windows.Forms.CheckBox();
            this.txtActiverAlerteMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chx_ActiverAlerteMax = new System.Windows.Forms.CheckBox();
            this.txtActiverAlerteMax = new System.Windows.Forms.TextBox();
            this.txtPoidsAlerteMin = new System.Windows.Forms.TextBox();
            this.txtPoidsAlerteMax = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chx_EmpecherTicketSiAlerte = new System.Windows.Forms.CheckBox();
            this.txtEmpecherTicketSiAlerte = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chx_Dechet = new System.Windows.Forms.CheckBox();
            this.txtDechet = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbTypeDechetId = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.panelLang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpdating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spain_flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.England_flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.France_flag)).BeginInit();
            this.panelNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLang
            // 
            this.panelLang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.panelLang.Controls.Add(this.pbUpdating);
            this.panelLang.Controls.Add(this.Spain_flag);
            this.panelLang.Controls.Add(this.England_flag);
            this.panelLang.Controls.Add(this.France_flag);
            this.panelLang.Controls.Add(this.cbLang);
            resources.ApplyResources(this.panelLang, "panelLang");
            this.panelLang.Name = "panelLang";
            // 
            // pbUpdating
            // 
            this.pbUpdating.Image = global::WidraSoft.UI.Properties.Resources.pencil;
            resources.ApplyResources(this.pbUpdating, "pbUpdating");
            this.pbUpdating.Name = "pbUpdating";
            this.pbUpdating.TabStop = false;
            // 
            // Spain_flag
            // 
            this.Spain_flag.BackColor = System.Drawing.Color.Transparent;
            this.Spain_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Spain_flag.Image = global::WidraSoft.UI.Properties.Resources.spain;
            resources.ApplyResources(this.Spain_flag, "Spain_flag");
            this.Spain_flag.Name = "Spain_flag";
            this.Spain_flag.TabStop = false;
            // 
            // England_flag
            // 
            this.England_flag.BackColor = System.Drawing.Color.Transparent;
            this.England_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.England_flag.Image = global::WidraSoft.UI.Properties.Resources.united_kingdom;
            resources.ApplyResources(this.England_flag, "England_flag");
            this.England_flag.Name = "England_flag";
            this.England_flag.TabStop = false;
            // 
            // France_flag
            // 
            this.France_flag.BackColor = System.Drawing.Color.Transparent;
            this.France_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.France_flag.Image = global::WidraSoft.UI.Properties.Resources.france;
            resources.ApplyResources(this.France_flag, "France_flag");
            this.France_flag.Name = "France_flag";
            this.France_flag.TabStop = false;
            // 
            // cbLang
            // 
            this.cbLang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(77)))));
            this.cbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbLang, "cbLang");
            this.cbLang.ForeColor = System.Drawing.Color.White;
            this.cbLang.FormattingEnabled = true;
            this.cbLang.Name = "cbLang";
            this.cbLang.SelectedIndexChanged += new System.EventHandler(this.cbLang_SelectedIndexChanged);
            // 
            // panelNavigation
            // 
            this.panelNavigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.panelNavigation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNavigation.Controls.Add(this.pictureBox3);
            this.panelNavigation.Controls.Add(this.lbModifier);
            this.panelNavigation.Controls.Add(this.pictureBox1);
            this.panelNavigation.Controls.Add(this.pictureBox2);
            this.panelNavigation.Controls.Add(this.lbAjouter);
            this.panelNavigation.Controls.Add(this.lbSupprimer);
            resources.ApplyResources(this.panelNavigation, "panelNavigation");
            this.panelNavigation.Name = "panelNavigation";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::WidraSoft.UI.Properties.Resources.update;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // lbModifier
            // 
            this.lbModifier.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            resources.ApplyResources(this.lbModifier, "lbModifier");
            this.lbModifier.BackColor = System.Drawing.Color.Transparent;
            this.lbModifier.ForeColor = System.Drawing.Color.White;
            this.lbModifier.LinkColor = System.Drawing.Color.White;
            this.lbModifier.Name = "lbModifier";
            this.lbModifier.TabStop = true;
            this.lbModifier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbModifier_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::WidraSoft.UI.Properties.Resources.remove;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::WidraSoft.UI.Properties.Resources.add;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // lbAjouter
            // 
            this.lbAjouter.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            resources.ApplyResources(this.lbAjouter, "lbAjouter");
            this.lbAjouter.BackColor = System.Drawing.Color.Transparent;
            this.lbAjouter.ForeColor = System.Drawing.Color.White;
            this.lbAjouter.LinkColor = System.Drawing.Color.White;
            this.lbAjouter.Name = "lbAjouter";
            this.lbAjouter.TabStop = true;
            this.lbAjouter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbAjouter_LinkClicked);
            // 
            // lbSupprimer
            // 
            this.lbSupprimer.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            resources.ApplyResources(this.lbSupprimer, "lbSupprimer");
            this.lbSupprimer.BackColor = System.Drawing.Color.Transparent;
            this.lbSupprimer.ForeColor = System.Drawing.Color.White;
            this.lbSupprimer.LinkColor = System.Drawing.Color.White;
            this.lbSupprimer.Name = "lbSupprimer";
            this.lbSupprimer.TabStop = true;
            this.lbSupprimer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbSupprimer_LinkClicked);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtId, "txtId");
            this.txtId.ForeColor = System.Drawing.Color.Black;
            this.txtId.Name = "txtId";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // txtDateCreation
            // 
            this.txtDateCreation.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtDateCreation, "txtDateCreation");
            this.txtDateCreation.ForeColor = System.Drawing.Color.Black;
            this.txtDateCreation.Name = "txtDateCreation";
            this.txtDateCreation.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // txtDesignation
            // 
            this.txtDesignation.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtDesignation, "txtDesignation");
            this.txtDesignation.ForeColor = System.Drawing.Color.Black;
            this.txtDesignation.Name = "txtDesignation";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // cbGroupeProduitId
            // 
            this.cbGroupeProduitId.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.cbGroupeProduitId, "cbGroupeProduitId");
            this.cbGroupeProduitId.FormattingEnabled = true;
            this.cbGroupeProduitId.Name = "cbGroupeProduitId";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Name = "label8";
            // 
            // chx_EstEntrant
            // 
            resources.ApplyResources(this.chx_EstEntrant, "chx_EstEntrant");
            this.chx_EstEntrant.ForeColor = System.Drawing.Color.White;
            this.chx_EstEntrant.Name = "chx_EstEntrant";
            this.chx_EstEntrant.UseVisualStyleBackColor = true;
            this.chx_EstEntrant.CheckedChanged += new System.EventHandler(this.chx_EstEntrant_CheckedChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // chx_Valide
            // 
            resources.ApplyResources(this.chx_Valide, "chx_Valide");
            this.chx_Valide.ForeColor = System.Drawing.Color.White;
            this.chx_Valide.Name = "chx_Valide";
            this.chx_Valide.UseVisualStyleBackColor = true;
            this.chx_Valide.CheckedChanged += new System.EventHandler(this.chx_Valide_CheckedChanged);
            // 
            // chx_EstSortant
            // 
            resources.ApplyResources(this.chx_EstSortant, "chx_EstSortant");
            this.chx_EstSortant.ForeColor = System.Drawing.Color.White;
            this.chx_EstSortant.Name = "chx_EstSortant";
            this.chx_EstSortant.UseVisualStyleBackColor = true;
            this.chx_EstSortant.CheckedChanged += new System.EventHandler(this.chx_EstSortant_CheckedChanged);
            // 
            // txtEstSortant
            // 
            resources.ApplyResources(this.txtEstSortant, "txtEstSortant");
            this.txtEstSortant.Name = "txtEstSortant";
            // 
            // txtEstEntrant
            // 
            resources.ApplyResources(this.txtEstEntrant, "txtEstEntrant");
            this.txtEstEntrant.Name = "txtEstEntrant";
            // 
            // txtValide
            // 
            resources.ApplyResources(this.txtValide, "txtValide");
            this.txtValide.Name = "txtValide";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // chx_ActiverAlerteMin
            // 
            resources.ApplyResources(this.chx_ActiverAlerteMin, "chx_ActiverAlerteMin");
            this.chx_ActiverAlerteMin.ForeColor = System.Drawing.Color.White;
            this.chx_ActiverAlerteMin.Name = "chx_ActiverAlerteMin";
            this.chx_ActiverAlerteMin.UseVisualStyleBackColor = true;
            this.chx_ActiverAlerteMin.CheckedChanged += new System.EventHandler(this.chx_ActiverAlerteMin_CheckedChanged);
            // 
            // txtActiverAlerteMin
            // 
            resources.ApplyResources(this.txtActiverAlerteMin, "txtActiverAlerteMin");
            this.txtActiverAlerteMin.Name = "txtActiverAlerteMin";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Name = "label6";
            // 
            // chx_ActiverAlerteMax
            // 
            resources.ApplyResources(this.chx_ActiverAlerteMax, "chx_ActiverAlerteMax");
            this.chx_ActiverAlerteMax.ForeColor = System.Drawing.Color.White;
            this.chx_ActiverAlerteMax.Name = "chx_ActiverAlerteMax";
            this.chx_ActiverAlerteMax.UseVisualStyleBackColor = true;
            this.chx_ActiverAlerteMax.CheckedChanged += new System.EventHandler(this.chx_ActiverAlerteMax_CheckedChanged);
            // 
            // txtActiverAlerteMax
            // 
            resources.ApplyResources(this.txtActiverAlerteMax, "txtActiverAlerteMax");
            this.txtActiverAlerteMax.Name = "txtActiverAlerteMax";
            // 
            // txtPoidsAlerteMin
            // 
            this.txtPoidsAlerteMin.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtPoidsAlerteMin, "txtPoidsAlerteMin");
            this.txtPoidsAlerteMin.ForeColor = System.Drawing.Color.Black;
            this.txtPoidsAlerteMin.Name = "txtPoidsAlerteMin";
            // 
            // txtPoidsAlerteMax
            // 
            this.txtPoidsAlerteMax.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtPoidsAlerteMax, "txtPoidsAlerteMax");
            this.txtPoidsAlerteMax.ForeColor = System.Drawing.Color.Black;
            this.txtPoidsAlerteMax.Name = "txtPoidsAlerteMax";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Name = "label10";
            // 
            // chx_EmpecherTicketSiAlerte
            // 
            resources.ApplyResources(this.chx_EmpecherTicketSiAlerte, "chx_EmpecherTicketSiAlerte");
            this.chx_EmpecherTicketSiAlerte.ForeColor = System.Drawing.Color.White;
            this.chx_EmpecherTicketSiAlerte.Name = "chx_EmpecherTicketSiAlerte";
            this.chx_EmpecherTicketSiAlerte.UseVisualStyleBackColor = true;
            this.chx_EmpecherTicketSiAlerte.CheckedChanged += new System.EventHandler(this.chx_EmpecherTicketSiAlerte_CheckedChanged);
            // 
            // txtEmpecherTicketSiAlerte
            // 
            resources.ApplyResources(this.txtEmpecherTicketSiAlerte, "txtEmpecherTicketSiAlerte");
            this.txtEmpecherTicketSiAlerte.Name = "txtEmpecherTicketSiAlerte";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Name = "label11";
            // 
            // chx_Dechet
            // 
            resources.ApplyResources(this.chx_Dechet, "chx_Dechet");
            this.chx_Dechet.ForeColor = System.Drawing.Color.White;
            this.chx_Dechet.Name = "chx_Dechet";
            this.chx_Dechet.UseVisualStyleBackColor = true;
            this.chx_Dechet.CheckedChanged += new System.EventHandler(this.chx_Dechet_CheckedChanged);
            // 
            // txtDechet
            // 
            resources.ApplyResources(this.txtDechet, "txtDechet");
            this.txtDechet.Name = "txtDechet";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Name = "label12";
            // 
            // cbTypeDechetId
            // 
            this.cbTypeDechetId.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.cbTypeDechetId, "cbTypeDechetId");
            this.cbTypeDechetId.FormattingEnabled = true;
            this.cbTypeDechetId.Name = "cbTypeDechetId";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Name = "label13";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Name = "label14";
            // 
            // panelDetail
            // 
            this.panelDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.panelDetail.Controls.Add(this.txtId);
            this.panelDetail.Controls.Add(this.label14);
            this.panelDetail.Controls.Add(this.label2);
            this.panelDetail.Controls.Add(this.label13);
            this.panelDetail.Controls.Add(this.txtDateCreation);
            this.panelDetail.Controls.Add(this.label12);
            this.panelDetail.Controls.Add(this.label1);
            this.panelDetail.Controls.Add(this.cbTypeDechetId);
            this.panelDetail.Controls.Add(this.label3);
            this.panelDetail.Controls.Add(this.label11);
            this.panelDetail.Controls.Add(this.txtDesignation);
            this.panelDetail.Controls.Add(this.chx_Dechet);
            this.panelDetail.Controls.Add(this.cbGroupeProduitId);
            this.panelDetail.Controls.Add(this.txtDechet);
            this.panelDetail.Controls.Add(this.label7);
            this.panelDetail.Controls.Add(this.label10);
            this.panelDetail.Controls.Add(this.txtValide);
            this.panelDetail.Controls.Add(this.chx_EmpecherTicketSiAlerte);
            this.panelDetail.Controls.Add(this.txtEstEntrant);
            this.panelDetail.Controls.Add(this.txtEmpecherTicketSiAlerte);
            this.panelDetail.Controls.Add(this.txtEstSortant);
            this.panelDetail.Controls.Add(this.txtPoidsAlerteMax);
            this.panelDetail.Controls.Add(this.chx_EstSortant);
            this.panelDetail.Controls.Add(this.txtPoidsAlerteMin);
            this.panelDetail.Controls.Add(this.chx_Valide);
            this.panelDetail.Controls.Add(this.label6);
            this.panelDetail.Controls.Add(this.label4);
            this.panelDetail.Controls.Add(this.chx_ActiverAlerteMax);
            this.panelDetail.Controls.Add(this.chx_EstEntrant);
            this.panelDetail.Controls.Add(this.txtActiverAlerteMax);
            this.panelDetail.Controls.Add(this.label8);
            this.panelDetail.Controls.Add(this.label5);
            this.panelDetail.Controls.Add(this.label9);
            this.panelDetail.Controls.Add(this.chx_ActiverAlerteMin);
            this.panelDetail.Controls.Add(this.txtActiverAlerteMin);
            resources.ApplyResources(this.panelDetail, "panelDetail");
            this.panelDetail.Name = "panelDetail";
            // 
            // ProduitDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.panelNavigation);
            this.Controls.Add(this.panelLang);
            this.MaximizeBox = false;
            this.Name = "ProduitDetail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProduitDetail_FormClosing);
            this.Load += new System.EventHandler(this.ProduitDetail_Load);
            this.panelLang.ResumeLayout(false);
            this.panelLang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpdating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spain_flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.England_flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.France_flag)).EndInit();
            this.panelNavigation.ResumeLayout(false);
            this.panelNavigation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLang;
        private System.Windows.Forms.PictureBox pbUpdating;
        private System.Windows.Forms.PictureBox Spain_flag;
        private System.Windows.Forms.PictureBox England_flag;
        private System.Windows.Forms.PictureBox France_flag;
        private System.Windows.Forms.ComboBox cbLang;
        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.LinkLabel lbModifier;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel lbAjouter;
        private System.Windows.Forms.LinkLabel lbSupprimer;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDateCreation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbGroupeProduitId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chx_EstEntrant;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chx_Valide;
        private System.Windows.Forms.CheckBox chx_EstSortant;
        private System.Windows.Forms.TextBox txtEstSortant;
        private System.Windows.Forms.TextBox txtEstEntrant;
        private System.Windows.Forms.TextBox txtValide;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chx_ActiverAlerteMin;
        private System.Windows.Forms.TextBox txtActiverAlerteMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chx_ActiverAlerteMax;
        private System.Windows.Forms.TextBox txtActiverAlerteMax;
        private System.Windows.Forms.TextBox txtPoidsAlerteMin;
        private System.Windows.Forms.TextBox txtPoidsAlerteMax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chx_EmpecherTicketSiAlerte;
        private System.Windows.Forms.TextBox txtEmpecherTicketSiAlerte;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chx_Dechet;
        private System.Windows.Forms.TextBox txtDechet;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbTypeDechetId;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panelDetail;
    }
}