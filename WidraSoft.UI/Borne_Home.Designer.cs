namespace WidraSoft.UI
{
    partial class Borne_Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Borne_Home));
            txtPoids = new System.Windows.Forms.TextBox();
            Spain_flag = new System.Windows.Forms.PictureBox();
            England_flag = new System.Windows.Forms.PictureBox();
            France_flag = new System.Windows.Forms.PictureBox();
            timer_Time = new System.Windows.Forms.Timer(components);
            lbDate = new System.Windows.Forms.Label();
            select_FR = new System.Windows.Forms.PictureBox();
            select_EN = new System.Windows.Forms.PictureBox();
            select_ES = new System.Windows.Forms.PictureBox();
            lbMessage = new System.Windows.Forms.Label();
            panelWeight = new System.Windows.Forms.Panel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            panelDetail = new System.Windows.Forms.Panel();
            panelDetailCentre = new System.Windows.Forms.Panel();
            Weight_Timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)Spain_flag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)England_flag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)France_flag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)select_FR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)select_EN).BeginInit();
            ((System.ComponentModel.ISupportInitialize)select_ES).BeginInit();
            panelWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelDetail.SuspendLayout();
            panelDetailCentre.SuspendLayout();
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
            // timer_Time
            // 
            timer_Time.Tick += timer_Time_Tick;
            // 
            // lbDate
            // 
            resources.ApplyResources(lbDate, "lbDate");
            lbDate.BackColor = System.Drawing.Color.FromArgb(58, 62, 60);
            lbDate.ForeColor = System.Drawing.Color.White;
            lbDate.Name = "lbDate";
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
            // select_EN
            // 
            resources.ApplyResources(select_EN, "select_EN");
            select_EN.BackColor = System.Drawing.Color.Transparent;
            select_EN.Cursor = System.Windows.Forms.Cursors.Hand;
            select_EN.Image = Properties.Resources.down;
            select_EN.Name = "select_EN";
            select_EN.TabStop = false;
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
            // lbMessage
            // 
            resources.ApplyResources(lbMessage, "lbMessage");
            lbMessage.BackColor = System.Drawing.Color.FromArgb(58, 62, 60);
            lbMessage.ForeColor = System.Drawing.Color.White;
            lbMessage.Name = "lbMessage";
            // 
            // panelWeight
            // 
            panelWeight.BackColor = System.Drawing.Color.Black;
            panelWeight.Controls.Add(txtPoids);
            resources.ApplyResources(panelWeight, "panelWeight");
            panelWeight.Name = "panelWeight";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Image = Properties.Resources.logo_Widra_250;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // panelDetail
            // 
            panelDetail.Controls.Add(panelDetailCentre);
            resources.ApplyResources(panelDetail, "panelDetail");
            panelDetail.Name = "panelDetail";
            // 
            // panelDetailCentre
            // 
            resources.ApplyResources(panelDetailCentre, "panelDetailCentre");
            panelDetailCentre.Controls.Add(pictureBox1);
            panelDetailCentre.Controls.Add(select_FR);
            panelDetailCentre.Controls.Add(France_flag);
            panelDetailCentre.Controls.Add(select_EN);
            panelDetailCentre.Controls.Add(England_flag);
            panelDetailCentre.Controls.Add(lbDate);
            panelDetailCentre.Controls.Add(lbMessage);
            panelDetailCentre.Controls.Add(select_ES);
            panelDetailCentre.Controls.Add(Spain_flag);
            panelDetailCentre.Name = "panelDetailCentre";
            // 
            // Weight_Timer
            // 
            Weight_Timer.Tick += Weight_Timer_Tick;
            // 
            // Borne_Home
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(58, 62, 60);
            Controls.Add(panelDetail);
            Controls.Add(panelWeight);
            Name = "Borne_Home";
            FormClosing += Borne_Home_FormClosing;
            Load += Borne_Home_Load;
            ((System.ComponentModel.ISupportInitialize)Spain_flag).EndInit();
            ((System.ComponentModel.ISupportInitialize)England_flag).EndInit();
            ((System.ComponentModel.ISupportInitialize)France_flag).EndInit();
            ((System.ComponentModel.ISupportInitialize)select_FR).EndInit();
            ((System.ComponentModel.ISupportInitialize)select_EN).EndInit();
            ((System.ComponentModel.ISupportInitialize)select_ES).EndInit();
            panelWeight.ResumeLayout(false);
            panelWeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelDetail.ResumeLayout(false);
            panelDetailCentre.ResumeLayout(false);
            panelDetailCentre.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TextBox txtPoids;
        private System.Windows.Forms.PictureBox Spain_flag;
        private System.Windows.Forms.PictureBox England_flag;
        private System.Windows.Forms.PictureBox France_flag;
        private System.Windows.Forms.Timer timer_Time;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.PictureBox select_FR;
        private System.Windows.Forms.PictureBox select_EN;
        private System.Windows.Forms.PictureBox select_ES;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Panel panelWeight;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.Panel panelDetailCentre;
        private System.Windows.Forms.Timer Weight_Timer;
    }
}