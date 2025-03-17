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
    public partial class Borne_ChoixDeuxiemePesee : Form
    {
        String vg_lang;
        Int32 vg_P;
        public Borne_ChoixDeuxiemePesee(string lang, int P)
        {
            InitializeComponent();
            vg_lang = lang;
            vg_P = P;
        }

        private void Borne_ChoixDeuxiemePesee_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            WindowState = FormWindowState.Maximized;

            if (vg_lang == "fr")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                //language_Manager.ChangeLanguage("fr", this, typeof(Borne_DeuxiemePesee));
            }

            if (vg_lang == "en")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                //language_Manager.ChangeLanguage("en", this, typeof(Borne_DeuxiemePesee));
            }

            if (vg_lang == "es")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                //language_Manager.ChangeLanguage("es", this, typeof(Borne_DeuxiemePesee));
            }

            Bind_Dgv();

            lbTexte.Text = "Choisir pesée";
        }

        private void Bind_Dgv()
        {
            PeseePB peseePB = new PeseePB();
            DgvList.DataSource = peseePB.FindWeighingsInProgress();
            DgvList.Columns[0].Visible = false;
            DgvList.Columns[0].HeaderText = "NUMERO";
            DgvList.Columns["TYPEPESEE"].Visible = false;
            DgvList.Columns["FLUX"].Visible = false;
            DgvList.Columns["PONTID"].Visible = false;
            DgvList.Columns["WEIGHING_SETTINGSID"].Visible = false;
            DgvList.Columns["POIDS2"].Visible = false;
            DgvList.Columns["DATEHEUREPOIDS2"].Visible = false;
            DgvList.Columns["DATEHEUREPOIDS2"].HeaderText = "DATEHEURE";
            DgvList.Columns["PONT"].Visible = false;
            DgvList.Columns["FIRMEID"].Visible = false;
            DgvList.Columns["FIRME"].Visible = false;
            DgvList.Columns["CAMIONID"].Visible = false;
            DgvList.Columns["CAMION"].Visible = false;
            DgvList.Columns["CHAUFFEURID"].Visible = false;
            DgvList.Columns["CHAUFFEUR"].Visible = false;
            DgvList.Columns["TRANSPORTEURID"].Visible = false;
            DgvList.Columns["TRANSPORTEUR"].Visible = false;
            DgvList.Columns["PRODUITID"].Visible = false;
            DgvList.Columns["PRODUIT"].Visible = false;
            DgvList.Columns["CLIENTID"].Visible = false;
            DgvList.Columns["CLIENT"].Visible = false;
            DgvList.Columns["POIDS1"].Visible = false;
            DgvList.Columns["DATEHEUREPOIDS1"].Visible = false;
            DgvList.Columns["TABLES_SUPPLEMENTAIRES_STRING"].Visible = false;
            DgvList.Columns["PARAMPESEE"].Visible = false;
            DgvList.Columns["PARAMPESEE"].HeaderText = "PARAMETRE";
            DgvList.Columns["POIDSNET"].Visible = false;
            DgvList.Columns["USER_INFO"].Visible = false;
            DgvList.Columns["ETATPESEE"].Visible = false;
            DgvList.Columns["ETATPESEE"].HeaderText = "ETAT";
            DgvList.Columns["ENREGISTREMENTSID1"].Visible = false;
            DgvList.Columns["ENREGISTREMENTSID2"].Visible = false;
            DgvList.Columns["ENREGISTREMENTSID3"].Visible = false;
            DgvList.Columns["ENREGISTREMENTSID4"].Visible = false;
            DgvList.Columns["ENREGISTREMENTSID5"].Visible = false;
            DgvList.Columns["ENREGISTREMENTSID6"].Visible = false;
            DgvList.Columns["ENREGISTREMENTSID7"].Visible = false;
            DgvList.Columns["TITRE1"].Visible = false;
            DgvList.Columns["TITRE2"].Visible = false;
            DgvList.Columns["FOOTER"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = false;
            DgvList.Columns["PESEE_RESUME"].Visible = true;
            DgvList.Columns["PESEE_RESUME"].HeaderText = "PESEE";

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            DgvList.ReadOnly = true;

            lbCount.Text = DgvList.RowCount.ToString();

            if (DgvList.RowCount > 4)
            {
                btDoubleDown.Visible = true;
                btDoubleUp.Visible = true;
            }
            else
            {
                btDoubleDown.Visible = false;
                btDoubleUp.Visible = false;
            }

        }

        private void btDoubleUp_Click(object sender, EventArgs e)
        {
            DgvList.Focus();
            int i;
            i = 38;
            int currentRow = DgvList.CurrentCell.RowIndex;
            if (currentRow > 3)
            {
                DgvList.Rows[currentRow - 3].Cells[i].Selected = true;
                DgvList.CurrentCell = DgvList.Rows[currentRow - 3].Cells[i];
            }
            else
            {
                DgvList.Rows[0].Cells[i].Selected = true;
                DgvList.CurrentCell = DgvList.Rows[0].Cells[i];
            }
        }

        private void btDoubleDown_Click(object sender, EventArgs e)
        {
            DgvList.Focus();
            int i;
            i = 38;

            int currentRow = DgvList.CurrentCell.RowIndex;
            if (currentRow < DgvList.RowCount - 3)
            {
                DgvList.Rows[currentRow + 3].Cells[i].Selected = true;
                DgvList.CurrentCell = DgvList.Rows[currentRow + 3].Cells[i];
            }
            else
            {
                DgvList.Rows[DgvList.RowCount - 1].Cells[i].Selected = true;
                DgvList.CurrentCell = DgvList.Rows[DgvList.RowCount - 1].Cells[i];
            }
        }

        private void btUp_Click(object sender, EventArgs e)
        {
            DgvList.Focus();
            int i;
            i = 38;

            int currentRow = DgvList.CurrentCell.RowIndex;
            if (currentRow > 0)
            {
                DgvList.Rows[currentRow - 1].Cells[i].Selected = true;
                DgvList.CurrentCell = DgvList.Rows[currentRow - 1].Cells[i];
            }
        }

        private void btDown_Click(object sender, EventArgs e)
        {
            DgvList.Focus();
            int i;
            i = 38;

            int currentRow = DgvList.CurrentCell.RowIndex;
            if (currentRow < DgvList.RowCount - 1)
            {
                DgvList.Rows[currentRow + 1].Cells[i].Selected = true;
                DgvList.CurrentCell = DgvList.Rows[currentRow + 1].Cells[i];
            }
        }

        private void btValider_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new Borne_DeuxiemePesee(vg_P, Common_functions.GetDatagridViewSelectedId(DgvList), "", vg_lang);
                form.Show();
                Close();
            }
            catch { throw; }
        }

        private void btAnnuler_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
