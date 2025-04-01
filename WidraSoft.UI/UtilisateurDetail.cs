using CustomMessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WidraSoft.BL;

namespace WidraSoft.UI
{
    public partial class UtilisateurDetail : Form
    {
        String vg_Mode = "";
        Int32 vg_Id = 0;
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;
        public UtilisateurDetail(String Mode, Int32 Id)
        {
            InitializeComponent();
            vg_Mode = Mode;
            vg_Id = Id;
        }

        private void UtilisateurDetail_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            
            Groupe groupe = new Groupe();
            cbGroupeId.DataSource = groupe.List("1=1");
            cbGroupeId.DisplayMember = "DESIGNATION";
            cbGroupeId.ValueMember = "GROUPEID";

            cbLanguage.DataSource = Values.Langue_Utilisateur;
            cbLanguage.ValueMember = null;
            cbLanguage.DisplayMember = Values.Langue_Utilisateur[0].ToString();


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
            Bind_DgvAuthorizationList();
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = MenuGeneral.languuage_index;
        }

        private void Bind_DgvAuthorizationList()
        {
            GroupeModule groupemodule = new GroupeModule();
            if (cbGroupeId.Text == "")
            {
                DgvAuthorizationList.DataSource = groupemodule.FindAuthorizedModulesByGroupeId(-1);
            }
            else
            {
                int Id;
                Id= (Int32)cbGroupeId.SelectedValue;
                DgvAuthorizationList.DataSource = groupemodule.FindAuthorizedModulesByGroupeId(Id);
            }

            DgvAuthorizationList.Columns[0].Visible = false;
            DgvAuthorizationList.Columns["DESIGNATION"].Visible = true;
            DgvAuthorizationList.Columns["TYPEACESS"].Visible = true;

            DgvAuthorizationList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvAuthorizationList.ReadOnly = true;
            DgvAuthorizationList.RowHeadersVisible = false;

        }

        private void Localize_DgvAuthorizationList(string lang)
        {
            if (lang == "fr")
            {
                DgvAuthorizationList.Columns["DESIGNATION"].HeaderText = "MODULE";
                DgvAuthorizationList.Columns["TYPEACESS"].HeaderText = "TYPE ACCES";
            }

            if (lang == "en")
            {
                DgvAuthorizationList.Columns["DESIGNATION"].HeaderText = "MODULE";
                DgvAuthorizationList.Columns["TYPEACESS"].HeaderText = "ACCESS TYPE";
            }

            if (lang == "es")
            {
                DgvAuthorizationList.Columns["DESIGNATION"].HeaderText = "MÓDULO";
                DgvAuthorizationList.Columns["TYPEACESS"].HeaderText = "TYPO DE ACCESO";
            }
        }

        private void Add_Item()
        {
            if (txtId.Text == "" && txtDateCreation.Text == "" && txtNom.Text=="" && txtPrenom.Text=="" && txtLogin.Text == "" && txtPassword.Text == "" && cbGroupeId.Text == "" && cbLanguage.Text == "")
            {
                lbModifier.Enabled = false;
                lbModifier.BackColor = Color.Transparent;
                lbSupprimer.Enabled = false;
                lbSupprimer.BackColor = Color.Transparent;
            }                       
        }

