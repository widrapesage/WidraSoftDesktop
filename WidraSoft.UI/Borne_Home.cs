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
    public partial class Borne_Home : Form
    {
        int vg_PontId;
        string Lang;
        public Borne_Home()
        {
            InitializeComponent();
        }

        private void Borne_Home_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            select_FR.Visible = true;
            select_EN.Visible = false;
            select_ES.Visible = false;
            Language_Manager language_Manager = new Language_Manager();
            Lang = "fr";
            language_Manager.ChangeLanguage(Lang, this, typeof(Borne_Home));

            vg_PontId = GetPontId();
            lbDate.Text = DateTime.Now.ToShortDateString() + ' ' + DateTime.Now.ToShortTimeString();
            timer_Time.Interval = 30000;
            timer_Time.Start();

            lbMessage.Text = "Bienvenue, prêt à peser ...";
            
        }

        private int GetPontId()
        {
            //Pont 
            Pont pont = new Pont();
            DataTable dtPont = pont.FindByMachineName(System.Environment.MachineName);
          
            Int32 pontId = 0;

            if (dtPont.Rows.Count < 1)
            {
                if (select_FR.Visible)
                    Custom_MessageBox.Show("FR", "Aucun pont paramétré pour cette machine, impossible d'effectuer une pesée.", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (select_EN.Visible)
                    Custom_MessageBox.Show("EN", "No weighbridge set for this computer", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Custom_MessageBox.Show("ES", "Ningún puente seleccionado", "Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            else
            {
                if (dtPont.Rows.Count == 1)
                {
                    foreach (DataRow row in dtPont.Rows)
                    {
                        try
                        {
                            pontId = (int)row["PONTID"];
                        }
                        catch { throw; }

                    }
                }
                
            }

            return pontId;
        }

        private bool GetWeighingSettingsType(Int32 PontId)
        {
            Pont pont = new Pont();
            WeighingSettings weighingSettings = new WeighingSettings();

            if (pont.IsMultipleParam(PontId))
            {
                if (weighingSettings.CountNbWeighingSettingsTotal() > 1)
                {
                    return true;
                }
                else if (weighingSettings.CountNbWeighingSettingsTotal() == 1)
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

       
        private void timer_Time_Tick(object sender, EventArgs e)
        {
            lbDate.Text = DateTime.Now.ToShortDateString() + ' ' + DateTime.Now.ToShortTimeString();
        }

        private void France_flag_Click(object sender, EventArgs e)
        {
            select_FR.Visible = true;
            select_EN.Visible = false;
            select_ES.Visible = false;
            Language_Manager language_Manager = new Language_Manager();
            Lang = "fr";
            language_Manager.ChangeLanguage(Lang, this, typeof(Borne_Home));
            lbDate.Text = DateTime.Now.ToShortDateString() + ' ' + DateTime.Now.ToShortTimeString();
        }

        private void France_flag_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void England_flag_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void Spain_flag_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void btAddPont_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void txtPoids_TextChanged(object sender, EventArgs e)
        {
            int P = 0;
            P = Convert.ToInt32(txtPoids.Text);
            if (P > 500)
            {
                Form form = new Borne_ChoixTypePesee(Lang, GetPontId(), GetWeighingSettingsType(GetPontId()), P);
                form.Show();
                txtPoids.Text = "0";
            }
        }

        private void txtPoids_DoubleClick(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Entrez un poids", "Simulateur Poids");
            txtPoids.Text = input;
        }

        private void England_flag_Click(object sender, EventArgs e)
        {
            select_FR.Visible = false;
            select_EN.Visible = true;
            select_ES.Visible = false;
            Language_Manager language_Manager = new Language_Manager();
            Lang = "en";
            language_Manager.ChangeLanguage(Lang, this, typeof(Borne_Home));

            lbDate.Text = DateTime.Now.ToShortDateString() + ' ' + DateTime.Now.ToShortTimeString();
        }

        private void Spain_flag_Click(object sender, EventArgs e)
        {
            select_FR.Visible = false;
            select_EN.Visible = false;
            select_ES.Visible = true;
            Language_Manager language_Manager = new Language_Manager();
            Lang = "es";
            language_Manager.ChangeLanguage(Lang, this, typeof(Borne_Home));

            lbDate.Text = DateTime.Now.ToShortDateString() + ' ' + DateTime.Now.ToShortTimeString();
        }
    }
}
