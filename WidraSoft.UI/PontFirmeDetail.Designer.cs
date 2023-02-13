namespace WidraSoft.UI
{
    partial class PontFirmeDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PontFirmeDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelLang = new System.Windows.Forms.Panel();
            this.Spain_flag = new System.Windows.Forms.PictureBox();
            this.England_flag = new System.Windows.Forms.PictureBox();
            this.France_flag = new System.Windows.Forms.PictureBox();
            this.cbLang = new System.Windows.Forms.ComboBox();
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.lblDeselectionner = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblSelectionnerTout = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblEnregistrerDgv = new System.Windows.Forms.LinkLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panelLayout = new System.Windows.Forms.Panel();
            this.dgvFirmes = new System.Windows.Forms.DataGridView();
            this.panelLang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spain_flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.England_flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.France_flag)).BeginInit();
            this.panelNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panelLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFirmes)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLang
            // 
            resources.ApplyResources(this.panelLang, "panelLang");
            this.panelLang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.panelLang.Controls.Add(this.Spain_flag);
            this.panelLang.Controls.Add(this.England_flag);
            this.panelLang.Controls.Add(this.France_flag);
            this.panelLang.Controls.Add(this.cbLang);
            this.panelLang.Name = "panelLang";
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
            // 
            // panelNavigation
            // 
            resources.ApplyResources(this.panelNavigation, "panelNavigation");
            this.panelNavigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.panelNavigation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNavigation.Controls.Add(this.lblDeselectionner);
            this.panelNavigation.Controls.Add(this.pictureBox2);
            this.panelNavigation.Controls.Add(this.lblSelectionnerTout);
            this.panelNavigation.Controls.Add(this.pictureBox1);
            this.panelNavigation.Controls.Add(this.lblEnregistrerDgv);
            this.panelNavigation.Controls.Add(this.pictureBox4);
            this.panelNavigation.Name = "panelNavigation";
            // 
            // lblDeselectionner
            // 
            resources.ApplyResources(this.lblDeselectionner, "lblDeselectionner");
            this.lblDeselectionner.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.lblDeselectionner.BackColor = System.Drawing.Color.Transparent;
            this.lblDeselectionner.ForeColor = System.Drawing.Color.White;
            this.lblDeselectionner.LinkColor = System.Drawing.Color.White;
            this.lblDeselectionner.Name = "lblDeselectionner";
            this.lblDeselectionner.TabStop = true;
            this.lblDeselectionner.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDeselectionner_LinkClicked);
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::WidraSoft.UI.Properties.Resources.uncheck;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // lblSelectionnerTout
            // 
            resources.ApplyResources(this.lblSelectionnerTout, "lblSelectionnerTout");
            this.lblSelectionnerTout.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.lblSelectionnerTout.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectionnerTout.ForeColor = System.Drawing.Color.White;
            this.lblSelectionnerTout.LinkColor = System.Drawing.Color.White;
            this.lblSelectionnerTout.Name = "lblSelectionnerTout";
            this.lblSelectionnerTout.TabStop = true;
            this.lblSelectionnerTout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSelectionnerTout_LinkClicked);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::WidraSoft.UI.Properties.Resources.select;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // lblEnregistrerDgv
            // 
            resources.ApplyResources(this.lblEnregistrerDgv, "lblEnregistrerDgv");
            this.lblEnregistrerDgv.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.lblEnregistrerDgv.BackColor = System.Drawing.Color.Transparent;
            this.lblEnregistrerDgv.ForeColor = System.Drawing.Color.White;
            this.lblEnregistrerDgv.LinkColor = System.Drawing.Color.White;
            this.lblEnregistrerDgv.Name = "lblEnregistrerDgv";
            this.lblEnregistrerDgv.TabStop = true;
            this.lblEnregistrerDgv.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblEnregistrerDgv_LinkClicked);
            // 
            // pictureBox4
            // 
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::WidraSoft.UI.Properties.Resources.plus;
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
            // 
            // panelLayout
            // 
            resources.ApplyResources(this.panelLayout, "panelLayout");
            this.panelLayout.Controls.Add(this.dgvFirmes);
            this.panelLayout.Name = "panelLayout";
            // 
            // dgvFirmes
            // 
            resources.ApplyResources(this.dgvFirmes, "dgvFirmes");
            this.dgvFirmes.AllowUserToAddRows = false;
            this.dgvFirmes.AllowUserToDeleteRows = false;
            this.dgvFirmes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.dgvFirmes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFirmes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFirmes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFirmes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFirmes.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFirmes.Name = "dgvFirmes";
            this.dgvFirmes.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFirmes.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFirmes.RowTemplate.Height = 33;
            this.dgvFirmes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFirmes_CellContentClick);
            // 
            // PontFirmeDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.panelLayout);
            this.Controls.Add(this.panelNavigation);
            this.Controls.Add(this.panelLang);
            this.MaximizeBox = false;
            this.Name = "PontFirmeDetail";
            this.Load += new System.EventHandler(this.PontFirmeDetail_Load);
            this.panelLang.ResumeLayout(false);
            this.panelLang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spain_flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.England_flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.France_flag)).EndInit();
            this.panelNavigation.ResumeLayout(false);
            this.panelNavigation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panelLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFirmes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLang;
        private System.Windows.Forms.PictureBox Spain_flag;
        private System.Windows.Forms.PictureBox England_flag;
        private System.Windows.Forms.PictureBox France_flag;
        private System.Windows.Forms.ComboBox cbLang;
        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.LinkLabel lblDeselectionner;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel lblSelectionnerTout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lblEnregistrerDgv;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panelLayout;
        private System.Windows.Forms.DataGridView dgvFirmes;
    }
}