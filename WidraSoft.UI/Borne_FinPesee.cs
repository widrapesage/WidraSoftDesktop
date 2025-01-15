using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            Gestion_Modes(vg_mode);

            Timer timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += delegate { this.Close(); };
            timer.Start();
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

                Form form = new PeseePBTicketA5(vg_Id);
                form.Show();
            }
        }
    }
}
