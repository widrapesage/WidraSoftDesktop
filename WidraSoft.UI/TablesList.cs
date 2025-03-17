using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WidraSoft.BL;

namespace WidraSoft.UI
{
    public partial class TablesList : Form
    {
        string vg_filter = "";
        public TablesList(string filter)
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            vg_filter = filter;
        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyMenuColors()) { }
        }

        private void TablesList_Load(object sender, EventArgs e)
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
            Tables tables = new Tables();
            DgvList.DataSource = tables.List(vg_filter);
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["NOM"].Visible = true;
            DgvList.Columns["INCLUREDANSPESEE"].Visible = false;
            DgvList.Columns["INCLUREDANSTICKET"].Visible = false;
            DgvList.Columns["ESTENTRANT"].Visible = false;
            DgvList.Columns["ESTSORTANT"].Visible = false;
            DgvList.Columns["TABLEPARENTID"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = true;
            DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            DgvList.Columns["OBSERVATIONS"].Visible = false;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;
        }

        private void Localize_Dgv(string lang)
        {
            if (lang == "fr")
            {
                DgvList.Columns["NOM"].HeaderText = "NOM";
                DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            }

            if (lang == "en")
            {
                DgvList.Columns["NOM"].HeaderText = "NAME";
                DgvList.Columns["DATECREATION"].HeaderText = "CREATION DATE";
            }

            if (lang == "es")
            {
                DgvList.Columns["NOM"].HeaderText = "APELLIDO";
                DgvList.Columns["DATECREATION"].HeaderText = "FECHA DE CREACIÓN";
            }

        }

        private void ActualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vg_filter = "1=1";
            Bind_Dgv();
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DgvList.Focus();
            Form form = new TablesDetail("Edit", Common_functions.GetDatagridViewSelectedId(DgvList));
            form.Show();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new TablesDetail("Add", 0);
            form.Show();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            Tables tables = new Tables();
            DgvList.DataSource = tables.SearchBox(txtSearchBox.Text);
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(TablesList));
                Localize_Dgv("fr");
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(TablesList));
                Localize_Dgv("en");
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(TablesList));
                Localize_Dgv("es");
            }
        }
    }
}
