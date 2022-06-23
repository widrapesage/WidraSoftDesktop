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
    public partial class FirmeDetail : Form
    {
        String vg_Mode = "";
        Int32 vg_Id = 0;
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;
        public FirmeDetail(String Mode, Int32 Id)
        {
            InitializeComponent();
            vg_Mode = Mode;
            vg_Id = Id;
        }

        private void FirmeDetail_Load(object sender, EventArgs e)
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

        }

        private void Add_Item()
        {
            if (txtId.Text == "" && txtDateCreation.Text == "" && txtBadge.Text == "" && txtDesignation.Text == "" && txtAdresse.Text == "" && txtCodePostal.Text == "" && txtLocalite.Text == ""
                && txtPays.Text == "" && txtTelephone.Text == "" && txtEmail.Text == "" && txtNumTVA.Text == "" && txtSiteWebUrl.Text == ""
                && txtValide.Text == "" && txtBloque.Text == "" && txtBlocage.Text == "" && txtAttention.Text == "" && txtAlerte.Text == "")
            {
                btModifier.Enabled = false;
                btModifier.BackColor = Color.Transparent;
                btSupprimer.Enabled = false;
                btSupprimer.BackColor = Color.Transparent;

                txtValide.Text = "1";
                chx_Valide.Checked = true;
                txtBloque.Text = "0";
                chx_Bloque.Checked = false;
                txtAttention.Text = "0";
                chx_Attention.Checked = false;
                
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
            Firme firme = new Firme();
            dt = firme.FindById(vg_Id);
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["FIRMEID"];
                txtId.Text = Id.ToString();
                txtDateCreation.Text = row["DATECREATION"].ToString();
                txtBadge.Text = row["BADGE"].ToString();
                txtDesignation.Text = row["DESIGNATION"].ToString();
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
                txtValide.Visible = false;
                if (txtValide.Text == "1")
                    chx_Valide.Checked = true;
                else
                    chx_Valide.Checked = false;
                txtBloque.Text = row["BLOQUE"].ToString();
                txtBloque.Visible = false;
                if (txtBloque.Text == "1" )
                    chx_Bloque.Checked = true;
                else
                    chx_Bloque.Checked = false;
                txtBlocage.Text = row["TEXTEBLOQUE"].ToString();
                txtAttention.Text = row["ATTENTION"].ToString();
                txtAttention.Visible = false;
                if (txtAttention.Text == "1" )
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
            txtDesignation.Enabled = false;
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

            vg_IsEnabled = false;
        }

        private void Enable() 
        {
            txtDateCreation.Enabled = true;
            txtBadge.Enabled = true;
            txtDesignation.Enabled = true;
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

            vg_IsEnabled = true;
        }

        private void Clear()
        {
            txtId.Text = "";
            txtDateCreation.Text = "";
            txtBadge.Text = "";
            txtDesignation.Text = "";
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

        private Int32 CbSelectedValue_Convert_Int(ComboBox o)
        {
            if (o.SelectedValue == null)
            {
                return 0;
            }
            else
            {
                return (Int32)o.SelectedValue;
            }
        }

        private void btAjouter_MouseEnter(object sender, EventArgs e)
        {
            if (btAjouter.Enabled == true)
                btAjouter.BackColor = Color.MintCream;
        }

        private void btAjouter_MouseLeave(object sender, EventArgs e)
        {
            if (btAjouter.Enabled == true)
                btAjouter.BackColor = Color.MediumSeaGreen;
        }

        private void btModifier_MouseEnter(object sender, EventArgs e)
        {
            if (btModifier.Enabled == true)
                btModifier.BackColor = Color.MintCream;
        }

        private void btModifier_MouseLeave(object sender, EventArgs e)
        {
            if (btModifier.Enabled == true)
                btModifier.BackColor = Color.MediumSeaGreen;
        }

        private void btSupprimer_MouseEnter(object sender, EventArgs e)
        {
            if (btSupprimer.Enabled == true)
                btSupprimer.BackColor = Color.MintCream;
        }

        private void btSupprimer_MouseLeave(object sender, EventArgs e)
        {
            if (btSupprimer.Enabled == true)
                btSupprimer.BackColor = Color.MediumSeaGreen;
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

        private void btAjouter_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtId.Text == "" && txtDateCreation.Text == "" && txtDesignation.Text != "" && txtValide.Text != "" && txtBloque.Text != "" && txtAttention.Text != "")
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
                            Firme firme = new Firme();
                            firme.Add(txtBadge.Text, txtDesignation.Text, txtAdresse.Text, txtCodePostal.Text, txtLocalite.Text, txtPays.Text, txtTelephone.Text, txtEmail.Text,
                                    txtNumTVA.Text, txtSiteWebUrl.Text, txtObservations.Text, Valide, Bloque, txtBlocage.Text, Attention, txtAlerte.Text);
                            MessageBox.Show("Firme ajoutée avec succès");
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
                    MessageBox.Show("Informations incomplètes");
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
                    btModifier.Text = "Valider";
                    vg_Update = true;
                }
                else
                {
                    try
                    {
                        if (txtId.Text != "" && txtDateCreation.Text != "" && txtDesignation.Text != "" 
                            && txtValide.Text != "" && txtBloque.Text != "" && txtAttention.Text != "") 
                        {
                            int Id;
                            int Valide;
                            int Bloque;
                            int Attention;
                            bool IsParsableId;
                            bool IsParsableValide;
                            bool IsParsableBloque;
                            bool IsParsableAttention;
                            IsParsableId = Int32.TryParse(txtId.Text, out Id);
                            IsParsableValide = Int32.TryParse(txtValide.Text, out Valide);
                            IsParsableBloque = Int32.TryParse(txtBloque.Text, out Bloque);
                            IsParsableAttention = Int32.TryParse(txtAttention.Text, out Attention);
                            try
                            {
                                if (IsParsableId && IsParsableValide && IsParsableBloque && IsParsableAttention)
                                {
                                    Firme firme = new Firme();
                                    firme.Update(Id, txtBadge.Text, txtDesignation.Text, txtAdresse.Text, txtCodePostal.Text, txtLocalite.Text, txtPays.Text, txtTelephone.Text, txtEmail.Text,
                                            txtNumTVA.Text, txtSiteWebUrl.Text, txtObservations.Text, Valide, Bloque, txtBlocage.Text, Attention, txtAlerte.Text);
                                    MessageBox.Show("Firme modifiée avec succès");
                                    btModifier.Text = "Modifier";
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
                            MessageBox.Show("Informations incomplètes");
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
                MessageBox.Show("Vous ne pouvez pas supprimer l'enregistrement terminez d'abord la modification");
            }
            else
            {
                try
                {
                    Firme firme = new Firme();
                    int Id;
                    bool IsParsableId;
                    IsParsableId = Int32.TryParse(txtId.Text, out Id);
                    if (IsParsableId)
                    {
                        firme.Delete(Id);
                        MessageBox.Show("Firme supprimée avec succès");
                        Close();
                    }
                }
                catch
                {
                    throw;
                }
                

            }
        }
    }
}
