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
        int vg_Tare;
        string vg_FluxDefault;
        int vg_ScanChauffeurId;
        int vg_ScanClientId;
        int vg_ScanWalterreId;
        public Borne_ChoixFlux(string Lang, int PontId, bool Demander_Paramatre, int ScanCamionId, int P, int Tare, string Flux_default, int ScanChauffeurId, int ScanClientId, int ScanWalterreId)
        {
            InitializeComponent();
            vg_Lang = Lang;
            vg_PontId = PontId;
            vg_DemanderParametre = Demander_Paramatre;
            vg_ScanCamionId = ScanCamionId;
            vg_P = P;
            vg_Tare = Tare;
            vg_FluxDefault = Flux_default;  
            vg_ScanChauffeurId = ScanChauffeurId;
            vg_ScanClientId = ScanClientId; 
            vg_ScanWalterreId = ScanWalterreId;
        }

        private void Borne_ChoixFlux_Load(object sender, EventArgs e)
        {
            if (vg_FluxDefault == "Out")
                btChargement_Click(this, new EventArgs());
            else if (vg_FluxDefault == "In")
                btDechargement_Click(this, new EventArgs());
            else
            {
                this.CenterToScreen();
                WindowState = FormWindowState.Maximized;
                Camion camion = new Camion();
                Chauffeur chauffeur = new Chauffeur();
                Client client = new Client();
                Walterre walterre = new Walterre(); 
                if (vg_ScanCamionId > 0)
                {
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

                if (vg_ScanChauffeurId > 0)
                {
                    if (vg_Lang == "fr")
                    {

                        Language_Manager language_Manager = new Language_Manager();
                        language_Manager.ChangeLanguage("fr", this, typeof(Borne_ChoixFlux));
                        lbTexte.Text = "Choisir le flux";
                        if (chauffeur.IfExists(chauffeur.GetName(vg_ScanChauffeurId)))
                        {
                            lbMessage.Text = "Scan du chauffeur " + chauffeur.GetName(vg_ScanChauffeurId) + " validé";
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
                        if (chauffeur.IfExists(chauffeur.GetName(vg_ScanChauffeurId)))
                        {
                            lbMessage.Text = "Driver " + chauffeur.GetName(vg_ScanChauffeurId) + " scan passed";
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
                        if (chauffeur.IfExists(chauffeur.GetName(vg_ScanChauffeurId)))
                        {
                            lbMessage.Text = "Escaneo de conductor " + chauffeur.GetName(vg_ScanChauffeurId) + " aprobado";
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
                if (vg_ScanClientId > 0)
                {
                    if (vg_Lang == "fr")
                    {

                        Language_Manager language_Manager = new Language_Manager();
                        language_Manager.ChangeLanguage("fr", this, typeof(Borne_ChoixFlux));
                        lbTexte.Text = "Choisir le flux";
                        if (client.IfExists(client.GetName(vg_ScanClientId)))
                        {
                            lbMessage.Text = "Scan du client " + client.GetName(vg_ScanClientId) + " validé";
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
                        if (client.IfExists(client.GetName(vg_ScanClientId)))
                        {
                            lbMessage.Text = "Customer " + client.GetName(vg_ScanClientId) + " scan passed";
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
                        if (client.IfExists(client.GetName(vg_ScanClientId)))
                        {
                            lbMessage.Text = "Escaneo de cliente " + client.GetName(vg_ScanClientId) + " aprobado";
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

                if (vg_ScanWalterreId > 0)
                {
                    if (vg_Lang == "fr")
                    {

                        Language_Manager language_Manager = new Language_Manager();
                        language_Manager.ChangeLanguage("fr", this, typeof(Borne_ChoixFlux));
                        lbTexte.Text = "Choisir le flux";
                        if (walterre.IfExists(walterre.GetName(vg_ScanWalterreId)))
                        {
                            lbMessage.Text = "Scan du chantier Walterre " + walterre.GetName(vg_ScanClientId) + " validé";
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
                        if (walterre.IfExists(walterre.GetName(vg_ScanWalterreId)))
                        {
                            lbMessage.Text = "Walterre " + walterre.GetName(vg_ScanWalterreId) + " scan passed";
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
                        if (walterre.IfExists(walterre.GetName(vg_ScanWalterreId)))
                        {
                            lbMessage.Text = "Escaneo de walterre " + walterre.GetName(vg_ScanWalterreId) + " aprobado";
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
            }
            
        }

        private void btChargement_Click(object sender, EventArgs e)
        {
            Form form = new Borne_PremierePesee(vg_Lang, vg_PontId, vg_DemanderParametre, "Out", vg_ScanCamionId, vg_P, vg_Tare, vg_ScanChauffeurId, vg_ScanClientId, vg_ScanWalterreId); 
            form.Show();
            Close();
        }

        private void btDechargement_Click(object sender, EventArgs e)
        {
            Form form = new Borne_PremierePesee(vg_Lang, vg_PontId, vg_DemanderParametre, "In", vg_ScanCamionId, vg_P, vg_Tare, vg_ScanChauffeurId, vg_ScanClientId, vg_ScanWalterreId);
            form.Show();
            Close();
        }

        private void btAnnuler_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
