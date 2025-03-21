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
        int vg_PontId;

        public Borne_DeuxiemePesee(int P, int PeseePEId, string camion, string lang, int PontId)
        {
            InitializeComponent();
            vg_P = P;
            vg_PeseePBId = PeseePEId;
            vg_camion = camion;
            vg_lang = lang;
            vg_PontId = PontId;
        }

        private void Borne_DeuxiemePesee_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            WindowState = FormWindowState.Maximized;

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
            lbMessage.Text = "Numéro: " + vg_PeseePBId + " " + peseePB.GetShortResume(vg_PeseePBId);
            vg_Poids2 = peseePB.GetPoids2ById(vg_PeseePBId);

            Weight_Timer.Interval = 500;
            Weight_Timer.Start();
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
                Walterre walterre = new Walterre();
                if (pesee.GetWalterreIdById(vg_PeseePBId) > 0)
                {
                    if (Math.Round(Convert.ToDecimal(Math.Abs(vg_P - vg_Poids2)) / 1000, 2) + walterre.GetQteEnlevements(pesee.GetWalterreIdById(vg_PeseePBId)) > walterre.GetSeuilMax(pesee.GetWalterreIdById(vg_PeseePBId)))
                    {
                        if (walterre.IsDepassementSeuilMaxAutorise(pesee.GetWalterreIdById(vg_PeseePBId)))
                        {
                            if (Math.Round(Convert.ToDecimal(Math.Abs(vg_P - vg_Poids2)) / 1000, 2) + walterre.GetQteEnlevements(pesee.GetWalterreIdById(vg_PeseePBId)) > walterre.GetVolume(pesee.GetWalterreIdById(vg_PeseePBId)))
                            {
                                if (walterre.IsDepassementVolumeAutorise(pesee.GetWalterreIdById(vg_PeseePBId)))
                                {
                                    try
                                    {
                                        pesee.Update_Borne(vg_PeseePBId, vg_P,
                                         DateTime.Now, Math.Abs(vg_P - vg_Poids2), "Borne", "Complete");
                                        Form form = new Borne_FinPesee(vg_lang, "2x2", vg_PeseePBId, true, pesee.GetWalterreIdById(vg_PeseePBId), vg_PontId);
                                        form.Show();
                                        Close();
                                    }
                                    catch { throw; }
                                }
                                else
                                {
                                    //IMPOSSIBLE VOLUME DEPASSE ET  PAS D'AUTORISATION
                                    if (vg_lang == "fr")
                                        lbMessage.Text = "Impossible de finaliser la pesée car le volume maximal de " + walterre.GetVolume(pesee.GetWalterreIdById(vg_PeseePBId)).ToString() + " Tonnes a été atteint pour le contrat Walterre numéro " + walterre.GetName(pesee.GetWalterreIdById(vg_PeseePBId)) + ".";
                                    if (vg_lang == "en")
                                        lbMessage.Text = "Impossible to complete the weighing because the maximum volume of " + walterre.GetVolume(pesee.GetWalterreIdById(vg_PeseePBId)).ToString() + " Tons has been reached for the Walterre contract number " + walterre.GetName(pesee.GetWalterreIdById(vg_PeseePBId)) + ".";
                                    if (vg_lang == "es")
                                        lbMessage.Text = "";
                                }
                            }
                            else
                            {
                                try
                                {
                                    pesee.Update_Borne(vg_PeseePBId, vg_P,
                                     DateTime.Now, Math.Abs(vg_P - vg_Poids2), "Borne", "Complete");
                                    Form form = new Borne_FinPesee(vg_lang, "2x2", vg_PeseePBId, true, pesee.GetWalterreIdById(vg_PeseePBId), vg_PontId);
                                    form.Show();
                                    Close();
                                }
                                catch { throw; }
                            }

                        }
                        else
                        {
                            //IMPOSSIBLE SEUIL MAX DEPASSE ET PAS D'AUTORISARTION
                            if (vg_lang == "fr")
                                lbMessage.Text = "Impossible de finaliser la pesée car le seuil maximal de " + walterre.GetSeuilMax(pesee.GetWalterreIdById(vg_PeseePBId)).ToString() + " Tonnes a été atteint pour le contrat Walterre numéro " + walterre.GetName(pesee.GetWalterreIdById(vg_PeseePBId)) + ".";
                            if (vg_lang == "en")
                                lbMessage.Text = "Impossible to complete the weighing because the maximum threshold of " + walterre.GetSeuilMax(pesee.GetWalterreIdById(vg_PeseePBId)).ToString() + " Tons has been reached for the Walterre contract number " + walterre.GetName(pesee.GetWalterreIdById(vg_PeseePBId)) + ".";
                            if (vg_lang == "es")
                                lbMessage.Text = "";
                        }
                    }
                    else
                    {
                        try
                        {
                            pesee.Update_Borne(vg_PeseePBId, vg_P,
                             DateTime.Now, Math.Abs(vg_P - vg_Poids2), "Borne", "Complete");
                            Form form = new Borne_FinPesee(vg_lang, "2x2", vg_PeseePBId, true, pesee.GetWalterreIdById(vg_PeseePBId), vg_PontId);
                            form.Show();
                            Close();
                        }
                        catch { throw; }
                    }

                }
                else
                {
                    try
                    {
                        pesee.Update_Borne(vg_PeseePBId, vg_P,
                         DateTime.Now, Math.Abs(vg_P - vg_Poids2), "Borne", "Complete");
                        Form form = new Borne_FinPesee(vg_lang, "2x2", vg_PeseePBId, false, 0, vg_PontId);
                        form.Show();
                        Close();
                    }
                    catch { throw; }

                }

            }
            catch
            { throw; }
        }

        private void lbTexte_Click(object sender, EventArgs e)
        {

        }

        private void Weight_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                txtPoids.Text = Borne_Home.Poids_Public.ToString();
            }
            catch { throw; }
        }
    }

}
