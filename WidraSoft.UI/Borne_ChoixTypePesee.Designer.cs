namespace WidraSoft.UI
{
    partial class Borne_ChoixTypePesee
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Borne_ChoixTypePesee));
            txtPoids = new System.Windows.Forms.TextBox();
            select_ES = new System.Windows.Forms.PictureBox();
            select_EN = new System.Windows.Forms.PictureBox();
            select_FR = new System.Windows.Forms.PictureBox();
            Spain_flag = new System.Windows.Forms.PictureBox();
            England_flag = new System.Windows.Forms.PictureBox();
            France_flag = new System.Windows.Forms.PictureBox();
            QrCode = new System.Windows.Forms.PictureBox();
            btPeser = new System.Windows.Forms.Button();
            btTareManuelle = new System.Windows.Forms.Button();
            lbBadge = new System.Windows.Forms.Label();
            timerHoneywell = new System.Windows.Forms.Timer(components);
            btPeser2 = new System.Windows.Forms.Button();
            fleche_Lecteur = new System.Windows.Forms.PictureBox();
            panelWeight = new System.Windows.Forms.Panel();
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            Weight_Timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)select_ES).BeginInit();
            ((System.ComponentModel.ISupportInitialize)select_EN).BeginInit();
            ((System.ComponentModel.ISupportInitialize)select_FR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Spain_flag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)England_flag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)France_flag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)QrCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fleche_Lecteur).BeginInit();
            panelWeight.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // txtPoids
            // 
            txtPoids.BackColor = System.Drawing.Color.Black;
            txtPoids.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(txtPoids, "txtPoids");
            txtPoids.ForeColor = System.Drawing.Color.FromArgb(112, 228, 132);
            txtPoids.Name = "txtPoids";
            txtPoids.TabStop = false;
            txtPoids.TextChanged += txtPoids_TextChanged;
            txtPoids.DoubleClick += txtPoids_DoubleClick;
            // 
            // select_ES
            // 
            resources.ApplyResources(select_ES, "select_ES");
            select_ES.BackColor = System.Drawing.Color.Transparent;
            select_ES.Cursor = System.Windows.Forms.Cursors.Hand;
            select_ES.Image = Properties.Resources.down;
            select_ES.Name = "select_ES";
            select_ES.TabStop = false;
            // 
            // select_EN
            // 
            resources.ApplyResources(select_EN, "select_EN");
            select_EN.BackColor = System.Drawing.Color.Transparent;
            select_EN.Cursor = System.Windows.Forms.Cursors.Hand;
            select_EN.Image = Properties.Resources.down;
            select_EN.Name = "select_EN";
            select_EN.TabStop = false;
            // 
            // select_FR
            // 
            resources.ApplyResources(select_FR, "select_FR");
            select_FR.BackColor = System.Drawing.Color.Transparent;
            select_FR.Cursor = System.Windows.Forms.Cursors.Hand;
            select_FR.Image = Properties.Resources.down;
            select_FR.Name = "select_FR";
            select_FR.TabStop = false;
            // 
            // Spain_flag
            // 
            resources.ApplyResources(Spain_flag, "Spain_flag");
            Spain_flag.BackColor = System.Drawing.Color.Transparent;
            Spain_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            Spain_flag.Image = Properties.Resources.spain_borne;
            Spain_flag.Name = "Spain_flag";
            Spain_flag.TabStop = false;
            Spain_flag.Click += Spain_flag_Click;
            // 
            // England_flag
            // 
            resources.ApplyResources(England_flag, "England_flag");
            England_flag.BackColor = System.Drawing.Color.Transparent;
            England_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            England_flag.Image = Properties.Resources.united_kingdom_borne;
            England_flag.Name = "England_flag";
            England_flag.TabStop = false;
            England_flag.Click += England_flag_Click;
            // 
            // France_flag
            // 
            resources.ApplyResources(France_flag, "France_flag");
            France_flag.BackColor = System.Drawing.Color.Transparent;
            France_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            France_flag.Image = Properties.Resources.france_borne;
            France_flag.Name = "France_flag";
            France_flag.TabStop = false;
            France_flag.Click += France_flag_Click;
            // 
            // QrCode
            // 
            resources.ApplyResources(QrCode, "QrCode");
            QrCode.BackColor = System.Drawing.Color.Transparent;
            QrCode.Cursor = System.Windows.Forms.Cursors.Hand;
            QrCode.Image = Properties.Resources.qr_code;
            QrCode.Name = "QrCode";
            QrCode.TabStop = false;
            // 
            // btPeser
            // 
            resources.ApplyResources(btPeser, "btPeser");
            btPeser.BackColor = System.Drawing.Color.Black;
            btPeser.Cursor = System.Windows.Forms.Cursors.Hand;
            btPeser.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(112, 228, 132);
            btPeser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(72, 86, 81);
            btPeser.ForeColor = System.Drawing.Color.FromArgb(112, 228, 132);
            btPeser.Image = Properties.Resources.Peser_Borne;
            btPeser.Name = "btPeser";
            btPeser.UseVisualStyleBackColor = false;
            btPeser.Click += btPeser_Click;
            // 
            // btTareManuelle
            // 
            resources.ApplyResources(btTareManuelle, "btTareManuelle");
            btTareManuelle.BackColor = System.Drawing.Color.Black;
            btTareManuelle.Cursor = System.Windows.Forms.Cursors.Hand;
            btTareManuelle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(112, 228, 132);
            btTareManuelle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(72, 86, 81);
            btTareManuelle.ForeColor = System.Drawing.Color.FromArgb(112, 228, 132);
            btTareManuelle.Image = Properties.Resources.pave_numerique;
            btTareManuelle.Name = "btTareManuelle";
            btTareManuelle.UseVisualStyleBackColor = false;
            btTareManuelle.Click += btTareManuelle_Click;
            // 
            // lbBadge
            // 
            resources.ApplyResources(lbBadge, "lbBadge");
            lbBadge.BackColor = System.Drawing.Color.Transparent;
            lbBadge.ForeColor = System.Drawing.Color.White;
            lbBadge.Name = "lbBadge";
            // 
            // timerHoneywell
            // 
            timerHoneywell.Tick += timerHoneywell_Tick;
            // 
            // btPeser2
            // 
            resources.ApplyResources(btPeser2, "btPeser2");
            btPeser2.BackColor = System.Drawing.Color.Black;
            btPeser2.Cursor = System.Windows.Forms.Cursors.Hand;
            btPeser2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(112, 228, 132);
            btPeser2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(72, 86, 81);
            btPeser2.ForeColor = System.Drawing.Color.FromArgb(112, 228, 132);
            btPeser2.Image = Properties.Resources.Peser_Borne;
            btPeser2.Name = "btPeser2";
            btPeser2.UseVisualStyleBackColor = false;
            btPeser2.Click += btPeser2_Click;
            // 
            // fleche_Lecteur
            // 
            resources.ApplyResources(fleche_Lecteur, "fleche_Lecteur");
            fleche_Lecteur.BackColor = System.Drawing.Color.Transparent;
            fleche_Lecteur.Cursor = System.Windows.Forms.Cursors.Hand;
            fleche_Lecteur.Image = Properties.Resources.fleche_vers_le_bas_borne;
            fleche_Lecteur.Name = "fleche_Lecteur";
            fleche_Lecteur.TabStop = false;
            // 
            // panelWeight
            // 
            panelWeight.BackColor = System.Drawing.Color.Black;
            panelWeight.Controls.Add(txtPoids);
            resources.ApplyResources(panelWeight, "panelWeight");
            panelWeight.Name = "panelWeight";
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(btPeser2);
            panel1.Controls.Add(France_flag);
            panel1.Controls.Add(fleche_Lecteur);
            panel1.Controls.Add(England_flag);
            panel1.Controls.Add(Spain_flag);
            panel1.Controls.Add(lbBadge);
            panel1.Controls.Add(select_FR);
            panel1.Controls.Add(btTareManuelle);
            panel1.Controls.Add(select_EN);
            panel1.Controls.Add(btPeser);
            panel1.Controls.Add(select_ES);
            panel1.Controls.Add(QrCode);
            panel1.Name = "panel1";
            // 
            // panel2
            // 
            panel2.Controls.Add(panel1);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // Weight_Timer
            // 
            Weight_Timer.Tick += Weight_Timer_Tick;
            // 
            // Borne_ChoixTypePesee
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(58, 62, 60);
            Controls.Add(panel2);
            Controls.Add(panelWeight);
            Name = "Borne_ChoixTypePesee";
            Load += Borne_ChoixTypePesee_Load;
            ((System.ComponentModel.ISupportInitialize)select_ES).EndInit();
            ((System.ComponentModel.ISupportInitialize)select_EN).EndInit();
            ((System.ComponentModel.ISupportInitialize)select_FR).EndInit();
            ((System.ComponentModel.ISupportInitialize)Spain_flag).EndInit();
            ((System.ComponentModel.ISupportInitialize)England_flag).EndInit();
            ((System.ComponentModel.ISupportInitialize)France_flag).EndInit();
            ((System.ComponentModel.ISupportInitialize)QrCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)fleche_Lecteur).EndInit();
            panelWeight.ResumeLayout(false);
            panelWeight.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TextBox txtPoids;
        private System.Windows.Forms.PictureBox select_ES;
        private System.Windows.Forms.PictureBox select_EN;
        private System.Windows.Forms.PictureBox select_FR;
        private System.Windows.Forms.PictureBox Spain_flag;
        private System.Windows.Forms.PictureBox England_flag;
        private System.Windows.Forms.PictureBox France_flag;
        private System.Windows.Forms.PictureBox QrCode;
        private System.Windows.Forms.Button btPeser;
        private System.Windows.Forms.Button btTareManuelle;
        private System.Windows.Forms.Label lbBadge;
        private System.Windows.Forms.Timer timerHoneywell;
        private System.Windows.Forms.Button btPeser2;
        private System.Windows.Forms.PictureBox fleche_Lecteur;
        private System.Windows.Forms.Panel panelWeight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer Weight_Timer;
    }
}