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
            this.btChargement = new System.Windows.Forms.Button();
            this.btDechargement = new System.Windows.Forms.Button();
            this.Spain_flag = new System.Windows.Forms.PictureBox();
            this.England_flag = new System.Windows.Forms.PictureBox();
            this.France_flag = new System.Windows.Forms.PictureBox();
            this.btAnnuler = new System.Windows.Forms.Button();
            this.lbTexte = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Spain_flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.England_flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.France_flag)).BeginInit();
            this.SuspendLayout();
            // 
            // btChargement
            // 
            resources.ApplyResources(this.btChargement, "btChargement");
            this.btChargement.BackColor = System.Drawing.Color.Black;
            this.btChargement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btChargement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.btChargement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.btChargement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.btChargement.Image = global::WidraSoft.UI.Properties.Resources.Chargement;
            this.btChargement.Name = "btChargement";
            this.btChargement.UseVisualStyleBackColor = false;
            this.btChargement.Click += new System.EventHandler(this.btChargement_Click);
            // 
            // btDechargement
            // 
            resources.ApplyResources(this.btDechargement, "btDechargement");
            this.btDechargement.BackColor = System.Drawing.Color.Black;
            this.btDechargement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDechargement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.btDechargement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.btDechargement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.btDechargement.Image = global::WidraSoft.UI.Properties.Resources.Dechargement;
            this.btDechargement.Name = "btDechargement";
            this.btDechargement.UseVisualStyleBackColor = false;
            this.btDechargement.Click += new System.EventHandler(this.btDechargement_Click);
            // 
            // Spain_flag
            // 
            resources.ApplyResources(this.Spain_flag, "Spain_flag");
            this.Spain_flag.BackColor = System.Drawing.Color.Transparent;
            this.Spain_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Spain_flag.Image = global::WidraSoft.UI.Properties.Resources.spain;
            this.Spain_flag.Name = "Spain_flag";
            this.Spain_flag.TabStop = false;
            // 
            // England_flag
            // 
            resources.ApplyResources(this.England_flag, "England_flag");
            this.England_flag.BackColor = System.Drawing.Color.Transparent;
            this.England_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.England_flag.Image = global::WidraSoft.UI.Properties.Resources.united_kingdom;
            this.England_flag.Name = "England_flag";
            this.England_flag.TabStop = false;
            // 
            // France_flag
            // 
            resources.ApplyResources(this.France_flag, "France_flag");
            this.France_flag.BackColor = System.Drawing.Color.Transparent;
            this.France_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.France_flag.Image = global::WidraSoft.UI.Properties.Resources.france;
            this.France_flag.Name = "France_flag";
            this.France_flag.TabStop = false;
            // 
            // btAnnuler
            // 
            resources.ApplyResources(this.btAnnuler, "btAnnuler");
            this.btAnnuler.BackColor = System.Drawing.Color.Black;
            this.btAnnuler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.btAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.btAnnuler.ForeColor = System.Drawing.Color.Tomato;
            this.btAnnuler.Name = "btAnnuler";
            this.btAnnuler.UseVisualStyleBackColor = false;
            // 
            // lbTexte
            // 
            resources.ApplyResources(this.lbTexte, "lbTexte");
            this.lbTexte.ForeColor = System.Drawing.Color.White;
            this.lbTexte.Name = "lbTexte";
            // 
            // lbMessage
            // 
            resources.ApplyResources(this.lbMessage, "lbMessage");
            this.lbMessage.ForeColor = System.Drawing.Color.White;
            this.lbMessage.Name = "lbMessage";
            // 
            // Borne_ChoixFlux
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.lbTexte);
            this.Controls.Add(this.btAnnuler);
            this.Controls.Add(this.Spain_flag);
            this.Controls.Add(this.England_flag);
            this.Controls.Add(this.France_flag);
            this.Controls.Add(this.btDechargement);
            this.Controls.Add(this.btChargement);
            this.Name = "Borne_ChoixFlux";
            this.Load += new System.EventHandler(this.Borne_ChoixFlux_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Spain_flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.England_flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.France_flag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}