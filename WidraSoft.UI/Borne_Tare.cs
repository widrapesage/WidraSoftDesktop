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
    public partial class Borne_Tare : Form
    {
        string vg_Lang;
        int vg_PontId;
        bool vg_Demander_Parametre;
        int vg_P;
        string Flux_Default;
        public Borne_Tare(string lang, int PontId, bool Demander_Paramatre, int P)
        {
            InitializeComponent();
            vg_Lang = lang;
            vg_PontId = PontId;
            vg_Demander_Parametre = Demander_Paramatre;
            vg_P = P;

        }

        private void bt_1_Click(object sender, EventArgs e)
        {
            if (txtPoids.Text.Length < 6)
                txtPoids.Text = txtPoids.Text + "1";
        }

        private void bt_2_Click(object sender, EventArgs e)
        {
            if (txtPoids.Text.Length < 6)
                txtPoids.Text = txtPoids.Text + "2";
        }

        private void bt_3_Click(object sender, EventArgs e)
        {
            if (txtPoids.Text.Length < 6)
                txtPoids.Text = txtPoids.Text + "3";
        }

        private void bt_4_Click(object sender, EventArgs e)
        {
            if (txtPoids.Text.Length < 6)
                txtPoids.Text = txtPoids.Text + "4";
        }

        private void bt_5_Click(object sender, EventArgs e)
        {
            if (txtPoids.Text.Length < 6)
                txtPoids.Text = txtPoids.Text + "5";
        }

        private void bt_6_Click(object sender, EventArgs e)
        {
            if (txtPoids.Text.Length < 6)
                txtPoids.Text = txtPoids.Text + "6";
        }

        private void bt_7_Click(object sender, EventArgs e)
        {
            if (txtPoids.Text.Length < 6)
                txtPoids.Text = txtPoids.Text + "7";
        }

        private void bt_8_Click(object sender, EventArgs e)
        {
            if (txtPoids.Text.Length < 6)
                txtPoids.Text = txtPoids.Text + "8";
        }

        private void bt_9_Click(object sender, EventArgs e)
        {
            if (txtPoids.Text.Length < 6)
                txtPoids.Text = txtPoids.Text + "9";
        }

        private void bt_0_Click(object sender, EventArgs e)
        {
            if (txtPoids.Text.Length < 6)
                txtPoids.Text = txtPoids.Text + "0";
        }

        private void btEffacer_Click(object sender, EventArgs e)
        {
            if (txtPoids.Text.Length > 0)
            {
                txtPoids.Text = txtPoids.Text.Remove(txtPoids.Text.Length - 1);
            }
        }

        private void Borne_Tare_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            WindowState = FormWindowState.Maximized;

            if (vg_Lang == "fr")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(Borne_Tare));
            }

            if (vg_Lang == "en")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(Borne_Tare));
            }

            if (vg_Lang == "es")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(Borne_Tare));
            }

            Pont pont = new Pont();
            Flux_Default = pont.GetFluxDefault(vg_PontId);

            txtPoids.Text = "";
        }

        private void btAnnuler_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btValider_Click(object sender, EventArgs e)
        {
            if (txtPoids.Text.Length >= 2)
            {
                int Poids;
                bool IsParsablePoids = Int32.TryParse(txtPoids.Text, out Poids);
                if (Poids > 0)
                {
                    Form form = new Borne_ChoixFlux(vg_Lang, vg_PontId, vg_Demander_Parametre, -1, vg_P, Poids, Flux_Default, -1, -1);
                    form.Show();
                    Close();
                }
            }
        }
    }
}
