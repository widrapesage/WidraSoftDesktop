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
    public partial class PontFirmeDetail : Form
    {
        Int32 vg_PontId = 0;
        public PontFirmeDetail(Int32 PontId)
        {
            InitializeComponent();
            vg_PontId = PontId;
        }

        private void PontFirmeDetail_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            Bind_Dgv();
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = 0;
        }

        private void Bind_Dgv()
        {
            //Definit la source du Dgv 
            dgvFirmes.AutoGenerateColumns = false;
            PontFirme pontFirme = new PontFirme();
            if (vg_PontId > 0)
            {
                dgvFirmes.DataSource = pontFirme.FindNonLinkedFirmsByPontId(vg_PontId);
            }

            //Crée et ajoute le textbox pour le champ FIRMEID  (Masqué)
            DataGridViewTextBoxColumn txt_FirmeId = new DataGridViewTextBoxColumn();
            txt_FirmeId.HeaderText = "ID";
            txt_FirmeId.DataPropertyName = "FIRMEID";
            txt_FirmeId.Name = "FIRMEID";
            dgvFirmes.Columns.Add(txt_FirmeId);
            txt_FirmeId.Visible = false;

            //Crée et ajoute la combo pour le champ CHAUFFEUR
            DataGridViewTextBoxColumn txt_Firme = new DataGridViewTextBoxColumn();
            txt_Firme.HeaderText = "FIRME";
            txt_Firme.DataPropertyName = "DESIGNATION";
            txt_Firme.Name = "FIRME";
            txt_Firme.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFirmes.Columns.Add(txt_Firme);

            dgvFirmes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
        }

        private void Localize_Dgv(string lang)
        {
            if (lang == "fr")
            {
                dgvFirmes.Columns["FIRME"].HeaderText = "FIRME";
            }
            if (lang == "en")
            {
                dgvFirmes.Columns["FIRME"].HeaderText = "FIRM";
            }
            if (lang == "es")
            {
                dgvFirmes.Columns["FIRME"].HeaderText = "FIRMA";
            }
        }

        private void Refresh_Dgv()
        {
            PontFirme pontFirme = new PontFirme();
            dgvFirmes.DataSource = pontFirme.FindNonLinkedFirmsByPontId(vg_PontId);
        }

        private void lblEnregistrerDgv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Int32 SelectedRowsCount = dgvFirmes.Rows.GetRowCount(DataGridViewElementStates.Selected);
            Int32[] Selected = new Int32[SelectedRowsCount];

            try
            {
                if (SelectedRowsCount > 0)
                {
                    for (int i = 0; i < SelectedRowsCount; i++)
                    {
                        Selected[i] = Int32.Parse(dgvFirmes.SelectedRows[i].Cells[0].Value.ToString());
                    }
                    for (int i = 0; i < SelectedRowsCount; i++)
                    {
                        try
                        {
                            PontFirme pontFirme = new PontFirme();
                            pontFirme.Add(vg_PontId, Selected[i]);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", SelectedRowsCount + " firme(s) ajoutée(s)", "Firme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", SelectedRowsCount + " firm(s) added", "Firm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES", SelectedRowsCount + " firma(s) añadido(s)", "Firma", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Aucun enregistrement sélectionné", "Firme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "No rows selected", "Firm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Firma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Refresh_Dgv();

            }
            catch
            {
                throw;
            }
        }

        private void lblSelectionnerTout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dgvFirmes.SelectAll();
        }

        private void lblDeselectionner_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dgvFirmes.ClearSelection();
        }

        private void dgvFirmes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFirmes.CurrentCell.Selected)
                dgvFirmes.CurrentCell.Selected = false;
            else
                dgvFirmes.CurrentCell.Selected = true;
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(PontFirmeDetail));
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(PontFirmeDetail));
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(PontFirmeDetail));
            }
        }
    }
}
