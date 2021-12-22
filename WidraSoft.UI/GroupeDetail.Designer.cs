
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
            this.splitter2 = new System.Windows.Forms.Splitter();
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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupeDroits)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.Gray;
            this.splitter2.Enabled = false;
            this.splitter2.Location = new System.Drawing.Point(24, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(10, 903);
            this.splitter2.TabIndex = 17;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(24, 903);
            this.splitter1.TabIndex = 16;
            this.splitter1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btSupprimer);
            this.groupBox1.Controls.Add(this.btModifier);
            this.groupBox1.Controls.Add(this.btAjouter);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1.Font = new System.Drawing.Font("Corbel", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.groupBox1.Location = new System.Drawing.Point(41, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(982, 133);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // btSupprimer
            // 
            this.btSupprimer.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSupprimer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btSupprimer.ForeColor = System.Drawing.Color.Black;
            this.btSupprimer.Image = global::WidraSoft.UI.Properties.Resources.button_delete;
            this.btSupprimer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSupprimer.Location = new System.Drawing.Point(603, 28);
            this.btSupprimer.Name = "btSupprimer";
            this.btSupprimer.Padding = new System.Windows.Forms.Padding(0, 18, 0, 6);
            this.btSupprimer.Size = new System.Drawing.Size(112, 86);
            this.btSupprimer.TabIndex = 2;
            this.btSupprimer.Text = "Supprimer";
            this.btSupprimer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSupprimer.UseVisualStyleBackColor = false;
            this.btSupprimer.Click += new System.EventHandler(this.btSupprimer_Click);
            // 
            // btModifier
            // 
            this.btModifier.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btModifier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btModifier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btModifier.ForeColor = System.Drawing.Color.Black;
            this.btModifier.Image = global::WidraSoft.UI.Properties.Resources.button_edit;
            this.btModifier.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btModifier.Location = new System.Drawing.Point(419, 28);
            this.btModifier.Name = "btModifier";
            this.btModifier.Padding = new System.Windows.Forms.Padding(0, 18, 0, 6);
            this.btModifier.Size = new System.Drawing.Size(112, 86);
            this.btModifier.TabIndex = 1;
            this.btModifier.Text = "Modifier";
            this.btModifier.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btModifier.UseVisualStyleBackColor = false;
            this.btModifier.Click += new System.EventHandler(this.btModifier_Click);
            // 
            // btAjouter
            // 
            this.btAjouter.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAjouter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btAjouter.ForeColor = System.Drawing.Color.Black;
            this.btAjouter.Image = global::WidraSoft.UI.Properties.Resources.button_add;
            this.btAjouter.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAjouter.Location = new System.Drawing.Point(233, 28);
            this.btAjouter.Name = "btAjouter";
            this.btAjouter.Padding = new System.Windows.Forms.Padding(0, 18, 0, 6);
            this.btAjouter.Size = new System.Drawing.Size(112, 86);
            this.btAjouter.TabIndex = 0;
            this.btAjouter.Text = "Ajouter";
            this.btAjouter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btAjouter.UseVisualStyleBackColor = false;
            this.btAjouter.Click += new System.EventHandler(this.btAjouter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "Date création";
            // 
            // txtDateCreation
            // 
            this.txtDateCreation.Location = new System.Drawing.Point(219, 224);
            this.txtDateCreation.Name = "txtDateCreation";
            this.txtDateCreation.ReadOnly = true;
            this.txtDateCreation.Size = new System.Drawing.Size(370, 31);
            this.txtDateCreation.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Id";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(219, 177);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(150, 31);
            this.txtId.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "Désignation";
            // 
            // txtDesignation
            // 
            this.txtDesignation.Location = new System.Drawing.Point(219, 268);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(370, 31);
            this.txtDesignation.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 25);
            this.label4.TabIndex = 26;
            this.label4.Text = "Code groupe";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(219, 313);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(150, 31);
            this.txtCode.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 361);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 25);
            this.label7.TabIndex = 28;
            this.label7.Text = "Limiter nombre";
            // 
            // cbLimite
            // 
            this.cbLimite.FormattingEnabled = true;
            this.cbLimite.Items.AddRange(new object[] {
            "Oui",
            "Non\t"});
            this.cbLimite.Location = new System.Drawing.Point(219, 358);
            this.cbLimite.Name = "cbLimite";
            this.cbLimite.Size = new System.Drawing.Size(150, 33);
            this.cbLimite.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 25);
            this.label5.TabIndex = 30;
            this.label5.Text = "Nombre limite ";
            // 
            // txtNbLimite
            // 
            this.txtNbLimite.Location = new System.Drawing.Point(219, 405);
            this.txtNbLimite.Name = "txtNbLimite";
            this.txtNbLimite.Size = new System.Drawing.Size(150, 31);
            this.txtNbLimite.TabIndex = 29;
            // 
            // dgvGroupeDroits
            // 
            this.dgvGroupeDroits.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvGroupeDroits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupeDroits.Location = new System.Drawing.Point(72, 483);
            this.dgvGroupeDroits.Name = "dgvGroupeDroits";
            this.dgvGroupeDroits.RowHeadersWidth = 62;
            this.dgvGroupeDroits.RowTemplate.Height = 33;
            this.dgvGroupeDroits.Size = new System.Drawing.Size(926, 408);
            this.dgvGroupeDroits.TabIndex = 31;
            this.dgvGroupeDroits.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroupeDroits_CellEndEdit);
            this.dgvGroupeDroits.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvGroupeDroits_DefaultValuesNeeded);
            // 
            // GroupeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1034, 903);
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
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GroupeDetail";
            this.Text = "Groupe";
            this.Load += new System.EventHandler(this.GroupeDetail_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupeDroits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter2;
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
    }
}