        private void Edit_Item()
        {
                lbAjouter.Enabled = false;
                lbAjouter.BackColor = Color.Transparent;
                Disable();
                Bind_Fields();           
        }
        private void Bind_Fields()
        {
            DataTable dt = new DataTable();
            Utilisateur utilisateur = new Utilisateur();
            dt = utilisateur.GetById(vg_Id);
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["UTILISATEURID"];
                txtId.Text = Id.ToString();
                txtDateCreation.Text = row["DATECREATION"].ToString();
                txtNom.Text = row["NOM"].ToString();
                txtPrenom.Text = row["PRENOM"].ToString();
                txtLogin.Text = row["LOGIN"].ToString();
                txtPassword.Text = row["PASSWORD"].ToString();
                if (row["GROUPEID"] is System.DBNull)
                    cbGroupeId.SelectedValue = 0;
                else
                    cbGroupeId.SelectedValue = (int)row["GROUPEID"];
                cbLanguage.Text = row["LANG"].ToString();
            }
        }

        private void Disable()
        {
            txtNom.Enabled = false;
            txtDateCreation.Enabled = false;
            txtPrenom.Enabled = false;
            txtLogin.Enabled = false;
            txtPassword.Enabled = false;
            cbGroupeId.Enabled = false;
            cbLanguage.Enabled = false;
            pbUpdating.Visible = false;
            DgvAuthorizationList.Enabled = false;

            vg_IsEnabled = false;
        }

        private void Enable()
        {
            txtNom.Enabled = true;
            txtDateCreation.Enabled = true;
            txtPrenom.Enabled = true;
            txtLogin.Enabled = true;
            txtPassword.Enabled = true;
            cbGroupeId.Enabled = true;
            cbLanguage.Enabled = true;
            pbUpdating.Visible = true;
            DgvAuthorizationList.Enabled = true;

            vg_IsEnabled = true;
        }

        private void Clear()
        {
            txtId.Text = "";
            txtDateCreation.Text = "";
            txtNom.Text = "";
            txtPrenom.Text = "";
            txtLogin.Text = "";
            txtPassword.Text = "";
            cbGroupeId.Text = "";
            cbLanguage.Text = "";
        }

      


        private void lbAjouter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtId.Text == "" && txtDateCreation.Text == "" && txtNom.Text != "" && txtPrenom.Text != "" && txtLogin.Text != "" && txtPassword.Text != "")
                {
                    Utilisateur utilisateur = new Utilisateur();
                    utilisateur.Add(txtNom.Text, txtPrenom.Text, txtLogin.Text, txtPassword.Text, Common_functions.CbSelectedValue_Convert_Int(cbGroupeId), cbLanguage.Text);
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Utilisateur ajouté avec succès", "Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "User added successfully", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES", "Usuario agregado", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Informations incomplètes", "Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "Incomplete informations", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES", "Información incompleta", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                throw;
            }
        }

        private void lbModifier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (vg_Update == false && vg_IsEnabled == false)
                {
                    Enable();
                    lbModifier.Text = Language_Manager.Localize("Valider", cbLang.Text);
                    vg_Update = true;
                }
                else
                {
                    try
                    {
                        if (txtId.Text != "" && txtNom.Text != "" && txtPrenom.Text != "" && txtLogin.Text != "" && txtPassword.Text != "")
                        {
                            Utilisateur utilisateur = new Utilisateur();
                            Int32 Id;
                            bool IsParsableId;
                            IsParsableId = Int32.TryParse(txtId.Text, out Id);
                            if (IsParsableId)
                            {
                                utilisateur.Update(Id, txtNom.Text, txtPrenom.Text, txtLogin.Text, txtPassword.Text, Common_functions.CbSelectedValue_Convert_Int(cbGroupeId), cbLanguage.Text);
                                if (cbLang.Text == "FR")
                                    Custom_MessageBox.Show("FR", "Utilisateur modifié avec succès", "Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else if (cbLang.Text == "EN")
                                    Custom_MessageBox.Show("EN", "User updated successfully", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    Custom_MessageBox.Show("ES", "Usuario alterado", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                lbModifier.Text = Language_Manager.Localize("Modifier", cbLang.Text);
                                vg_Update = false;
                                Disable();
                                Bind_Fields();
                                Bind_DgvAuthorizationList();
                            }
                        }
                        else
                        {
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Informations incomplètes", "Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Incomplete informations", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Información incompleta", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void lbSupprimer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (vg_Update)
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas supprimer l'enregistrement tant que la modification n'est pas validée", "Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You can't delete this record before the update is completed", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    Custom_MessageBox.Show("ES", "No puede eliminar el registro hasta que se confirme el cambio", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    Utilisateur utilisateur = new Utilisateur();
                    Int32 Id;
                    bool IsParsableId;
                    IsParsableId = Int32.TryParse(txtId.Text, out Id);
                    if (IsParsableId)
                    {
                        DialogResult result;
                        if (cbLang.Text == "FR")
                            result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir supprimer cet enregistrement?", "Utilisateur", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else if (cbLang.Text == "EN")
                            result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else
                            result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            utilisateur.Delete(Id);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Utilisateur supprimé avec succès", "Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "User deleted successfully", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Usuario eliminado", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void UtilisateurDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vg_Mode == "Edit")
            {
                if (pbUpdating.Visible)
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Vous ne pouvez pas fermer la fenetre tant que la modification n'est pas validée", "Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "You can't close this window before the update is completed", "User", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        Custom_MessageBox.Show("ES", "No puede cerrar la página hasta que se valide el cambio", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    e.Cancel = true;
                }
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
                language_Manager.ChangeLanguage("fr", this, typeof(UtilisateurDetail));
                Localize_DgvAuthorizationList("fr");
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(UtilisateurDetail));
                Localize_DgvAuthorizationList("en");
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(UtilisateurDetail));
                Localize_DgvAuthorizationList("es");
            }
        }

    }
}
