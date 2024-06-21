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
    public partial class CamionChauffeurDetail : Form
    {
        Int32 vg_CamionId = 0;
        public CamionChauffeurDetail(Int32 CamionId)
        {
            InitializeComponent();
            vg_CamionId = CamionId;
        }

        private void CamionChauffeurDetail_Load(object sender, EventArgs e)
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
            dgvChauffeurs.AutoGenerateColumns = false;
            CamionChauffeur camionChauffeur = new CamionChauffeur();
            if (vg_CamionId > 0)
            {
                dgvChauffeurs.DataSource = camionChauffeur.FindNonLinkedDriversByCamionId(vg_CamionId);
            }

            //Crée et ajoute le textbox pour le champ CHAUFFEURID  (Masqué)
            DataGridViewTextBoxColumn txt_ChauffeurId = new DataGridViewTextBoxColumn();
            txt_ChauffeurId.HeaderText = "ID";
            txt_ChauffeurId.DataPropertyName = "CHAUFFEURID";
            txt_ChauffeurId.Name = "CHAUFFEURID";
            dgvChauffeurs.Columns.Add(txt_ChauffeurId);
            txt_ChauffeurId.Visible = false;

            //Crée et ajoute la combo pour le champ CHAUFFEUR
            DataGridViewTextBoxColumn txt_Chauffeur = new DataGridViewTextBoxColumn();
            txt_Chauffeur.HeaderText = "CHAUFFEUR";
            txt_Chauffeur.DataPropertyName = "NOM";
            txt_Chauffeur.Name = "CHAUFFEUR";
            txt_Chauffeur.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvChauffeurs.Columns.Add(txt_Chauffeur);

            dgvChauffeurs.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
        }

        private void Localize_Dgv(string lang)
        {
            if (lang == "fr")
            {
                dgvChauffeurs.Columns["CHAUFFEUR"].HeaderText = "CHAUFFEUR";
            }
            if (lang == "en")
            {
                dgvChauffeurs.Columns["CHAUFFEUR"].HeaderText = "DRIVER";
            }
            if (lang == "es")
            {
                dgvChauffeurs.Columns["CHAUFFEUR"].HeaderText = "CONDUCTOR";
            }
        }

        private void Refresh_Dgv()
        {
            CamionChauffeur camionChauffeur = new CamionChauffeur();
            dgvChauffeurs.DataSource = camionChauffeur.FindNonLinkedDriversByCamionId(vg_CamionId);
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(CamionChauffeurDetail));
                Localize_Dgv("fr");

            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(CamionChauffeurDetail));
                Localize_Dgv("en");

            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(CamionChauffeurDetail));
                Localize_Dgv("es");
            }
        }

        private void lblEnregistrerDgv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Int32 SelectedRowsCount = dgvChauffeurs.Rows.GetRowCount(DataGridViewElementStates.Selected);
            Int32[] Selected = new Int32[SelectedRowsCount];

            try
            {
                if (SelectedRowsCount > 0)
                {
                    for (int i = 0; i < SelectedRowsCount; i++)
                    {
                        Selected[i] = Int32.Parse(dgvChauffeurs.SelectedRows[i].Cells[0].Value.ToString());
                    }
                    for (int i = 0; i < SelectedRowsCount; i++)
                    {
                        try
                        {
                            CamionChauffeur camionChauffeur = new CamionChauffeur();
                            camionChauffeur.Add(vg_CamionId, Selected[i]);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", SelectedRowsCount + " chauffeur(s) ajouté(s)", "Chauffeur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", SelectedRowsCount + " driver(s) added", "Driver", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES", SelectedRowsCount + " conductor(es) añadido(s)", "Conductor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Aucun enregistrement sélectionné", "Chauffeur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "No rows selected", "Driver", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Conductor", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dgvChauffeurs.SelectAll();
        }

        private void lblDeselectionner_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dgvChauffeurs.ClearSelection();
        }

        private void dgvChauffeurs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvChauffeurs.CurrentCell.Selected)
                dgvChauffeurs.CurrentCell.Selected = false;
            else
                dgvChauffeurs.CurrentCell.Selected = true;
        }

        
    }
}
