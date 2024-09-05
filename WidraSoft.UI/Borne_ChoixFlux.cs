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
    public partial class Borne_ChoixFlux : Form
    {
        String vg_Lang;
        int vg_PontId;
        bool vg_DemanderParametre;
        int vg_ScanCamionId;
        int vg_P;
        public Borne_ChoixFlux(string Lang, int PontId, bool Demander_Paramatre, int ScanCamionId, int P)
        {
            InitializeComponent();
            vg_Lang = Lang;
            vg_PontId = PontId;
            vg_DemanderParametre = Demander_Paramatre;
            vg_ScanCamionId = ScanCamionId;
            vg_P = P;
        }

        private void Borne_ChoixFlux_Load(object sender, EventArgs e)
        {

            this.CenterToScreen();
            Camion camion = new Camion();
            if (vg_Lang == "fr")
            {
                
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(Borne_ChoixFlux));
                lbTexte.Text = "Choisir le flux";
                if (camion.IfExists(camion.GetName(vg_ScanCamionId)))
                {
                    lbMessage.Text = "Scan du camion " + camion.GetName(vg_ScanCamionId) + " validé";
                }
                else
                {
                    lbMessage.Text = "";
                }
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
            }               
            else if (vg_Lang == "en")
            {
                
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(Borne_ChoixFlux));
                lbTexte.Text = "Choose the flow";
                if (camion.IfExists(camion.GetName(vg_ScanCamionId)))
                {
                    lbMessage.Text = "Truck " + camion.GetName(vg_ScanCamionId) + " scan passed";
                }
                else
                {
                    lbMessage.Text = "";
                }
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
            }
            else
            {
                
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(Borne_ChoixFlux));
                lbTexte.Text = "Elegir flujo";
                if (camion.IfExists(camion.GetName(vg_ScanCamionId)))
                {
                    lbMessage.Text = "Escaneo de camión " + camion.GetName(vg_ScanCamionId) + " aprobado";
                }
                else
                {
                    lbMessage.Text = "";
                }
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
            }               
        }

        private void btChargement_Click(object sender, EventArgs e)
        {
            Form form = new Borne_PremierePesee(vg_Lang, vg_PontId, vg_DemanderParametre, "Out", vg_ScanCamionId, vg_P);
            form.Show();
            Close();
        }

        private void btDechargement_Click(object sender, EventArgs e)
        {
            Form form = new Borne_PremierePesee(vg_Lang, vg_PontId, vg_DemanderParametre, "In", vg_ScanCamionId, vg_P);
            form.Show();
            Close();
        }
    }
}
