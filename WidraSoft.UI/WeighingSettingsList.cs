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
    public partial class WeighingSettingsList : Form
    {
        string vg_filter = "";
        public WeighingSettingsList(string filter)
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            vg_filter = filter;
        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyMenuColors()) { }
        }

        private void WeighingSettingsList_Load(object sender, EventArgs e)
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
            WeighingSettings weighingSettings = new WeighingSettings();
            DgvList.DataSource = weighingSettings.List(vg_filter);
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["DESIGNATION"].Visible = true;
            DgvList.Columns["CAMION"].Visible = false;
            DgvList.Columns["CHAUFFEUR"].Visible = false;
            DgvList.Columns["TRANSPORTEUR"].Visible = false;
            DgvList.Columns["PRODUIT"].Visible = false;
            DgvList.Columns["CLIENT"].Visible = false;
            DgvList.Columns["FIRME"].Visible = false;
            DgvList.Columns["CAMION_OBL"].Visible = false;
            DgvList.Columns["CHAUFFEUR_OBL"].Visible = false;
            DgvList.Columns["TRANSPORTEUR_OBL"].Visible = false;
            DgvList.Columns["PRODUIT_OBL"].Visible = false;
            DgvList.Columns["CLIENT_OBL"].Visible = false;
            DgvList.Columns["FIRME_OBL"].Visible = false;
            DgvList.Columns["CAMION_BORNE"].Visible = false;
            DgvList.Columns["CHAUFFEUR_BORNE"].Visible = false;
            DgvList.Columns["TRANSPORTEUR_BORNE"].Visible = false;
            DgvList.Columns["PRODUIT_BORNE"].Visible = false;
            DgvList.Columns["CLIENT_BORNE"].Visible = false;
            DgvList.Columns["FIRME_BORNE"].Visible = false;
            DgvList.Columns["CAMION_AJOUT_F"].Visible = false;
            DgvList.Columns["CHAUFFEUR_AJOUT_F"].Visible = false;
            DgvList.Columns["TRANSPORTEUR_AJOUT_F"].Visible = false;
            DgvList.Columns["PRODUIT_AJOUT_F"].Visible = false;
            DgvList.Columns["CLIENT_AJOUT_F"].Visible = false;
            DgvList.Columns["FIRME_AJOUT_F"].Visible = false;
            DgvList.Columns["TABLE1_ID"].Visible = false;
            DgvList.Columns["TABLE2_ID"].Visible = false;
            DgvList.Columns["TABLE3_ID"].Visible = false;
            DgvList.Columns["TABLE4_ID"].Visible = false;
            DgvList.Columns["TABLE5_ID"].Visible = false;
            DgvList.Columns["TABLE6_ID"].Visible = false;
            DgvList.Columns["TABLE7_ID"].Visible = false;
            DgvList.Columns["TABLE1_OBL"].Visible = false;
            DgvList.Columns["TABLE2_OBL"].Visible = false;
            DgvList.Columns["TABLE3_OBL"].Visible = false;
            DgvList.Columns["TABLE4_OBL"].Visible = false;
            DgvList.Columns["TABLE5_OBL"].Visible = false;
            DgvList.Columns["TABLE6_OBL"].Visible = false;
            DgvList.Columns["TABLE7_OBL"].Visible = false;
            DgvList.Columns["TABLE1_CODE"].Visible = false;
            DgvList.Columns["TABLE2_CODE"].Visible = false;
            DgvList.Columns["TABLE3_CODE"].Visible = false;
            DgvList.Columns["TABLE4_CODE"].Visible = false;
            DgvList.Columns["TABLE5_CODE"].Visible = false;
            DgvList.Columns["TABLE6_CODE"].Visible = false;
            DgvList.Columns["TABLE7_CODE"].Visible = false;
            DgvList.Columns["TABLE1_BORNE"].Visible = false;
            DgvList.Columns["TABLE2_BORNE"].Visible = false;
            DgvList.Columns["TABLE3_BORNE"].Visible = false;
            DgvList.Columns["TABLE4_BORNE"].Visible = false;
            DgvList.Columns["TABLE5_BORNE"].Visible = false;
            DgvList.Columns["TABLE6_BORNE"].Visible = false;
            DgvList.Columns["TABLE7_BORNE"].Visible = false;
            DgvList.Columns["TABLE1_TICKET"].Visible = false;
            DgvList.Columns["TABLE2_TICKET"].Visible = false;
            DgvList.Columns["TABLE3_TICKET"].Visible = false;
            DgvList.Columns["TABLE4_TICKET"].Visible = false;
            DgvList.Columns["TABLE5_TICKET"].Visible = false;
            DgvList.Columns["TABLE6_TICKET"].Visible = false;
            DgvList.Columns["TABLE7_TICKET"].Visible = false;
            DgvList.Columns["TABLE1_AJOUT_F"].Visible = false;
            DgvList.Columns["TABLE2_AJOUT_F"].Visible = false;
            DgvList.Columns["TABLE3_AJOUT_F"].Visible = false;
            DgvList.Columns["TABLE4_AJOUT_F"].Visible = false;
            DgvList.Columns["TABLE5_AJOUT_F"].Visible = false;
            DgvList.Columns["TABLE6_AJOUT_F"].Visible = false;
            DgvList.Columns["TABLE7_AJOUT_F"].Visible = false;
            DgvList.Columns["CHAMPLIBRE1"].Visible = false;
            DgvList.Columns["CHAMPLIBRE2"].Visible = false;
            DgvList.Columns["CHAMPLIBRE3"].Visible = false;
            DgvList.Columns["CHAMPLIBRE4"].Visible = false;
            DgvList.Columns["CHAMPLIBRE1_OBL"].Visible = false;
            DgvList.Columns["CHAMPLIBRE2_OBL"].Visible = false;
            DgvList.Columns["CHAMPLIBRE3_OBL"].Visible = false;
            DgvList.Columns["CHAMPLIBRE4_OBL"].Visible = false;
            DgvList.Columns["CHAMPLIBRE1_TICKET"].Visible = false;
            DgvList.Columns["CHAMPLIBRE2_TICKET"].Visible = false;
            DgvList.Columns["CHAMPLIBRE3_TICKET"].Visible = false;
            DgvList.Columns["CHAMPLIBRE4_TICKET"].Visible = false;
            DgvList.Columns["CHAMPLIBRE1_BORNE"].Visible = false;
            DgvList.Columns["CHAMPLIBRE2_BORNE"].Visible = false;
            DgvList.Columns["CHAMPLIBRE3_BORNE"].Visible = false;
            DgvList.Columns["CHAMPLIBRE4_BORNE"].Visible = false;
            DgvList.Columns["PONTFIRME"].Visible = false;
            DgvList.Columns["CAMIONCHAUFFEUR"].Visible = false;
            DgvList.Columns["CAMIONTRANSPORTEUR"].Visible = false;
            DgvList.Columns["FORMAT"].Visible = false;
            DgvList.Columns["TITRE1"].Visible = false;
            DgvList.Columns["TITRE2"].Visible = false;
            DgvList.Columns["FOOTER"].Visible = false;
          
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
            Form form = new WeighingSettingsDetail("Edit", Common_functions.GetDatagridViewSelectedId(DgvList));
            form.Show();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new WeighingSettingsDetail("Add", 0);
            form.Show();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            WeighingSettings weighingSettings = new WeighingSettings();
            DgvList.DataSource = weighingSettings.SearchBox(txtSearchBox.Text);
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(WeighingSettingsList));
                Localize_Dgv("fr");
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(WeighingSettingsList));
                Localize_Dgv("en");
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(WeighingSettingsList));
                Localize_Dgv("es");
            }
        }
    }
}
