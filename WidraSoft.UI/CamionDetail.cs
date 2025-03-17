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
    public partial class CamionDetail : Form
    {
        String vg_Mode = "";
        Int32 vg_Id = 0;
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;
        public CamionDetail(String Mode, Int32 Id)
        {
            InitializeComponent();
            vg_Mode = Mode;
            vg_Id = Id;
        }

        private void CamionDetail_Load(object sender, EventArgs e)
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
            Bind_DgvChauffeurs();
            Bind_DgvTransporteurs();
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = MenuGeneral.languuage_index;
        }

        private void Add_Item()
        {
            if (txtId.Text == "" && txtDateCreation.Text == "" && txtBadge.Text == "" && txtPlaque.Text == "" && txtCode.Text == "" && txtTare.Text == ""
                && txtValide.Text == "" && txtBloque.Text == "" && txtBlocage.Text == "" && txtAttention.Text == "" && txtAlerte.Text == "" && txtObservations.Text == "")
            {
                lbModifier.Enabled = false;
                lbModifier.BackColor = Color.Transparent;
                lbSupprimer.Enabled = false;
                lbSupprimer.BackColor = Color.Transparent;

                txtTare.Text = "0";
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
            Camion camion = new Camion();
            dt = camion.FindById(vg_Id);
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["CAMIONID"];
                txtId.Text = Id.ToString();
                txtDateCreation.Text = row["DATECREATION"].ToString();
                txtBadge.Text = row["BADGE"].ToString();
                txtPlaque.Text = row["PLAQUE"].ToString();
                txtCode.Text = row["CODE"].ToString();
                txtTare.Text = row["TARE"].ToString();
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
                txtObservations.Text = row["OBSERVATIONS"].ToString();
            }
        }

        private void Disable()
        {
            txtDateCreation.Enabled = false;
            txtBadge.Enabled = false;
            txtPlaque.Enabled = false;
            txtCode.Enabled = false;
            txtTare.Enabled = false;
            chx_Valide.Enabled = false;
            chx_Bloque.Enabled = false;
            txtBlocage.Enabled  = false;
            chx_Attention.Enabled = false;
            txtAlerte.Enabled = false;
            txtObservations.Enabled = false;
            dgvChauffeurs.Enabled = false;
            dgvTransporteurs.Enabled = false;
            lblAddDgvChauffeurs.Enabled = false;
            lblRetirerDgvChauffeurs.Enabled = false;
            lbActualiserDgvChauffeurs.Enabled = false;
            lblAddDgvTransporteurs.Enabled =false;
            lblRetirerDgvTransporteurs.Enabled = false;
            lbActualiserDgvTransporteurs.Enabled = false;
            pbUpdating.Visible = false;

            vg_IsEnabled = false;
        }

        private void Enable()
        {
            txtDateCreation.Enabled = true;
            txtBadge.Enabled = true;
            txtPlaque.Enabled = true;
            txtCode.Enabled = true;
            txtTare.Enabled = true;
            chx_Valide.Enabled = true;
            chx_Bloque.Enabled = true;
            txtBlocage.Enabled = true;
            chx_Attention.Enabled = true;
            txtAlerte.Enabled = true;
            txtObservations.Enabled = true;
            dgvChauffeurs.Enabled = true;
            dgvTransporteurs.Enabled = true;
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
            txtBadge.Text = "";
            txtPlaque.Text = "";
            txtCode.Text = "";
            txtTare.Text = "";            
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

        private void Bind_DgvChauffeurs()
        {
            CamionChauffeur camionChauffeur = new CamionChauffeur();
            if (txtId.Text == "")
            {
                dgvChauffeurs.DataSource = camionChauffeur.FindByCamionId(-1);
            }
            else
            {
                int Id;
                bool IsParsableId;
                IsParsableId = Int32.TryParse(txtId.Text, out Id);
                dgvChauffeurs.DataSource = camionChauffeur.FindByCamionId(Id);
            }

            dgvChauffeurs.Columns[0].Visible = false;
            dgvChauffeurs.Columns["CHAUFFEUR"].Visible = true;
            dgvChauffeurs.Columns["CAMIONID"].Visible = false;
            dgvChauffeurs.Columns["CAMION"].Visible = false;
            dgvChauffeurs.Columns["DATECREATION"].Visible = false;

            dgvChauffeurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChauffeurs.ReadOnly = true;

        }

        private void Localize_DgvChauffeurs(string lang)
        {
            if (lang == "fr")
            {
                dgvChauffeurs.Columns["CAMION"].HeaderText = "CAMION";
                dgvChauffeurs.Columns["CHAUFFEUR"].HeaderText = "CHAUFFEUR";
                dgvChauffeurs.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            }

            if (lang == "en")
            {
                dgvChauffeurs.Columns["CAMION"].HeaderText = "TRUCK";
                dgvChauffeurs.Columns["CHAUFFEUR"].HeaderText = "DRIVER";
                dgvChauffeurs.Columns["DATECREATION"].HeaderText = "CREATION DATE";
            }

            if (lang == "es")
            {
                dgvChauffeurs.Columns["CAMION"].HeaderText = "CAMIÓN";
                dgvChauffeurs.Columns["CHAUFFEUR"].HeaderText = "CONDUCTOR";
                dgvChauffeurs.Columns["DATECREATION"].HeaderText = "FECHA DE CREACIÓN";
            }
        }

        private void lblAddDgvChauffeurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Form form = new CamionChauffeurDetail(vg_Id);
                form.Show();
            }
            catch
            {
                throw;
            }
        }

        private void lbActualiserDgvChauffeurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Refresh_DgvChauffeurs();
        }

        private void lblRetirerDgvChauffeurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Int32[] selectedIds = new Int32[Common_functions.GetDatagridViewSelectedRowsId(dgvChauffeurs).Length];
            selectedIds = Common_functions.GetDatagridViewSelectedRowsId(dgvChauffeurs);
            if (Common_functions.GetDatagridViewSelectedRowsId(dgvChauffeurs).Length > 0)
            {
                for (int i = 0; i < Common_functions.GetDatagridViewSelectedRowsId(dgvChauffeurs).Length; i++)
                {
                    try
                    {
                        CamionChauffeur camionChauffeur = new CamionChauffeur();
                        camionChauffeur.Delete(vg_Id, selectedIds[i]);
                    }
                    catch
                    {
                        throw;
                    }
                }
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", Common_functions.GetDatagridViewSelectedRowsId(dgvChauffeurs).Length + " chauffeur(s) supprimé(s)", "Chauffeur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", Common_functions.GetDatagridViewSelectedRowsId(dgvChauffeurs).Length + " driver(s) deleted", "Driver", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    Custom_MessageBox.Show("ES", Common_functions.GetDatagridViewSelectedRowsId(dgvChauffeurs).Length + " conductor(es) añadido(s)", "Conductor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Refresh_DgvChauffeurs();
            }
            else
            {

                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Aucun enregistrement sélectionné", "Chauffeur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "No rows selected", "Driver", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Conductor", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Refresh_DgvChauffeurs()
        {
            int Id;
            bool IsParsableId;
            CamionChauffeur camionChauffeur = new CamionChauffeur();
            IsParsableId = Int32.TryParse(txtId.Text, out Id);
            dgvChauffeurs.DataSource = camionChauffeur.FindByCamionId(Id);
        }

        private void Bind_DgvTransporteurs()
        {
            CamionTransporteur camionTransporteur = new CamionTransporteur();
            if (txtId.Text == "")
            {
                dgvTransporteurs.DataSource = camionTransporteur.FindByCamionId(-1);
            }
            else
            {
                int Id;
                bool IsParsableId;
                IsParsableId = Int32.TryParse(txtId.Text, out Id);
                dgvTransporteurs.DataSource = camionTransporteur.FindByCamionId(Id);
            }

            dgvTransporteurs.Columns[0].Visible = false;
            dgvTransporteurs.Columns["TRANSPORTEUR"].Visible = true;
            dgvTransporteurs.Columns["CAMIONID"].Visible = false;
            dgvTransporteurs.Columns["CAMION"].Visible = false;
            dgvTransporteurs.Columns["DATECREATION"].Visible = false;

            dgvTransporteurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransporteurs.ReadOnly = true;

        }

        private void Localize_DgvTransporteurs(string lang)
        {
            if (lang == "fr")
            {
                dgvTransporteurs.Columns["CAMION"].HeaderText = "CAMION";
                dgvTransporteurs.Columns["TRANSPORTEUR"].HeaderText = "TRANSPORTEUR";
                dgvTransporteurs.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            }

            if (lang == "en")
            {
                dgvTransporteurs.Columns["CAMION"].HeaderText = "TRUCK";
                dgvTransporteurs.Columns["TRANSPORTEUR"].HeaderText = "CARRIER";
                dgvTransporteurs.Columns["DATECREATION"].HeaderText = "CREATION DATE";
            }

            if (lang == "es")
            {
                dgvTransporteurs.Columns["CAMION"].HeaderText = "CAMIÓN";
                dgvTransporteurs.Columns["TRANSPORTEUR"].HeaderText = "TRANSPORTADOR";
                dgvTransporteurs.Columns["DATECREATION"].HeaderText = "FECHA DE CREACIÓN";
            }
        }

        private void lblAddDgvTransporteurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Form form = new CamionTransporteurDetail(vg_Id);
                form.Show();
            }
            catch
            {
                throw;
            }
        }

        private void lbActualiserDgvTransporteurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Refresh_DgvTransporteurs();
        }

        private void lblRetirerDgvTransporteurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Int32[] selectedIds = new Int32[Common_functions.GetDatagridViewSelectedRowsId(dgvTransporteurs).Length];
            selectedIds = Common_functions.GetDatagridViewSelectedRowsId(dgvTransporteurs);
            if (Common_functions.GetDatagridViewSelectedRowsId(dgvTransporteurs).Length > 0)
            {
                for (int i = 0; i < Common_functions.GetDatagridViewSelectedRowsId(dgvTransporteurs).Length; i++)
                {
                    try
                    {
                        CamionTransporteur camionTransporteur = new CamionTransporteur();
                        camionTransporteur.Delete(vg_Id, selectedIds[i]);
                    }
                    catch
                    {
                        throw;
                    }
                }
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", Common_functions.GetDatagridViewSelectedRowsId(dgvTransporteurs).Length + " transporteur(s) supprimé(s)", "Transporteur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", Common_functions.GetDatagridViewSelectedRowsId(dgvTransporteurs).Length + " carrier(s) deleted", "Carrier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    Custom_MessageBox.Show("ES", Common_functions.GetDatagridViewSelectedRowsId(dgvTransporteurs).Length + " transportistas añadidos", "Transportador", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Refresh_DgvChauffeurs();
            }
            else
            {

                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Aucun enregistrement sélectionné", "Transporteur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "No rows selected", "Carrier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Transportador", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Refresh_DgvTransporteurs()
        {
            int Id;
            bool IsParsableId;
            CamionTransporteur camionTransporteur = new CamionTransporteur();
            IsParsableId = Int32.TryParse(txtId.Text, out Id);
            dgvTransporteurs.DataSource = camionTransporteur.FindByCamionId(Id);
        }





        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(CamionDetail));
                Localize_DgvChauffeurs("fr");
                Localize_DgvTransporteurs("fr");

            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(CamionDetail));
                Localize_DgvChauffeurs("en");
                Localize_DgvTransporteurs("en");
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(CamionDetail));
                Localize_DgvChauffeurs("es");
                Localize_DgvTransporteurs("es");
            }
        }

        private void lbAjouter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtId.Text == "" && txtDateCreation.Text == "" && txtPlaque.Text != "" && txtValide.Text != "" && txtBloque.Text != "" && txtAttention.Text != "")
                {
                    int Tare;
                    int Valide;
                    int Bloque;
                    int Attention;
                    bool IsParsableTare;
                    bool IsParsableValide;
                    bool IsParsableBloque;
                    bool IsParsableAttention;
                    IsParsableTare = Int32.TryParse(txtTare.Text, out Tare);
                    IsParsableValide = Int32.TryParse(txtValide.Text, out Valide);
                    IsParsableBloque = Int32.TryParse(txtBloque.Text, out Bloque);
                    IsParsableAttention = Int32.TryParse(txtAttention.Text, out Attention);
                    try
                    {
                        if (IsParsableTare && IsParsableValide && IsParsableBloque && IsParsableAttention)
                        {
                            Camion camion = new Camion();
                            camion.Add(txtCode.Text, txtPlaque.Text, txtBadge.Text, Tare, Valide, Bloque, txtBlocage.Text,
                                 Attention, txtAlerte.Text, txtObservations.Text);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Camion ajouté avec succès", "Camion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Truck added successfully", "Truck", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Camión agregado", "Camión", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        Custom_MessageBox.Show("FR", "Informations incomplètes", "Camion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "Incomplete informations", "Truck", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES", "Información incompleta", "Camión", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (txtId.Text != "" && txtDateCreation.Text != "" && txtPlaque.Text != "" && txtValide.Text != "" && txtBloque.Text != "" && txtAttention.Text != "")
                        {
                            int Id;
                            int Tare;
                            int Valide;
                            int Bloque;
                            int Attention;
                            bool IsParsableId;
                            bool IsParsableTare;
                            bool IsParsableValide;
                            bool IsParsableBloque;
                            bool IsParsableAttention;
                            IsParsableId = Int32.TryParse(txtId.Text, out Id);
                            IsParsableTare = Int32.TryParse(txtTare.Text, out Tare);
                            IsParsableValide = Int32.TryParse(txtValide.Text, out Valide);
                            IsParsableBloque = Int32.TryParse(txtBloque.Text, out Bloque);
                            IsParsableAttention = Int32.TryParse(txtAttention.Text, out Attention);
                            try
                            {
                                if (IsParsableId && IsParsableTare && IsParsableValide && IsParsableBloque && IsParsableAttention)
                                {
                                    Camion camion = new Camion();
                                    camion.Update(Id, txtCode.Text, txtPlaque.Text, txtBadge.Text, Tare, Valide, Bloque, txtBlocage.Text,
                                       Attention, txtAlerte.Text, txtObservations.Text);
                                    if (cbLang.Text == "FR")
                                        Custom_MessageBox.Show("FR", "Camion modifié avec succès", "Camion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else if (cbLang.Text == "EN")
                                        Custom_MessageBox.Show("EN", "Truck updated successfully", "Truck", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                        Custom_MessageBox.Show("ES", "Camión alterado", "Camión", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                Custom_MessageBox.Show("FR", "Informations incomplètes", "Camion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Incomplete informations", "Truck", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Información incompleta", "Camión", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas supprimer l'enregistrement tant que la modification n'est pas validée", "Camion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You can't delete this record before the update is completed", "Truck", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    Custom_MessageBox.Show("ES", "No puede eliminar el registro hasta que se confirme el cambio", "Camión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    Camion camion = new Camion();
                    int Id;
                    bool IsParsableId;
                    IsParsableId = Int32.TryParse(txtId.Text, out Id);
                    if (IsParsableId)
                    {
                        DialogResult result;
                        if (cbLang.Text == "FR")
                            result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir supprimer cet enregistrement?", "Camion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else if (cbLang.Text == "EN")
                            result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "Truck", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else
                            result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Camión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            camion.Delete(Id);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Camion supprimé avec succès", "Camion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Truck deleted successfully", "Truck", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Camión eliminado", "Camión", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void CamionDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vg_Mode == "Edit")
            {
                if (pbUpdating.Visible)
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Vous ne pouvez pas fermer la fenetre tant que la modification n'est pas validée", "Camion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "You can't close this window before the update is completed", "Truck", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        Custom_MessageBox.Show("ES", "No puede cerrar la página hasta que se valide el cambio", "Camión", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    e.Cancel = true;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtPlaque.Text != "")
            {
                Form form = new AccesCamionQr(txtPlaque.Text);
                form.Show();
            }
            
        }
    }
}
