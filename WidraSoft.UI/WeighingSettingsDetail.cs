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
    public partial class WeighingSettingsDetail : Form
    {
        String vg_Mode = "";
        Int32 vg_Id = 0;
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;
        public WeighingSettingsDetail(String Mode, Int32 Id)
        {
            InitializeComponent();
            vg_Mode = Mode;
            vg_Id = Id;
        }

        private void WeighingSettingsDetail_Load(object sender, EventArgs e)
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

            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = 0;
        }

        private void Add_Item()
        {
            if (txtId.Text == "" && txtDateCreation.Text == "" && txtDesignation.Text == "" && txtCamion.Text == "" && txtChauffeur.Text == "" && txtTransporteur.Text == ""
                && txtProduit.Text == "" && txtClient.Text == "" && txtDestination.Text == "" && txtProvenance.Text == "")
            {
                lbModifier.Enabled = false;
                lbModifier.BackColor = Color.Transparent;
                lbSupprimer.Enabled = false;
                lbSupprimer.BackColor = Color.Transparent;
                
                txtCamion.Text = "1";
                chx_Camion.Checked = true;
                txtChauffeur.Text = "1";
                chx_Chauffeur.Checked = true;
                txtTransporteur.Text = "1";
                chx_Transporteur.Checked = true;
                txtProduit.Text = "1";
                chx_Produit.Checked = true;
                txtClient.Text = "1";
                chx_Client.Checked = true;
                txtDestination.Text = "1";
                chx_Destination.Checked = true;
                txtProvenance.Text = "1";
                chx_Provenance.Checked = true;

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
            WeighingSettings weighingSettings = new WeighingSettings();
            dt = weighingSettings.FindById(vg_Id);
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["WEIGHING_SETTINGSID"];
                txtId.Text = Id.ToString();
                txtDateCreation.Text = row["DATECREATION"].ToString();
                txtDesignation.Text = row["DESIGNATION"].ToString();                
                txtCamion.Text = row["CAMION"].ToString();
                if (txtCamion.Text == "1")
                    chx_Camion.Checked = true;
                else
                    chx_Camion.Checked = false;
                txtChauffeur.Text = row["CHAUFFEUR"].ToString();
                if (txtChauffeur.Text == "1")
                    chx_Chauffeur.Checked = true;
                else
                    chx_Chauffeur.Checked = false;
                txtTransporteur.Text = row["TRANSPORTEUR"].ToString();
                if (txtTransporteur.Text == "1")
                    chx_Transporteur.Checked = true;
                else
                    chx_Transporteur.Checked = false;
                txtProduit.Text = row["PRODUIT"].ToString();
                if (txtProduit.Text == "1")
                    chx_Produit.Checked = true;
                else
                    chx_Produit.Checked = false;
                txtClient.Text = row["CLIENT"].ToString();
                if (txtClient.Text == "1")
                    chx_Client.Checked = true;
                else
                    chx_Client.Checked = false;
                txtDestination.Text = row["DESTINATION"].ToString();
                if (txtDestination.Text == "1")
                    chx_Destination.Checked = true;
                else
                    chx_Destination.Checked = false;
                txtProvenance.Text = row["PROVENANCE"].ToString();
                if (txtProvenance.Text == "1")
                    chx_Provenance.Checked = true;
                else
                    chx_Provenance.Checked = false;

            }
        }

        private void Disable()
        {
            txtDateCreation.Enabled = false;
            txtDesignation.Enabled = false;
            chx_Camion.Enabled = false;
            chx_Chauffeur.Enabled = false;
            chx_Transporteur.Enabled = false;
            chx_Produit.Enabled = false;
            chx_Client.Enabled = false;
            chx_Destination.Enabled = false;
            chx_Provenance.Enabled = false;            
            pbUpdating.Visible = false;

            vg_IsEnabled = false;
        }

        private void Enable()
        {
            txtDateCreation.Enabled = true;
            txtDesignation.Enabled = true;
            chx_Camion.Enabled = true;
            chx_Chauffeur.Enabled = true;
            chx_Transporteur.Enabled = true;
            chx_Produit.Enabled = true;
            chx_Client.Enabled = true;
            chx_Destination.Enabled = true;
            chx_Provenance.Enabled = true;
            pbUpdating.Visible = true;

            vg_IsEnabled = true;
        }

        private void Clear()
        {
            txtId.Text = "";
            txtDateCreation.Text = "";
            txtDesignation.Text = "";
            chx_Camion.Checked = false;
            chx_Chauffeur.Checked = false;
            chx_Transporteur.Checked = false;
            chx_Produit.Checked = false;
            chx_Client.Checked = false;
            chx_Destination.Checked = false;
            chx_Provenance.Checked = false;
        }

        private void chx_Camion_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Camion.Checked)
                txtCamion.Text = "1";
            else
                txtCamion.Text = "0";
        }

        private void chx_Chauffeur_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Chauffeur.Checked)
                txtChauffeur.Text = "1";
            else
                txtChauffeur.Text = "0";
        }

        private void chx_Transporteur_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Transporteur.Checked)
                txtTransporteur.Text = "1";
            else
                txtTransporteur.Text = "0";
        }

        private void chx_Produit_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Produit.Checked)
                txtProduit.Text = "1";
            else
                txtProduit.Text = "0";
        }

        private void chx_Client_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Client.Checked)
                txtClient.Text = "1";
            else
                txtClient.Text = "0";
        }

        private void chx_Destination_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Destination.Checked)
                txtDestination.Text = "1";
            else
                txtDestination.Text = "0";
        }

        private void chx_Provenance_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Provenance.Checked)
                txtProvenance.Text = "1";
            else
                txtProvenance.Text = "0";
        }

        private void lbAjouter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtId.Text == "" && txtDateCreation.Text == "" && txtDesignation.Text != "" && txtCamion.Text != "" && txtChauffeur.Text != "" && txtTransporteur.Text != ""
                    && txtProduit.Text != "" && txtClient.Text != ""  && txtDestination.Text != "" && txtProvenance.Text != "")
                {
                    int Camion;
                    int Chauffeur;
                    int Transporteur;
                    int Produit;
                    int Client;
                    int Destination;
                    int Provenance;
                    bool IsParsableCamion;
                    bool IsParsableChauffeur;
                    bool IsParsableTransporteur;
                    bool IsParsableProduit;
                    bool IsParsableClient;
                    bool IsParsableDestination;
                    bool IsParsableProvenance;
                    IsParsableCamion = Int32.TryParse(txtCamion.Text, out Camion);
                    IsParsableChauffeur = Int32.TryParse(txtChauffeur.Text, out Chauffeur);
                    IsParsableTransporteur = Int32.TryParse(txtTransporteur.Text, out Transporteur);
                    IsParsableProduit = Int32.TryParse(txtProduit.Text, out Produit);
                    IsParsableClient = Int32.TryParse(txtClient.Text, out Client);
                    IsParsableDestination = Int32.TryParse(txtDestination.Text, out Destination);
                    IsParsableProvenance = Int32.TryParse(txtProvenance.Text, out Provenance);
                    try
                    {
                        if (IsParsableCamion && IsParsableChauffeur && IsParsableTransporteur && IsParsableProduit && IsParsableClient && IsParsableDestination && IsParsableProvenance)
                        {
                            WeighingSettings weighingSettings = new WeighingSettings();
                            weighingSettings.Add(txtDesignation.Text, Camion, Chauffeur, Transporteur, Produit, Client, Destination, Provenance);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Paramètre ajouté avec succès", "Paramètre de pesée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Setting added successfully", "Weighing setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Parámetro agregado", "Parámetro de pesaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        Custom_MessageBox.Show("FR", "Informations incomplètes", "Paramètre de pesée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "Incomplete informations", "Weighing setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES", "Información incompleta", "Parámetro de pesaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (txtId.Text != "" && txtDateCreation.Text != "" && txtDesignation.Text != "" && txtCamion.Text != "" && txtChauffeur.Text != "" && txtTransporteur.Text != ""
                            && txtProduit.Text != "" && txtClient.Text != "" && txtDestination.Text != "" && txtProvenance.Text != "")
                        {
                            
                            int Id;
                            int Camion;
                            int Chauffeur;
                            int Transporteur;
                            int Produit;
                            int Client;
                            int Destination;
                            int Provenance;
                            bool IsParsableId;
                            bool IsParsableCamion;
                            bool IsParsableChauffeur;
                            bool IsParsableTransporteur;
                            bool IsParsableProduit;
                            bool IsParsableClient;
                            bool IsParsableDestination;
                            bool IsParsableProvenance;
                            IsParsableId = Int32.TryParse(txtId.Text, out Id);
                            IsParsableCamion = Int32.TryParse(txtCamion.Text, out Camion);
                            IsParsableChauffeur = Int32.TryParse(txtChauffeur.Text, out Chauffeur);
                            IsParsableTransporteur = Int32.TryParse(txtTransporteur.Text, out Transporteur);
                            IsParsableProduit = Int32.TryParse(txtProduit.Text, out Produit);
                            IsParsableClient = Int32.TryParse(txtClient.Text, out Client);
                            IsParsableDestination = Int32.TryParse(txtDestination.Text, out Destination);
                            IsParsableProvenance = Int32.TryParse(txtProvenance.Text, out Provenance);
                            try
                            {
                                if (IsParsableId && IsParsableCamion && IsParsableChauffeur && IsParsableTransporteur && IsParsableProduit && IsParsableClient && IsParsableDestination && IsParsableProvenance)
                                {
                                    WeighingSettings weighingSettings = new WeighingSettings();
                                    weighingSettings.Update(Id, txtDesignation.Text, Camion, Chauffeur, Transporteur, Produit, Client, Destination, Provenance);
                                    if (cbLang.Text == "FR")
                                        Custom_MessageBox.Show("FR", "Paramètre modifié avec succès", "Paramètre de pesée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else if (cbLang.Text == "EN")
                                        Custom_MessageBox.Show("EN", "Setting updated successfully", "Weighing setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                        Custom_MessageBox.Show("ES", "Parámetro alterado", "Parámetro de pesaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                Custom_MessageBox.Show("FR", "Informations incomplètes", "Paramètre de pesée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Incomplete informations", "Weighing setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Información incompleta", "Parámetro de pesaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas supprimer l'enregistrement tant que la modification n'est pas validée", "Paramètre de pesée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You can't delete this record before the update is completed", "Weighing setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    Custom_MessageBox.Show("ES", "No puede eliminar el registro hasta que se confirme el cambio", "Parámetro de pesaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    WeighingSettings weighingSettings = new WeighingSettings();
                    int Id;
                    bool IsParsableId;
                    IsParsableId = Int32.TryParse(txtId.Text, out Id);
                    if (IsParsableId)
                    {
                        DialogResult result;
                        if (cbLang.Text == "FR")
                            result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir supprimer cet enregistrement?", "Paramètre de pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else if (cbLang.Text == "EN")
                            result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "Weighing setting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else
                            result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Parámetro de pesaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            weighingSettings.Delete(Id);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Paramètre supprimé avec succès", "Paramètre de pesée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Setting deleted successfully", "Weighing setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Parámetro eliminado", "Parámetro de pesaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void WeighingSettingsDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vg_Mode == "Edit")
            {
                if (pbUpdating.Visible)
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Vous ne pouvez pas fermer la fenetre tant que la modification n'est pas validée", "Paramètre de pesée", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "You can't close this window before the update is completed", "Weighing setting", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        Custom_MessageBox.Show("ES", "No puede cerrar la página hasta que se valide el cambio", "Parámetro de pesaje", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                language_Manager.ChangeLanguage("fr", this, typeof(WeighingSettingsDetail));

            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(WeighingSettingsDetail));
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(WeighingSettingsDetail));
            }
        }
    }
}
