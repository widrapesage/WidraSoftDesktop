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
    public partial class PontsListe : Form
    {
        string vg_filter = "";
        public PontsListe(string filter)
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            vg_filter = filter;
        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyMenuColors()) { }
        }

        private void PontsListe_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            Bind_Dgv();
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = 0;
        }

        private void Bind_Dgv()
        {
            Pont pont = new Pont();
            DgvList.DataSource = pont.List(vg_filter);
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["DESIGNATION"].Visible = true;
            DgvList.Columns["NUMPORTCOM"].Visible = true;
            DgvList.Columns["WEIGHT_SETTINGSID"].Visible = false;
            DgvList.Columns["ACTIVERPOIDS"].Visible = false;
            DgvList.Columns["BAUDRATE"].Visible = false;
            DgvList.Columns["DATABITS"].Visible = false;
            DgvList.Columns["STOPBITS"].Visible = false;
            DgvList.Columns["HANDSHAKE"].Visible = false;
            DgvList.Columns["READTIMEOUT"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = true;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;
        }

        private void Localize_Dgv(string lang)
        {
            if (lang == "fr")
            {
                DgvList.Columns["DESIGNATION"].HeaderText = "DESIGNATION";
                DgvList.Columns["NUMPORTCOM"].HeaderText = "COM";
                DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            }

            if (lang == "en")
            {
                DgvList.Columns["DESIGNATION"].HeaderText = "NAME";
                DgvList.Columns["NUMPORTCOM"].HeaderText = "COM";
                DgvList.Columns["DATECREATION"].HeaderText = "CREATION DATE";
            }

            if (lang == "es")
            {
                DgvList.Columns["DESIGNATION"].HeaderText = "DESIGNACIÓN";
                DgvList.Columns["NUMPORTCOM"].HeaderText = "COM";
                DgvList.Columns["DATECREATION"].HeaderText = "CREATION DATE";
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
            Form form = new PontDetail("Edit", Common_functions.GetDatagridViewSelectedId(DgvList));
            form.Show();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new PontDetail("Add", 0);
            form.Show();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            Pont pont = new Pont();
            DgvList.DataSource = pont.SearchBox(txtSearchBox.Text);
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(PontsListe));
                Localize_Dgv("fr");
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(PontsListe));
                Localize_Dgv("en");
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(PontsListe));
                Localize_Dgv("es");
            }
        }
    }
}
