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
    public partial class TablesDetail : Form
    {
        String vg_Mode = "";
        Int32 vg_Id = 0;
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;
        public TablesDetail(String Mode, Int32 Id)
        {
            InitializeComponent();
            vg_Mode = Mode;
            vg_Id = Id;
        }

        private void TablesDetail_Load(object sender, EventArgs e)
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
            Bind_DgvEnregistrements();
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = 0;
        }

        private void Add_Item()
        {
            if (txtId.Text == "" && txtDateCreation.Text == "" && txtNom.Text == "" && txtInclurePesee.Text == "" && txtInclureTicket.Text == "" && txtEntrant.Text == ""
                && txtSortant.Text == "" && txtObservations.Text == "")
            {   
                //Tables 
                Tables tables = new Tables();
                cbTableParentId.DataSource = tables.List("1=1");
                cbTableParentId.DisplayMember = "NOM";
                cbTableParentId.ValueMember = "TABLESID";
                cbTableParentId.Text = "";

                lbModifier.Enabled = false;
                lbModifier.BackColor = Color.Transparent;
                lbSupprimer.Enabled = false;
                lbSupprimer.BackColor = Color.Transparent;
               
                txtInclurePesee.Text = "1";
                chx_InclurePesee.Checked = true;
                txtInclureTicket.Text = "1";
                chx_InclureTicket.Checked = true;
                txtEntrant.Text = "1";
                chx_Entrant.Checked = true;
                txtSortant.Text = "1";
                chx_Sortant.Checked = true;               
            }
        }

        private void Edit_Item()
        {
            //Tables 
            Tables tables = new Tables();
            cbTableParentId.DataSource = tables.FindExceptId(vg_Id);
            cbTableParentId.DisplayMember = "NOM";
            cbTableParentId.ValueMember = "TABLESID";
            lbAjouter.Enabled = false;
            lbAjouter.BackColor = Color.Transparent;
            Disable();
            Bind_Fields();
        }

        private void Bind_Fields()
        {
            DataTable dt = new DataTable();
            Tables tables = new Tables();
            dt = tables.FindById(vg_Id);
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["TABLESID"];
                txtId.Text = Id.ToString();
                txtDateCreation.Text = row["DATECREATION"].ToString();
                txtNom.Text = row["NOM"].ToString();
                if (row["TABLEPARENTID"] is System.DBNull)
                    cbTableParentId.SelectedValue = 0;
                else
                    cbTableParentId.SelectedValue = (int)row["TABLEPARENTID"];
                txtInclurePesee.Text = row["INCLUREDANSPESEE"].ToString();
                if (txtInclurePesee.Text == "1")
                    chx_InclurePesee.Checked = true;
                else
                    chx_InclurePesee.Checked = false;
                txtInclureTicket.Text = row["INCLUREDANSTICKET"].ToString();
                if (txtInclureTicket.Text == "1")
                    chx_InclureTicket.Checked = true;
                else
                    chx_InclureTicket.Checked = false;
                txtEntrant.Text = row["ESTENTRANT"].ToString();
                if (txtEntrant.Text == "1")
                    chx_Entrant.Checked = true;
                else
                    chx_Entrant.Checked = false;
                txtSortant.Text = row["ESTSORTANT"].ToString();
                if (txtSortant.Text == "1")
                    chx_Sortant.Checked = true;
                else
                    chx_Sortant.Checked = false;
                txtObservations.Text = row["OBSERVATIONS"].ToString();
            }
        }

        private void Disable()
        {
            txtDateCreation.Enabled = false;
            txtNom.Enabled = false;
            cbTableParentId.Enabled = false;
            chx_InclurePesee.Enabled = false;
            chx_InclureTicket.Enabled = false;
            chx_Entrant.Enabled = false;
            chx_Sortant.Enabled = false;        
            txtObservations.Enabled = false;
            dgvEnregistrements.Enabled = false;
            dgvTraductions.Enabled = false;
            lblAddDgvChauffeurs.Enabled = false;
            lblRetirerDgvChauffeurs.Enabled = false;
            lbActualiserDgvChauffeurs.Enabled = false;
            lblAddDgvTransporteurs.Enabled = false;
            lblRetirerDgvTransporteurs.Enabled = false;
            lbActualiserDgvTransporteurs.Enabled = false;
            pbUpdating.Visible = false;

            vg_IsEnabled = false;
        }

        private void Enable()
        {
            txtDateCreation.Enabled = true;
            txtNom.Enabled = true;
            cbTableParentId.Enabled = true;
            chx_InclurePesee.Enabled = true;
            chx_InclureTicket.Enabled = true;
            chx_Entrant.Enabled = true;
            chx_Sortant.Enabled = true;
            txtObservations.Enabled = true;
            dgvEnregistrements.Enabled = true;
            dgvTraductions.Enabled = true;
            lblAddDgvChauffeurs.Enabled = true;
            lblRetirerDgvChauffeurs.Enabled = true;
            lbActualiserDgvChauffeurs.Enabled = true;
            lblAddDgvTransporteurs.Enabled = true;
            lblRetirerDgvTransporteurs.Enabled = true;
            lbActualiserDgvTransporteurs.Enabled = true;
            pbUpdating.Visible = true;

            vg_IsEnabled = true;
        }

        private void Clear()
        {
            txtId.Text = "";
            txtDateCreation.Text = "";
            txtNom.Text = "";
            cbTableParentId.Text = "";
            txtObservations.Text = "";
            chx_InclurePesee.Checked = false;
            chx_InclureTicket.Checked = false;
            chx_Entrant.Checked = false;
            chx_Sortant.Checked = false;
        }

        private void Bind_DgvEnregistrements()
        {
            TablesEnregistrements tablesEnregistrements = new TablesEnregistrements();
            if (txtId.Text == "")
            {
                dgvEnregistrements.DataSource = tablesEnregistrements.FindByTablesId(-1);
            }
            else
            {
                int Id;
                bool IsParsableId;
                IsParsableId = Int32.TryParse(txtId.Text, out Id);
                dgvEnregistrements.DataSource = tablesEnregistrements.FindByTablesId(Id);
            }

            dgvEnregistrements.Columns[0].Visible = false;
            dgvEnregistrements.Columns["ENREGISTREMENT"].Visible = true;
            dgvEnregistrements.Columns["TABLESID"].Visible = false;
            dgvEnregistrements.Columns["TABLES"].Visible = false;
            dgvEnregistrements.Columns["DATECREATION"].Visible = false;

            dgvEnregistrements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEnregistrements.ReadOnly = true;

        }

        private void Localize_DgvEnregistrements(string lang)
        {
            if (lang == "fr")
            {
                dgvEnregistrements.Columns["ENREGISTREMENT"].HeaderText = "ENREGISTREMENT";
                dgvEnregistrements.Columns["TABLES"].HeaderText = "TABLES";
                dgvEnregistrements.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            }

            if (lang == "en")
            {
                dgvEnregistrements.Columns["ENREGISTREMENT"].HeaderText = "RECORD";
                dgvEnregistrements.Columns["TABLES"].HeaderText = "TABLES";
                dgvEnregistrements.Columns["DATECREATION"].HeaderText = "CREATION DATE";
            }

            if (lang == "es")
            {
                dgvEnregistrements.Columns["ENREGISTREMENT"].HeaderText = "REGISTRO";
                dgvEnregistrements.Columns["TABLES"].HeaderText = "TABLA";
                dgvEnregistrements.Columns["DATECREATION"].HeaderText = "FECHA DE CREACIÓN";
            }
        }

        private void Refresh_DgvTransporteurs()
        {
            int Id;
            bool IsParsableId;
            TablesEnregistrements tablesEnregistrements = new TablesEnregistrements();
            IsParsableId = Int32.TryParse(txtId.Text, out Id);
            dgvEnregistrements.DataSource = tablesEnregistrements.FindByTablesId(Id);
        }

        private void lbActualiserDgvChauffeurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Refresh_DgvTransporteurs();
        }


        private void chx_InclurePesee_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_InclurePesee.Checked)
                txtInclurePesee.Text = "1";
            else
                txtInclurePesee.Text = "0";
        }

        private void chx_InclureTicket_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_InclureTicket.Checked)
                txtInclureTicket.Text = "1";
            else
                txtInclureTicket.Text = "0";
        }

        private void chx_Entrant_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Entrant.Checked)
                txtEntrant.Text = "1";
            else
                txtEntrant.Text = "0";
        }

        private void chx_Sortant_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Sortant.Checked)
                txtSortant.Text = "1";
            else
                txtSortant.Text = "0";
        }

        private void lbAjouter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtId.Text == "" && txtDateCreation.Text == "" && txtNom.Text != "" && txtInclurePesee.Text != "" && txtInclureTicket.Text != "" && txtEntrant.Text != "" && txtSortant.Text != "")
                {
                    int InclurePesee;
                    int InclureTicket;
                    int Entrant;
                    int Sortant;
                    bool IsParsableInclurePesee;
                    bool IsParsableInclureTicket;
                    bool IsParsableEntrant;
                    bool IsParsableSortant;
                    IsParsableInclurePesee = Int32.TryParse(txtInclurePesee.Text, out InclurePesee);
                    IsParsableInclureTicket = Int32.TryParse(txtInclureTicket.Text, out InclureTicket);
                    IsParsableEntrant = Int32.TryParse(txtEntrant.Text, out Entrant);
                    IsParsableSortant = Int32.TryParse(txtSortant.Text, out Sortant);
                    try
                    {
                        if (IsParsableInclurePesee && IsParsableInclureTicket && IsParsableEntrant && IsParsableSortant)
                        {
                            Tables tables = new Tables();
                            tables.Add(txtNom.Text, InclurePesee, InclureTicket, Entrant, Sortant, Common_functions.CbSelectedValue_Convert_Int(cbTableParentId), txtObservations.Text);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Table ajoutée avec succès", "Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Table added successfully", "Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Tabla agregado", "Tabla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                    }
                    catch
                    {
                        throw;
                    }

                }
                else
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Informations incomplètes", "Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "Incomplete informations", "Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES", "Información incompleta", "Tabla", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (txtId.Text != "" && txtDateCreation.Text != "" && txtNom.Text != "" && txtInclurePesee.Text != "" && txtInclureTicket.Text != "" && txtEntrant.Text != "" && txtSortant.Text != "")
                        {
                            int Id;
                            int InclurePesee;
                            int InclureTicket;
                            int Entrant;
                            int Sortant;
                            bool IsParsableId;
                            bool IsParsableInclurePesee;
                            bool IsParsableInclureTicket;
                            bool IsParsableEntrant;
                            bool IsParsableSortant;
                            IsParsableId = Int32.TryParse(txtId.Text, out Id);
                            IsParsableInclurePesee = Int32.TryParse(txtInclurePesee.Text, out InclurePesee);
                            IsParsableInclureTicket = Int32.TryParse(txtInclureTicket.Text, out InclureTicket);
                            IsParsableEntrant = Int32.TryParse(txtEntrant.Text, out Entrant);
                            IsParsableSortant = Int32.TryParse(txtSortant.Text, out Sortant);
                            try
                            {
                                if (IsParsableId && IsParsableInclurePesee && IsParsableInclureTicket && IsParsableEntrant && IsParsableSortant)
                                {
                                    Tables tables = new Tables();
                                    tables.Update(Id, txtNom.Text, InclurePesee, InclureTicket, Entrant, Sortant, Common_functions.CbSelectedValue_Convert_Int(cbTableParentId), txtObservations.Text);
                                    if (cbLang.Text == "FR")
                                        Custom_MessageBox.Show("FR", "Table modifiée avec succès", "Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else if (cbLang.Text == "EN")
                                        Custom_MessageBox.Show("EN", "Table updated successfully", "Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                        Custom_MessageBox.Show("ES", "Tabla alterado", "Tabla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lbModifier.Text = Language_Manager.Localize("Modifier", cbLang.Text);
                                    vg_Update = false;
                                    Disable();
                                    Bind_Fields();
                                }
                            }
                            catch
                            {
                                throw;
                            }
                        }
                        else
                        {
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Informations incomplètes", "Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Incomplete informations", "Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Información incompleta", "Tabla", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas supprimer l'enregistrement tant que la modification n'est pas validée", "Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You can't delete this record before the update is completed", "Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    Custom_MessageBox.Show("ES", "No puede eliminar el registro hasta que se confirme el cambio", "Tabla", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    Tables tables = new Tables();
                    int Id;
                    bool IsParsableId;
                    IsParsableId = Int32.TryParse(txtId.Text, out Id);
                    if (IsParsableId)
                    {
                        DialogResult result;
                        if (cbLang.Text == "FR")
                            result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir supprimer cet enregistrement?", "Table", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else if (cbLang.Text == "EN")
                            result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "Table", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else
                            result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Tabla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            tables.Delete(Id);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Camion supprimé avec succès", "Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Truck deleted successfully", "Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Camión eliminado", "Tabla", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void TablesDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vg_Mode == "Edit")
            {
                if (pbUpdating.Visible)
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Vous ne pouvez pas fermer la fenetre tant que la modification n'est pas validée", "Table", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "You can't close this window before the update is completed", "Table", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        Custom_MessageBox.Show("ES", "No puede cerrar la página hasta que se valide el cambio", "Tabla", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                language_Manager.ChangeLanguage("fr", this, typeof(TablesDetail));
                //Localize_DgvChauffeurs("fr");
                //Localize_DgvTransporteurs("fr");

            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(TablesDetail));
                //Localize_DgvChauffeurs("en");
                //Localize_DgvTransporteurs("en");
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(TablesDetail));
                //Localize_DgvChauffeurs("es");
                //Localize_DgvTransporteurs("es");
            }
        }

        
    }
}
