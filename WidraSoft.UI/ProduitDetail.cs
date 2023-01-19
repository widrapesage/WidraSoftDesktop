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
    public partial class ProduitDetail : Form
    {
        String vg_Mode = "";
        Int32 vg_Id = 0;
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;
        public ProduitDetail(String Mode, Int32 Id)
        {
            InitializeComponent();
            vg_Mode = Mode;
            vg_Id = Id;
        }

        private void ProduitDetail_Load(object sender, EventArgs e)
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
            if (txtId.Text == "" && txtDateCreation.Text == "" && txtDesignation.Text == "" && cbGroupeProduitId.Text == "" 
                && txtValide.Text == "" && txtEstEntrant.Text == "" && txtEstSortant.Text == "" && txtActiverAlerteMin.Text == "" 
                && txtActiverAlerteMax.Text == "" && txtPoidsAlerteMin.Text == "" && txtPoidsAlerteMax.Text == "" && txtEmpecherTicketSiAlerte.Text == ""
                && txtDechet.Text == "" && cbTypeDechetId.Text=="")
            {
                lbModifier.Enabled = false;
                lbModifier.BackColor = Color.Transparent;
                lbSupprimer.Enabled = false;
                lbSupprimer.BackColor = Color.Transparent;

                txtValide.Text = "1"; chx_Valide.Checked = true;
                txtEstEntrant.Text = "0"; chx_EstEntrant.Checked = false;
                txtEstSortant.Text = "0"; chx_EstSortant.Checked = false;
                txtActiverAlerteMin.Text = "0"; chx_ActiverAlerteMin.Checked = false;
                txtActiverAlerteMax.Text = "0"; chx_ActiverAlerteMax.Checked = false;
                txtEmpecherTicketSiAlerte.Text = "0"; chx_EmpecherTicketSiAlerte.Checked = false;
                txtDechet.Text = "0"; chx_Dechet.Checked = false;

                txtPoidsAlerteMin.Text = "0";
                txtPoidsAlerteMax.Text = "0";
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
            Produit produit = new Produit();
            dt = produit.FindById(vg_Id);
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["PRODUITID"];
                txtId.Text = Id.ToString();
                txtDateCreation.Text = row["DATECREATION"].ToString();
                txtDesignation.Text = row["DESIGNATION"].ToString();
                if (row["GROUPEPRODUITID"] is System.DBNull)
                    cbGroupeProduitId.SelectedValue = 0;
                else
                    cbGroupeProduitId.SelectedValue = (int)row["GROUPEPRODUITID"];
                txtEstEntrant.Text = row["ESTENTRANT"].ToString();                
                if (txtEstEntrant.Text == "1")
                    chx_EstEntrant.Checked = true;
                else
                    chx_EstEntrant.Checked = false;
                txtEstSortant.Text = row["ESTSORTANT"].ToString();                
                if (txtEstSortant.Text == "1")
                    chx_EstSortant.Checked = true;
                else
                    chx_EstSortant.Checked = false;
                txtValide.Text = row["VALIDE"].ToString();                
                if (txtValide.Text == "1")
                    chx_Valide.Checked = true;
                else
                    chx_Valide.Checked = false;
                txtActiverAlerteMin.Text = row["ACTIVERALERTEMIN"].ToString();                
                if (txtActiverAlerteMin.Text == "1")
                    chx_ActiverAlerteMin.Checked = true;
                else
                    chx_ActiverAlerteMin.Checked = false;
                txtPoidsAlerteMin.Text = row["POIDSALERTEMIN"].ToString();
                txtActiverAlerteMax.Text = row["ACTIVERALERTEMAX"].ToString();                
                if (txtActiverAlerteMax.Text == "1")
                    chx_ActiverAlerteMax.Checked = true;
                else
                    chx_ActiverAlerteMax.Checked = false;
                txtPoidsAlerteMax.Text = row["POIDSALERTEMAX"].ToString();
                txtEmpecherTicketSiAlerte.Text = row["EMPECHERTICKETSIALERTE"].ToString();                
                if (txtEmpecherTicketSiAlerte.Text == "1")
                    chx_EmpecherTicketSiAlerte.Checked = true;
                else
                    chx_EmpecherTicketSiAlerte.Checked = false;
                txtDechet.Text = row["DECHET"].ToString();               
                if (txtDechet.Text == "1")
                    chx_Dechet.Checked = true;
                else
                    chx_Dechet.Checked = false;
                if (row["TYPEDECHETID"] is System.DBNull)
                    cbTypeDechetId.SelectedValue = 0;
                else
                    cbTypeDechetId.SelectedValue = (int)row["TYPEDECHETID"];
            }
        }

        private void Disable()
        {
            txtDateCreation.Enabled = false;
            txtDesignation.Enabled = false;
            cbGroupeProduitId.Enabled = false;
            chx_Valide.Enabled = false;
            chx_EstEntrant.Enabled = false;
            chx_EstSortant.Enabled = false;
            chx_ActiverAlerteMin.Enabled = false;
            chx_ActiverAlerteMax.Enabled = false;
            txtActiverAlerteMin.Enabled = false;
            txtActiverAlerteMax.Enabled = false;
            chx_EmpecherTicketSiAlerte.Enabled = false;
            txtDechet.Enabled = false;
            cbTypeDechetId.Enabled = false;
            pbUpdating.Visible = false;

            vg_IsEnabled = false;
        }
        
        private void Enable()
        {
            txtDateCreation.Enabled = true;
            txtDesignation.Enabled = true;
            cbGroupeProduitId.Enabled = true;
            chx_Valide.Enabled = true;
            chx_EstEntrant.Enabled = true;
            chx_EstSortant.Enabled = true;
            chx_ActiverAlerteMin.Enabled = true;
            chx_ActiverAlerteMax.Enabled = true;
            txtActiverAlerteMin.Enabled = true;
            txtActiverAlerteMax.Enabled = true;
            chx_EmpecherTicketSiAlerte.Enabled = true;
            txtDechet.Enabled = true;
            cbTypeDechetId.Enabled = true;
            pbUpdating.Visible = true;
            

            vg_IsEnabled = true;
        }

        private void Clear()
        {
            txtId.Text = "";
            txtDateCreation.Text = "";
            txtDesignation.Text = "";
            cbGroupeProduitId.Text = "";
            txtPoidsAlerteMin.Text = "";
            txtPoidsAlerteMax.Text = "";
            cbTypeDechetId.Text = "";
            chx_Valide.Checked = false;
            chx_EstEntrant.Checked = false;
            chx_EstSortant.Checked = false;
            chx_ActiverAlerteMin.Checked = false;
            chx_ActiverAlerteMax.Checked = false;
            chx_EmpecherTicketSiAlerte.Checked = false; 
            chx_Dechet.Checked = false;
        }

        private void chx_Valide_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Valide.Checked)
                txtValide.Text = "1";
            else
                txtValide.Text = "0";
        }

        private void chx_EstEntrant_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_EstEntrant.Checked)
                chx_EstEntrant.Text = "1";
            else
                chx_EstEntrant.Text = "0";
        }

        private void chx_EstSortant_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_EstSortant.Checked)
                chx_EstSortant.Text = "1";
            else
                chx_EstSortant.Text = "0";
        }

        private void chx_ActiverAlerteMin_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_ActiverAlerteMin.Checked)
                chx_ActiverAlerteMin.Text = "1";
            else
                chx_ActiverAlerteMin.Text = "0";
        }

        private void chx_ActiverAlerteMax_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_ActiverAlerteMax.Checked)
                chx_ActiverAlerteMax.Text = "1";
            else
                chx_ActiverAlerteMax.Text = "0";
        }

        private void chx_EmpecherTicketSiAlerte_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_EmpecherTicketSiAlerte.Checked)
                chx_EmpecherTicketSiAlerte.Text = "1";
            else
                chx_EmpecherTicketSiAlerte.Text = "0";
        }

        private void chx_Dechet_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Dechet.Checked)
                chx_Dechet.Text = "1";
            else
                chx_Dechet.Text = "0";
        }

        private void lbAjouter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        
        {
            try
            {
                if (txtId.Text == "" && txtDateCreation.Text == "" && txtDesignation.Text != ""  && txtValide.Text != "" 
                    && txtEstEntrant.Text != "" && txtEstSortant.Text != "" && txtActiverAlerteMin.Text != "" &&  txtActiverAlerteMax.Text != "" 
                    && txtEmpecherTicketSiAlerte.Text != "" && txtDechet.Text != "")
                {
                     
                    int Valide;
                    int EstEntrant;
                    int EstSortant;
                    int ActiverAlerteMin;
                    int ActiverAlerteMax;
                    int PoidsAlerteMin;
                    int PoidsAlerteMax;
                    int EmpecherTicketSiAlerte;
                    int Dechet;

                    bool IsParsableValide;
                    bool IsParsableEstEntrant;
                    bool IsParsableEstSortant;
                    bool IsParsableActiverAlerteMin;
                    bool IsParsableActiverAlerteMax;
                    bool IsParsablePoidsAlerteMin;
                    bool IsParsablePoidsAlerteMax;
                    bool IsParsableEmpecherTicketSiAlerte;
                    bool IsParsableDechet;

                    IsParsableValide = Int32.TryParse(txtValide.Text, out Valide);
                    IsParsableEstEntrant = Int32.TryParse(txtEstEntrant.Text, out EstEntrant);
                    IsParsableEstSortant = Int32.TryParse(txtEstSortant.Text, out EstSortant);
                    IsParsableActiverAlerteMin = Int32.TryParse(txtActiverAlerteMin.Text, out ActiverAlerteMin);
                    IsParsableActiverAlerteMax = Int32.TryParse(txtActiverAlerteMax.Text, out ActiverAlerteMax);
                    IsParsablePoidsAlerteMin = Int32.TryParse(txtPoidsAlerteMin.Text, out PoidsAlerteMin);
                    IsParsablePoidsAlerteMax = Int32.TryParse(txtPoidsAlerteMax.Text, out PoidsAlerteMax);
                    IsParsableEmpecherTicketSiAlerte = Int32.TryParse(txtEmpecherTicketSiAlerte.Text, out EmpecherTicketSiAlerte);
                    IsParsableDechet = Int32.TryParse(txtDechet.Text, out Dechet);

                    try
                    {
                        if (IsParsableValide && IsParsableEstEntrant && IsParsableEstSortant && IsParsableActiverAlerteMin && IsParsableActiverAlerteMax
                            && IsParsablePoidsAlerteMin && IsParsablePoidsAlerteMax && IsParsableEmpecherTicketSiAlerte && IsParsableDechet)
                        {
                            Produit produit = new Produit();
                            produit.Add(txtDesignation.Text, Common_functions.CbSelectedValue_Convert_Int(cbGroupeProduitId), EstEntrant, EstSortant, Valide, PoidsAlerteMin, ActiverAlerteMin,
                                PoidsAlerteMax, ActiverAlerteMax, EmpecherTicketSiAlerte, Dechet, Common_functions.CbSelectedValue_Convert_Int(cbTypeDechetId)) ;
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Produit ajouté avec succès", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Product added successfully", "Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Producto agregado", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        Custom_MessageBox.Show("FR", "Informations incomplètes", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "Incomplete informations", "Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES", "Información incompleta", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (txtId.Text != "" && txtDateCreation.Text != "" && txtDesignation.Text != "" && txtValide.Text != ""
                            && txtEstEntrant.Text != "" && txtEstSortant.Text != "" && txtActiverAlerteMin.Text != "" && txtActiverAlerteMax.Text != ""
                            && txtEmpecherTicketSiAlerte.Text != "" && txtDechet.Text != "")
                        {
                            int Id;
                            int Valide;
                            int EstEntrant;
                            int EstSortant;
                            int ActiverAlerteMin;
                            int ActiverAlerteMax;
                            int PoidsAlerteMin;
                            int PoidsAlerteMax;
                            int EmpecherTicketSiAlerte;
                            int Dechet;

                            bool IsParsableId;
                            bool IsParsableValide;
                            bool IsParsableEstEntrant;
                            bool IsParsableEstSortant;
                            bool IsParsableActiverAlerteMin;
                            bool IsParsableActiverAlerteMax;
                            bool IsParsablePoidsAlerteMin;
                            bool IsParsablePoidsAlerteMax;
                            bool IsParsableEmpecherTicketSiAlerte;
                            bool IsParsableDechet;

                            IsParsableId = Int32.TryParse(txtId.Text, out Id);
                            IsParsableValide = Int32.TryParse(txtValide.Text, out Valide);
                            IsParsableEstEntrant = Int32.TryParse(txtEstEntrant.Text, out EstEntrant);
                            IsParsableEstSortant = Int32.TryParse(txtEstSortant.Text, out EstSortant);
                            IsParsableActiverAlerteMin = Int32.TryParse(txtActiverAlerteMin.Text, out ActiverAlerteMin);
                            IsParsableActiverAlerteMax = Int32.TryParse(txtActiverAlerteMax.Text, out ActiverAlerteMax);
                            IsParsablePoidsAlerteMin = Int32.TryParse(txtPoidsAlerteMin.Text, out PoidsAlerteMin);
                            IsParsablePoidsAlerteMax = Int32.TryParse(txtPoidsAlerteMax.Text, out PoidsAlerteMax);
                            IsParsableEmpecherTicketSiAlerte = Int32.TryParse(txtEmpecherTicketSiAlerte.Text, out EmpecherTicketSiAlerte);
                            IsParsableDechet = Int32.TryParse(txtDechet.Text, out Dechet);

                            try
                            {
                                if (IsParsableValide && IsParsableEstEntrant && IsParsableEstSortant && IsParsableActiverAlerteMin && IsParsableActiverAlerteMax
                                    && IsParsablePoidsAlerteMin && IsParsablePoidsAlerteMax && IsParsableEmpecherTicketSiAlerte && IsParsableDechet)
                                {
                                    Produit produit = new Produit();
                                    produit.Update(Id, txtDesignation.Text, Common_functions.CbSelectedValue_Convert_Int(cbGroupeProduitId), EstEntrant, EstSortant, Valide, PoidsAlerteMin, ActiverAlerteMin,
                                    PoidsAlerteMax, ActiverAlerteMax, EmpecherTicketSiAlerte, Dechet, Common_functions.CbSelectedValue_Convert_Int(cbTypeDechetId));
                                    if (cbLang.Text == "FR")
                                        Custom_MessageBox.Show("FR", "Produit modifié avec succès", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else if (cbLang.Text == "EN")
                                        Custom_MessageBox.Show("EN", "Product updated successfully", "Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                        Custom_MessageBox.Show("ES", "Producto alterado", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                Custom_MessageBox.Show("FR", "Informations incomplètes", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Incomplete informations", "Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Información incompleta", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Vous ne pouvez pas supprimer l'enregistrement terminez d'abord la modification");
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas supprimer l'enregistrement tant que la modification n'est pas validée", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You can't delete this record before the update is completed", "Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    Custom_MessageBox.Show("ES", "No puede eliminar el registro hasta que se confirme el cambio", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    Produit produit = new Produit();
                    int Id;
                    bool IsParsableId;
                    IsParsableId = Int32.TryParse(txtId.Text, out Id);
                    if (IsParsableId)
                    {
                        DialogResult result;
                        if (cbLang.Text == "FR")
                            result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir supprimer cet enregistrement?", "Produit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else if (cbLang.Text == "EN")
                            result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else
                            result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            produit.Delete(Id);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Produit supprimé avec succès", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Product deleted successfully", "Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Producto eliminado", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ProduitDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vg_Mode == "Edit")
            {
                if (pbUpdating.Visible)
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Vous ne pouvez pas fermer la fenetre tant que la modification n'est pas validée", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "You can't close this window before the update is completed", "Product", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        Custom_MessageBox.Show("ES", "No puede cerrar la página hasta que se valide el cambio", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                language_Manager.ChangeLanguage("fr", this, typeof(ProduitDetail));

            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(ProduitDetail));
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(ProduitDetail));
            }
        }

  
    }
}
