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
    public partial class EnregistrementsListe : Form
    {
        string vg_filter = "";
        public EnregistrementsListe(string filter)
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            vg_filter = filter;
        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyMenuColors()) { }
        }

        private void EnregistrementsListe_Load(object sender, EventArgs e)
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
            Enregistrements enregistrements = new Enregistrements();
            DgvList.DataSource = enregistrements.List(vg_filter);
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["NOM"].Visible = true;
            DgvList.Columns["ADRESSE"].Visible = true;
            DgvList.Columns["CODEPOSTAL"].Visible = true;
            DgvList.Columns["LOCALITE"].Visible = true;
            DgvList.Columns["PAYS"].Visible = true;
            DgvList.Columns["TELEPHONE"].Visible = true;
            DgvList.Columns["EMAIL"].Visible = true;
            DgvList.Columns["NUMTVA"].Visible = false;
            DgvList.Columns["SITEWEB_URL"].Visible = false;
            DgvList.Columns["OBSERVATIONS"].Visible = false;
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
                DgvList.Columns["NOM"].HeaderText = "NOM";
                DgvList.Columns["ADRESSE"].HeaderText = "ADRESSE";
                DgvList.Columns["CODEPOSTAL"].HeaderText = "CODE POSTAL";
                DgvList.Columns["LOCALITE"].HeaderText = "LOCALITE";
                DgvList.Columns["PAYS"].HeaderText = "PAYS";
                DgvList.Columns["TELEPHONE"].HeaderText = "N° TELEPHONE";
                DgvList.Columns["EMAIL"].HeaderText = "EMAIL";
                DgvList.Columns["NUMTVA"].HeaderText = "N° TVA";
                DgvList.Columns["SITEWEB_URL"].HeaderText = "URL SITE WEB";
                DgvList.Columns["BLOQUE"].HeaderText = "BLOQUE";
                DgvList.Columns["ATTENTION"].HeaderText = "ATTENTION";
                DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            }

            if (lang == "en")
            {
                DgvList.Columns["NOM"].HeaderText = "NAME";
                DgvList.Columns["ADRESSE"].HeaderText = "ADRESS";
                DgvList.Columns["CODEPOSTAL"].HeaderText = "POSTAL CODE";
                DgvList.Columns["LOCALITE"].HeaderText = "CITY";
                DgvList.Columns["PAYS"].HeaderText = "COUNTRY";
                DgvList.Columns["TELEPHONE"].HeaderText = "PHONE N°";
                DgvList.Columns["EMAIL"].HeaderText = "MAIL";
                DgvList.Columns["NUMTVA"].HeaderText = "VAT N°";
                DgvList.Columns["SITEWEB_URL"].HeaderText = "WEBSITE URL";
                DgvList.Columns["BLOQUE"].HeaderText = "BLOCKED";
                DgvList.Columns["ATTENTION"].HeaderText = "WARNING";
                DgvList.Columns["DATECREATION"].HeaderText = "CREATION DATE";
            }

            if (lang == "es")
            {
                DgvList.Columns["NOM"].HeaderText = "APELLIDO";
                DgvList.Columns["ADRESSE"].HeaderText = "DIRECCIÓN";
                DgvList.Columns["CODEPOSTAL"].HeaderText = "CÓDIGO POSTAL";
                DgvList.Columns["LOCALITE"].HeaderText = "LOCALIDAD";
                DgvList.Columns["PAYS"].HeaderText = "PAÍS";
                DgvList.Columns["TELEPHONE"].HeaderText = "TELÉFONO";
                DgvList.Columns["EMAIL"].HeaderText = "CORREO ELECTRÓNICO";
                DgvList.Columns["NUMTVA"].HeaderText = "N° IVA";
                DgvList.Columns["SITEWEB_URL"].HeaderText = "SITIO WEB";
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
            Form form = new EnregistrementsDetail("Edit", Common_functions.GetDatagridViewSelectedId(DgvList));
            form.Show();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new EnregistrementsDetail("Add", 0);
            form.Show();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            Enregistrements enregistrements = new Enregistrements();
            DgvList.DataSource = enregistrements.SearchBox(txtSearchBox.Text);
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(EnregistrementsListe));
                Localize_Dgv("fr");
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(EnregistrementsListe));
                Localize_Dgv("en");
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(EnregistrementsListe));
                Localize_Dgv("es");
            }
        }
    }
}
