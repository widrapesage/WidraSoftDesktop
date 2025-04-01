
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
            this.splitter1 = new System.Windows.Forms.Splitter();
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
            this.dgvGroupeDroits = new System.Windows.Forms.DataGridView();
            this.btSupprimerDgv = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupeDroits)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
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
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // txtDateCreation
            // 
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
            resources.ApplyResources(this.txtNbLimite, "txtNbLimite");
            this.txtNbLimite.Name = "txtNbLimite";
            // 
            // dgvGroupeDroits
            // 
            this.dgvGroupeDroits.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Corbel", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGroupeDroits.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGroupeDroits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGroupeDroits.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dgvGroupeDroits, "dgvGroupeDroits");
            this.dgvGroupeDroits.Name = "dgvGroupeDroits";
            this.dgvGroupeDroits.RowTemplate.Height = 33;
            this.dgvGroupeDroits.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroupeDroits_CellEndEdit);
            this.dgvGroupeDroits.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroupeDroits_CellLeave);
            this.dgvGroupeDroits.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroupeDroits_CellValueChanged);
            this.dgvGroupeDroits.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvGroupeDroits_DefaultValuesNeeded);
            // 
            // btSupprimerDgv
            // 
            this.btSupprimerDgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.btSupprimerDgv.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btSupprimerDgv, "btSupprimerDgv");
            this.btSupprimerDgv.ForeColor = System.Drawing.Color.Black;
            this.btSupprimerDgv.Image = global::WidraSoft.UI.Properties.Resources.delete_button;
            this.btSupprimerDgv.Name = "btSupprimerDgv";
            this.btSupprimerDgv.UseVisualStyleBackColor = false;
            this.btSupprimerDgv.Click += new System.EventHandler(this.btSupprimerDgv_Click);
            // 
            // GroupeDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(77)))));
            this.Controls.Add(this.btSupprimerDgv);
            this.Controls.Add(this.dgvGroupeDroits);
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
            this.Controls.Add(this.splitter1);
            this.MaximizeBox = false;
            this.Name = "GroupeDetail";
            this.Load += new System.EventHandler(this.GroupeDetail_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupeDroits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Splitter splitter1;
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
        private System.Windows.Forms.DataGridView dgvGroupeDroits;
        private System.Windows.Forms.Button btSupprimerDgv;
    }
}