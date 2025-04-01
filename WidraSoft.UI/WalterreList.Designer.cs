namespace WidraSoft.UI
{
    partial class WalterreList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WalterreList));
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            ouvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ActualiserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exporterVersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panelTitleBar = new System.Windows.Forms.Panel();
            txtSearchBox = new System.Windows.Forms.TextBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            panel1 = new System.Windows.Forms.Panel();
            Spain_flag = new System.Windows.Forms.PictureBox();
            England_flag = new System.Windows.Forms.PictureBox();
            France_flag = new System.Windows.Forms.PictureBox();
            cbLang = new System.Windows.Forms.ComboBox();
            panelList = new System.Windows.Forms.Panel();
            DgvList = new System.Windows.Forms.DataGridView();
            menuStrip1.SuspendLayout();
            panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Spain_flag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)England_flag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)France_flag).BeginInit();
            panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvList).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = System.Drawing.Color.FromArgb(58, 62, 60);
            menuStrip1.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ouvrirToolStripMenuItem, ajouterToolStripMenuItem, supprimerToolStripMenuItem, ActualiserToolStripMenuItem, exporterVersToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            menuStrip1.Size = new System.Drawing.Size(1036, 30);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // ouvrirToolStripMenuItem
            // 
            ouvrirToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ouvrirToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            ouvrirToolStripMenuItem.Image = Properties.Resources.open;
            ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
            ouvrirToolStripMenuItem.Size = new System.Drawing.Size(89, 28);
            ouvrirToolStripMenuItem.Text = "Ouvrir";
            ouvrirToolStripMenuItem.Click += ouvrirToolStripMenuItem_Click;
            // 
            // ajouterToolStripMenuItem
            // 
            ajouterToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ajouterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            ajouterToolStripMenuItem.Image = Properties.Resources.add;
            ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            ajouterToolStripMenuItem.Size = new System.Drawing.Size(97, 28);
            ajouterToolStripMenuItem.Text = "Ajouter";
            ajouterToolStripMenuItem.Click += ajouterToolStripMenuItem_Click;
            // 
            // supprimerToolStripMenuItem
            // 
            supprimerToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            supprimerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            supprimerToolStripMenuItem.Image = Properties.Resources.remove;
            supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            supprimerToolStripMenuItem.Size = new System.Drawing.Size(117, 28);
            supprimerToolStripMenuItem.Text = "Supprimer";
            // 
            // ActualiserToolStripMenuItem
            // 
            ActualiserToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ActualiserToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            ActualiserToolStripMenuItem.Image = Properties.Resources.refresh;
            ActualiserToolStripMenuItem.Name = "ActualiserToolStripMenuItem";
            ActualiserToolStripMenuItem.Size = new System.Drawing.Size(113, 28);
            ActualiserToolStripMenuItem.Text = "Actualiser";
            ActualiserToolStripMenuItem.Click += ActualiserToolStripMenuItem_Click;
            // 
            // exporterVersToolStripMenuItem
            // 
            exporterVersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { excelToolStripMenuItem, pDFToolStripMenuItem });
            exporterVersToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            exporterVersToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            exporterVersToolStripMenuItem.Image = Properties.Resources.export;
            exporterVersToolStripMenuItem.Name = "exporterVersToolStripMenuItem";
            exporterVersToolStripMenuItem.Size = new System.Drawing.Size(136, 28);
            exporterVersToolStripMenuItem.Text = "Exporter vers";
            // 
            // excelToolStripMenuItem
            // 
            excelToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(58, 62, 60);
            excelToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            excelToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            excelToolStripMenuItem.Text = "Excel";
            // 
            // pDFToolStripMenuItem
            // 
            pDFToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(58, 62, 60);
            pDFToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            pDFToolStripMenuItem.Name = "pDFToolStripMenuItem";
            pDFToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            pDFToolStripMenuItem.Text = "PDF";
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = System.Drawing.Color.FromArgb(72, 86, 81);
            panelTitleBar.Controls.Add(txtSearchBox);
            panelTitleBar.Controls.Add(pictureBox1);
            panelTitleBar.Controls.Add(panel1);
            panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            panelTitleBar.Location = new System.Drawing.Point(0, 30);
            panelTitleBar.Margin = new System.Windows.Forms.Padding(4);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new System.Drawing.Size(1036, 38);
            panelTitleBar.TabIndex = 9;
            // 
            // txtSearchBox
            // 
            txtSearchBox.BackColor = System.Drawing.Color.Honeydew;
            txtSearchBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtSearchBox.ForeColor = System.Drawing.Color.Black;
            txtSearchBox.Location = new System.Drawing.Point(44, 6);
            txtSearchBox.Name = "txtSearchBox";
            txtSearchBox.Size = new System.Drawing.Size(357, 27);
            txtSearchBox.TabIndex = 34;
            txtSearchBox.TextChanged += txtSearchBox_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            pictureBox1.Location = new System.Drawing.Point(14, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(24, 24);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 31;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(Spain_flag);
            panel1.Controls.Add(England_flag);
            panel1.Controls.Add(France_flag);
            panel1.Controls.Add(cbLang);
            panel1.Dock = System.Windows.Forms.DockStyle.Right;
            panel1.Location = new System.Drawing.Point(756, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(280, 38);
            panel1.TabIndex = 0;
            // 
            // Spain_flag
            // 
            Spain_flag.BackColor = System.Drawing.Color.Transparent;
            Spain_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            Spain_flag.Image = Properties.Resources.spain;
            Spain_flag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            Spain_flag.Location = new System.Drawing.Point(81, 7);
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
            England_flag.Location = new System.Drawing.Point(81, 7);
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
            France_flag.Location = new System.Drawing.Point(81, 7);
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
            cbLang.Location = new System.Drawing.Point(111, 6);
            cbLang.Name = "cbLang";
            cbLang.Size = new System.Drawing.Size(158, 26);
            cbLang.TabIndex = 27;
            cbLang.SelectedIndexChanged += cbLang_SelectedIndexChanged;
            // 
            // panelList
            // 
            panelList.Controls.Add(DgvList);
            panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            panelList.Location = new System.Drawing.Point(0, 68);
            panelList.Margin = new System.Windows.Forms.Padding(4);
            panelList.Name = "panelList";
            panelList.Size = new System.Drawing.Size(1036, 493);
            panelList.TabIndex = 10;
            // 
            // DgvList
            // 
            DgvList.AllowUserToAddRows = false;
            DgvList.AllowUserToDeleteRows = false;
            DgvList.BackgroundColor = System.Drawing.Color.FromArgb(72, 86, 81);
            DgvList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(72, 86, 81);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            DgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(72, 86, 81);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            DgvList.DefaultCellStyle = dataGridViewCellStyle2;
            DgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            DgvList.Location = new System.Drawing.Point(0, 0);
            DgvList.Name = "DgvList";
            DgvList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            DgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            DgvList.RowHeadersWidth = 62;
            DgvList.RowTemplate.Height = 33;
            DgvList.Size = new System.Drawing.Size(1036, 493);
            DgvList.TabIndex = 1;
            DgvList.CellDoubleClick += DgvList_CellDoubleClick;
            DgvList.CellFormatting += DgvList_CellFormatting;
            // 
            // WalterreList
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1036, 561);
            Controls.Add(panelList);
            Controls.Add(panelTitleBar);
            Controls.Add(menuStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "WalterreList";
            Text = "Liste des contats Walterre";
            Load += WalterreList_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Spain_flag).EndInit();
            ((System.ComponentModel.ISupportInitialize)England_flag).EndInit();
            ((System.ComponentModel.ISupportInitialize)France_flag).EndInit();
            panelList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ouvrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ActualiserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exporterVersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDFToolStripMenuItem;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Spain_flag;
        private System.Windows.Forms.PictureBox England_flag;
        private System.Windows.Forms.PictureBox France_flag;
        private System.Windows.Forms.ComboBox cbLang;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.DataGridView DgvList;
    }
}