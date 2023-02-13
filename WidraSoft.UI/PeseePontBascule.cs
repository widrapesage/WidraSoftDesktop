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
    public partial class PeseePontBascule : Form
    {
        SerialPort com = new SerialPort();
        int TimerInterval;
        int LongueurMinChaine;
        int PositionDebut;
        int LongueurChaine;
        string CaractereSeparation;
        string ModeLecture;
        int Stabilite;
        int PositionStabilite;
        string ValeurStable;
        int Negatif;
        int PositionNegatif;
        string ValeurNegatif;
        bool Stable;

        public PeseePontBascule()
        {
            InitializeComponent();

        }

        private void PeseePontBascule_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            Pont pont = new Pont();
            cbPont.DataSource = pont.List("1=1");
            cbPont.DisplayMember = "DESIGNATION";
            cbPont.ValueMember = "PONTID";
            cbPont.SelectedIndex = 0;
            lbCOM.Text = "COM" + pont.GetCOM((int)cbPont.SelectedValue);
            lbStatus.Text = "En cours";

            com.PortName = lbCOM.Text;
            DataTable dtPont = new DataTable();
            dtPont = pont.FindById((int)cbPont.SelectedValue);
            foreach (DataRow row in dtPont.Rows)
            {
                com.ReadTimeout = (int)row["READTIMEOUT"];
                com.BaudRate = (int)row["BAUDRATE"];
                com.Parity = Parity.None;
                com.StopBits = StopBits.One;
                com.DataBits = (int)row["DATABITS"];
                com.Handshake = Handshake.None;
                try
                {
                    com.Open();
                }
                catch { throw; }
               

                WeightSettings weightSettings = new WeightSettings();
                DataTable dtWeightSettings = new DataTable();
                dtWeightSettings = weightSettings.FindById((int)row["WEIGHT_SETTINGSID"]);
                foreach (DataRow r in dtWeightSettings.Rows)
                {
                    lbWeightSettings.Text = r["DESIGNATION"].ToString();
                    TimerInterval = (int)r["TIMERINTERVAL"];
                    Weight_Timer.Interval = TimerInterval;
                    Weight_Timer.Start();
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
            
            Firme firme = new Firme();
            cbFirme.DataSource = firme.List("1=1");
            cbFirme.DisplayMember = "DESIGNATION";
            cbFirme.ValueMember = "FIRMEID";
            cbFirme.SelectedIndex = 0;

            Camion camion = new Camion();
            cbCamion.DataSource = camion.List("1=1");
            cbCamion.DisplayMember = "PLAQUE";
            cbCamion.ValueMember = "CAMIONID";
            cbCamion.SelectedIndex = 0;

            Chauffeur chauffeur = new Chauffeur();
            cbChauffeur.DataSource = chauffeur.List("1=1");
            cbChauffeur.DisplayMember = "NOM";
            cbChauffeur.ValueMember = "CHAUFFEURID";
            cbChauffeur.SelectedIndex = 0;

            Transporteur transporteur = new Transporteur();
            cbTransporteur.DataSource = transporteur.List("1=1");
            cbTransporteur.DisplayMember = "NOM";
            cbTransporteur.ValueMember = "TRANSPORTEURID";
            cbTransporteur.SelectedIndex = 0;

            Produit produit = new Produit();
            cbProduit.DataSource = produit.List("1=1");
            cbProduit.DisplayMember = "DESIGNATION";
            cbProduit.ValueMember = "PRODUITID";
            cbProduit.SelectedIndex = 0;

            Client client = new Client();
            cbClient.DataSource = client.List("1=1");
            cbClient.DisplayMember = "DESIGNATION";
            cbClient.ValueMember = "CLIENTID";
            cbClient.SelectedIndex = 0;

            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = 0;


            richTextBoxPoids.SelectionAlignment = HorizontalAlignment.Right;
            
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
                    Stable = true;
                }
                else
                {
                    richTextBoxPoids.ForeColor = Color.Red;
                    Stable = false;
                }
            } else
            {
                returnstr = "000000";
            }
              
            return returnstr;

        }

        public void ReceiveSerialData()
        {
            string s;
            byte[] trame = new byte[com.BytesToRead];
            com.Read(trame, 0, trame.Length);
            s = System.Text.Encoding.ASCII.GetString(trame);
            s = "$000000";
            if (s.Length >= LongueurMinChaine)
                richTextBoxPoids.Text = filtredataBilancia(s);
            else
                richTextBoxPoids.Text = "000000";
        }

        private void PeseePontBascule_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (com.IsOpen)
                com.Close();
        }

        private void Weight_Timer_Tick(object sender, EventArgs e)
        {
            ReceiveSerialData();            
        }
    }
}