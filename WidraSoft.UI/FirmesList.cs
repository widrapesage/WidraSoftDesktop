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
    public partial class FirmesList : Form
    {
        string vg_filter = "";
        public FirmesList(string filter)
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            vg_filter = filter; 
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyMenuColors()) { }
        }
        private void FirmesList_Load(object sender, EventArgs e)
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
            Firme firme = new Firme();
            DgvList.DataSource = firme.List(vg_filter);
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["BADGE"].Visible = false;
            DgvList.Columns["DESIGNATION"].Width = 250;
            DgvList.Columns["ADRESSE"].Width = 200;
            DgvList.Columns["CODEPOSTAL"].Width = 150;
            DgvList.Columns["CODEPOSTAL"].HeaderText = "CODE POSTAL";
            DgvList.Columns["LOCALITE"].Width = 200;
            DgvList.Columns["PAYS"].Width = 200;
            DgvList.Columns["TELEPHONE"].Width = 200;
            DgvList.Columns["EMAIL"].Width = 200;
            DgvList.Columns["NUMTVA"].Visible = false;
            DgvList.Columns["SITEWEB_URL"].Visible = false;
            DgvList.Columns["OBSERVATIONS"].Visible = false;
            DgvList.Columns["VALIDE"].Visible = false;
            DgvList.Columns["BLOQUE"].Visible = false;
            DgvList.Columns["TEXTEBLOQUE"].Visible = false;
            DgvList.Columns["ATTENTION"].Visible = false;
            DgvList.Columns["TEXTEATTENTION"].Visible = false; 
            DgvList.Columns["DATECREATION"].Width = 200;
            DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;

        }

        private void Localize_Dgv(string lang)
        {
            if (lang == "fr")
            {
                DgvList.Columns["BADGE"].HeaderText = "N° BADGE";
                DgvList.Columns["DESIGNATION"].HeaderText = "DESIGNATION";
                DgvList.Columns["ADRESSE"].HeaderText = "ADRESSE";
                DgvList.Columns["CODEPOSTAL"].HeaderText = "CODE POSTAL";
                DgvList.Columns["LOCALITE"].HeaderText = "LOCALITE";
                DgvList.Columns["PAYS"].HeaderText = "PAYS";
                DgvList.Columns["TELEPHONE"].HeaderText = "N° TELEPHONE";
                DgvList.Columns["EMAIL"].HeaderText = "EMAIL";
                DgvList.Columns["NUMTVA"].HeaderText = "N° TVA";
                DgvList.Columns["SITEWEB_URL"].HeaderText = "URL SITE WEB";
                DgvList.Columns["VALIDE"].HeaderText = "VALIDE";
                DgvList.Columns["BLOQUE"].HeaderText = "BLOQUE";
                DgvList.Columns["ATTENTION"].HeaderText = "ATTENTION";
                DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            }

            if (lang == "en")
            {
                DgvList.Columns["BADGE"].HeaderText = "BADGE N°";
                DgvList.Columns["DESIGNATION"].HeaderText = "NAME";
                DgvList.Columns["ADRESSE"].HeaderText = "ADRESS";
                DgvList.Columns["CODEPOSTAL"].HeaderText = "POSTAL CODE";
                DgvList.Columns["LOCALITE"].HeaderText = "LOCALITY";
                DgvList.Columns["PAYS"].HeaderText = "COUNTRY";
                DgvList.Columns["TELEPHONE"].HeaderText = "PHONE N°";
                DgvList.Columns["EMAIL"].HeaderText = "EMAIL";
                DgvList.Columns["NUMTVA"].HeaderText = "VAT N°";
                DgvList.Columns["SITEWEB_URL"].HeaderText = "WEBSITE URL";
                DgvList.Columns["VALIDE"].HeaderText = "VALID";
                DgvList.Columns["BLOQUE"].HeaderText = "BLOCKED";
                DgvList.Columns["ATTENTION"].HeaderText = "WARNING";
                DgvList.Columns["DATECREATION"].HeaderText = "CREATION DATE";
            }

        }

        private Int32 GetId()
        {
            try
            {
                return (int)DgvList[0, DgvList.CurrentCell.RowIndex].Value;

            }
            catch
            {
                throw;
            }
        }

        private Int32[] GetSelectedRowsId()
        {
            try
            {
                Int32 SelectedRowsCount = DgvList.Rows.GetRowCount(DataGridViewElementStates.Selected);
                Int32[] Selected = new Int32[SelectedRowsCount];
                if (SelectedRowsCount > 0)
                {

                    for (int i = 0; i < SelectedRowsCount; i++)
                    {
                        Selected[i] = Int32.Parse(DgvList.SelectedRows[i].Cells[0].Value.ToString());
                    }

                }
                return Selected;
            }
            catch
            {
                throw;
            }
        }

        private void ActualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vg_filter = "1=1";
            Bind_Dgv();
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FirmeDetail("Edit", GetId());
            form.Show();
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FirmeDetail("Edit", GetId());
            form.Show();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FirmeDetail("Add", 0);
            form.Show();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32[] selectedIds = new Int32[GetSelectedRowsId().Length];
            selectedIds = GetSelectedRowsId();
            if (GetSelectedRowsId().Length > 0)
            {
                for (int i = 0; i < GetSelectedRowsId().Length; i++)
                {
                    //MessageBox.Show(selectedIds[i].ToString());
                    Firme firme = new Firme();
                    firme.Delete(selectedIds[i]);
                }
                MessageBox.Show(GetSelectedRowsId().Length + " firme(s) supprimée(s)");
            }
            else
            {
                MessageBox.Show("Vous n'avez selectionné aucun enregistrement à supprimer");
            }
        
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            Firme firme = new Firme();
            DgvList.DataSource = firme.SearchBox(txtSearchBox.Text);
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "Francais(FR)")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(FirmesList));
                Localize_Dgv("fr"); 
            }

            if (cbLang.Text == "Anglais(ANG)")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(FirmesList));
                Localize_Dgv("en"); 
            }

            if (cbLang.Text == "Espagnol(ESP)")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
            }
        }
    }
}
