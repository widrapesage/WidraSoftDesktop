namespace WidraSoft.UI
{
    partial class CamionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CamionDetail));
            this.btSupprimer = new System.Windows.Forms.Button();
            this.btModifier = new System.Windows.Forms.Button();
            this.btAjouter = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlaque = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDateCreation = new System.Windows.Forms.TextBox();
            this.txtBadge = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTare = new System.Windows.Forms.TextBox();
            this.txtAttention = new System.Windows.Forms.TextBox();
            this.txtBloque = new System.Windows.Forms.TextBox();
            this.txtValide = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtObservations = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAlerte = new System.Windows.Forms.TextBox();
            this.chx_Attention = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBlocage = new System.Windows.Forms.TextBox();
            this.chx_Bloque = new System.Windows.Forms.CheckBox();
            this.chx_Valide = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panelLang = new System.Windows.Forms.Panel();
            this.Spain_flag = new System.Windows.Forms.PictureBox();
            this.England_flag = new System.Windows.Forms.PictureBox();
            this.France_flag = new System.Windows.Forms.PictureBox();
            this.cbLang = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.panelLang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spain_flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.England_flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.France_flag)).BeginInit();
            this.SuspendLayout();
            // 
            // btSupprimer
            // 
            this.btSupprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.btSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSupprimer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.btSupprimer.FlatAppearance.BorderSize = 2;
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
            this.btModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.btModifier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btModifier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.btModifier.FlatAppearance.BorderSize = 2;
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
            this.btAjouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.btAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAjouter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.btAjouter.FlatAppearance.BorderSize = 2;
            resources.ApplyResources(this.btAjouter, "btAjouter");
            this.btAjouter.ForeColor = System.Drawing.Color.Black;
            this.btAjouter.Image = global::WidraSoft.UI.Properties.Resources.button_add;
            this.btAjouter.Name = "btAjouter";
            this.btAjouter.UseVisualStyleBackColor = false;
            this.btAjouter.Click += new System.EventHandler(this.btAjouter_Click);
            this.btAjouter.MouseEnter += new System.EventHandler(this.btAjouter_MouseEnter);
            this.btAjouter.MouseLeave += new System.EventHandler(this.btAjouter_MouseLeave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btSupprimer);
            this.groupBox1.Controls.Add(this.btModifier);
            this.groupBox1.Controls.Add(this.btAjouter);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // txtPlaque
            // 
            this.txtPlaque.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtPlaque, "txtPlaque");
            this.txtPlaque.ForeColor = System.Drawing.Color.Black;
            this.txtPlaque.Name = "txtPlaque";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // txtDateCreation
            // 
            this.txtDateCreation.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtDateCreation, "txtDateCreation");
            this.txtDateCreation.ForeColor = System.Drawing.Color.Black;
            this.txtDateCreation.Name = "txtDateCreation";
            this.txtDateCreation.ReadOnly = true;
            // 
            // txtBadge
            // 
            this.txtBadge.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtBadge, "txtBadge");
            this.txtBadge.ForeColor = System.Drawing.Color.Black;
            this.txtBadge.Name = "txtBadge";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtId, "txtId");
            this.txtId.ForeColor = System.Drawing.Color.Black;
            this.txtId.Name = "txtId";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtCode, "txtCode");
            this.txtCode.ForeColor = System.Drawing.Color.Black;
            this.txtCode.Name = "txtCode";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Name = "label6";
            // 
            // txtTare
            // 
            this.txtTare.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtTare, "txtTare");
            this.txtTare.ForeColor = System.Drawing.Color.Black;
            this.txtTare.Name = "txtTare";
            // 
            // txtAttention
            // 
            resources.ApplyResources(this.txtAttention, "txtAttention");
            this.txtAttention.Name = "txtAttention";
            // 
            // txtBloque
            // 
            resources.ApplyResources(this.txtBloque, "txtBloque");
            this.txtBloque.Name = "txtBloque";
            // 
            // txtValide
            // 
            resources.ApplyResources(this.txtValide, "txtValide");
            this.txtValide.Name = "txtValide";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Name = "label15";
            // 
            // txtObservations
            // 
            this.txtObservations.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtObservations, "txtObservations");
            this.txtObservations.ForeColor = System.Drawing.Color.Black;
            this.txtObservations.Name = "txtObservations";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Name = "label14";
            // 
            // txtAlerte
            // 
            this.txtAlerte.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtAlerte, "txtAlerte");
            this.txtAlerte.ForeColor = System.Drawing.Color.Black;
            this.txtAlerte.Name = "txtAlerte";
            // 
            // chx_Attention
            // 
            resources.ApplyResources(this.chx_Attention, "chx_Attention");
            this.chx_Attention.ForeColor = System.Drawing.Color.White;
            this.chx_Attention.Name = "chx_Attention";
            this.chx_Attention.UseVisualStyleBackColor = true;
            this.chx_Attention.CheckedChanged += new System.EventHandler(this.chx_Attention_CheckedChanged);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Name = "label13";
            // 
            // txtBlocage
            // 
            this.txtBlocage.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtBlocage, "txtBlocage");
            this.txtBlocage.ForeColor = System.Drawing.Color.Black;
            this.txtBlocage.Name = "txtBlocage";
            // 
            // chx_Bloque
            // 
            resources.ApplyResources(this.chx_Bloque, "chx_Bloque");
            this.chx_Bloque.ForeColor = System.Drawing.Color.White;
            this.chx_Bloque.Name = "chx_Bloque";
            this.chx_Bloque.UseVisualStyleBackColor = true;
            this.chx_Bloque.CheckedChanged += new System.EventHandler(this.chx_Bloque_CheckedChanged);
            // 
            // chx_Valide
            // 
            resources.ApplyResources(this.chx_Valide, "chx_Valide");
            this.chx_Valide.ForeColor = System.Drawing.Color.White;
            this.chx_Valide.Name = "chx_Valide";
            this.chx_Valide.UseVisualStyleBackColor = true;
            this.chx_Valide.CheckedChanged += new System.EventHandler(this.chx_Valide_CheckedChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Name = "label9";
            // 
            // panelLang
            // 
            this.panelLang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(77)))));
            this.panelLang.Controls.Add(this.Spain_flag);
            this.panelLang.Controls.Add(this.England_flag);
            this.panelLang.Controls.Add(this.France_flag);
            this.panelLang.Controls.Add(this.cbLang);
            resources.ApplyResources(this.panelLang, "panelLang");
            this.panelLang.Name = "panelLang";
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
            // CamionDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.txtPlaque);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelLang);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtAlerte);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBlocage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chx_Bloque);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtBadge);
            this.Controls.Add(this.chx_Valide);
            this.Controls.Add(this.txtDateCreation);
            this.Controls.Add(this.chx_Attention);
            this.Controls.Add(this.txtAttention);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTare);
            this.Controls.Add(this.txtBloque);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtValide);
            this.Controls.Add(this.txtObservations);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label15);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.Name = "CamionDetail";
            this.Load += new System.EventHandler(this.CamionDetail_Load);
            this.groupBox1.ResumeLayout(false);
            this.panelLang.ResumeLayout(false);
            this.panelLang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spain_flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.England_flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.France_flag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btSupprimer;
        private System.Windows.Forms.Button btModifier;
        private System.Windows.Forms.Button btAjouter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPlaque;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDateCreation;
        private System.Windows.Forms.TextBox txtBadge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTare;
        private System.Windows.Forms.TextBox txtAttention;
        private System.Windows.Forms.TextBox txtBloque;
        private System.Windows.Forms.TextBox txtValide;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtObservations;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAlerte;
        private System.Windows.Forms.CheckBox chx_Attention;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBlocage;
        private System.Windows.Forms.CheckBox chx_Bloque;
        private System.Windows.Forms.CheckBox chx_Valide;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelLang;
        private System.Windows.Forms.PictureBox Spain_flag;
        private System.Windows.Forms.PictureBox England_flag;
        private System.Windows.Forms.PictureBox France_flag;
        private System.Windows.Forms.ComboBox cbLang;
    }
}