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
using WeighBridge_Library.Clients;

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

        SerialPort comScanner = new SerialPort();
        string vg_TypeScanner;
        int vg_ActiverScanner; 
        public Borne_ChoixTypePesee(string Lang, int PontId, bool Demander_Paramatre, int P, int TimerInterval, string TypeScanner, int ActiverScanner)
        {
            InitializeComponent();
            vg_Lang = Lang;
            vg_Demander_Paramatre = Demander_Paramatre;
            vg_PontId = PontId;
            vg_P = P;
            vg_TimerInterval = TimerInterval;
            vg_TypeScanner = TypeScanner;
            vg_ActiverScanner = ActiverScanner;

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

            if(vg_ActiverScanner > 0)
            {
                comScanner.PortName = "COM" + pont.GetCOMScanner(vg_PontId);
                comScanner.ReadTimeout = 1000;
                comScanner.BaudRate = 9600;
                comScanner.Parity = Parity.None;
                comScanner.StopBits = StopBits.One;
                comScanner.DataBits = 8;
                comScanner.Handshake = Handshake.None;

                try
                {
                    if (!comScanner.IsOpen) 
                        comScanner.Open();
                }
                catch
                {
                    throw;
                }

                timerScanner.Interval = 300;
                timerScanner.Start();
                

                if (vg_TypeScanner == "Lecteur QR Code HoneyWell")
                {
                    
                }
            }
                     
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
            if (P < 500)
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
            if (vg_TypeScanner == "Lecteur badge RFID")
            {
                Read_Badge();
            }
            
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

            byte[] trame = new byte[comScanner.BytesToRead];

            try
            {
                WeighingApplicationClient weighingApplicationClient = new WeighingApplicationClient();
                comScanner.Read(trame, 0, trame.Length);
                s = System.Text.Encoding.ASCII.GetString(trame);
                if (s.Length >= 10)
                {
                    s1 = s.Substring(1, 4);
                    s2 = s.Substring(5, 6);
                    //MessageBox.Show(s1 + " " + s2);
                    lbNotFound.Visible = false;
                    Firme firme = new Firme();
                    if (firme.GetBadge(1).Trim() == s1)
                    {
                        if (Type == "Camion")
                        {
                            Camion camion = new Camion();
                            if (camion.CountByBadge(s2) > 0)
                            {
                                ScanCamionId = camion.GetIdByBadge(s2);
                                if (camion.IfIsPending(camion.GetName(ScanCamionId)))
                                {
                                    Form form = new Borne_DeuxiemePesee(Convert.ToInt32(txtPoids.Text), camion.GetPendingId(camion.GetName(ScanCamionId)), camion.GetName(ScanCamionId), vg_Lang, vg_PontId);
                                    form.Show();
                                    Close();
                                }
                                else
                                {
                                    Form form = new Borne_ChoixFlux(vg_Lang, vg_PontId, vg_Demander_Paramatre, ScanCamionId, Convert.ToInt32(txtPoids.Text), 0, Flux_Default, -1, -1);
                                    form.Show();
                                    Close();
                                }
                                
                            }
                            else
                            {
                                lbNotFound.Visible = true;
                            }
                        }

                        if (Type == "Chauffeur")
                        {
                            Chauffeur chauffeur = new Chauffeur();
                            if (chauffeur.CountByBadge(s2) > 0)
                            {
                                ScanChauffeurId = chauffeur.GetIdByBadge(s2);
                                Form form = new Borne_ChoixFlux(vg_Lang, vg_PontId, vg_Demander_Paramatre, -1, Convert.ToInt32(txtPoids.Text), 0, Flux_Default, ScanChauffeurId, -1);
                                form.Show();
                                Close();
                            }
                        }

                        if (Type == "Client")
                        {
                            Client client = new Client();
                            if (client.CountByBadge(s2) > 0)
                            {
                                ScanClientId = client.GetIdByBadge(s2);
                                Form form = new Borne_ChoixFlux(vg_Lang, vg_PontId, vg_Demander_Paramatre, -1, Convert.ToInt32(txtPoids.Text), 0, Flux_Default, -1, ScanClientId);
                                form.Show();
                                Close();
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
                Form form = new Borne_ChoixDeuxiemePesee(vg_Lang, vg_P, vg_PontId);
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

        private void Borne_ChoixTypePesee_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comScanner.IsOpen)
                comScanner.Close();
            //Borne_Home.GetWeigh = true;
        }
    }
}
