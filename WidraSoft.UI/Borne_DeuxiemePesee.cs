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
    public partial class Borne_DeuxiemePesee : Form
    {
        int vg_P;
        int vg_PeseePBId;
        string vg_camion;
        string vg_lang;
        int vg_Poids2;
        public Borne_DeuxiemePesee(int P, int PeseePEId, string camion, string lang)
        {
            InitializeComponent();
            vg_P = P;
            vg_PeseePBId = PeseePEId;
            vg_camion = camion;
            vg_lang = lang;
        }

        private void Borne_DeuxiemePesee_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            if (vg_lang == "fr")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(Borne_DeuxiemePesee));
            }

            if (vg_lang == "en")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(Borne_DeuxiemePesee));
            }

            if (vg_lang == "es")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(Borne_DeuxiemePesee));
            }

            txtPoids.Text = vg_P.ToString();
            PeseePB peseePB = new PeseePB();
            lbMessage.Text =  "Numéro: " + vg_PeseePBId + " " + peseePB.GetShortResume(vg_PeseePBId) ;
            vg_Poids2 = peseePB.GetPoids2ById(vg_PeseePBId);
        }

        private void btAnnuler_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btValider_Click(object sender, EventArgs e)
        {
            try
            {
                PeseePB pesee = new PeseePB();
                pesee.Update_Borne(vg_PeseePBId, vg_P, 
                    DateTime.Now, Math.Abs(vg_P - vg_Poids2), "Borne", "Complete");
                Form form = new Borne_FinPesee(vg_lang, "2x2", vg_PeseePBId);
                form.Show();
                Close();
            }
            catch
            { throw; }
        }
    }

}
