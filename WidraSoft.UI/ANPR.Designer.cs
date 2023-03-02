namespace WidraSoft.UI
{
    partial class ANPR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ANPR));
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_login = new System.Windows.Forms.Button();
            this.comboBox_channel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_realplay = new System.Windows.Forms.Button();
            this.button_local = new System.Windows.Forms.Button();
            this.button_remote = new System.Windows.Forms.Button();
            this.button_span = new System.Windows.Forms.Button();
            this.pictureBox_preview = new System.Windows.Forms.PictureBox();
            this.pictureBox_image = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_image)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_ip
            // 
            this.textBox_ip.BackColor = System.Drawing.Color.Honeydew;
            this.textBox_ip.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_ip.Location = new System.Drawing.Point(109, 31);
            this.textBox_ip.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(218, 27);
            this.textBox_ip.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(28, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "Adresse IP";
            // 
            // textBox_port
            // 
            this.textBox_port.BackColor = System.Drawing.Color.Honeydew;
            this.textBox_port.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_port.Location = new System.Drawing.Point(405, 31);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(119, 27);
            this.textBox_port.TabIndex = 27;
            this.textBox_port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_port_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(361, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 19);
            this.label1.TabIndex = 28;
            this.label1.Text = "Port";
            // 
            // textBox_name
            // 
            this.textBox_name.BackColor = System.Drawing.Color.Honeydew;
            this.textBox_name.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_name.Location = new System.Drawing.Point(608, 31);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(119, 27);
            this.textBox_name.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(559, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 19);
            this.label2.TabIndex = 30;
            this.label2.Text = "Login";
            // 
            // textBox_password
            // 
            this.textBox_password.BackColor = System.Drawing.Color.Honeydew;
            this.textBox_password.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_password.Location = new System.Drawing.Point(854, 31);
            this.textBox_password.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(166, 27);
            this.textBox_password.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(753, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 19);
            this.label4.TabIndex = 32;
            this.label4.Text = "Mot de passe";
            // 
            // button_login
            // 
            this.button_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.button_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_login.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.button_login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.button_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_login.Image = global::WidraSoft.UI.Properties.Resources.expand_arrows;
            this.button_login.Location = new System.Drawing.Point(1036, 31);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(40, 27);
            this.button_login.TabIndex = 120;
            this.button_login.UseVisualStyleBackColor = false;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // comboBox_channel
            // 
            this.comboBox_channel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_channel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_channel.BackColor = System.Drawing.Color.Honeydew;
            this.comboBox_channel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.comboBox_channel.FormattingEnabled = true;
            this.comboBox_channel.Location = new System.Drawing.Point(109, 96);
            this.comboBox_channel.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_channel.Name = "comboBox_channel";
            this.comboBox_channel.Size = new System.Drawing.Size(100, 27);
            this.comboBox_channel.TabIndex = 121;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(28, 99);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 19);
            this.label5.TabIndex = 122;
            this.label5.Text = "Channel";
            // 
            // button_realplay
            // 
            this.button_realplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.button_realplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_realplay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.button_realplay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.button_realplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_realplay.ForeColor = System.Drawing.Color.White;
            this.button_realplay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_realplay.Location = new System.Drawing.Point(233, 96);
            this.button_realplay.Name = "button_realplay";
            this.button_realplay.Size = new System.Drawing.Size(193, 27);
            this.button_realplay.TabIndex = 123;
            this.button_realplay.Text = "RealPlay";
            this.button_realplay.UseVisualStyleBackColor = false;
            this.button_realplay.Click += new System.EventHandler(this.button_realplay_Click);
            // 
            // button_local
            // 
            this.button_local.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.button_local.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_local.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.button_local.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.button_local.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_local.ForeColor = System.Drawing.Color.White;
            this.button_local.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_local.Location = new System.Drawing.Point(432, 96);
            this.button_local.Name = "button_local";
            this.button_local.Size = new System.Drawing.Size(193, 27);
            this.button_local.TabIndex = 124;
            this.button_local.Text = "Local Capture";
            this.button_local.UseVisualStyleBackColor = false;
            this.button_local.Click += new System.EventHandler(this.button_local_Click);
            // 
            // button_remote
            // 
            this.button_remote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.button_remote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_remote.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.button_remote.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.button_remote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_remote.ForeColor = System.Drawing.Color.White;
            this.button_remote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_remote.Location = new System.Drawing.Point(233, 129);
            this.button_remote.Name = "button_remote";
            this.button_remote.Size = new System.Drawing.Size(193, 27);
            this.button_remote.TabIndex = 125;
            this.button_remote.Text = "Remote Capture";
            this.button_remote.UseVisualStyleBackColor = false;
            this.button_remote.Click += new System.EventHandler(this.button_remote_Click);
            // 
            // button_span
            // 
            this.button_span.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.button_span.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_span.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(228)))), ((int)(((byte)(132)))));
            this.button_span.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.button_span.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_span.ForeColor = System.Drawing.Color.White;
            this.button_span.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_span.Location = new System.Drawing.Point(432, 129);
            this.button_span.Name = "button_span";
            this.button_span.Size = new System.Drawing.Size(193, 27);
            this.button_span.TabIndex = 126;
            this.button_span.Text = "Span Capture";
            this.button_span.UseVisualStyleBackColor = false;
            this.button_span.Click += new System.EventHandler(this.button_span_Click);
            // 
            // pictureBox_preview
            // 
            this.pictureBox_preview.Location = new System.Drawing.Point(82, 208);
            this.pictureBox_preview.Name = "pictureBox_preview";
            this.pictureBox_preview.Size = new System.Drawing.Size(368, 320);
            this.pictureBox_preview.TabIndex = 127;
            this.pictureBox_preview.TabStop = false;
            // 
            // pictureBox_image
            // 
            this.pictureBox_image.Location = new System.Drawing.Point(582, 208);
            this.pictureBox_image.Name = "pictureBox_image";
            this.pictureBox_image.Size = new System.Drawing.Size(368, 320);
            this.pictureBox_image.TabIndex = 128;
            this.pictureBox_image.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(82, 182);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 19);
            this.label6.TabIndex = 129;
            this.label6.Text = "Preview";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(582, 182);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 19);
            this.label7.TabIndex = 130;
            this.label7.Text = "Image";
            // 
            // ANPR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(86)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1133, 621);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox_image);
            this.Controls.Add(this.pictureBox_preview);
            this.Controls.Add(this.button_span);
            this.Controls.Add(this.button_remote);
            this.Controls.Add(this.button_local);
            this.Controls.Add(this.button_realplay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_channel);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ANPR";
            this.Text = "ANPR";
            this.Load += new System.EventHandler(this.ANPR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.ComboBox comboBox_channel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_realplay;
        private System.Windows.Forms.Button button_local;
        private System.Windows.Forms.Button button_remote;
        private System.Windows.Forms.Button button_span;
        private System.Windows.Forms.PictureBox pictureBox_preview;
        private System.Windows.Forms.PictureBox pictureBox_image;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}