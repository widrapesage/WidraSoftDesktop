
namespace WidraSoft.UI
{
    partial class MenuGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuGeneral));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.camionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chauffeursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paramètresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btCamions = new System.Windows.Forms.PictureBox();
            this.btProduits = new System.Windows.Forms.PictureBox();
            this.btChauffeurs = new System.Windows.Forms.PictureBox();
            this.btTransporteurs = new System.Windows.Forms.PictureBox();
            this.btOriginDestination = new System.Windows.Forms.PictureBox();
            this.btClients = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btCamions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btProduits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btChauffeurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btTransporteurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btOriginDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btClients)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gray;
            this.menuStrip1.Font = new System.Drawing.Font("Corbel", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.camionsToolStripMenuItem,
            this.chauffeursToolStripMenuItem,
            this.paramètresToolStripMenuItem,
            this.reportingToolStripMenuItem,
            this.aideToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1238, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // camionsToolStripMenuItem
            // 
            this.camionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("camionsToolStripMenuItem.Image")));
            this.camionsToolStripMenuItem.Name = "camionsToolStripMenuItem";
            this.camionsToolStripMenuItem.Size = new System.Drawing.Size(182, 36);
            this.camionsToolStripMenuItem.Text = "Utilisateurs";
            // 
            // chauffeursToolStripMenuItem
            // 
            this.chauffeursToolStripMenuItem.Image = global::WidraSoft.UI.Properties.Resources.Groupes;
            this.chauffeursToolStripMenuItem.Name = "chauffeursToolStripMenuItem";
            this.chauffeursToolStripMenuItem.Size = new System.Drawing.Size(146, 36);
            this.chauffeursToolStripMenuItem.Text = "Groupes";
            // 
            // paramètresToolStripMenuItem
            // 
            this.paramètresToolStripMenuItem.Image = global::WidraSoft.UI.Properties.Resources.Settings;
            this.paramètresToolStripMenuItem.Name = "paramètresToolStripMenuItem";
            this.paramètresToolStripMenuItem.Size = new System.Drawing.Size(183, 36);
            this.paramètresToolStripMenuItem.Text = "Paramètres";
            // 
            // reportingToolStripMenuItem
            // 
            this.reportingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportingToolStripMenuItem.Image")));
            this.reportingToolStripMenuItem.Name = "reportingToolStripMenuItem";
            this.reportingToolStripMenuItem.Size = new System.Drawing.Size(163, 36);
            this.reportingToolStripMenuItem.Text = "Reporting";
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.Image = global::WidraSoft.UI.Properties.Resources.Aide;
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(110, 36);
            this.aideToolStripMenuItem.Text = "Aide ";
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Image = global::WidraSoft.UI.Properties.Resources.Quitter;
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(136, 36);
            this.quitterToolStripMenuItem.Text = "Quitter";
            // 
            // btCamions
            // 
            this.btCamions.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btCamions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btCamions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCamions.Image = global::WidraSoft.UI.Properties.Resources.Trucks;
            this.btCamions.Location = new System.Drawing.Point(165, 151);
            this.btCamions.Name = "btCamions";
            this.btCamions.Size = new System.Drawing.Size(213, 156);
            this.btCamions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btCamions.TabIndex = 1;
            this.btCamions.TabStop = false;
            this.btCamions.MouseEnter += new System.EventHandler(this.btCamions_MouseEnter);
            this.btCamions.MouseLeave += new System.EventHandler(this.btCamions_MouseLeave);
            // 
            // btProduits
            // 
            this.btProduits.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btProduits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btProduits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btProduits.Image = ((System.Drawing.Image)(resources.GetObject("btProduits.Image")));
            this.btProduits.Location = new System.Drawing.Point(540, 151);
            this.btProduits.Name = "btProduits";
            this.btProduits.Size = new System.Drawing.Size(213, 156);
            this.btProduits.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btProduits.TabIndex = 2;
            this.btProduits.TabStop = false;
            this.btProduits.MouseEnter += new System.EventHandler(this.btProduits_MouseEnter);
            this.btProduits.MouseLeave += new System.EventHandler(this.btProduits_MouseLeave);
            // 
            // btChauffeurs
            // 
            this.btChauffeurs.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btChauffeurs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btChauffeurs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btChauffeurs.Image = ((System.Drawing.Image)(resources.GetObject("btChauffeurs.Image")));
            this.btChauffeurs.Location = new System.Drawing.Point(907, 151);
            this.btChauffeurs.Name = "btChauffeurs";
            this.btChauffeurs.Size = new System.Drawing.Size(213, 156);
            this.btChauffeurs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btChauffeurs.TabIndex = 3;
            this.btChauffeurs.TabStop = false;
            this.btChauffeurs.MouseEnter += new System.EventHandler(this.btChauffeurs_MouseEnter);
            this.btChauffeurs.MouseLeave += new System.EventHandler(this.btChauffeurs_MouseLeave);
            // 
            // btTransporteurs
            // 
            this.btTransporteurs.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btTransporteurs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btTransporteurs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btTransporteurs.Image = ((System.Drawing.Image)(resources.GetObject("btTransporteurs.Image")));
            this.btTransporteurs.Location = new System.Drawing.Point(165, 391);
            this.btTransporteurs.Name = "btTransporteurs";
            this.btTransporteurs.Size = new System.Drawing.Size(213, 156);
            this.btTransporteurs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btTransporteurs.TabIndex = 4;
            this.btTransporteurs.TabStop = false;
            // 
            // btOriginDestination
            // 
            this.btOriginDestination.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btOriginDestination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btOriginDestination.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btOriginDestination.Image = ((System.Drawing.Image)(resources.GetObject("btOriginDestination.Image")));
            this.btOriginDestination.Location = new System.Drawing.Point(540, 391);
            this.btOriginDestination.Name = "btOriginDestination";
            this.btOriginDestination.Size = new System.Drawing.Size(213, 156);
            this.btOriginDestination.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btOriginDestination.TabIndex = 5;
            this.btOriginDestination.TabStop = false;
            // 
            // btClients
            // 
            this.btClients.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btClients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btClients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btClients.Image = ((System.Drawing.Image)(resources.GetObject("btClients.Image")));
            this.btClients.Location = new System.Drawing.Point(907, 391);
            this.btClients.Name = "btClients";
            this.btClients.Size = new System.Drawing.Size(213, 156);
            this.btClients.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btClients.TabIndex = 6;
            this.btClients.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 40);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(40, 772);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.Gray;
            this.splitter2.Enabled = false;
            this.splitter2.Location = new System.Drawing.Point(40, 40);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(10, 772);
            this.splitter2.TabIndex = 8;
            this.splitter2.TabStop = false;
            // 
            // MenuGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1238, 812);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btClients);
            this.Controls.Add(this.btOriginDestination);
            this.Controls.Add(this.btTransporteurs);
            this.Controls.Add(this.btChauffeurs);
            this.Controls.Add(this.btProduits);
            this.Controls.Add(this.btCamions);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuGeneral";
            this.Text = "Menu General";
            this.Load += new System.EventHandler(this.MenuGeneral_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btCamions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btProduits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btChauffeurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btTransporteurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btOriginDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem camionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chauffeursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paramètresToolStripMenuItem;
        private System.Windows.Forms.PictureBox btCamions;
        private System.Windows.Forms.PictureBox btProduits;
        private System.Windows.Forms.PictureBox btChauffeurs;
        private System.Windows.Forms.PictureBox btTransporteurs;
        private System.Windows.Forms.PictureBox btOriginDestination;
        private System.Windows.Forms.PictureBox btClients;
        private System.Windows.Forms.ToolStripMenuItem reportingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
    }
}