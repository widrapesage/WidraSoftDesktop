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
    public partial class ChauffeursListe : Form
    {
        string vg_filter = "";
        public ChauffeursListe(string filter)
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            vg_filter = filter;
        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyMenuColors()) { }
        }

        private void ChauffeursListe_Load(object sender, EventArgs e)
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
            Chauffeur chauffeur = new Chauffeur();
            DgvList.DataSource = chauffeur.List(vg_filter);
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["BADGE"].Visible = false;
            DgvList.Columns["NOM"].Visible = true;
            DgvList.Columns["NUMERONATIONAL"].Visible = true;
            DgvList.Columns["NUMEROPERMIS"].Visible = true;
            DgvList.Columns["ADRESSE"].Visible = true;
            DgvList.Columns["CODEPOSTAL"].Visible = true;
            DgvList.Columns["LOCALITE"].Visible = true;
            DgvList.Columns["PAYS"].Visible = true;
            DgvList.Columns["TELEPHONE"].Visible = true;
            DgvList.Columns["OBSERVATIONS"].Visible = false;
            DgvList.Columns["VALIDE"].Visible = false;
            DgvList.Columns["BLOQUE"].Visible = false;
            DgvList.Columns["TEXTEBLOQUE"].Visible = false;
            DgvList.Columns["ATTENTION"].Visible = false;
            DgvList.Columns["TEXTEATTENTION"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = true;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;

        }

        private void Localize_Dgv(string lang)
        {
            if (lang == "fr")
            {
                DgvList.Columns["BADGE"].HeaderText = "N° BADGE";
                DgvList.Columns["NOM"].HeaderText = "NOM";
                DgvList.Columns["NUMERONATIONAL"].HeaderText = "N° NATIONAL";
                DgvList.Columns["NUMEROPERMIS"].HeaderText = "N° PERMIS";
                DgvList.Columns["ADRESSE"].HeaderText = "ADRESSE";
                DgvList.Columns["CODEPOSTAL"].HeaderText = "CODE POSTAL";
                DgvList.Columns["LOCALITE"].HeaderText = "LOCALITE";
                DgvList.Columns["PAYS"].HeaderText = "PAYS";
                DgvList.Columns["TELEPHONE"].HeaderText = "N° TELEPHONE";
                DgvList.Columns["VALIDE"].HeaderText = "VALIDE";
                DgvList.Columns["BLOQUE"].HeaderText = "BLOQUE";
                DgvList.Columns["ATTENTION"].HeaderText = "ATTENTION";
                DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            }

            if (lang == "en")
            {
                DgvList.Columns["BADGE"].HeaderText = "BADGE N°";
                DgvList.Columns["NOM"].HeaderText = "NAME";
                DgvList.Columns["NUMERONATIONAL"].HeaderText = "NATIONAL N°";
                DgvList.Columns["NUMEROPERMIS"].HeaderText = "LICENSE N°";
                DgvList.Columns["ADRESSE"].HeaderText = "ADRESSE";
                DgvList.Columns["CODEPOSTAL"].HeaderText = "CODE POSTAL";
                DgvList.Columns["LOCALITE"].HeaderText = "LOCALITE";
                DgvList.Columns["PAYS"].HeaderText = "PAYS";
                DgvList.Columns["TELEPHONE"].HeaderText = "N° TELEPHONE";
                DgvList.Columns["VALIDE"].HeaderText = "VALIDE";
                DgvList.Columns["BLOQUE"].HeaderText = "BLOQUE";
                DgvList.Columns["ATTENTION"].HeaderText = "ATTENTION";
                DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            }

            if (lang == "es")
            {
                DgvList.Columns["BADGE"].HeaderText = "N° INSIGNIA";
                DgvList.Columns["NOM"].HeaderText = "APELLIDO";
                DgvList.Columns["NUMERONATIONAL"].HeaderText = "N° NACIONAL";
                DgvList.Columns["NUMEROPERMIS"].HeaderText = "N° PERMISO";
                DgvList.Columns["ADRESSE"].HeaderText = "DIRECCIÓN";
                DgvList.Columns["CODEPOSTAL"].HeaderText = "CÓDIGO POSTAL";
                DgvList.Columns["LOCALITE"].HeaderText = "LOCALIDAD";
                DgvList.Columns["PAYS"].HeaderText = "PAÍS";
                DgvList.Columns["TELEPHONE"].HeaderText = "TELÉFONO";
                DgvList.Columns["VALIDE"].HeaderText = "VÁLIDO";
                DgvList.Columns["BLOQUE"].HeaderText = "OBSTRUIDO";
                DgvList.Columns["ATTENTION"].HeaderText = "ATENCIÓN";
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
            Form form = new ChauffeurDetail("Edit", Common_functions.GetDatagridViewSelectedId(DgvList));
            form.Show();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ChauffeurDetail("Add", 0);
            form.Show();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            Chauffeur chauffeur = new Chauffeur();
            DgvList.DataSource = chauffeur.SearchBox(txtSearchBox.Text);
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(ChauffeursListe));
                Localize_Dgv("fr");
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(ChauffeursListe));
                Localize_Dgv("en");
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(ChauffeursListe));
                Localize_Dgv("es");
            }
        }

        private void DgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Form form = new ChauffeurDetail("Edit", Common_functions.GetDatagridViewSelectedId(DgvList));
                form.Show();
            }
            catch { throw; }
        }
    }
}
