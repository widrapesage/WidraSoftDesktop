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
    public partial class CamionTransporteurDetail : Form
    {
        Int32 vg_CamionId = 0;
        public CamionTransporteurDetail(Int32 CamionId)
        {
            InitializeComponent();
            vg_CamionId = CamionId;
        }

        private void CamionTransporteurDetail_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            Bind_Dgv();
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = MenuGeneral.languuage_index;
        }

        private void Bind_Dgv()
        {
            //Definit la source du Dgv 
            dgvTransporteurs.AutoGenerateColumns = false;
            CamionTransporteur camionTransporteur = new CamionTransporteur();
            if (vg_CamionId > 0)
            {
                dgvTransporteurs.DataSource = camionTransporteur.FindNonLinkedCarriersByCamionId(vg_CamionId);
            }

            //Crée et ajoute le textbox pour le champ TRANSPORTEURID  (Masqué)
            DataGridViewTextBoxColumn txt_TransporteurId = new DataGridViewTextBoxColumn();
            txt_TransporteurId.HeaderText = "ID";
            txt_TransporteurId.DataPropertyName = "TRANSPORTEURID";
            txt_TransporteurId.Name = "TRANSPORTEURID";
            dgvTransporteurs.Columns.Add(txt_TransporteurId);
            txt_TransporteurId.Visible = false;

            //Crée et ajoute la combo pour le champ TRANSPORTEUR
            DataGridViewTextBoxColumn txt_Transporteur = new DataGridViewTextBoxColumn();
            txt_Transporteur.HeaderText = "TRANSPORTEUR";
            txt_Transporteur.DataPropertyName = "NOM";
            txt_Transporteur.Name = "TRANSPORTEUR";
            txt_Transporteur.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTransporteurs.Columns.Add(txt_Transporteur);

            dgvTransporteurs.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
        }

        private void Localize_Dgv(string lang)
        {
            if (lang == "fr")
            {
                dgvTransporteurs.Columns["TRANSPORTEUR"].HeaderText = "TRANSPORTEUR";
            }
            if (lang == "en")
            {
                dgvTransporteurs.Columns["TRANSPORTEUR"].HeaderText = "CARRIER";
            }
            if (lang == "es")
            {
                dgvTransporteurs.Columns["TRANSPORTEUR"].HeaderText = "TRANSPORTADOR";
            }
        }

        private void Refresh_Dgv()
        {
            CamionTransporteur camionTransporteur = new CamionTransporteur();
            dgvTransporteurs.DataSource = camionTransporteur.FindNonLinkedCarriersByCamionId(vg_CamionId);
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(CamionTransporteurDetail));
                Localize_Dgv("fr");

            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(CamionTransporteurDetail));
                Localize_Dgv("en");

            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(CamionTransporteurDetail));
                Localize_Dgv("es");
            }
        }

        private void lblEnregistrerDgv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Int32 SelectedRowsCount = dgvTransporteurs.Rows.GetRowCount(DataGridViewElementStates.Selected);
            Int32[] Selected = new Int32[SelectedRowsCount];

            try
            {
                if (SelectedRowsCount > 0)
                {
                    for (int i = 0; i < SelectedRowsCount; i++)
                    {
                        Selected[i] = Int32.Parse(dgvTransporteurs.SelectedRows[i].Cells[0].Value.ToString());
                    }
                    for (int i = 0; i < SelectedRowsCount; i++)
                    {
                        try
                        {
                            CamionTransporteur camionTransporteur = new CamionTransporteur();
                            camionTransporteur.Add(vg_CamionId, Selected[i]);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", SelectedRowsCount + " transporteur(s) ajouté(s)", "Transporteur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", SelectedRowsCount + " carrier(s) added", "Carrier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES", SelectedRowsCount + " transportistas añadidos", "Transportador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Aucun enregistrement sélectionné", "Transporteur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "No rows selected", "Carrier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Transportador", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dgvTransporteurs.SelectAll();
        }

        private void lblDeselectionner_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dgvTransporteurs.ClearSelection();
        }

        private void dgvTransporteurs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTransporteurs.CurrentCell.Selected)
                dgvTransporteurs.CurrentCell.Selected = false;
            else
                dgvTransporteurs.CurrentCell.Selected = true;
        }

        
    }
}
