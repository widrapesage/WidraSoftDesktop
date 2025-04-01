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
using Tunnel.Communication.Data;
using TunnelIntegration;
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
        int ActiverScanner = 0;
        string TypeScanner;
        public static bool GetWeigh = true;

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

            TunnelCommunicationHelper.ReceivedWeightData += TunnelCommunicationHelper_ReceivedWeightData;

            Initialize_WeighBridgeSettings(vg_PontId);
            Initialize_Contact();

        }

        private static void TunnelCommunicationHelper_ReceivedWeightData(object sender, WeightData e)
        {
            Poids_Public = e.Weight;
        }

        private void UpdateWeight()
        {
            txtPoids.Text = Poids_Public.ToString();
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

        private void Initialize_Contact()
        {
            Pont pont = new Pont();
            DataTable dtPont = pont.FindById(vg_PontId);
            foreach (DataRow ro in dtPont.Rows)
            {
                if (ro["CONTACT1"].ToString() != "")
                {
                    lbContact1.Text = ro["CONTACT1"].ToString();
                    lbContact1.Visible = true;
                    pbContact1.Visible = true;
                }
                else
                {
                    lbContact1.Visible = false;
                    pbContact1.Visible = false;
                }
                if (ro["CONTACT2"].ToString() != "")
                {
                    lbContact2.Text = ro["CONTACT2"].ToString();
                    lbContact2.Visible = true;
                    pbContact2.Visible = true;
                }
                else
                {
                    lbContact2.Visible = false;
                    pbContact2.Visible = false;
                }
                if (ro["CONTACT3"].ToString() != "")
                {
                    lbContact3.Text = ro["CONTACT3"].ToString();
                    lbContact3.Visible = true;
                    pbContact3.Visible = true;
                }
                else
                {
                    lbContact3.Visible = false;
                    pbContact3.Visible = false;
                }
            }

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
                ActiverScanner = (int)row["ACTIVER_SCANNER"];
                TypeScanner = row["TYPESCANNER"].ToString();
                try
                {
                    if (ActiverPoids == 1)
                    {
                        txtPoids.ReadOnly = true;
                        if (!com.IsOpen)
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
            Initialize_Contact();
        }


        private void txtPoids_TextChanged(object sender, EventArgs e)
        {
            int P = 0;
            bool IsParsableP;
            IsParsableP = Int32.TryParse(txtPoids.Text, out P);
            if (IsParsableP)
            {
                if (P > 500)
                {
                    Poids_Public = P;
                    FormCollection fc = Application.OpenForms;
                    bool WeighingInProgress = false;
                    foreach (Form frm in fc)
                    {
                        if (frm.Name == "Borne_ChoixTypePesee" || frm.Name == "Borne_PremierePesee" || frm.Name == "Borne_DeuxiemePesee" || frm.Name == "Borne_FinPesee" || frm.Name == "Borne_Tare"
                            || frm.Name == "Borne_ChoixFlux" || frm.Name == "Borne_ChoixDeuxiemePesee")
                        {
                            WeighingInProgress = true;
                            return;
                        }
                    }
                    if (!WeighingInProgress)
                    {
                        Form form = new Borne_ChoixTypePesee(Lang, GetPontId(), GetWeighingSettingsType(GetPontId()), P, TimerInterval, TypeScanner, ActiverScanner);
                        //txtPoids.Text = "0";
                        form.Show(this);
                    }

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
            Initialize_Contact();
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
            Initialize_Contact();
        }

        private void Weight_Timer_Tick(object sender, EventArgs e)
        {
            if (com.IsOpen)
                ReceiveSerialData();
            else
                UpdateWeight();
        }

        private void Borne_Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (com.IsOpen)
            {
                Weight_Timer.Stop();
                com.Close();
            }
        }

        
    }
}
