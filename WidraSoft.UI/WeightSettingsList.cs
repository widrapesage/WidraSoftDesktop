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
    public partial class WeightSettingsList : Form
    {
        string vg_filter = "";
        public WeightSettingsList(string filter)
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            vg_filter = filter;
        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyMenuColors()) { }
        }

        private void WeightSettingsList_Load(object sender, EventArgs e)
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
            WeightSettings weightSettings = new WeightSettings();
            DgvList.DataSource = weightSettings.List(vg_filter);
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["DESIGNATION"].Visible = true;
            DgvList.Columns["TIMERINTERVAL"].Visible = false;
            DgvList.Columns["LONGUEURMINCHAINE"].Visible = false;
            DgvList.Columns["POSITIONDEBUT"].Visible = false;
            DgvList.Columns["LONGUEURCHAINE"].Visible = false;
            DgvList.Columns["CARACTERESEPARATION"].Visible = false;
            DgvList.Columns["MODELECTURE"].Visible = false;
            DgvList.Columns["STABILITE"].Visible = false;
            DgvList.Columns["POSITIONSTABILTE"].Visible = false;
            DgvList.Columns["VALEURSTABLE"].Visible = false;
            DgvList.Columns["NEGATIF"].Visible = false;
            DgvList.Columns["POSITIONNEGATIF"].Visible = false;
            DgvList.Columns["VALEURNEGATIF"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = true;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;
        }

        private void Localize_Dgv(string lang)
        {
            if (lang == "fr")
            {
                DgvList.Columns["DESIGNATION"].HeaderText = "DESIGNATION";
                DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            }

            if (lang == "en")
            {
                DgvList.Columns["DESIGNATION"].HeaderText = "NAME";
                DgvList.Columns["DATECREATION"].HeaderText = "CREATION DATE";
            }

            if (lang == "es")
            {
                DgvList.Columns["DESIGNATION"].HeaderText = "DESIGNACIÓN";
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
            Form form = new WeightSettingsDetail("Edit", Common_functions.GetDatagridViewSelectedId(DgvList));
            form.Show();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new WeightSettingsDetail("Add", 0);
            form.Show();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            WeightSettings weightSettings = new WeightSettings();
            DgvList.DataSource = weightSettings.SearchBox(txtSearchBox.Text);
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(WeightSettingsList));
                Localize_Dgv("fr");
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(WeightSettingsList));
                Localize_Dgv("en");
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(WeightSettingsList));
                Localize_Dgv("es");
            }
        }
    }
}
