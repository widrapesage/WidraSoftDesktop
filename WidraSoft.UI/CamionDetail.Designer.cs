namespace WidraSoft.UI
{
    partial class CamionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CamionDetail));
            this.btSupprimer = new System.Windows.Forms.Button();
            this.btModifier = new System.Windows.Forms.Button();
            this.btAjouter = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlaque = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDateCreation = new System.Windows.Forms.TextBox();
            this.txtBadge = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTare = new System.Windows.Forms.TextBox();
            this.txtAttention = new System.Windows.Forms.TextBox();
            this.txtBloque = new System.Windows.Forms.TextBox();
            this.txtValide = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtObservations = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAlerte = new System.Windows.Forms.TextBox();
            this.chx_Attention = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBlocage = new System.Windows.Forms.TextBox();
            this.chx_Bloque = new System.Windows.Forms.CheckBox();
            this.chx_Valide = new System.Windows.Forms.CheckBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSupprimer
            // 
            this.btSupprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.btSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSupprimer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.btSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSupprimer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btSupprimer.ForeColor = System.Drawing.Color.White;
            this.btSupprimer.Image = global::WidraSoft.UI.Properties.Resources.button_delete;
            this.btSupprimer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSupprimer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btSupprimer.Location = new System.Drawing.Point(565, 21);
            this.btSupprimer.Name = "btSupprimer";
            this.btSupprimer.Padding = new System.Windows.Forms.Padding(0, 13, 0, 5);
            this.btSupprimer.Size = new System.Drawing.Size(89, 80);
            this.btSupprimer.TabIndex = 2;
            this.btSupprimer.Text = "Supprimer";
            this.btSupprimer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSupprimer.UseVisualStyleBackColor = false;
            this.btSupprimer.Click += new System.EventHandler(this.btSupprimer_Click);
            this.btSupprimer.MouseEnter += new System.EventHandler(this.btSupprimer_MouseEnter);
            this.btSupprimer.MouseLeave += new System.EventHandler(this.btSupprimer_MouseLeave);
            // 
            // btModifier
            // 
            this.btModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.btModifier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btModifier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.btModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btModifier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btModifier.ForeColor = System.Drawing.Color.White;
            this.btModifier.Image = global::WidraSoft.UI.Properties.Resources.button_edit;
            this.btModifier.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btModifier.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btModifier.Location = new System.Drawing.Point(419, 21);
            this.btModifier.Name = "btModifier";
            this.btModifier.Padding = new System.Windows.Forms.Padding(0, 13, 0, 5);
            this.btModifier.Size = new System.Drawing.Size(89, 80);
            this.btModifier.TabIndex = 1;
            this.btModifier.Text = "Modifier";
            this.btModifier.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btModifier.UseVisualStyleBackColor = false;
            this.btModifier.Click += new System.EventHandler(this.btModifier_Click);
            this.btModifier.MouseEnter += new System.EventHandler(this.btModifier_MouseEnter);
            this.btModifier.MouseLeave += new System.EventHandler(this.btModifier_MouseLeave);
            // 
            // btAjouter
            // 
            this.btAjouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.btAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAjouter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.btAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAjouter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btAjouter.ForeColor = System.Drawing.Color.White;
            this.btAjouter.Image = global::WidraSoft.UI.Properties.Resources.button_add;
            this.btAjouter.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAjouter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btAjouter.Location = new System.Drawing.Point(269, 21);
            this.btAjouter.Name = "btAjouter";
            this.btAjouter.Padding = new System.Windows.Forms.Padding(0, 13, 0, 5);
            this.btAjouter.Size = new System.Drawing.Size(89, 80);
            this.btAjouter.TabIndex = 0;
            this.btAjouter.Text = "Ajouter";
            this.btAjouter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btAjouter.UseVisualStyleBackColor = false;
            this.btAjouter.Click += new System.EventHandler(this.btAjouter_Click);
            this.btAjouter.MouseEnter += new System.EventHandler(this.btAjouter_MouseEnter);
            this.btAjouter.MouseLeave += new System.EventHandler(this.btAjouter_MouseLeave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btSupprimer);
            this.groupBox1.Controls.Add(this.btModifier);
            this.groupBox1.Controls.Add(this.btAjouter);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Corbel", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.groupBox1.Location = new System.Drawing.Point(36, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(909, 116);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(52, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 18);
            this.label4.TabIndex = 34;
            this.label4.Text = "N° Plaque";
            // 
            // txtPlaque
            // 
            this.txtPlaque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.txtPlaque.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPlaque.ForeColor = System.Drawing.Color.White;
            this.txtPlaque.Location = new System.Drawing.Point(169, 243);
            this.txtPlaque.Name = "txtPlaque";
            this.txtPlaque.Size = new System.Drawing.Size(296, 25);
            this.txtPlaque.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(52, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 32;
            this.label3.Text = "N° Badge";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(52, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 18);
            this.label2.TabIndex = 31;
            this.label2.Text = "Date création";
            // 
            // txtDateCreation
            // 
            this.txtDateCreation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.txtDateCreation.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDateCreation.ForeColor = System.Drawing.Color.White;
            this.txtDateCreation.Location = new System.Drawing.Point(169, 180);
            this.txtDateCreation.Name = "txtDateCreation";
            this.txtDateCreation.ReadOnly = true;
            this.txtDateCreation.Size = new System.Drawing.Size(296, 25);
            this.txtDateCreation.TabIndex = 30;
            // 
            // txtBadge
            // 
            this.txtBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.txtBadge.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBadge.ForeColor = System.Drawing.Color.White;
            this.txtBadge.Location = new System.Drawing.Point(169, 211);
            this.txtBadge.Name = "txtBadge";
            this.txtBadge.Size = new System.Drawing.Size(296, 25);
            this.txtBadge.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(52, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 18);
            this.label1.TabIndex = 28;
            this.label1.Text = "Id";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.txtId.Enabled = false;
            this.txtId.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtId.ForeColor = System.Drawing.Color.White;
            this.txtId.Location = new System.Drawing.Point(169, 145);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(120, 25);
            this.txtId.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(52, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 18);
            this.label5.TabIndex = 36;
            this.label5.Text = "Code";
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.txtCode.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCode.ForeColor = System.Drawing.Color.White;
            this.txtCode.Location = new System.Drawing.Point(169, 275);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(296, 25);
            this.txtCode.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(52, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 18);
            this.label6.TabIndex = 38;
            this.label6.Text = "Tare (Kg)";
            // 
            // txtTare
            // 
            this.txtTare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.txtTare.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTare.ForeColor = System.Drawing.Color.White;
            this.txtTare.Location = new System.Drawing.Point(169, 309);
            this.txtTare.Name = "txtTare";
            this.txtTare.Size = new System.Drawing.Size(120, 25);
            this.txtTare.TabIndex = 37;
            // 
            // txtAttention
            // 
            this.txtAttention.Enabled = false;
            this.txtAttention.Location = new System.Drawing.Point(627, 387);
            this.txtAttention.Name = "txtAttention";
            this.txtAttention.Size = new System.Drawing.Size(17, 25);
            this.txtAttention.TabIndex = 66;
            // 
            // txtBloque
            // 
            this.txtBloque.Enabled = false;
            this.txtBloque.Location = new System.Drawing.Point(148, 387);
            this.txtBloque.Name = "txtBloque";
            this.txtBloque.Size = new System.Drawing.Size(17, 25);
            this.txtBloque.TabIndex = 65;
            // 
            // txtValide
            // 
            this.txtValide.Enabled = false;
            this.txtValide.Location = new System.Drawing.Point(148, 347);
            this.txtValide.Name = "txtValide";
            this.txtValide.Size = new System.Drawing.Size(17, 25);
            this.txtValide.TabIndex = 64;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(49, 495);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 18);
            this.label15.TabIndex = 63;
            this.label15.Text = "Observations";
            // 
            // txtObservations
            // 
            this.txtObservations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.txtObservations.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtObservations.ForeColor = System.Drawing.Color.White;
            this.txtObservations.Location = new System.Drawing.Point(169, 495);
            this.txtObservations.Multiline = true;
            this.txtObservations.Name = "txtObservations";
            this.txtObservations.Size = new System.Drawing.Size(776, 67);
            this.txtObservations.TabIndex = 62;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(549, 414);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 18);
            this.label14.TabIndex = 61;
            this.label14.Text = "Texte alerte";
            // 
            // txtAlerte
            // 
            this.txtAlerte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.txtAlerte.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAlerte.ForeColor = System.Drawing.Color.White;
            this.txtAlerte.Location = new System.Drawing.Point(648, 414);
            this.txtAlerte.Multiline = true;
            this.txtAlerte.Name = "txtAlerte";
            this.txtAlerte.Size = new System.Drawing.Size(296, 61);
            this.txtAlerte.TabIndex = 60;
            // 
            // chx_Attention
            // 
            this.chx_Attention.AutoSize = true;
            this.chx_Attention.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chx_Attention.ForeColor = System.Drawing.Color.White;
            this.chx_Attention.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chx_Attention.Location = new System.Drawing.Point(648, 388);
            this.chx_Attention.Name = "chx_Attention";
            this.chx_Attention.Size = new System.Drawing.Size(86, 22);
            this.chx_Attention.TabIndex = 59;
            this.chx_Attention.Text = "Attention";
            this.chx_Attention.UseVisualStyleBackColor = true;
            this.chx_Attention.CheckedChanged += new System.EventHandler(this.chx_Attention_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(49, 414);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 18);
            this.label13.TabIndex = 58;
            this.label13.Text = "Texte blocage";
            // 
            // txtBlocage
            // 
            this.txtBlocage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.txtBlocage.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBlocage.ForeColor = System.Drawing.Color.White;
            this.txtBlocage.Location = new System.Drawing.Point(169, 414);
            this.txtBlocage.Multiline = true;
            this.txtBlocage.Name = "txtBlocage";
            this.txtBlocage.Size = new System.Drawing.Size(296, 61);
            this.txtBlocage.TabIndex = 57;
            // 
            // chx_Bloque
            // 
            this.chx_Bloque.AutoSize = true;
            this.chx_Bloque.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chx_Bloque.ForeColor = System.Drawing.Color.White;
            this.chx_Bloque.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chx_Bloque.Location = new System.Drawing.Point(169, 388);
            this.chx_Bloque.Name = "chx_Bloque";
            this.chx_Bloque.Size = new System.Drawing.Size(70, 22);
            this.chx_Bloque.TabIndex = 56;
            this.chx_Bloque.Text = "Bloqué";
            this.chx_Bloque.UseVisualStyleBackColor = true;
            this.chx_Bloque.CheckedChanged += new System.EventHandler(this.chx_Bloque_CheckedChanged);
            // 
            // chx_Valide
            // 
            this.chx_Valide.AutoSize = true;
            this.chx_Valide.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chx_Valide.ForeColor = System.Drawing.Color.White;
            this.chx_Valide.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chx_Valide.Location = new System.Drawing.Point(169, 350);
            this.chx_Valide.Name = "chx_Valide";
            this.chx_Valide.Size = new System.Drawing.Size(64, 22);
            this.chx_Valide.TabIndex = 55;
            this.chx_Valide.Text = "Valide";
            this.chx_Valide.UseVisualStyleBackColor = true;
            this.chx_Valide.CheckedChanged += new System.EventHandler(this.chx_Valide_CheckedChanged);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 653);
            this.splitter1.TabIndex = 67;
            this.splitter1.TabStop = false;
            // 
            // CamionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(979, 653);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.txtAttention);
            this.Controls.Add(this.txtBloque);
            this.Controls.Add(this.txtValide);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtObservations);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtAlerte);
            this.Controls.Add(this.chx_Attention);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtBlocage);
            this.Controls.Add(this.chx_Bloque);
            this.Controls.Add(this.chx_Valide);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTare);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPlaque);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDateCreation);
            this.Controls.Add(this.txtBadge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Corbel", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CamionDetail";
            this.Text = "Camion";
            this.Load += new System.EventHandler(this.CamionDetail_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btSupprimer;
        private System.Windows.Forms.Button btModifier;
        private System.Windows.Forms.Button btAjouter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPlaque;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDateCreation;
        private System.Windows.Forms.TextBox txtBadge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTare;
        private System.Windows.Forms.TextBox txtAttention;
        private System.Windows.Forms.TextBox txtBloque;
        private System.Windows.Forms.TextBox txtValide;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtObservations;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAlerte;
        private System.Windows.Forms.CheckBox chx_Attention;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBlocage;
        private System.Windows.Forms.CheckBox chx_Bloque;
        private System.Windows.Forms.CheckBox chx_Valide;
        private System.Windows.Forms.Splitter splitter1;
    }
}