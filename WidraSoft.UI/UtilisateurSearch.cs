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
    public partial class UtilisateurSearch : Form
    {

        public UtilisateurSearch()
        {
            InitializeComponent();

        }

        private void UtilisateurSearch_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            Groupe groupe = new Groupe();
            cbGroupe.DataSource = groupe.List("1=1");
            cbGroupe.DisplayMember = "DESIGNATION";
            cbGroupe.ValueMember = "GROUPEID";
            Clear();
        }

        private void Clear()
        {
            txtLogin.Text = "";
            txtNom.Text = "";
            txtPrenom.Text = "";
            cbGroupe.Text = "";
        }

        private string Filter()
        {
            string filter = "1=1";
            if (!string.IsNullOrEmpty(txtNom.Text))
                filter = filter + " AND NOM LIKE '%" + txtNom.Text + "%'";
            if (!string.IsNullOrEmpty(txtPrenom.Text))
                filter = filter + " AND PRENOM LIKE '%" + txtPrenom.Text + "%'";
            if (!string.IsNullOrEmpty(txtLogin.Text))
                filter = filter + " AND LOGIN LIKE '%" + txtLogin.Text + "%'";
            if (!string.IsNullOrEmpty(cbGroupe.Text))
                filter = filter + " AND GROUPEID =" + cbGroupe.SelectedValue;

            return filter;

        }

        private void btRecherche_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
                if (f.Name == "UtilisateursList")
                {
                    f.Close();
                }
            Form form = new UtilisateursList(Filter());          
            form.Show();
            Close();
        }

        private void btAnnuler_Click(object sender, EventArgs e)
        {
            Clear();
            Form form = new UtilisateursList("1=1");
            form.Show();
            Close();
        }


    }
}
