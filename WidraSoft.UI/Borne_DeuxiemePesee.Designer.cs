namespace WidraSoft.UI
{
    partial class Borne_DeuxiemePesee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Borne_DeuxiemePesee));
            lbTexte = new System.Windows.Forms.Label();
            btAnnuler = new System.Windows.Forms.Button();
            btValider = new System.Windows.Forms.Button();
            txtPoids = new System.Windows.Forms.TextBox();
            lbMessage = new System.Windows.Forms.Label();
            Spain_flag = new System.Windows.Forms.PictureBox();
            England_flag = new System.Windows.Forms.PictureBox();
            France_flag = new System.Windows.Forms.PictureBox();
            panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)Spain_flag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)England_flag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)France_flag).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbTexte
            // 
            resources.ApplyResources(lbTexte, "lbTexte");
            lbTexte.ForeColor = System.Drawing.Color.White;
            lbTexte.Name = "lbTexte";
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
            // btValider
            // 
            resources.ApplyResources(btValider, "btValider");
            btValider.BackColor = System.Drawing.Color.Black;
            btValider.Cursor = System.Windows.Forms.Cursors.Hand;
            btValider.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(112, 228, 132);
            btValider.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(72, 86, 81);
            btValider.ForeColor = System.Drawing.Color.FromArgb(112, 228, 132);
            btValider.Name = "btValider";
            btValider.UseVisualStyleBackColor = false;
            btValider.Click += btValider_Click;
            // 
            // txtPoids
            // 
            resources.ApplyResources(txtPoids, "txtPoids");
            txtPoids.BackColor = System.Drawing.Color.Black;
            txtPoids.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtPoids.ForeColor = System.Drawing.Color.FromArgb(112, 228, 132);
            txtPoids.Name = "txtPoids";
            txtPoids.ReadOnly = true;
            txtPoids.TabStop = false;
            // 
            // lbMessage
            // 
            resources.ApplyResources(lbMessage, "lbMessage");
            lbMessage.ForeColor = System.Drawing.Color.White;
            lbMessage.Name = "lbMessage";
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
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(txtPoids);
            panel1.Controls.Add(Spain_flag);
            panel1.Controls.Add(lbTexte);
            panel1.Controls.Add(England_flag);
            panel1.Controls.Add(btValider);
            panel1.Controls.Add(France_flag);
            panel1.Controls.Add(btAnnuler);
            panel1.Controls.Add(lbMessage);
            panel1.Name = "panel1";
            // 
            // Borne_DeuxiemePesee
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(58, 62, 60);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Borne_DeuxiemePesee";
            Load += Borne_DeuxiemePesee_Load;
            ((System.ComponentModel.ISupportInitialize)Spain_flag).EndInit();
            ((System.ComponentModel.ISupportInitialize)England_flag).EndInit();
            ((System.ComponentModel.ISupportInitialize)France_flag).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lbTexte;
        private System.Windows.Forms.Button btAnnuler;
        private System.Windows.Forms.Button btValider;
        private System.Windows.Forms.TextBox txtPoids;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.PictureBox Spain_flag;
        private System.Windows.Forms.PictureBox England_flag;
        private System.Windows.Forms.PictureBox France_flag;
        private System.Windows.Forms.Panel panel1;
    }
}