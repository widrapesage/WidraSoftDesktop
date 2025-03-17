namespace WidraSoft.UI
{
    partial class Borne_FinPesee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Borne_FinPesee));
            pictureBox2 = new System.Windows.Forms.PictureBox();
            lbTexte = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            Spain_flag = new System.Windows.Forms.PictureBox();
            England_flag = new System.Windows.Forms.PictureBox();
            France_flag = new System.Windows.Forms.PictureBox();
            panel1 = new System.Windows.Forms.Panel();
            Timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Spain_flag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)England_flag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)France_flag).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            resources.ApplyResources(pictureBox2, "pictureBox2");
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox2.Image = Properties.Resources.a_bientot;
            pictureBox2.Name = "pictureBox2";
            pictureBox2.TabStop = false;
            // 
            // lbTexte
            // 
            resources.ApplyResources(lbTexte, "lbTexte");
            lbTexte.ForeColor = System.Drawing.Color.White;
            lbTexte.Name = "lbTexte";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(58, 62, 60);
            pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox1.Image = Properties.Resources.message;
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
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
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(Spain_flag);
            panel1.Controls.Add(England_flag);
            panel1.Controls.Add(lbTexte);
            panel1.Controls.Add(France_flag);
            panel1.Controls.Add(pictureBox1);
            panel1.Name = "panel1";
            panel1.Paint += panel1_Paint;
            // 
            // Timer
            // 
            Timer.Tick += Timer_Tick;
            // 
            // Borne_FinPesee
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(58, 62, 60);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Borne_FinPesee";
            FormClosing += Borne_FinPesee_FormClosing;
            Load += Borne_FinPesee_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Spain_flag).EndInit();
            ((System.ComponentModel.ISupportInitialize)England_flag).EndInit();
            ((System.ComponentModel.ISupportInitialize)France_flag).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbTexte;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Spain_flag;
        private System.Windows.Forms.PictureBox England_flag;
        private System.Windows.Forms.PictureBox France_flag;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer Timer;
    }
}