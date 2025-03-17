using CustomMessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WidraSoft.BL;

namespace WidraSoft.UI
{
    public partial class WalterreDetail : Form
    {
        String vg_Mode = "";
        Int32 vg_Id = 0;
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;
        public WalterreDetail(String Mode, Int32 Id)
        {
            InitializeComponent();
            vg_Mode = Mode;
            vg_Id = Id;
        }

        private void WalterreDetail_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            Client client = new Client();
            cbClientId.DataSource = client.List("1=1");
            cbClientId.DisplayMember = "DESIGNATION";
            cbClientId.ValueMember = "CLIENTID";

            Produit produit = new Produit();
            cbProduitId.DataSource = produit.List("1=1");
            cbProduitId.DisplayMember = "DESIGNATION";
            cbProduitId.ValueMember = "PRODUITID";

            cbRegion.DataSource = Values.Regions_Belgique_Walterre;
            cbRegion.ValueMember = null;
            cbRegion.DisplayMember = Values.Regions_Belgique_Walterre[0].ToString();

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



            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = MenuGeneral.languuage_index;
        }

        private void Add_Item()
        {
            if (txtId.Text == "" && txtDateCreation.Text == "" && txtCode.Text == "" && cbClientId.Text == "" && cbProduitId.Text == "" && cbRegion.Text == "" && txtVolume.Text == "" &&
                txtSeuilMax.Text == "" && txtCloture.Text == "" && txtDateCloture.Text == "" && txtDepassement.Text == "" && txtBorne.Text == "" && txtObservations.Text == "" && txtStatus.Text == "")
            {
                lbModifier.Enabled = false;
                lbModifier.BackColor = Color.Transparent;
                lbSupprimer.Enabled = false;
                lbSupprimer.BackColor = Color.Transparent;

                txtCloture.Text = "0";
                chx_Cloture.Checked = false;

                txtDepassement.Text = "0";
                chx_Depassement.Checked = false;

                txtStatus.Text = "Pending";

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
            Walterre walterre = new Walterre();
            dt = walterre.FindById(vg_Id);
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["WALTERREID"];
                txtId.Text = Id.ToString();
                txtDateCreation.Text = row["DATECREATION"].ToString();
                txtCode.Text = row["CODE"].ToString();
                if (row["PRODUITID"] is System.DBNull)
                    cbProduitId.SelectedValue = 0;
                else
                    cbProduitId.SelectedValue = (int)row["PRODUITID"];
                if (row["CLIENTID"] is System.DBNull)
                    cbClientId.SelectedValue = 0;
                else
                    cbClientId.SelectedValue = (int)row["CLIENTID"];
                txtVolume.Text = row["VOLUME"].ToString();
                txtSeuilMax.Text = row["SEUIL_MAX"].ToString();
                txtCloture.Text = row["CLOTURE"].ToString();
                if (txtCloture.Text == "1")
                    chx_Cloture.Checked = true;
                else
                    chx_Cloture.Checked = false;
                if (row["REGION"] is System.DBNull)
                    cbRegion.Text = "";
                else
                    cbRegion.Text = row["REGION"].ToString();
                txtDepassement.Text = row["DEPASSEMENT"].ToString();
                if (txtDepassement.Text == "1")
                    chx_Depassement.Checked = true;
                else
                    chx_Depassement.Checked = false;
                txtDateCloture.Text = row["DATECLOTURE"].ToString();
                txtObservations.Text = row["OBSERVATIONS"].ToString();
                txtBorne.Text = row["TEXTE_BORNE"].ToString();
                txtStatus.Text = row["STATUS"].ToString();
                if (txtStatus.Text == "Pending")
                {
                    txtStatus.ForeColor = Color.OrangeRed;
                    txtVolume.Enabled = false;
                    txtSeuilMax.Enabled = false;
                }

                else
                {
                    txtStatus.ForeColor = Color.FromArgb(11, 228, 132);

                }
                    
            }
        }
        private void Disable()
        {
            txtDateCreation.Enabled = false;
            txtCode.Enabled = false;
            cbClientId.Enabled = false;
            cbProduitId.Enabled = false;
            cbRegion.Enabled = false;
            txtVolume.Enabled = false;
            txtSeuilMax.Enabled = false;
            chx_Cloture.Enabled = false;
            chx_Depassement.Enabled = false;
            txtBorne.Enabled = false;
            txtObservations.Enabled = false;
            pbUpdating.Visible = false;

            vg_IsEnabled = false;
        }

