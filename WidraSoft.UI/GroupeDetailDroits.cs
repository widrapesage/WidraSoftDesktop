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
    public partial class GroupeDetailDroits : Form
    {
        Int32 vg_GroupeId = 0;
        public GroupeDetailDroits(Int32 GroupeId)
        {
            InitializeComponent();
            vg_GroupeId = GroupeId;
        }

        private void GroupeDetailDroits_Load(object sender, EventArgs e)
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
            dgvGroupeDroits.AutoGenerateColumns = false;
            GroupeModule groupemodule = new GroupeModule();
            if (vg_GroupeId > 0)
            {
                dgvGroupeDroits.DataSource = groupemodule.FindNonAuthorizedModulesByGroupeId(vg_GroupeId);
            }

            //Crée et ajoute le textbox pour le champ MODULEID  (Masqué)
            DataGridViewTextBoxColumn txt_ModuleId = new DataGridViewTextBoxColumn();
            txt_ModuleId.HeaderText = "ID";
            txt_ModuleId.DataPropertyName = "MODULEID";
            txt_ModuleId.Name = "MODULEID";
            dgvGroupeDroits.Columns.Add(txt_ModuleId);
            txt_ModuleId.Visible = false;

            //Crée et ajoute la combo pour le champ MODULE
            DataGridViewTextBoxColumn txt_Module = new DataGridViewTextBoxColumn();
            txt_Module.HeaderText = "MODULE";
            txt_Module.DataPropertyName = "DESIGNATION";
            txt_Module.Name = "MODULE";
            txt_Module.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGroupeDroits.Columns.Add(txt_Module);

            dgvGroupeDroits.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
        }

        private void Localize_Dgv(string lang)
        {
            if (lang == "fr")
            {
                dgvGroupeDroits.Columns["MODULE"].HeaderText = "MODULE";
            }
            if (lang == "en")
            {
                dgvGroupeDroits.Columns["MODULE"].HeaderText = "MODULE";
            }  
            if (lang == "es")
            {
                dgvGroupeDroits.Columns["MODULE"].HeaderText = "MÓDULO";
            }
        }

        private void Refresh_Dgv()
        { 
            GroupeModule groupemodule = new GroupeModule();            
            dgvGroupeDroits.DataSource = groupemodule.FindNonAuthorizedModulesByGroupeId(vg_GroupeId);
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(GroupeDetailDroits));
                Localize_Dgv("fr");
                
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(GroupeDetailDroits));
                Localize_Dgv("en");
                
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager= new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(GroupeDetailDroits));
                Localize_Dgv("es"); 
            }
        }

        private void lblEnregistrerDgv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Int32 SelectedRowsCount = dgvGroupeDroits.Rows.GetRowCount(DataGridViewElementStates.Selected);
            Int32[] Selected = new Int32[SelectedRowsCount];

            try
            {
                if (SelectedRowsCount > 0)
                {
                    for (int i = 0; i < SelectedRowsCount; i++)
                    {
                        Selected[i] = Int32.Parse(dgvGroupeDroits.SelectedRows[i].Cells[0].Value.ToString());
                    }
                    for (int i = 0; i < SelectedRowsCount; i++)
                    {
                        try
                        {
                            GroupeModule groupemodule = new GroupeModule();
                            groupemodule.Add(vg_GroupeId, Selected[i], 1, "RW");
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", SelectedRowsCount + " droit(s) ajouté(s)", "Droits d'accès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", SelectedRowsCount + " Permission(s) granted", "Permission manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES", SelectedRowsCount + " derecho(s) añadido(s)", "Derechos de acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Aucun enregistrement sélectionné", "Droits d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "No rows selected", "Permission manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Derechos de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dgvGroupeDroits.SelectAll();
        }

        private void lblDeselectionner_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dgvGroupeDroits.ClearSelection();
        }

        private void dgvGroupeDroits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGroupeDroits.CurrentCell.Selected)
                dgvGroupeDroits.CurrentCell.Selected = false;
            else
                dgvGroupeDroits.CurrentCell.Selected = true;
        }


    }
}
