namespace WidraSoft.UI
{
    partial class Borne_DeuxiemePesee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Borne_DeuxiemePesee));
            this.lbTexte = new System.Windows.Forms.Label();
            this.btAnnuler = new System.Windows.Forms.Button();
            this.btValider = new System.Windows.Forms.Button();
            this.txtPoids = new System.Windows.Forms.TextBox();
            this.lbMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbTexte
            // 
            this.lbTexte.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTexte.AutoSize = true;
            this.lbTexte.Font = new System.Drawing.Font("Corbel", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTexte.ForeColor = System.Drawing.Color.White;
            this.lbTexte.Location = new System.Drawing.Point(282, 243);
            this.lbTexte.Name = "lbTexte";
            this.lbTexte.Size = new System.Drawing.Size(343, 46);
            this.lbTexte.TabIndex = 4;
            this.lbTexte.Text = "Confirmer le poids 2";
            // 
            // btAnnuler
            // 
            this.btAnnuler.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btAnnuler.BackColor = System.Drawing.Color.Black;
            this.btAnnuler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.btAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.btAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAnnuler.Font = new System.Drawing.Font("Corbel", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btAnnuler.ForeColor = System.Drawing.Color.Tomato;
            this.btAnnuler.Location = new System.Drawing.Point(568, 310);
            this.btAnnuler.Name = "btAnnuler";
            this.btAnnuler.Size = new System.Drawing.Size(177, 104);
            this.btAnnuler.TabIndex = 122;
            this.btAnnuler.Text = "ANNULER";
            this.btAnnuler.UseVisualStyleBackColor = false;
            this.btAnnuler.Click += new System.EventHandler(this.btAnnuler_Click);
            // 
            // btValider
            // 
            this.btValider.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btValider.BackColor = System.Drawing.Color.Black;
            this.btValider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btValider.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.btValider.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.btValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btValider.Font = new System.Drawing.Font("Corbel", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btValider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.btValider.Location = new System.Drawing.Point(209, 310);
            this.btValider.Name = "btValider";
            this.btValider.Size = new System.Drawing.Size(177, 104);
            this.btValider.TabIndex = 121;
            this.btValider.Text = "CONFIRMER";
            this.btValider.UseVisualStyleBackColor = false;
            this.btValider.Click += new System.EventHandler(this.btValider_Click);
            // 
            // txtPoids
            // 
            this.txtPoids.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPoids.BackColor = System.Drawing.Color.Black;
            this.txtPoids.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPoids.Font = new System.Drawing.Font("Calibri", 60F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.txtPoids.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.txtPoids.Location = new System.Drawing.Point(209, 14);
            this.txtPoids.Name = "txtPoids";
            this.txtPoids.Size = new System.Drawing.Size(536, 98);
            this.txtPoids.TabIndex = 139;
            this.txtPoids.TabStop = false;
            this.txtPoids.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbMessage
            // 
            this.lbMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbMessage.Font = new System.Drawing.Font("Corbel", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbMessage.ForeColor = System.Drawing.Color.White;
            this.lbMessage.Location = new System.Drawing.Point(209, 117);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(536, 118);
            this.lbMessage.TabIndex = 140;
            this.lbMessage.Text = "..";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Borne_DeuxiemePesee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(929, 453);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.txtPoids);
            this.Controls.Add(this.btAnnuler);
            this.Controls.Add(this.btValider);
            this.Controls.Add(this.lbTexte);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Borne_DeuxiemePesee";
            this.Load += new System.EventHandler(this.Borne_DeuxiemePesee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTexte;
        private System.Windows.Forms.Button btAnnuler;
        private System.Windows.Forms.Button btValider;
        private System.Windows.Forms.TextBox txtPoids;
        private System.Windows.Forms.Label lbMessage;
    }
}