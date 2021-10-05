using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WidraSoft.BL;

namespace WidraSoft.UI
{
    public partial class MenuGeneral : Form
    {
        public MenuGeneral(Int32 UtilisateurId)
        {
            InitializeComponent();
            Utilisateur utilisateur = new Utilisateur();
            lblusername.Text = utilisateur.GetFullUsername(UtilisateurId);
        }

        private void MenuGeneral_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();                       
        }

        private void btCamions_MouseEnter(object sender, EventArgs e)
        {
            this.btCamions.BackColor = Color.MintCream;
        }

        private void btCamions_MouseLeave(object sender, EventArgs e)
        {
            this.btCamions.BackColor = Color.MediumSeaGreen;
        }

        private void btProduits_MouseEnter(object sender, EventArgs e)
        {
            this.btProduits.BackColor = Color.MintCream;
        }

        private void btProduits_MouseLeave(object sender, EventArgs e)
        {
            this.btProduits.BackColor = Color.MediumSeaGreen;
        }

        private void btChauffeurs_MouseEnter(object sender, EventArgs e)
        {
            this.btChauffeurs.BackColor = Color.MintCream;
        }

        private void btChauffeurs_MouseLeave(object sender, EventArgs e)
        {
            this.btChauffeurs.BackColor = Color.MediumSeaGreen;
        }

        private void btTransporteurs_MouseEnter(object sender, EventArgs e)
        {
            this.btTransporteurs.BackColor = Color.MintCream;
        }

        private void btTransporteurs_MouseLeave(object sender, EventArgs e)
        {
            this.btTransporteurs.BackColor = Color.MediumSeaGreen;
        }

        private void btOriginDestination_MouseEnter(object sender, EventArgs e)
        {
            this.btOriginDestination.BackColor = Color.MintCream;
        }

        private void btOriginDestination_MouseLeave(object sender, EventArgs e)
        {
            this.btOriginDestination.BackColor = Color.MediumSeaGreen;
        }

        private void btClients_MouseEnter(object sender, EventArgs e)
        {
            this.btClients.BackColor = Color.MintCream;
        }

        private void btClients_MouseLeave(object sender, EventArgs e)
        {
            this.btClients.BackColor = Color.MediumSeaGreen;
        }

        private void btPesees_MouseEnter(object sender, EventArgs e)
        {
            this.btPesees.BackColor = Color.MintCream;
        }

        private void btPesees_MouseLeave(object sender, EventArgs e)
        {
            this.btPesees.BackColor = Color.MediumSeaGreen;
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void camionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new UtilisateursList();
            form.Show();
        }

        private void btFirmes_MouseEnter(object sender, EventArgs e)
        {
            this.btFirmes.BackColor = Color.MintCream;
        }

        private void btPonts_MouseLeave(object sender, EventArgs e)
        {
            this.btPonts.BackColor = Color.MediumSeaGreen;
        }

        private void btFirmes_MouseLeave(object sender, EventArgs e)
        {
            this.btFirmes.BackColor = Color.MediumSeaGreen;
        }

        private void btPonts_MouseEnter(object sender, EventArgs e)
        {
            this.btPonts.BackColor = Color.MintCream;
        }
    }
}
