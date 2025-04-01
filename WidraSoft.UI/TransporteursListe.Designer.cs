namespace WidraSoft.UI
{
    partial class TransporteursListe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransporteursListe));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ouvrirToolStripMenuItem, ajouterToolStripMenuItem, supprimerToolStripMenuItem, ActualiserToolStripMenuItem, exporterVersToolStripMenuItem });
            menuStrip1.Name = "menuStrip1";
            // 
            // ouvrirToolStripMenuItem
            // 
            resources.ApplyResources(ouvrirToolStripMenuItem, "ouvrirToolStripMenuItem");
            ouvrirToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            ouvrirToolStripMenuItem.Image = Properties.Resources.open;
            ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
            ouvrirToolStripMenuItem.Click += ouvrirToolStripMenuItem_Click;
            // 
            // ajouterToolStripMenuItem
            // 
            resources.ApplyResources(ajouterToolStripMenuItem, "ajouterToolStripMenuItem");
            ajouterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            ajouterToolStripMenuItem.Image = Properties.Resources.add;
            ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            ajouterToolStripMenuItem.Click += ajouterToolStripMenuItem_Click;
            // 
            // supprimerToolStripMenuItem
            // 
            resources.ApplyResources(supprimerToolStripMenuItem, "supprimerToolStripMenuItem");
            supprimerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            supprimerToolStripMenuItem.Image = Properties.Resources.remove;
            supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            // 
            // ActualiserToolStripMenuItem
            // 
            resources.ApplyResources(ActualiserToolStripMenuItem, "ActualiserToolStripMenuItem");
            ActualiserToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            ActualiserToolStripMenuItem.Image = Properties.Resources.refresh;
            ActualiserToolStripMenuItem.Name = "ActualiserToolStripMenuItem";
            ActualiserToolStripMenuItem.Click += ActualiserToolStripMenuItem_Click;
            // 
            // exporterVersToolStripMenuItem
            // 
            exporterVersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { excelToolStripMenuItem, pDFToolStripMenuItem });
            resources.ApplyResources(exporterVersToolStripMenuItem, "exporterVersToolStripMenuItem");
            exporterVersToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            exporterVersToolStripMenuItem.Image = Properties.Resources.export;
            exporterVersToolStripMenuItem.Name = "exporterVersToolStripMenuItem";
            // 
            // excelToolStripMenuItem
            // 
            excelToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(58, 62, 60);
            excelToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            resources.ApplyResources(excelToolStripMenuItem, "excelToolStripMenuItem");
            // 
            // pDFToolStripMenuItem
            // 
            pDFToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(58, 62, 60);
            pDFToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            pDFToolStripMenuItem.Name = "pDFToolStripMenuItem";
            resources.ApplyResources(pDFToolStripMenuItem, "pDFToolStripMenuItem");
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = System.Drawing.Color.FromArgb(72, 86, 81);
            panelTitleBar.Controls.Add(txtSearchBox);
            panelTitleBar.Controls.Add(pictureBox1);
            panelTitleBar.Controls.Add(panel1);
            resources.ApplyResources(panelTitleBar, "panelTitleBar");
            panelTitleBar.Name = "panelTitleBar";
            // 
            // txtSearchBox
            // 
            txtSearchBox.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(txtSearchBox, "txtSearchBox");
            txtSearchBox.ForeColor = System.Drawing.Color.Black;
            txtSearchBox.Name = "txtSearchBox";
            txtSearchBox.TextChanged += txtSearchBox_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox1.Image = Properties.Resources.search;
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(Spain_flag);
            panel1.Controls.Add(England_flag);
            panel1.Controls.Add(France_flag);
            panel1.Controls.Add(cbLang);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // Spain_flag
            // 
            Spain_flag.BackColor = System.Drawing.Color.Transparent;
            Spain_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            Spain_flag.Image = Properties.Resources.spain;
            resources.ApplyResources(Spain_flag, "Spain_flag");
            Spain_flag.Name = "Spain_flag";
            Spain_flag.TabStop = false;
            // 
            // England_flag
            // 
            England_flag.BackColor = System.Drawing.Color.Transparent;
            England_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            England_flag.Image = Properties.Resources.united_kingdom;
            resources.ApplyResources(England_flag, "England_flag");
            England_flag.Name = "England_flag";
            England_flag.TabStop = false;
            // 
            // France_flag
            // 
            France_flag.BackColor = System.Drawing.Color.Transparent;
            France_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            France_flag.Image = Properties.Resources.france;
            resources.ApplyResources(France_flag, "France_flag");
            France_flag.Name = "France_flag";
            France_flag.TabStop = false;
            // 
            // cbLang
            // 
            cbLang.BackColor = System.Drawing.Color.FromArgb(72, 86, 77);
            cbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(cbLang, "cbLang");
            cbLang.ForeColor = System.Drawing.Color.White;
            cbLang.FormattingEnabled = true;
            cbLang.Name = "cbLang";
            cbLang.SelectedIndexChanged += cbLang_SelectedIndexChanged;
            // 
            // panelList
            // 
            panelList.Controls.Add(DgvList);
            resources.ApplyResources(panelList, "panelList");
            panelList.Name = "panelList";
            // 
            // DgvList
            // 
            DgvList.AllowUserToAddRows = false;
            DgvList.AllowUserToDeleteRows = false;
            DgvList.BackgroundColor = System.Drawing.Color.FromArgb(72, 86, 81);
            DgvList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(72, 86, 77);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(72, 190, 117);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
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
            resources.ApplyResources(DgvList, "DgvList");
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
            DgvList.RowTemplate.Height = 33;
            DgvList.CellDoubleClick += DgvList_CellDoubleClick;
            // 
            // TransporteursListe
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(58, 62, 60);
            Controls.Add(panelList);
            Controls.Add(panelTitleBar);
            Controls.Add(menuStrip1);
            Name = "TransporteursListe";
            Load += TransporteursListe_Load;
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