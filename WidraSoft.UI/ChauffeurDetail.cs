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
    public partial class ChauffeurDetail : Form
    {
        String vg_Mode = "";
        Int32 vg_Id = 0;
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;

        public ChauffeurDetail(String Mode, Int32 Id)
        {
            InitializeComponent();
            vg_Mode = Mode;
            vg_Id = Id;
        }

        private void ChauffeurDetail_Load(object sender, EventArgs e)
        {

            this.CenterToParent();

            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = 0;
        }

        private void Add_Item()
        {
            if (txtId.Text == "" && txtDateCreation.Text == "" && txtBadge.Text == "" && txtNom.Text == "" && txtNumeroNational.Text == "" 
                && txtAdresse.Text == "" && txtCodePostal.Text == "" && txtLocalite.Text == ""
                && txtPays.Text == "" && txtTelephone.Text == "" && txtEmail.Text == "" && txtNumTVA.Text == "" && txtSiteWebUrl.Text == ""
                && txtValide.Text == "" && txtBloque.Text == "" && txtBlocage.Text == "" && txtAttention.Text == "" && txtAlerte.Text == "" && txtObservations.Text == "")
            {
                lbModifier.Enabled = false;
                lbModifier.BackColor = Color.Transparent;
                lbSupprimer.Enabled = false;
                lbSupprimer.BackColor = Color.Transparent;

                txtValide.Text = "1"; chx_Valide.Checked = true;
                txtBloque.Text = "0"; chx_Bloque.Checked = false;
                txtAttention.Text = "0"; chx_Attention.Checked = false;

            }
        }

        private void Edit_Item()
        {
            lbAjouter.Enabled = false;
            lbAjouter.BackColor = Color.Transparent;
            //Disable();
            //Bind_Fields();
        }

        private void Bind_Fields()
        {
            DataTable dt = new DataTable();
            Chauffeur chauffeur = new Chauffeur();
            dt = chauffeur.FindById(vg_Id);
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["CHAUFFEURID"];
                txtId.Text = Id.ToString();
                txtDateCreation.Text = row["DATECREATION"].ToString();
                txtBadge.Text = row["BADGE"].ToString();
                txtNom.Text = row["NOM"].ToString();
                txtNumeroNational.Text = row["NUMERONATIONAL"].ToString();
                txtNumeroPermis.Text = row["NUMEROPERMIS"].ToString();
                txtAdresse.Text = row["ADRESSE"].ToString();
                txtCodePostal.Text = row["CODEPOSTAL"].ToString();
                txtLocalite.Text = row["LOCALITE"].ToString();
                txtPays.Text = row["PAYS"].ToString();
                txtTelephone.Text = row["TELEPHONE"].ToString();
                txtEmail.Text = row["EMAIL"].ToString();
                txtNumTVA.Text = row["NUMTVA"].ToString();
                txtSiteWebUrl.Text = row["SITEWEB_URL"].ToString();
                txtObservations.Text = row["OBSERVATIONS"].ToString();
                txtValide.Text = row["VALIDE"].ToString();
                if (txtValide.Text == "1")
                    chx_Valide.Checked = true;
                else
                    chx_Valide.Checked = false;
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

        private void Disable()
        {
            txtDateCreation.Enabled = false;
            txtBadge.Enabled = false;
            txtNom.Enabled = false;
            txtNumeroNational.Enabled = false;
            txtNumeroPermis.Enabled = false;
            txtAdresse.Enabled = false;
            txtCodePostal.Enabled = false;
            txtLocalite.Enabled = false;
            txtPays.Enabled = false;
            txtTelephone.Enabled = false;
            txtEmail.Enabled = false;
            txtNumTVA.Enabled = false;
            txtSiteWebUrl.Enabled = false;
            chx_Valide.Enabled = false;
            chx_Bloque.Enabled = false;
            txtBlocage.Enabled = false;
            chx_Attention.Enabled = false;
            txtAlerte.Enabled = false;
            txtObservations.Enabled = false;
            pbUpdating.Visible = false;

            vg_IsEnabled = false;
        }

        private void Enable()
        {
            txtDateCreation.Enabled = true;
            txtBadge.Enabled = true;
            txtNom.Enabled = true;
            txtNumeroNational.Enabled = true;
            txtNumeroPermis.Enabled = true;
            txtAdresse.Enabled = true;
            txtCodePostal.Enabled = true;
            txtLocalite.Enabled = true;
            txtPays.Enabled = true;
            txtTelephone.Enabled = true;
            txtEmail.Enabled = true;
            txtNumTVA.Enabled = true;
            txtSiteWebUrl.Enabled = true;
            chx_Valide.Enabled = true;
            chx_Bloque.Enabled = true;
            txtBlocage.Enabled = true;
            chx_Attention.Enabled = true;
            txtAlerte.Enabled = true;
            txtObservations.Enabled = true;
            pbUpdating.Visible = true;

            vg_IsEnabled = true;
        }

        private void Clear()
        {
            txtId.Text = "";
            txtDateCreation.Text = "";
            txtBadge.Text = "";
            txtNom.Text = "";
            txtNumeroNational.Text = "";
            txtNumeroPermis.Text = "";
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
            chx_Valide.Checked = false;
            chx_Bloque.Checked = false;
            chx_Attention.Checked = false;
        }

        private void chx_Valide_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Valide.Checked)
                txtValide.Text = "1";
            else
                txtValide.Text = "0";
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

                if (txtId.Text == "" && txtDateCreation.Text == "" && txtNom.Text != "" && txtValide.Text != "" && txtBloque.Text != "" && txtAttention.Text != "")
                {
                    int Valide;
                    int Bloque;
                    int Attention;
                    bool IsParsableValide;
                    bool IsParsableBloque;
                    bool IsParsableAttention;
                    IsParsableValide = Int32.TryParse(txtValide.Text, out Valide);
                    IsParsableBloque = Int32.TryParse(txtBloque.Text, out Bloque);
                    IsParsableAttention = Int32.TryParse(txtAttention.Text, out Attention);
                    try
                    {
                        if (IsParsableValide && IsParsableBloque && IsParsableAttention)
                        {
                            Chauffeur chauffeur = new Chauffeur();
                            //chauffeur.Add(txtBadge.Text, txtNom.Text, txtNumeroNational.Text, txtNumeroPermis.Text, txtAdresse.Text, txtCodePostal.Text, txtLocalite.Text, txtPays.Text, txtTelephone.Text,
                               //     txtNumTVA.Text, txtSiteWebUrl.Text, txtObservations.Text, Valide, Bloque, txtBlocage.Text, Attention, txtAlerte.Text);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Firme ajoutée avec succès", "Firme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Firm added successfully", "Firm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Firma agregado", "Firma", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        Custom_MessageBox.Show("FR", "Informations incomplètes", "Firme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "Incomplete informations", "Firm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES", "Información incompleta", "Firma", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
