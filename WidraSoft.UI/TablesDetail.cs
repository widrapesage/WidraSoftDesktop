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
            Bind_DgvTablesTraduction();
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = MenuGeneral.languuage_index;
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
            Enregistrements Enregistrements = new Enregistrements();
            if (txtId.Text == "")
            {
                dgvEnregistrements.DataSource = Enregistrements.FindByTableId(-1);
            }
            else
            {
                int Id;
                bool IsParsableId;
                IsParsableId = Int32.TryParse(txtId.Text, out Id);
                dgvEnregistrements.DataSource = Enregistrements.FindByTableId(Id);
            }

            dgvEnregistrements.Columns[0].Visible = false;
            dgvEnregistrements.Columns["TABLESID"].Visible = false;
            dgvEnregistrements.Columns["NOM"].Visible = true;
            dgvEnregistrements.Columns["ADRESSE"].Visible = false;
            dgvEnregistrements.Columns["CODEPOSTAL"].Visible = false;
            dgvEnregistrements.Columns["LOCALITE"].Visible = false;
            dgvEnregistrements.Columns["PAYS"].Visible = false;
            dgvEnregistrements.Columns["TELEPHONE"].Visible = false;
            dgvEnregistrements.Columns["EMAIL"].Visible = false;
            dgvEnregistrements.Columns["NUMTVA"].Visible = false;
            dgvEnregistrements.Columns["SITEWEB_URL"].Visible = false;
            dgvEnregistrements.Columns["OBSERVATIONS"].Visible = false;
            dgvEnregistrements.Columns["BLOQUE"].Visible = false;
            dgvEnregistrements.Columns["TEXTEBLOQUE"].Visible = false;
            dgvEnregistrements.Columns["ATTENTION"].Visible = false;
            dgvEnregistrements.Columns["TEXTEATTENTION"].Visible = false;
            dgvEnregistrements.Columns["PARENTID"].Visible = false;
            dgvEnregistrements.Columns["DATECREATION"].Visible = true;

            dgvEnregistrements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEnregistrements.ReadOnly = true;

        }

        private void Localize_DgvEnregistrements(string lang)
        {
            if (lang == "fr")
            {
                dgvEnregistrements.Columns["NOM"].HeaderText = "ENREGISTREMENT";
                dgvEnregistrements.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            }

            if (lang == "en")
            {
                dgvEnregistrements.Columns["NOM"].HeaderText = "RECORD";
                dgvEnregistrements.Columns["DATECREATION"].HeaderText = "CREATION DATE";
            }

            if (lang == "es")
            {
                dgvEnregistrements.Columns["NOM"].HeaderText = "REGISTRO";
                dgvEnregistrements.Columns["DATECREATION"].HeaderText = "FECHA DE CREACIÓN";
            }
        }

        private void Refresh_DgvTransporteurs()
        {
            int Id;
            bool IsParsableId;
            Enregistrements Enregistrements = new Enregistrements();
            IsParsableId = Int32.TryParse(txtId.Text, out Id);
            dgvEnregistrements.DataSource = Enregistrements.FindByTableId(Id);
        }

        private void Bind_DgvTablesTraduction()
        {
            TablesTraduction tablesTraduction = new TablesTraduction();
            if (txtId.Text == "")
            {
                dgvTraductions.DataSource = tablesTraduction.FindByTableId(-1);
            }
            else
            {
                int Id;
                bool IsParsableId;
                IsParsableId = Int32.TryParse(txtId.Text, out Id);
                dgvTraductions.DataSource = tablesTraduction.FindByTableId(Id);
            }

            dgvTraductions.Columns[0].Visible = false;
            dgvTraductions.Columns["TABLESID"].Visible = false;
            dgvTraductions.Columns["CODE_LANG"].Visible = true;
            dgvTraductions.Columns["VALUE"].Visible = true;

            dgvTraductions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTraductions.ReadOnly = true;

        }

        private void Refresh_DgvTablesTraduction()
        {
            int Id;
            bool IsParsableId;
            TablesTraduction tablesTraduction= new TablesTraduction();
            IsParsableId = Int32.TryParse(txtId.Text, out Id);
            dgvTraductions.DataSource = tablesTraduction.FindByTableId(Id);
        }

        private void Localize_DgvTablesTraduction(string lang)
        {
            if (lang == "fr")
            {
                dgvTraductions.Columns["CODE_LANG"].HeaderText = "LANGUE";
                dgvTraductions.Columns["VALUE"].HeaderText = "TRADUCTION";
            }

            if (lang == "en")
            {
                dgvTraductions.Columns["CODE_LANG"].HeaderText = "LANGUAGE";
                dgvTraductions.Columns["VALUE"].HeaderText = "TRANSLATION";
            }

            if (lang == "es")
            {
                dgvTraductions.Columns["CODE_LANG"].HeaderText = "IDIOMA";
                dgvTraductions.Columns["VALUE"].HeaderText = "TRADUCCIÓN";
            }
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
                Localize_DgvEnregistrements("fr");
                Localize_DgvTablesTraduction("fr");

            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(TablesDetail));
                Localize_DgvEnregistrements("en");
                Localize_DgvTablesTraduction("en");
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(TablesDetail));
                Localize_DgvEnregistrements("es");
                Localize_DgvTablesTraduction("es");
            }
        }

        private void lblAddDgvChauffeurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            if (txtId.Text != "")
            {
                Int32 Id;
                bool IsParsableId = Int32.TryParse(txtId.Text, out Id);
                if (IsParsableId)
                {
                    if (Id > 0)
                    {
                        Form form = new EnregistrementsDetail("Add", 0, Id);
                        form.Show();
                    }                    
                }              
            }
              
        }

        private void lblRetirerDgvChauffeurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Int32[] selectedIds = new Int32[Common_functions.GetDatagridViewSelectedRowsId(dgvEnregistrements).Length];
            selectedIds = Common_functions.GetDatagridViewSelectedRowsId(dgvEnregistrements);
            if (Common_functions.GetDatagridViewSelectedRowsId(dgvEnregistrements).Length > 0)
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "Etes vous sur ?", "Supprimer enregistrement(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure ?", "Delete record(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro?", "Eliminar registro(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < Common_functions.GetDatagridViewSelectedRowsId(dgvEnregistrements).Length; i++)
                    {
                        try
                        {
                            Enregistrements enregistrements = new Enregistrements();
                            enregistrements.Delete(selectedIds[i]);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", Common_functions.GetDatagridViewSelectedRowsId(dgvEnregistrements).Length + " enregistrement(s) supprimé(s)", "Enregistrements", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", Common_functions.GetDatagridViewSelectedRowsId(dgvEnregistrements).Length + " record(s) deleted", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES", Common_functions.GetDatagridViewSelectedRowsId(dgvEnregistrements).Length + " Registro(s) eliminado(s)", "Registros", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Refresh_DgvTransporteurs();
                }
                
            }
            else
            {

                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Aucun enregistrement sélectionné", "Enregistrements", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "No rows selected", "Records", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Registros", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void lbActualiserDgvTransporteurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Refresh_DgvTablesTraduction();
        }

        private void lblAddDgvTransporteurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Form form = new TableTraductionAdd(vg_Id);
                form.Show();
            }
            catch { throw; }
        }
    }
}
