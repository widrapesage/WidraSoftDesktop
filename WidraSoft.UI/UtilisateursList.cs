using CustomMessageBox;
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
    public partial class UtilisateursList : Form
    {
        string vg_filter = "";
        public UtilisateursList(string filter)
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            vg_filter = filter;
        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyMenuColors()) { }
        }
        private void UtilisateursList_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            WindowState = FormWindowState.Maximized;
            Bind_Dgv();
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = MenuGeneral.languuage_index;
        }

        private void Bind_Dgv()
        {
            Utilisateur utilisateur = new Utilisateur();
            DgvList.DataSource = utilisateur.List(vg_filter);
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["GROUPEID"].Visible = false;
            DgvList.Columns["NOM"].Width = 250;
            DgvList.Columns["PRENOM"].Width = 250;
            DgvList.Columns["LOGIN"].Width = 200;
            DgvList.Columns["GROUPE"].Width = 200;
            DgvList.Columns["DATECREATION"].Width = 200;
            DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";


            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            DgvList.ReadOnly = true;

        }

        private void Localize_Dgv(string lang)
        {
            if (lang == "fr")
            {
                DgvList.Columns["NOM"].HeaderText = "NOM";
                DgvList.Columns["PRENOM"].HeaderText = "PRENOM";
                DgvList.Columns["LOGIN"].HeaderText = "LOGIN";
                DgvList.Columns["GROUPE"].HeaderText = "GROUPE";
                DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            }

            if (lang == "en")
            {
                DgvList.Columns["NOM"].HeaderText = "LAST NAME";
                DgvList.Columns["PRENOM"].HeaderText = "FIRST NAME";
                DgvList.Columns["LOGIN"].HeaderText = "LOGIN";
                DgvList.Columns["GROUPE"].HeaderText = "GROUP";
                DgvList.Columns["DATECREATION"].HeaderText = "CREATION DATE";
            }
            if (lang == "es")
            {
                DgvList.Columns["NOM"].HeaderText = "APELLIDO";
                DgvList.Columns["PRENOM"].HeaderText = "NOMBRE";
                DgvList.Columns["LOGIN"].HeaderText = "ACCESO";
                DgvList.Columns["GROUPE"].HeaderText = "GRUPO";
                DgvList.Columns["DATECREATION"].HeaderText = "FECHA DE CREACIÓN";
            }

        }





        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DgvList.Focus();
            Form form = new UtilisateurDetail("Edit", Common_functions.GetDatagridViewSelectedId(DgvList));
            form.Show();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new UtilisateurDetail("Add", 0);
            form.Show();
        }


        private void ActualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vg_filter = "1=1";
            Bind_Dgv();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32[] selectedIds = new Int32[Common_functions.GetDatagridViewSelectedRowsId(DgvList).Length];
            selectedIds = Common_functions.GetDatagridViewSelectedRowsId(DgvList);
            if (Common_functions.GetDatagridViewSelectedRowsId(DgvList).Length > 0)
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "Etes vous sur?", "Utilisateurs", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure?", "Users", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está usted seguro?", "Usuarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < Common_functions.GetDatagridViewSelectedRowsId(DgvList).Length; i++)
                    {
                        Utilisateur utilisateur = new Utilisateur();
                        utilisateur.Delete(selectedIds[i]);
                    }
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", Common_functions.GetDatagridViewSelectedRowsId(DgvList).Length + " utilisateur(s) supprimé(s)", "Utilisateurs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", Common_functions.GetDatagridViewSelectedRowsId(DgvList).Length + " user(s) deleted", "Users", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES ", Common_functions.GetDatagridViewSelectedRowsId(DgvList).Length + " usario(s) eliminado(s)", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Bind_Dgv();
                }
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Aucun enregistrement n'a été sélectionné", "Utilisateurs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "No row selected", "Users", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            Utilisateur utilisateur = new Utilisateur();
            DgvList.DataSource = utilisateur.SearchBox(txtSearchBox.Text);
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(UtilisateursList));
                Localize_Dgv("fr");
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(UtilisateursList));
                Localize_Dgv("en");
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(UtilisateursList));
                Localize_Dgv("es");
            }
        }

        private void DgvList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Form form = new UtilisateurDetail("Edit", Common_functions.GetDatagridViewSelectedId(DgvList));
                form.Show();
            }
            catch { throw; }
        }
    }
}
