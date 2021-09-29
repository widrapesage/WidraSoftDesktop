
namespace WidraSoft.UI
{
    partial class Password
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Password));
            this.label1 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btConnecter = new System.Windows.Forms.Button();
            this.btQuitter = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Condiment", 65F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label1.Location = new System.Drawing.Point(43, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(598, 198);
            this.label1.TabIndex = 1;
            this.label1.Text = "WidraSoft";
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.MintCream;
            this.txtLogin.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLogin.Location = new System.Drawing.Point(218, 265);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(423, 30);
            this.txtLogin.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(73, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(73, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mot de passe";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.MintCream;
            this.txtPassword.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.Location = new System.Drawing.Point(218, 317);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(423, 30);
            this.txtPassword.TabIndex = 4;
            // 
            // btConnecter
            // 
            this.btConnecter.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btConnecter.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btConnecter.Location = new System.Drawing.Point(218, 375);
            this.btConnecter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btConnecter.Name = "btConnecter";
            this.btConnecter.Size = new System.Drawing.Size(227, 52);
            this.btConnecter.TabIndex = 7;
            this.btConnecter.Text = "Se connecter";
            this.btConnecter.UseVisualStyleBackColor = false;
            this.btConnecter.Click += new System.EventHandler(this.btConnecter_Click);
            // 
            // btQuitter
            // 
            this.btQuitter.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btQuitter.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btQuitter.Location = new System.Drawing.Point(451, 375);
            this.btQuitter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btQuitter.Name = "btQuitter";
            this.btQuitter.Size = new System.Drawing.Size(190, 52);
            this.btQuitter.TabIndex = 8;
            this.btQuitter.Text = "Quitter";
            this.btQuitter.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label4.Location = new System.Drawing.Point(290, 515);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Propulsé par WIDRA";
            // 
            // Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(746, 540);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btQuitter);
            this.Controls.Add(this.btConnecter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Password";
            this.Text = "Identification";
            this.Load += new System.EventHandler(this.Password_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btConnecter;
        private System.Windows.Forms.Button btQuitter;
        private System.Windows.Forms.Label label4;
    }
}