        private void Enable()
        {
            txtDateCreation.Enabled = true;
            txtCode.Enabled = true;
            cbClientId.Enabled = true;
            cbProduitId.Enabled = true;
            cbRegion.Enabled = true;
            txtVolume.Enabled = true;
            txtSeuilMax.Enabled = true;
            chx_Cloture.Enabled = true;
            chx_Depassement.Enabled = true;
            txtBorne.Enabled = true;
            txtObservations.Enabled = true;
            pbUpdating.Visible = true;

            vg_IsEnabled = true;
        }

        private void Clear()
        {
            txtId.Text = "";
            txtDateCreation.Text = "";
            txtCode.Text = "";
            cbClientId.Text = "";
            cbProduitId.Text = "";
            cbRegion.Text = "";
            txtVolume.Text = "";
            txtSeuilMax.Text = "";
            txtCloture.Text = "";
            chx_Cloture.Checked = false;
            txtDepassement.Text = "";
            chx_Depassement.Checked = false;
            txtDateCloture.Text = "";
            txtBorne.Text = "";
            txtObservations.Text = "";
            txtStatus.Text = "";

        }

        private void chx_Cloture_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Cloture.Checked)
            {
                txtCloture.Text = "1";
                txtStatus.Text = "Closed";
                if (txtDateCloture.Text == "")
                    txtDateCloture.Text = DateTime.Now.ToString();
            }

            else
            {
                txtCloture.Text = "0";
                txtStatus.Text = "Pending";
                if (txtDateCloture.Text != "")
                    txtDateCloture.Text = "";
            }

            if (txtStatus.Text == "Pending")
            {
                txtStatus.ForeColor = Color.OrangeRed;
                txtVolume.Enabled = false;
                txtSeuilMax.Enabled = false;
            }

            else
            {
                txtStatus.ForeColor = Color.FromArgb(11, 228, 132);

            }
        }

        private void chx_Depassement_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Depassement.Checked)
                txtDepassement.Text = "1";
            else
                txtDepassement.Text = "0";
        }

        private void lbAjouter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtId.Text == "" && txtDateCreation.Text == "" && txtCode.Text != ""  && txtVolume.Text != "" && txtSeuilMax.Text != ""
                    && txtCloture.Text != "" && txtDepassement.Text != "")
                {
                    int Cloture;
                    int Depassement;
                    Decimal Volume;
                    Decimal Seuil_Max;
                    SqlDateTime DateCloture;
                    DateTime DateCloture2;
                    bool IsParsableCloture;
                    bool IsParsableDepassement;
                    bool IsParsableVolume;
                    bool IsParsableSeuil_Max;
                    bool IsParsableDateCloture;
                    IsParsableCloture = Int32.TryParse(txtCloture.Text, out Cloture);
                    IsParsableDepassement = Int32.TryParse(txtDepassement.Text, out Depassement);
                    IsParsableVolume = Decimal.TryParse(txtVolume.Text, out Volume);
                    IsParsableSeuil_Max = Decimal.TryParse(txtSeuilMax.Text, out Seuil_Max);
                    //IsParsableDateCloture = SqlDateTime.TryParse(txtDateCloture.Text, out DateCloture);
                    if (txtDateCloture.Text == "")
                        DateCloture = SqlDateTime.Null;
                    else
                    {
                        DateTime.TryParse(txtDateCloture.Text, out DateCloture2);
                        DateCloture = (SqlDateTime) DateCloture2;
                    }
                    
                    try
                    {
                        if ( IsParsableCloture && IsParsableDepassement && IsParsableVolume && IsParsableSeuil_Max)
                        {
                            if (Cloture == 1)
                            {
                                if (cbLang.Text == "FR")
                                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas clôturer un contrat qui vien d'être créé", "Walterre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else if (cbLang.Text == "EN")
                                    Custom_MessageBox.Show("EN", "Ypu can not close a contract that has just been created", "Walterre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                    Custom_MessageBox.Show("ES", "Información incompleta", "Puente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                Walterre walterre = new Walterre();
                                walterre.Add(txtCode.Text, Common_functions.CbSelectedValue_Convert_Int(cbProduitId), Common_functions.CbSelectedValue_Convert_Int(cbClientId), Volume, Seuil_Max, cbRegion.Text, txtBorne.Text,
                                     txtObservations.Text, Depassement, Cloture, DateCloture, txtStatus.Text);
                                if (cbLang.Text == "FR")
                                    Custom_MessageBox.Show("FR", "Contrat Walterre ajouté avec succès", "Walterre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else if (cbLang.Text == "EN")
                                    Custom_MessageBox.Show("EN", "Walterre Contract added successfully", "Walterre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    Custom_MessageBox.Show("ES", "Puente agregado", "Puente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                            }
                            
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
                        Custom_MessageBox.Show("FR", "Informations incomplètes", "Walterre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "Incomplete informations", "Walterre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        Custom_MessageBox.Show("ES", "Información incompleta", "Puente", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (txtStatus.Text == "Pending")
                    {
                        txtStatus.ForeColor = Color.OrangeRed;
                        txtVolume.Enabled = false;
                        txtSeuilMax.Enabled = false;
                    }

                    else
                    {
                        txtStatus.ForeColor = Color.FromArgb(11, 228, 132);

                    }
                    lbModifier.Text = Language_Manager.Localize("Valider", cbLang.Text);
                    vg_Update = true;
                }
                else
                {
                    try
                    {
                        if (txtId.Text != "" && txtDateCreation.Text != "" && txtCode.Text != ""  && txtVolume.Text != "" && txtSeuilMax.Text != ""
                             && txtCloture.Text != "" && txtDepassement.Text != "")
                        {
                            int Id;
                            int Cloture;
                            int Depassement;
                            Decimal Volume;
                            Decimal Seuil_Max;
                            SqlDateTime DateCloture;
                            DateTime DateCloture2;
                            bool IsParsableId;
                            bool IsParsableCloture;
                            bool IsParsableDepassement;
                            bool IsParsableVolume;
                            bool IsParsableSeuil_Max;
                            bool IsParsableDateCloture;
                            IsParsableId = Int32.TryParse(txtId.Text, out Id);
                            IsParsableCloture = Int32.TryParse(txtCloture.Text, out Cloture);
                            IsParsableDepassement = Int32.TryParse(txtDepassement.Text, out Depassement);
                            IsParsableVolume = Decimal.TryParse(txtVolume.Text, out Volume);
                            IsParsableSeuil_Max = Decimal.TryParse(txtSeuilMax.Text, out Seuil_Max);
                            //IsParsableDateCloture = SqlDateTime.TryParse(txtDateCloture.Text, out DateCloture);
                            if (txtDateCloture.Text == "")
                                DateCloture = SqlDateTime.Null;
                            else
                            {
                                DateTime.TryParse(txtDateCloture.Text, out DateCloture2);
                                DateCloture = (SqlDateTime)DateCloture2;
                            }
                            try
                            {
                                if (IsParsableId && IsParsableCloture && IsParsableDepassement && IsParsableVolume && IsParsableSeuil_Max)
                                {
                                    Walterre walterre = new Walterre();
                                    walterre.Update(Id, txtCode.Text, Common_functions.CbSelectedValue_Convert_Int(cbProduitId), Common_functions.CbSelectedValue_Convert_Int(cbClientId), Volume, Seuil_Max, cbRegion.Text, txtBorne.Text,
                                 txtObservations.Text, Depassement, Cloture, DateCloture, txtStatus.Text);
                                    if (cbLang.Text == "FR")
                                        Custom_MessageBox.Show("FR", "Contrat Walterre modifié avec succès", "Walterre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else if (cbLang.Text == "EN")
                                        Custom_MessageBox.Show("EN", "Walterre contract updated successfully", "Walterre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                        Custom_MessageBox.Show("ES", "Puente alterado", "Puente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                Custom_MessageBox.Show("FR", "Informations incomplètes", "Walterre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Incomplete informations", "Walterre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                Custom_MessageBox.Show("ES", "Información incompleta", "Puente", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas supprimer l'enregistrement tant que la modification n'est pas validée", "Walterre", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You can't delete this record before the update is completed", "Walterre", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    Custom_MessageBox.Show("ES", "No puede eliminar el registro hasta que se confirme el cambio", "Puente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Walterre walterre = new Walterre();
                    int Id;
                    bool IsParsableId;
                    IsParsableId = Int32.TryParse(txtId.Text, out Id);
                    if (IsParsableId)
                    {
                        DialogResult result;
                        if (cbLang.Text == "FR")
                            result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir supprimer cet enregistrement?", "Walterre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else if (cbLang.Text == "EN")
                            result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "Walterre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else
                            result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Puente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            walterre.Delete(Id);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Contrat Walterre supprimé avec succès", "Pont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Walterre Contract deleted successfully", "Weighbridge", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Puente eliminado", "Puente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void WalterreDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vg_Mode == "Edit")
            {
                if (pbUpdating.Visible)
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Vous ne pouvez pas fermer la fenetre tant que la modification n'est pas validée", "Walterre", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "You can't close this window before the update is completed", "Walterre", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        Custom_MessageBox.Show("ES", "No puede cerrar la página hasta que se valide el cambio", "Puente", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                language_Manager.ChangeLanguage("fr", this, typeof(WalterreDetail));

            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                //language_Manager.ChangeLanguage("en", this, typeof(WalterreDetail));
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                //language_Manager.ChangeLanguage("es", this, typeof(WalterreDetail));
            }
        }
    }
}
