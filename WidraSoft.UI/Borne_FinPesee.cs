using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.Reporting.WinForms;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WidraSoft.BL;
using WidraSoft.DA;

namespace WidraSoft.UI
{
    public partial class Borne_FinPesee : Form
    {
        string vg_Lang;
        string vg_mode;
        int vg_Id;
        int vg_WalterreId;
        bool vg_IsWalterre;
        bool close = false;
        int vg_PontId;
        int vg_ActiverBarriere;
        SerialPort comBarriere = new SerialPort();

        public Borne_FinPesee(string lang, string mode, int Id, bool isWalterre, int walterreid, int PontId)
        {
            InitializeComponent();
            vg_Lang = lang;
            vg_mode = mode;
            vg_Id = Id;
            vg_IsWalterre = isWalterre;
            vg_WalterreId = walterreid;
            vg_PontId = PontId;
        }

        private void Borne_FinPesee_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            WindowState = FormWindowState.Maximized;

            lbCamera.Visible = false;

            if (vg_Lang == "fr")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
            }

            if (vg_Lang == "en")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
            }

            if (vg_Lang == "es")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
            }

            Pont pont = new Pont();
            DataTable dtPont = new DataTable();
            dtPont = pont.FindById(vg_PontId);
            string com_Barriere = "7";

            foreach (DataRow row in dtPont.Rows)
            {
                com_Barriere = row["NUMPORTCOM_BARRIERE"].ToString();
                vg_ActiverBarriere = (int)row["ACTIVER_BARRIERE"];
            }

            comBarriere.PortName = "COM" + com_Barriere;
            comBarriere.ReadTimeout = 1000;
            comBarriere.BaudRate = 9600;
            comBarriere.Parity = Parity.None;
            comBarriere.StopBits = StopBits.One;
            comBarriere.DataBits = 8;
            comBarriere.Handshake = Handshake.None;

            if (vg_ActiverBarriere == 1)
            {
                try
                {
                    comBarriere.Open();
                }
                catch
                {
                    throw;
                }
            }


            Gestion_Modes(vg_mode, vg_IsWalterre);

            

            Timer.Interval = 5000;

            Timer.Start();
        }

        private void Gestion_Modes(string mode, bool isWalterre)
        {
            decimal reste = 0;
            bool afficher_walterre = false;
            Walterre walterre = new Walterre();

            if (vg_ActiverBarriere == 1)
            {
                Fermer_Relais_BrainBox(0);
                System.Threading.Thread.Sleep(600);
                Ouvrir_Relais_BrainBox(0);
            }

            if (isWalterre && vg_WalterreId > 0)
            {
                reste = walterre.GetVolume(vg_WalterreId) - walterre.GetQteEnlevements(vg_WalterreId);
                afficher_walterre = true;
            }
            if (mode == "2x1")
            {

                Captures_Images("1x");
                if (vg_Lang == "fr")
                {
                    lbTexte.Text = "Première pesée terminée. Vous pouvez quitter la bascule.";
                }

                if (vg_Lang == "en")
                {
                    lbTexte.Text = "First weighing completed. You can leave the weighbridge.";
                }

                if (vg_Lang == "es")
                {
                    lbTexte.Text = "Primer pesaje completado. Puedes dejar la báscula.";
                }

                
            }

            if (mode == "2x2")

            {
                Captures_Images("2x");
                if (vg_Lang == "fr")
                {
                    if (afficher_walterre)
                        lbTexte.Text = "Il reste " + reste.ToString() + " Tonnes sur un total de " + walterre.GetVolume(vg_WalterreId) + " Tonnes pour le contrat Walterre numéro " + walterre.GetName(vg_WalterreId) + ".";
                    else
                        lbTexte.Text = "Pesée terminée. Vous pouvez quitter la bascule.";

                }

                if (vg_Lang == "en")
                {
                    if (afficher_walterre)
                        lbTexte.Text = "There are" + reste.ToString() + " Tons remaining out of a total of " + walterre.GetVolume(vg_WalterreId) + " Tons for the Walterre contract number " + walterre.GetName(vg_WalterreId) + ".";
                    else
                        lbTexte.Text = "Weighing completed. You can leave the weighbridge.";
                }

                if (vg_Lang == "es")
                {
                    if (afficher_walterre)
                        lbTexte.Text = "";
                    else
                        lbTexte.Text = "Pesaje completado. Puedes dejar la báscula.";
                }

                


                try
                {
                    Form form = new PeseePBTicketA5(vg_Id);
                    form.Show();
                }


                catch { throw; }
                
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Captures_Images(string type)
        {
            Pont pont = new Pont(); 
            DataTable dt = new DataTable();
            dt = pont.FindById(vg_PontId);
            foreach (DataRow row in dt.Rows)
            {
                int Camera1;
                int Camera2;
                int Camera3;
                string IpCamera1;
                string IpCamera2;
                string IpCamera3;
                string Port1;
                string Port2;
                string Port3;
                string Login1;
                string Login2;
                string Login3;
                string Password1;
                string Password2;
                string Password3;

                Camera1 = (int)row["ACTIVER_CAMERA1"];
                Camera2 = (int)row["ACTIVER_CAMERA2"];
                Camera3 = (int)row["ACTIVER_CAMERA3"];
                IpCamera1 = row["ADRESSEIP_1"].ToString();
                IpCamera2 = row["ADRESSEIP_2"].ToString();
                IpCamera3 = row["ADRESSEIP_3"].ToString();
                Port1 = row["PORT_1"].ToString();
                Port2 = row["PORT_2"].ToString();
                Port3 = row["PORT_3"].ToString();
                Login1 = row["LOGIN_1"].ToString();
                Login2 = row["LOGIN_2"].ToString();
                Login3 = row["LOGIN_3"].ToString();
                Password1 = row["PASSWORD_1"].ToString();
                Password2 = row["PASSWORD_2"].ToString();
                Password3 = row["PASSWORD_3"].ToString();

                if (Camera1 == 1 )

                {
                    try
                    {
                        Form form1 = new ANPR(IpCamera1, Port1, Login1, Password1, vg_Id.ToString(), type, "1");
                        form1.Show();
                        lbCamera.Visible = true;
                    }
                    catch { throw; }
                }

                System.Threading.Thread.Sleep(800);

                if (Camera2 == 1  )

                {
                    try
                    {
                        Form form1 = new ANPR2(IpCamera2, Port2, Login2, Password2, vg_Id.ToString(), type, "2");
                        form1.Show();
                        lbCamera.Visible = true;
                    }
                    catch { throw; }
                   
                }

                System.Threading.Thread.Sleep(800);
                
                if (Camera3 == 1)

                {
                    try
                    {
                        Form form1 = new ANPR3(IpCamera3, Port3, Login3, Password3, vg_Id.ToString(), type, "3");
                        form1.Show();
                        lbCamera.Visible = true;
                    }
                    catch { throw;}
                }
            }

        }

        private void Ouvrir_Relais_BrainBox(int relais)
        {
            byte[] bytestosend0 = { 0x23, 0x30, 0x31, 0x41, 0x30, 0x30, 0x30, 0x0D };
            byte[] bytestosend1 = { 0x23, 0x30, 0x31, 0x41, 0x31, 0x30, 0x30, 0x0D };
            byte[] bytestosend2 = { 0x23, 0x30, 0x31, 0x41, 0x32, 0x30, 0x30, 0x0D };
            byte[] bytestosend3 = { 0x23, 0x30, 0x31, 0x41, 0x33, 0x30, 0x30, 0x0D };
            try
            {
                if (relais  == 0) 
                    comBarriere.Write(bytestosend0, 0, bytestosend0.Length);
                if (relais == 1)
                    comBarriere.Write(bytestosend1, 0, bytestosend0.Length);
                if (relais == 2)
                    comBarriere.Write(bytestosend2, 0, bytestosend0.Length);
                if (relais == 3)
                    comBarriere.Write(bytestosend3, 0, bytestosend0.Length);
            }
            catch { throw; }
        }

        private void Fermer_Relais_BrainBox(int relais)
        {
            byte[] bytestosend0 = { 0x23, 0x30, 0x31, 0x41, 0x30, 0x30, 0x31, 0x0D };
            byte[] bytestosend1 = { 0x23, 0x30, 0x31, 0x41, 0x31, 0x30, 0x31, 0x0D };
            byte[] bytestosend2 = { 0x23, 0x30, 0x31, 0x41, 0x32, 0x30, 0x31, 0x0D };
            byte[] bytestosend3 = { 0x23, 0x30, 0x31, 0x41, 0x33, 0x30, 0x31, 0x0D };
            try
            {
                if (relais == 0)
                    comBarriere.Write(bytestosend0, 0, bytestosend0.Length);
                if (relais == 1)
                    comBarriere.Write(bytestosend1, 0, bytestosend0.Length);
                if (relais == 2)
                    comBarriere.Write(bytestosend2, 0, bytestosend0.Length);
                if (relais == 3)
                    comBarriere.Write(bytestosend3, 0, bytestosend0.Length);
            }
            catch { throw; }
        }

        private void Relais_On_Arduino(int relais)
        {
            try
            {
                string s = "0WDO0x0" + ((int)Math.Pow(2, (relais - 1))).ToString("X");
                //string s = "0WDO0x00";
                s = CT(s);
                comBarriere.Write(s + "/r/n");
            }
            catch { throw; }


        }

        public string CT(string S)
        {
            int I;
            int J;
            string S2;
            string SResult;

            S2 = "<";

            J = Convert.ToInt32("0xAA", 16);
            for (I = 1; I <= S.Length; I++)
            {
                J = J + Strings.Asc(Strings.Mid(S, I, 1));
                S2 = S2 + Strings.Mid(S, I, 1);
            }
            J = J % 256;

            if (J.ToString("X").Length == 1)
            {
                SResult = S2 + "0" + J.ToString("X") + ">";
            }
            else
            {
                SResult = S2 + "" + J.ToString("X") + ">";
            }
            return SResult;
        }

        private void Borne_FinPesee_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comBarriere.IsOpen)
            { comBarriere.Close(); }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (close)
            {
                try
                {
                    FormCollection fc = Application.OpenForms;
                    foreach (Form frm in fc)
                    {
                        if (frm.Name == "Borne_PremierePesee")
                        {
                            frm.Close();
                            return;
                        }
                    }
                    this.Close();
                }
                catch { throw; }
            }
            close = true;

        }

        private void btOpen_Click(object sender, EventArgs e)
        {

        }
    }
}
