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
using WidraSoft.DA;

namespace WidraSoft.UI
{
    public partial class Borne_ChoixTypePesee : Form
    {
        string vg_Lang;
        int vg_PontId;
        bool vg_Demander_Paramatre;
        int vg_P;
        int vg_TimerInterval;
        int ScanCamionId = -1;
        int ScanChauffeurId = -1;   
        int ScanClientId = -1;
        string Flux_Default;

        SerialPort comHoneywell = new SerialPort();
        SerialPort comBadge = new SerialPort();
        public Borne_ChoixTypePesee(string Lang, int PontId, bool Demander_Paramatre, int P, int TimerInterval)
        {
            InitializeComponent();
            vg_Lang = Lang;
            vg_Demander_Paramatre = Demander_Paramatre;
            vg_PontId = PontId;
            vg_P = P;
            vg_TimerInterval = TimerInterval;

        }

        private void btTareManuelle_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new Borne_Tare(vg_Lang, vg_PontId, vg_Demander_Paramatre, vg_P);
                form.Show();
                Close();
            }
            catch
            {
                throw;
            }
        }

        private void Borne_ChoixTypePesee_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            WindowState = FormWindowState.Maximized;

            txtPoids.Text = vg_P.ToString();

            Weight_Timer.Interval = vg_TimerInterval;
            Weight_Timer.Start();

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

            Gestion_Boutons(vg_PontId);

            Pont pont = new Pont();
            Flux_Default = pont.GetFluxDefault(vg_PontId);


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

            

            comBadge.PortName = "COM5";
            comBadge.ReadTimeout = 1000;
            comBadge.BaudRate = 9600;
            comBadge.Parity = Parity.None;
            comBadge.StopBits = StopBits.One;
            comBadge.DataBits = 8;
            comBadge.Handshake = Handshake.None;

            try
            {
                comBadge.Open();
            }
            catch
            {
                throw;
            }

            timerHoneywell.Interval = 300;
            timerHoneywell.Start();
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
            try
            {
                Form form = new Borne_ChoixFlux(vg_Lang, vg_PontId, vg_Demander_Paramatre, -1, Convert.ToInt32(txtPoids.Text), 0, Flux_Default, -1, -1);
                form.Show();
                Close();
            }
            catch { throw; }

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
            Read_Badge();
           /* string s;
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
                            Form form = new Borne_DeuxiemePesee(Convert.ToInt32(txtPoids.Text), camion.GetPendingId(s), s, vg_Lang);
                            form.Show();
                        }
                        else
                        {
                            ScanCamionId = camion.GetIdByName(s);
                            Form form = new Borne_ChoixFlux(vg_Lang, vg_PontId, vg_Demander_Paramatre, ScanCamionId, Convert.ToInt32(txtPoids.Text), 0);
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
            }*/
        }

        private void Read_Badge()
        {
            String s;
            String s1 = "";
            String s2 = "";
            String Type = "Camion";

            byte[] trame = new byte[comBadge.BytesToRead];

            try
            {
                comBadge.Read(trame, 0, trame.Length);
                s = System.Text.Encoding.ASCII.GetString(trame);
                if (s.Length >= 10)
                {
                    s1 = s.Substring(1, 4);
                    s2 = s.Substring(5, 6);
                    //MessageBox.Show(s1 + " " + s2);

                    Firme firme = new Firme();
                    if (firme.GetBadge(1).Trim() == s1)
                    {
                        if (Type == "Camion")
                        {
                            Camion camion = new Camion();
                            if (camion.CountByBadge(s2) > 0)
                            {
                                ScanCamionId = camion.GetIdByBadge(s2);
                                Form form = new Borne_ChoixFlux(vg_Lang, vg_PontId, vg_Demander_Paramatre, ScanCamionId, Convert.ToInt32(txtPoids.Text), 0, Flux_Default, -1, -1);
                                form.Show();  
                            }
                        }

                        if (Type == "Chauffeur")
                        {
                            Chauffeur chauffeur = new Chauffeur();
                            if (chauffeur.CountByBadge(s2)  > 0)
                            {
                                ScanChauffeurId = chauffeur.GetIdByBadge(s2);
                                Form form = new Borne_ChoixFlux(vg_Lang, vg_PontId, vg_Demander_Paramatre, -1, Convert.ToInt32(txtPoids.Text), 0, Flux_Default, ScanChauffeurId, -1);
                                form.Show();
                            } 
                        }

                        if (Type == "Client")
                        {
                            Client client = new Client();
                            if(client.CountByBadge(s2) > 0)
                            {
                                ScanClientId = client.GetIdByBadge(s2);
                                Form form = new Borne_ChoixFlux(vg_Lang, vg_PontId, vg_Demander_Paramatre, -1, Convert.ToInt32(txtPoids.Text), 0, Flux_Default, -1, ScanClientId);
                                form.Show();
                            }
                        }
                    }

                    
                }               
            }
            catch { throw; }
        }

        private void btPeser2_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new Borne_ChoixDeuxiemePesee(vg_Lang, vg_P);
                form.Show();
                Close();
            }
            catch { throw; }
        }

        private void Gestion_Boutons(Int32 pontId)
        {
            try
            {
                Pont pont = new Pont();
                if (pont.Borne_Autoriser_Premiere_Pesee(pontId))
                    btPeser.Visible = true;
                else
                    btPeser.Visible = false;
                if (pont.Borne_Autoriser_Deuxieme_Pesee(pontId))
                    btPeser2.Visible = true;
                else
                    btPeser2.Visible = false;
                if (pont.Borne_Autoriser_Tare_Manuelle(pontId))
                    btTareManuelle.Visible = true;
                else
                    btTareManuelle.Visible = false;

            }
            catch
            {
                throw;
            }
        }

        private void Weight_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                txtPoids.Text = Borne_Home.Poids_Public.ToString();
            }
            catch { throw; }
        }
    }
}
