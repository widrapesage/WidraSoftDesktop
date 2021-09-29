using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WidraSoft.UI
{
    public partial class MenuGeneral : Form
    {
        public MenuGeneral()
        {
            InitializeComponent();
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
    }
}
