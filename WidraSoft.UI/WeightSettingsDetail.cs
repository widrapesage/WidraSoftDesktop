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
    public partial class WeightSettingsDetail : Form
    {
        String vg_Mode = "";
        Int32 vg_Id = 0;
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;
        public WeightSettingsDetail(String Mode, Int32 Id)
        {
            InitializeComponent();
            vg_Mode = Mode;
            vg_Id = Id;
        }

        private void WeightSettingsDetail_Load(object sender, EventArgs e)
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

            cbModeLecture.DataSource = Values.WeightSettigs_ModeLecture;
            cbModeLecture.ValueMember = null;
            cbModeLecture.DisplayMember = Values.WeightSettigs_ModeLecture[0].ToString();

            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = MenuGeneral.languuage_index;
        }

        private void Add_Item()
        {
            if (txtId.Text == "" && txtDateCreation.Text == "" && txtDesignation.Text == "" && txtTimerInterval.Text == "" && txtLongueurMinChaine.Text == "" && txtPositionDebut.Text == "" && txtLongueurChaine.Text == ""
                && txtCaractereSeparation.Text == "" && cbModeLecture.Text == "" && txtStabilite.Text == "" && txtPositionStabilite.Text == "" && txtValeurStable.Text == "" && txtNegatif.Text == "" 
                && txtPositionNegatif.Text == "" && txtValeurNegatif.Text == "")
            {
                lbModifier.Enabled = false;
                lbModifier.BackColor = Color.Transparent;
                lbSupprimer.Enabled = false;
                lbSupprimer.BackColor = Color.Transparent;

                txtStabilite.Text = "0";
                chx_Stabilite.Checked = false;
                txtNegatif.Text = "0";
                chx_Negatif.Checked = false;
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
            WeightSettings weightSettings = new WeightSettings();
            dt = weightSettings.FindById(vg_Id);
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["WEIGHT_SETTINGSID"];
                txtId.Text = Id.ToString();
                txtDateCreation.Text = row["DATECREATION"].ToString();
                txtDesignation.Text = row["DESIGNATION"].ToString();
                txtTimerInterval.Text = row["TIMERINTERVAL"].ToString();
                txtLongueurMinChaine.Text = row["LONGUEURMINCHAINE"].ToString();
                txtPositionDebut.Text = row["POSITIONDEBUT"].ToString();
                txtLongueurChaine.Text = row["LONGUEURCHAINE"].ToString();
                txtCaractereSeparation.Text = row["CARACTERESEPARATION"].ToString();
                cbModeLecture.Text = row["MODELECTURE"].ToString();
                txtStabilite.Text = row["STABILITE"].ToString();
                if (txtStabilite.Text == "1")
                    chx_Stabilite.Checked = true;
                else
                    chx_Stabilite.Checked = false;
                txtPositionStabilite.Text = row["POSITIONSTABILTE"].ToString();
                txtValeurStable.Text = row["VALEURSTABLE"].ToString();
                txtNegatif.Text = row["NEGATIF"].ToString();
                if (txtNegatif.Text == "1")
                    chx_Negatif.Checked = true;
                else
                    chx_Negatif.Checked = false;
                txtPositionNegatif.Text = row["POSITIONNEGATIF"].ToString();
                txtValeurNegatif.Text = row["VALEURNEGATIF"].ToString();
            }
        }

        private void Disable()
        {
            txtDateCreation.Enabled = false;
            txtDesignation.Enabled = false;
            txtTimerInterval.Enabled = false;
            txtLongueurMinChaine.Enabled = false;
            txtPositionDebut.Enabled = false;
            txtLongueurChaine.Enabled = false;
            txtCaractereSeparation.Enabled = false;
            cbModeLecture.Enabled = false;
            chx_Stabilite.Enabled = false;
            txtPositionStabilite.Enabled = false;
            txtValeurStable.Enabled = false;
            chx_Negatif.Enabled = false;
            txtPositionNegatif.Enabled = false;
            txtValeurNegatif.Enabled = false;
            pbUpdating.Visible = false;

            vg_IsEnabled = false;
        }

        private void Enable()
        {
            txtDateCreation.Enabled = true;
            txtDesignation.Enabled = true;
            txtTimerInterval.Enabled = true;
            txtLongueurMinChaine.Enabled = true;
            txtPositionDebut.Enabled = true;
            txtLongueurChaine.Enabled = true;
            txtCaractereSeparation.Enabled = true;
            cbModeLecture.Enabled = true;
            chx_Stabilite.Enabled = true;
            txtPositionStabilite.Enabled = true;
            txtValeurStable.Enabled = true;
            chx_Negatif.Enabled = true;
            txtPositionNegatif.Enabled = true;
            txtValeurNegatif.Enabled = true;
            pbUpdating.Visible = true;

            vg_IsEnabled = true;
        }

        private void Clear()
        {
            txtId.Text = "";
            txtDateCreation.Text = "";
            txtDesignation.Text = "";
            txtTimerInterval.Text = "";
            txtLongueurMinChaine.Text = "";
            txtPositionDebut.Text = "";
            txtLongueurChaine.Text = "";
            txtCaractereSeparation.Text = "";
            cbModeLecture.Text = "";
            chx_Stabilite.Checked = false;
            txtPositionStabilite.Text = "";
            txtValeurStable.Text = "";
            chx_Negatif.Text = "";
            txtPositionNegatif.Text = "";
            txtValeurNegatif.Text = "";
        }

        private void chx_Stabilite_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Stabilite.Checked)
                txtStabilite.Text = "1";
            else
                txtStabilite.Text = "0";
        }

        private void chx_Negatif_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Negatif.Checked)
                txtNegatif.Text = "1";
            else
                txtNegatif.Text = "0";
        }

        private void lbAjouter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtId.Text == "" && txtDateCreation.Text == "" && txtDesignation.Text != "" && txtTimerInterval.Text != "" && txtLongueurMinChaine.Text != "" && txtPositionDebut.Text != ""
                    && txtLongueurChaine.Text != "" && txtCaractereSeparation.Text != "" && cbModeLecture.Text != "" && txtStabilite.Text != "" && txtNegatif.Text != "")
                {
                    if (txtPositionNegatif.Text == "") txtPositionNegatif.Text = "0";
                    if (txtPositionStabilite.Text == "") txtPositionStabilite.Text = "0";

                    int TimerInterval;
                    int LongueurMinChaine;
                    int PositionDebut;
                    int LongueurChaine;
                    int Stabilite;
                    int PositionStabilite;
                    int Negatif;
                    int PositionNegatif;

                    bool IsParsableTimerInterval;
                    bool IsParsableLongueurMinChaine;
                    bool IsParsablePositionDebut;
                    bool IsParsableLongueurChaine;
                    bool IsParsableStabilite;
                    bool IsParsablePositionStabilite;
                    bool IsParsableNegatif;
                    bool IsParsablePositionNegatif;

                    IsParsableTimerInterval = Int32.TryParse(txtTimerInterval.Text, out TimerInterval);
                    IsParsableLongueurMinChaine = Int32.TryParse(txtLongueurMinChaine.Text, out LongueurMinChaine);
                    IsParsablePositionDebut = Int32.TryParse(txtPositionDebut.Text, out PositionDebut);
                    IsParsableLongueurChaine = Int32.TryParse(txtLongueurChaine.Text, out LongueurChaine);
                    IsParsableStabilite = Int32.TryParse(txtStabilite.Text, out Stabilite);
                    IsParsablePositionStabilite = Int32.TryParse(txtPositionStabilite.Text, out PositionStabilite);
                    IsParsableNegatif = Int32.TryParse(txtNegatif.Text, out Negatif);
                    IsParsablePositionNegatif = Int32.TryParse(txtPositionNegatif.Text, out PositionNegatif);
                    try
                    {
                        if (IsParsableTimerInterval && IsParsableLongueurMinChaine && IsParsablePositionDebut && IsParsableLongueurChaine && IsParsableStabilite 
                            && IsParsablePositionStabilite && IsParsableNegatif && IsParsablePositionNegatif)
                        {
                            WeightSettings weightSettings = new WeightSettings();
                            weightSettings.Add(txtDesignation.Text, TimerInterval, LongueurMinChaine, PositionDebut, LongueurChaine, txtCaractereSeparation.Text, cbModeLecture.Text,
                                Stabilite, PositionStabilite, txtValeurStable.Text, Negatif, PositionNegatif, txtValeurNegatif.Text);
                                 
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Paramètre ajouté avec succès", "Paramètres poids", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Setting added successfully", "Weight settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Parámetro agregado", "Parámetro de peso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        Custom_MessageBox.Show("FR", "Informations incomplètes", "Paramètres poids", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "Incomplete informations", "Weight settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES", "Información incompleta", "Parámetro de peso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (txtId.Text != "" && txtDateCreation.Text != "" && txtDesignation.Text != "" && txtTimerInterval.Text != "" && txtLongueurMinChaine.Text != "" && txtPositionDebut.Text != ""
                            && txtLongueurChaine.Text != "" && txtCaractereSeparation.Text != "" && cbModeLecture.Text != "" && txtStabilite.Text != "" && txtNegatif.Text != "")
                        {
                            if (txtPositionNegatif.Text == "") txtPositionNegatif.Text = "0";
                            if (txtPositionStabilite.Text == "") txtPositionStabilite.Text = "0";

                            int Id;
                            int TimerInterval;
                            int LongueurMinChaine;
                            int PositionDebut;
                            int LongueurChaine;
                            int Stabilite;
                            int PositionStabilite;
                            int Negatif;
                            int PositionNegatif;
                            bool IsParsableId;
                            bool IsParsableTimerInterval;
                            bool IsParsableLongueurMinChaine; 
                            bool IsParsablePositionDebut;
                            bool IsParsableLongueurChaine;
                            bool IsParsableStabilite;
                            bool IsParsablePositionStabilite;
                            bool IsParsableNegatif;
                            bool IsParsablePositionNegatif;
                            IsParsableId = Int32.TryParse(txtId.Text, out Id);
                            IsParsableTimerInterval = Int32.TryParse(txtTimerInterval.Text, out TimerInterval);
                            IsParsableLongueurMinChaine = Int32.TryParse(txtLongueurMinChaine.Text, out LongueurMinChaine);
                            IsParsablePositionDebut = Int32.TryParse(txtPositionDebut.Text, out PositionDebut);
                            IsParsableLongueurChaine = Int32.TryParse(txtLongueurChaine.Text, out LongueurChaine);
                            IsParsableStabilite = Int32.TryParse(txtStabilite.Text, out Stabilite);
                            IsParsablePositionStabilite = Int32.TryParse(txtPositionStabilite.Text, out PositionStabilite);
                            IsParsableNegatif = Int32.TryParse(txtNegatif.Text, out Negatif);
                            IsParsablePositionNegatif = Int32.TryParse(txtPositionNegatif.Text, out PositionNegatif);
                            try
                            {
                                if (IsParsableTimerInterval && IsParsableLongueurMinChaine && IsParsablePositionDebut && IsParsableLongueurChaine && IsParsableStabilite
                                     && IsParsablePositionStabilite && IsParsableNegatif && IsParsablePositionNegatif)
                                {
                                    WeightSettings weightSettings = new WeightSettings();
                                    weightSettings.Update(Id, txtDesignation.Text, TimerInterval, LongueurMinChaine, PositionDebut, LongueurChaine, txtCaractereSeparation.Text, cbModeLecture.Text,
                                    Stabilite, PositionStabilite, txtValeurStable.Text, Negatif, PositionNegatif, txtValeurNegatif.Text);
                                    if (cbLang.Text == "FR")
                                        Custom_MessageBox.Show("FR", "Paramètre modifié avec succès", "Paramètres poids", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else if (cbLang.Text == "EN")
                                        Custom_MessageBox.Show("EN", "Setting updated successfully", "Weight settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                        Custom_MessageBox.Show("ES", "Parámetro alterado", "Parámetro de peso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                Custom_MessageBox.Show("FR", "Informations incomplètes", "Paramètres poids", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Incomplete informations", "Weight settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Información incompleta", "Parámetro de peso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas supprimer l'enregistrement tant que la modification n'est pas validée", "Paramètres poids", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You can't delete this record before the update is completed", "Weight settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    Custom_MessageBox.Show("ES", "No puede eliminar el registro hasta que se confirme el cambio", "Parámetro de peso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    WeightSettings weightSettings = new WeightSettings();
                    int Id;
                    bool IsParsableId;
                    IsParsableId = Int32.TryParse(txtId.Text, out Id);
                    if (IsParsableId)
                    {
                        DialogResult result;
                        if (cbLang.Text == "FR")
                            result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir supprimer cet enregistrement?", "Paramètres poids", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else if (cbLang.Text == "EN")
                            result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "Weight settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else
                            result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Parámetro de peso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            weightSettings.Delete(Id);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Paramètre supprimé avec succès", "Paramètres poids", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Setting deleted successfully", "Weight settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Parámetro eliminado", "Parámetro de peso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void WeightSettingsDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vg_Mode == "Edit")
            {
                if (pbUpdating.Visible)
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Vous ne pouvez pas fermer la fenetre tant que la modification n'est pas validée", "Paramètres poids", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "You can't close this window before the update is completed", "Weight settings", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        Custom_MessageBox.Show("ES", "No puede cerrar la página hasta que se valide el cambio", "Parámetro de peso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                language_Manager.ChangeLanguage("fr", this, typeof(WeightSettingsDetail));

            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(WeightSettingsDetail));
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(WeightSettingsDetail));
            }
        }
    }
}
