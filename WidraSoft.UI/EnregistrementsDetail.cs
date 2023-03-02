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
    public partial class EnregistrementsDetail : Form
    {
        String vg_Mode = "";
        Int32 vg_Id = 0;
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;
        public EnregistrementsDetail(String Mode, Int32 Id)
        {
            InitializeComponent();
            vg_Mode = Mode;
            vg_Id = Id;
        }

        private void EnregistrementsDetail_Load(object sender, EventArgs e)
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
            if (txtId.Text == "" && txtDateCreation.Text == ""  && txtNom.Text == "" && txtAdresse.Text == "" && txtCodePostal.Text == "" && txtLocalite.Text == ""
                && txtPays.Text == "" && txtTelephone.Text == "" && txtEmail.Text == "" && txtNumTVA.Text == "" && txtSiteWebUrl.Text == ""
                &&  txtBloque.Text == "" && txtBlocage.Text == "" && txtAttention.Text == "" && txtAlerte.Text == "" && txtObservations.Text == "")
            {
                lbModifier.Enabled = false;
                lbModifier.BackColor = Color.Transparent;
                lbSupprimer.Enabled = false;
                lbSupprimer.BackColor = Color.Transparent;
                
                txtBloque.Text = "0";
                chx_Bloque.Checked = false;
                txtAttention.Text = "0";
                chx_Attention.Checked = false;

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
            Enregistrements enregistrements = new Enregistrements();
            dt = enregistrements.FindById(vg_Id);
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["ENREGISTREMENTSID"];
                txtId.Text = Id.ToString();
                txtDateCreation.Text = row["DATECREATION"].ToString();
                txtNom.Text = row["NOM"].ToString();
                txtAdresse.Text = row["ADRESSE"].ToString();
                txtCodePostal.Text = row["CODEPOSTAL"].ToString();
                txtLocalite.Text = row["LOCALITE"].ToString();
                txtPays.Text = row["PAYS"].ToString();
                txtTelephone.Text = row["TELEPHONE"].ToString();
                txtEmail.Text = row["EMAIL"].ToString();
                txtNumTVA.Text = row["NUMTVA"].ToString();
                txtSiteWebUrl.Text = row["SITEWEB_URL"].ToString();
                txtObservations.Text = row["OBSERVATIONS"].ToString();
                txtBloque.Text = row["BLOQUE"].ToString();
                if (txtBloque.Text == "1")
                    chx_Bloque.Checked = true;
                else
                    chx_Bloque.Checked = false;
                txtBlocage.Text = row["TEXTEBLOQUE"].ToString();
                txtAttention.Text = row["ATTENTION"].ToString();
                if (txtAttention.Text == "1")
                    chx_Attention.Checked = true;
                else
                    chx_Attention.Checked = false;
                txtAlerte.Text = row["TEXTEATTENTION"].ToString();
            }
        }

        private void Bind_DgvEnregistrements()
        {
            TablesEnregistrements tablesEnregistrements = new TablesEnregistrements();
            if (txtId.Text == "")
            {
                dgvEnregistrements.DataSource = tablesEnregistrements.FindByEnregistrementsId(-1);
            }
            else
            {
                int Id;
                bool IsParsableId;
                IsParsableId = Int32.TryParse(txtId.Text, out Id);
                dgvEnregistrements.DataSource = tablesEnregistrements.FindByEnregistrementsId(Id);
            }

            dgvEnregistrements.Columns[0].Visible = false;
            dgvEnregistrements.Columns["TABLES"].Visible = true;
            dgvEnregistrements.Columns["ENREGISTREMENTSID"].Visible = false;
            dgvEnregistrements.Columns["ENREGISTREMENT"].Visible = false;
            dgvEnregistrements.Columns["DATECREATION"].Visible = false;

            dgvEnregistrements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEnregistrements.ReadOnly = true;

        }

        private void Localize_DgvEnregistrements(string lang)
        {
            if (lang == "fr")
            {
                dgvEnregistrements.Columns["TABLES"].HeaderText = "TABLES";
                dgvEnregistrements.Columns["ENREGISTREMENT"].HeaderText = "ENREGISTREMENTS";
                dgvEnregistrements.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            }

            if (lang == "en")
            {
                dgvEnregistrements.Columns["TABLES"].HeaderText = "TABLES";
                dgvEnregistrements.Columns["ENREGISTREMENT"].HeaderText = "RECORDS";
                dgvEnregistrements.Columns["DATECREATION"].HeaderText = "CREATION DATE";
            }

            if (lang == "es")
            {
                dgvEnregistrements.Columns["TABLES"].HeaderText = "TABLAS";
                dgvEnregistrements.Columns["ENREGISTREMENT"].HeaderText = "REGISTROS";
                dgvEnregistrements.Columns["DATECREATION"].HeaderText = "FECHA DE CREACIÓN";
            }
        }

        private void Refresh_DgvEnregistrements()
        {
            int Id;
            bool IsParsableId;
            TablesEnregistrements tablesEnregistrements = new TablesEnregistrements();
            IsParsableId = Int32.TryParse(txtId.Text, out Id);
            dgvEnregistrements.DataSource = tablesEnregistrements.FindByEnregistrementsId(Id);
        }

        private void Disable()
        {
            txtDateCreation.Enabled = false;
            txtNom.Enabled = false;
            txtAdresse.Enabled = false;
            txtCodePostal.Enabled = false;
            txtLocalite.Enabled = false;
            txtPays.Enabled = false;
            txtTelephone.Enabled = false;
            txtEmail.Enabled = false;
            txtNumTVA.Enabled = false;
            txtSiteWebUrl.Enabled = false;
            chx_Bloque.Enabled = false;
            txtBlocage.Enabled = false;
            chx_Attention.Enabled = false;
            txtAlerte.Enabled = false;
            txtObservations.Enabled = false;
            dgvEnregistrements.Enabled = false;
            lblAddDgvEnregistrements.Enabled = false;
            lbActualiserDgvEnregistrements.Enabled = false;
            pbUpdating.Visible = false;

            vg_IsEnabled = false;
        }

        private void Enable()
        {
            txtDateCreation.Enabled = true;
            txtNom.Enabled = true;
            txtAdresse.Enabled = true;
            txtCodePostal.Enabled = true;
            txtLocalite.Enabled = true;
            txtPays.Enabled = true;
            txtTelephone.Enabled = true;
            txtEmail.Enabled = true;
            txtNumTVA.Enabled = true;
            txtSiteWebUrl.Enabled = true;
            chx_Bloque.Enabled = true;
            txtBlocage.Enabled = true;
            chx_Attention.Enabled = true;
            txtAlerte.Enabled = true;
            txtObservations.Enabled = true;
            dgvEnregistrements.Enabled = true;
            lblAddDgvEnregistrements.Enabled = true;
            lbActualiserDgvEnregistrements.Enabled = true;
            pbUpdating.Visible = true;

            vg_IsEnabled = true;
        }

        private void Clear()
        {
            txtId.Text = "";
            txtDateCreation.Text = "";
            txtNom.Text = "";
            txtAdresse.Text = "";
            txtCodePostal.Text = "";
            txtLocalite.Text = "";
            txtPays.Text = "";
            txtTelephone.Text = "";
            txtEmail.Text = "";
            txtNumTVA.Text = "";
            txtSiteWebUrl.Text = "";
            txtBlocage.Text = "";
            txtAlerte.Text = "";
            txtObservations.Text = "";
            chx_Bloque.Checked = false;
            chx_Attention.Checked = false;
        }

        private void chx_Bloque_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Bloque.Checked)
                txtBloque.Text = "1";
            else
                txtBloque.Text = "0";
        }

        private void chx_Attention_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Attention.Checked)
                txtAttention.Text = "1";
            else
                txtAttention.Text = "0";
        }

        private void lbAjouter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

                if (txtId.Text == "" && txtDateCreation.Text == "" && txtNom.Text != "" && txtBloque.Text != "" && txtAttention.Text != "")
                {
                    
                    int Bloque;
                    int Attention;
                    bool IsParsableBloque;
                    bool IsParsableAttention;
                    IsParsableBloque = Int32.TryParse(txtBloque.Text, out Bloque);
                    IsParsableAttention = Int32.TryParse(txtAttention.Text, out Attention);
                    try
                    {
                        if (IsParsableBloque && IsParsableAttention)
                        {
                            Enregistrements enregistrements = new Enregistrements();
                            enregistrements.Add(txtNom.Text, txtAdresse.Text, txtCodePostal.Text, txtLocalite.Text, txtPays.Text, txtTelephone.Text, txtEmail.Text,
                                    txtNumTVA.Text, txtSiteWebUrl.Text, txtObservations.Text, Bloque, txtBlocage.Text, Attention, txtAlerte.Text);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Enregistrement ajouté avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Record added successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Registro agregado", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        Custom_MessageBox.Show("FR", "Informations incomplètes", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "Incomplete informations", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES", "Información incompleta", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (txtId.Text != "" && txtDateCreation.Text != "" && txtNom.Text != "" && txtBloque.Text != "" && txtAttention.Text != "")
                        {
                            int Id;
                            int Bloque;
                            int Attention;
                            bool IsParsableId;
                            bool IsParsableBloque;
                            bool IsParsableAttention;
                            IsParsableId = Int32.TryParse(txtId.Text, out Id);
                            IsParsableBloque = Int32.TryParse(txtBloque.Text, out Bloque);
                            IsParsableAttention = Int32.TryParse(txtAttention.Text, out Attention);
                            try
                            {
                                if (IsParsableId &&  IsParsableBloque && IsParsableAttention)
                                {
                                    Enregistrements enregistrements = new Enregistrements();
                                    enregistrements.Update(Id, txtNom.Text, txtAdresse.Text, txtCodePostal.Text, txtLocalite.Text, txtPays.Text, txtTelephone.Text, txtEmail.Text,
                                            txtNumTVA.Text, txtSiteWebUrl.Text, txtObservations.Text, Bloque, txtBlocage.Text, Attention, txtAlerte.Text);
                                    if (cbLang.Text == "FR")
                                        Custom_MessageBox.Show("FR", "Enregistrement modifié avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else if (cbLang.Text == "EN")
                                        Custom_MessageBox.Show("EN", "Record updated successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                        Custom_MessageBox.Show("ES", "Registro alterado", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lbModifier.Text = Language_Manager.Localize("Modifier", cbLang.Text);
                                    vg_Update = false;
                                    Disable();
                                    Bind_Fields();
                                    Bind_DgvEnregistrements();
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
                                Custom_MessageBox.Show("FR", "Informations incomplètes", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Incomplete informations", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Información incompleta", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas supprimer l'enregistrement tant que la modification n'est pas validée", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You can't delete this record before the update is completed", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    Custom_MessageBox.Show("ES", "No puede eliminar el registro hasta que se confirme el cambio", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    Enregistrements enregistrements = new Enregistrements();
                    int Id;
                    bool IsParsableId;
                    IsParsableId = Int32.TryParse(txtId.Text, out Id);
                    if (IsParsableId)
                    {
                        DialogResult result;
                        if (cbLang.Text == "FR")
                            result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir supprimer cet enregistrement?", "Enregistrement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else if (cbLang.Text == "EN")
                            result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else
                            result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            enregistrements.Delete(Id);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Enregistrement supprimé avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Record deleted successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Registro eliminado", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void EnregistrementsDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vg_Mode == "Edit")
            {
                if (pbUpdating.Visible)
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Vous ne pouvez pas fermer la fenetre tant que la modification n'est pas validée", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "You can't close this window before the update is completed", "Record", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        Custom_MessageBox.Show("ES", "No puede cerrar la página hasta que se valide el cambio", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                language_Manager.ChangeLanguage("fr", this, typeof(EnregistrementsDetail));
                Localize_DgvEnregistrements("fr");
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(EnregistrementsDetail));
                Localize_DgvEnregistrements("en");
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(EnregistrementsDetail));
                Localize_DgvEnregistrements("es");
            }
        }

        private void lblAddDgvEnregistrements_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (vg_Id > 0)
                {
                    Form form = new TablesEnregistrementsDetail("Add", vg_Id);
                    form.Show();
                }
                else
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Vous ne pouvez pas ajouter d'enregistrements tant que la modification n'est pas validée", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "You can't add a record before the update is completed", "Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        Custom_MessageBox.Show("ES", "No puede agregar un registro hasta que se confirme el cambio", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                throw;
            }
           
        }

        private void lbActualiserDgvEnregistrements_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Refresh_DgvEnregistrements();
        }
    }
}
