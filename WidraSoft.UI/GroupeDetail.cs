using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WidraSoft.BL;
using CustomMessageBox;

namespace WidraSoft.UI
{
    public partial class GroupeDetail : Form
    {
        String vg_Mode = "";
        Int32 vg_Id = 0;
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;
        Boolean vg_Add = false;
        public GroupeDetail(String Mode, Int32 Id)
        {
            InitializeComponent();
            vg_Mode = Mode;
            vg_Id = Id;
        }

        private void GroupeDetail_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            
            if (vg_Mode == "Add")
            {
                try
                { 
                    Clear();
                    Add_Item();
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                if (vg_Mode == "Edit")
                {
                    try
                    {
                        Edit_Item();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            Bind_DgvUsersList();
            Bind_Dgv();
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = 0;           
        }

        private void Add_Item()
        {
            if (txtId.Text=="" && txtDateCreation.Text == "" && txtDesignation.Text == "" && txtCode.Text == "" && cbLimite.Text == "" && txtNbLimite.Text == "")
            {
                btModifier.Enabled = false;
                btModifier.BackColor = Color.Transparent;
                btSupprimer.Enabled = false;
                btSupprimer.BackColor = Color.Transparent;
            }
        }

        private void Edit_Item()
        {
            btAjouter.Enabled = false;
            btAjouter.BackColor = Color.Transparent;
            Disable();
            Bind_Fields();

        }

        private void Bind_Fields()
        {
            DataTable dt = new DataTable();
            Groupe groupe = new Groupe();
            dt = groupe.FindById(vg_Id);
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["GROUPEID"];
                txtId.Text = Id.ToString();
                txtDateCreation.Text = row["DATECREATION"].ToString();
                txtDesignation.Text = row["DESIGNATION"].ToString();
                txtCode.Text = row["CODE"].ToString();
                cbLimite.Text = row["LIMITER"].ToString();
                txtNbLimite.Text = row["NBLIMITE"].ToString();
            }
        }

        private void Refresh_Dgv()
        {
            int Id;
            bool IsParsableId;
            GroupeModule groupemodule = new GroupeModule();
            IsParsableId = Int32.TryParse(txtId.Text, out Id);
            dgvGroupeDroits.DataSource = groupemodule.FindByGroupeId(Id);
        }

        private void Bind_DgvUsersList()
        {
            Groupe groupe = new Groupe();
            if (txtId.Text == "")
            {
                DgvUsersList.DataSource = groupe.FindUsersById(-1);
            }
            else
            {
                int Id;
                bool IsParsableId;
                IsParsableId = Int32.TryParse(txtId.Text, out Id);
                DgvUsersList.DataSource = groupe.FindUsersById(Id);
            }

            DgvUsersList.Columns[0].Visible = false;
            DgvUsersList.Columns["LOGIN"].Width = 100;
            DgvUsersList.Columns["PRENOM"].Width = 100;
            DgvUsersList.Columns["NOM"].Width = 100;
            DgvUsersList.Columns["GROUPEID"].Visible = false;
            DgvUsersList.Columns["GROUPE"].Visible = false;
            DgvUsersList.Columns["DATECREATION"].Visible = false;

            DgvUsersList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvUsersList.ReadOnly = true;
            DgvUsersList.RowHeadersVisible = false;
            
        }

        private void Localize_DgvUsersList(string lang)
        {
            if (lang == "fr")
            {
                DgvUsersList.Columns["LOGIN"].HeaderText = "LOGIN";
                DgvUsersList.Columns["PRENOM"].HeaderText = "PRENOM";
                DgvUsersList.Columns["NOM"].HeaderText = "NOM";
                DgvUsersList.Columns["GROUPE"].HeaderText = "GROUPE";
                DgvUsersList.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            }

            if (lang == "en")
            {
                DgvUsersList.Columns["LOGIN"].HeaderText = "LOGIN";
                DgvUsersList.Columns["PRENOM"].HeaderText = "FIRST NAME";
                DgvUsersList.Columns["NOM"].HeaderText = "LAST NAME";
                DgvUsersList.Columns["GROUPE"].HeaderText = "GROUP";
                DgvUsersList.Columns["DATECREATION"].HeaderText = "CREATION DATE";
            }
        }


        private void Bind_Dgv()
        {
            //Definit la source du Dgv 
            dgvGroupeDroits.AutoGenerateColumns = false;
            GroupeModule groupemodule = new GroupeModule();
            if (txtId.Text == "")
            {
                dgvGroupeDroits.DataSource = groupemodule.FindByGroupeId(-1);
            }
            else
            {
                int Id;
                bool IsParsableId;
                IsParsableId = Int32.TryParse(txtId.Text, out Id);
                dgvGroupeDroits.DataSource = groupemodule.FindByGroupeId(Id);
            }

            //Crée et ajoute le textbox pour le champ GROUPEMODULEID  (Masqué)
            DataGridViewTextBoxColumn txt_GroupeModuleId = new DataGridViewTextBoxColumn();
            txt_GroupeModuleId.HeaderText = "ID";
            txt_GroupeModuleId.DataPropertyName = "GROUPEMODULEID";
            txt_GroupeModuleId.Name = "GROUPEMODULEID";
            dgvGroupeDroits.Columns.Add(txt_GroupeModuleId);
            txt_GroupeModuleId.Visible = false;
            // Crée et ajoute la combo pour le champ GROUPEID (Masqué)
            DataGridViewComboBoxColumn cbx_GroupeId = new DataGridViewComboBoxColumn();
            cbx_GroupeId.HeaderText = "GROUPE";
            Groupe groupe = new Groupe();
            cbx_GroupeId.DataSource = groupe.List("1=1");
            cbx_GroupeId.DisplayMember = "DESIGNATION";
            cbx_GroupeId.ValueMember = "GROUPEID";
            cbx_GroupeId.DataPropertyName = "GROUPEID";
            cbx_GroupeId.Name = "GROUPEID";
            dgvGroupeDroits.Columns.Add(cbx_GroupeId);
            cbx_GroupeId.Visible = false;
            //Crée et ajoute la combo pour le champ MODULEID 
            DataGridViewComboBoxColumn cbx_ModuleId = new DataGridViewComboBoxColumn();
            cbx_ModuleId.HeaderText = "MODULE";
            Module module = new Module();
            cbx_ModuleId.DataSource = module.List();
            cbx_ModuleId.DisplayMember = "DESIGNATION"; 
            cbx_ModuleId.ValueMember = "MODULEID";
            cbx_ModuleId.DataPropertyName = "MODULEID";
            cbx_ModuleId.Name = "MODULEID";
            cbx_ModuleId.Width = 850;
            dgvGroupeDroits.Columns.Add(cbx_ModuleId);
            //Crée et ajoute le checkBox pour le champ ACCES
            DataGridViewCheckBoxColumn chx_Acces = new DataGridViewCheckBoxColumn();
            chx_Acces.HeaderText = "ACCES";
            chx_Acces.DataPropertyName = "ACCES";
            chx_Acces.Name = "ACCES";
            chx_Acces.TrueValue = 1;
            chx_Acces.FalseValue = 0;
            chx_Acces.Width = 50;
            dgvGroupeDroits.Columns.Add(chx_Acces);
            chx_Acces.Visible = false;
            // Crée et ajoute la combo pour le champ TYPEACESS
            DataGridViewComboBoxColumn cbx_TypeAcess = new DataGridViewComboBoxColumn();
            cbx_TypeAcess.HeaderText = "TYPE ACCES";
            cbx_TypeAcess.DataPropertyName = "TYPEACESS";
            cbx_TypeAcess.Name = "TYPEACESS";
            cbx_TypeAcess.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cbx_TypeAcess.Items.AddRange(new string[] { "RW", "RO" });
            dgvGroupeDroits.Columns.Add(cbx_TypeAcess);

            dgvGroupeDroits.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
        }

        private void Localize_Dgv(string lang)
        {
            if (lang == "fr")
            {
                dgvGroupeDroits.Columns["GROUPEID"].HeaderText = "GROUPE";
                dgvGroupeDroits.Columns["MODULEID"].HeaderText = "MODULE";
                dgvGroupeDroits.Columns["ACCES"].HeaderText = "ACCES";
                dgvGroupeDroits.Columns["TYPEACESS"].HeaderText = "TYPE ACCES";
            }

            if (lang == "en")
            {
                dgvGroupeDroits.Columns["GROUPEID"].HeaderText = "GROUP";
                dgvGroupeDroits.Columns["MODULEID"].HeaderText = "MODULE";
                dgvGroupeDroits.Columns["ACCES"].HeaderText = "ACCESS";
                dgvGroupeDroits.Columns["TYPEACESS"].HeaderText = "ACCESS TYPE";
            }
        }

        private void Clear()
        {
            txtId.Text = "";
            txtDateCreation.Text = "";
            txtDesignation.Text = "";
            txtCode.Text = "";
            cbLimite.Text = "";
            txtNbLimite.Text = "";
        }

        private void Enable()
        {
            txtDateCreation.Enabled = true;
            txtDesignation.Enabled = true;
            txtCode.Enabled = true;
            cbLimite.Enabled = true;
            txtNbLimite.Enabled = true;
            dgvGroupeDroits.Enabled = true;
            dgvGroupeDroits.AllowUserToAddRows = true;
            dgvGroupeDroits.AllowUserToDeleteRows = true;
            DgvUsersList.Enabled = true;
            lblEnregistrerDgv.Enabled = true;
            lblRetirerDgv.Enabled = true;
            pbLocked.Visible = false;

            vg_IsEnabled = true;
        }

        private void Disable()
        {
            txtDateCreation.Enabled = false;
            txtDesignation.Enabled = false;
            txtCode.Enabled = false;
            cbLimite.Enabled = false;
            txtNbLimite.Enabled = false;
            dgvGroupeDroits.Enabled = false;
            dgvGroupeDroits.AllowUserToAddRows = false;
            dgvGroupeDroits.AllowUserToDeleteRows = false;
            DgvUsersList.Enabled=false;
            lblEnregistrerDgv.Enabled = false;
            lblRetirerDgv.Enabled = false;
            pbLocked.Visible = true;

            vg_IsEnabled = false;
        }
        private void btAjouter_MouseEnter(object sender, EventArgs e)
        {
            if (btAjouter.Enabled == true)
                btAjouter.BackColor = Color.Honeydew;
        }

        private void btAjouter_MouseLeave(object sender, EventArgs e)
        {
            if (btAjouter.Enabled == true)
                btAjouter.BackColor = Color.FromArgb(110, 230, 130);
        }

        private void btModifier_MouseEnter(object sender, EventArgs e)
        {
            if (btModifier.Enabled == true)
                btModifier.BackColor = Color.Honeydew;
        }

        private void btModifier_MouseLeave(object sender, EventArgs e)
        {
            if (btModifier.Enabled == true)
                btModifier.BackColor = Color.FromArgb(110, 230, 130);
        }

        private void btSupprimer_MouseEnter(object sender, EventArgs e)
        {
            if (btSupprimer.Enabled == true)
                btSupprimer.BackColor = Color.Honeydew;
        }

        private void btSupprimer_MouseLeave(object sender, EventArgs e)
        {
            if (btSupprimer.Enabled == true)
                btSupprimer.BackColor = Color.FromArgb(110, 230, 130);
        }

        private void btAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNbLimite.Text))
                {
                    txtNbLimite.Text = "0";
                }
                if (txtId.Text == "" && txtDateCreation.Text == "" && txtDesignation.Text != "" && txtCode.Text != "" && cbLimite.Text != "" && txtNbLimite.Text != "")
                {
                    int NbLimite;
                    bool IsParsableNbLimite;
                    IsParsableNbLimite = Int32.TryParse(txtNbLimite.Text, out NbLimite);
                    if (IsParsableNbLimite)
                    {
                        Groupe groupe = new Groupe();
                        groupe.Add(txtDesignation.Text, txtCode.Text, cbLimite.Text, NbLimite);
                        if (cbLang.Text == "FR")
                            Custom_MessageBox.Show("FR", "Groupe ajouté avec succès", "Groupe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (cbLang.Text == "EN")
                            Custom_MessageBox.Show("EN", "Group added successfully", "Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            Custom_MessageBox.Show("FR", "Groupe ajouté avec succès", "Groupe", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Close();
                    }
                    else
                    {
                        if (cbLang.Text == "FR")
                            Custom_MessageBox.Show("FR", "Le nombre limite d'utiilisateurs doit etre un nombre entier", "Groupe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (cbLang.Text == "EN")
                            Custom_MessageBox.Show("EN", "The limit number of users must be a valid number", "Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            Custom_MessageBox.Show("FR", "Nombre limite d'utiilisateurs doit etre un nombre entier", "Groupe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Informations incomplètes", "Groupe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "Incomplete informations", "Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("FR", "Informations incomplètes", "Groupe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                throw;
            }
        }

        private void btModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (vg_Update == false && vg_IsEnabled == false)
                {
                    Enable();
                    btModifier.Text = Language_Manager.Localize("Valider", cbLang.Text);
                    vg_Update = true;
                }
                else
                {
                    try
                    {
                        if (string.IsNullOrEmpty(txtNbLimite.Text))
                        {
                            txtNbLimite.Text = "0";
                        }
                        if (txtId.Text != "" && txtDateCreation.Text != "" && txtDesignation.Text != "" && txtCode.Text != "" && cbLimite.Text != "" && txtNbLimite.Text != "")
                        {
                            Groupe groupe = new Groupe();
                            int Id;
                            int NbLimite;
                            bool IsParsableId;
                            bool IsParsableNbLimite;
                            IsParsableId = Int32.TryParse(txtId.Text, out Id);
                            IsParsableNbLimite = Int32.TryParse(txtNbLimite.Text, out NbLimite);
                            if (IsParsableId && IsParsableNbLimite)
                            { 
                                groupe.Update(Id, txtDesignation.Text, txtCode.Text, cbLimite.Text, NbLimite);
                                if (cbLang.Text == "FR")
                                    Custom_MessageBox.Show("FR", "Groupe modifié avec succès", "Groupe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else if (cbLang.Text == "EN")
                                    Custom_MessageBox.Show("EN", "Group updated successfully", "Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    Custom_MessageBox.Show("FR", "Groupe modifié avec succès", "Groupe", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                btModifier.Text = Language_Manager.Localize("Modifier", cbLang.Text);
                                vg_Update = false;
                                Disable();
                                Bind_Fields();
                                Refresh_Dgv();
                            }
                        }
                        else
                        {
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Informations incomplètes", "Groupe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Incomplete informations", "Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("FR", "Informations incomplètes", "Groupe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void btSupprimer_Click(object sender, EventArgs e)
        {
            if (vg_Update)
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas supprimer l'enregistrement tant que la modification n'est pas validée", "Groupe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You can't delete this record before the update is completed", "Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas supprimer l'enregistrement tant que la modification n'est pas validée", "Groupe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    Groupe groupe = new Groupe();
                    int Id;
                    bool IsParsableId;
                    IsParsableId = Int32.TryParse(txtId.Text, out Id);
                    if (IsParsableId)
                    {
                        DialogResult result;
                        if (cbLang.Text == "FR")
                            result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir supprimer cet enregistrement?", "Groupe", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else if (cbLang.Text == "EN")
                            result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else
                            result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir supprimer cet enregistrement?", "Groupe", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            groupe.Delete(Id);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Groupe supprimé avec succès", "Groupe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Group deleted successfully", "Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("FR", "Groupe supprimé avec succès", "Groupe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }                      
                    }
                }
                catch
                {
                    throw;
                }
            }
        }


        private Int32[] GetSelectedRowsId()
        {
            try
            {
                Int32 SelectedRowsCount = dgvGroupeDroits.Rows.GetRowCount(DataGridViewElementStates.Selected);
                Int32[] Selected = new Int32[SelectedRowsCount];
                if (SelectedRowsCount > 0)
                {

                    for (int i = 0; i < SelectedRowsCount; i++)
                    {
                        Selected[i] = Int32.Parse(dgvGroupeDroits.SelectedRows[i].Cells[0].Value.ToString());
                    }

                }
                return Selected;
            }
            catch
            {
                throw;
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
                language_Manager.ChangeLanguage("fr", this, typeof(GroupeDetail));
                Localize_Dgv("fr");
                Localize_DgvUsersList("fr");
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(GroupeDetail));
                Localize_Dgv("en");
                Localize_DgvUsersList("en");
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                /*Language_Manager language_Manager= new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(GroupeDetail));
                Localize_Dgv("es"); */
            }
        }

        private void lblRetirerDgv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Int32[] selectedIds = new Int32[GetSelectedRowsId().Length];
            selectedIds = GetSelectedRowsId();
            if (GetSelectedRowsId().Length > 0)
            {
                for (int i = 0; i < GetSelectedRowsId().Length; i++)
                {
                    //MessageBox.Show(selectedIds[i].ToString());

                    try
                    {
                        GroupeModule groupemodule = new GroupeModule();
                        groupemodule.Delete(selectedIds[i]);
                    }
                    catch
                    {
                        throw;
                    }
                }
                MessageBox.Show(GetSelectedRowsId().Length + " droit(s) supprimé(s)");
                Refresh_Dgv();
            }
            else
            {
                MessageBox.Show("Vous n'avez selectionné aucun enregistrement à supprimer");
            }

        }

        private void dgvGroupeDroits_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((int)dgvGroupeDroits[0, e.RowIndex].Value == 0 && (int)dgvGroupeDroits[1, e.RowIndex].Value > 0 && !string.IsNullOrEmpty(dgvGroupeDroits[2, e.RowIndex].Value.ToString()) && !string.IsNullOrEmpty(dgvGroupeDroits[4, e.RowIndex].Value.ToString()))
            {
                try
                {
                    GroupeModule groupemodule = new GroupeModule();
                    groupemodule.Add((int)dgvGroupeDroits[1, e.RowIndex].Value, (int)dgvGroupeDroits[2, e.RowIndex].Value, (int)dgvGroupeDroits[3, e.RowIndex].Value, dgvGroupeDroits[4, e.RowIndex].Value.ToString());

                }
                catch
                {
                    throw;
                }
            }

            if ((int)dgvGroupeDroits[0, e.RowIndex].Value > 0 && (int)dgvGroupeDroits[1, e.RowIndex].Value > 0 && !string.IsNullOrEmpty(dgvGroupeDroits[2, e.RowIndex].Value.ToString()) && !string.IsNullOrEmpty(dgvGroupeDroits[4, e.RowIndex].Value.ToString()))
            {
                try
                {
                    GroupeModule groupemodule = new GroupeModule();
                    groupemodule.Update((int)dgvGroupeDroits[0, e.RowIndex].Value, (int)dgvGroupeDroits[1, e.RowIndex].Value, (int)dgvGroupeDroits[2, e.RowIndex].Value, (int)dgvGroupeDroits[3, e.RowIndex].Value, dgvGroupeDroits[4, e.RowIndex].Value.ToString());

                }
                catch
                {
                    throw;
                }
            }
            Refresh_Dgv();
        }

        private void dgvGroupeDroits_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                GroupeModule groupemodule = new GroupeModule();
                e.Row.Cells["GROUPEMODULEID"].Value = 0;
                e.Row.Cells["GROUPEID"].Value = txtId.Text;
                e.Row.Cells["ACCES"].Value = 1;
                e.Row.Cells["TYPEACESS"].Value = "RO";
            }
            catch
            {
                throw;
            }
        }
    }
}
