using CustomMessageBox;
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
    public partial class WeighingSettingsDetail : Form
    {
        String vg_Mode = "";
        Int32 vg_Id = 0;
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;
        public WeighingSettingsDetail(String Mode, Int32 Id)
        {
            InitializeComponent();
            vg_Mode = Mode;
            vg_Id = Id;
        }

        private void WeighingSettingsDetail_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = 0;

            cbFormat.DataSource = Values.FormatTicket;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Values.FormatTicket[0].ToString();

            List<String> FirmeBorne = new List<String>();
            FirmeBorne.Add("List"); FirmeBorne.Add("Scan"); FirmeBorne.Add("List&Scan"); FirmeBorne.Add("Text");
            List<String> CamionBorne = new List<String>();
            CamionBorne.Add("List"); CamionBorne.Add("Scan"); CamionBorne.Add("List&Scan"); CamionBorne.Add("Text");
            List<String> ChauffeurBorne = new List<String>();
            ChauffeurBorne.Add("List"); ChauffeurBorne.Add("Scan"); ChauffeurBorne.Add("List&Scan"); ChauffeurBorne.Add("Text");
            List<String> TransporteurBorne = new List<String>();
            TransporteurBorne.Add("List"); TransporteurBorne.Add("Scan"); TransporteurBorne.Add("List&Scan"); TransporteurBorne.Add("Text");
            List<String> ProduitBorne = new List<String>();
            ProduitBorne.Add("List"); ProduitBorne.Add("Scan"); ProduitBorne.Add("List&Scan"); ProduitBorne.Add("Text");
            List<String> ClientBorne = new List<String>();
            ClientBorne.Add("List"); ClientBorne.Add("Scan"); ClientBorne.Add("List&Scan"); ClientBorne.Add("Text");


            cbFirmeBorne.DataSource = FirmeBorne;
            cbFirmeBorne.ValueMember = null; 
            cbFirmeBorne.DisplayMember = FirmeBorne[0];

            cbCamionBorne.DataSource = CamionBorne;
            cbCamionBorne.ValueMember = null; 
            cbCamionBorne.DisplayMember = CamionBorne[0];

            cbChauffeurBorne.DataSource = ChauffeurBorne;
            cbChauffeurBorne.ValueMember = null; 
            cbChauffeurBorne.DisplayMember = ChauffeurBorne[0];

            cbTransporteurBorne.DataSource = TransporteurBorne;
            cbTransporteurBorne.ValueMember = null; 
            cbTransporteurBorne.DisplayMember = TransporteurBorne[0];

            cbProduitBorne.DataSource = ProduitBorne;
            cbProduitBorne.ValueMember = null; 
            cbProduitBorne.DisplayMember = ProduitBorne[0];

            cbClientBorne.DataSource = ClientBorne;
            cbClientBorne.ValueMember = null; 
            cbClientBorne.DisplayMember = ClientBorne[0];

            Tables table = new Tables();

            //Champ1
            cbChamp1.DataSource = table.List("1=1");
            cbChamp1.DisplayMember = "NOM";
            cbChamp1.ValueMember = "TABLESID";

            //Champ2
            cbChamp2.DataSource = table.List("1=1");
            cbChamp2.DisplayMember = "NOM";
            cbChamp2.ValueMember = "TABLESID";

            //Champ3
            cbChamp3.DataSource = table.List("1=1");
            cbChamp3.DisplayMember = "NOM";
            cbChamp3.ValueMember = "TABLESID";

            //Champ4
            cbChamp4.DataSource = table.List("1=1");
            cbChamp4.DisplayMember = "NOM";
            cbChamp4.ValueMember = "TABLESID";

            //Champ5
            cbChamp5.DataSource = table.List("1=1");
            cbChamp5.DisplayMember = "NOM";
            cbChamp5.ValueMember = "TABLESID";

            //Champ6
            cbChamp6.DataSource = table.List("1=1");
            cbChamp6.DisplayMember = "NOM";
            cbChamp6.ValueMember = "TABLESID";

            //Champ7
            cbChamp7.DataSource = table.List("1=1");
            cbChamp7.DisplayMember = "NOM";
            cbChamp7.ValueMember = "TABLESID";

            List<String> BorneChamp1 = new List<String>();
            BorneChamp1.Add("List"); BorneChamp1.Add("Scan"); BorneChamp1.Add("List&Scan"); BorneChamp1.Add("Text");
            List<String> BorneChamp2 = new List<String>();
            BorneChamp2.Add("List"); BorneChamp2.Add("Scan"); BorneChamp2.Add("List&Scan"); BorneChamp2.Add("Text");
            List<String> BorneChamp3 = new List<String>();
            BorneChamp3.Add("List"); BorneChamp3.Add("Scan"); BorneChamp3.Add("List&Scan"); BorneChamp3.Add("Text");
            List<String> BorneChamp4 = new List<String>();
            BorneChamp4.Add("List"); BorneChamp4.Add("Scan"); BorneChamp4.Add("List&Scan"); BorneChamp4.Add("Text");
            List<String> BorneChamp5 = new List<String>();
            BorneChamp5.Add("List"); BorneChamp5.Add("Scan"); BorneChamp5.Add("List&Scan"); BorneChamp5.Add("Text");
            List<String> BorneChamp6 = new List<String>();
            BorneChamp6.Add("List"); BorneChamp6.Add("Scan"); BorneChamp6.Add("List&Scan"); BorneChamp6.Add("Text");
            List<String> BorneChamp7 = new List<String>();
            BorneChamp7.Add("List"); BorneChamp7.Add("Scan"); BorneChamp7.Add("List&Scan"); BorneChamp7.Add("Text");

            List<String> BorneChampLibre1 = new List<String>();
            BorneChampLibre1.Add("String"); BorneChampLibre1.Add("Numeric");

            List<String> BorneChampLibre2 = new List<String>();
            BorneChampLibre2.Add("String"); BorneChampLibre2.Add("Numeric");

            List<String> BorneChampLibre3 = new List<String>();
            BorneChampLibre3.Add("String"); BorneChampLibre3.Add("Numeric");

            List<String> BorneChampLibre4 = new List<String>();
            BorneChampLibre4.Add("String"); BorneChampLibre4.Add("Numeric");


            cbBorneChamp1.DataSource = BorneChamp1;
            cbBorneChamp1.ValueMember = null;
            cbBorneChamp1.DisplayMember = BorneChamp1[0];

            cbBorneChamp2.DataSource = BorneChamp2;
            cbBorneChamp2.ValueMember = null;
            cbBorneChamp2.DisplayMember = BorneChamp2[0];

            cbBorneChamp3.DataSource = BorneChamp3;
            cbBorneChamp3.ValueMember = null;
            cbBorneChamp3.DisplayMember = BorneChamp3[0];

            cbBorneChamp4.DataSource = BorneChamp4;
            cbBorneChamp4.ValueMember = null;
            cbBorneChamp4.DisplayMember = BorneChamp4[0];

            cbBorneChamp5.DataSource = BorneChamp5;
            cbBorneChamp5.ValueMember = null;
            cbBorneChamp5.DisplayMember = BorneChamp5[0];

            cbBorneChamp6.DataSource = BorneChamp6;
            cbBorneChamp6.ValueMember = null;
            cbBorneChamp6.DisplayMember = BorneChamp6[0];

            cbBorneChamp7.DataSource = BorneChamp7;
            cbBorneChamp7.ValueMember = null;
            cbBorneChamp7.DisplayMember = BorneChamp7[0];

            cbBorneChampLibre1.DataSource = BorneChampLibre1;
            cbBorneChampLibre1.ValueMember = null;
            cbBorneChampLibre1.DisplayMember = BorneChampLibre1[0];

            cbBorneChampLibre2.DataSource = BorneChampLibre2;
            cbBorneChampLibre2.ValueMember = null;
            cbBorneChampLibre2.DisplayMember = BorneChampLibre2[0];

            cbBorneChampLibre3.DataSource = BorneChampLibre3;
            cbBorneChampLibre3.ValueMember = null;
            cbBorneChampLibre3.DisplayMember = BorneChampLibre3[0];

            cbBorneChampLibre4.DataSource = BorneChampLibre4;
            cbBorneChampLibre4.ValueMember = null;
            cbBorneChampLibre4.DisplayMember = BorneChampLibre4[0];

            if (vg_Mode == "Add")
            {
                try
                {
                    Clear();
                    
                    Add_Item();
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                if (vg_Mode == "Edit")
                {
                    try
                    {
                        Edit_Item();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

            

        }

        private void Add_Item()
        {
            if (txtId.Text == "" && txtDateCreation.Text == "" && txtDesignation.Text == "" && txtCamion.Text == "" && txtChauffeur.Text == "" && txtTransporteur.Text == ""
                && txtProduit.Text == "" && txtClient.Text == "" && txtFirme.Text == "" && txtFirmeObligatoire.Text == "" && txtCamionObligatoire.Text == "" && txtChauffeurObligatoire.Text == "" 
                && txtTransporteurObligatoire.Text == "" && txtProduitObligatoire.Text == "" && txtClientObligatoire.Text == "" && cbFirmeBorne.Text == "" && cbCamionBorne.Text == "" && cbChauffeurBorne.Text == ""
                && cbTransporteurBorne.Text == "" && cbProduitBorne.Text == "" && cbClientBorne.Text == "" && txtAjoutFirme.Text == "" && txtAjoutCamion.Text == "" && txtAjoutChauffeur.Text == "" 
                && txtAjoutTransporteur.Text == "" && txtAjoutProduit.Text == "" && txtAjoutClient.Text == "" && txtPontFirme.Text == "" && txtCamionChauffeur.Text == "" && txtCamionTransporteur.Text == "" && cbChamp1.Text == ""
                && cbChamp2.Text == "" && cbChamp3.Text == "" && cbChamp4.Text == "" && cbChamp5.Text == "" && cbChamp6.Text == "" && cbChamp7.Text == "" && txtObligatoire1.Text == "" && txtObligatoire2.Text == "" 
                && txtObligatoire3.Text == "" && txtObligatoire4.Text == "" && txtObligatoire5.Text == "" && txtObligatoire6.Text == "" && txtObligatoire7.Text == "" && txtAfficherCode1.Text == "" && txtAfficherCode2.Text == ""
                && txtAfficherCode3.Text == "" && txtAfficherCode4.Text == "" && txtAfficherCode5.Text == "" && txtAfficherCode6.Text == "" && txtAfficherCode7.Text == "" && cbBorneChamp1.Text == "" && cbBorneChamp2.Text == "" 
                && cbBorneChamp3.Text == "" && cbBorneChamp4.Text == "" && cbBorneChamp5.Text == "" && cbBorneChamp6.Text == "" && cbBorneChamp7.Text == "" && txtTicketChamp1.Text == "" && txtTicketChamp2.Text == "" 
                && txtTicketChamp3.Text == "" && txtTicketChamp4.Text == "" && txtTicketChamp5.Text == "" && txtTicketChamp6.Text == "" && txtTicketChamp7.Text == "" && txtAjoutChamp1.Text == "" && txtAjoutChamp2.Text == ""
                && txtAjoutChamp3.Text == "" && txtAjoutChamp4.Text == "" && txtAjoutChamp5.Text == "" && txtAjoutChamp6.Text == "" && txtAjoutChamp7.Text == "" && cbFormat.Text == "" && txtTitre1.Text == ""
                && txtTitre2.Text == "" && txtFooter.Text == "" && txtChampLibre1.Text == "" && txtChampLibre2.Text == "" && txtChampLibre3.Text == "" && txtChampLibre4.Text == "" && txtLibreObligatoire1.Text == ""
                && txtLibreObligatoire2.Text == "" && txtLibreObligatoire3.Text == "" && txtLibreObligatoire4.Text == "" && txtTicketChampLibre1.Text == "" && txtTicketChampLibre2.Text == "" && txtTicketChampLibre3.Text == ""
                && txtTicketChampLibre4.Text == "" && cbBorneChampLibre1.Text == "" && cbBorneChampLibre2.Text == "" && cbBorneChampLibre3.Text == "" && cbBorneChampLibre4.Text == "")
            {
                lbModifier.Enabled = false;
                lbModifier.BackColor = Color.Transparent;
                lbSupprimer.Enabled = false;
                lbSupprimer.BackColor = Color.Transparent;
                
                txtCamion.Text = "1";
                chx_Camion.Checked = true;
                txtChauffeur.Text = "1";
                chx_Chauffeur.Checked = true;
                txtTransporteur.Text = "1";
                chx_Transporteur.Checked = true;
                txtProduit.Text = "1";
                chx_Produit.Checked = true;
                txtClient.Text = "1";
                chx_Client.Checked = true;
                txtFirme.Text = "1";
                chx_Firme.Checked = true;

                txtFirmeObligatoire.Text = "1";
                chx_FirmeObligatoire.Checked = true;
                txtCamionObligatoire.Text = "1";
                chx_CamionObligatoire.Checked = true;
                txtChauffeurObligatoire.Text = "1";
                chx_ChauffeurObligatoire.Checked = true;
                txtTransporteurObligatoire.Text = "1";
                chx_TransporteurObligatoire.Checked= true;
                txtProduitObligatoire.Text = "1";
                chx_ProduitObligatoire.Checked = true;
                txtClientObligatoire.Text = "1";
                chx_ClientObligatoire.Checked = true;

                cbFirmeBorne.Text = "List";
                cbCamionBorne.Text = "List";
                cbChauffeurBorne.Text = "List";
                cbTransporteurBorne.Text = "List";
                cbProduitBorne.Text = "List";
                cbClientBorne.Text = "List";


                txtAjoutFirme.Text = "0";
                chx_AjoutFirme.Checked = false;
                txtAjoutCamion.Text = "0";
                chx_AjoutCamion.Checked= false;
                txtAjoutChauffeur.Text = "0";
                chx_AjoutChauffeur.Checked = false;
                txtAjoutTransporteur.Text = "0";
                chx_AjoutTransporteur.Checked = false;
                txtAjoutProduit.Text = "0";
                chx_AjoutProduit.Checked = false;
                txtAjoutClient.Text = "0";
                chx_AjoutClient.Checked = false;

                txtPontFirme.Text = "0";
                chx_PontFirme.Checked = false;
                txtCamionChauffeur.Text = "0";
                chx_CamionChauffeur.Checked = false;
                txtCamionTransporteur.Text = "0";
                chx_CamionTransporteur.Checked = false;

                cbChamp1.SelectedIndex = -1; cbChamp1.Text = "";
                cbChamp2.SelectedIndex = -1; cbChamp2.Text = "";
                cbChamp3.SelectedIndex = -1; cbChamp3.Text = "";
                cbChamp4.SelectedIndex = -1; cbChamp4.Text = "";
                cbChamp5.SelectedIndex = -1; cbChamp5.Text = "";
                cbChamp6.SelectedIndex = -1; cbChamp6.Text = "";
                cbChamp7.SelectedIndex = -1; cbChamp7.Text = "";

                txtObligatoire1.Text = "0";
                chx_Obligatoire1.Checked = false;
                txtObligatoire2.Text = "0";
                chx_Obligatoire2.Checked = false;
                txtObligatoire3.Text = "0";
                chx_Obligatoire3.Checked = false;
                txtObligatoire4.Text = "0";
                chx_Obligatoire4.Checked = false;
                txtObligatoire5.Text = "0";
                chx_Obligatoire5.Checked = false;
                txtObligatoire6.Text = "0";
                chx_Obligatoire6.Checked = false;
                txtObligatoire7.Text = "0";
                chx_Obligatoire7.Checked = false;

                txtAfficherCode1.Text = "0";
                chx_AfficherCode1.Checked = false;
                txtAfficherCode2.Text = "0";
                chx_AfficherCode2.Checked = false;
                txtAfficherCode3.Text = "0";
                chx_AfficherCode3.Checked = false;
                txtAfficherCode4.Text = "0";
                chx_AfficherCode4.Checked = false;
                txtAfficherCode5.Text = "0";
                chx_AfficherCode5.Checked = false;
                txtAfficherCode6.Text = "0";
                chx_AfficherCode6.Checked = false;
                txtAfficherCode7.Text = "0";
                chx_AfficherCode7.Checked = false;

                cbBorneChamp1.SelectedIndex = -1; cbBorneChamp1.Text = "";
                cbBorneChamp2.SelectedIndex = -1; cbBorneChamp2.Text = "";
                cbBorneChamp3.SelectedIndex = -1; cbBorneChamp3.Text = "";
                cbBorneChamp4.SelectedIndex = -1; cbBorneChamp4.Text = "";
                cbBorneChamp5.SelectedIndex = -1; cbBorneChamp5.Text = "";
                cbBorneChamp6.SelectedIndex = -1; cbBorneChamp6.Text = "";
                cbBorneChamp7.SelectedIndex = -1; cbBorneChamp7.Text = "";

                txtTicketChamp1.Text = "0";
                cbx_TicketChamp1.Checked = false;
                txtTicketChamp2.Text = "0";
                cbx_TicketChamp2.Checked = false;
                txtTicketChamp3.Text = "0";
                cbx_TicketChamp3.Checked = false;
                txtTicketChamp4.Text = "0";
                cbx_TicketChamp4.Checked = false;
                txtTicketChamp5.Text = "0";
                cbx_TicketChamp5.Checked = false;
                txtTicketChamp6.Text = "0";
                cbx_TicketChamp6.Checked = false;
                txtTicketChamp7.Text = "0";
                cbx_TicketChamp7.Checked = false;

                txtAjoutChamp1.Text = "0";
                chx_AjoutChamp1.Checked = false;
                txtAjoutChamp2.Text = "0";
                chx_AjoutChamp2.Checked = false;
                txtAjoutChamp3.Text = "0";
                chx_AjoutChamp3.Checked = false;
                txtAjoutChamp4.Text = "0";
                chx_AjoutChamp4.Checked = false;
                txtAjoutChamp5.Text = "0";
                chx_AjoutChamp5.Checked = false;
                txtAjoutChamp6.Text = "0";
                chx_AjoutChamp6.Checked = false;
                txtAjoutChamp7.Text = "0";
                chx_AjoutChamp7.Checked = false;

                txtTicketChampLibre1.Text = "";
                txtTicketChampLibre2.Text = "";
                txtTicketChampLibre3.Text = "";
                txtTicketChampLibre4.Text = "";

                txtLibreObligatoire1.Text = "0";
                chx_LibreObligatoire1.Checked = false;
                txtLibreObligatoire2.Text = "0";
                chx_LibreObligatoire2.Checked = false;
                txtLibreObligatoire3.Text = "0";
                chx_LibreObligatoire3.Checked = false;
                txtLibreObligatoire4.Text = "0";
                chx_LibreObligatoire4.Checked = false;

                txtTicketChampLibre1.Text = "0";
                cbx_TicketChampLibre1.Checked = false;
                txtTicketChampLibre2.Text = "0";
                cbx_TicketChampLibre2.Checked = false;
                txtTicketChampLibre3.Text = "0";
                cbx_TicketChampLibre3.Checked = false;
                txtTicketChampLibre4.Text = "0";
                cbx_TicketChampLibre4.Checked = false;

                cbBorneChampLibre1.SelectedIndex = -1; cbBorneChampLibre1.Text = "";
                cbBorneChampLibre2.SelectedIndex = -1; cbBorneChampLibre2.Text = "";
                cbBorneChampLibre3.SelectedIndex = -1; cbBorneChampLibre3.Text = "";
                cbBorneChampLibre4.SelectedIndex = -1; cbBorneChampLibre4.Text = "";



                cbFormat.Text = "A5";
            }
        }

        private void Edit_Item()
        {
            lbAjouter.Enabled = false;
            lbAjouter.BackColor = Color.Transparent;
            Disable();
            Bind_Fields();
        }

        private void Bind_Fields()
        {
            DataTable dt = new DataTable();
            WeighingSettings weighingSettings = new WeighingSettings();
            dt = weighingSettings.FindById(vg_Id);
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["WEIGHING_SETTINGSID"];
                txtId.Text = Id.ToString();
                txtDateCreation.Text = row["DATECREATION"].ToString();
                txtDesignation.Text = row["DESIGNATION"].ToString();                
                txtCamion.Text = row["CAMION"].ToString();
                if (txtCamion.Text == "1")
                    chx_Camion.Checked = true;
                else
                    chx_Camion.Checked = false;
                txtChauffeur.Text = row["CHAUFFEUR"].ToString();
                if (txtChauffeur.Text == "1")
                    chx_Chauffeur.Checked = true;
                else
                    chx_Chauffeur.Checked = false;
                txtTransporteur.Text = row["TRANSPORTEUR"].ToString();
                if (txtTransporteur.Text == "1")
                    chx_Transporteur.Checked = true;
                else
                    chx_Transporteur.Checked = false;
                txtProduit.Text = row["PRODUIT"].ToString();
                if (txtProduit.Text == "1")
                    chx_Produit.Checked = true;
                else
                    chx_Produit.Checked = false;
                txtClient.Text = row["CLIENT"].ToString();
                if (txtClient.Text == "1")
                    chx_Client.Checked = true;
                else
                    chx_Client.Checked = false;
                txtFirme.Text = row["FIRME"].ToString();
                if (txtFirme.Text == "1")
                    chx_Firme.Checked = true;
                else
                    chx_Firme.Checked = false;
                txtCamionObligatoire.Text = row["CAMION_OBL"].ToString();
                if (txtCamionObligatoire.Text == "1")
                    chx_CamionObligatoire.Checked = true;
                else
                    chx_CamionObligatoire.Checked = false;
                txtChauffeurObligatoire.Text = row["CHAUFFEUR_OBL"].ToString();
                if (txtChauffeurObligatoire.Text == "1")
                    chx_ChauffeurObligatoire.Checked = true;
                else
                    chx_ChauffeurObligatoire.Checked = false;
                txtTransporteurObligatoire.Text = row["TRANSPORTEUR_OBL"].ToString();
                if (txtTransporteurObligatoire.Text == "1")
                    chx_TransporteurObligatoire.Checked = true;
                else
                    chx_TransporteurObligatoire.Checked = false;
                txtProduitObligatoire.Text = row["PRODUIT_OBL"].ToString();
                if (txtProduitObligatoire.Text == "1")
                    chx_ProduitObligatoire.Checked = true;
                else
                    chx_ProduitObligatoire.Checked = false;
                txtClientObligatoire.Text = row["CLIENT_OBL"].ToString();
                if (txtClientObligatoire.Text == "1")
                    chx_ClientObligatoire.Checked = true;
                else
                    chx_ClientObligatoire.Checked = false;
                txtFirmeObligatoire.Text = row["FIRME_OBL"].ToString();
                if (txtFirmeObligatoire.Text == "1")
                    chx_FirmeObligatoire.Checked = true;
                else
                    chx_FirmeObligatoire.Checked = false;
                cbCamionBorne.Text = row["CAMION_BORNE"].ToString();
                cbChauffeurBorne.Text = row["CHAUFFEUR_BORNE"].ToString();
                cbTransporteurBorne.Text = row["TRANSPORTEUR_BORNE"].ToString();
                cbProduitBorne.Text = row["PRODUIT_BORNE"].ToString();
                cbClientBorne.Text = row["CLIENT_BORNE"].ToString();
                cbFirmeBorne.Text = row["FIRME_BORNE"].ToString();
                txtAjoutCamion.Text = row["CAMION_AJOUT_F"].ToString();
                if (txtAjoutCamion.Text == "1")
                    chx_AjoutCamion.Checked = true;
                else
                    chx_AjoutCamion.Checked = false;
                txtAjoutChauffeur.Text = row["CHAUFFEUR_AJOUT_F"].ToString();
                if (txtAjoutChauffeur.Text == "1")
                    chx_AjoutChauffeur.Checked = true;
                else
                    chx_AjoutChauffeur.Checked = false;
                txtAjoutTransporteur.Text = row["TRANSPORTEUR_AJOUT_F"].ToString();
                if (txtAjoutTransporteur.Text == "1")
                    chx_AjoutTransporteur.Checked = true;
                else
                    chx_AjoutTransporteur.Checked = false;
                txtAjoutProduit.Text = row["PRODUIT_AJOUT_F"].ToString();
                if (txtAjoutProduit.Text == "1")
                    chx_AjoutProduit.Checked = true;
                else
                    chx_AjoutProduit.Checked = false;
                txtAjoutClient.Text = row["CLIENT_AJOUT_F"].ToString();
                if (txtAjoutClient.Text == "1")
                    chx_AjoutClient.Checked = true;
                else
                    chx_AjoutClient.Checked = false;
                txtAjoutFirme.Text = row["FIRME_AJOUT_F"].ToString();
                if (txtAjoutFirme.Text == "1")
                    chx_AjoutFirme.Checked = true;
                else
                    chx_AjoutFirme.Checked = false;
                if (row["TABLE1_ID"] is System.DBNull)
                    cbChamp1.SelectedValue = 0;
                else
                    cbChamp1.SelectedValue = (int)row["TABLE1_ID"];
                if (row["TABLE2_ID"] is System.DBNull)
                    cbChamp2.SelectedValue = 0;
                else
                    cbChamp2.SelectedValue = (int)row["TABLE2_ID"];
                if (row["TABLE3_ID"] is System.DBNull)
                    cbChamp3.SelectedValue = 0;
                else
                    cbChamp3.SelectedValue = (int)row["TABLE3_ID"];
                if (row["TABLE4_ID"] is System.DBNull)
                    cbChamp4.SelectedValue = 0;
                else
                    cbChamp4.SelectedValue = (int)row["TABLE4_ID"];
                if (row["TABLE5_ID"] is System.DBNull)
                    cbChamp5.SelectedValue = 0;
                else
                    cbChamp5.SelectedValue = (int)row["TABLE5_ID"];
                if (row["TABLE6_ID"] is System.DBNull)
                    cbChamp6.SelectedValue = 0;
                else
                    cbChamp6.SelectedValue = (int)row["TABLE6_ID"];
                if (row["TABLE7_ID"] is System.DBNull)
                    cbChamp7.SelectedValue = 0;
                else
                    cbChamp7.SelectedValue = (int)row["TABLE7_ID"];
                txtObligatoire1.Text = row["TABLE1_OBL"].ToString();
                if (txtObligatoire1.Text == "1")
                    chx_Obligatoire1.Checked = true;
                else
                    chx_Obligatoire1.Checked = false;
                txtObligatoire2.Text = row["TABLE2_OBL"].ToString();
                if (txtObligatoire2.Text == "1")
                    chx_Obligatoire2.Checked = true;
                else
                    chx_Obligatoire2.Checked = false;
                txtObligatoire3.Text = row["TABLE3_OBL"].ToString();
                if (txtObligatoire3.Text == "1")
                    chx_Obligatoire3.Checked = true;
                else
                    chx_Obligatoire3.Checked = false;
                txtObligatoire4.Text = row["TABLE4_OBL"].ToString();
                if (txtObligatoire4.Text == "1")
                    chx_Obligatoire4.Checked = true;
                else
                    chx_Obligatoire4.Checked = false;
                txtObligatoire5.Text = row["TABLE5_OBL"].ToString();
                if (txtObligatoire5.Text == "1")
                    chx_Obligatoire5.Checked = true;
                else
                    chx_Obligatoire5.Checked = false;
                txtObligatoire6.Text = row["TABLE6_OBL"].ToString();
                if (txtObligatoire6.Text == "1")
                    chx_Obligatoire6.Checked = true;
                else
                    chx_Obligatoire6.Checked = false;
                txtObligatoire7.Text = row["TABLE7_OBL"].ToString();
                if (txtObligatoire7.Text == "1")
                    chx_Obligatoire7.Checked = true;
                else
                    chx_Obligatoire7.Checked = false;
                txtAfficherCode1.Text = row["TABLE1_CODE"].ToString();
                if (txtAfficherCode1.Text == "1")
                    chx_AfficherCode1.Checked = true;
                else
                    chx_AfficherCode1.Checked = false;
                txtAfficherCode2.Text = row["TABLE2_CODE"].ToString();
                if (txtAfficherCode2.Text == "1")
                    chx_AfficherCode2.Checked = true;
                else
                    chx_AfficherCode2.Checked = false;
                txtAfficherCode3.Text = row["TABLE3_CODE"].ToString();
                if (txtAfficherCode3.Text == "1")
                    chx_AfficherCode3.Checked = true;
                else
                    chx_AfficherCode3.Checked = false;
                txtAfficherCode4.Text = row["TABLE4_CODE"].ToString();
                if (txtAfficherCode4.Text == "1")
                    chx_AfficherCode4.Checked = true;
                else
                    chx_AfficherCode4.Checked = false;
                txtAfficherCode5.Text = row["TABLE5_CODE"].ToString();
                if (txtAfficherCode5.Text == "1")
                    chx_AfficherCode5.Checked = true;
                else
                    chx_AfficherCode5.Checked = false;
                txtAfficherCode6.Text = row["TABLE6_CODE"].ToString();
                if (txtAfficherCode6.Text == "1")
                    chx_AfficherCode6.Checked = true;
                else
                    chx_AfficherCode6.Checked = false;
                txtAfficherCode7.Text = row["TABLE7_CODE"].ToString();
                if (txtAfficherCode7.Text == "1")
                    chx_AfficherCode7.Checked = true;
                else
                    chx_AfficherCode7.Checked = false;
                cbBorneChamp1.Text = row["TABLE1_BORNE"].ToString();
                cbBorneChamp2.Text = row["TABLE2_BORNE"].ToString();
                cbBorneChamp3.Text = row["TABLE3_BORNE"].ToString();
                cbBorneChamp4.Text = row["TABLE4_BORNE"].ToString();
                cbBorneChamp5.Text = row["TABLE5_BORNE"].ToString();
                cbBorneChamp6.Text = row["TABLE6_BORNE"].ToString();
                cbBorneChamp7.Text = row["TABLE7_BORNE"].ToString();
                txtTicketChamp1.Text = row["TABLE1_TICKET"].ToString();
                if (txtTicketChamp1.Text == "1")
                    cbx_TicketChamp1.Checked = true;
                else
                    cbx_TicketChamp1.Checked = false;
                txtTicketChamp2.Text = row["TABLE2_TICKET"].ToString();
                if (txtTicketChamp2.Text == "1")
                    cbx_TicketChamp2.Checked = true;
                else
                    cbx_TicketChamp2.Checked = false;
                txtTicketChamp3.Text = row["TABLE3_TICKET"].ToString();
                if (txtTicketChamp3.Text == "1")
                    cbx_TicketChamp3.Checked = true;
                else
                    cbx_TicketChamp3.Checked = false;
                txtTicketChamp4.Text = row["TABLE4_TICKET"].ToString();
                if (txtTicketChamp4.Text == "1")
                    cbx_TicketChamp4.Checked = true;
                else
                    cbx_TicketChamp4.Checked = false;
                txtTicketChamp5.Text = row["TABLE5_TICKET"].ToString();
                if (txtTicketChamp5.Text == "1")
                    cbx_TicketChamp5.Checked = true;
                else
                    cbx_TicketChamp5.Checked = false;
                txtTicketChamp6.Text = row["TABLE6_TICKET"].ToString();
                if (txtTicketChamp6.Text == "1")
                    cbx_TicketChamp6.Checked = true;
                else
                    cbx_TicketChamp6.Checked = false;
                txtTicketChamp7.Text = row["TABLE7_TICKET"].ToString();
                if (txtTicketChamp7.Text == "1")
                    cbx_TicketChamp7.Checked = true;
                else
                    cbx_TicketChamp7.Checked = false;
                txtAjoutChamp1.Text = row["TABLE1_AJOUT_F"].ToString();
                if (txtAjoutChamp1.Text == "1")
                    chx_AjoutChamp1.Checked = true;
                else
                    chx_AjoutChamp1.Checked = false;
                txtAjoutChamp2.Text = row["TABLE2_AJOUT_F"].ToString();
                if (txtAjoutChamp2.Text == "1")
                    chx_AjoutChamp2.Checked = true;
                else
                    chx_AjoutChamp2.Checked = false;
                txtAjoutChamp3.Text = row["TABLE3_AJOUT_F"].ToString();
                if (txtAjoutChamp3.Text == "1")
                    chx_AjoutChamp3.Checked = true;
                else
                    chx_AjoutChamp3.Checked = false;
                txtAjoutChamp4.Text = row["TABLE4_AJOUT_F"].ToString();
                if (txtAjoutChamp4.Text == "1")
                    chx_AjoutChamp4.Checked = true;
                else
                    chx_AjoutChamp4.Checked = false;
                txtAjoutChamp5.Text = row["TABLE5_AJOUT_F"].ToString();
                if (txtAjoutChamp5.Text == "1")
                    chx_AjoutChamp5.Checked = true;
                else
                    chx_AjoutChamp5.Checked = false;
                txtAjoutChamp6.Text = row["TABLE6_AJOUT_F"].ToString();
                if (txtAjoutChamp6.Text == "1")
                    chx_AjoutChamp6.Checked = true;
                else
                    chx_AjoutChamp6.Checked = false;
                txtAjoutChamp7.Text = row["TABLE7_AJOUT_F"].ToString();
                if (txtAjoutChamp7.Text == "1")
                    chx_AjoutChamp7.Checked = true;
                else
                    chx_AjoutChamp7.Checked = false;
                txtPontFirme.Text = row["PONTFIRME"].ToString();
                if (txtPontFirme.Text == "1")
                    chx_PontFirme.Checked = true;
                else
                    chx_PontFirme.Checked = false;
                txtCamionChauffeur.Text = row["CAMIONCHAUFFEUR"].ToString();
                if (txtCamionChauffeur.Text == "1")
                    chx_CamionChauffeur.Checked = true;
                else
                    chx_CamionChauffeur.Checked = false;
                txtCamionTransporteur.Text = row["CAMIONTRANSPORTEUR"].ToString();
                if (txtCamionTransporteur.Text == "1")
                    chx_CamionTransporteur.Checked = true;
                else
                    chx_CamionTransporteur.Checked = false;

                cbFormat.Text = row["FORMAT"].ToString();
                txtTitre1.Text = row["TITRE1"].ToString();
                txtTitre2.Text = row["TITRE2"].ToString();
                txtFooter.Text = row["FOOTER"].ToString();

            }
        }

        private void Disable()
        {
            txtDateCreation.Enabled = false;
            txtDesignation.Enabled = false;
            chx_Camion.Enabled = false;
            chx_Chauffeur.Enabled = false;
            chx_Transporteur.Enabled = false;
            chx_Produit.Enabled = false;
            chx_Client.Enabled = false;
            chx_Firme.Enabled = false;
            chx_PontFirme.Enabled = false;
            chx_CamionChauffeur.Enabled = false;
            chx_CamionTransporteur.Enabled = false;

            chx_CamionObligatoire.Enabled = false;
            chx_ChauffeurObligatoire.Enabled = false;
            chx_TransporteurObligatoire.Enabled = false;
            chx_ProduitObligatoire.Enabled = false;
            chx_ClientObligatoire.Enabled = false;
            chx_FirmeObligatoire.Enabled = false;

            cbCamionBorne.Enabled = false;
            cbChauffeurBorne.Enabled = false;
            cbTransporteurBorne.Enabled = false;
            cbProduitBorne.Enabled = false;
            cbClientBorne.Enabled = false;
            cbFirmeBorne.Enabled = false;

            chx_AjoutCamion.Enabled = false;
            chx_AjoutChauffeur.Enabled = false;
            chx_AjoutTransporteur.Enabled = false;
            chx_AjoutProduit.Enabled = false;
            chx_AjoutClient.Enabled = false;
            chx_AjoutFirme.Enabled = false;

            cbChamp1.Enabled = false;
            cbChamp2.Enabled = false;
            cbChamp3.Enabled = false;
            cbChamp4.Enabled = false;
            cbChamp5.Enabled = false;
            cbChamp6.Enabled = false;
            cbChamp7.Enabled = false;

            chx_Obligatoire1.Enabled = false;
            chx_Obligatoire2.Enabled = false;
            chx_Obligatoire3.Enabled = false;
            chx_Obligatoire4.Enabled = false;
            chx_Obligatoire5.Enabled = false;
            chx_Obligatoire6.Enabled = false;
            chx_Obligatoire7.Enabled = false;

            chx_AfficherCode1.Enabled = false;
            chx_AfficherCode2.Enabled = false;
            chx_AfficherCode3.Enabled = false;
            chx_AfficherCode4.Enabled = false;
            chx_AfficherCode5.Enabled = false;
            chx_AfficherCode6.Enabled = false;
            chx_AfficherCode7.Enabled = false;

            cbBorneChamp1.Enabled = false;
            cbBorneChamp2.Enabled = false;
            cbBorneChamp3.Enabled = false;
            cbBorneChamp4.Enabled = false;
            cbBorneChamp5.Enabled = false;
            cbBorneChamp6.Enabled = false;
            cbBorneChamp7.Enabled = false;

            cbx_TicketChamp1.Enabled = false;
            cbx_TicketChamp2.Enabled = false;
            cbx_TicketChamp3.Enabled = false;
            cbx_TicketChamp4.Enabled = false;
            cbx_TicketChamp5.Enabled = false;
            cbx_TicketChamp6.Enabled = false;
            cbx_TicketChamp7.Enabled = false;

            chx_AjoutChamp1.Enabled = false;
            chx_AjoutChamp2.Enabled = false;
            chx_AjoutChamp3.Enabled = false;
            chx_AjoutChamp4.Enabled = false;
            chx_AjoutChamp5.Enabled = false;
            chx_AjoutChamp6.Enabled = false;
            chx_AjoutChamp7.Enabled = false;

            cbFormat.Enabled = false;
            txtTitre1.Enabled = false;
            txtTitre2.Enabled = false;
            txtFooter.Enabled = false;

            pbUpdating.Visible = false;

            vg_IsEnabled = false;
        }

        private void Enable()
        {
            txtDateCreation.Enabled = true;
            txtDesignation.Enabled = true;
            chx_Camion.Enabled = true;
            chx_Chauffeur.Enabled = true;
            chx_Transporteur.Enabled = true;
            chx_Produit.Enabled = true;
            chx_Client.Enabled = true;
            chx_Firme.Enabled = true;
            chx_PontFirme.Enabled = true;
            chx_CamionChauffeur.Enabled = true;
            chx_CamionTransporteur.Enabled = true;

            chx_CamionObligatoire.Enabled = true;
            chx_ChauffeurObligatoire.Enabled = true;
            chx_TransporteurObligatoire.Enabled = true;
            chx_ProduitObligatoire.Enabled = true;
            chx_ClientObligatoire.Enabled = true;
            chx_FirmeObligatoire.Enabled = true;

            cbCamionBorne.Enabled = true;
            cbChauffeurBorne.Enabled = true;
            cbTransporteurBorne.Enabled = true;
            cbProduitBorne.Enabled = true;
            cbClientBorne.Enabled = true;
            cbFirmeBorne.Enabled = true;

            chx_AjoutCamion.Enabled = true;
            chx_AjoutChauffeur.Enabled = true;
            chx_AjoutTransporteur.Enabled = true;
            chx_AjoutProduit.Enabled = true;
            chx_AjoutClient.Enabled = true;
            chx_AjoutFirme.Enabled = true;

            cbChamp1.Enabled = true;
            cbChamp2.Enabled = true;
            cbChamp3.Enabled = true;
            cbChamp4.Enabled = true;
            cbChamp5.Enabled = true;
            cbChamp6.Enabled = true;
            cbChamp7.Enabled = true;

            chx_Obligatoire1.Enabled = true;
            chx_Obligatoire2.Enabled = true;
            chx_Obligatoire3.Enabled = true;
            chx_Obligatoire4.Enabled = true;
            chx_Obligatoire5.Enabled = true;
            chx_Obligatoire6.Enabled = true;
            chx_Obligatoire7.Enabled = true;

            chx_AfficherCode1.Enabled = true;
            chx_AfficherCode2.Enabled = true;
            chx_AfficherCode3.Enabled = true;
            chx_AfficherCode4.Enabled = true;
            chx_AfficherCode5.Enabled = true;
            chx_AfficherCode6.Enabled = true;
            chx_AfficherCode7.Enabled = true;

            cbBorneChamp1.Enabled = true;
            cbBorneChamp2.Enabled = true;
            cbBorneChamp3.Enabled = true;
            cbBorneChamp4.Enabled = true;
            cbBorneChamp5.Enabled = true;
            cbBorneChamp6.Enabled = true;
            cbBorneChamp7.Enabled = true;

            cbx_TicketChamp1.Enabled = true;
            cbx_TicketChamp2.Enabled = true;
            cbx_TicketChamp3.Enabled = true;
            cbx_TicketChamp4.Enabled = true;
            cbx_TicketChamp5.Enabled = true;
            cbx_TicketChamp6.Enabled = true;
            cbx_TicketChamp7.Enabled = true;

            chx_AjoutChamp1.Enabled = true;
            chx_AjoutChamp2.Enabled = true;
            chx_AjoutChamp3.Enabled = true;
            chx_AjoutChamp4.Enabled = true;
            chx_AjoutChamp5.Enabled = true;
            chx_AjoutChamp6.Enabled = true;
            chx_AjoutChamp7.Enabled = true;

            cbFormat.Enabled = true;
            txtTitre1.Enabled = true;
            txtTitre2.Enabled = true;
            txtFooter.Enabled = true;

            pbUpdating.Visible = true;

            vg_IsEnabled = true;
        }

        private void Clear()
        {
            txtId.Text = "";
            txtDateCreation.Text = "";
            txtDesignation.Text = "";
            chx_Camion.Checked = false;
            chx_Chauffeur.Checked = false;
            chx_Transporteur.Checked = false;
            chx_Produit.Checked = false;
            chx_Client.Checked = false;
            chx_Firme.Checked = false;
            chx_PontFirme.Checked = false;
            chx_CamionChauffeur.Checked = false;
            chx_CamionTransporteur.Checked = false;

            chx_CamionObligatoire.Checked = false;
            chx_ChauffeurObligatoire.Checked = false;
            chx_TransporteurObligatoire.Checked = false;
            chx_ProduitObligatoire.Checked = false;
            chx_ClientObligatoire.Checked = false;
            chx_FirmeObligatoire.Checked = false;

            cbCamionBorne.Text = "";
            cbChauffeurBorne.Text = "";
            cbTransporteurBorne.Text = "";
            cbProduitBorne.Text = "";
            cbClientBorne.Text = "";
            cbFirmeBorne.Text = "";

            chx_AjoutCamion.Checked = false;
            chx_AjoutChauffeur.Checked = false;
            chx_AjoutTransporteur.Checked = false;
            chx_AjoutProduit.Checked = false;
            chx_AjoutClient.Checked = false;
            chx_AjoutFirme.Checked = false;

            cbChamp1.Text = "";
            cbChamp2.Text = "";
            cbChamp3.Text = "";
            cbChamp4.Text = "";
            cbChamp5.Text = "";
            cbChamp6.Text = "";
            cbChamp7.Text = "";

            chx_Obligatoire1.Checked = false;
            chx_Obligatoire2.Checked = false;
            chx_Obligatoire3.Checked = false;
            chx_Obligatoire4.Checked = false;
            chx_Obligatoire5.Checked = false;
            chx_Obligatoire6.Checked = false;
            chx_Obligatoire7.Checked = false;

            chx_AfficherCode1.Checked = false;
            chx_AfficherCode2.Checked = false;
            chx_AfficherCode3.Checked = false;
            chx_AfficherCode4.Checked = false;
            chx_AfficherCode5.Checked = false;
            chx_AfficherCode6.Checked = false;
            chx_AfficherCode7.Checked = false;

            cbBorneChamp1.Text = "";
            cbBorneChamp2.Text = "";
            cbBorneChamp3.Text = "";
            cbBorneChamp4.Text = "";
            cbBorneChamp5.Text = "";
            cbBorneChamp6.Text = "";
            cbBorneChamp7.Text = "";

            cbx_TicketChamp1.Checked = false;
            cbx_TicketChamp2.Checked = false;
            cbx_TicketChamp3.Checked = false;
            cbx_TicketChamp4.Checked = false;
            cbx_TicketChamp5.Checked = false;
            cbx_TicketChamp6.Checked = false;
            cbx_TicketChamp7.Checked = false;

            chx_AjoutChamp1.Checked = false;
            chx_AjoutChamp2.Checked = false;
            chx_AjoutChamp3.Checked = false;
            chx_AjoutChamp4.Checked = false;
            chx_AjoutChamp5.Checked = false;
            chx_AjoutChamp6.Checked = false;
            chx_AjoutChamp7.Checked = false;

            cbFormat.Text = "";
            txtTitre1.Text = "";
            txtTitre2.Text = "";
            txtFooter.Text = "";

        }
        private void chx_Camion_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Camion.Checked)
                txtCamion.Text = "1";
            else
                txtCamion.Text = "0";
        }

        private void chx_Chauffeur_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Chauffeur.Checked)
                txtChauffeur.Text = "1";
            else
                txtChauffeur.Text = "0";
        }

        private void chx_Transporteur_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Transporteur.Checked)
                txtTransporteur.Text = "1";
            else
                txtTransporteur.Text = "0";
        }

        private void chx_Produit_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Produit.Checked)
                txtProduit.Text = "1";
            else
                txtProduit.Text = "0";
        }

        private void chx_Client_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Client.Checked)
                txtClient.Text = "1";
            else
                txtClient.Text = "0";
        }

        private void chx_Firme_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Firme.Checked)
                txtFirme.Text = "1";
            else
                txtFirme.Text = "0";
        }

        private void chx_FirmeObligatoire_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_FirmeObligatoire.Checked)
                txtFirmeObligatoire.Text = "1";
            else
                txtFirmeObligatoire.Text = "0";
        }

        private void chx_CamionObligatoire_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_CamionObligatoire.Checked)
                txtCamionObligatoire.Text = "1";
            else
                txtCamionObligatoire.Text = "0";
        }

        private void chx_ChauffeurObligatoire_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_ChauffeurObligatoire.Checked)
                txtChauffeurObligatoire.Text = "1";
            else
                txtChauffeurObligatoire.Text = "0";
        }

        private void chx_TransporteurObligatoire_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_TransporteurObligatoire.Checked)
                txtTransporteurObligatoire.Text = "1";
            else
                txtTransporteurObligatoire.Text = "0";
        }

        private void chx_ProduitObligatoire_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_ProduitObligatoire.Checked)
                txtProduitObligatoire.Text = "1";
            else
                txtProduitObligatoire.Text = "0";
        }

        private void chx_ClientObligatoire_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_ClientObligatoire.Checked)
                txtClientObligatoire.Text = "1";
            else
                txtClientObligatoire.Text = "0";
        }

        private void chx_AjoutFirme_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AjoutFirme.Checked)
                txtAjoutFirme.Text = "1";
            else
                txtAjoutFirme.Text = "0";
        }

        private void chx_AjoutCamion_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AjoutCamion.Checked)
                txtAjoutCamion.Text = "1";
            else
                txtAjoutCamion.Text = "0";
        }

        private void chx_AjoutChauffeur_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AjoutChauffeur.Checked)
                txtAjoutChauffeur.Text = "1";
            else
                txtAjoutChauffeur.Text = "0";
        }

        private void chx_AjoutTransporteur_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AjoutTransporteur.Checked)
                txtAjoutTransporteur.Text = "1";
            else
                txtAjoutTransporteur.Text = "0";
        }

        private void chx_AjoutProduit_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AjoutProduit.Checked)
                txtAjoutProduit.Text = "1";
            else
                txtAjoutProduit.Text = "0";
        }

        private void chx_AjoutClient_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AjoutClient.Checked)
                txtAjoutClient.Text = "1";
            else
                txtAjoutClient.Text = "0";
        }

        private void chx_PontFirme_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_PontFirme.Checked)
                txtPontFirme.Text = "1";
            else
                txtPontFirme.Text = "0";
        }

        private void chx_CamionChauffeur_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_CamionChauffeur.Checked)
                txtCamionChauffeur.Text = "1";
            else
                txtCamionChauffeur.Text = "0";
        }

        private void chx_CamionTransporteur_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_CamionTransporteur.Checked)
                txtCamionTransporteur.Text = "1";
            else
                txtCamionTransporteur.Text = "0";
        }

        private void chx_Obligatoire1_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Obligatoire1.Checked)
                txtObligatoire1.Text = "1";
            else
                txtObligatoire1.Text = "0";
        }

        private void chx_Obligatoire2_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Obligatoire2.Checked)
                txtObligatoire2.Text = "1";
            else
                txtObligatoire2.Text = "0";
        }

        private void chx_Obligatoire3_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Obligatoire3.Checked)
                txtObligatoire3.Text = "1";
            else
                txtObligatoire3.Text = "0";
        }

        private void chx_Obligatoire4_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Obligatoire4.Checked)
                txtObligatoire4.Text = "1";
            else
                txtObligatoire4.Text = "0";
        }

        private void chx_Obligatoire5_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Obligatoire5.Checked)
                txtObligatoire5.Text = "1";
            else
                txtObligatoire5.Text = "0";
        }

        private void chx_Obligatoire6_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Obligatoire6.Checked)
                txtObligatoire6.Text = "1";
            else
                txtObligatoire6.Text = "0";
        }

        private void chx_Obligatoire7_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Obligatoire7.Checked)
                txtObligatoire7.Text = "1";
            else
                txtObligatoire7.Text = "0";
        }

        private void chx_AfficherCode1_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AfficherCode1.Checked)
                txtAfficherCode1.Text = "1";
            else
                txtAfficherCode1.Text = "0";
        }

        private void chx_AfficherCode2_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AfficherCode2.Checked)
                txtAfficherCode2.Text = "1";
            else
                txtAfficherCode2.Text = "0";
        }

        private void chx_AfficherCode3_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AfficherCode3.Checked)
                txtAfficherCode3.Text = "1";
            else
                txtAfficherCode3.Text = "0";
        }

        private void chx_AfficherCode4_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AfficherCode4.Checked)
                txtAfficherCode4.Text = "1";
            else
                txtAfficherCode4.Text = "0";
        }

        private void chx_AfficherCode5_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AfficherCode5.Checked)
                txtAfficherCode5.Text = "1";
            else
                txtAfficherCode5.Text = "0";
        }

        private void chx_AfficherCode6_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AfficherCode6.Checked)
                txtAfficherCode6.Text = "1";
            else
                txtAfficherCode6.Text = "0";
        }

        private void chx_AfficherCode7_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AfficherCode7.Checked)
                txtAfficherCode7.Text = "1";
            else
                txtAfficherCode7.Text = "0";
        }

        private void cbx_TicketChamp1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_TicketChamp1.Checked)
                txtTicketChamp1.Text = "1";
            else
                txtTicketChamp1.Text = "0";
        }

        private void cbx_TicketChamp2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_TicketChamp2.Checked)
                txtTicketChamp2.Text = "1";
            else
                txtTicketChamp2.Text = "0";
        }

        private void cbx_TicketChamp3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_TicketChamp3.Checked)
                txtTicketChamp3.Text = "1";
            else
                txtTicketChamp3.Text = "0";
        }

        private void cbx_TicketChamp4_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_TicketChamp4.Checked)
                txtTicketChamp4.Text = "1";
            else
                txtTicketChamp4.Text = "0";
        }

        private void cbx_TicketChamp5_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_TicketChamp5.Checked)
                txtTicketChamp5.Text = "1";
            else
                txtTicketChamp5.Text = "0";
        }

        private void cbx_TicketChamp6_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_TicketChamp6.Checked)
                txtTicketChamp6.Text = "1";
            else
                txtTicketChamp6.Text = "0";
        }

        private void cbx_TicketChamp7_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_TicketChamp7.Checked)
                txtTicketChamp7.Text = "1";
            else
                txtTicketChamp7.Text = "0";
        }

        private void chx_AjoutChamp1_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AjoutChamp1.Checked)
                txtAjoutChamp1.Text = "1";
            else
                txtAjoutChamp1.Text = "0";
        }

        private void chx_AjoutChamp2_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AjoutChamp2.Checked)
                txtAjoutChamp2.Text = "1";
            else
                txtAjoutChamp2.Text = "0";
        }

        private void chx_AjoutChamp3_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AjoutChamp3.Checked)
                txtAjoutChamp3.Text = "1";
            else
                txtAjoutChamp3.Text = "0";
        }

        private void chx_AjoutChamp4_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AjoutChamp4.Checked)
                txtAjoutChamp4.Text = "1";
            else
                txtAjoutChamp4.Text = "0";
        }

        private void chx_AjoutChamp5_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AjoutChamp5.Checked)
                txtAjoutChamp5.Text = "1";
            else
                txtAjoutChamp5.Text = "0";
        }

        private void chx_AjoutChamp6_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AjoutChamp6.Checked)
                txtAjoutChamp6.Text = "1";
            else
                txtAjoutChamp6.Text = "0";
        }

        private void chx_AjoutChamp7_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_AjoutChamp7.Checked)
                txtAjoutChamp7.Text = "1";
            else
                txtAjoutChamp7.Text = "0";
        }

        private void lbAjouter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtId.Text == "" && txtDateCreation.Text == "" && txtDesignation.Text != "" && txtCamion.Text != "" && txtChauffeur.Text != "" && txtTransporteur.Text != ""
                    && txtProduit.Text != "" && txtClient.Text != ""  && txtFirme.Text != "" && cbFormat.Text != "")
                {
                    int Camion;
                    int Chauffeur;
                    int Transporteur;
                    int Produit;
                    int Client;
                    int Firme;
                    int FirmeObligatoire;
                    int CamionObligatoire;
                    int ChauffeurObligatoire;
                    int TransporteurObligatoire;
                    int ProduitObligatoire;
                    int ClientObligatoire;
                    int AjoutFirme;
                    int AjoutCamion;
                    int AjoutChauffeur;
                    int AjoutTransporteur;
                    int AjoutProduit;
                    int AjoutClient;
                    int TableObligatoire1;
                    int TableObligatoire2;
                    int TableObligatoire3;
                    int TableObligatoire4;
                    int TableObligatoire5;
                    int TableObligatoire6;
                    int TableObligatoire7;
                    int AfficherCode1;
                    int AfficherCode2;
                    int AfficherCode3;
                    int AfficherCode4;
                    int AfficherCode5;
                    int AfficherCode6;
                    int AfficherCode7;
                    int Ticket1;
                    int Ticket2;
                    int Ticket3;
                    int Ticket4;
                    int Ticket5;
                    int Ticket6;
                    int Ticket7;
                    int AjoutChamp1;   
                    int AjoutChamp2;
                    int AjoutChamp3;                        
                    int AjoutChamp4;                       
                    int AjoutChamp5;
                    int AjoutChamp6;
                    int AjoutChamp7;
                    int LibreObligatoire1; 
                    int LibreObligatoire2;
                    int LibreObligatoire3;
                    int LibreObligatoire4;
                    int LibreTicket1; 
                    int LibreTicket2;
                    int LibreTicket3;
                    int LibreTicket4;
                    int PontFirme;
                    int CamionChauffeur;
                    int CamionTransporteur;

                    bool IsParsableCamion;
                    bool IsParsableChauffeur;
                    bool IsParsableTransporteur;
                    bool IsParsableProduit;
                    bool IsParsableClient;
                    bool IsParsableFirme;
                    bool IsParsableFirmeObligatoire;
                    bool IsParsableCamionObligatoire;
                    bool IsParsableChauffeurObligatoire;
                    bool IsParsableTransporteurObligatoire;
                    bool IsParsableProduitObligatoire;
                    bool IsParsableClientObligatoire;
                    bool IsParsableAjoutFirme;
                    bool IsParsableAjoutCamion;
                    bool IsParsableAjoutChauffeur;
                    bool IsParsableAjoutTransporteur;
                    bool IsParsableAjoutProduit;
                    bool IsParsableAjoutClient;
                    bool IsParsableTableObligatoire1;
                    bool IsParsableTableObligatoire2;
                    bool IsParsableTableObligatoire3;
                    bool IsParsableTableObligatoire4;
                    bool IsParsableTableObligatoire5;
                    bool IsParsableTableObligatoire6;
                    bool IsParsableTableObligatoire7;
                    bool IsParsableAfficherCode1;
                    bool IsParsableAfficherCode2;
                    bool IsParsableAfficherCode3;
                    bool IsParsableAfficherCode4;
                    bool IsParsableAfficherCode5;
                    bool IsParsableAfficherCode6;
                    bool IsParsableAfficherCode7;
                    bool IsParsableTicket1;
                    bool IsParsableTicket2;
                    bool IsParsableTicket3;
                    bool IsParsableTicket4;
                    bool IsParsableTicket5;
                    bool IsParsableTicket6;
                    bool IsParsableTicket7;
                    bool IsParsableAjoutChamp1;
                    bool IsParsableAjoutChamp2;
                    bool IsParsableAjoutChamp3;
                    bool IsParsableAjoutChamp4;
                    bool IsParsableAjoutChamp5;
                    bool IsParsableAjoutChamp6;
                    bool IsParsableAjoutChamp7;
                    bool IsParsableLibreObligatoire1;
                    bool IsParsableLibreObligatoire2;
                    bool IsParsableLibreObligatoire3;
                    bool IsParsableLibreObligatoire4;
                    bool IsParsableLibreTicket1;
                    bool IsParsableLibreTicket2;
                    bool IsParsableLibreTicket3;
                    bool IsParsableLibreTicket4;
                    bool IsParsablePontFirme;
                    bool IsParsableCamionChauffeur;
                    bool IsParsableCamionTransporteur;


                    IsParsableCamion = Int32.TryParse(txtCamion.Text, out Camion);
                    IsParsableChauffeur = Int32.TryParse(txtChauffeur.Text, out Chauffeur);
                    IsParsableTransporteur = Int32.TryParse(txtTransporteur.Text, out Transporteur);
                    IsParsableProduit = Int32.TryParse(txtProduit.Text, out Produit);
                    IsParsableClient = Int32.TryParse(txtClient.Text, out Client);
                    IsParsableFirme = Int32.TryParse(txtFirme.Text, out Firme);
                    IsParsableFirmeObligatoire = Int32.TryParse(txtFirmeObligatoire.Text, out FirmeObligatoire);
                    IsParsableCamionObligatoire = Int32.TryParse(txtCamionObligatoire.Text, out CamionObligatoire);
                    IsParsableChauffeurObligatoire = Int32.TryParse(txtChauffeurObligatoire.Text, out ChauffeurObligatoire);
                    IsParsableTransporteurObligatoire = Int32.TryParse(txtTransporteurObligatoire.Text, out TransporteurObligatoire);
                    IsParsableProduitObligatoire = Int32.TryParse(txtProduitObligatoire.Text, out ProduitObligatoire);
                    IsParsableClientObligatoire = Int32.TryParse(txtClientObligatoire.Text, out ClientObligatoire);
                    IsParsableAjoutFirme = Int32.TryParse(txtAjoutFirme.Text, out AjoutFirme);
                    IsParsableAjoutCamion = Int32.TryParse(txtAjoutCamion.Text, out AjoutCamion);
                    IsParsableAjoutChauffeur = Int32.TryParse(txtAjoutChauffeur.Text, out AjoutChauffeur);
                    IsParsableAjoutTransporteur = Int32.TryParse(txtAjoutTransporteur.Text, out AjoutTransporteur);
                    IsParsableAjoutProduit = Int32.TryParse(txtAjoutProduit.Text, out AjoutProduit);
                    IsParsableAjoutClient = Int32.TryParse(txtAjoutClient.Text, out AjoutClient);
                    IsParsableTableObligatoire1 = Int32.TryParse(txtObligatoire1.Text, out TableObligatoire1);
                    IsParsableTableObligatoire2 = Int32.TryParse(txtObligatoire2.Text, out TableObligatoire2);
                    IsParsableTableObligatoire3 = Int32.TryParse(txtObligatoire3.Text, out TableObligatoire3);
                    IsParsableTableObligatoire4 = Int32.TryParse(txtObligatoire4.Text, out TableObligatoire4);
                    IsParsableTableObligatoire5 = Int32.TryParse(txtObligatoire5.Text, out TableObligatoire5);
                    IsParsableTableObligatoire6 = Int32.TryParse(txtObligatoire6.Text, out TableObligatoire6);
                    IsParsableTableObligatoire7 = Int32.TryParse(txtObligatoire7.Text, out TableObligatoire7);
                    IsParsableAfficherCode1 = Int32.TryParse(txtAfficherCode1.Text, out AfficherCode1);
                    IsParsableAfficherCode2 = Int32.TryParse(txtAfficherCode2.Text, out AfficherCode2);
                    IsParsableAfficherCode3 = Int32.TryParse(txtAfficherCode3.Text, out AfficherCode3);
                    IsParsableAfficherCode4 = Int32.TryParse(txtAfficherCode4.Text, out AfficherCode4);
                    IsParsableAfficherCode5 = Int32.TryParse(txtAfficherCode5.Text, out AfficherCode5);
                    IsParsableAfficherCode6 = Int32.TryParse(txtAfficherCode6.Text, out AfficherCode6);
                    IsParsableAfficherCode7 = Int32.TryParse(txtAfficherCode7.Text, out AfficherCode7);
                    IsParsableTicket1 = Int32.TryParse(txtTicketChamp1.Text, out Ticket1);
                    IsParsableTicket2 = Int32.TryParse(txtTicketChamp2.Text, out Ticket2);
                    IsParsableTicket3 = Int32.TryParse(txtTicketChamp3.Text, out Ticket3);
                    IsParsableTicket4 = Int32.TryParse(txtTicketChamp4.Text, out Ticket4);
                    IsParsableTicket5 = Int32.TryParse(txtTicketChamp5.Text, out Ticket5);
                    IsParsableTicket6 = Int32.TryParse(txtTicketChamp6.Text, out Ticket6);
                    IsParsableTicket7 = Int32.TryParse(txtTicketChamp7.Text, out Ticket7);
                    IsParsableAjoutChamp1 = Int32.TryParse(txtAjoutChamp1.Text, out AjoutChamp1);
                    IsParsableAjoutChamp2 = Int32.TryParse(txtAjoutChamp2.Text, out AjoutChamp2);
                    IsParsableAjoutChamp3 = Int32.TryParse(txtAjoutChamp3.Text, out AjoutChamp3);
                    IsParsableAjoutChamp4 = Int32.TryParse(txtAjoutChamp4.Text, out AjoutChamp4);
                    IsParsableAjoutChamp5 = Int32.TryParse(txtAjoutChamp5.Text, out AjoutChamp5);
                    IsParsableAjoutChamp6 = Int32.TryParse(txtAjoutChamp6.Text, out AjoutChamp6);
                    IsParsableAjoutChamp7 = Int32.TryParse(txtAjoutChamp7.Text, out AjoutChamp7);
                    IsParsableLibreObligatoire1 = Int32.TryParse(txtLibreObligatoire1.Text, out LibreObligatoire1);
                    IsParsableLibreObligatoire2 = Int32.TryParse(txtLibreObligatoire2.Text, out LibreObligatoire2);
                    IsParsableLibreObligatoire3 = Int32.TryParse(txtLibreObligatoire3.Text, out LibreObligatoire3);
                    IsParsableLibreObligatoire4 = Int32.TryParse(txtLibreObligatoire4.Text, out LibreObligatoire4);
                    IsParsableLibreTicket1 = Int32.TryParse(txtTicketChampLibre1.Text, out LibreTicket1);
                    IsParsableLibreTicket2 = Int32.TryParse(txtTicketChampLibre2.Text, out LibreTicket2);
                    IsParsableLibreTicket3 = Int32.TryParse(txtTicketChampLibre3.Text, out LibreTicket3);
                    IsParsableLibreTicket4 = Int32.TryParse(txtTicketChampLibre4.Text, out LibreTicket4);
                    IsParsablePontFirme = Int32.TryParse(txtPontFirme.Text, out PontFirme);
                    IsParsableCamionChauffeur = Int32.TryParse(txtCamionChauffeur.Text, out CamionChauffeur);
                    IsParsableCamionTransporteur = Int32.TryParse(txtCamionTransporteur.Text, out CamionTransporteur);




                    try
                    {
                        if (IsParsableCamion && IsParsableChauffeur && IsParsableTransporteur && IsParsableProduit && IsParsableClient && IsParsableFirme 
                            && IsParsableFirmeObligatoire && IsParsableCamionObligatoire && IsParsableChauffeurObligatoire && IsParsableTransporteurObligatoire && IsParsableProduitObligatoire && IsParsableClientObligatoire
                    && IsParsableAjoutFirme && IsParsableAjoutCamion && IsParsableAjoutChauffeur && IsParsableAjoutTransporteur && IsParsableAjoutProduit && IsParsableAjoutClient && IsParsableTableObligatoire1
                    && IsParsableTableObligatoire2 && IsParsableTableObligatoire3 && IsParsableTableObligatoire4 && IsParsableTableObligatoire5 && IsParsableTableObligatoire6  && IsParsableTableObligatoire7
                    && IsParsableAfficherCode1 && IsParsableAfficherCode2 && IsParsableAfficherCode3 && IsParsableAfficherCode4 && IsParsableAfficherCode5 && IsParsableAfficherCode6 && IsParsableAfficherCode7
                    && IsParsableTicket1 && IsParsableTicket2 && IsParsableTicket3 && IsParsableTicket4 && IsParsableTicket5 && IsParsableTicket6 && IsParsableTicket7 && IsParsableAjoutChamp1 && IsParsableAjoutChamp2
                    && IsParsableAjoutChamp3 && IsParsableAjoutChamp4 && IsParsableAjoutChamp5 && IsParsableAjoutChamp6 && IsParsableAjoutChamp7 && IsParsableLibreObligatoire1 && IsParsableLibreObligatoire2 && IsParsableLibreObligatoire3
                    && IsParsableLibreObligatoire4 && IsParsableLibreTicket1 && IsParsableLibreTicket2 && IsParsableLibreTicket3 && IsParsableLibreTicket4 && IsParsablePontFirme && IsParsableCamionChauffeur && IsParsableCamionTransporteur)
                        {
                            WeighingSettings weighingSettings = new WeighingSettings();
                            weighingSettings.Add(txtDesignation.Text, Camion, Chauffeur, Transporteur, Produit, Client, Firme, CamionObligatoire, ChauffeurObligatoire, TransporteurObligatoire, ProduitObligatoire, ClientObligatoire
                                , FirmeObligatoire, cbCamionBorne.Text, cbChauffeurBorne.Text, cbTransporteurBorne.Text, cbProduitBorne.Text, cbClientBorne.Text, cbFirmeBorne.Text, AjoutCamion, AjoutChauffeur, 
                                AjoutTransporteur, AjoutProduit, AjoutClient, AjoutFirme, Common_functions.CbSelectedValue_Convert_Int(cbChamp1), Common_functions.CbSelectedValue_Convert_Int(cbChamp2), Common_functions.CbSelectedValue_Convert_Int(cbChamp3),
                                Common_functions.CbSelectedValue_Convert_Int(cbChamp4), Common_functions.CbSelectedValue_Convert_Int(cbChamp5), Common_functions.CbSelectedValue_Convert_Int(cbChamp6), Common_functions.CbSelectedValue_Convert_Int(cbChamp7),
                                TableObligatoire1, TableObligatoire2, TableObligatoire3, TableObligatoire4, TableObligatoire5, TableObligatoire6, TableObligatoire7, AfficherCode1, AfficherCode2, AfficherCode3, AfficherCode4, AfficherCode5, AfficherCode6, 
                                AfficherCode7, cbBorneChamp1.Text, cbBorneChamp2.Text, cbBorneChamp3.Text, cbBorneChamp4.Text, cbBorneChamp5.Text, cbBorneChamp6.Text, cbBorneChamp7.Text, Ticket1, Ticket2, Ticket3, Ticket4, Ticket5, Ticket6, Ticket7, 
                                AjoutChamp1, AjoutChamp2, AjoutChamp3, AjoutChamp4, AjoutChamp5, AjoutChamp6, AjoutChamp7, txtChampLibre1.Text, txtChampLibre2.Text, txtChampLibre3.Text, txtChampLibre4.Text, LibreObligatoire1, LibreObligatoire2, LibreObligatoire3,
                                LibreObligatoire4, LibreTicket1,LibreTicket2, LibreTicket3, LibreTicket4,  
                                cbBorneChampLibre1.Text, cbBorneChampLibre2.Text, cbBorneChampLibre3.Text, cbBorneChampLibre4.Text,
                                PontFirme, CamionChauffeur, CamionTransporteur, cbFormat.Text, txtTitre1.Text, txtTitre2.Text, txtFooter.Text);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Paramètre ajouté avec succès", "Paramètre de pesée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Setting added successfully", "Weighing setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Parámetro agregado", "Parámetro de pesaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                    }
                    catch
                    {
                        throw;
                    }

                }
                else
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Informations incomplètes", "Paramètre de pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "Incomplete informations", "Weighing setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        Custom_MessageBox.Show("ES", "Información incompleta", "Parámetro de pesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                throw;
            }
        }

        private void lbModifier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (vg_Update == false && vg_IsEnabled == false)
                {
                    Enable();
                    lbModifier.Text = Language_Manager.Localize("Valider", cbLang.Text);
                    vg_Update = true;
                }
                else
                {
                    try
                    {
                        if (txtId.Text != "" && txtDateCreation.Text != "" && txtDesignation.Text != "" && txtCamion.Text != "" && txtChauffeur.Text != "" && txtTransporteur.Text != ""
                            && txtProduit.Text != "" && txtClient.Text != "" && txtFirme.Text != "" && cbFormat.Text != "")
                        {
                            
                            int Id;
                            int Camion;
                            int Chauffeur;
                            int Transporteur;
                            int Produit;
                            int Client;
                            int Firme;
                            int FirmeObligatoire;
                            int CamionObligatoire;
                            int ChauffeurObligatoire;
                            int TransporteurObligatoire;
                            int ProduitObligatoire;
                            int ClientObligatoire;
                            int AjoutFirme;
                            int AjoutCamion;
                            int AjoutChauffeur;
                            int AjoutTransporteur;
                            int AjoutProduit;
                            int AjoutClient;
                            int TableObligatoire1;
                            int TableObligatoire2;
                            int TableObligatoire3;
                            int TableObligatoire4;
                            int TableObligatoire5;
                            int TableObligatoire6;
                            int TableObligatoire7;
                            int AfficherCode1;
                            int AfficherCode2;
                            int AfficherCode3;
                            int AfficherCode4;
                            int AfficherCode5;
                            int AfficherCode6;
                            int AfficherCode7;
                            int Ticket1;
                            int Ticket2;
                            int Ticket3;
                            int Ticket4;
                            int Ticket5;
                            int Ticket6;
                            int Ticket7;
                            int AjoutChamp1;
                            int AjoutChamp2;
                            int AjoutChamp3;
                            int AjoutChamp4;
                            int AjoutChamp5;
                            int AjoutChamp6;
                            int AjoutChamp7;
                            int LibreObligatoire1;
                            int LibreObligatoire2;
                            int LibreObligatoire3;
                            int LibreObligatoire4;
                            int LibreTicket1;
                            int LibreTicket2;
                            int LibreTicket3;
                            int LibreTicket4;
                            int PontFirme;
                            int CamionChauffeur;
                            int CamionTransporteur;

                            bool IsParsableId;
                            bool IsParsableCamion;
                            bool IsParsableChauffeur;
                            bool IsParsableTransporteur;
                            bool IsParsableProduit;
                            bool IsParsableClient;
                            bool IsParsableFirme;
                            bool IsParsableFirmeObligatoire;
                            bool IsParsableCamionObligatoire;
                            bool IsParsableChauffeurObligatoire;
                            bool IsParsableTransporteurObligatoire;
                            bool IsParsableProduitObligatoire;
                            bool IsParsableClientObligatoire;
                            bool IsParsableAjoutFirme;
                            bool IsParsableAjoutCamion;
                            bool IsParsableAjoutChauffeur;
                            bool IsParsableAjoutTransporteur;
                            bool IsParsableAjoutProduit;
                            bool IsParsableAjoutClient;
                            bool IsParsableTableObligatoire1;
                            bool IsParsableTableObligatoire2;
                            bool IsParsableTableObligatoire3;
                            bool IsParsableTableObligatoire4;
                            bool IsParsableTableObligatoire5;
                            bool IsParsableTableObligatoire6;
                            bool IsParsableTableObligatoire7;
                            bool IsParsableAfficherCode1;
                            bool IsParsableAfficherCode2;
                            bool IsParsableAfficherCode3;
                            bool IsParsableAfficherCode4;
                            bool IsParsableAfficherCode5;
                            bool IsParsableAfficherCode6;
                            bool IsParsableAfficherCode7;
                            bool IsParsableTicket1;
                            bool IsParsableTicket2;
                            bool IsParsableTicket3;
                            bool IsParsableTicket4;
                            bool IsParsableTicket5;
                            bool IsParsableTicket6;
                            bool IsParsableTicket7;
                            bool IsParsableAjoutChamp1;
                            bool IsParsableAjoutChamp2;
                            bool IsParsableAjoutChamp3;
                            bool IsParsableAjoutChamp4;
                            bool IsParsableAjoutChamp5;
                            bool IsParsableAjoutChamp6;
                            bool IsParsableAjoutChamp7;
                            bool IsParsableLibreObligatoire1;
                            bool IsParsableLibreObligatoire2;
                            bool IsParsableLibreObligatoire3;
                            bool IsParsableLibreObligatoire4;
                            bool IsParsableLibreTicket1;
                            bool IsParsableLibreTicket2;
                            bool IsParsableLibreTicket3;
                            bool IsParsableLibreTicket4;
                            bool IsParsablePontFirme;
                            bool IsParsableCamionChauffeur;
                            bool IsParsableCamionTransporteur;

                            IsParsableId = Int32.TryParse(txtId.Text, out Id);
                            IsParsableCamion = Int32.TryParse(txtCamion.Text, out Camion);
                            IsParsableChauffeur = Int32.TryParse(txtChauffeur.Text, out Chauffeur);
                            IsParsableTransporteur = Int32.TryParse(txtTransporteur.Text, out Transporteur);
                            IsParsableProduit = Int32.TryParse(txtProduit.Text, out Produit);
                            IsParsableClient = Int32.TryParse(txtClient.Text, out Client);
                            IsParsableFirme = Int32.TryParse(txtFirme.Text, out Firme);
                            IsParsableFirmeObligatoire = Int32.TryParse(txtFirmeObligatoire.Text, out FirmeObligatoire);
                            IsParsableCamionObligatoire = Int32.TryParse(txtCamionObligatoire.Text, out CamionObligatoire);
                            IsParsableChauffeurObligatoire = Int32.TryParse(txtChauffeurObligatoire.Text, out ChauffeurObligatoire);
                            IsParsableTransporteurObligatoire = Int32.TryParse(txtTransporteurObligatoire.Text, out TransporteurObligatoire);
                            IsParsableProduitObligatoire = Int32.TryParse(txtProduitObligatoire.Text, out ProduitObligatoire);
                            IsParsableClientObligatoire = Int32.TryParse(txtClientObligatoire.Text, out ClientObligatoire);
                            IsParsableAjoutFirme = Int32.TryParse(txtAjoutFirme.Text, out AjoutFirme);
                            IsParsableAjoutCamion = Int32.TryParse(txtAjoutCamion.Text, out AjoutCamion);
                            IsParsableAjoutChauffeur = Int32.TryParse(txtAjoutChauffeur.Text, out AjoutChauffeur);
                            IsParsableAjoutTransporteur = Int32.TryParse(txtAjoutTransporteur.Text, out AjoutTransporteur);
                            IsParsableAjoutProduit = Int32.TryParse(txtAjoutProduit.Text, out AjoutProduit);
                            IsParsableAjoutClient = Int32.TryParse(txtAjoutClient.Text, out AjoutClient);
                            IsParsableTableObligatoire1 = Int32.TryParse(txtObligatoire1.Text, out TableObligatoire1);
                            IsParsableTableObligatoire2 = Int32.TryParse(txtObligatoire2.Text, out TableObligatoire2);
                            IsParsableTableObligatoire3 = Int32.TryParse(txtObligatoire3.Text, out TableObligatoire3);
                            IsParsableTableObligatoire4 = Int32.TryParse(txtObligatoire4.Text, out TableObligatoire4);
                            IsParsableTableObligatoire5 = Int32.TryParse(txtObligatoire5.Text, out TableObligatoire5);
                            IsParsableTableObligatoire6 = Int32.TryParse(txtObligatoire6.Text, out TableObligatoire6);
                            IsParsableTableObligatoire7 = Int32.TryParse(txtObligatoire7.Text, out TableObligatoire7);
                            IsParsableAfficherCode1 = Int32.TryParse(txtAfficherCode1.Text, out AfficherCode1);
                            IsParsableAfficherCode2 = Int32.TryParse(txtAfficherCode2.Text, out AfficherCode2);
                            IsParsableAfficherCode3 = Int32.TryParse(txtAfficherCode3.Text, out AfficherCode3);
                            IsParsableAfficherCode4 = Int32.TryParse(txtAfficherCode4.Text, out AfficherCode4);
                            IsParsableAfficherCode5 = Int32.TryParse(txtAfficherCode5.Text, out AfficherCode5);
                            IsParsableAfficherCode6 = Int32.TryParse(txtAfficherCode6.Text, out AfficherCode6);
                            IsParsableAfficherCode7 = Int32.TryParse(txtAfficherCode7.Text, out AfficherCode7);
                            IsParsableTicket1 = Int32.TryParse(txtTicketChamp1.Text, out Ticket1);
                            IsParsableTicket2 = Int32.TryParse(txtTicketChamp2.Text, out Ticket2);
                            IsParsableTicket3 = Int32.TryParse(txtTicketChamp3.Text, out Ticket3);
                            IsParsableTicket4 = Int32.TryParse(txtTicketChamp4.Text, out Ticket4);
                            IsParsableTicket5 = Int32.TryParse(txtTicketChamp5.Text, out Ticket5);
                            IsParsableTicket6 = Int32.TryParse(txtTicketChamp6.Text, out Ticket6);
                            IsParsableTicket7 = Int32.TryParse(txtTicketChamp7.Text, out Ticket7);
                            IsParsableAjoutChamp1 = Int32.TryParse(txtAjoutChamp1.Text, out AjoutChamp1);
                            IsParsableAjoutChamp2 = Int32.TryParse(txtAjoutChamp2.Text, out AjoutChamp2);
                            IsParsableAjoutChamp3 = Int32.TryParse(txtAjoutChamp3.Text, out AjoutChamp3);
                            IsParsableAjoutChamp4 = Int32.TryParse(txtAjoutChamp4.Text, out AjoutChamp4);
                            IsParsableAjoutChamp5 = Int32.TryParse(txtAjoutChamp5.Text, out AjoutChamp5);
                            IsParsableAjoutChamp6 = Int32.TryParse(txtAjoutChamp6.Text, out AjoutChamp6);
                            IsParsableAjoutChamp7 = Int32.TryParse(txtAjoutChamp7.Text, out AjoutChamp7);
                            IsParsableLibreObligatoire1 = Int32.TryParse(txtLibreObligatoire1.Text, out LibreObligatoire1);
                            IsParsableLibreObligatoire2 = Int32.TryParse(txtLibreObligatoire2.Text, out LibreObligatoire2);
                            IsParsableLibreObligatoire3 = Int32.TryParse(txtLibreObligatoire3.Text, out LibreObligatoire3);
                            IsParsableLibreObligatoire4 = Int32.TryParse(txtLibreObligatoire4.Text, out LibreObligatoire4);
                            IsParsableLibreTicket1 = Int32.TryParse(txtTicketChampLibre1.Text, out LibreTicket1);
                            IsParsableLibreTicket2 = Int32.TryParse(txtTicketChampLibre2.Text, out LibreTicket2);
                            IsParsableLibreTicket3 = Int32.TryParse(txtTicketChampLibre3.Text, out LibreTicket3);
                            IsParsableLibreTicket4 = Int32.TryParse(txtTicketChampLibre4.Text, out LibreTicket4);
                            IsParsablePontFirme = Int32.TryParse(txtPontFirme.Text, out PontFirme);
                            IsParsableCamionChauffeur = Int32.TryParse(txtCamionChauffeur.Text, out CamionChauffeur);
                            IsParsableCamionTransporteur = Int32.TryParse(txtCamionTransporteur.Text, out CamionTransporteur);

                            try
                            {
                                if (IsParsableId && IsParsableCamion && IsParsableChauffeur && IsParsableTransporteur && IsParsableProduit && IsParsableClient && IsParsableFirme
                            && IsParsableFirmeObligatoire && IsParsableCamionObligatoire && IsParsableChauffeurObligatoire && IsParsableTransporteurObligatoire && IsParsableProduitObligatoire && IsParsableClientObligatoire
                            && IsParsableAjoutFirme && IsParsableAjoutCamion && IsParsableAjoutChauffeur && IsParsableAjoutTransporteur && IsParsableAjoutProduit && IsParsableAjoutClient && IsParsableTableObligatoire1
                            && IsParsableTableObligatoire2 && IsParsableTableObligatoire3 && IsParsableTableObligatoire4 && IsParsableTableObligatoire5 && IsParsableTableObligatoire6 && IsParsableTableObligatoire7
                            && IsParsableAfficherCode1 && IsParsableAfficherCode2 && IsParsableAfficherCode3 && IsParsableAfficherCode4 && IsParsableAfficherCode5 && IsParsableAfficherCode6 && IsParsableAfficherCode7
                            && IsParsableTicket1 && IsParsableTicket2 && IsParsableTicket3 && IsParsableTicket4 && IsParsableTicket5 && IsParsableTicket6 && IsParsableTicket7 && IsParsableAjoutChamp1 && IsParsableAjoutChamp2
                            && IsParsableAjoutChamp3 && IsParsableAjoutChamp4 && IsParsableAjoutChamp5 && IsParsableAjoutChamp6 && IsParsableAjoutChamp7 && IsParsableLibreObligatoire1 && IsParsableLibreObligatoire2 && IsParsableLibreObligatoire3
                    && IsParsableLibreObligatoire4 && IsParsableLibreTicket1 && IsParsableLibreTicket2 && IsParsableLibreTicket3 && IsParsableLibreTicket4 && IsParsablePontFirme && IsParsableCamionChauffeur && IsParsableCamionTransporteur)
                                {
                                    WeighingSettings weighingSettings = new WeighingSettings();
                                    weighingSettings.Update(Id, txtDesignation.Text, Camion, Chauffeur, Transporteur, Produit, Client, Firme, CamionObligatoire, ChauffeurObligatoire, TransporteurObligatoire, ProduitObligatoire, ClientObligatoire
                                , FirmeObligatoire, cbCamionBorne.Text, cbChauffeurBorne.Text, cbTransporteurBorne.Text, cbProduitBorne.Text, cbClientBorne.Text, cbFirmeBorne.Text, AjoutCamion, AjoutChauffeur,
                                AjoutTransporteur, AjoutProduit, AjoutClient, AjoutFirme, Common_functions.CbSelectedValue_Convert_Int_2(cbChamp1), Common_functions.CbSelectedValue_Convert_Int(cbChamp2), Common_functions.CbSelectedValue_Convert_Int(cbChamp3),
                                Common_functions.CbSelectedValue_Convert_Int(cbChamp4), Common_functions.CbSelectedValue_Convert_Int(cbChamp5), Common_functions.CbSelectedValue_Convert_Int(cbChamp6), Common_functions.CbSelectedValue_Convert_Int(cbChamp7),
                                TableObligatoire1, TableObligatoire2, TableObligatoire3, TableObligatoire4, TableObligatoire5, TableObligatoire6, TableObligatoire7, AfficherCode1, AfficherCode2, AfficherCode3, AfficherCode4, AfficherCode5, AfficherCode6,
                                AfficherCode7, cbBorneChamp1.Text, cbBorneChamp2.Text, cbBorneChamp3.Text, cbBorneChamp4.Text, cbBorneChamp5.Text, cbBorneChamp6.Text, cbBorneChamp7.Text, Ticket1, Ticket2, Ticket3, Ticket4, Ticket5, Ticket6, Ticket7,
                                AjoutChamp1, AjoutChamp2, AjoutChamp3, AjoutChamp4, AjoutChamp5, AjoutChamp6, AjoutChamp7, txtChampLibre1.Text, txtChampLibre2.Text, txtChampLibre3.Text, txtChampLibre4.Text, LibreObligatoire1, LibreObligatoire2, LibreObligatoire3,
                                LibreObligatoire4, LibreTicket1, LibreTicket2, LibreTicket3, LibreTicket4,
                                cbBorneChampLibre1.Text, cbBorneChampLibre2.Text, cbBorneChampLibre3.Text, cbBorneChampLibre4.Text, PontFirme, CamionChauffeur, CamionTransporteur, cbFormat.Text, txtTitre1.Text, txtTitre2.Text, txtFooter.Text);
                                    if (cbLang.Text == "FR")
                                        Custom_MessageBox.Show("FR", "Paramètre modifié avec succès", "Paramètre de pesée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else if (cbLang.Text == "EN")
                                        Custom_MessageBox.Show("EN", "Setting updated successfully", "Weighing setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                        Custom_MessageBox.Show("ES", "Parámetro alterado", "Parámetro de pesaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lbModifier.Text = Language_Manager.Localize("Modifier", cbLang.Text);
                                    vg_Update = false;
                                    Disable();
                                    Bind_Fields();
                                }
                            }
                            catch
                            {
                                throw;
                            }
                        }
                        else
                        {
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Informations incomplètes", "Paramètre de pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Incomplete informations", "Weighing setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                Custom_MessageBox.Show("ES", "Información incompleta", "Parámetro de pesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void lbSupprimer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (vg_Update)
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas supprimer l'enregistrement tant que la modification n'est pas validée", "Paramètre de pesée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You can't delete this record before the update is completed", "Weighing setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    Custom_MessageBox.Show("ES", "No puede eliminar el registro hasta que se confirme el cambio", "Parámetro de pesaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    WeighingSettings weighingSettings = new WeighingSettings();
                    int Id;
                    bool IsParsableId;
                    IsParsableId = Int32.TryParse(txtId.Text, out Id);
                    if (IsParsableId)
                    {
                        DialogResult result;
                        if (cbLang.Text == "FR")
                            result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir supprimer cet enregistrement?", "Paramètre de pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else if (cbLang.Text == "EN")
                            result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "Weighing setting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else
                            result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Parámetro de pesaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            weighingSettings.Delete(Id);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Paramètre supprimé avec succès", "Paramètre de pesée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Setting deleted successfully", "Weighing setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Parámetro eliminado", "Parámetro de pesaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }

                    }
                }
                catch
                {
                    throw;
                }

            }
        }

        private void WeighingSettingsDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vg_Mode == "Edit")
            {
                if (pbUpdating.Visible)
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Vous ne pouvez pas fermer la fenetre tant que la modification n'est pas validée", "Paramètre de pesée", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "You can't close this window before the update is completed", "Weighing setting", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        Custom_MessageBox.Show("ES", "No puede cerrar la página hasta que se valide el cambio", "Parámetro de pesaje", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    e.Cancel = true;
                }
            }
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(WeighingSettingsDetail));

            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(WeighingSettingsDetail));
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(WeighingSettingsDetail));
            }
        }

        
    }
}
