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
    public partial class PeseePBDetail : Form
    {
        int vg_UtilisateurId;
        int vg_PeseePBId;

        // Weighing Settings Informations
        int EnableCamion;
        int EnableChauffeur;
        int EnableTransporteur;
        int EnableProduit;
        int EnableClient;
        int EnableFirme;
        int EnableWalterre;
        int Camion_Obl;
        int Chauffeur_Obl;
        int Transporteur_Obl;
        int Produit_Obl;
        int Client_Obl;
        int Firme_Obl;
        int Camion_Ajout;
        int Chauffeur_Ajout;
        int Transporteur_Ajout;
        int Produit_Ajout;
        int Client_Ajout;
        int Firme_Ajout;
        int Table1Id;
        int Table2Id;
        int Table3Id;
        int Table4Id;
        int Table5Id;
        int Table6Id;
        int Table7Id;
        string Table1Name = "";
        string Table2Name = "";
        string Table3Name = "";
        string Table4Name = "";
        string Table5Name = "";
        string Table6Name = "";
        string Table7Name = "";
        int Table1_Obl;
        int Table2_Obl;
        int Table3_Obl;
        int Table4_Obl;
        int Table5_Obl;
        int Table6_Obl;
        int Table7_Obl;
        int Table1_Code;
        int Table2_Code;
        int Table3_Code;
        int Table4_Code;
        int Table5_Code;
        int Table6_Code;
        int Table7_Code;
        int Table1_Ajout;
        int Table2_Ajout;
        int Table3_Ajout;
        int Table4_Ajout;
        int Table5_Ajout;
        int Table6_Ajout;
        int Table7_Ajout;
        string ChampLibre1Name = "";
        string ChampLibre2Name = "";
        string ChampLibre3Name = "";
        string ChampLibre4Name = "";
        int ChampLibre1_Obl;
        int ChampLibre2_Obl;
        int ChampLibre3_Obl;
        int ChampLibre4_Obl;
        int ChampLibre1_Ticket;
        int ChampLibre2_Ticket;
        int ChampLibre3_Ticket;
        int ChampLibre4_Ticket;
        int PontFirme;
        int CamionChauffeur;
        int CamionTransporteur;


        //Weighing Type 
        string TypePesee;
        //Flux
        string Flux;

        String vg_Mode = "";
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;

        bool init_WeighingSettings = false;

        public PeseePBDetail(Int32 UtilisateurId, Int32 PeseePBId)
        {
            InitializeComponent();
            vg_UtilisateurId = UtilisateurId;
            vg_PeseePBId = PeseePBId;
        }

        private void PeseePBDetail_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            //Pont 
            Pont pont = new Pont();
            cbPont.DataSource = pont.List("1=1");
            cbPont.DisplayMember = "DESIGNATION";
            cbPont.ValueMember = "PONTID";

            //WeighingSettings
            WeighingSettings weighingSettings = new WeighingSettings();
            cbWeighingSettingsId.DataSource = weighingSettings.List("1=1");
            cbWeighingSettingsId.DisplayMember = "DESIGNATION";
            cbWeighingSettingsId.ValueMember = "WEIGHING_SETTINGSID";


            Filter2.Visible = false;
            Filter3.Visible = false;
            Filter4.Visible = false;
            Filter5.Visible = false;
            Filter6.Visible = false;
            Filter7.Visible = false;


            Initialize_Data();

            Bind_Fields();

            ApplyWeighingSettings(Common_functions.CbSelectedValue_Convert_Int_2(cbWeighingSettingsId));

            init_WeighingSettings = true;

            Bind_Fields();

            Disable();


            Utilisateur utilisateur = new Utilisateur();
            lblusername.Text = utilisateur.GetFullUsername(vg_UtilisateurId);

            //Lang
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = MenuGeneral.languuage_index;
        }

        private void Initialize_Data()
        {
            //Firme
            Firme firme = new Firme();
            cbFirme.DataSource = firme.List("1=1");
            cbFirme.DisplayMember = "DESIGNATION";
            cbFirme.ValueMember = "FIRMEID";

            //Camion
            Camion camion = new Camion();
            cbCamion.DataSource = camion.List("1=1");
            cbCamion.DisplayMember = "PLAQUE";
            cbCamion.ValueMember = "CAMIONID";

            //Chauffeur
            Chauffeur chauffeur = new Chauffeur();
            cbChauffeur.DataSource = chauffeur.List("1=1");
            cbChauffeur.DisplayMember = "NOM";
            cbChauffeur.ValueMember = "CHAUFFEURID";

            //Transporteur
            Transporteur transporteur = new Transporteur();
            cbTransporteur.DataSource = transporteur.List("1=1");
            cbTransporteur.DisplayMember = "NOM";
            cbTransporteur.ValueMember = "TRANSPORTEURID";

            //Produit
            Produit produit = new Produit();
            cbProduit.DataSource = produit.List("1=1");
            cbProduit.DisplayMember = "DESIGNATION";
            cbProduit.ValueMember = "PRODUITID";

            //Client
            Client client = new Client();
            cbClient.DataSource = client.List("1=1");
            cbClient.DisplayMember = "DESIGNATION";
            cbClient.ValueMember = "CLIENTID";
        }

        private void Bind_Fields()
        {
            DataTable dt = new DataTable();
            PeseePB peseePB = new PeseePB();
            dt = peseePB.FindById(vg_PeseePBId);
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["PESEEPBID"];
                txtId.Text = Id.ToString();

                if (row["TYPEPESEE"].ToString() == "1x")
                {
                    rb1x.Checked = true;
                    TypePesee = "1x";
                }
                else
                {
                    rb2x1.Checked = true;
                    TypePesee = "2x";
                }

                if (row["WEIGHING_SETTINGSID"] is System.DBNull)
                    cbWeighingSettingsId.SelectedValue = 0;
                else
                    cbWeighingSettingsId.SelectedValue = (int)row["WEIGHING_SETTINGSID"];

                if (row["FLUX"].ToString() == "In")
                    rbxEntrant.Checked = true;
                else
                    rbxSortant.Checked = true;
                if (row["PONTID"] is System.DBNull)
                    cbPont.SelectedValue = 0;
                else
                    cbPont.SelectedValue = (int)row["PONTID"];
                cbPont_Leave(this, EventArgs.Empty);
                if (row["FIRMEID"] is System.DBNull)
                    cbFirme.SelectedValue = 0;
                else
                    cbFirme.SelectedValue = (int)row["FIRMEID"];
                cbFirme_Leave(this, EventArgs.Empty);
                if (row["CAMIONID"] is System.DBNull)
                    cbCamion.SelectedValue = 0;
                else
                    cbCamion.SelectedValue = (int)row["CAMIONID"];
                cbCamion_Leave(this, EventArgs.Empty);
                if (row["CHAUFFEURID"] is System.DBNull)
                    cbChauffeur.SelectedValue = 0;
                else
                    cbChauffeur.SelectedValue = (int)row["CHAUFFEURID"];
                cbChauffeur_Leave(this, EventArgs.Empty);
                if (row["TRANSPORTEURID"] is System.DBNull)
                    cbTransporteur.SelectedValue = 0;
                else
                    cbTransporteur.SelectedValue = (int)row["TRANSPORTEURID"];
                cbTransporteur_Leave(this, EventArgs.Empty);
                if (row["PRODUITID"] is System.DBNull)
                    cbProduit.SelectedValue = 0;
                else
                    cbProduit.SelectedValue = (int)row["PRODUITID"];
                cbProduit_Leave(this, EventArgs.Empty);
                if (row["CLIENTID"] is System.DBNull)
                    cbClient.SelectedValue = 0;
                else
                    cbClient.SelectedValue = (int)row["CLIENTID"];
                cbClient_Leave(this, EventArgs.Empty);
                if (row["WALTERREID"] is System.DBNull)
                    cbWalterre.SelectedValue = 0;
                else
                    cbWalterre.SelectedValue = (int)row["WALTERREID"];
                cbWalterre_Leave(this, EventArgs.Empty);
                if (row["ENREGISTREMENTSID1"] is System.DBNull)
                    cbChamp1.SelectedValue = 0;
                else
                    cbChamp1.SelectedValue = (int)row["ENREGISTREMENTSID1"];
                cbChamp1_Leave(this, EventArgs.Empty);
                if (row["ENREGISTREMENTSID2"] is System.DBNull)
                    cbChamp2.SelectedValue = 0;
                else
                    cbChamp2.SelectedValue = (int)row["ENREGISTREMENTSID2"];
                cbChamp2_Leave(this, EventArgs.Empty);
                if (row["ENREGISTREMENTSID3"] is System.DBNull)
                    cbChamp3.SelectedValue = 0;
                else
                    cbChamp3.SelectedValue = (int)row["ENREGISTREMENTSID3"];
                cbChamp3_Leave(this, EventArgs.Empty);
                if (row["ENREGISTREMENTSID4"] is System.DBNull)
                    cbChamp4.SelectedValue = 0;
                else
                    cbChamp4.SelectedValue = (int)row["ENREGISTREMENTSID4"];
                cbChamp4_Leave(this, EventArgs.Empty);
                if (row["ENREGISTREMENTSID5"] is System.DBNull)
                    cbChamp5.SelectedValue = 0;
                else
                    cbChamp5.SelectedValue = (int)row["ENREGISTREMENTSID5"];
                cbChamp5_Leave(this, EventArgs.Empty);
                if (row["ENREGISTREMENTSID6"] is System.DBNull)
                    cbChamp6.SelectedValue = 0;
                else
                    cbChamp6.SelectedValue = (int)row["ENREGISTREMENTSID6"];
                cbChamp6_Leave(this, EventArgs.Empty);
                if (row["ENREGISTREMENTSID7"] is System.DBNull)
                    cbChamp7.SelectedValue = 0;
                else
                    cbChamp7.SelectedValue = (int)row["ENREGISTREMENTSID7"];
                cbChamp7_Leave(this, EventArgs.Empty);
                txtEtatPesee.Text = row["ETATPESEE"].ToString();
                if (txtEtatPesee.Text == "Pending")
                    txtEtatPesee.ForeColor = Color.OrangeRed;
                else
                    txtEtatPesee.ForeColor = Color.FromArgb(11, 228, 132);

                txtChampLibre1.Text = row["CHAMPLIBRE1"].ToString();
                txtChampLibre2.Text = row["CHAMPLIBRE2"].ToString();
                txtChampLibre3.Text = row["CHAMPLIBRE3"].ToString();
                txtChampLibre4.Text = row["CHAMPLIBRE4"].ToString();

                lbPoidsBrut.Text = row["POIDS1"].ToString();
                lbDateHeurePoidsBrut.Text = row["DATEHEUREPOIDS1"].ToString();
                lbPoidsTare.Text = row["POIDS2"].ToString();
                lbDateHeurePoidsTare.Text = row["DATEHEUREPOIDS2"].ToString();
                lbPoidsNet.Text = row["POIDSNET"].ToString();
                //lbStatus.Text = row["ETATPESEE"].ToString();
            }
        }

        private void Edit_Item_1x()
        {
            if (vg_PeseePBId > 0)
            {
                Bind_Fields();
                ApplyWeighingSettings(Common_functions.CbSelectedValue_Convert_Int(cbWeighingSettingsId));

            }
        }

        private void Edit_Item_2x()
        {
            if (vg_PeseePBId > 0)
            {
                Bind_Fields();
                ApplyWeighingSettings(Common_functions.CbSelectedValue_Convert_Int(cbWeighingSettingsId));
            }
        }

        private void ApplyWeighingSettings(Int32 WeighingSettingsId)
        {
            WeighingSettings weighingSettings = new WeighingSettings();
            Tables tables = new Tables();
            Enregistrements enregistrements = new Enregistrements();
            DataTable dtWeighingSettings = new DataTable();
            dtWeighingSettings = weighingSettings.FindById(WeighingSettingsId);
            foreach (DataRow ro in dtWeighingSettings.Rows)
            {
                EnableCamion = (int)ro["CAMION"];
                EnableChauffeur = (int)ro["CHAUFFEUR"];
                EnableTransporteur = (int)ro["TRANSPORTEUR"];
                EnableProduit = (int)ro["PRODUIT"];
                EnableClient = (int)ro["CLIENT"];
                EnableFirme = (int)ro["FIRME"];
                EnableWalterre = (int)ro["WALTERRE"];

                Camion_Obl = (int)ro["CAMION_OBL"];
                Chauffeur_Obl = (int)ro["CHAUFFEUR_OBL"];
                Transporteur_Obl = (int)ro["TRANSPORTEUR_OBL"];
                Produit_Obl = (int)ro["PRODUIT_OBL"];
                Client_Obl = (int)ro["CLIENT_OBL"];
                Firme_Obl = (int)ro["FIRME_OBL"];

                Camion_Ajout = (int)ro["CAMION_AJOUT_F"];
                Chauffeur_Ajout = (int)ro["CHAUFFEUR_AJOUT_F"];
                Transporteur_Ajout = (int)ro["TRANSPORTEUR_AJOUT_F"];
                Produit_Ajout = (int)ro["PRODUIT_AJOUT_F"];
                Client_Ajout = (int)ro["CLIENT_AJOUT_F"];
                Firme_Ajout = (int)ro["FIRME_AJOUT_F"];

                Table1Id = (int)ro["TABLE1_ID"];
                Table2Id = (int)ro["TABLE2_ID"];
                Table3Id = (int)ro["TABLE3_ID"];
                Table4Id = (int)ro["TABLE4_ID"];
                Table5Id = (int)ro["TABLE5_ID"];
                Table6Id = (int)ro["TABLE6_ID"];
                Table7Id = (int)ro["TABLE7_ID"];

                Table1_Obl = (int)ro["TABLE1_OBL"];
                Table2_Obl = (int)ro["TABLE2_OBL"];
                Table3_Obl = (int)ro["TABLE3_OBL"];
                Table4_Obl = (int)ro["TABLE4_OBL"];
                Table5_Obl = (int)ro["TABLE5_OBL"];
                Table6_Obl = (int)ro["TABLE6_OBL"];
                Table7_Obl = (int)ro["TABLE7_OBL"];

                Table1_Code = (int)ro["TABLE1_CODE"];
                Table2_Code = (int)ro["TABLE2_CODE"];
                Table3_Code = (int)ro["TABLE3_CODE"];
                Table4_Code = (int)ro["TABLE4_CODE"];
                Table5_Code = (int)ro["TABLE5_CODE"];
                Table6_Code = (int)ro["TABLE6_CODE"];
                Table7_Code = (int)ro["TABLE7_CODE"];

                Table1_Ajout = (int)ro["TABLE1_AJOUT_F"];
                Table2_Ajout = (int)ro["TABLE2_AJOUT_F"];
                Table3_Ajout = (int)ro["TABLE3_AJOUT_F"];
                Table4_Ajout = (int)ro["TABLE4_AJOUT_F"];
                Table5_Ajout = (int)ro["TABLE5_AJOUT_F"];
                Table6_Ajout = (int)ro["TABLE6_AJOUT_F"];
                Table7_Ajout = (int)ro["TABLE7_AJOUT_F"];

                ChampLibre1_Obl = (int)ro["CHAMPLIBRE1_OBL"];
                ChampLibre2_Obl = (int)ro["CHAMPLIBRE2_OBL"];
                ChampLibre3_Obl = (int)ro["CHAMPLIBRE3_OBL"];
                ChampLibre4_Obl = (int)ro["CHAMPLIBRE4_OBL"];

                ChampLibre1_Ticket = (int)ro["CHAMPLIBRE1_TICKET"];
                ChampLibre2_Ticket = (int)ro["CHAMPLIBRE2_TICKET"];
                ChampLibre3_Ticket = (int)ro["CHAMPLIBRE3_TICKET"];
                ChampLibre4_Ticket = (int)ro["CHAMPLIBRE4_TICKET"];

                ChampLibre1Name = ro["CHAMPLIBRE1"].ToString();
                ChampLibre2Name = ro["CHAMPLIBRE2"].ToString();
                ChampLibre3Name = ro["CHAMPLIBRE3"].ToString();
                ChampLibre4Name = ro["CHAMPLIBRE4"].ToString();

                PontFirme = (int)ro["PONTFIRME"];
                CamionChauffeur = (int)ro["CAMIONCHAUFFEUR"];
                CamionTransporteur = (int)ro["CAMIONTRANSPORTEUR"];

            }

            if (EnableCamion == 0)
            {
                cbCamion.Enabled = false;
                RqCamion.Visible = false;
            }
            else
            {
                cbCamion.Enabled = true;
                if (Camion_Obl == 0)
                    RqCamion.Visible = false;
                else
                    RqCamion.Visible = true;
            }
            if (EnableChauffeur == 0)
            {
                cbChauffeur.Enabled = false;
                RqChauffeur.Visible = false;
            }
            else
            {
                cbChauffeur.Enabled = true;
                if (Chauffeur_Obl == 0)
                    RqChauffeur.Visible = false;
                else
                    RqChauffeur.Visible = true;
            }
            if (EnableTransporteur == 0)
            {
                cbTransporteur.Enabled = false;
                RqTransporteur.Visible = false;
            }
            else
            {
                cbTransporteur.Enabled = true;
                if (Transporteur_Obl == 0)
                    RqTransporteur.Visible = false;
                else
                    RqTransporteur.Visible = true;
            }
            if (EnableProduit == 0)
            {
                cbProduit.Enabled = false;
                RqProduit.Visible = false;
            }
            else
            {
                cbProduit.Enabled = true;
                if (Produit_Obl == 0)
                    RqProduit.Visible = false;
                else
                    RqProduit.Visible = true;
            }
            if (EnableClient == 0)
            {
                cbClient.Enabled = false;
                RqClient.Visible = false;
            }
            else
            {
                cbClient.Enabled = true;
                if (Client_Obl == 0)
                    RqClient.Visible = false;
                else
                    RqClient.Visible = true;
            }
            if (EnableFirme == 0)
            {
                cbFirme.Enabled = false;
                RqFirme.Visible = false;
            }
            else
            {
                cbFirme.Enabled = true;
                if (Firme_Obl == 0)
                    RqFirme.Visible = false;
                else
                    RqFirme.Visible = true;
            }

            if (EnableWalterre == 0)
            {
                cbWalterre.Visible = false;
                lbWalterre.Visible = false;
                RqWalterre.Visible = false;
            }
            else
            {
                Walterre walterre = new Walterre();
                cbWalterre.Visible = true;
                lbWalterre.Visible = true;
                RqWalterre.Visible = true;
                cbWalterre.DataSource = walterre.List("1=1");
                cbWalterre.DisplayMember = "CODE";
                cbWalterre.ValueMember = "WALTERREID";
                //cbChamp1_SelectedValueChanged(this, EventArgs.Empty);
                cbWalterre_Leave(this, EventArgs.Empty);

            }

            if (Table1Id == 0)
            {
                cbChamp1.Visible = false;
                lbChamp1.Visible = false;
                RqChamp1.Visible = false;
                btAddChamp1.Visible = false;
            }
            else
            {
                cbChamp1.Visible = true;
                lbChamp1.Visible = true;
                if (Table1_Obl == 0)
                    RqChamp1.Visible = false;
                else
                    RqChamp1.Visible = true;
                btAddChamp1.Visible = true;
                string table_name = tables.GetName(Table1Id);
                lbChamp1.Text = table_name;
                Table1Name = table_name;
                cbChamp1.DataSource = enregistrements.FindByTableId(Table1Id);
                cbChamp1.DisplayMember = "NOM";
                cbChamp1.ValueMember = "ENREGISTREMENTSID";
                //cbChamp1_SelectedValueChanged(this, EventArgs.Empty);
                cbChamp1_Leave(this, EventArgs.Empty);


            }

            if (Table2Id == 0)
            {
                cbChamp2.Visible = false;
                lbChamp2.Visible = false;
                RqChamp2.Visible = false;
                btAddChamp2.Visible = false;
            }
            else
            {
                cbChamp2.Visible = true;
                lbChamp2.Visible = true;
                if (Table2_Obl == 0)
                    RqChamp2.Visible = false;
                else
                    RqChamp2.Visible = true;
                btAddChamp2.Visible = true;
                string table_name = tables.GetName(Table2Id);
                lbChamp2.Text = table_name;
                Table2Name = table_name;
                cbChamp2.DataSource = enregistrements.FindByTableId(Table2Id);
                cbChamp2.DisplayMember = "NOM";
                cbChamp2.ValueMember = "ENREGISTREMENTSID";
                //cbChamp2_SelectedValueChanged(this, EventArgs.Empty);
                cbChamp2_Leave(this, EventArgs.Empty);
            }

            if (Table3Id == 0)
            {
                cbChamp3.Visible = false;
                lbChamp3.Visible = false;
                RqChamp3.Visible = false;
                btAddChamp3.Visible = false;
            }
            else
            {
                cbChamp3.Visible = true;
                lbChamp3.Visible = true;
                if (Table3_Obl == 0)
                    RqChamp3.Visible = false;
                else
                    RqChamp3.Visible = true;
                btAddChamp3.Visible = true;
                string table_name = tables.GetName(Table3Id);
                lbChamp3.Text = table_name;
                Table3Name = table_name;
                cbChamp3.DataSource = enregistrements.FindByTableId(Table3Id);
                cbChamp3.DisplayMember = "NOM";
                cbChamp3.ValueMember = "ENREGISTREMENTSID";
                //cbChamp3_SelectedValueChanged(this, EventArgs.Empty);
                cbChamp3_Leave(this, EventArgs.Empty);
            }

            if (Table4Id == 0)
            {
                cbChamp4.Visible = false;
                lbChamp4.Visible = false;
                RqChamp4.Visible = false;
                btAddChamp4.Visible = false;
            }
            else
            {
                cbChamp4.Visible = true;
                lbChamp4.Visible = true;
                if (Table4_Obl == 0)
                    RqChamp4.Visible = false;
                else
                    RqChamp4.Visible = true;
                btAddChamp4.Visible = true;
                string table_name = tables.GetName(Table4Id);
                lbChamp4.Text = table_name;
                Table4Name = table_name;
                cbChamp4.DataSource = enregistrements.FindByTableId(Table4Id);
                cbChamp4.DisplayMember = "NOM";
                cbChamp4.ValueMember = "ENREGISTREMENTSID";
                cbChamp4_Leave(this, EventArgs.Empty);
            }

            if (Table5Id == 0)
            {
                cbChamp5.Visible = false;
                lbChamp5.Visible = false;
                RqChamp5.Visible = false;
                btAddChamp5.Visible = false;
            }
            else
            {
                cbChamp5.Visible = true;
                lbChamp5.Visible = true;
                if (Table5_Obl == 0)
                    RqChamp5.Visible = false;
                else
                    RqChamp5.Visible = true;
                btAddChamp5.Visible = true;
                string table_name = tables.GetName(Table5Id);
                lbChamp5.Text = table_name;
                Table5Name = table_name;
                cbChamp5.DataSource = enregistrements.FindByTableId(Table5Id);
                cbChamp5.DisplayMember = "NOM";
                cbChamp5.ValueMember = "ENREGISTREMENTSID";
                cbChamp5_Leave(this, EventArgs.Empty);
            }

            if (Table6Id == 0)
            {
                cbChamp6.Visible = false;
                lbChamp6.Visible = false;
                RqChamp6.Visible = false;
                btAddChamp6.Visible = false;
            }
            else
            {
                cbChamp6.Visible = true;
                lbChamp6.Visible = true;
                if (Table6_Obl == 0)
                    RqChamp6.Visible = false;
                else
                    RqChamp6.Visible = true;
                btAddChamp6.Visible = true;
                string table_name = tables.GetName(Table6Id);
                lbChamp6.Text = table_name;
                Table6Name = table_name;
                cbChamp6.DataSource = enregistrements.FindByTableId(Table6Id);
                cbChamp6.DisplayMember = "NOM";
                cbChamp6.ValueMember = "ENREGISTREMENTSID";
                cbChamp6_Leave(this, EventArgs.Empty);
            }

            if (Table7Id == 0)
            {
                cbChamp7.Visible = false;
                lbChamp7.Visible = false;
                RqChamp7.Visible = false;
                btAddChamp7.Visible = false;
            }
            else
            {
                cbChamp7.Visible = true;
                lbChamp7.Visible = true;
                if (Table7_Obl == 0)
                    RqChamp7.Visible = false;
                else
                    RqChamp7.Visible = true;
                btAddChamp7.Visible = true;
                string table_name = tables.GetName(Table7Id);
                lbChamp7.Text = table_name;
                cbChamp7.DataSource = enregistrements.FindByTableId(Table7Id);
                cbChamp7.DisplayMember = "NOM";
                cbChamp7.ValueMember = "ENREGISTREMENTSID";
                cbChamp7_Leave(this, EventArgs.Empty);
            }

            if (ChampLibre1Name.Trim().Length > 2)
            {
                lbChampLibre1.Visible = true;
                txtChampLibre1.Visible = true;
                lbChampLibre1.Text = ChampLibre1Name;
                if (ChampLibre1_Obl != 0)
                    RqChampLibre1.Visible = true;
                else
                    RqChampLibre1.Visible = false;
            }
            else
            {
                lbChampLibre1.Visible = false;
                txtChampLibre1.Visible = false;
                RqChampLibre1.Visible = false;
            }

            if (ChampLibre2Name.Trim().Length > 2)
            {
                lbChampLibre2.Visible = true;
                txtChampLibre2.Visible = true;
                lbChampLibre2.Text = ChampLibre2Name;
                if (ChampLibre2_Obl != 0)
                    RqChampLibre2.Visible = true;
                else
                    RqChampLibre2.Visible = false;
            }
            else
            {
                lbChampLibre2.Visible = false;
                txtChampLibre2.Visible = false;
                RqChampLibre2.Visible = false;
            }

            if (ChampLibre3Name.Trim().Length > 2)
            {
                lbChampLibre3.Visible = true;
                txtChampLibre3.Visible = true;
                lbChampLibre3.Text = ChampLibre3Name;
                if (ChampLibre3_Obl != 0)
                    RqChampLibre3.Visible = true;
                else
                    RqChampLibre3.Visible = false;
            }
            else
            {
                lbChampLibre3.Visible = false;
                txtChampLibre3.Visible = false;
                RqChampLibre3.Visible = false;
            }

            if (ChampLibre4Name.Trim().Length > 2)
            {
                lbChampLibre4.Visible = true;
                txtChampLibre4.Visible = true;
                lbChampLibre4.Text = ChampLibre4Name;
                if (ChampLibre4_Obl != 0)
                    RqChampLibre4.Visible = true;
                else
                    RqChampLibre4.Visible = false;
            }
            else
            {
                lbChampLibre4.Visible = false;
                txtChampLibre4.Visible = false;
                RqChampLibre4.Visible = false;
            }

            //InitializeWeighingSettings(Common_functions.CbSelectedValue_Convert_Int(cbPont));

        }

        private void panelData_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbChampLibre1_Click(object sender, EventArgs e)
        {

        }

        private void RqChampLibre1_Click(object sender, EventArgs e)
        {

        }

        private void rb1x_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rb2x1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Disable()
        {
            cbFirme.Enabled = false;
            cbCamion.Enabled = false;
            cbChauffeur.Enabled = false;
            cbTransporteur.Enabled = false;
            cbProduit.Enabled = false;
            cbClient.Enabled = false;
            cbWalterre.Enabled = false;
            cbChamp1.Enabled = false;
            cbChamp2.Enabled = false;
            cbChamp3.Enabled = false;
            cbChamp4.Enabled = false;
            cbChamp5.Enabled = false;
            cbChamp6.Enabled = false;
            cbChamp7.Enabled = false;
            txtChampLibre1.Enabled = false;
            txtChampLibre2.Enabled = false;
            txtChampLibre3.Enabled = false;
            txtChampLibre4.Enabled = false;

            pbUpdating.Visible = false;

            vg_IsEnabled = false;
        }

        private void Enable()
        {
            if (EnableFirme != 0)
                cbFirme.Enabled = true;
            if (EnableCamion != 0)
                cbCamion.Enabled = true;
            if (EnableChauffeur != 0)
                cbChauffeur.Enabled = true;
            if (EnableTransporteur != 0)
                cbTransporteur.Enabled = true;
            if (EnableProduit != 0)
                cbProduit.Enabled = true;
            if (EnableClient != 0)
                cbClient.Enabled = true;
            cbWalterre.Enabled = true;
            cbChamp1.Enabled = true;
            cbChamp2.Enabled = true;
            cbChamp3.Enabled = true;
            cbChamp4.Enabled = true;
            cbChamp5.Enabled = true;
            cbChamp6.Enabled = true;
            cbChamp7.Enabled = true;
            txtChampLibre1.Enabled = true;
            txtChampLibre2.Enabled = true;
            txtChampLibre3.Enabled = true;
            txtChampLibre4.Enabled = true;

            pbUpdating.Visible = true;

            vg_IsEnabled = true;
        }

        private void rbxEntrant_CheckedChanged(object sender, EventArgs e)
        {
            if (rbxEntrant.Checked)
                Flux = "In";
        }

        private void rbxSortant_CheckedChanged(object sender, EventArgs e)
        {
            if (rbxSortant.Checked)
                Flux = "Out";
        }

        private void cbPont_Leave(object sender, EventArgs e)
        {
            if (cbPont.Text != "")
            {
                Pont pont = new Pont();
                if (pont.IfExists(cbPont.Text))
                {
                    cbPont.BackColor = Color.FromArgb(58, 62, 60);
                    cbPont.ForeColor = Color.White;
                    btAddPont.Visible = false;
                }
                else
                {
                    cbPont.BackColor = Color.Honeydew;
                    cbPont.ForeColor = Color.Black;
                    btAddPont.Visible = true;
                }
            }
        }

        private void cbFirme_Leave(object sender, EventArgs e)
        {
            if (cbFirme.Text != "")
            {
                Firme firme = new Firme();
                if (firme.IfExists(cbFirme.Text))
                {
                    cbFirme.BackColor = Color.FromArgb(58, 62, 60);
                    cbFirme.ForeColor = Color.White;
                    btAddFirme.Visible = false;
                }
                else
                {
                    cbFirme.BackColor = Color.Honeydew;
                    cbFirme.ForeColor = Color.Black;
                    if (Firme_Ajout != 0)
                        btAddFirme.Visible = true;
                }
            }
            else
            {
                cbFirme.BackColor = Color.Honeydew;
                cbFirme.ForeColor = Color.Black;
            }
        }

        private void cbCamion_Leave(object sender, EventArgs e)
        {
            if (cbCamion.Text != "")
            {
                Camion camion = new Camion();
                if (camion.IfExists(cbCamion.Text))
                {
                    cbCamion.BackColor = Color.FromArgb(58, 62, 60);
                    cbCamion.ForeColor = Color.White;
                    btAddCamion.Visible = false;
                }
                else
                {
                    cbCamion.BackColor = Color.Honeydew;
                    cbCamion.ForeColor = Color.Black;
                    if (Camion_Ajout != 0)
                        btAddCamion.Visible = true;
                }
            }
            else
            {
                cbCamion.BackColor = Color.Honeydew;
                cbCamion.ForeColor = Color.Black;
            }
        }

        private void cbChauffeur_Leave(object sender, EventArgs e)
        {
            if (cbChauffeur.Text != "")
            {
                Chauffeur chauffeur = new Chauffeur();
                if (chauffeur.IfExists(cbChauffeur.Text))
                {
                    cbChauffeur.BackColor = Color.FromArgb(58, 62, 60);
                    cbChauffeur.ForeColor = Color.White;
                    btAddChauffeur.Visible = false;
                }
                else
                {
                    cbChauffeur.BackColor = Color.Honeydew;
                    cbChauffeur.ForeColor = Color.Black;
                    if (Chauffeur_Ajout != 0)
                        btAddChauffeur.Visible = true;
                }
            }
            else
            {
                cbChauffeur.BackColor = Color.Honeydew;
                cbChauffeur.ForeColor = Color.Black;
            }
        }

        private void cbTransporteur_Leave(object sender, EventArgs e)
        {
            if (cbTransporteur.Text != "")
            {
                Transporteur transporteur = new Transporteur();
                if (transporteur.IfExists(cbTransporteur.Text))
                {
                    cbTransporteur.BackColor = Color.FromArgb(58, 62, 60);
                    cbTransporteur.ForeColor = Color.White;
                    btAddTransporteur.Visible = false;
                }
                else
                {
                    cbTransporteur.BackColor = Color.Honeydew;
                    cbTransporteur.ForeColor = Color.Black;
                    if (Transporteur_Ajout != 0)
                        btAddTransporteur.Visible = true;
                }
            }
            else
            {
                cbTransporteur.BackColor = Color.Honeydew;
                cbTransporteur.ForeColor = Color.Black;
            }
        }

        private void cbProduit_Leave(object sender, EventArgs e)
        {
            if (cbProduit.Text != "")
            {
                Produit produit = new Produit();
                if (produit.IfExists(cbProduit.Text))
                {
                    cbProduit.BackColor = Color.FromArgb(58, 62, 60);
                    cbProduit.ForeColor = Color.White;
                    btAddProduit.Visible = false;
                }
                else
                {
                    cbProduit.BackColor = Color.Honeydew;
                    cbProduit.ForeColor = Color.Black;
                    if (Produit_Ajout != 0)
                        btAddProduit.Visible = true;
                }
            }
            else
            {
                cbProduit.BackColor = Color.Honeydew;
                cbProduit.ForeColor = Color.Black;
            }
        }

        private void cbClient_Leave(object sender, EventArgs e)
        {
            if (cbClient.Text != "")
            {
                Client client = new Client();
                if (client.IfExists(cbClient.Text))
                {
                    cbClient.BackColor = Color.FromArgb(58, 62, 60);
                    cbClient.ForeColor = Color.White;
                    btAddClient.Visible = false;
                }
                else
                {
                    cbClient.BackColor = Color.Honeydew;
                    cbClient.ForeColor = Color.Black;
                    if (Client_Ajout != 0)
                        btAddClient.Visible = true;
                }
            }
            else
            {
                cbClient.BackColor = Color.Honeydew;
                cbClient.ForeColor = Color.Black;
            }
        }

        private void btAddFirme_Click(object sender, EventArgs e)
        {
            if (cbFirme.Text != "" && cbFirme.Text.Trim().Length > 1)
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir ajouter la firme: " + cbFirme.Text + "?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure you want to add the firm: " + cbFirme.Text + "?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Firme firme = new Firme();
                        firme.Add("", cbFirme.Text, "", "", "", "", "", "", "", "", "", 1, 0, "", 0, "");
                        cbFirme.DataSource = firme.List("1=1");
                        cbFirme.SelectedIndex = cbFirme.Items.Count - 1;
                        cbFirme.Focus();
                        cbCamion.Focus();
                    }
                    catch
                    {
                        throw;
                    }

                }
            }
        }

        private void btAddCamion_Click(object sender, EventArgs e)
        {
            if (cbCamion.Text != "" && cbCamion.Text.Trim().Length > 1)
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir ajouter le camion: " + cbCamion.Text + "?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure you want to add the truck: " + cbCamion.Text + "?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Camion camion = new Camion();
                        camion.Add("", cbCamion.Text, "", 0, 1, 0, "", 0, "", "");
                        cbCamion.DataSource = camion.List("1=1");
                        cbCamion.SelectedIndex = cbCamion.Items.Count - 1;
                        cbCamion.Focus();
                        cbChauffeur.Focus();
                    }
                    catch
                    {
                        throw;
                    }

                }
            }
        }

        private void btAddChauffeur_Click(object sender, EventArgs e)
        {
            if (cbChauffeur.Text != "" && cbChauffeur.Text.Trim().Length > 1)
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir ajouter le chauffeur: " + cbChauffeur.Text + "?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure you want to add the driver: " + cbChauffeur.Text + "?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Chauffeur chauffeur = new Chauffeur();
                        chauffeur.Add("", cbChauffeur.Text, "", "", "", "", "", "", "", "", 1, 0, "", 0, "");
                        cbChauffeur.DataSource = chauffeur.List("1=1");
                        cbChauffeur.SelectedIndex = cbChauffeur.Items.Count - 1;
                        cbChauffeur.Focus();
                        cbTransporteur.Focus();
                    }
                    catch
                    {
                        throw;
                    }

                }
            }
        }

        private void btAddTransporteur_Click(object sender, EventArgs e)
        {
            if (cbTransporteur.Text != "" && cbTransporteur.Text.Trim().Length > 1)
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir ajouter le transporteur: " + cbTransporteur.Text + "?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure you want to add the carrier: " + cbTransporteur.Text + "?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Transporteur transporteur = new Transporteur();
                        transporteur.Add("", cbTransporteur.Text, "", "", "", "", "", "", "", "", "", 1, 0, "", 0, "");
                        cbTransporteur.DataSource = transporteur.List("1=1");
                        cbTransporteur.SelectedIndex = cbTransporteur.Items.Count - 1;
                        cbTransporteur.Focus();
                        cbProduit.Focus();
                    }
                    catch
                    {
                        throw;
                    }

                }
            }
        }

        private void btAddProduit_Click(object sender, EventArgs e)
        {
            if (cbProduit.Text != "" && cbProduit.Text.Trim().Length > 1)
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir ajouter le produit: " + cbProduit.Text + "?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure you want to add the product: " + cbProduit.Text + "?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Produit produit = new Produit();
                        produit.Add(cbProduit.Text, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0);
                        cbProduit.DataSource = produit.List("1=1");
                        cbProduit.SelectedIndex = cbProduit.Items.Count - 1;
                        cbProduit.Focus();
                        cbClient.Focus();
                    }
                    catch
                    {
                        throw;
                    }

                }
            }
        }

        private void btAddClient_Click(object sender, EventArgs e)
        {
            if (cbClient.Text != "" && cbClient.Text.Trim().Length > 1)
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir ajouter le client: " + cbClient.Text + "?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure you want to add the customer: " + cbClient.Text + "?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Client client = new Client();
                        client.Add("", cbClient.Text, 0, "", "", "", "", "", "", "", "", "", 1, 0, "", 0, "");
                        cbClient.DataSource = client.List("1=1");
                        cbClient.SelectedIndex = cbClient.Items.Count - 1;
                        cbClient.Focus();
                        gbTypePesee.Focus();
                    }
                    catch
                    {
                        throw;
                    }

                }
            }
        }

        private void cbChamp1_Leave(object sender, EventArgs e)
        {
            if (cbChamp1.Text.Trim() != "")
            {
                Enregistrements enregistrements = new Enregistrements();
                if (enregistrements.IfExists(cbChamp1.Text, Table1Id, 0))
                {
                    cbChamp1.BackColor = Color.FromArgb(58, 62, 60);
                    cbChamp1.ForeColor = Color.White;
                    btAddChamp1.Visible = false;
                }
                else
                {
                    cbChamp1.BackColor = Color.Honeydew;
                    cbChamp1.ForeColor = Color.Black;
                    if (Table1_Ajout != 0)
                        btAddChamp1.Visible = true;
                }
            }
            else
            {
                cbChamp1.BackColor = Color.Honeydew;
                cbChamp1.ForeColor = Color.Black;
                if (Filter2.Visible)
                    Filter2.Visible = false;
            }
        }

        private void cbChamp1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (init_WeighingSettings && Table1Id != 0 && cbChamp1.Text.Trim() != "")
            {
                Tables tables = new Tables();
                Enregistrements enregistrements = new Enregistrements();
                if (Table2Id != 0 && tables.IsTableRelated(Table2Id))
                {
                    if (tables.GetParentTableId(Table2Id) == Table1Id)
                    {
                        cbChamp2.DataSource = enregistrements.FindByTableIdAndParentId(Table2Id, Common_functions.CbSelectedValue_Convert_Int(cbChamp1));
                        cbChamp2.DisplayMember = "NOM";
                        cbChamp2.ValueMember = "ENREGISTREMENTSID";
                        cbChamp2.Text = "";
                        cbChamp2.SelectedIndex = -1;
                        cbChamp2.BackColor = Color.Honeydew;
                        cbChamp2.ForeColor = Color.Black;
                        btAddChamp2.Visible = false;
                        Filter2.Visible = true;
                    }
                }
            }
            else
                Filter2.Visible = false;
        }

        private void cbChamp2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (init_WeighingSettings && Table2Id != 0 && cbChamp2.Text.Trim() != "")
            {
                Tables tables = new Tables();
                Enregistrements enregistrements = new Enregistrements();
                if (Table3Id != 0 && tables.IsTableRelated(Table3Id))
                {
                    if (tables.GetParentTableId(Table3Id) == Table2Id)
                    {
                        cbChamp3.DataSource = enregistrements.FindByTableIdAndParentId(Table3Id, Common_functions.CbSelectedValue_Convert_Int(cbChamp2));
                        cbChamp3.DisplayMember = "NOM";
                        cbChamp3.ValueMember = "ENREGISTREMENTSID";
                        cbChamp3.Text = "";
                        cbChamp3.SelectedIndex = -1;
                        cbChamp3.BackColor = Color.Honeydew;
                        cbChamp3.ForeColor = Color.Black;
                        btAddChamp3.Visible = false;
                        Filter3.Visible = true;
                    }
                }
            }
            else
                Filter3.Visible = false;
        }

        private void cbChamp2_Leave(object sender, EventArgs e)
        {
            if (cbChamp2.Text.Trim() != "")
            {
                Tables tables = new Tables();
                Enregistrements enregistrements = new Enregistrements();
                if (tables.IsTableRelated(Table2Id))
                {
                    if (enregistrements.IfExists(cbChamp2.Text, Table2Id, Common_functions.CbSelectedValue_Convert_Int(cbChamp1)))
                    {
                        cbChamp2.BackColor = Color.FromArgb(58, 62, 60);
                        cbChamp2.ForeColor = Color.White;
                        btAddChamp2.Visible = false;
                    }
                    else
                    {
                        cbChamp2.BackColor = Color.Honeydew;
                        cbChamp2.ForeColor = Color.Black;
                        if (Table2_Ajout != 0)
                            btAddChamp2.Visible = true;
                    }
                }
                else
                {
                    if (enregistrements.IfExists(cbChamp2.Text, Table2Id, 0))
                    {
                        cbChamp2.BackColor = Color.FromArgb(58, 62, 60);
                        cbChamp2.ForeColor = Color.White;
                        btAddChamp2.Visible = false;
                    }
                    else
                    {
                        cbChamp2.BackColor = Color.Honeydew;
                        cbChamp2.ForeColor = Color.Black;
                        if (Table2_Ajout != 0)
                            btAddChamp2.Visible = true;
                    }
                }

            }
            else
            {
                cbChamp2.BackColor = Color.Honeydew;
                cbChamp2.ForeColor = Color.Black;
                if (Filter3.Visible)
                    Filter3.Visible = false;
            }
        }

        private void cbChamp3_SelectedValueChanged(object sender, EventArgs e)
        {
            if (init_WeighingSettings && Table3Id != 0 && cbChamp3.Text.Trim() != "")
            {
                Tables tables = new Tables();
                Enregistrements enregistrements = new Enregistrements();
                if (Table4Id != 0 && tables.IsTableRelated(Table4Id))
                {
                    if (tables.GetParentTableId(Table4Id) == Table3Id)
                    {
                        cbChamp4.DataSource = enregistrements.FindByTableIdAndParentId(Table4Id, Common_functions.CbSelectedValue_Convert_Int(cbChamp3));
                        cbChamp4.DisplayMember = "NOM";
                        cbChamp4.ValueMember = "ENREGISTREMENTSID";
                        cbChamp4.Text = "";
                        cbChamp4.SelectedIndex = -1;
                        cbChamp4.BackColor = Color.Honeydew;
                        cbChamp4.ForeColor = Color.Black;
                        btAddChamp4.Visible = false;
                        Filter4.Visible = true;
                    }
                }
            }
            else
                Filter4.Visible = false;
        }

        private void cbChamp3_Leave(object sender, EventArgs e)
        {
            if (cbChamp3.Text.Trim() != "")
            {
                Tables tables = new Tables();
                Enregistrements enregistrements = new Enregistrements();
                if (tables.IsTableRelated(Table3Id))
                {
                    if (enregistrements.IfExists(cbChamp3.Text, Table3Id, Common_functions.CbSelectedValue_Convert_Int(cbChamp2)))
                    {
                        cbChamp3.BackColor = Color.FromArgb(58, 62, 60);
                        cbChamp3.ForeColor = Color.White;
                        btAddChamp3.Visible = false;
                    }
                    else
                    {
                        cbChamp3.BackColor = Color.Honeydew;
                        cbChamp3.ForeColor = Color.Black;
                        if (Table3_Ajout != 0)
                            btAddChamp3.Visible = true;
                    }

                }
                else
                {
                    if (enregistrements.IfExists(cbChamp3.Text, Table3Id, 0))
                    {
                        cbChamp3.BackColor = Color.FromArgb(58, 62, 60);
                        cbChamp3.ForeColor = Color.White;
                        btAddChamp3.Visible = false;
                    }
                    else
                    {
                        cbChamp3.BackColor = Color.Honeydew;
                        cbChamp3.ForeColor = Color.Black;
                        if (Table3_Ajout != 0)
                            btAddChamp3.Visible = true;
                    }
                }
            }
            else
            {
                cbChamp3.BackColor = Color.Honeydew;
                cbChamp3.ForeColor = Color.Black;
                if (Filter4.Visible)
                    Filter4.Visible = false;
            }
        }

        private void cbChamp4_SelectedValueChanged(object sender, EventArgs e)
        {
            if (init_WeighingSettings && Table4Id != 0 && cbChamp4.Text.Trim() != "")
            {
                Tables tables = new Tables();
                Enregistrements enregistrements = new Enregistrements();
                if (Table5Id != 0 && tables.IsTableRelated(Table5Id))
                {
                    if (tables.GetParentTableId(Table5Id) == Table4Id)
                    {
                        cbChamp5.DataSource = enregistrements.FindByTableIdAndParentId(Table5Id, Common_functions.CbSelectedValue_Convert_Int(cbChamp4));
                        cbChamp5.DisplayMember = "NOM";
                        cbChamp5.ValueMember = "ENREGISTREMENTSID";
                        cbChamp5.Text = "";
                        cbChamp5.SelectedIndex = -1;
                        cbChamp5.BackColor = Color.Honeydew;
                        cbChamp5.ForeColor = Color.Black;
                        btAddChamp5.Visible = false;
                        Filter5.Visible = true;
                    }
                }
            }
            else
                Filter5.Visible = false;
        }

        private void cbChamp4_Leave(object sender, EventArgs e)
        {
            if (cbChamp4.Text.Trim() != "")
            {
                Tables tables = new Tables();
                Enregistrements enregistrements = new Enregistrements();
                if (tables.IsTableRelated(Table4Id))
                {
                    if (enregistrements.IfExists(cbChamp4.Text, Table4Id, Common_functions.CbSelectedValue_Convert_Int(cbChamp3)))
                    {
                        cbChamp4.BackColor = Color.FromArgb(58, 62, 60);
                        cbChamp4.ForeColor = Color.White;
                        btAddChamp4.Visible = false;
                    }
                    else
                    {
                        cbChamp4.BackColor = Color.Honeydew;
                        cbChamp4.ForeColor = Color.Black;
                        if (Table4_Ajout != 0)
                            btAddChamp4.Visible = true;
                    }
                }
                else
                {
                    if (enregistrements.IfExists(cbChamp4.Text, Table4Id, 0))
                    {
                        cbChamp4.BackColor = Color.FromArgb(58, 62, 60);
                        cbChamp4.ForeColor = Color.White;
                        btAddChamp4.Visible = false;
                    }
                    else
                    {
                        cbChamp4.BackColor = Color.Honeydew;
                        cbChamp4.ForeColor = Color.Black;
                        if (Table4_Ajout != 0)
                            btAddChamp4.Visible = true;
                    }
                }
            }
            else
            {
                cbChamp4.BackColor = Color.Honeydew;
                cbChamp4.ForeColor = Color.Black;
                if (Filter5.Visible)
                    Filter5.Visible = false;
            }
        }

        private void cbChamp5_SelectedValueChanged(object sender, EventArgs e)
        {
            if (init_WeighingSettings && Table5Id != 0 && cbChamp5.Text.Trim() != "")
            {
                Tables tables = new Tables();
                Enregistrements enregistrements = new Enregistrements();
                if (Table6Id != 0 && tables.IsTableRelated(Table6Id))
                {
                    if (tables.GetParentTableId(Table6Id) == Table5Id)
                    {
                        cbChamp6.DataSource = enregistrements.FindByTableIdAndParentId(Table6Id, Common_functions.CbSelectedValue_Convert_Int(cbChamp5));
                        cbChamp6.DisplayMember = "NOM";
                        cbChamp6.ValueMember = "ENREGISTREMENTSID";
                        cbChamp6.Text = "";
                        cbChamp6.SelectedIndex = -1;
                        cbChamp6.BackColor = Color.Honeydew;
                        cbChamp6.ForeColor = Color.Black;
                        btAddChamp6.Visible = false;
                        Filter6.Visible = true;
                    }
                }
            }
            else
                Filter6.Visible = false;
        }

        private void cbChamp5_Leave(object sender, EventArgs e)
        {
            if (cbChamp5.Text.Trim() != "")
            {
                Tables tables = new Tables();
                Enregistrements enregistrements = new Enregistrements();
                if (tables.IsTableRelated(Table5Id))
                {
                    if (enregistrements.IfExists(cbChamp5.Text, Table5Id, Common_functions.CbSelectedValue_Convert_Int(cbChamp4)))
                    {
                        cbChamp5.BackColor = Color.FromArgb(58, 62, 60);
                        cbChamp5.ForeColor = Color.White;
                        btAddChamp5.Visible = false;
                    }
                    else
                    {
                        cbChamp5.BackColor = Color.Honeydew;
                        cbChamp5.ForeColor = Color.Black;
                        if (Table5_Ajout != 0)
                            btAddChamp5.Visible = true;
                    }
                }
                else
                {
                    if (enregistrements.IfExists(cbChamp5.Text, Table5Id, 0))
                    {
                        cbChamp5.BackColor = Color.FromArgb(58, 62, 60);
                        cbChamp5.ForeColor = Color.White;
                        btAddChamp5.Visible = false;
                    }
                    else
                    {
                        cbChamp5.BackColor = Color.Honeydew;
                        cbChamp5.ForeColor = Color.Black;
                        if (Table5_Ajout != 0)
                            btAddChamp5.Visible = true;
                    }
                }
            }
            else
            {
                cbChamp5.BackColor = Color.Honeydew;
                cbChamp5.ForeColor = Color.Black;
                if (Filter6.Visible)
                    Filter6.Visible = false;
            }
        }

        private void cbChamp6_SelectedValueChanged(object sender, EventArgs e)
        {
            if (init_WeighingSettings && Table6Id != 0 && cbChamp6.Text.Trim() != "")
            {
                Tables tables = new Tables();
                Enregistrements enregistrements = new Enregistrements();
                if (Table7Id != 0 && tables.IsTableRelated(Table7Id))
                {
                    if (tables.GetParentTableId(Table7Id) == Table6Id)
                    {
                        cbChamp7.DataSource = enregistrements.FindByTableIdAndParentId(Table7Id, Common_functions.CbSelectedValue_Convert_Int(cbChamp6));
                        cbChamp7.DisplayMember = "NOM";
                        cbChamp7.ValueMember = "ENREGISTREMENTSID";
                        cbChamp7.Text = "";
                        cbChamp7.SelectedIndex = -1;
                        cbChamp7.BackColor = Color.Honeydew;
                        cbChamp7.ForeColor = Color.Black;
                        btAddChamp7.Visible = false;
                        Filter7.Visible = true;
                    }
                }
            }
            else
                Filter7.Visible = false;
        }

        private void cbChamp6_Leave(object sender, EventArgs e)
        {
            if (cbChamp6.Text.Trim() != "")
            {
                Tables tables = new Tables();
                Enregistrements enregistrements = new Enregistrements();
                if (tables.IsTableRelated(Table6Id))
                {
                    if (enregistrements.IfExists(cbChamp6.Text, Table6Id, Common_functions.CbSelectedValue_Convert_Int(cbChamp5)))
                    {
                        cbChamp6.BackColor = Color.FromArgb(58, 62, 60);
                        cbChamp6.ForeColor = Color.White;
                        btAddChamp6.Visible = false;
                    }
                    else
                    {
                        cbChamp6.BackColor = Color.Honeydew;
                        cbChamp6.ForeColor = Color.Black;
                        if (Table6_Ajout != 0)
                            btAddChamp6.Visible = true;
                    }
                }
                else
                {
                    if (enregistrements.IfExists(cbChamp6.Text, Table6Id, 0))
                    {
                        cbChamp6.BackColor = Color.FromArgb(58, 62, 60);
                        cbChamp6.ForeColor = Color.White;
                        btAddChamp6.Visible = false;
                    }
                    else
                    {
                        cbChamp6.BackColor = Color.Honeydew;
                        cbChamp6.ForeColor = Color.Black;
                        if (Table6_Ajout != 0)
                            btAddChamp6.Visible = true;
                    }
                }
            }
            else
            {
                cbChamp6.BackColor = Color.Honeydew;
                cbChamp6.ForeColor = Color.Black;
                if (Filter7.Visible)
                    Filter7.Visible = false;
            }
        }

        private void cbChamp7_Leave(object sender, EventArgs e)
        {
            if (cbChamp7.Text.Trim() != "")
            {
                Tables tables = new Tables();
                Enregistrements enregistrements = new Enregistrements();
                if (tables.IsTableRelated(Table7Id))
                {
                    if (enregistrements.IfExists(cbChamp7.Text, Table7Id, Common_functions.CbSelectedValue_Convert_Int(cbChamp6)))
                    {
                        cbChamp7.BackColor = Color.FromArgb(58, 62, 60);
                        cbChamp7.ForeColor = Color.White;
                        btAddChamp7.Visible = false;
                    }
                    else
                    {
                        cbChamp7.BackColor = Color.Honeydew;
                        cbChamp7.ForeColor = Color.Black;
                        if (Table7_Ajout != 0)
                            btAddChamp7.Visible = true;
                    }
                }
                else
                {
                    if (enregistrements.IfExists(cbChamp7.Text, Table7Id, 0))
                    {
                        cbChamp7.BackColor = Color.FromArgb(58, 62, 60);
                        cbChamp7.ForeColor = Color.White;
                        btAddChamp7.Visible = false;
                    }
                    else
                    {
                        cbChamp7.BackColor = Color.Honeydew;
                        cbChamp7.ForeColor = Color.Black;
                        if (Table7_Ajout != 0)
                            btAddChamp7.Visible = true;
                    }
                }
            }
            else
            {
                cbChamp7.BackColor = Color.Honeydew;
                cbChamp7.ForeColor = Color.Black;
            }
        }

        private void cbWeighingSettingsId_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(PeseePBDetail));

            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                //Language_Manager language_Manager = new Language_Manager();
                //language_Manager.ChangeLanguage("en", this, typeof(TransporteurDetail));

            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                //Language_Manager language_Manager = new Language_Manager();
                //language_Manager.ChangeLanguage("es", this, typeof(TransporteurDetail));

            }
        }

        private void lbModifier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtEtatPesee.Text != "Pending")
                {
                    if (vg_Update == false && vg_IsEnabled == false)
                    {
                        Enable();
                        lbModifier.Text = Language_Manager.Localize("Valider", cbLang.Text);
                        vg_Update = true;
                    }
                    else
                    {
                        if (check_fields())
                        {
                            try
                            {

                                PeseePB peseePB = new PeseePB();
                                peseePB.Update_UI(vg_PeseePBId, Flux, Common_functions.CbSelectedValue_Convert_Int(cbFirme), Common_functions.CbSelectedValue_Convert_Int(cbCamion),
                                    Common_functions.CbSelectedValue_Convert_Int(cbChauffeur), Common_functions.CbSelectedValue_Convert_Int(cbTransporteur), Common_functions.CbSelectedValue_Convert_Int(cbProduit),
                                    Common_functions.CbSelectedValue_Convert_Int(cbClient), Common_functions.CbSelectedValue_Convert_Int(cbChamp1), Table1Id, Table1Name, cbChamp1.Text, Common_functions.CbSelectedValue_Convert_Int(cbChamp2), Table2Id, Table2Name, cbChamp2.Text,
                                    Common_functions.CbSelectedValue_Convert_Int(cbChamp3), Table3Id, Table3Name, cbChamp3.Text, Common_functions.CbSelectedValue_Convert_Int(cbChamp4), Table4Id, Table4Name, cbChamp4.Text, Common_functions.CbSelectedValue_Convert_Int(cbChamp5), Table5Id, Table5Name, cbChamp5.Text,
                                    Common_functions.CbSelectedValue_Convert_Int(cbChamp6), Table6Id, Table6Name, cbChamp6.Text, Common_functions.CbSelectedValue_Convert_Int(cbChamp7), Table7Id, Table7Name, cbChamp7.Text
                                    , ChampLibre1Name, txtChampLibre1.Text, ChampLibre2Name, txtChampLibre2.Text, ChampLibre3Name, txtChampLibre3.Text, ChampLibre4Name, txtChampLibre4.Text, Common_functions.CbSelectedValue_Convert_Int(cbWalterre));

                                if (cbLang.Text == "FR")
                                    Custom_MessageBox.Show("FR", "Enregisté", "Pesée: " + txtId.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else if (cbLang.Text == "EN")
                                    Custom_MessageBox.Show("EN", "Done", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Disable();
                                Close();
                            }
                            catch
                            {
                                throw;
                            }
                        }
                        else
                        {
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Informations incomplètes", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Incomplete informations", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Vous ne pouvez pas modifier une pesée en cours", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "You can't update a pending weighing", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                throw;
            }
        }

        private bool check_fields()
        {
            bool vl_Camion;
            bool vl_Chauffeur;
            bool vl_Transporteur;
            bool vl_Produit;
            bool vl_Firme;
            bool vl_Client;
            bool vl_Champ1;
            bool vl_Champ2;
            bool vl_Champ3;
            bool vl_Champ4;
            bool vl_Champ5;
            bool vl_Champ6;
            bool vl_Champ7;
            bool vl_ChampLibre1;
            bool vl_ChampLibre2;
            bool vl_ChampLibre3;
            bool vl_ChampLibre4;

            if (EnableCamion != 0 && Camion_Obl != 0)
            {
                if (cbCamion.Text != "" && cbCamion.SelectedIndex != -1)
                    vl_Camion = true;
                else
                    vl_Camion = false;
            }
            else
                vl_Camion = true;
            if (EnableChauffeur != 0 && Chauffeur_Obl != 0)
            {
                if (cbChauffeur.Text != "" && cbChauffeur.SelectedIndex != -1)
                    vl_Chauffeur = true;
                else
                    vl_Chauffeur = false;
            }
            else
                vl_Chauffeur = true;
            if (EnableTransporteur != 0 && Transporteur_Obl != 0)
            {
                if (cbTransporteur.Text != "" && cbTransporteur.SelectedIndex != -1)
                    vl_Transporteur = true;
                else
                    vl_Transporteur = false;
            }
            else
                vl_Transporteur = true;
            if (EnableProduit != 0 && Produit_Obl != 0)
            {
                if (cbProduit.Text != "" && cbProduit.SelectedIndex != -1)
                    vl_Produit = true;
                else
                    vl_Produit = false;
            }
            else
                vl_Produit = true;
            if (EnableFirme != 0 && Firme_Obl != 0)
            {
                if (cbFirme.Text != "" && cbFirme.SelectedIndex != -1)
                    vl_Firme = true;
                else
                    vl_Firme = false;
            }
            else
                vl_Firme = true;
            if (EnableClient != 0 && Client_Obl != 0)
            {
                if (cbClient.Text != "" && cbClient.SelectedIndex != -1)
                    vl_Client = true;
                else
                    vl_Client = false;
            }
            else
                vl_Client = true;
            if (Table1Id != 0 && Table1_Obl != 0)
            {
                if (cbChamp1.Text != "" && cbChamp1.SelectedIndex != -1)
                    vl_Champ1 = true;
                else
                    vl_Champ1 = false;
            }
            else
                vl_Champ1 = true;
            if (Table2Id != 0 && Table2_Obl != 0)
            {
                if (cbChamp2.Text != "" && cbChamp2.SelectedIndex != -1)
                    vl_Champ2 = true;
                else
                    vl_Champ2 = false;
            }
            else
                vl_Champ2 = true;
            if (Table3Id != 0 && Table3_Obl != 0)
            {
                if (cbChamp3.Text != "" && cbChamp3.SelectedIndex != -1)
                    vl_Champ3 = true;
                else
                    vl_Champ3 = false;
            }
            else
                vl_Champ3 = true;
            if (Table4Id != 0 && Table4_Obl != 0)
            {
                if (cbChamp4.Text != "" && cbChamp4.SelectedIndex != -1)
                    vl_Champ4 = true;
                else
                    vl_Champ4 = false;
            }
            else
                vl_Champ4 = true;
            if (Table5Id != 0 && Table5_Obl != 0)
            {
                if (cbChamp5.Text != "" && cbChamp5.SelectedIndex != -1)
                    vl_Champ5 = true;
                else
                    vl_Champ5 = false;
            }
            else
                vl_Champ5 = true;
            if (Table6Id != 0 && Table6_Obl != 0)
            {
                if (cbChamp6.Text != "" && cbChamp6.SelectedIndex != -1)
                    vl_Champ6 = true;
                else
                    vl_Champ6 = false;
            }
            else
                vl_Champ6 = true;
            if (Table7Id != 0 && Table7_Obl != 0)
            {
                if (cbChamp7.Text != "" && cbChamp7.SelectedIndex != -1)
                    vl_Champ7 = true;
                else
                    vl_Champ7 = false;
            }
            else
                vl_Champ7 = true;
            if (ChampLibre1Name.Trim().Length > 2 && ChampLibre1_Obl != 0)
            {
                if (txtChampLibre1.Text.Trim() != "")
                    vl_ChampLibre1 = true;
                else
                    vl_ChampLibre1 = false;
            }
            else
                vl_ChampLibre1 = true;
            if (ChampLibre2Name.Trim().Length > 2 && ChampLibre2_Obl != 0)
            {
                if (txtChampLibre2.Text.Trim() != "")
                    vl_ChampLibre2 = true;
                else
                    vl_ChampLibre2 = false;
            }
            else
                vl_ChampLibre2 = true;
            if (ChampLibre3Name.Trim().Length > 2 && ChampLibre3_Obl != 0)
            {
                if (txtChampLibre3.Text.Trim() != "")
                    vl_ChampLibre3 = true;
                else
                    vl_ChampLibre3 = false;
            }
            else
                vl_ChampLibre3 = true;
            if (ChampLibre4Name.Trim().Length > 2 && ChampLibre4_Obl != 0)
            {
                if (txtChampLibre4.Text.Trim() != "")
                    vl_ChampLibre4 = true;
                else
                    vl_ChampLibre4 = false;
            }
            else
                vl_ChampLibre4 = true;


            if (vl_Camion && vl_Chauffeur && vl_Transporteur && vl_Produit && vl_Firme && vl_Client
                && vl_Champ1 && vl_Champ2 && vl_Champ3 && vl_Champ4 && vl_Champ5 && vl_Champ6 && vl_Champ7
                && vl_ChampLibre1 && vl_ChampLibre2 && vl_ChampLibre3 && vl_ChampLibre4)
            {
                return true;
            }
            else
                return false;
        }

        private void PeseePBDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pbUpdating.Visible)
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas fermer la fenetre tant que la modification n'est pas validée", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You can't close this window before the update is completed", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                    Custom_MessageBox.Show("ES", "No puede cerrar la página hasta que se valide el cambio", "Firma", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Cancel = true;
            }
        }

        private void lbSupprimer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (vg_Update)
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas supprimer l'enregistrement tant que la modification n'est pas validée", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You can't delete this record before the update is completed", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                    Custom_MessageBox.Show("ES", "No puede eliminar el registro hasta que se confirme el cambio", "Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                try
                {
                    DialogResult result;
                    if (cbLang.Text == "FR")
                        result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir supprimer cet enregistrement?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    else if (cbLang.Text == "EN")
                        result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    else
                        result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        PeseePB pesee = new PeseePB();
                        pesee.Delete(vg_PeseePBId);
                        if (cbLang.Text == "FR")
                            Custom_MessageBox.Show("FR", "Pesée supprimée avec succès", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (cbLang.Text == "EN")
                            Custom_MessageBox.Show("EN", "Weighing deleted successfully", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            Custom_MessageBox.Show("ES", "Pesaje eliminado", "Firma", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }

                }
                catch
                {
                    throw;
                }

            }
        }

        private void lbAjouter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (vg_Update)
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas imprimer la pesée tant que la modification n'est pas validée", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You can't print this weighing before the update is completed", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                    Custom_MessageBox.Show("ES", "No puede eliminar el registro hasta que se confirme el cambio", "Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                Form form = new PeseePBTicketA5(vg_PeseePBId);
                form.Show();
            }
        }

        private void cbWalterre_Leave(object sender, EventArgs e)
        {
            if (cbWalterre.Text != "")
            {
                Walterre walterre = new Walterre();
                if (walterre.IfExists(cbWalterre.Text))
                {
                    cbWalterre.BackColor = Color.FromArgb(58, 62, 60);
                    cbWalterre.ForeColor = Color.White;
                }
                else
                {
                    cbWalterre.BackColor = Color.Honeydew;
                    cbWalterre.ForeColor = Color.Black;
                }
            }
            else
            {
                cbWalterre.BackColor = Color.Honeydew;
                cbWalterre.ForeColor = Color.Black;
            }
        }
    }
    
}
