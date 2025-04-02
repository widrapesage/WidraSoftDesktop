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
            WindowState = FormWindowState.Maximized;
            Bind_Dgv();
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = MenuGeneral.languuage_index;
        }

        private void Bind_Dgv()
        {
            Pont pont = new Pont();
            DgvList.DataSource = pont.List(vg_filter);
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["DESIGNATION"].Visible = true;
            DgvList.Columns["NUMPORTCOM"].Visible = false;
            DgvList.Columns["WEIGHT_SETTINGSID"].Visible = false;
            DgvList.Columns["WEIGHING_SETTINGSID"].Visible = false;
            DgvList.Columns["ACTIVER_MULTIPLE_PARAM"].Visible = false;
            DgvList.Columns["ACTIVERPOIDS"].Visible = false;
            DgvList.Columns["BAUDRATE"].Visible = false;
            DgvList.Columns["DATABITS"].Visible = false;
            DgvList.Columns["STOPBITS"].Visible = false;
            DgvList.Columns["HANDSHAKE"].Visible = false;
            DgvList.Columns["READTIMEOUT"].Visible = false;
            DgvList.Columns["MACHINE"].Visible = false;
            DgvList.Columns["DEMARRAGE"].Visible = false;
            DgvList.Columns["UTILISATEURID"].Visible = false;
            DgvList.Columns["POIDS_DETECTION"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = true;
            DgvList.Columns["BORNEPREMIEREPESEE"].Visible = false;
            DgvList.Columns["BORNEDEUXIEMEPESEE"].Visible = false;
            DgvList.Columns["BORNETAREMANUELLE"].Visible = false;
            DgvList.Columns["FLUX_DEFAULT"].Visible = false;
            DgvList.Columns["ACTIVER_SCANNER"].Visible = false;
            DgvList.Columns["TYPESCANNER"].Visible = false;
            DgvList.Columns["ACTIVER_BARRIERE"].Visible = false;
            DgvList.Columns["NUMPORTCOM_BARRIERE"].Visible = false;
            DgvList.Columns["NUMPORTCOM_SCANNER"].Visible = false;
            DgvList.Columns["CONTACT1"].Visible = false;
            DgvList.Columns["CONTACT2"].Visible = false;
            DgvList.Columns["CONTACT3"].Visible = false;
            DgvList.Columns["IS_BORNE_LAUNCHED"].Visible = false;
            DgvList.Columns["ACTIVER_CAMERA1"].Visible = false;
            DgvList.Columns["ADRESSEIP_1"].Visible = false;
            DgvList.Columns["PORT_1"].Visible = false;
            DgvList.Columns["LOGIN_1"].Visible = false;
            DgvList.Columns["PASSWORD_1"].Visible = false;
            DgvList.Columns["ACTIVER_CAMERA2"].Visible = false;
            DgvList.Columns["ADRESSEIP_2"].Visible = false;
            DgvList.Columns["PORT_2"].Visible = false;
            DgvList.Columns["LOGIN_2"].Visible = false;
            DgvList.Columns["PASSWORD_2"].Visible = false;
            DgvList.Columns["ACTIVER_CAMERA3"].Visible = false;
            DgvList.Columns["ADRESSEIP_3"].Visible = false;
            DgvList.Columns["PORT_3"].Visible = false;
            DgvList.Columns["LOGIN_3"].Visible = false;
            DgvList.Columns["PASSWORD_3"].Visible = false;
            DgvList.Columns["ACTIVER_SCANNER2"].Visible = false;
            DgvList.Columns["TYPESCANNER2"].Visible = false;

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

        private void DgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Form form = new PontDetail("Edit", Common_functions.GetDatagridViewSelectedId(DgvList));
                form.Show();
            }
            catch { throw; }
        }
    }
}
