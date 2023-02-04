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

            cbModeLecture.DataSource = Values.WeightSettigs_ModeLecture;
            cbModeLecture.ValueMember = null;
            cbModeLecture.DisplayMember = Values.WeightSettigs_ModeLecture[0].ToString();

            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = 0;
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
            }
        }

        private void Edit_Item()
        {
            lbAjouter.Enabled = false;
            lbAjouter.BackColor = Color.Transparent;           
            //Disable();
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
                if (row["MODELECTURE"] is System.DBNull)
                    cbModeLecture.SelectedValue = "";
                else
                    cbModeLecture.SelectedValue = (int)row["MODELECTURE"];
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

        
    }
}
