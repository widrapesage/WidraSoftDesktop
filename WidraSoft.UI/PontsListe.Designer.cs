namespace WidraSoft.UI
{
    partial class PontsListe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PontsListe));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ouvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ActualiserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exporterVersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Spain_flag = new System.Windows.Forms.PictureBox();
            this.England_flag = new System.Windows.Forms.PictureBox();
            this.France_flag = new System.Windows.Forms.PictureBox();
            this.cbLang = new System.Windows.Forms.ComboBox();
            this.panelList = new System.Windows.Forms.Panel();
            this.DgvList = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spain_flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.England_flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.France_flag)).BeginInit();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouvrirToolStripMenuItem,
            this.ajouterToolStripMenuItem,
            this.supprimerToolStripMenuItem,
            this.ActualiserToolStripMenuItem,
            this.exporterVersToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // ouvrirToolStripMenuItem
            // 
            resources.ApplyResources(this.ouvrirToolStripMenuItem, "ouvrirToolStripMenuItem");
            this.ouvrirToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ouvrirToolStripMenuItem.Image = global::WidraSoft.UI.Properties.Resources.open;
            this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
            this.ouvrirToolStripMenuItem.Click += new System.EventHandler(this.ouvrirToolStripMenuItem_Click);
            // 
            // ajouterToolStripMenuItem
            // 
            resources.ApplyResources(this.ajouterToolStripMenuItem, "ajouterToolStripMenuItem");
            this.ajouterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ajouterToolStripMenuItem.Image = global::WidraSoft.UI.Properties.Resources.add;
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.ajouterToolStripMenuItem_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            resources.ApplyResources(this.supprimerToolStripMenuItem, "supprimerToolStripMenuItem");
            this.supprimerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.supprimerToolStripMenuItem.Image = global::WidraSoft.UI.Properties.Resources.remove;
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            // 
            // ActualiserToolStripMenuItem
            // 
            resources.ApplyResources(this.ActualiserToolStripMenuItem, "ActualiserToolStripMenuItem");
            this.ActualiserToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ActualiserToolStripMenuItem.Image = global::WidraSoft.UI.Properties.Resources.refresh;
            this.ActualiserToolStripMenuItem.Name = "ActualiserToolStripMenuItem";
            this.ActualiserToolStripMenuItem.Click += new System.EventHandler(this.ActualiserToolStripMenuItem_Click);
            // 
            // exporterVersToolStripMenuItem
            // 
            resources.ApplyResources(this.exporterVersToolStripMenuItem, "exporterVersToolStripMenuItem");
            this.exporterVersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem,
            this.pDFToolStripMenuItem});
            this.exporterVersToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exporterVersToolStripMenuItem.Image = global::WidraSoft.UI.Properties.Resources.export;
            this.exporterVersToolStripMenuItem.Name = "exporterVersToolStripMenuItem";
            // 
            // excelToolStripMenuItem
            // 
            resources.ApplyResources(this.excelToolStripMenuItem, "excelToolStripMenuItem");
            this.excelToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.excelToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            // 
            // pDFToolStripMenuItem
            // 
            resources.ApplyResources(this.pDFToolStripMenuItem, "pDFToolStripMenuItem");
            this.pDFToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.pDFToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.pDFToolStripMenuItem.Name = "pDFToolStripMenuItem";
            // 
            // panelTitleBar
            // 
            resources.ApplyResources(this.panelTitleBar, "panelTitleBar");
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.panelTitleBar.Controls.Add(this.txtSearchBox);
            this.panelTitleBar.Controls.Add(this.pictureBox1);
            this.panelTitleBar.Controls.Add(this.panel1);
            this.panelTitleBar.Name = "panelTitleBar";
            // 
            // txtSearchBox
            // 
            resources.ApplyResources(this.txtSearchBox, "txtSearchBox");
            this.txtSearchBox.BackColor = System.Drawing.Color.Honeydew;
            this.txtSearchBox.ForeColor = System.Drawing.Color.Black;
            this.txtSearchBox.Name = "txtSearchBox";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::WidraSoft.UI.Properties.Resources.search;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.Spain_flag);
            this.panel1.Controls.Add(this.England_flag);
            this.panel1.Controls.Add(this.France_flag);
            this.panel1.Controls.Add(this.cbLang);
            this.panel1.Name = "panel1";
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
            // cbLang
            // 
            resources.ApplyResources(this.cbLang, "cbLang");
            this.cbLang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(77)))));
            this.cbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLang.ForeColor = System.Drawing.Color.White;
            this.cbLang.FormattingEnabled = true;
            this.cbLang.Name = "cbLang";
            this.cbLang.SelectedIndexChanged += new System.EventHandler(this.cbLang_SelectedIndexChanged);
            // 
            // panelList
            // 
            resources.ApplyResources(this.panelList, "panelList");
            this.panelList.Controls.Add(this.DgvList);
            this.panelList.Name = "panelList";
            // 
            // DgvList
            // 
            resources.ApplyResources(this.DgvList, "DgvList");
            this.DgvList.AllowUserToAddRows = false;
            this.DgvList.AllowUserToDeleteRows = false;
            this.DgvList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.DgvList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvList.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvList.Name = "DgvList";
            this.DgvList.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvList.RowTemplate.Height = 33;
            // 
            // PontsListe
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.menuStrip1);
            this.Name = "PontsListe";
            this.Load += new System.EventHandler(this.PontsListe_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spain_flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.England_flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.France_flag)).EndInit();
            this.panelList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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