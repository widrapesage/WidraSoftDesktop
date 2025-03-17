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
    public partial class GroupesList : Form
    {
        string vg_filter = "";
        public GroupesList(string filter)
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            vg_filter = filter;
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyMenuColors()) { }
        }

        private void GroupesList_Load(object sender, EventArgs e)
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
            Groupe groupe = new Groupe();
            DgvList.DataSource = groupe.List(vg_filter);
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["DESIGNATION"].Visible = true;
            DgvList.Columns["CODE"].Visible = true;
            DgvList.Columns["LIMITER"].Visible = true;
            DgvList.Columns["NBLIMITE"].Visible= false;
            DgvList.Columns["DATECREATION"].Visible = true;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            DgvList.ReadOnly = true;

        }

        private void Localize_Dgv(string lang)
        {
            if (lang == "fr")
            {
                DgvList.Columns["DESIGNATION"].HeaderText = "DESIGNATION";
                DgvList.Columns["CODE"].HeaderText = "CODE";
                DgvList.Columns["LIMITER"].HeaderText = "LIMITER";
                DgvList.Columns["NBLIMITE"].HeaderText = "NOMBRE LIMITE";
                DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            }
            if (lang == "en")
            {
                DgvList.Columns["DESIGNATION"].HeaderText = "NAME";
                DgvList.Columns["CODE"].HeaderText = "CODE";
                DgvList.Columns["LIMITER"].HeaderText = "LIMIT";
                DgvList.Columns["NBLIMITE"].HeaderText = "LIMIT NUMBER";
                DgvList.Columns["DATECREATION"].HeaderText = "CREATION DATE";
            }
            if (lang == "es")
            {
                DgvList.Columns["DESIGNATION"].HeaderText = "DESIGNACION";
                DgvList.Columns["CODE"].HeaderText = "CODIGO";
                DgvList.Columns["LIMITER"].HeaderText = "LÍMITE";
                DgvList.Columns["NBLIMITE"].HeaderText = "NÚMERO LIMITADO";
                DgvList.Columns["DATECREATION"].HeaderText = "FECHA DE CREACIÓN";
            }

        }
        

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DgvList.Focus();          
            Form form = new GroupeDetail("Edit", Common_functions.GetDatagridViewSelectedId(DgvList));
            form.Show();           
        }

        private void ActualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vg_filter = "1=1";
            Bind_Dgv();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new GroupeDetail("Add", 0);
            form.Show();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32[] selectedIds = new Int32[Common_functions.GetDatagridViewSelectedRowsId(DgvList).Length];
            selectedIds = Common_functions.GetDatagridViewSelectedRowsId(DgvList);
            if (Common_functions.GetDatagridViewSelectedRowsId(DgvList).Length > 0)
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "Etes vous sur?", "Groupe", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure?", "Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está usted seguro?", "Grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < Common_functions.GetDatagridViewSelectedRowsId(DgvList).Length; i++)
                    {
                        Groupe groupe = new Groupe();
                        groupe.Delete(selectedIds[i]);
                    }
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", Common_functions.GetDatagridViewSelectedRowsId(DgvList).Length + " groupe(s) supprimé(s)", "Groupe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", Common_functions.GetDatagridViewSelectedRowsId(DgvList).Length + " group(s) deleted", "Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES", Common_functions.GetDatagridViewSelectedRowsId(DgvList).Length + " grupo(s) eliminado(s)", "Groupe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Bind_Dgv();
                }
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Aucun enregistrement n'a été sélectionné", "Groupe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "No row selected", "Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Grupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            Groupe groupe = new Groupe();
            DgvList.DataSource = groupe.SearchBox(txtSearchBox.Text);
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(GroupesList));
                Localize_Dgv("fr"); 
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(GroupesList));
                Localize_Dgv("en"); 
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(GroupesList));
                Localize_Dgv("es");
            }
        }       
    }
}
