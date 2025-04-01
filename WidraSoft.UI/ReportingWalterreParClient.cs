using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WidraSoft.BL;

namespace WidraSoft.UI
{
    public partial class ReportingWalterreParClient : Form
    {
        string vg_filter = "";
        string vl_Filter = "1=1";
        string filtreRapportClient = "Filtre client = Null";
        string filtreRapportDate = "Filtre date = Null";
        public ReportingWalterreParClient(string filter)
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            vg_filter = filter;
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyMenuColors()) { }
        }
        private void ReportingWalterreParClient_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            //WindowState = FormWindowState.Maximized;
            Bind_Search_Fields();

            Clear();


            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = MenuGeneral.languuage_index;
        }

        private void Bind_Search_Fields()
        {


            //Transporteur
            Transporteur transporteur = new Transporteur();
            cbTransporteur.DataSource = transporteur.List("1=1");
            cbTransporteur.DisplayMember = "NOM";
            cbTransporteur.ValueMember = "TRANSPORTEURID";
            cbTransporteur.SelectedIndex = -1;

            //Pont
            Pont pont = new Pont();
            cbPont.DataSource = pont.List("1=1");
            cbPont.DisplayMember = "DESIGNATION";
            cbPont.ValueMember = "PONTID";
            cbPont.SelectedIndex = -1;

            //Client
            Client client = new Client();
            cbClient.DataSource = client.List("1=1");
            cbClient.DisplayMember = "DESIGNATION";
            cbClient.ValueMember = "CLIENTID";
            cbClient.SelectedIndex = -1;

            //Walterre
            Walterre walterre = new Walterre();
            cbWalterre.DataSource = walterre.List("1=1");
            cbWalterre.DisplayMember = "CODE";
            cbWalterre.ValueMember = "WALTERREID";
            cbWalterre.SelectedIndex = -1;

            // Weighing_Settings
            WeighingSettings weighingSettings = new WeighingSettings();
            cbWeighingSettingsId.DataSource = weighingSettings.List("1=1");
            cbWeighingSettingsId.DisplayMember = "DESIGNATION";
            cbWeighingSettingsId.ValueMember = "WEIGHING_SETTINGSID";
            cbWeighingSettingsId.SelectedIndex = -1;

            //Selection de dates 
            if (chx_Date.Checked)
            {
                dtDebut.Enabled = true;
                dtFin.Enabled = true;
                rbToutDate.Checked = true;
                gbPeriode.Enabled = false;
            }
            else
            {
                dtDebut.Enabled = false;
                dtFin.Enabled = false;
                gbPeriode.Enabled = true;
            }

            //Produit
            Produit produit = new Produit();
            cbProduit.DataSource = produit.List("1=1");
            cbProduit.DisplayMember = "DESIGNATION";
            cbProduit.ValueMember = "PRODUITID";
            cbProduit.SelectedIndex = -1;

        }

        private void Clear()
        {
            cbPont.Text = "";
            cbClient.Text = "";
            cbProduit.Text = "";
            cbTransporteur.Text = "";
            cbWalterre.Text = "";
            cbWeighingSettingsId.Text = "";
            chx_Date.Checked = false;
            rbToutDate.Checked = true;
        }

        private void chx_Date_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Date.Checked)
            {
                dtDebut.Enabled = true;
                dtFin.Enabled = true;
                rbToutDate.Checked = true;
                gbPeriode.Enabled = false;
            }
            else
            {
                dtDebut.Enabled = false;
                dtFin.Enabled = false;
                gbPeriode.Enabled = true;
            }
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                //language_Manager.ChangeLanguage("fr", this, typeof(PeseePBList));

            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                //language_Manager.ChangeLanguage("en", this, typeof(PeseePBList));
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                //language_Manager.ChangeLanguage("es", this, typeof(PeseePBList));
            }
        }

        private void Search()
        {
            vl_Filter = "1=1";
            filtreRapportClient = "Filtre client = Null";
            filtreRapportDate = "Filtre date = Null";
            if (cbTransporteur.Text != "")
                vl_Filter = vl_Filter + " AND TRANSPORTEURID=" + cbTransporteur.SelectedValue;
            if (cbPont.Text != "")
                vl_Filter = vl_Filter + " AND PONTID=" + cbPont.SelectedValue;
            if (cbWalterre.Text != "")
                vl_Filter = vl_Filter + " AND WALTERREID=" + cbWalterre.SelectedValue;
            if (cbClient.Text != "")
            {
                vl_Filter = vl_Filter + " AND CLIENTID=" + cbClient.SelectedValue;
                filtreRapportClient = "Filtre client : " + cbClient.Text;
            }    
            if (cbProduit.Text != "")
                vl_Filter = vl_Filter + " AND PRODUITID=" + cbProduit.SelectedValue;
            if (cbWeighingSettingsId.Text != "")
                vl_Filter = vl_Filter + " AND WEIGHING_SETTINGSID=" + cbWeighingSettingsId.SelectedValue;

            //Periode
            if (rbMois.Checked)
            {
                vl_Filter = vl_Filter + " AND YEAR(DATEHEUREPOIDS1) =" + DateTime.Now.Year + "AND MONTH(DATEHEUREPOIDS1) =" + DateTime.Now.Month;
                filtreRapportDate = "Filtre date : Mois " + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            }
                
            if (rbJour.Checked)
            {
                vl_Filter = vl_Filter + " AND YEAR(DATEHEUREPOIDS1) =" + DateTime.Now.Year + "AND MONTH(DATEHEUREPOIDS1) =" + DateTime.Now.Month + "AND DAY(DATEHEUREPOIDS1) =" + DateTime.Now.Day;
                filtreRapportDate = "Filtre jour du: " + DateTime.Now.ToShortDateString().ToString();
            }
                


            //Date 
            if (chx_Date.Checked)
            {
                vl_Filter = vl_Filter + " AND DATEHEUREPOIDS1>='" + dtDebut.Value.Date.ToString() + "' AND DATEHEUREPOIDS1<='" + dtFin.Value.Date.AddDays(1).ToString() + "'";
                filtreRapportDate = "Intervalle de date : " + dtDebut.Value.ToShortDateString().ToString() + " - " + dtFin.Value.ToShortDateString().ToString();
            }

            vl_Filter = vl_Filter + " AND ETATPESEE='Complete'";
        }

        private void Export_Click(object sender, EventArgs e)
        {
            Search();
            try
            {
                Form form = new ReportingWalterreGBClient(vl_Filter, filtreRapportClient, filtreRapportDate);
                form.Show();
            }
            catch { throw; }
        }
    }
}
