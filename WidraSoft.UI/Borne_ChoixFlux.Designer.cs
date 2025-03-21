namespace WidraSoft.UI
{
    partial class Borne_ChoixFlux
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Borne_ChoixFlux));
            btChargement = new System.Windows.Forms.Button();
            btDechargement = new System.Windows.Forms.Button();
            Spain_flag = new System.Windows.Forms.PictureBox();
            England_flag = new System.Windows.Forms.PictureBox();
            France_flag = new System.Windows.Forms.PictureBox();
            btAnnuler = new System.Windows.Forms.Button();
            lbTexte = new System.Windows.Forms.Label();
            lbMessage = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)Spain_flag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)England_flag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)France_flag).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btChargement
            // 
            resources.ApplyResources(btChargement, "btChargement");
            btChargement.BackColor = System.Drawing.Color.Black;
            btChargement.Cursor = System.Windows.Forms.Cursors.Hand;
            btChargement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(112, 228, 132);
            btChargement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(72, 86, 81);
            btChargement.ForeColor = System.Drawing.Color.FromArgb(112, 228, 132);
            btChargement.Image = Properties.Resources.Chargement;
            btChargement.Name = "btChargement";
            btChargement.UseVisualStyleBackColor = false;
            btChargement.Click += btChargement_Click;
            // 
            // btDechargement
            // 
            resources.ApplyResources(btDechargement, "btDechargement");
            btDechargement.BackColor = System.Drawing.Color.Black;
            btDechargement.Cursor = System.Windows.Forms.Cursors.Hand;
            btDechargement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(112, 228, 132);
            btDechargement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(72, 86, 81);
            btDechargement.ForeColor = System.Drawing.Color.FromArgb(112, 228, 132);
            btDechargement.Image = Properties.Resources.Dechargement;
            btDechargement.Name = "btDechargement";
            btDechargement.UseVisualStyleBackColor = false;
            btDechargement.Click += btDechargement_Click;
            // 
            // Spain_flag
            // 
            resources.ApplyResources(Spain_flag, "Spain_flag");
            Spain_flag.BackColor = System.Drawing.Color.Transparent;
            Spain_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            Spain_flag.Image = Properties.Resources.spain;
            Spain_flag.Name = "Spain_flag";
            Spain_flag.TabStop = false;
            // 
            // England_flag
            // 
            resources.ApplyResources(England_flag, "England_flag");
            England_flag.BackColor = System.Drawing.Color.Transparent;
            England_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            England_flag.Image = Properties.Resources.united_kingdom;
            England_flag.Name = "England_flag";
            England_flag.TabStop = false;
            // 
            // France_flag
            // 
            resources.ApplyResources(France_flag, "France_flag");
            France_flag.BackColor = System.Drawing.Color.Transparent;
            France_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            France_flag.Image = Properties.Resources.france;
            France_flag.Name = "France_flag";
            France_flag.TabStop = false;
            // 
            // btAnnuler
            // 
            resources.ApplyResources(btAnnuler, "btAnnuler");
            btAnnuler.BackColor = System.Drawing.Color.Black;
            btAnnuler.Cursor = System.Windows.Forms.Cursors.Hand;
            btAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            btAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(72, 86, 81);
            btAnnuler.ForeColor = System.Drawing.Color.Tomato;
            btAnnuler.Name = "btAnnuler";
            btAnnuler.UseVisualStyleBackColor = false;
            btAnnuler.Click += btAnnuler_Click;
            // 
            // lbTexte
            // 
            resources.ApplyResources(lbTexte, "lbTexte");
            lbTexte.ForeColor = System.Drawing.Color.White;
            lbTexte.Name = "lbTexte";
            // 
            // lbMessage
            // 
            resources.ApplyResources(lbMessage, "lbMessage");
            lbMessage.ForeColor = System.Drawing.Color.White;
            lbMessage.Name = "lbMessage";
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(btDechargement);
            panel1.Controls.Add(lbMessage);
            panel1.Controls.Add(btChargement);
            panel1.Controls.Add(lbTexte);
            panel1.Controls.Add(France_flag);
            panel1.Controls.Add(btAnnuler);
            panel1.Controls.Add(England_flag);
            panel1.Controls.Add(Spain_flag);
            panel1.Name = "panel1";
            // 
            // Borne_ChoixFlux
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(58, 62, 60);
            ControlBox = false;
            Controls.Add(panel1);
            Name = "Borne_ChoixFlux";
            Load += Borne_ChoixFlux_Load;
            ((System.ComponentModel.ISupportInitialize)Spain_flag).EndInit();
            ((System.ComponentModel.ISupportInitialize)England_flag).EndInit();
            ((System.ComponentModel.ISupportInitialize)France_flag).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btChargement;
        private System.Windows.Forms.Button btDechargement;
        private System.Windows.Forms.PictureBox Spain_flag;
        private System.Windows.Forms.PictureBox England_flag;
        private System.Windows.Forms.PictureBox France_flag;
        private System.Windows.Forms.Button btAnnuler;
        private System.Windows.Forms.Label lbTexte;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Panel panel1;
    }
}