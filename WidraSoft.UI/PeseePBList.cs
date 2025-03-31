using CustomMessageBox;
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
    public partial class PeseePBList : Form
    {
        string vg_filter = "";
        string vl_Filter = "1=1";
        public PeseePBList(string filter)
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            vg_filter = filter;
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyMenuColors()) { }
        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PeseePBList_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            WindowState = FormWindowState.Maximized;
            Bind_Search_Fields();

            Clear();

            Bind_Dgv();
            
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = MenuGeneral.languuage_index;

            lbNombre.Text = DgvList.Rows.Count.ToString();
        }

        private void Bind_Search_Fields()
        {
            //Camion
            Camion camion = new Camion();
            cbCamion.DataSource = camion.List("1=1");
            cbCamion.DisplayMember = "PLAQUE";
            cbCamion.ValueMember = "CAMIONID";
            cbCamion.SelectedIndex = -1;

            //Chauffeur
            Chauffeur chauffeur = new Chauffeur();
            cbChauffeur.DataSource = chauffeur.List("1=1");
            cbChauffeur.DisplayMember = "NOM";
            cbChauffeur.ValueMember = "CHAUFFEURID";
            cbChauffeur.SelectedIndex = -1;

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

            //Firme
            Firme firme = new Firme();
            cbFirme.DataSource = firme.List("1=1");
            cbFirme.DisplayMember = "DESIGNATION";
            cbFirme.ValueMember = "FIRMEID";
            cbFirme.SelectedIndex = -1;

            // Weighing_Settings
            WeighingSettings weighingSettings = new WeighingSettings();
            cbWeighingSettingsId.DataSource = weighingSettings.List("1=1");
            cbWeighingSettingsId.DisplayMember = "DESIGNATION";
            cbWeighingSettingsId.ValueMember = "WEIGHING_SETTINGSID";
            cbWeighingSettingsId.SelectedIndex = -1;

            //Type
            cbType.Items.Clear();
            cbType.Items.Add("1x");
            cbType.Items.Add("2x");

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
            cbCamion.Text = "";
            cbChauffeur.Text = "";
            cbTransporteur.Text = "";
            cbPont.Text = "";
            cbClient.Text = "";
            cbProduit.Text = "";
            cbTransporteur.Text = "";
            cbFirme.Text = "";
            cbType.Text = "";
            cbWeighingSettingsId.Text = "";
            txtNum.Text = "";
            chx_Date.Checked = false;
            rbToutDate.Checked = true;
            rbToutEtat.Checked = true;
        }

        private void Bind_Dgv()
        {
            PeseePB peseePB = new PeseePB();
            DgvList.DataSource = peseePB.List(vg_filter);

            DgvList.Columns["PESEEPBID"].Visible = true;
            DgvList.Columns["PESEEPBID"].HeaderText = "PESEE";
            DgvList.Columns["TYPEPESEE"].Visible = false;
            DgvList.Columns["FLUX"].Visible = true;
            DgvList.Columns["PONTID"].Visible = false;
            DgvList.Columns["WEIGHING_SETTINGSID"].Visible = false;
            DgvList.Columns["PONT"].Visible = true;
            DgvList.Columns["FIRMEID"].Visible = false;
            DgvList.Columns["FIRME"].Visible = true;
            DgvList.Columns["CAMIONID"].Visible = false;
            DgvList.Columns["CAMION"].Visible = true;
            DgvList.Columns["CHAUFFEURID"].Visible = false;
            DgvList.Columns["CHAUFFEUR"].Visible = true;
            DgvList.Columns["TRANSPORTEURID"].Visible = false;
            DgvList.Columns["TRANSPORTEUR"].Visible = true;
            DgvList.Columns["PRODUITID"].Visible = false;
            DgvList.Columns["PRODUIT"].Visible = true;
            DgvList.Columns["CLIENTID"].Visible = false;
            DgvList.Columns["CLIENT"].Visible = true;
            DgvList.Columns["POIDS1"].Visible = false;
            DgvList.Columns["DATEHEUREPOIDS1"].Visible = true;
            DgvList.Columns["DATEHEUREPOIDS1"].HeaderText = "DATE HEURE";
            DgvList.Columns["POIDS2"].Visible = false;
            DgvList.Columns["DATEHEUREPOIDS2"].Visible = false;
            DgvList.Columns["POIDSNET"].Visible = true;
            DgvList.Columns["USER_INFO"].Visible = false;
            DgvList.Columns["ETATPESEE"].Visible = true;
            DgvList.Columns["ENREGISTREMENTSID1"].Visible = false;
            DgvList.Columns["ENREGISTREMENTSID2"].Visible = false;
            DgvList.Columns["ENREGISTREMENTSID3"].Visible = false;
            DgvList.Columns["ENREGISTREMENTSID4"].Visible = false;
            DgvList.Columns["ENREGISTREMENTSID5"].Visible = false;
            DgvList.Columns["ENREGISTREMENTSID6"].Visible = false;
            DgvList.Columns["ENREGISTREMENTSID7"].Visible = false;
            DgvList.Columns["CHAMPLIBRE1"].Visible = false;
            DgvList.Columns["CHAMPLIBRE2"].Visible = false;
            DgvList.Columns["CHAMPLIBRE3"].Visible = false;
            DgvList.Columns["CHAMPLIBRE4"].Visible = false;
            DgvList.Columns["TABLES_SUPPLEMENTAIRES_STRING"].Visible = false;
            DgvList.Columns["PARAMPESEE"].Visible = true;
            DgvList.Columns["PARAMPESEE"].HeaderText = "PARAMETRE";
            DgvList.Columns["TITRE1"].Visible = false;
            DgvList.Columns["TITRE2"].Visible = false;
            DgvList.Columns["FOOTER"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = false;
            DgvList.Columns["WALTERREID"].Visible = false;
            DgvList.Columns["CODEWALTERRE"].Visible = false;


            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            DgvList.ReadOnly = true;

        }

        private void cbWeighingSettingsId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

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
                language_Manager.ChangeLanguage("fr", this, typeof(PeseePBList));

            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(PeseePBList));
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(PeseePBList));
            }

            lbNombre.Text = DgvList.Rows.Count.ToString();
        }

        private void ActualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bind_Search_Fields();
            Clear();           
            vg_filter = "1=1";
            vl_Filter = "1=1";
            Bind_Dgv();
            Search();

        }

        private void exporterVersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            vl_Filter = "1=1";

            if (cbCamion.Text != "")
                vl_Filter = vl_Filter + " AND CAMIONID=" + cbCamion.SelectedValue;
            if (cbTransporteur.Text != "")
                vl_Filter = vl_Filter + " AND TRANSPORTEURID=" + cbTransporteur.SelectedValue;
            if (cbChauffeur.Text != "")
                vl_Filter = vl_Filter + " AND CHAUFFEURID=" + cbChauffeur.SelectedValue;
            if (cbPont.Text != "")
                vl_Filter = vl_Filter + " AND PONTID=" + cbPont.SelectedValue;
            if (cbFirme.Text != "")
                vl_Filter = vl_Filter + " AND FIRMEID=" + cbFirme.SelectedValue;
            if (cbClient.Text != "")
                vl_Filter = vl_Filter + " AND CLIENTID=" + cbClient.SelectedValue;
            if (cbProduit.Text != "")
                vl_Filter = vl_Filter + " AND PRODUITID=" + cbProduit.SelectedValue;
            if (cbType.Text != "")
                vl_Filter = vl_Filter + " AND TYPE='" + cbType.Text + "'";
            if (cbWeighingSettingsId.Text != "")
                vl_Filter = vl_Filter + " AND WEIGHING_SETTINGSID=" + cbWeighingSettingsId.SelectedValue;
            if (txtNum.Text != "")
                vl_Filter = vl_Filter + " AND PESEEPBID =" + txtNum.Text;

            //Periode
            if (rbMois.Checked)
                vl_Filter = vl_Filter + " AND YEAR(DATEHEUREPOIDS1) =" + DateTime.Now.Year + "AND MONTH(DATEHEUREPOIDS1) =" + DateTime.Now.Month;
            if (rbJour.Checked)
                vl_Filter = vl_Filter + " AND YEAR(DATEHEUREPOIDS1) =" + DateTime.Now.Year + "AND MONTH(DATEHEUREPOIDS1) =" + DateTime.Now.Month + "AND DAY(DATEHEUREPOIDS1) =" + DateTime.Now.Day;
            //Etat 
            if (rbComplete.Checked)
                vl_Filter = vl_Filter + " AND ETATPESEE ='Complete'";
            if (rbPending.Checked)
                vl_Filter = vl_Filter + " AND ETATPESEE ='Pending'";

            //Date 
            if (chx_Date.Checked)
            {
                vl_Filter = vl_Filter + " AND DATEHEUREPOIDS1>='" + dtDebut.Value.Date.ToString() + "' AND DATEHEUREPOIDS1<='" + dtFin.Value.Date.AddDays(1).ToString() + "'";
            }

            PeseePB peseePB = new PeseePB();
            DgvList.DataSource = peseePB.List(vl_Filter);

            lbNombre.Text = DgvList.Rows.Count.ToString();
            

        }

        private void DgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Form form = new PeseePBDetail(0, Common_functions.GetDatagridViewSelectedId(DgvList));
                form.Show();
            } catch { throw; }           
        }

        private void DgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DgvList.Columns[e.ColumnIndex].Name.Equals("ETATPESEE"))
            {
                //Int32 intValue;
                if ((String)e.Value == "Pending")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(214, 60, 60);
                    e.CellStyle.SelectionBackColor = Color.DarkRed;
                }
                if ((String)e.Value == "Complete")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(23, 117, 63);
                    e.CellStyle.SelectionBackColor = Color.DarkSeaGreen;
                }
                
            }
        }

        private void Excel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (DgvList.Rows.Count > 0)
            {
                DgvList.Focus();
                PeseePB peseePB = new PeseePB();
                if (!peseePB.IsPending(Common_functions.GetDatagridViewSelectedId(DgvList))) 
                {
                    try
                    {
                        Form form = new PeseePBTicketA5(Common_functions.GetDatagridViewSelectedId(DgvList));
                        form.Show();
                    }
                    catch { throw; }
                }
                else
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Vous ne pouvez pas imprimer l'enregistrement tant que la pesée n'est pas completée.", "Liste des pesées", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "You can't print this record before the weighing is completed", "Weighing's list", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        Custom_MessageBox.Show("ES", "No puede eliminar el registro hasta que se confirme el cambio", "Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas supprimer l'enregistrement tant que la modification n'est pas validée", "Liste des pesées", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You can't delete this record before the update is completed", "Weighing's list", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Custom_MessageBox.Show("ES", "No puede eliminar el registro hasta que se confirme el cambio", "Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
