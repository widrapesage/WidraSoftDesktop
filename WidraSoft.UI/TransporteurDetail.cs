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
    public partial class TransporteurDetail : Form
    {
        String vg_Mode = "";
        Int32 vg_Id = 0;
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;

        public TransporteurDetail(String Mode, Int32 Id)
        {
            InitializeComponent();
            vg_Mode = Mode;
            vg_Id = Id;
        }

        private void TransporteurDetail_Load(object sender, EventArgs e)
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

            Bind_DgvCamions();
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = 0;
        }

        private void Add_Item()
        {
            if (txtId.Text == "" && txtDateCreation.Text == "" && txtLicence.Text == "" && txtNom.Text == "" && txtAdresse.Text == "" && txtCodePostal.Text == "" && txtLocalite.Text == ""
                && txtPays.Text == "" && txtTelephone.Text == "" && txtEmail.Text == "" && txtNumTVA.Text == "" && txtSiteWebUrl.Text == ""
                && txtValide.Text == "" && txtBloque.Text == "" && txtBlocage.Text == "" && txtAttention.Text == "" && txtAlerte.Text == "" && txtObservations.Text == "")
            {
                lbModifier.Enabled = false;
                lbModifier.BackColor = Color.Transparent;
                lbSupprimer.Enabled = false;
                lbSupprimer.BackColor = Color.Transparent;

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
            lbAjouter.Enabled = false;
            lbAjouter.BackColor = Color.Transparent;
            Disable();
            Bind_Fields();
        }

        private void Bind_Fields()
        {
            DataTable dt = new DataTable();
            Transporteur transporteur = new Transporteur();
            dt = transporteur.FindById(vg_Id);
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["TRANSPORTEURID"];
                txtId.Text = Id.ToString();
                txtDateCreation.Text = row["DATECREATION"].ToString();
                txtLicence.Text = row["LICENCE"].ToString();
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
                txtValide.Text = row["VALIDE"].ToString();
                txtValide.Visible = false;
                if (txtValide.Text == "1")
                    chx_Valide.Checked = true;
                else
                    chx_Valide.Checked = false;
                txtBloque.Text = row["BLOQUE"].ToString();
                txtBloque.Visible = false;
                if (txtBloque.Text == "1")
                    chx_Bloque.Checked = true;
                else
                    chx_Bloque.Checked = false;
                txtBlocage.Text = row["TEXTEBLOQUE"].ToString();
                txtAttention.Text = row["ATTENTION"].ToString();
                txtAttention.Visible = false;
                if (txtAttention.Text == "1")
                    chx_Attention.Checked = true;
                else
                    chx_Attention.Checked = false;
                txtAlerte.Text = row["TEXTEATTENTION"].ToString();
            }
        }

        private void Bind_DgvCamions()
        {
            CamionTransporteur camionTransporteur = new CamionTransporteur();
            if (vg_Id <= 0)
            {
                DgvCamions.DataSource = camionTransporteur.FindByTransporteurId(-1);
            }
            else
            {
                DgvCamions.DataSource = camionTransporteur.FindByTransporteurId(vg_Id);
            }

            DgvCamions.Columns[0].Visible = false;
            DgvCamions.Columns["CAMION"].Visible = true;
            DgvCamions.Columns["TRANSPORTEURID"].Visible = false;
            DgvCamions.Columns["TRANSPORTEUR"].Visible = false;
            DgvCamions.Columns["DATECREATION"].Visible = false;

            DgvCamions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvCamions.ReadOnly = true;
            DgvCamions.RowHeadersVisible = false;

        }

        private void Localize_DgvCamions(string lang)
        {
            if (lang == "fr")
            {
                DgvCamions.Columns["CAMION"].HeaderText = "CAMION";
            }

            if (lang == "en")
            {
                DgvCamions.Columns["CAMION"].HeaderText = "TRUCK";
            }

            if (lang == "es")
            {
                DgvCamions.Columns["CAMION"].HeaderText = "CAMIÓN";
            }
        }

        private void Disable()
        {
            txtDateCreation.Enabled = false;
            txtLicence.Enabled = false;
            txtNom.Enabled = false;
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
            DgvCamions.Enabled = false;
            pbUpdating.Visible = false;

            vg_IsEnabled = false;
        }

        private void Enable()
        {
            txtDateCreation.Enabled = true;
            txtLicence.Enabled = true;
            txtNom.Enabled = true;
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
            DgvCamions.Enabled = true;
            pbUpdating.Visible = true;

            vg_IsEnabled = true;
        }

        private void Clear()
        {
            txtId.Text = "";
            txtDateCreation.Text = "";
            txtLicence.Text = "";
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
                            Transporteur transporteur = new Transporteur();
                            transporteur.Add(txtLicence.Text, txtNom.Text, txtAdresse.Text, txtCodePostal.Text, txtLocalite.Text, txtPays.Text, txtTelephone.Text, txtEmail.Text,
                                    txtNumTVA.Text, txtSiteWebUrl.Text, txtObservations.Text, Valide, Bloque, txtBlocage.Text, Attention, txtAlerte.Text);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Transporteur ajouté avec succès", "Transporteur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Carrier added successfully", "Carrier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Transportador agregado", "Transportador", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        Custom_MessageBox.Show("FR", "Informations incomplètes", "Transporteur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "Incomplete informations", "Carrier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES", "Información incompleta", "Transportador", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (txtId.Text != "" && txtDateCreation.Text != "" && txtNom.Text != ""
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
                                    Transporteur transporteur = new Transporteur();
                                    transporteur.Update(Id, txtLicence.Text, txtNom.Text, txtAdresse.Text, txtCodePostal.Text, txtLocalite.Text, txtPays.Text, txtTelephone.Text, txtEmail.Text,
                                            txtNumTVA.Text, txtSiteWebUrl.Text, txtObservations.Text, Valide, Bloque, txtBlocage.Text, Attention, txtAlerte.Text);
                                    if (cbLang.Text == "FR")
                                        Custom_MessageBox.Show("FR", "Transporteur modifié avec succès", "Transporteur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else if (cbLang.Text == "EN")
                                        Custom_MessageBox.Show("EN", "Carrier updated successfully", "Carrier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                        Custom_MessageBox.Show("ES", "Transportador alterado", "Transportador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lbModifier.Text = Language_Manager.Localize("Modifier", cbLang.Text);
                                    vg_Update = false;
                                    Disable();
                                    Bind_Fields();
                                    Bind_DgvCamions();
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
                                Custom_MessageBox.Show("FR", "Informations incomplètes", "Transporteur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Incomplete informations", "Carrier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Información incompleta", "Transportador", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas supprimer l'enregistrement tant que la modification n'est pas validée", "Transporteur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You can't delete this record before the update is completed", "Carrier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    Custom_MessageBox.Show("ES", "No puede eliminar el registro hasta que se confirme el cambio", "Transportador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    Transporteur transporteur = new Transporteur();
                    int Id;
                    bool IsParsableId;
                    IsParsableId = Int32.TryParse(txtId.Text, out Id);
                    if (IsParsableId)
                    {
                        DialogResult result;
                        if (cbLang.Text == "FR")
                            result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir supprimer cet enregistrement?", "Transporteur", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else if (cbLang.Text == "EN")
                            result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "Carrier", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else
                            result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Transportador", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            transporteur.Delete(Id);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Transporteur supprimé avec succès", "Transporteur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Carrier deleted successfully", "Carrier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Transportador eliminado", "Transportador", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void TransporteurDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vg_Mode == "Edit")
            {
                if (pbUpdating.Visible)
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Vous ne pouvez pas fermer la fenetre tant que la modification n'est pas validée", "Transporteur", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "You can't close this window before the update is completed", "Carrier", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        Custom_MessageBox.Show("ES", "No puede cerrar la página hasta que se valide el cambio", "Transportador", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                language_Manager.ChangeLanguage("fr", this, typeof(TransporteurDetail));
                Localize_DgvCamions("fr");
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(TransporteurDetail));
                Localize_DgvCamions("en");
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(TransporteurDetail));
                Localize_DgvCamions("es");
            }
        }
    }
}
