using CustomMessageBox;
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
using static System.Windows.Forms.AxHost;

namespace WidraSoft.UI
{

    public partial class Borne_Home : Form
    {
        // COM & Weight Settings Informations
        SerialPort com = new SerialPort();
        int TimerInterval;
        int LongueurMinChaine;
        int PositionDebut;
        int LongueurChaine;
        int Poids_Detection;
        int ActiverPoids;
        string CaractereSeparation;
        string ModeLecture;
        int Stabilite;
        int PositionStabilite;
        string ValeurStable;
        int Negatif;
        int PositionNegatif;
        string ValeurNegatif;
        Boolean Stable;
        int vg_PontId;
        string Lang;
        public static int Poids_Public;

        public Borne_Home()
        {
            InitializeComponent();
        }

        private void Borne_Home_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            WindowState = FormWindowState.Maximized;

            select_FR.Visible = true;
            select_EN.Visible = false;
            select_ES.Visible = false;
            Language_Manager language_Manager = new Language_Manager();
            Lang = "fr";
            language_Manager.ChangeLanguage(Lang, this, typeof(Borne_Home));
            lbMessage.Text = "Bienvenue, prêt à peser ...";

            vg_PontId = GetPontId();
            lbDate.Text = DateTime.Now.ToShortDateString() + ' ' + DateTime.Now.ToShortTimeString();
            timer_Time.Interval = 30000;
            timer_Time.Start();

            Initialize_WeighBridgeSettings(vg_PontId);


        }

        private int GetPontId()
        {
            //Pont 
            Pont pont = new Pont();
            DataTable dtPont = pont.FindByMachineName(System.Environment.MachineName);

            int pontId = 0;

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

        private void Initialize_WeighBridgeSettings(Int32 PontId)
        {
            Pont pont = new Pont();
            String NumCom;
            NumCom = "COM" + pont.GetCOM(PontId);
            com.PortName = NumCom;
            DataTable dtPont = new DataTable();
            dtPont = pont.FindById(PontId);
            foreach (DataRow row in dtPont.Rows)
            {
                com.ReadTimeout = (int)row["READTIMEOUT"];
                com.BaudRate = (int)row["BAUDRATE"];
                com.Parity = Parity.None;
                com.StopBits = StopBits.One;
                com.DataBits = (int)row["DATABITS"];
                com.Handshake = Handshake.None;
                Poids_Detection = (int)row["POIDS_DETECTION"];
                ActiverPoids = (int)row["ACTIVERPOIDS"];
                try
                {
                    if (ActiverPoids == 1)
                    {
                        txtPoids.ReadOnly = true;
                        com.Open();
                    }
                    else
                    {
                        txtPoids.ReadOnly = false;
                    }
                }
                catch { throw; }

            }

            Initialize_WeightSettings(PontId);
        }

        private void Initialize_WeightSettings(Int32 PontId)
        {
            Pont pont = new Pont();
            WeightSettings weightSettings = new WeightSettings();
            DataTable dtWeightSettings = new DataTable();
            dtWeightSettings = weightSettings.FindById(pont.GetWeightSettingsId(PontId));
            foreach (DataRow r in dtWeightSettings.Rows)
            {
                //lbWeightSettings.Text = r["DESIGNATION"].ToString();
                TimerInterval = (int)r["TIMERINTERVAL"];
                Weight_Timer.Interval = TimerInterval;
                if (ActiverPoids == 1)
                {
                    Weight_Timer.Start();

                }
                LongueurMinChaine = (int)r["LONGUEURMINCHAINE"];
                PositionDebut = (int)r["POSITIONDEBUT"];
                LongueurChaine = (int)r["LONGUEURCHAINE"];
                CaractereSeparation = r["CARACTERESEPARATION"].ToString();
                ModeLecture = r["MODELECTURE"].ToString();
                Stabilite = (int)r["STABILITE"];
                PositionStabilite = (int)r["POSITIONSTABILTE"];
                ValeurStable = r["VALEURSTABLE"].ToString();
                Negatif = (int)r["NEGATIF"];
                PositionNegatif = (int)r["POSITIONNEGATIF"];
                ValeurNegatif = r["VALEURNEGATIF"].ToString();
            }
        }

        public String filtredataBilancia(String returnstr)
        {
            Char s;
            if (returnstr.Length >= LongueurMinChaine)
            {
                s = returnstr[PositionStabilite];
                returnstr = returnstr.Substring(PositionDebut, LongueurChaine);
                if (s == ValeurStable[0])
                {
                    txtPoids.ForeColor = Color.FromArgb(112, 228, 132);
                    Stable = true;
                }
                else
                {
                    txtPoids.ForeColor = Color.Red;
                    Stable = false;
                }
            }
            else
            {
                returnstr = "0";
            }

            return returnstr;

        }

        public void ReceiveSerialData()
        {
            string s;
            string result;
            byte[] trame = new byte[com.BytesToRead];
            com.Read(trame, 0, trame.Length);
            s = System.Text.Encoding.ASCII.GetString(trame);
            
            if (s.Length >= LongueurMinChaine)
            {
                result = filtredataBilancia(s);
                int Poids;
                bool IsParsablePoids;
                IsParsablePoids = Int32.TryParse(result, out Poids);
                if (IsParsablePoids) { txtPoids.Text = Poids.ToString(); }
                else { txtPoids.Text = "0"; }
                Poids_Public = Poids;
            }
                
            else
                txtPoids.Text = "0";
            
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
            lbMessage.Text = "Bienvenue, prêt à peser ...";
        }


        private void txtPoids_TextChanged(object sender, EventArgs e)
        {
            int P = 0;
            bool IsParsableP;
            IsParsableP = Int32.TryParse(txtPoids.Text, out P);
            if (IsParsableP)
            {
                if (P > 300)
                {
                    Poids_Public = P;
                    Form form = new Borne_ChoixTypePesee(Lang, GetPontId(), GetWeighingSettingsType(GetPontId()), P, TimerInterval);
                    //txtPoids.Text = "0";
                    form.Show(this);
                }
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
            lbMessage.Text = "Welcome, ready to weigh ...";
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
            lbMessage.Text = "Bienvenido, listo para pesar";
        }

        private void Weight_Timer_Tick(object sender, EventArgs e)
        {
            ReceiveSerialData();
        }

        private void Borne_Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (com.IsOpen)
            {
                com.Close();
            }
        }
    }
}
