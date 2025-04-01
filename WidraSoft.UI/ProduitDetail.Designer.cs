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
            panelLang = new System.Windows.Forms.Panel();
            pbUpdating = new System.Windows.Forms.PictureBox();
            Spain_flag = new System.Windows.Forms.PictureBox();
            England_flag = new System.Windows.Forms.PictureBox();
            France_flag = new System.Windows.Forms.PictureBox();
            cbLang = new System.Windows.Forms.ComboBox();
            panelNavigation = new System.Windows.Forms.Panel();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            lbModifier = new System.Windows.Forms.LinkLabel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            lbAjouter = new System.Windows.Forms.LinkLabel();
            lbSupprimer = new System.Windows.Forms.LinkLabel();
            txtId = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            txtDateCreation = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtDesignation = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            cbGroupeProduitId = new System.Windows.Forms.ComboBox();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            chx_EstEntrant = new System.Windows.Forms.CheckBox();
            label4 = new System.Windows.Forms.Label();
            chx_Valide = new System.Windows.Forms.CheckBox();
            chx_EstSortant = new System.Windows.Forms.CheckBox();
            txtEstSortant = new System.Windows.Forms.TextBox();
            txtEstEntrant = new System.Windows.Forms.TextBox();
            txtValide = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            chx_ActiverAlerteMin = new System.Windows.Forms.CheckBox();
            txtActiverAlerteMin = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            chx_ActiverAlerteMax = new System.Windows.Forms.CheckBox();
            txtActiverAlerteMax = new System.Windows.Forms.TextBox();
            txtPoidsAlerteMin = new System.Windows.Forms.TextBox();
            txtPoidsAlerteMax = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            chx_EmpecherTicketSiAlerte = new System.Windows.Forms.CheckBox();
            txtEmpecherTicketSiAlerte = new System.Windows.Forms.TextBox();
            label11 = new System.Windows.Forms.Label();
            chx_Dechet = new System.Windows.Forms.CheckBox();
            txtDechet = new System.Windows.Forms.TextBox();
            label12 = new System.Windows.Forms.Label();
            cbTypeDechetId = new System.Windows.Forms.ComboBox();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            panelDetail = new System.Windows.Forms.Panel();
            pictureBox12 = new System.Windows.Forms.PictureBox();
            panelLang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUpdating).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Spain_flag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)England_flag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)France_flag).BeginInit();
            panelNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).BeginInit();
            SuspendLayout();
            // 
            // panelLang
            // 
            panelLang.BackColor = System.Drawing.Color.FromArgb(72, 86, 81);
            panelLang.Controls.Add(pbUpdating);
            panelLang.Controls.Add(Spain_flag);
            panelLang.Controls.Add(England_flag);
            panelLang.Controls.Add(France_flag);
            panelLang.Controls.Add(cbLang);
            resources.ApplyResources(panelLang, "panelLang");
            panelLang.Name = "panelLang";
            // 
            // pbUpdating
            // 
            pbUpdating.Image = Properties.Resources.pencil;
            resources.ApplyResources(pbUpdating, "pbUpdating");
            pbUpdating.Name = "pbUpdating";
            pbUpdating.TabStop = false;
            // 
            // Spain_flag
            // 
            Spain_flag.BackColor = System.Drawing.Color.Transparent;
            Spain_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            Spain_flag.Image = Properties.Resources.spain;
            resources.ApplyResources(Spain_flag, "Spain_flag");
            Spain_flag.Name = "Spain_flag";
            Spain_flag.TabStop = false;
            // 
            // England_flag
            // 
            England_flag.BackColor = System.Drawing.Color.Transparent;
            England_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            England_flag.Image = Properties.Resources.united_kingdom;
            resources.ApplyResources(England_flag, "England_flag");
            England_flag.Name = "England_flag";
            England_flag.TabStop = false;
            // 
            // France_flag
            // 
            France_flag.BackColor = System.Drawing.Color.Transparent;
            France_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            France_flag.Image = Properties.Resources.france;
            resources.ApplyResources(France_flag, "France_flag");
            France_flag.Name = "France_flag";
            France_flag.TabStop = false;
            // 
            // cbLang
            // 
            cbLang.BackColor = System.Drawing.Color.FromArgb(72, 86, 77);
            cbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(cbLang, "cbLang");
            cbLang.ForeColor = System.Drawing.Color.White;
            cbLang.FormattingEnabled = true;
            cbLang.Name = "cbLang";
            cbLang.SelectedIndexChanged += cbLang_SelectedIndexChanged;
            // 
            // panelNavigation
            // 
            panelNavigation.BackColor = System.Drawing.Color.FromArgb(58, 62, 60);
            panelNavigation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelNavigation.Controls.Add(pictureBox3);
            panelNavigation.Controls.Add(lbModifier);
            panelNavigation.Controls.Add(pictureBox1);
            panelNavigation.Controls.Add(pictureBox2);
            panelNavigation.Controls.Add(lbAjouter);
            panelNavigation.Controls.Add(lbSupprimer);
            resources.ApplyResources(panelNavigation, "panelNavigation");
            panelNavigation.Name = "panelNavigation";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = System.Drawing.Color.Transparent;
            pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox3.Image = Properties.Resources.update;
            resources.ApplyResources(pictureBox3, "pictureBox3");
            pictureBox3.Name = "pictureBox3";
            pictureBox3.TabStop = false;
            // 
            // lbModifier
            // 
            lbModifier.ActiveLinkColor = System.Drawing.Color.FromArgb(72, 190, 117);
            resources.ApplyResources(lbModifier, "lbModifier");
            lbModifier.BackColor = System.Drawing.Color.Transparent;
            lbModifier.ForeColor = System.Drawing.Color.White;
            lbModifier.LinkColor = System.Drawing.Color.White;
            lbModifier.Name = "lbModifier";
            lbModifier.TabStop = true;
            lbModifier.LinkClicked += lbModifier_LinkClicked;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox1.Image = Properties.Resources.remove;
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox2.Image = Properties.Resources.add;
            resources.ApplyResources(pictureBox2, "pictureBox2");
            pictureBox2.Name = "pictureBox2";
            pictureBox2.TabStop = false;
            // 
            // lbAjouter
            // 
            lbAjouter.ActiveLinkColor = System.Drawing.Color.FromArgb(72, 190, 117);
            resources.ApplyResources(lbAjouter, "lbAjouter");
            lbAjouter.BackColor = System.Drawing.Color.Transparent;
            lbAjouter.ForeColor = System.Drawing.Color.White;
            lbAjouter.LinkColor = System.Drawing.Color.White;
            lbAjouter.Name = "lbAjouter";
            lbAjouter.TabStop = true;
            lbAjouter.LinkClicked += lbAjouter_LinkClicked;
            // 
            // lbSupprimer
            // 
            lbSupprimer.ActiveLinkColor = System.Drawing.Color.FromArgb(72, 190, 117);
            resources.ApplyResources(lbSupprimer, "lbSupprimer");
            lbSupprimer.BackColor = System.Drawing.Color.Transparent;
            lbSupprimer.ForeColor = System.Drawing.Color.White;
            lbSupprimer.LinkColor = System.Drawing.Color.White;
            lbSupprimer.Name = "lbSupprimer";
            lbSupprimer.TabStop = true;
            lbSupprimer.LinkClicked += lbSupprimer_LinkClicked;
            // 
            // txtId
            // 
            txtId.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(txtId, "txtId");
            txtId.ForeColor = System.Drawing.Color.Black;
            txtId.Name = "txtId";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = System.Drawing.Color.White;
            label1.Name = "label1";
            // 
            // txtDateCreation
            // 
            txtDateCreation.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(txtDateCreation, "txtDateCreation");
            txtDateCreation.ForeColor = System.Drawing.Color.Black;
            txtDateCreation.Name = "txtDateCreation";
            txtDateCreation.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = System.Drawing.Color.White;
            label2.Name = "label2";
            // 
            // txtDesignation
            // 
            txtDesignation.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(txtDesignation, "txtDesignation");
            txtDesignation.ForeColor = System.Drawing.Color.Black;
            txtDesignation.Name = "txtDesignation";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = System.Drawing.Color.White;
            label3.Name = "label3";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.ForeColor = System.Drawing.Color.White;
            label7.Name = "label7";
            // 
            // cbGroupeProduitId
            // 
            cbGroupeProduitId.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(cbGroupeProduitId, "cbGroupeProduitId");
            cbGroupeProduitId.FormattingEnabled = true;
            cbGroupeProduitId.Name = "cbGroupeProduitId";
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.ForeColor = System.Drawing.Color.White;
            label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.ForeColor = System.Drawing.Color.White;
            label8.Name = "label8";
            // 
            // chx_EstEntrant
            // 
            resources.ApplyResources(chx_EstEntrant, "chx_EstEntrant");
            chx_EstEntrant.ForeColor = System.Drawing.Color.White;
            chx_EstEntrant.Name = "chx_EstEntrant";
            chx_EstEntrant.UseVisualStyleBackColor = true;
            chx_EstEntrant.CheckedChanged += chx_EstEntrant_CheckedChanged;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.ForeColor = System.Drawing.Color.White;
            label4.Name = "label4";
            // 
            // chx_Valide
            // 
            resources.ApplyResources(chx_Valide, "chx_Valide");
            chx_Valide.ForeColor = System.Drawing.Color.White;
            chx_Valide.Name = "chx_Valide";
            chx_Valide.UseVisualStyleBackColor = true;
            chx_Valide.CheckedChanged += chx_Valide_CheckedChanged;
            // 
            // chx_EstSortant
            // 
            resources.ApplyResources(chx_EstSortant, "chx_EstSortant");
            chx_EstSortant.ForeColor = System.Drawing.Color.White;
            chx_EstSortant.Name = "chx_EstSortant";
            chx_EstSortant.UseVisualStyleBackColor = true;
            chx_EstSortant.CheckedChanged += chx_EstSortant_CheckedChanged;
            // 
            // txtEstSortant
            // 
            resources.ApplyResources(txtEstSortant, "txtEstSortant");
            txtEstSortant.Name = "txtEstSortant";
            // 
            // txtEstEntrant
            // 
            resources.ApplyResources(txtEstEntrant, "txtEstEntrant");
            txtEstEntrant.Name = "txtEstEntrant";
            // 
            // txtValide
            // 
            resources.ApplyResources(txtValide, "txtValide");
            txtValide.Name = "txtValide";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.ForeColor = System.Drawing.Color.White;
            label5.Name = "label5";
            // 
            // chx_ActiverAlerteMin
            // 
            resources.ApplyResources(chx_ActiverAlerteMin, "chx_ActiverAlerteMin");
            chx_ActiverAlerteMin.ForeColor = System.Drawing.Color.White;
            chx_ActiverAlerteMin.Name = "chx_ActiverAlerteMin";
            chx_ActiverAlerteMin.UseVisualStyleBackColor = true;
            chx_ActiverAlerteMin.CheckedChanged += chx_ActiverAlerteMin_CheckedChanged;
            // 
            // txtActiverAlerteMin
            // 
            resources.ApplyResources(txtActiverAlerteMin, "txtActiverAlerteMin");
            txtActiverAlerteMin.Name = "txtActiverAlerteMin";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.ForeColor = System.Drawing.Color.White;
            label6.Name = "label6";
            // 
            // chx_ActiverAlerteMax
            // 
            resources.ApplyResources(chx_ActiverAlerteMax, "chx_ActiverAlerteMax");
            chx_ActiverAlerteMax.ForeColor = System.Drawing.Color.White;
            chx_ActiverAlerteMax.Name = "chx_ActiverAlerteMax";
            chx_ActiverAlerteMax.UseVisualStyleBackColor = true;
            chx_ActiverAlerteMax.CheckedChanged += chx_ActiverAlerteMax_CheckedChanged;
            // 
            // txtActiverAlerteMax
            // 
            resources.ApplyResources(txtActiverAlerteMax, "txtActiverAlerteMax");
            txtActiverAlerteMax.Name = "txtActiverAlerteMax";
            // 
            // txtPoidsAlerteMin
            // 
            txtPoidsAlerteMin.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(txtPoidsAlerteMin, "txtPoidsAlerteMin");
            txtPoidsAlerteMin.ForeColor = System.Drawing.Color.Black;
            txtPoidsAlerteMin.Name = "txtPoidsAlerteMin";
            // 
            // txtPoidsAlerteMax
            // 
            txtPoidsAlerteMax.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(txtPoidsAlerteMax, "txtPoidsAlerteMax");
            txtPoidsAlerteMax.ForeColor = System.Drawing.Color.Black;
            txtPoidsAlerteMax.Name = "txtPoidsAlerteMax";
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.ForeColor = System.Drawing.Color.White;
            label10.Name = "label10";
            // 
            // chx_EmpecherTicketSiAlerte
            // 
            resources.ApplyResources(chx_EmpecherTicketSiAlerte, "chx_EmpecherTicketSiAlerte");
            chx_EmpecherTicketSiAlerte.ForeColor = System.Drawing.Color.White;
            chx_EmpecherTicketSiAlerte.Name = "chx_EmpecherTicketSiAlerte";
            chx_EmpecherTicketSiAlerte.UseVisualStyleBackColor = true;
            chx_EmpecherTicketSiAlerte.CheckedChanged += chx_EmpecherTicketSiAlerte_CheckedChanged;
            // 
            // txtEmpecherTicketSiAlerte
            // 
            resources.ApplyResources(txtEmpecherTicketSiAlerte, "txtEmpecherTicketSiAlerte");
            txtEmpecherTicketSiAlerte.Name = "txtEmpecherTicketSiAlerte";
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.ForeColor = System.Drawing.Color.White;
            label11.Name = "label11";
            // 
            // chx_Dechet
            // 
            resources.ApplyResources(chx_Dechet, "chx_Dechet");
            chx_Dechet.ForeColor = System.Drawing.Color.White;
            chx_Dechet.Name = "chx_Dechet";
            chx_Dechet.UseVisualStyleBackColor = true;
            chx_Dechet.CheckedChanged += chx_Dechet_CheckedChanged;
            // 
            // txtDechet
            // 
            resources.ApplyResources(txtDechet, "txtDechet");
            txtDechet.Name = "txtDechet";
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.ForeColor = System.Drawing.Color.White;
            label12.Name = "label12";
            // 
            // cbTypeDechetId
            // 
            cbTypeDechetId.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(cbTypeDechetId, "cbTypeDechetId");
            cbTypeDechetId.FormattingEnabled = true;
            cbTypeDechetId.Name = "cbTypeDechetId";
            // 
            // label13
            // 
            resources.ApplyResources(label13, "label13");
            label13.ForeColor = System.Drawing.Color.White;
            label13.Name = "label13";
            // 
            // label14
            // 
            resources.ApplyResources(label14, "label14");
            label14.ForeColor = System.Drawing.Color.White;
            label14.Name = "label14";
            // 
            // panelDetail
            // 
            panelDetail.BackColor = System.Drawing.Color.FromArgb(72, 86, 81);
            panelDetail.Controls.Add(pictureBox12);
            panelDetail.Controls.Add(txtId);
            panelDetail.Controls.Add(label14);
            panelDetail.Controls.Add(label2);
            panelDetail.Controls.Add(label13);
            panelDetail.Controls.Add(txtDateCreation);
            panelDetail.Controls.Add(label12);
            panelDetail.Controls.Add(label1);
            panelDetail.Controls.Add(cbTypeDechetId);
            panelDetail.Controls.Add(label3);
            panelDetail.Controls.Add(label11);
            panelDetail.Controls.Add(txtDesignation);
            panelDetail.Controls.Add(chx_Dechet);
            panelDetail.Controls.Add(cbGroupeProduitId);
            panelDetail.Controls.Add(txtDechet);
            panelDetail.Controls.Add(label7);
            panelDetail.Controls.Add(label10);
            panelDetail.Controls.Add(txtValide);
            panelDetail.Controls.Add(chx_EmpecherTicketSiAlerte);
            panelDetail.Controls.Add(txtEstEntrant);
            panelDetail.Controls.Add(txtEmpecherTicketSiAlerte);
            panelDetail.Controls.Add(txtEstSortant);
            panelDetail.Controls.Add(txtPoidsAlerteMax);
            panelDetail.Controls.Add(chx_EstSortant);
            panelDetail.Controls.Add(txtPoidsAlerteMin);
            panelDetail.Controls.Add(chx_Valide);
            panelDetail.Controls.Add(label6);
            panelDetail.Controls.Add(label4);
            panelDetail.Controls.Add(chx_ActiverAlerteMax);
            panelDetail.Controls.Add(chx_EstEntrant);
            panelDetail.Controls.Add(txtActiverAlerteMax);
            panelDetail.Controls.Add(label8);
            panelDetail.Controls.Add(label5);
            panelDetail.Controls.Add(label9);
            panelDetail.Controls.Add(chx_ActiverAlerteMin);
            panelDetail.Controls.Add(txtActiverAlerteMin);
            resources.ApplyResources(panelDetail, "panelDetail");
            panelDetail.Name = "panelDetail";
            // 
            // pictureBox12
            // 
            pictureBox12.Image = Properties.Resources.asterisk;
            resources.ApplyResources(pictureBox12, "pictureBox12");
            pictureBox12.Name = "pictureBox12";
            pictureBox12.TabStop = false;
            // 
            // ProduitDetail
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(58, 62, 60);
            Controls.Add(panelDetail);
            Controls.Add(panelNavigation);
            Controls.Add(panelLang);
            MaximizeBox = false;
            Name = "ProduitDetail";
            FormClosing += ProduitDetail_FormClosing;
            Load += ProduitDetail_Load;
            panelLang.ResumeLayout(false);
            panelLang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbUpdating).EndInit();
            ((System.ComponentModel.ISupportInitialize)Spain_flag).EndInit();
            ((System.ComponentModel.ISupportInitialize)England_flag).EndInit();
            ((System.ComponentModel.ISupportInitialize)France_flag).EndInit();
            panelNavigation.ResumeLayout(false);
            panelNavigation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelDetail.ResumeLayout(false);
            panelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).EndInit();
            ResumeLayout(false);
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
        private System.Windows.Forms.PictureBox pictureBox12;
    }
}