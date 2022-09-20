
namespace WidraSoft.UI
{
    partial class GroupeDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupeDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btSupprimer = new System.Windows.Forms.Button();
            this.btModifier = new System.Windows.Forms.Button();
            this.btAjouter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDateCreation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbLimite = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNbLimite = new System.Windows.Forms.TextBox();
            this.panelLang = new System.Windows.Forms.Panel();
            this.pbTracking = new System.Windows.Forms.PictureBox();
            this.pbLocked = new System.Windows.Forms.PictureBox();
            this.Spain_flag = new System.Windows.Forms.PictureBox();
            this.England_flag = new System.Windows.Forms.PictureBox();
            this.France_flag = new System.Windows.Forms.PictureBox();
            this.cbLang = new System.Windows.Forms.ComboBox();
            this.dgvGroupeDroits = new System.Windows.Forms.DataGridView();
            this.lblRetirerDgv = new System.Windows.Forms.LinkLabel();
            this.lblEnregistrerDgv = new System.Windows.Forms.LinkLabel();
            this.pbAddRow = new System.Windows.Forms.PictureBox();
            this.pbRemoveRow = new System.Windows.Forms.PictureBox();
            this.DgvUsersList = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panelLang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTracking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLocked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spain_flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.England_flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.France_flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupeDroits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRemoveRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUsersList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btSupprimer);
            this.groupBox1.Controls.Add(this.btModifier);
            this.groupBox1.Controls.Add(this.btAjouter);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btSupprimer
            // 
            this.btSupprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.btSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btSupprimer, "btSupprimer");
            this.btSupprimer.ForeColor = System.Drawing.Color.Black;
            this.btSupprimer.Image = global::WidraSoft.UI.Properties.Resources.button_delete;
            this.btSupprimer.Name = "btSupprimer";
            this.btSupprimer.UseVisualStyleBackColor = false;
            this.btSupprimer.Click += new System.EventHandler(this.btSupprimer_Click);
            this.btSupprimer.MouseEnter += new System.EventHandler(this.btSupprimer_MouseEnter);
            this.btSupprimer.MouseLeave += new System.EventHandler(this.btSupprimer_MouseLeave);
            // 
            // btModifier
            // 
            this.btModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.btModifier.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btModifier, "btModifier");
            this.btModifier.ForeColor = System.Drawing.Color.Black;
            this.btModifier.Image = global::WidraSoft.UI.Properties.Resources.button_edit;
            this.btModifier.Name = "btModifier";
            this.btModifier.UseVisualStyleBackColor = false;
            this.btModifier.Click += new System.EventHandler(this.btModifier_Click);
            this.btModifier.MouseEnter += new System.EventHandler(this.btModifier_MouseEnter);
            this.btModifier.MouseLeave += new System.EventHandler(this.btModifier_MouseLeave);
            // 
            // btAjouter
            // 
            this.btAjouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.btAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btAjouter, "btAjouter");
            this.btAjouter.ForeColor = System.Drawing.Color.Black;
            this.btAjouter.Image = global::WidraSoft.UI.Properties.Resources.button_add;
            this.btAjouter.Name = "btAjouter";
            this.btAjouter.UseVisualStyleBackColor = false;
            this.btAjouter.Click += new System.EventHandler(this.btAjouter_Click);
            this.btAjouter.MouseEnter += new System.EventHandler(this.btAjouter_MouseEnter);
            this.btAjouter.MouseLeave += new System.EventHandler(this.btAjouter_MouseLeave);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // txtDateCreation
            // 
            this.txtDateCreation.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtDateCreation, "txtDateCreation");
            this.txtDateCreation.Name = "txtDateCreation";
            this.txtDateCreation.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtId, "txtId");
            this.txtId.Name = "txtId";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // txtDesignation
            // 
            this.txtDesignation.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtDesignation, "txtDesignation");
            this.txtDesignation.Name = "txtDesignation";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtCode, "txtCode");
            this.txtCode.Name = "txtCode";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // cbLimite
            // 
            this.cbLimite.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.cbLimite, "cbLimite");
            this.cbLimite.FormattingEnabled = true;
            this.cbLimite.Items.AddRange(new object[] {
            resources.GetString("cbLimite.Items"),
            resources.GetString("cbLimite.Items1")});
            this.cbLimite.Name = "cbLimite";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // txtNbLimite
            // 
            this.txtNbLimite.BackColor = System.Drawing.Color.Honeydew;
            resources.ApplyResources(this.txtNbLimite, "txtNbLimite");
            this.txtNbLimite.Name = "txtNbLimite";
            // 
            // panelLang
            // 
            this.panelLang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(77)))));
            this.panelLang.Controls.Add(this.pbTracking);
            this.panelLang.Controls.Add(this.pbLocked);
            this.panelLang.Controls.Add(this.Spain_flag);
            this.panelLang.Controls.Add(this.England_flag);
            this.panelLang.Controls.Add(this.France_flag);
            this.panelLang.Controls.Add(this.cbLang);
            resources.ApplyResources(this.panelLang, "panelLang");
            this.panelLang.Name = "panelLang";
            // 
            // pbTracking
            // 
            this.pbTracking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbTracking.Image = global::WidraSoft.UI.Properties.Resources.view;
            resources.ApplyResources(this.pbTracking, "pbTracking");
            this.pbTracking.Name = "pbTracking";
            this.pbTracking.TabStop = false;
            // 
            // pbLocked
            // 
            this.pbLocked.Image = global::WidraSoft.UI.Properties.Resources._lock;
            resources.ApplyResources(this.pbLocked, "pbLocked");
            this.pbLocked.Name = "pbLocked";
            this.pbLocked.TabStop = false;
            // 
            // Spain_flag
            // 
            this.Spain_flag.BackColor = System.Drawing.Color.Transparent;
            this.Spain_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Spain_flag.Image = global::WidraSoft.UI.Properties.Resources.spain;
            resources.ApplyResources(this.Spain_flag, "Spain_flag");
            this.Spain_flag.Name = "Spain_flag";
            this.Spain_flag.TabStop = false;
            // 
            // England_flag
            // 
            this.England_flag.BackColor = System.Drawing.Color.Transparent;
            this.England_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.England_flag.Image = global::WidraSoft.UI.Properties.Resources.united_kingdom;
            resources.ApplyResources(this.England_flag, "England_flag");
            this.England_flag.Name = "England_flag";
            this.England_flag.TabStop = false;
            // 
            // France_flag
            // 
            this.France_flag.BackColor = System.Drawing.Color.Transparent;
            this.France_flag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.France_flag.Image = global::WidraSoft.UI.Properties.Resources.france;
            resources.ApplyResources(this.France_flag, "France_flag");
            this.France_flag.Name = "France_flag";
            this.France_flag.TabStop = false;
            // 
            // cbLang
            // 
            this.cbLang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(77)))));
            this.cbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbLang, "cbLang");
            this.cbLang.ForeColor = System.Drawing.Color.White;
            this.cbLang.FormattingEnabled = true;
            this.cbLang.Name = "cbLang";
            this.cbLang.SelectedIndexChanged += new System.EventHandler(this.cbLang_SelectedIndexChanged);
            // 
            // dgvGroupeDroits
            // 
            this.dgvGroupeDroits.AllowUserToAddRows = false;
            this.dgvGroupeDroits.AllowUserToDeleteRows = false;
            this.dgvGroupeDroits.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.dgvGroupeDroits.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGroupeDroits.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGroupeDroits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGroupeDroits.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dgvGroupeDroits, "dgvGroupeDroits");
            this.dgvGroupeDroits.Name = "dgvGroupeDroits";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGroupeDroits.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGroupeDroits.RowTemplate.Height = 33;
            this.dgvGroupeDroits.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroupeDroits_CellEndEdit);
            // 
            // lblRetirerDgv
            // 
            this.lblRetirerDgv.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            resources.ApplyResources(this.lblRetirerDgv, "lblRetirerDgv");
            this.lblRetirerDgv.BackColor = System.Drawing.Color.Transparent;
            this.lblRetirerDgv.ForeColor = System.Drawing.Color.White;
            this.lblRetirerDgv.LinkColor = System.Drawing.Color.White;
            this.lblRetirerDgv.Name = "lblRetirerDgv";
            this.lblRetirerDgv.TabStop = true;
            this.lblRetirerDgv.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRetirerDgv_LinkClicked);
            // 
            // lblEnregistrerDgv
            // 
            this.lblEnregistrerDgv.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            resources.ApplyResources(this.lblEnregistrerDgv, "lblEnregistrerDgv");
            this.lblEnregistrerDgv.BackColor = System.Drawing.Color.Transparent;
            this.lblEnregistrerDgv.ForeColor = System.Drawing.Color.White;
            this.lblEnregistrerDgv.LinkColor = System.Drawing.Color.White;
            this.lblEnregistrerDgv.Name = "lblEnregistrerDgv";
            this.lblEnregistrerDgv.TabStop = true;
            // 
            // pbAddRow
            // 
            this.pbAddRow.BackColor = System.Drawing.Color.Transparent;
            this.pbAddRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAddRow.Image = global::WidraSoft.UI.Properties.Resources.plus;
            resources.ApplyResources(this.pbAddRow, "pbAddRow");
            this.pbAddRow.Name = "pbAddRow";
            this.pbAddRow.TabStop = false;
            // 
            // pbRemoveRow
            // 
            this.pbRemoveRow.BackColor = System.Drawing.Color.Transparent;
            this.pbRemoveRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbRemoveRow.Image = global::WidraSoft.UI.Properties.Resources.delete;
            resources.ApplyResources(this.pbRemoveRow, "pbRemoveRow");
            this.pbRemoveRow.Name = "pbRemoveRow";
            this.pbRemoveRow.TabStop = false;
            // 
            // DgvUsersList
            // 
            this.DgvUsersList.AllowUserToAddRows = false;
            this.DgvUsersList.AllowUserToDeleteRows = false;
            this.DgvUsersList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.DgvUsersList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvUsersList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvUsersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvUsersList.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.DgvUsersList, "DgvUsersList");
            this.DgvUsersList.Name = "DgvUsersList";
            this.DgvUsersList.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvUsersList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvUsersList.RowTemplate.Height = 33;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Name = "label6";
            // 
            // GroupeDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DgvUsersList);
            this.Controls.Add(this.pbRemoveRow);
            this.Controls.Add(this.pbAddRow);
            this.Controls.Add(this.lblEnregistrerDgv);
            this.Controls.Add(this.lblRetirerDgv);
            this.Controls.Add(this.dgvGroupeDroits);
            this.Controls.Add(this.panelLang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNbLimite);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbLimite);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDesignation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDateCreation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "GroupeDetail";
            this.Load += new System.EventHandler(this.GroupeDetail_Load);
            this.groupBox1.ResumeLayout(false);
            this.panelLang.ResumeLayout(false);
            this.panelLang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTracking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLocked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spain_flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.England_flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.France_flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupeDroits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRemoveRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUsersList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btSupprimer;
        private System.Windows.Forms.Button btModifier;
        private System.Windows.Forms.Button btAjouter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDateCreation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbLimite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNbLimite;
        private System.Windows.Forms.Panel panelLang;
        private System.Windows.Forms.PictureBox Spain_flag;
        private System.Windows.Forms.PictureBox England_flag;
        private System.Windows.Forms.PictureBox France_flag;
        private System.Windows.Forms.ComboBox cbLang;
        private System.Windows.Forms.DataGridView dgvGroupeDroits;
        private System.Windows.Forms.LinkLabel lblRetirerDgv;
        private System.Windows.Forms.LinkLabel lblEnregistrerDgv;
        private System.Windows.Forms.PictureBox pbAddRow;
        private System.Windows.Forms.PictureBox pbRemoveRow;
        private System.Windows.Forms.DataGridView DgvUsersList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pbLocked;
        private System.Windows.Forms.PictureBox pbTracking;
    }
}