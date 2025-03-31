namespace WidraSoft.UI
{
    partial class ReportingWalterreParClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportingWalterreParClient));
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            Export = new System.Windows.Forms.ToolStripMenuItem();
            panelTitleBar = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            cbTransporteur = new System.Windows.Forms.ComboBox();
            gbPeriode = new System.Windows.Forms.GroupBox();
            rbToutDate = new System.Windows.Forms.RadioButton();
            lnjour = new System.Windows.Forms.Label();
            rbMois = new System.Windows.Forms.RadioButton();
            rbJour = new System.Windows.Forms.RadioButton();
            label12 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            cbWeighingSettingsId = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            cbWalterre = new System.Windows.Forms.ComboBox();
            chx_Date = new System.Windows.Forms.CheckBox();
            label11 = new System.Windows.Forms.Label();
            dtFin = new System.Windows.Forms.DateTimePicker();
            label10 = new System.Windows.Forms.Label();
            dtDebut = new System.Windows.Forms.DateTimePicker();
            label5 = new System.Windows.Forms.Label();
            cbProduit = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            cbClient = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            cbPont = new System.Windows.Forms.ComboBox();
            panel1 = new System.Windows.Forms.Panel();
            Spain_flag = new System.Windows.Forms.PictureBox();
            England_flag = new System.Windows.Forms.PictureBox();
            France_flag = new System.Windows.Forms.PictureBox();
            cbLang = new System.Windows.Forms.ComboBox();
            menuStrip1.SuspendLayout();
            panelTitleBar.SuspendLayout();
            gbPeriode.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Spain_flag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)England_flag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)France_flag).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = System.Drawing.Color.FromArgb(58, 62, 60);
            menuStrip1.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { Export });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            menuStrip1.Size = new System.Drawing.Size(1145, 30);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // Export
            // 
            Export.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            Export.ForeColor = System.Drawing.Color.White;
            Export.Image = Properties.Resources.export;
            Export.Name = "Export";
            Export.Size = new System.Drawing.Size(104, 28);
            Export.Text = "Exporter";
            Export.Click += Export_Click;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = System.Drawing.Color.FromArgb(72, 86, 81);
            panelTitleBar.Controls.Add(label1);
            panelTitleBar.Controls.Add(cbTransporteur);
            panelTitleBar.Controls.Add(gbPeriode);
            panelTitleBar.Controls.Add(label9);
            panelTitleBar.Controls.Add(cbWeighingSettingsId);
            panelTitleBar.Controls.Add(label6);
            panelTitleBar.Controls.Add(cbWalterre);
            panelTitleBar.Controls.Add(chx_Date);
            panelTitleBar.Controls.Add(label11);
            panelTitleBar.Controls.Add(dtFin);
            panelTitleBar.Controls.Add(label10);
            panelTitleBar.Controls.Add(dtDebut);
            panelTitleBar.Controls.Add(label5);
            panelTitleBar.Controls.Add(cbProduit);
            panelTitleBar.Controls.Add(label4);
            panelTitleBar.Controls.Add(cbClient);
            panelTitleBar.Controls.Add(label3);
            panelTitleBar.Controls.Add(cbPont);
            panelTitleBar.Controls.Add(panel1);
            panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            panelTitleBar.Location = new System.Drawing.Point(0, 30);
            panelTitleBar.Margin = new System.Windows.Forms.Padding(4);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new System.Drawing.Size(1145, 211);
            panelTitleBar.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.White;
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(563, 59);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(91, 19);
            label1.TabIndex = 252;
            label1.Text = "Transporteur";
            // 
            // cbTransporteur
            // 
            cbTransporteur.BackColor = System.Drawing.Color.Honeydew;
            cbTransporteur.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cbTransporteur.FormattingEnabled = true;
            cbTransporteur.Location = new System.Drawing.Point(660, 55);
            cbTransporteur.Margin = new System.Windows.Forms.Padding(2);
            cbTransporteur.Name = "cbTransporteur";
            cbTransporteur.Size = new System.Drawing.Size(202, 27);
            cbTransporteur.TabIndex = 251;
            // 
            // gbPeriode
            // 
            gbPeriode.Controls.Add(rbToutDate);
            gbPeriode.Controls.Add(lnjour);
            gbPeriode.Controls.Add(rbMois);
            gbPeriode.Controls.Add(rbJour);
            gbPeriode.Controls.Add(label12);
            gbPeriode.Controls.Add(label19);
            gbPeriode.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            gbPeriode.ForeColor = System.Drawing.Color.White;
            gbPeriode.Location = new System.Drawing.Point(660, 89);
            gbPeriode.Name = "gbPeriode";
            gbPeriode.Size = new System.Drawing.Size(92, 99);
            gbPeriode.TabIndex = 249;
            gbPeriode.TabStop = false;
            gbPeriode.Text = "Periode";
            // 
            // rbToutDate
            // 
            rbToutDate.AutoSize = true;
            rbToutDate.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(72, 190, 117);
            rbToutDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            rbToutDate.Location = new System.Drawing.Point(6, 24);
            rbToutDate.Name = "rbToutDate";
            rbToutDate.Size = new System.Drawing.Size(14, 13);
            rbToutDate.TabIndex = 233;
            rbToutDate.TabStop = true;
            rbToutDate.UseVisualStyleBackColor = true;
            // 
            // lnjour
            // 
            lnjour.AutoSize = true;
            lnjour.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lnjour.ForeColor = System.Drawing.Color.White;
            lnjour.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            lnjour.Location = new System.Drawing.Point(22, 66);
            lnjour.Name = "lnjour";
            lnjour.Size = new System.Drawing.Size(55, 18);
            lnjour.TabIndex = 246;
            lnjour.Text = "Ce jour ";
            // 
            // rbMois
            // 
            rbMois.AutoSize = true;
            rbMois.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(72, 190, 117);
            rbMois.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            rbMois.Location = new System.Drawing.Point(6, 46);
            rbMois.Name = "rbMois";
            rbMois.Size = new System.Drawing.Size(14, 13);
            rbMois.TabIndex = 235;
            rbMois.TabStop = true;
            rbMois.UseVisualStyleBackColor = true;
            // 
            // rbJour
            // 
            rbJour.AutoSize = true;
            rbJour.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(72, 190, 117);
            rbJour.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            rbJour.Location = new System.Drawing.Point(6, 68);
            rbJour.Name = "rbJour";
            rbJour.Size = new System.Drawing.Size(14, 13);
            rbJour.TabIndex = 245;
            rbJour.TabStop = true;
            rbJour.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label12.ForeColor = System.Drawing.Color.White;
            label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label12.Location = new System.Drawing.Point(22, 21);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(35, 18);
            label12.TabIndex = 236;
            label12.Text = "Tout";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label19.ForeColor = System.Drawing.Color.White;
            label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label19.Location = new System.Drawing.Point(22, 43);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(57, 18);
            label19.TabIndex = 238;
            label19.Text = "Ce mois";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label9.ForeColor = System.Drawing.Color.White;
            label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label9.Location = new System.Drawing.Point(278, 58);
            label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(76, 19);
            label9.TabIndex = 85;
            label9.Text = "Paramètre";
            // 
            // cbWeighingSettingsId
            // 
            cbWeighingSettingsId.BackColor = System.Drawing.Color.Honeydew;
            cbWeighingSettingsId.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cbWeighingSettingsId.FormattingEnabled = true;
            cbWeighingSettingsId.Location = new System.Drawing.Point(358, 55);
            cbWeighingSettingsId.Margin = new System.Windows.Forms.Padding(2);
            cbWeighingSettingsId.Name = "cbWeighingSettingsId";
            cbWeighingSettingsId.Size = new System.Drawing.Size(202, 27);
            cbWeighingSettingsId.TabIndex = 84;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.ForeColor = System.Drawing.Color.White;
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(4, 58);
            label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(65, 19);
            label6.TabIndex = 79;
            label6.Text = "Walterre";
            // 
            // cbWalterre
            // 
            cbWalterre.BackColor = System.Drawing.Color.Honeydew;
            cbWalterre.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cbWalterre.FormattingEnabled = true;
            cbWalterre.Location = new System.Drawing.Point(73, 55);
            cbWalterre.Margin = new System.Windows.Forms.Padding(2);
            cbWalterre.Name = "cbWalterre";
            cbWalterre.Size = new System.Drawing.Size(202, 27);
            cbWalterre.TabIndex = 78;
            // 
            // chx_Date
            // 
            chx_Date.AutoSize = true;
            chx_Date.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            chx_Date.Location = new System.Drawing.Point(11, 99);
            chx_Date.Name = "chx_Date";
            chx_Date.Size = new System.Drawing.Size(15, 14);
            chx_Date.TabIndex = 57;
            chx_Date.UseVisualStyleBackColor = true;
            chx_Date.CheckedChanged += chx_Date_CheckedChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label11.ForeColor = System.Drawing.Color.White;
            label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label11.Location = new System.Drawing.Point(334, 95);
            label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(26, 19);
            label11.TabIndex = 56;
            label11.Text = "Au";
            // 
            // dtFin
            // 
            dtFin.Location = new System.Drawing.Point(366, 95);
            dtFin.Name = "dtFin";
            dtFin.Size = new System.Drawing.Size(256, 23);
            dtFin.TabIndex = 55;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label10.ForeColor = System.Drawing.Color.White;
            label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label10.Location = new System.Drawing.Point(31, 95);
            label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(27, 19);
            label10.TabIndex = 54;
            label10.Text = "Du";
            // 
            // dtDebut
            // 
            dtDebut.Location = new System.Drawing.Point(73, 95);
            dtDebut.Name = "dtDebut";
            dtDebut.Size = new System.Drawing.Size(256, 23);
            dtDebut.TabIndex = 53;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.ForeColor = System.Drawing.Color.White;
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(563, 26);
            label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(55, 19);
            label5.TabIndex = 46;
            label5.Text = "Produit";
            // 
            // cbProduit
            // 
            cbProduit.BackColor = System.Drawing.Color.Honeydew;
            cbProduit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cbProduit.FormattingEnabled = true;
            cbProduit.Location = new System.Drawing.Point(660, 22);
            cbProduit.Margin = new System.Windows.Forms.Padding(2);
            cbProduit.Name = "cbProduit";
            cbProduit.Size = new System.Drawing.Size(202, 27);
            cbProduit.TabIndex = 45;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.ForeColor = System.Drawing.Color.White;
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(278, 25);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(47, 19);
            label4.TabIndex = 44;
            label4.Text = "Client";
            // 
            // cbClient
            // 
            cbClient.BackColor = System.Drawing.Color.Honeydew;
            cbClient.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cbClient.FormattingEnabled = true;
            cbClient.Location = new System.Drawing.Point(358, 22);
            cbClient.Margin = new System.Windows.Forms.Padding(2);
            cbClient.Name = "cbClient";
            cbClient.Size = new System.Drawing.Size(202, 27);
            cbClient.TabIndex = 43;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.ForeColor = System.Drawing.Color.White;
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(6, 25);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(38, 19);
            label3.TabIndex = 42;
            label3.Text = "Pont";
            // 
            // cbPont
            // 
            cbPont.BackColor = System.Drawing.Color.Honeydew;
            cbPont.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cbPont.FormattingEnabled = true;
            cbPont.Location = new System.Drawing.Point(73, 22);
            cbPont.Margin = new System.Windows.Forms.Padding(2);
            cbPont.Name = "cbPont";
            cbPont.Size = new System.Drawing.Size(202, 27);
            cbPont.TabIndex = 41;
            // 
            // panel1
            // 
            panel1.Controls.Add(Spain_flag);
            panel1.Controls.Add(England_flag);
            panel1.Controls.Add(France_flag);
            panel1.Controls.Add(cbLang);
            panel1.Dock = System.Windows.Forms.DockStyle.Right;
            panel1.Location = new System.Drawing.Point(865, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(280, 211);
            panel1.TabIndex = 32;
            // 
            // Spain_flag
            // 
            Spain_flag.BackColor = System.Drawing.Color.Transparent;
            Spain_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            Spain_flag.Image = Properties.Resources.spain;
            Spain_flag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            Spain_flag.Location = new System.Drawing.Point(48, 23);
            Spain_flag.Name = "Spain_flag";
            Spain_flag.Size = new System.Drawing.Size(24, 24);
            Spain_flag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            Spain_flag.TabIndex = 30;
            Spain_flag.TabStop = false;
            // 
            // England_flag
            // 
            England_flag.BackColor = System.Drawing.Color.Transparent;
            England_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            England_flag.Image = Properties.Resources.united_kingdom;
            England_flag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            England_flag.Location = new System.Drawing.Point(48, 23);
            England_flag.Name = "England_flag";
            England_flag.Size = new System.Drawing.Size(24, 24);
            England_flag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            England_flag.TabIndex = 29;
            England_flag.TabStop = false;
            // 
            // France_flag
            // 
            France_flag.BackColor = System.Drawing.Color.Transparent;
            France_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            France_flag.Image = Properties.Resources.france;
            France_flag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            France_flag.Location = new System.Drawing.Point(48, 23);
            France_flag.Name = "France_flag";
            France_flag.Size = new System.Drawing.Size(24, 24);
            France_flag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            France_flag.TabIndex = 28;
            France_flag.TabStop = false;
            // 
            // cbLang
            // 
            cbLang.BackColor = System.Drawing.Color.FromArgb(72, 86, 77);
            cbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbLang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cbLang.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            cbLang.ForeColor = System.Drawing.Color.White;
            cbLang.FormattingEnabled = true;
            cbLang.Location = new System.Drawing.Point(78, 22);
            cbLang.Name = "cbLang";
            cbLang.Size = new System.Drawing.Size(158, 26);
            cbLang.TabIndex = 27;
            cbLang.SelectedIndexChanged += cbLang_SelectedIndexChanged;
            // 
            // ReportingWalterreParClient
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(72, 86, 81);
            ClientSize = new System.Drawing.Size(1145, 243);
            Controls.Add(panelTitleBar);
            Controls.Add(menuStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ReportingWalterreParClient";
            Text = "Reporting Walterre Par Client";
            Load += ReportingWalterreParClient_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            gbPeriode.ResumeLayout(false);
            gbPeriode.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Spain_flag).EndInit();
            ((System.ComponentModel.ISupportInitialize)England_flag).EndInit();
            ((System.ComponentModel.ISupportInitialize)France_flag).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Export;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.GroupBox gbPeriode;
        private System.Windows.Forms.RadioButton rbToutDate;
        private System.Windows.Forms.Label lnjour;
        private System.Windows.Forms.RadioButton rbMois;
        private System.Windows.Forms.RadioButton rbJour;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbWeighingSettingsId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbWalterre;
        private System.Windows.Forms.CheckBox chx_Date;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtFin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtDebut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbProduit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPont;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Spain_flag;
        private System.Windows.Forms.PictureBox England_flag;
        private System.Windows.Forms.PictureBox France_flag;
        private System.Windows.Forms.ComboBox cbLang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTransporteur;
    }
}