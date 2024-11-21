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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Borne_Home));
            this.txtPoids = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Spain_flag = new System.Windows.Forms.PictureBox();
            this.England_flag = new System.Windows.Forms.PictureBox();
            this.France_flag = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer_Time = new System.Windows.Forms.Timer(this.components);
            this.lbDate = new System.Windows.Forms.Label();
            this.select_FR = new System.Windows.Forms.PictureBox();
            this.select_EN = new System.Windows.Forms.PictureBox();
            this.select_ES = new System.Windows.Forms.PictureBox();
            this.lbMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Spain_flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.England_flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.France_flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.select_FR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.select_EN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.select_ES)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPoids
            // 
            resources.ApplyResources(this.txtPoids, "txtPoids");
            this.txtPoids.BackColor = System.Drawing.Color.Black;
            this.txtPoids.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPoids.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.txtPoids.Name = "txtPoids";
            this.txtPoids.TabStop = false;
            this.txtPoids.TextChanged += new System.EventHandler(this.txtPoids_TextChanged);
            this.txtPoids.DoubleClick += new System.EventHandler(this.txtPoids_DoubleClick);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.button2.Image = global::WidraSoft.UI.Properties.Resources.more;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Spain_flag
            // 
            resources.ApplyResources(this.Spain_flag, "Spain_flag");
            this.Spain_flag.BackColor = System.Drawing.Color.Transparent;
            this.Spain_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Spain_flag.Image = global::WidraSoft.UI.Properties.Resources.spain_borne;
            this.Spain_flag.Name = "Spain_flag";
            this.Spain_flag.TabStop = false;
            this.Spain_flag.Click += new System.EventHandler(this.Spain_flag_Click);
            this.Spain_flag.DoubleClick += new System.EventHandler(this.Spain_flag_DoubleClick);
            // 
            // England_flag
            // 
            resources.ApplyResources(this.England_flag, "England_flag");
            this.England_flag.BackColor = System.Drawing.Color.Transparent;
            this.England_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.England_flag.Image = global::WidraSoft.UI.Properties.Resources.united_kingdom_borne;
            this.England_flag.Name = "England_flag";
            this.England_flag.TabStop = false;
            this.England_flag.Click += new System.EventHandler(this.England_flag_Click);
            this.England_flag.DoubleClick += new System.EventHandler(this.England_flag_DoubleClick);
            // 
            // France_flag
            // 
            resources.ApplyResources(this.France_flag, "France_flag");
            this.France_flag.BackColor = System.Drawing.Color.Transparent;
            this.France_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.France_flag.Image = global::WidraSoft.UI.Properties.Resources.france_borne;
            this.France_flag.Name = "France_flag";
            this.France_flag.TabStop = false;
            this.France_flag.Click += new System.EventHandler(this.France_flag_Click);
            this.France_flag.DoubleClick += new System.EventHandler(this.France_flag_DoubleClick);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.button3.Image = global::WidraSoft.UI.Properties.Resources.question;
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.BackColor = System.Drawing.Color.Black;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.button5.Image = global::WidraSoft.UI.Properties.Resources.list_borne;
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::WidraSoft.UI.Properties.Resources.logo_Widra_250;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // timer_Time
            // 
            this.timer_Time.Tick += new System.EventHandler(this.timer_Time_Tick);
            // 
            // lbDate
            // 
            resources.ApplyResources(this.lbDate, "lbDate");
            this.lbDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.lbDate.ForeColor = System.Drawing.Color.White;
            this.lbDate.Name = "lbDate";
            // 
            // select_FR
            // 
            resources.ApplyResources(this.select_FR, "select_FR");
            this.select_FR.BackColor = System.Drawing.Color.Transparent;
            this.select_FR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.select_FR.Image = global::WidraSoft.UI.Properties.Resources.down;
            this.select_FR.Name = "select_FR";
            this.select_FR.TabStop = false;
            // 
            // select_EN
            // 
            resources.ApplyResources(this.select_EN, "select_EN");
            this.select_EN.BackColor = System.Drawing.Color.Transparent;
            this.select_EN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.select_EN.Image = global::WidraSoft.UI.Properties.Resources.down;
            this.select_EN.Name = "select_EN";
            this.select_EN.TabStop = false;
            // 
            // select_ES
            // 
            resources.ApplyResources(this.select_ES, "select_ES");
            this.select_ES.BackColor = System.Drawing.Color.Transparent;
            this.select_ES.Cursor = System.Windows.Forms.Cursors.Hand;
            this.select_ES.Image = global::WidraSoft.UI.Properties.Resources.down;
            this.select_ES.Name = "select_ES";
            this.select_ES.TabStop = false;
            // 
            // lbMessage
            // 
            resources.ApplyResources(this.lbMessage, "lbMessage");
            this.lbMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.lbMessage.ForeColor = System.Drawing.Color.White;
            this.lbMessage.Name = "lbMessage";
            // 
            // Borne_Home
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.select_ES);
            this.Controls.Add(this.select_EN);
            this.Controls.Add(this.select_FR);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.Spain_flag);
            this.Controls.Add(this.England_flag);
            this.Controls.Add(this.France_flag);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtPoids);
            this.Name = "Borne_Home";
            this.Load += new System.EventHandler(this.Borne_Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Spain_flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.England_flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.France_flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.select_FR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.select_EN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.select_ES)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPoids;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox Spain_flag;
        private System.Windows.Forms.PictureBox England_flag;
        private System.Windows.Forms.PictureBox France_flag;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer_Time;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.PictureBox select_FR;
        private System.Windows.Forms.PictureBox select_EN;
        private System.Windows.Forms.PictureBox select_ES;
        private System.Windows.Forms.Label lbMessage;
    }
}