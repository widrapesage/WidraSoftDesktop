using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WidraSoft.BL;

namespace WidraSoft.UI
{
    public partial class Borne_ChoixTypePesee : Form
    {
        string vg_Lang;
        int vg_PontId;
        bool vg_Demander_Paramatre;
        int vg_P;
        int ScanCamionId = -1;

        SerialPort comHoneywell = new SerialPort();
        public Borne_ChoixTypePesee(string Lang, int PontId, bool Demander_Paramatre, int P)
        {
            InitializeComponent();
            vg_Lang = Lang;
            vg_Demander_Paramatre = Demander_Paramatre;
            vg_PontId = PontId;
            vg_P = P;
            
        }

        private void btTareManuelle_Click(object sender, EventArgs e)
        {
            
        }

        private void Borne_ChoixTypePesee_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();



            txtPoids.Text = vg_P.ToString();

            if (vg_Lang == "fr")
            {
                select_FR.Visible = true;
                select_EN.Visible = false;
                select_ES.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(Borne_ChoixTypePesee));
            }

            if (vg_Lang == "en")
            {
                select_FR.Visible = false;
                select_EN.Visible = true;
                select_ES.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(Borne_ChoixTypePesee));
            }

            if (vg_Lang == "es")
            {
                select_FR.Visible = false;
                select_EN.Visible = false;
                select_ES.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(Borne_ChoixTypePesee));
            }

            comHoneywell.PortName = "COM3";
            comHoneywell.ReadTimeout = 1000;
            comHoneywell.BaudRate = 9600;
            comHoneywell.Parity = Parity.None;
            comHoneywell.StopBits = StopBits.One;
            comHoneywell.DataBits = 8;
            comHoneywell.Handshake = Handshake.None;
            try
            {
                //comHoneywell.Open();
            }
            catch
            {
                throw;
            }

            timerHoneywell.Interval = 300;
            //timerHoneywell.Start();


        }

        private void France_flag_Click(object sender, EventArgs e)
        {
            select_FR.Visible = true;
            select_EN.Visible = false;
            select_ES.Visible = false;
            Language_Manager language_Manager = new Language_Manager();
            language_Manager.ChangeLanguage("fr", this, typeof(Borne_ChoixTypePesee));
            vg_Lang = "fr";
        }

        private void England_flag_Click(object sender, EventArgs e)
        {
            select_FR.Visible = false;
            select_EN.Visible = true;
            select_ES.Visible = false;
            Language_Manager language_Manager = new Language_Manager();
            language_Manager.ChangeLanguage("en", this, typeof(Borne_ChoixTypePesee));
            vg_Lang = "en";
        }

        private void Spain_flag_Click(object sender, EventArgs e)
        {
            select_FR.Visible = false;
            select_EN.Visible = false;
            select_ES.Visible = true;
            Language_Manager language_Manager = new Language_Manager();
            language_Manager.ChangeLanguage("es", this, typeof(Borne_ChoixTypePesee));
            vg_Lang = "es";
        }

        private void btPeser_Click(object sender, EventArgs e)
        {
            Form form = new Borne_ChoixFlux(vg_Lang, vg_PontId, vg_Demander_Paramatre, -1, Convert.ToInt32(txtPoids.Text));
            form.Show();
        }

        private void txtPoids_TextChanged(object sender, EventArgs e)
        {
            int P = 0;
            P = Convert.ToInt32(txtPoids.Text);
            if (P < 50)
            {               
               Close();
            }
        }

        private void txtPoids_DoubleClick(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Entrez un poids", "Simulateur Poids");
            txtPoids.Text = input;
        }

        private void timerHoneywell_Tick(object sender, EventArgs e)
        {
            string s;
            byte[] trame = new byte[comHoneywell.BytesToRead];
            try
            {
                comHoneywell.Read(trame, 0, trame.Length);
                s = System.Text.Encoding.ASCII.GetString(trame);
                
                if (s.Length > 5)
                {
                    Camion camion = new Camion();
                    if (camion.IfExists(s))
                    {
                        if (camion.IfIsPending(s))
                        {
                            Form form = new Borne_DeuxiemePesee(Convert.ToInt32(txtPoids.Text), camion.GetPendingId(s), s);
                            form.Show();
                        }
                        else
                        {
                            ScanCamionId = camion.GetIdByName(s);
                            Form form = new Borne_ChoixFlux(vg_Lang, vg_PontId, vg_Demander_Paramatre, ScanCamionId, Convert.ToInt32(txtPoids.Text));
                            form.Show();
                        }
                        

                    }
                    else
                    {
                        //ScanCamionId = -1;
                    }
                }


            }
            catch
            {
                throw;
            }
        }
    }
}
