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

namespace WidraSoft.UI
{
    public partial class Borne_FinPesee : Form
    {
        string vg_Lang;
        string vg_mode;
        int vg_Id;
        bool close = false;
        SerialPort comBarriere = new SerialPort();

        public Borne_FinPesee(string lang, string mode, int Id)
        {
            InitializeComponent();
            vg_Lang = lang;
            vg_mode = mode;
            vg_Id = Id;
        }

        private void Borne_FinPesee_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            WindowState = FormWindowState.Maximized;

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

            comBarriere.PortName = "COM8";
            comBarriere.ReadTimeout = 1000;
            comBarriere.BaudRate = 9600;
            comBarriere.Parity = Parity.None;
            comBarriere.StopBits = StopBits.One;
            comBarriere.DataBits = 8;
            comBarriere.Handshake = Handshake.None;


            try
            {
                // comBarriere.Open();
            }
            catch
            {
                throw;
            }

            Gestion_Modes(vg_mode);


            Timer.Interval = 3000;

            Timer.Start();
        }

        private void Gestion_Modes(string mode)
        {
            if (mode == "2x1")
            {
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
                if (vg_Lang == "fr")
                {
                    lbTexte.Text = "Pesée terminée. Vous pouvez quitter la bascule.";
                }

                if (vg_Lang == "en")
                {
                    lbTexte.Text = "Weighing completed. You can leave the weighbridge.";
                }

                if (vg_Lang == "es")
                {
                    lbTexte.Text = "Pesaje completado. Puedes dejar la báscula.";
                }

                //Ouvrir_Barriere();

                Form form = new PeseePBTicketA5(vg_Id);
                form.Show();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Ouvrir_Barriere()
        {
            try
            {
                comBarriere.WriteLine("23 30 31 41 30 30 30 0D");
            }
            catch { throw; }

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
    }
}
