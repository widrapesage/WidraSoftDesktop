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
            if (txtId.Text == "" && txtDateCreation.Text == "" && cbWeight_SettingsId.Text == "" && txtCOM.Text == "" && txtActiverPoids.Text == "" && cbBaudRate.Text == "" && cbDataBits.Text == ""
                && cbStopBits.Text == "" && cbHandshake.Text == "" && txtReadTimeOut.Text == "")
            {
                lbModifier.Enabled = false;
                lbModifier.BackColor = Color.Transparent;
                lbSupprimer.Enabled = false;
                lbSupprimer.BackColor = Color.Transparent;
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
                if (row["BAUDRATE"] is System.DBNull)
                    cbBaudRate.SelectedValue = "";
                else
                    cbBaudRate.SelectedValue = (int)row["BAUDRATE"];
                if (row["DATABITS"] is System.DBNull)
                    cbDataBits.SelectedValue = "";
                else
                    cbDataBits.SelectedValue = (int)row["DATABITS"];
                if (row["STOPBITS"] is System.DBNull)
                    cbDataBits.SelectedValue = "";
                else
                    cbDataBits.SelectedValue = row["STOPBITS"].ToString();
                if (row["HANDSHAKE"] is System.DBNull)
                    cbHandshake.SelectedValue = "";
                else
                    cbHandshake.SelectedValue = row["HANDSHAKE"].ToString();

                txtCOM.Text = row["NUMPORTCOM"].ToString();
                txtActiverPoids.Text = row["ACTIVERPOIDS"].ToString();
                if (txtActiverPoids.Text == "1")
                    chx_ActiverPoids.Checked = true;
                else
                    chx_ActiverPoids.Checked = false;
                txtReadTimeOut.Text = row["READTIMEOUT"].ToString();
            }
        }

        private void Disable()
        {
            txtDateCreation.Enabled = false;
            txtDesignation.Enabled = false;
            cbWeight_SettingsId.Enabled = false;
            txtCOM.Enabled = false;
            txtActiverPoids.Enabled = false;
            chx_ActiverPoids.Enabled = false;
            cbBaudRate.Enabled = false;
            cbDataBits.Enabled = false;
            cbStopBits.Enabled = false;
            cbHandshake.Enabled = false;
            txtReadTimeOut.Enabled = false;           
            pbUpdating.Visible = false;

            vg_IsEnabled = false;
        }

        private void Enable()
        {
            txtDateCreation.Enabled = true;
            txtDesignation.Enabled = true;
            cbWeight_SettingsId.Enabled = true;
            txtCOM.Enabled = true;
            txtActiverPoids.Enabled = true;
            chx_ActiverPoids.Enabled = true;
            cbBaudRate.Enabled = true;
            cbDataBits.Enabled = true;
            cbStopBits.Enabled = true;
            cbHandshake.Enabled = true;
            txtReadTimeOut.Enabled = true;
            pbUpdating.Visible = true;

            vg_IsEnabled = true;
        }

        private void Clear()
        {
            txtId.Text = "";
            txtDateCreation.Text = "";
            txtDesignation.Text = "";
            cbWeight_SettingsId.Text = "";
            txtCOM.Text = "";
            txtActiverPoids.Text = "";
            chx_ActiverPoids.Checked = false;
            cbBaudRate.Text = "";
            cbDataBits.Text = "";
            cbStopBits.Text = "";
            cbHandshake.Text = "";
            txtReadTimeOut.Text = "";
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
                if (txtId.Text == "" && txtDateCreation.Text == "" && txtDesignation.Text != "" && cbWeight_SettingsId.Text != "" && txtCOM.Text != "" && txtActiverPoids.Text != ""
                    && cbBaudRate.Text != "" && cbDataBits.Text != "" && cbStopBits.Text != "" && cbHandshake.Text != "" && txtReadTimeOut.Text != "")
                {
                    int ActiverPoids;
                    int BaudRate;
                    int DataBits;
                    int ReadTimeOut;
                    bool IsParsableActiverPoids;
                    bool IsParsableBaudRate;
                    bool IsParsableDataBits;
                    bool IsParsableReadTimeOut;
                    IsParsableActiverPoids = Int32.TryParse(txtActiverPoids.Text, out ActiverPoids);
                    IsParsableBaudRate = Int32.TryParse(cbBaudRate.Text, out BaudRate);
                    IsParsableDataBits = Int32.TryParse(cbDataBits.Text, out DataBits);
                    IsParsableReadTimeOut = Int32.TryParse(txtReadTimeOut.Text, out ReadTimeOut);
                    try
                    {
                        if (IsParsableActiverPoids && IsParsableBaudRate && IsParsableDataBits && IsParsableReadTimeOut)
                        {
                            Pont pont = new Pont();
                            pont.Add(txtDesignation.Text, txtCOM.Text, Common_functions.CbSelectedValue_Convert_Int(cbWeight_SettingsId), ActiverPoids, BaudRate, DataBits, cbStopBits.Text,
                                 cbHandshake.Text, ReadTimeOut);
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
                        Custom_MessageBox.Show("FR", "Informations incomplètes", "Pont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "Incomplete informations", "Weighbridge", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES", "Información incompleta", "Puente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (txtId.Text != "" && txtDateCreation.Text != "" && txtDesignation.Text != "" && cbWeight_SettingsId.Text != "" && txtCOM.Text != "" && txtActiverPoids.Text != ""
                             && cbBaudRate.Text != "" && cbDataBits.Text != "" && cbStopBits.Text != "" && cbHandshake.Text != "" && txtReadTimeOut.Text != "")
                        {
                            int Id;
                            int ActiverPoids;
                            int BaudRate;
                            int DataBits;
                            int ReadTimeOut;
                            bool IsParsableId;
                            bool IsParsableActiverPoids;
                            bool IsParsableBaudRate;
                            bool IsParsableDataBits;
                            bool IsParsableReadTimeOut;
                            IsParsableId = Int32.TryParse(txtId.Text, out Id);
                            IsParsableActiverPoids = Int32.TryParse(txtActiverPoids.Text, out ActiverPoids);
                            IsParsableBaudRate = Int32.TryParse(cbBaudRate.Text, out BaudRate);
                            IsParsableDataBits = Int32.TryParse(cbDataBits.Text, out DataBits);
                            IsParsableReadTimeOut = Int32.TryParse(txtReadTimeOut.Text, out ReadTimeOut);
                            try
                            {
                                if (IsParsableActiverPoids && IsParsableBaudRate && IsParsableDataBits && IsParsableReadTimeOut)
                                {
                                    Pont pont = new Pont();
                                    pont.Update(Id, txtDesignation.Text, txtCOM.Text, Common_functions.CbSelectedValue_Convert_Int(cbWeight_SettingsId), ActiverPoids, BaudRate, DataBits, cbStopBits.Text,
                                         cbHandshake.Text, ReadTimeOut);
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
                                Custom_MessageBox.Show("FR", "Informations incomplètes", "Pont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Incomplete informations", "Weighbridge", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Información incompleta", "Puente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas supprimer l'enregistrement tant que la modification n'est pas validée", "Pont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You can't delete this record before the update is completed", "Weighbridge", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    Custom_MessageBox.Show("ES", "No puede eliminar el registro hasta que se confirme el cambio", "Puente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
