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
    public partial class PontDetail : Form
    {
        String vg_Mode = "";
        Int32 vg_Id = 0;
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;
        public PontDetail(String Mode, Int32 Id)
        {
            InitializeComponent();
            vg_Mode = Mode;
            vg_Id = Id;
        }

        private void PontDetail_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            WeightSettings weightSettings = new WeightSettings();
            cbWeight_SettingsId.DataSource = weightSettings.List("1=1");
            cbWeight_SettingsId.DisplayMember = "DESIGNATION";
            cbWeight_SettingsId.ValueMember = "WEIGHT_SETTINGSID";

            WeighingSettings weighingSettings = new WeighingSettings();
            cbWeighing_SettingsId.DataSource = weighingSettings.List("1=1");
            cbWeighing_SettingsId.DisplayMember = "DESIGNATION";
            cbWeighing_SettingsId.ValueMember = "WEIGHING_SETTINGSID";

            Utilisateur utilisateur = new Utilisateur();
            DataTable dt = utilisateur.List("1=1");
            dt.Columns.Add("NOMCOMPLET", typeof(String), "PRENOM + ' ' + NOM");
            cbUtilisateurId.DataSource = dt;
            cbUtilisateurId.DisplayMember = "NOMCOMPLET";
            cbUtilisateurId.ValueMember = "ID";

            cbBaudRate.DataSource = Values.BaudRate;
            cbBaudRate.ValueMember = null;
            cbBaudRate.DisplayMember = Values.BaudRate[0].ToString();

            cbDataBits.DataSource = Values.Databits;
            cbDataBits.ValueMember = null;
            cbDataBits.DisplayMember = Values.Databits[0].ToString();

            cbStopBits.DataSource = Values.StopBits;
            cbStopBits.ValueMember = null;
            cbStopBits.DisplayMember = Values.StopBits[0];

            cbHandshake.DataSource = Values.Handshake;
            cbHandshake.ValueMember = null;
            cbHandshake.DisplayMember = Values.Handshake[0];

            cbDemarrage.DataSource = Values.DemarrageType;
            cbDemarrage.ValueMember = null;
            cbDemarrage.DisplayMember = Values.DemarrageType[0];

            cbBornePremierePesee.DataSource = Values.YesNoBornePremierePesee;
            cbBornePremierePesee.ValueMember = null;
            cbBornePremierePesee.DisplayMember = Values.YesNoBornePremierePesee[0].ToString();

            cbBorneDeuxiemePesee.DataSource = Values.YesNoBorneDeuxiemePesee;
            cbBorneDeuxiemePesee.ValueMember = null;
            cbBorneDeuxiemePesee.DisplayMember = Values.YesNoBorneDeuxiemePesee[0].ToString();

            cbBorneTareManuelle.DataSource = Values.YesNoBorneTareManuelle;
            cbBorneTareManuelle.ValueMember = null;
            cbBorneTareManuelle.DisplayMember = Values.YesNoBorneTareManuelle[0].ToString();

            cbFlux_Default.DataSource = Values.Flux_Default;
            cbFlux_Default.ValueMember = null;
            cbFlux_Default.DisplayMember = Values.Flux_Default[0].ToString();

            cbTypeScanner.DataSource = Values.TypeScanner;
            cbTypeScanner.ValueMember = null;
            cbTypeScanner.DisplayMember = Values.TypeScanner[0].ToString();

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

            Bind_DgvFirmes();
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = MenuGeneral.languuage_index;

        }

        private void Add_Item()
        {
            if (txtId.Text == "" && txtDateCreation.Text == "" && txtDesignation.Text == "" && cbWeight_SettingsId.Text == "" && cbWeighing_SettingsId.Text == "" && txtCOM.Text == "" && txtActiverPoids.Text == "" && cbBaudRate.Text == "" && cbDataBits.Text == ""
                && cbStopBits.Text == "" && cbHandshake.Text == "" && txtReadTimeOut.Text == "" && txtMachine.Text == "" && cbDemarrage.Text == "" && cbUtilisateurId.Text == "" && txtActiverMultipleParam.Text == "" && cbBornePremierePesee.Text == "" && cbBorneDeuxiemePesee.Text == ""
                && cbBorneTareManuelle.Text == "" && cbFlux_Default.Text == "" && txtActiverScanner.Text == "" && cbTypeScanner.Text == "" && txtActiverBarriere.Text == "" && txtCOMBarriere.Text == "" && txtCOMScanner.Text == ""
                && txtContact1.Text == "" && txtContact2.Text == "" && txtContact3.Text == "")
            {
                lbModifier.Enabled = false;
                lbModifier.BackColor = Color.Transparent;
                lbSupprimer.Enabled = false;
                lbSupprimer.BackColor = Color.Transparent;

                txtActiverPoids.Text = "1";
                chx_ActiverPoids.Checked = true;

                txtActiverMultipleParam.Text = "0";
                chx_ActiverPoids.Checked = false;

                txtActiverScanner.Text = "0";
                chx_ActiverScanner.Checked = false;

                txtActiverBarriere.Text = "0";
                chx_ActiverBarriere.Checked = false;

                txtMin.Text = "0";
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
            Pont pont = new Pont();
            dt = pont.FindById(vg_Id);
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["PONTID"];
                txtId.Text = Id.ToString();
                txtDateCreation.Text = row["DATECREATION"].ToString();
                txtDesignation.Text = row["DESIGNATION"].ToString();
                if (row["WEIGHT_SETTINGSID"] is System.DBNull)
                    cbWeight_SettingsId.SelectedValue = 0;
                else
                    cbWeight_SettingsId.SelectedValue = (int)row["WEIGHT_SETTINGSID"];
                if (row["WEIGHING_SETTINGSID"] is System.DBNull)
                    cbWeighing_SettingsId.SelectedValue = 0;
                else
                    cbWeighing_SettingsId.SelectedValue = (int)row["WEIGHING_SETTINGSID"];
                txtCOM.Text = row["NUMPORTCOM"].ToString();
                txtActiverPoids.Text = row["ACTIVERPOIDS"].ToString();
                if (txtActiverPoids.Text == "1")
                    chx_ActiverPoids.Checked = true;
                else
                    chx_ActiverPoids.Checked = false;
                if (row["BAUDRATE"] is System.DBNull)
                    cbBaudRate.Text = "";
                else
                    cbBaudRate.Text = row["BAUDRATE"].ToString();
                if (row["DATABITS"] is System.DBNull)
                    cbDataBits.Text = "";
                else
                    cbDataBits.Text = row["DATABITS"].ToString();
                cbStopBits.Text = row["STOPBITS"].ToString();
                cbHandshake.Text = row["HANDSHAKE"].ToString();
                txtReadTimeOut.Text = row["READTIMEOUT"].ToString();
                txtMachine.Text = row["MACHINE"].ToString();
                cbDemarrage.Text = row["DEMARRAGE"].ToString();
                if (row["UTILISATEURID"] is System.DBNull)
                    cbUtilisateurId.SelectedValue = 0;
                else
                    cbUtilisateurId.SelectedValue = (int)row["UTILISATEURID"];
                txtActiverMultipleParam.Text = row["ACTIVER_MULTIPLE_PARAM"].ToString();
                if (txtActiverMultipleParam.Text == "1")
                    chx_ActiverMultipleParam.Checked = true;
                else
                    chx_ActiverMultipleParam.Checked = false;
                txtMin.Text = row["POIDS_DETECTION"].ToString();
                cbBornePremierePesee.Text = row["BORNEPREMIEREPESEE"].ToString();
                cbBorneDeuxiemePesee.Text = row["BORNEDEUXIEMEPESEE"].ToString();
                cbBorneTareManuelle.Text = row["BORNETAREMANUELLE"].ToString();
                cbFlux_Default.Text = row["FLUX_DEFAULT"].ToString();
                txtActiverScanner.Text = row["ACTIVER_SCANNER"].ToString();
                if (txtActiverScanner.Text == "1")
                    chx_ActiverScanner.Checked = true;
                else
                    chx_ActiverScanner.Checked = false;
                cbTypeScanner.Text = row["TYPESCANNER"].ToString();
                txtActiverBarriere.Text = row["ACTIVER_BARRIERE"].ToString();
                if (txtActiverBarriere.Text == "1")
                    chx_ActiverBarriere.Checked = true;
                else
                    chx_ActiverBarriere.Checked = false;
                txtCOMBarriere.Text = row["NUMPORTCOM_BARRIERE"].ToString();
                txtCOMScanner.Text = row["NUMPORTCOM_SCANNER"].ToString();
                txtContact1.Text = row["CONTACT1"].ToString();
                txtContact2.Text = row["CONTACT2"].ToString();
                txtContact3.Text = row["CONTACT3"].ToString();
            }
        }

        private void Disable()
        {
            txtDateCreation.Enabled = false;
            txtDesignation.Enabled = false;
            cbWeight_SettingsId.Enabled = false;
            cbWeighing_SettingsId.Enabled = false;
            txtCOM.Enabled = false;
            txtActiverPoids.Enabled = false;
            chx_ActiverPoids.Enabled = false;
            chx_ActiverMultipleParam.Enabled = false;
            txtMin.Enabled = false;
            cbBaudRate.Enabled = false;
            cbDataBits.Enabled = false;
            cbStopBits.Enabled = false;
            cbHandshake.Enabled = false;
            txtReadTimeOut.Enabled = false;
            txtMachine.Enabled = false;
            cbDemarrage.Enabled = false;
            cbUtilisateurId.Enabled = false;
            dgvFirmes.Enabled = false;
            lblAddDgvChauffeurs.Enabled = false;
            lbActualiserDgvChauffeurs.Enabled = false;
            lblRetirerDgvChauffeurs.Enabled = false;
            cbBornePremierePesee.Enabled = false;
            cbBorneDeuxiemePesee.Enabled = false;
            cbBorneTareManuelle.Enabled = false;
            cbFlux_Default.Enabled = false;
            chx_ActiverScanner.Enabled = false;
            cbTypeScanner.Enabled = false;
            chx_ActiverBarriere.Enabled = false;
            txtCOMBarriere.Enabled = false;
            txtCOMScanner.Enabled = false;
            txtContact1.Enabled = false;
            txtContact2.Enabled = false;
            txtContact3.Enabled = false;    
            pbUpdating.Visible = false;

            vg_IsEnabled = false;
        }

        private void Enable()
        {
            txtDateCreation.Enabled = true;
            txtDesignation.Enabled = true;
            cbWeight_SettingsId.Enabled = true;
            cbWeighing_SettingsId.Enabled = true;
            txtCOM.Enabled = true;
            txtActiverPoids.Enabled = true;
            chx_ActiverPoids.Enabled = true;
            txtMin.Enabled = true;
            chx_ActiverMultipleParam.Enabled = true;
            cbBaudRate.Enabled = true;
            cbDataBits.Enabled = true;
            cbStopBits.Enabled = true;
            cbHandshake.Enabled = true;
            txtReadTimeOut.Enabled = true;
            txtMachine.Enabled = true;
            cbDemarrage.Enabled = true;
            cbUtilisateurId.Enabled = true;
            dgvFirmes.Enabled = true;
            lblAddDgvChauffeurs.Enabled = true;
            lbActualiserDgvChauffeurs.Enabled = true;
            lblRetirerDgvChauffeurs.Enabled = true;
            cbBornePremierePesee.Enabled = true;
            cbBorneDeuxiemePesee.Enabled = true;
            cbBorneTareManuelle.Enabled = true;
            cbFlux_Default.Enabled = true;
            chx_ActiverScanner.Enabled = true;
            cbTypeScanner.Enabled = true;
            chx_ActiverBarriere.Enabled = true;
            txtCOMBarriere.Enabled = true;
            txtCOMScanner.Enabled = true;
            txtContact1.Enabled = true;
            txtContact2.Enabled = true; 
            txtContact3.Enabled = true;
            pbUpdating.Visible = true;

            vg_IsEnabled = true;
        }

        private void Clear()
        {
            txtId.Text = "";
            txtDateCreation.Text = "";
            txtDesignation.Text = "";
            cbWeight_SettingsId.Text = "";
            cbWeighing_SettingsId.Text = "";
            txtCOM.Text = "";
            txtActiverPoids.Text = "";
            txtMin.Text = "";
            chx_ActiverPoids.Checked = false;
            txtActiverMultipleParam.Text = "";
            chx_ActiverMultipleParam.Checked = false;
            cbBaudRate.Text = "";
            cbDataBits.Text = "";
            cbStopBits.Text = "";
            cbHandshake.Text = "";
            txtReadTimeOut.Text = "";
            txtMachine.Text = "";
            cbDemarrage.Text = "";
            cbUtilisateurId.Text = "";
            cbBornePremierePesee.Text = "";
            cbBorneDeuxiemePesee.Text = "";
            cbBorneTareManuelle.Text = "";
            cbFlux_Default.Text = "";
            txtActiverScanner.Text = "";
            chx_ActiverScanner.Checked = false;
            txtActiverBarriere.Text = "";
            chx_ActiverBarriere.Checked = false;
            txtCOMBarriere.Text = "";
            txtCOMScanner.Text = "";
            cbTypeScanner.Text = "";
            txtContact1.Text = "";
            txtContact2.Text = "";
            txtContact3.Text = "";
        }

        private void Bind_DgvFirmes()
        {
            PontFirme pontFirme = new PontFirme();
            if (txtId.Text == "")
            {
                dgvFirmes.DataSource = pontFirme.FindByPontId(-1);
            }
            else
            {
                int Id;
                bool IsParsableId;
                IsParsableId = Int32.TryParse(txtId.Text, out Id);
                dgvFirmes.DataSource = pontFirme.FindByPontId(Id);
            }

            dgvFirmes.Columns[0].Visible = false;
            dgvFirmes.Columns["FIRME"].Visible = true;
            dgvFirmes.Columns["PONTID"].Visible = false;
            dgvFirmes.Columns["PONT"].Visible = false;
            dgvFirmes.Columns["DATECREATION"].Visible = false;

            dgvFirmes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFirmes.ReadOnly = true;

        }

        private void Localize_DgvFirmes(string lang)
        {
            if (lang == "fr")
            {
                dgvFirmes.Columns["PONT"].HeaderText = "PONT";
                dgvFirmes.Columns["FIRME"].HeaderText = "FIRME";
                dgvFirmes.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            }

            if (lang == "en")
            {
                dgvFirmes.Columns["PONT"].HeaderText = "WEIGHBRIDGE";
                dgvFirmes.Columns["FIRME"].HeaderText = "FIRM";
                dgvFirmes.Columns["DATECREATION"].HeaderText = "CREATION DATE";
            }

            if (lang == "es")
            {
                dgvFirmes.Columns["PONT"].HeaderText = "PUENTE";
                dgvFirmes.Columns["FIRME"].HeaderText = "FIRMA";
                dgvFirmes.Columns["DATECREATION"].HeaderText = "FECHA DE CREACIÓN";
            }
        }

        private void Refresh_DgvFirmes()
        {
            int Id;
            bool IsParsableId;
            PontFirme pontFirme = new PontFirme();
            IsParsableId = Int32.TryParse(txtId.Text, out Id);
            dgvFirmes.DataSource = pontFirme.FindByPontId(Id);
        }

        private void chx_ActiverPoids_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_ActiverPoids.Checked)
                txtActiverPoids.Text = "1";
            else
                txtActiverPoids.Text = "0";
        }

        private void lbAjouter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtId.Text == "" && txtDateCreation.Text == "" && txtDesignation.Text != "" && cbWeight_SettingsId.Text != "" && cbWeighing_SettingsId.Text != "" && txtCOM.Text != "" && txtActiverPoids.Text != ""
                    && cbBaudRate.Text != "" && cbDataBits.Text != "" && cbStopBits.Text != "" && cbHandshake.Text != "" && txtReadTimeOut.Text != "" && txtActiverMultipleParam.Text != "" && txtMin.Text != "" && txtMachine.Text != "" && cbDemarrage.Text != ""
                    && txtActiverScanner.Text != "" && txtActiverBarriere.Text != "")
                {
                    int ActiverPoids;
                    int ActiverMultipleParam;
                    int BaudRate;
                    int DataBits;
                    int ReadTimeOut;
                    int PoidsDetection;
                    int ActiverScanner;
                    int ActiverBarriere;
                    bool IsParsableActiverPoids;
                    bool IsParsableBaudRate;
                    bool IsParsableDataBits;
                    bool IsParsableReadTimeOut;
                    bool IsParsableActiverMultipleParam;
                    bool IsParsablePoidsDetection;
                    bool IsParsableActiverScanner;
                    bool IsParsableActiverBarriere;
                    IsParsableActiverPoids = Int32.TryParse(txtActiverPoids.Text, out ActiverPoids);
                    IsParsableBaudRate = Int32.TryParse(cbBaudRate.Text, out BaudRate);
                    IsParsableDataBits = Int32.TryParse(cbDataBits.Text, out DataBits);
                    IsParsableReadTimeOut = Int32.TryParse(txtReadTimeOut.Text, out ReadTimeOut);
                    IsParsableActiverMultipleParam = Int32.TryParse(txtActiverMultipleParam.Text, out ActiverMultipleParam);
                    IsParsablePoidsDetection = Int32.TryParse(txtMin.Text, out PoidsDetection);
                    IsParsableActiverScanner = Int32.TryParse(txtActiverScanner.Text, out ActiverScanner);
                    IsParsableActiverBarriere = Int32.TryParse(txtActiverBarriere.Text, out ActiverBarriere);
                    try
                    {
                        if (IsParsableActiverPoids && IsParsableBaudRate && IsParsableDataBits && IsParsableReadTimeOut && IsParsableActiverMultipleParam && IsParsablePoidsDetection && IsParsableActiverScanner && IsParsableActiverBarriere)
                        {
                            Pont pont = new Pont();
                            pont.Add(txtDesignation.Text, txtCOM.Text, Common_functions.CbSelectedValue_Convert_Int(cbWeight_SettingsId), Common_functions.CbSelectedValue_Convert_Int(cbWeighing_SettingsId), ActiverPoids, BaudRate, DataBits, cbStopBits.Text,
                                 cbHandshake.Text, ReadTimeOut, txtMachine.Text, cbDemarrage.Text, Common_functions.CbSelectedValue_Convert_Int(cbUtilisateurId), ActiverMultipleParam, PoidsDetection, cbBornePremierePesee.Text, cbBorneDeuxiemePesee.Text
                                 , cbBorneTareManuelle.Text, cbFlux_Default.Text, ActiverScanner, cbTypeScanner.Text, ActiverBarriere, txtCOMBarriere.Text, txtCOMScanner.Text, txtContact1.Text, txtContact2.Text, txtContact3.Text, 0);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Pont ajouté avec succès", "Pont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Weighbridge added successfully", "Weighbridge", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Puente agregado", "Puente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        Custom_MessageBox.Show("FR", "Informations incomplètes", "Pont", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "Incomplete informations", "Weighbridge", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    lbModifier.Text = Language_Manager.Localize("Valider", cbLang.Text);
                    vg_Update = true;
                }
                else
                {
                    try
                    {
                        if (txtId.Text != "" && txtDateCreation.Text != "" && txtDesignation.Text != "" && cbWeight_SettingsId.Text != "" && cbWeighing_SettingsId.Text != "" && txtCOM.Text != "" && txtActiverPoids.Text != ""
                             && cbBaudRate.Text != "" && cbDataBits.Text != "" && cbStopBits.Text != "" && cbHandshake.Text != "" && txtReadTimeOut.Text != "" && txtActiverMultipleParam.Text != "" && txtMin.Text != "" && txtMachine.Text != "" && cbDemarrage.Text != ""
                             && txtActiverScanner.Text != "" && txtActiverBarriere.Text != "")
                        {
                            int Id;
                            int ActiverPoids;
                            int ActiverMultipleParam;
                            int BaudRate;
                            int DataBits;
                            int ReadTimeOut;
                            int PoidsDetection;
                            int ActiverScanner;
                            int ActiverBarriere;
                            bool IsParsableId;
                            bool IsParsableActiverPoids;
                            bool IsParsableBaudRate;
                            bool IsParsableDataBits;
                            bool IsParsableReadTimeOut;
                            bool IsParsableActiverMultipleParam;
                            bool IsParsablePoidsDetection;
                            bool IsParsableActiverScanner;
                            bool IsParsableActiverBarriere;
                            IsParsableId = Int32.TryParse(txtId.Text, out Id);
                            IsParsableActiverPoids = Int32.TryParse(txtActiverPoids.Text, out ActiverPoids);
                            IsParsableBaudRate = Int32.TryParse(cbBaudRate.Text, out BaudRate);
                            IsParsableDataBits = Int32.TryParse(cbDataBits.Text, out DataBits);
                            IsParsableReadTimeOut = Int32.TryParse(txtReadTimeOut.Text, out ReadTimeOut);
                            IsParsableActiverMultipleParam = Int32.TryParse(txtActiverMultipleParam.Text, out ActiverMultipleParam);
                            IsParsablePoidsDetection = Int32.TryParse(txtMin.Text, out PoidsDetection);
                            IsParsableActiverScanner = Int32.TryParse(txtActiverScanner.Text, out ActiverScanner);
                            IsParsableActiverBarriere = Int32.TryParse(txtActiverBarriere.Text, out ActiverBarriere);
                            try
                            {
                                if (IsParsableActiverPoids && IsParsableBaudRate && IsParsableDataBits && IsParsableReadTimeOut && IsParsableActiverMultipleParam && IsParsablePoidsDetection && IsParsableActiverScanner && IsParsableActiverBarriere)
                                {
                                    Pont pont = new Pont();
                                    pont.Update(Id, txtDesignation.Text, txtCOM.Text, Common_functions.CbSelectedValue_Convert_Int(cbWeight_SettingsId), Common_functions.CbSelectedValue_Convert_Int(cbWeighing_SettingsId), ActiverPoids, BaudRate, DataBits, cbStopBits.Text,
                                         cbHandshake.Text, ReadTimeOut, txtMachine.Text, cbDemarrage.Text, Common_functions.CbSelectedValue_Convert_Int(cbUtilisateurId), ActiverMultipleParam, PoidsDetection, cbBornePremierePesee.Text, cbBorneDeuxiemePesee.Text
                                 , cbBorneTareManuelle.Text, cbFlux_Default.Text, ActiverScanner, cbTypeScanner.Text, ActiverBarriere, txtCOMBarriere.Text, txtCOMScanner.Text, txtContact1.Text, txtContact2.Text, txtContact3.Text, 0);
                                    if (cbLang.Text == "FR")
                                        Custom_MessageBox.Show("FR", "Pont modifié avec succès", "Pont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else if (cbLang.Text == "EN")
                                        Custom_MessageBox.Show("EN", "Weighbridge updated successfully", "Weighbridge", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                Custom_MessageBox.Show("FR", "Informations incomplètes", "Pont", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Incomplete informations", "Weighbridge", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas supprimer l'enregistrement tant que la modification n'est pas validée", "Pont", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You can't delete this record before the update is completed", "Weighbridge", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    Custom_MessageBox.Show("ES", "No puede eliminar el registro hasta que se confirme el cambio", "Puente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Pont pont = new Pont();
                    int Id;
                    bool IsParsableId;
                    IsParsableId = Int32.TryParse(txtId.Text, out Id);
                    if (IsParsableId)
                    {
                        DialogResult result;
                        if (cbLang.Text == "FR")
                            result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir supprimer cet enregistrement?", "Pont", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else if (cbLang.Text == "EN")
                            result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "Weighbridge", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else
                            result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Puente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            pont.Delete(Id);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Pont supprimé avec succès", "Pont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Weighbridge deleted successfully", "Weighbridge", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void PontDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vg_Mode == "Edit")
            {
                if (pbUpdating.Visible)
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Vous ne pouvez pas fermer la fenetre tant que la modification n'est pas validée", "Pont", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "You can't close this window before the update is completed", "Weighbridge", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                language_Manager.ChangeLanguage("fr", this, typeof(PontDetail));

            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(PontDetail));
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(PontDetail));
            }
        }

        private void lblAddDgvChauffeurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Form form = new PontFirmeDetail(vg_Id);
                form.Show();
            }
            catch
            {
                throw;
            }
        }

        private void lbActualiserDgvChauffeurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Refresh_DgvFirmes();
        }

        private void lblRetirerDgvChauffeurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Int32[] selectedIds = new Int32[Common_functions.GetDatagridViewSelectedRowsId(dgvFirmes).Length];
            selectedIds = Common_functions.GetDatagridViewSelectedRowsId(dgvFirmes);
            if (Common_functions.GetDatagridViewSelectedRowsId(dgvFirmes).Length > 0)
            {
                for (int i = 0; i < Common_functions.GetDatagridViewSelectedRowsId(dgvFirmes).Length; i++)
                {
                    try
                    {
                        PontFirme pontFirme = new PontFirme();
                        pontFirme.Delete(vg_Id, selectedIds[i]);
                    }
                    catch
                    {
                        throw;
                    }
                }
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", Common_functions.GetDatagridViewSelectedRowsId(dgvFirmes).Length + " firme(s) supprimé(s)", "Firme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", Common_functions.GetDatagridViewSelectedRowsId(dgvFirmes).Length + " firm(s) deleted", "Firm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    Custom_MessageBox.Show("ES", Common_functions.GetDatagridViewSelectedRowsId(dgvFirmes).Length + " firma(s) añadido(s)", "Firma", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Refresh_DgvFirmes();
            }
            else
            {

                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Aucun enregistrement sélectionné", "Firme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "No rows selected", "Firm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Firma", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void chx_ActiverMultipleParam_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_ActiverMultipleParam.Checked)
                txtActiverMultipleParam.Text = "1";
            else
                txtActiverMultipleParam.Text = "0";
        }

        private void chx_ActiverScanner_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_ActiverScanner.Checked)
                txtActiverScanner.Text = "1";
            else
                txtActiverScanner.Text = "0";
        }

        private void chx_ActiverBarriere_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_ActiverBarriere.Checked)
                txtActiverBarriere.Text = "1";
            else
                txtActiverBarriere.Text = "0";
        }
    }
}
