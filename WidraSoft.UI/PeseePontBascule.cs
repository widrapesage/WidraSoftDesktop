using CustomMessageBox;
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
using TunnelIntegration;
using WidraSoft.BL;
using WidraSoft.DA;

namespace WidraSoft.UI
{
    public partial class PeseePontBascule : Form
    {
        // COM & Weight Settings Informations
        SerialPort com = new SerialPort();
        int TimerInterval;
        int LongueurMinChaine;
        int PositionDebut;
        int LongueurChaine;
        int Poids_Detection;
        int ActiverPoids;
        string CaractereSeparation;
        string ModeLecture;
        int Stabilite;
        int PositionStabilite;
        string ValeurStable;
        int Negatif;
        int PositionNegatif;
        string ValeurNegatif;
        Boolean Stable;
        Boolean vg_IsEnabled = true;
        Int32 vg_Id = 0;
        Boolean vg_Clearing = false;
        bool init_WeighingSettings = false;
        int vg_UtilisateurId;

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

        public PeseePontBascule(Int32 UtilisateurId)
        {
            InitializeComponent();
            menuStrip.Renderer = menuStrip1.Renderer = new MyRenderer();
            vg_UtilisateurId = UtilisateurId;
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyMenuColors()) { }
        }

        private void PeseePontBascule_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            //Pont 
            Pont pont = new Pont();
            DataTable dtPont = pont.FindByMachineName(System.Environment.MachineName);
            cbPont.DataSource = dtPont;
            cbPont.DisplayMember = "DESIGNATION";
            cbPont.ValueMember = "PONTID";

            //WeighingSettings
            WeighingSettings weighingSettings = new WeighingSettings();
            cbWeighingSettingsId.DataSource = weighingSettings.List("1=1");
            cbWeighingSettingsId.DisplayMember = "DESIGNATION";
            cbWeighingSettingsId.ValueMember = "WEIGHING_SETTINGSID";

            Int32 pontId = 0;

            if (dtPont.Rows.Count < 1)
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Aucun pont paramétré pour cette machine, impossible d'effectuer une pesée.", "Pesée: " + txtId.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "Weighing over", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            else
            {
                if (dtPont.Rows.Count == 1)
                {
                    foreach (DataRow row in dtPont.Rows)
                    {
                        try
                        {
                            pontId = (int)row["PONTID"];
                            cbPont.SelectedItem = cbPont.Items[0];
                            cbPont.Enabled = false;
                        }
                        catch { throw; }

                    }
                }
                else
                {
                    cbPont.Enabled = true;
                }
            }

            btSimulateur.Enabled = false;

            Initialize_WeighBridgeSettings(pontId);

            Initialize_Data();

            init_WeighingSettings = true;

            Utilisateur utilisateur = new Utilisateur();
            lblusername.Text = utilisateur.GetFullUsername(vg_UtilisateurId);

            //Lang
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = MenuGeneral.languuage_index;

        }

        private void Initialize_WeighBridgeSettings(Int32 PontId)
        {
            Pont pont = new Pont();
            lbCOM.Text = "COM" + pont.GetCOM(PontId);
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
                Poids_Detection = (int)row["POIDS_DETECTION"];
                ActiverPoids = (int)row["ACTIVERPOIDS"];
                try
                {
                    if (ActiverPoids == 1)
                    {
                        com.Open();
                    }
                    else
                    {
                        btSimulateur.Enabled = true;
                    }
                }
                catch { throw; }

            }

            Initialize_WeightSettings(PontId);
            InitializeWeighingSettings(PontId);
        }

        private void Initialize_WeightSettings(Int32 PontId)
        {
            Pont pont = new Pont();
            WeightSettings weightSettings = new WeightSettings();
            DataTable dtWeightSettings = new DataTable();
            dtWeightSettings = weightSettings.FindById(pont.GetWeightSettingsId(PontId));
            foreach (DataRow r in dtWeightSettings.Rows)
            {
                lbWeightSettings.Text = r["DESIGNATION"].ToString();
                TimerInterval = (int)r["TIMERINTERVAL"];
                Weight_Timer.Interval = TimerInterval;
                JaugeTimer.Interval = TimerInterval;
                if (ActiverPoids == 1)
                {
                    Weight_Timer.Start();
                }
                JaugeTimer.Start();
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

        private void InitializeWeighingSettings(Int32 PontId)
        {
            Pont pont = new Pont();
            WeighingSettings weighingSettings = new WeighingSettings();

            if (pont.IsMultipleParam(PontId))
            {
                if (weighingSettings.CountNbWeighingSettingsTotal() > 1)
                {
                    cbWeighingSettingsId.Enabled = true;
                    cbWeighingSettingsId.SelectedValue = pont.GetWeighingSettingsId(PontId);
                }
                else if (weighingSettings.CountNbWeighingSettingsTotal() == 1)
                {
                    cbWeighingSettingsId.Enabled = false;
                    cbWeighingSettingsId.SelectedItem = cbWeighingSettingsId.Items[0];
                }
                else
                {

                }
            }
            else
            {
                //cbWeighingSettingsId.DataSource = weighingSettings.FindById(pont.GetWeighingSettingsId(PontId));
                cbWeighingSettingsId.Enabled = false;
                cbWeighingSettingsId.SelectedValue = pont.GetWeighingSettingsId(PontId);
            }

        }

        private void Initialize_Data()
        {

            rb2x1.Checked = true;
            lbStatus.Text = "Pending";
            lbStatus.ForeColor = Color.OrangeRed;

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
            Clear();
            Bind_Dgv();
        }

        private void Bind_Dgv()
        {
            PeseePB peseePB = new PeseePB();
            DgvList.DataSource = peseePB.FindWeighingsInProgress();
            DgvList.Columns[0].Visible = true;
            DgvList.Columns[0].HeaderText = "NUMERO";
            DgvList.Columns["TYPEPESEE"].Visible = false;
            DgvList.Columns["FLUX"].Visible = false;
            DgvList.Columns["PONTID"].Visible = false;
            DgvList.Columns["WEIGHING_SETTINGSID"].Visible = false;
            DgvList.Columns["POIDS2"].Visible = false;
            DgvList.Columns["DATEHEUREPOIDS2"].Visible = true;
            DgvList.Columns["DATEHEUREPOIDS2"].HeaderText = "DATEHEURE";
            DgvList.Columns["PONT"].Visible = false;
            DgvList.Columns["FIRMEID"].Visible = false;
            DgvList.Columns["FIRME"].Visible = false;
            DgvList.Columns["CAMIONID"].Visible = false;
            DgvList.Columns["CAMION"].Visible = true;
            DgvList.Columns["CHAUFFEURID"].Visible = false;
            DgvList.Columns["CHAUFFEUR"].Visible = false;
            DgvList.Columns["TRANSPORTEURID"].Visible = false;
            DgvList.Columns["TRANSPORTEUR"].Visible = false;
            DgvList.Columns["PRODUITID"].Visible = false;
            DgvList.Columns["PRODUIT"].Visible = true;
            DgvList.Columns["CLIENTID"].Visible = false;
            DgvList.Columns["CLIENT"].Visible = false;
            DgvList.Columns["POIDS1"].Visible = false;
            DgvList.Columns["DATEHEUREPOIDS1"].Visible = false;
            DgvList.Columns["TABLES_SUPPLEMENTAIRES_STRING"].Visible = false;
            DgvList.Columns["PARAMPESEE"].Visible = true;
            DgvList.Columns["PARAMPESEE"].HeaderText = "PARAMETRE";
            DgvList.Columns["POIDSNET"].Visible = false;
            DgvList.Columns["USER_INFO"].Visible = false;
            DgvList.Columns["ETATPESEE"].Visible = false;
            DgvList.Columns["ETATPESEE"].HeaderText = "ETAT";
            DgvList.Columns["ENREGISTREMENTSID1"].Visible = false;
            DgvList.Columns["ENREGISTREMENTSID2"].Visible = false;
            DgvList.Columns["ENREGISTREMENTSID3"].Visible = false;
            DgvList.Columns["ENREGISTREMENTSID4"].Visible = false;
            DgvList.Columns["ENREGISTREMENTSID5"].Visible = false;
            DgvList.Columns["ENREGISTREMENTSID6"].Visible = false;
            DgvList.Columns["ENREGISTREMENTSID7"].Visible = false;
            DgvList.Columns["TITRE1"].Visible = false;
            DgvList.Columns["TITRE2"].Visible = false;
            DgvList.Columns["FOOTER"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = false;
            DgvList.Columns["PESEE_RESUME"].Visible = false;
            DgvList.Columns["CODEWALTERRE"].Visible = false;
            DgvList.Columns["WALTERREID"].Visible = false;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            DgvList.ReadOnly = true;

        }

        private void Refresh_Dgv()
        {

            PeseePB peseePB = new PeseePB();
            DgvList.DataSource = peseePB.FindWeighingsInProgress();
        }

        private void Add_Item_1x()
        {
            if (check_fields_min())
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "ATTENTION, les données non enregistrées seront perdues. Etes vous sur?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Camión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Clear();
                    Enable();
                    if (txtId.Text == "" && cbFirme.Text == "" && cbCamion.Text == "" && cbChauffeur.Text == "" && cbTransporteur.Text == "" && cbProduit.Text == "" && cbClient.Text == "")
                    {

                        rbxEntrant.Checked = true;
                        TypePesee = "1x";
                        txtTareCamion.Visible = true;
                        lbTareCamion.Visible = true;
                        txtTareCamion.Text = "";
                        ApplyWeighingSettings(Common_functions.CbSelectedValue_Convert_Int(cbWeighingSettingsId), true);
                    }
                }
                else
                {
                    vg_Clearing = true;
                    rb2x1.Checked = true;
                }
            }
            else
            {
                Clear();
                Enable();
                if (txtId.Text == "" && cbFirme.Text == "" && cbCamion.Text == "" && cbChauffeur.Text == "" && cbTransporteur.Text == "" && cbProduit.Text == "" && cbClient.Text == "")
                {

                    rbxEntrant.Checked = true;
                    TypePesee = "1x";
                    txtTareCamion.Visible = true;
                    lbTareCamion.Visible = true;
                    txtTareCamion.Text = "";
                    ApplyWeighingSettings(Common_functions.CbSelectedValue_Convert_Int(cbWeighingSettingsId), true);
                }
            }

        }

        private void Add_Item_2x1()
        {
            if (check_fields_min())
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "ATTENTION, les données non enregistrées seront perdues. Etes vous sur?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Camión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Clear();
                    Enable();
                    if (txtId.Text == "" && cbFirme.Text == "" && cbCamion.Text == "" && cbChauffeur.Text == "" && cbTransporteur.Text == "" && cbProduit.Text == "" && cbClient.Text == "")
                    {

                        rbxEntrant.Checked = true;
                        TypePesee = "2x1";
                        txtTareCamion.Visible = false;
                        lbTareCamion.Visible = false;
                        ApplyWeighingSettings(Common_functions.CbSelectedValue_Convert_Int(cbWeighingSettingsId), true);

                    }
                }
                else
                {
                    vg_Clearing = true;
                    rb1x.Checked = true;
                }
            }
            else
            {
                Clear();
                Enable();
                if (txtId.Text == "" && cbFirme.Text == "" && cbCamion.Text == "" && cbChauffeur.Text == "" && cbTransporteur.Text == "" && cbProduit.Text == "" && cbClient.Text == "")
                {

                    rbxEntrant.Checked = true;
                    TypePesee = "2x1";
                    txtTareCamion.Visible = false;
                    lbTareCamion.Visible = false;
                    ApplyWeighingSettings(Common_functions.CbSelectedValue_Convert_Int(cbWeighingSettingsId), true);
                }
            }

        }

        private void Edit_Item_2x2()
        {
            if (vg_Id > 0)
            {
                Clear();
                rb2x1.Checked = true;
                TypePesee = "2x2";
                Enable();
                txtTareCamion.Visible = false;
                lbTareCamion.Visible = false;
                Bind_Fields();
                ApplyWeighingSettings_2(Common_functions.CbSelectedValue_Convert_Int(cbWeighingSettingsId), false);
                Bind_Fields();
            }
        }

        private void Bind_Fields()
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            PeseePB peseePB = new PeseePB();
            dt = peseePB.FindById(vg_Id);
            dt2 = peseePB.FindWeighingsInProgressById(vg_Id);
            DgvList.DataSource = dt2;
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["PESEEPBID"];
                txtId.Text = Id.ToString();
                //TypePesee
                init_WeighingSettings = false;
                if (row["WEIGHING_SETTINGSID"] is System.DBNull)
                    cbWeighingSettingsId.SelectedValue = 0;
                else
                    cbWeighingSettingsId.SelectedValue = (int)row["WEIGHING_SETTINGSID"];
                init_WeighingSettings = true;
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
                txtChampLibre1.Text = row["CHAMPLIBRE1"].ToString();
                txtChampLibre2.Text = row["CHAMPLIBRE2"].ToString();
                txtChampLibre3.Text = row["CHAMPLIBRE3"].ToString();
                txtChampLibre4.Text = row["CHAMPLIBRE4"].ToString();


                lbPoidsBrut.Text = row["POIDS1"].ToString();
                lbDateHeurePoidsBrut.Text = row["DATEHEUREPOIDS1"].ToString();
                lbPoidsTare.Text = row["POIDS2"].ToString();
                lbDateHeurePoidsTare.Text = row["DATEHEUREPOIDS2"].ToString();
                lbPoidsNet.Text = row["POIDSNET"].ToString();
                lbStatus.Text = row["ETATPESEE"].ToString();
                if (row["ETATPESEE"].ToString() == "Pending")
                    lbStatus.ForeColor = Color.OrangeRed;
                else
                    lbStatus.ForeColor = Color.FromArgb(11, 228, 132);
            }
        }

        private void ApplyWeighingSettings(Int32 WeighingSettingsId, bool Clear_fields)
        {
            WeighingSettings weighingSettings = new WeighingSettings();
            Tables tables = new Tables();
            Enregistrements enregistrements = new Enregistrements();
            DataTable dtWeighingSettings = new DataTable();
            dtWeighingSettings = weighingSettings.FindById(WeighingSettingsId);
            foreach (DataRow ro in dtWeighingSettings.Rows)
            {
                lbWeighingSettings.Text = ro["DESIGNATION"].ToString();

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
                Table7Name = table_name;
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

            if (Clear_fields)
                Clear();
        }

        private void ApplyWeighingSettings_2(Int32 WeighingSettingsId, bool Clear_fields)
        {
            WeighingSettings weighingSettings = new WeighingSettings();
            Tables tables = new Tables();
            Enregistrements enregistrements = new Enregistrements();
            DataTable dtWeighingSettings = new DataTable();

            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            PeseePB peseePB = new PeseePB();
            dt = peseePB.FindById(vg_Id);
            dt2 = peseePB.FindWeighingsInProgressById(vg_Id);
            DgvList.DataSource = dt2;

            foreach (DataRow row in dt.Rows)
            {
                //if ((int)row["WEIGHING_SETTINGSID"] == 1)
                dtWeighingSettings = weighingSettings.FindById((int)row["WEIGHING_SETTINGSID"]);
            }

            foreach (DataRow ro in dtWeighingSettings.Rows)
            {
                lbWeighingSettings.Text = ro["DESIGNATION"].ToString();

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
                Table7Name = table_name;
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

            if (Clear_fields)
                Clear();



        }

        private bool check_fields_min()
        {
            bool vl_return;
            if (txtId.Text != "" || cbFirme.Text != "" || cbCamion.Text != "" || cbChauffeur.Text != "" || cbTransporteur.Text != "" || cbProduit.Text != "" || cbClient.Text != "" || cbWalterre.Text != "" || cbChamp1.Text != ""
                || cbChamp2.Text != "" || cbChamp3.Text != "" || cbChamp4.Text != "" || cbChamp5.Text != "" || cbChamp6.Text != "" || cbChamp7.Text != "" || txtChampLibre1.Text != "" || txtChampLibre2.Text != ""
                || txtChampLibre3.Text != "" || txtChampLibre4.Text != "")
                vl_return = true;
            else
                vl_return = false;
            return vl_return;
        }

        private bool check_fields()
        {
            bool vl_Camion;
            bool vl_Chauffeur;
            bool vl_Transporteur;
            bool vl_Produit;
            bool vl_Firme;
            bool vl_Client;
            bool vl_Walterre;
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
            if (EnableWalterre != 0)
            {
                if (cbWalterre.Text != "" && cbWalterre.SelectedIndex != -1)
                    vl_Walterre = true;
                else
                    vl_Walterre = false;
            }
            else
                vl_Walterre = true;
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
                && vl_Walterre && vl_Champ1 && vl_Champ2 && vl_Champ3 && vl_Champ4 && vl_Champ5 && vl_Champ6 && vl_Champ7
                && vl_ChampLibre1 && vl_ChampLibre2 && vl_ChampLibre3 && vl_ChampLibre4)
            {
                if (TypePesee == "1x")
                {
                    if (txtTareCamion.Text != "")
                        return true;
                    else
                        return false;
                }
                else
                    return true;
            }
            else
                return false;
        }



        private void Clear()
        {

            cbFirme.Text = "";
            cbFirme.SelectedIndex = -1;
            cbFirme.BackColor = Color.Honeydew;
            cbFirme.ForeColor = Color.Black;
            btAddFirme.Visible = false;
            cbCamion.Text = "";
            cbCamion.SelectedIndex = -1;
            cbCamion.BackColor = Color.Honeydew;
            cbCamion.ForeColor = Color.Black;
            btAddCamion.Visible = false;
            cbChauffeur.Text = "";
            cbChauffeur.SelectedIndex = -1;
            cbChauffeur.BackColor = Color.Honeydew;
            cbChauffeur.ForeColor = Color.Black;
            btAddChauffeur.Visible = false;
            cbTransporteur.Text = "";
            cbTransporteur.SelectedIndex = -1;
            cbTransporteur.BackColor = Color.Honeydew;
            cbTransporteur.ForeColor = Color.Black;
            btAddTransporteur.Visible = false;
            cbProduit.Text = "";
            cbProduit.SelectedIndex = -1;
            cbProduit.BackColor = Color.Honeydew;
            cbProduit.ForeColor = Color.Black;
            btAddProduit.Visible = false;
            cbClient.Text = "";
            cbClient.SelectedIndex = -1;
            cbClient.BackColor = Color.Honeydew;
            cbClient.ForeColor = Color.Black;
            btAddClient.Visible = false;
            cbWalterre.Text = "";
            cbWalterre.SelectedIndex = -1;
            cbWalterre.BackColor = Color.Honeydew;
            cbWalterre.ForeColor = Color.Black;
            cbChamp1.Text = "";
            cbChamp1.SelectedIndex = -1;
            cbChamp1.BackColor = Color.Honeydew;
            cbChamp1.ForeColor = Color.Black;
            btAddChamp1.Visible = false;
            cbChamp2.Text = "";
            cbChamp2.SelectedIndex = -1;
            cbChamp2.BackColor = Color.Honeydew;
            cbChamp2.ForeColor = Color.Black;
            btAddChamp2.Visible = false;
            cbChamp3.Text = "";
            cbChamp3.SelectedIndex = -1;
            cbChamp3.BackColor = Color.Honeydew;
            cbChamp3.ForeColor = Color.Black;
            btAddChamp3.Visible = false;
            cbChamp4.Text = "";
            cbChamp4.SelectedIndex = -1;
            cbChamp4.BackColor = Color.Honeydew;
            cbChamp4.ForeColor = Color.Black;
            btAddChamp4.Visible = false;
            cbChamp5.Text = "";
            cbChamp5.SelectedIndex = -1;
            cbChamp5.BackColor = Color.Honeydew;
            cbChamp5.ForeColor = Color.Black;
            btAddChamp5.Visible = false;
            cbChamp6.Text = "";
            cbChamp6.SelectedIndex = -1;
            cbChamp6.BackColor = Color.Honeydew;
            cbChamp6.ForeColor = Color.Black;
            btAddChamp6.Visible = false;
            cbChamp7.Text = "";
            cbChamp7.SelectedIndex = -1;
            cbChamp7.BackColor = Color.Honeydew;
            cbChamp7.ForeColor = Color.Black;
            btAddChamp7.Visible = false;

            txtChampLibre1.Text = "";
            txtChampLibre2.Text = "";
            txtChampLibre3.Text = "";
            txtChampLibre4.Text = "";

            if (txtTareCamion.Visible)
                txtTareCamion.Text = "";
            txtId.Text = "";
            lbPoidsBrut.Text = "";
            lbPoidsTare.Text = "";
            lbPoidsNet.Text = "";
            lbDateHeurePoidsBrut.Text = "";
            lbDateHeurePoidsTare.Text = "";

            Disable_Checked_rbxs_only();

            Filter2.Visible = false;
            Filter3.Visible = false;
            Filter4.Visible = false;
            Filter5.Visible = false;
            Filter6.Visible = false;
            Filter7.Visible = false;
        }

        private void Disable()
        {
            //gbTypePesee.Enabled = false;
            //gbFlux.Enabled = false;
            //cbPont.Enabled = false;
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
            btPeser.Enabled = false;
            if (txtTareCamion.Visible)
                txtTareCamion.Enabled = false;

            vg_IsEnabled = false;
        }

        private void Enable()
        {
            //gbTypePesee.Enabled = true;
            //gbFlux.Enabled = true;
            //cbPont.Enabled = true;
            cbFirme.Enabled = true;
            cbCamion.Enabled = true;
            cbChauffeur.Enabled = true;
            cbTransporteur.Enabled = true;
            cbProduit.Enabled = true;
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
            btPeser.Enabled = true;
            if (txtTareCamion.Visible)
                txtTareCamion.Enabled = true;

            vg_IsEnabled = true;
        }

        private void Enable_Checked_rbxs_only()
        {
            if (rb1x.Checked)
                rb2x1.Visible = false;
            if (rb2x1.Checked)
                rb1x.Visible = false;
            if (rbxEntrant.Checked)
                rbxSortant.Visible = false;
            if (rbxSortant.Checked)
                rbxEntrant.Visible = false;

        }

        private void Disable_Checked_rbxs_only()
        {
            rb1x.Visible = true;
            rb2x1.Visible = true;
            rbxEntrant.Visible = true;
            rbxSortant.Visible = true;
        }

        private void getMaxId()
        {
            PeseePB peseePB = new PeseePB();
            if (txtId.Text == "")
                txtId.Text = peseePB.GetMaxIdByPontId(Common_functions.CbSelectedValue_Convert_Int(cbPont)).ToString();
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
                    txtPoids.ForeColor = Color.FromArgb(112, 228, 132);
                    Stable = true;
                }
                else
                {
                    txtPoids.ForeColor = Color.Red;
                    Stable = false;
                }
            }
            else
            {
                returnstr = "0";
            }

            return returnstr;

        }

        public async void ReceiveSerialData()
        {
            string s;
            string result;
            byte[] trame = new byte[com.BytesToRead];
            com.Read(trame, 0, trame.Length);
            s = System.Text.Encoding.ASCII.GetString(trame);

            if (s.Length >= LongueurMinChaine)
            {
                result = filtredataBilancia(s);
                int Poids;
                bool IsParsablePoids;
                IsParsablePoids = Int32.TryParse(result, out Poids);
                if (IsParsablePoids)
                {
                    txtPoids.Text = Poids.ToString();
                    await TunnelCommunicationHelper.SendWeightMessageAsync(Poids, false);
                }
                else { txtPoids.Text = "0"; }
                //P = Poids;
            }

            else
                txtPoids.Text = "0";


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

        private void cbPont_SelectedValueChanged(object sender, EventArgs e)
        {


        }

        private void rb1x_CheckedChanged(object sender, EventArgs e)
        {
            if (rb1x.Checked)
            {
                if (vg_Clearing == false)
                    Add_Item_1x();
                else
                    vg_Clearing = false;
            }
        }

        private void rb2x1_CheckedChanged(object sender, EventArgs e)
        {
            if (rb2x1.Checked)
            {
                if (vg_Clearing == false)
                    Add_Item_2x1();
                else
                    vg_Clearing = false;
            }
        }

        private void cbPont_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btPeser_Click(object sender, EventArgs e)
        {
            if (TypePesee == "1x")
            {
                if (check_fields())
                {
                    DateTime DateHeurePoidsBrut;
                    DateTime DateHeurePoidsTare;
                    Int32 Poids;
                    Int32 PoidsNet;
                    bool IsParsablePoids;
                    IsParsablePoids = Int32.TryParse(txtPoids.Text, out Poids);
                    if (IsParsablePoids && Poids > 0)
                    {
                        lbPoidsBrut.Text = Poids.ToString();
                        DateHeurePoidsBrut = DateTime.Now;
                        lbDateHeurePoidsBrut.Text = DateHeurePoidsBrut.ToString();
                        Int32 Tare;
                        bool IsParsableTare;
                        IsParsableTare = Int32.TryParse(txtTareCamion.Text, out Tare);
                        if (IsParsableTare && Tare > 0 && Poids > Tare)
                        {
                            lbPoidsTare.Text = Tare.ToString();
                            DateHeurePoidsTare = DateTime.Now;
                            lbDateHeurePoidsTare.Text = DateHeurePoidsTare.ToString();

                            PoidsNet = Poids - Tare;
                            lbPoidsNet.Text = PoidsNet.ToString();
                            lbStatus.Text = "Complete";
                            try
                            {
                                PeseePB peseePB = new PeseePB();
                                peseePB.Add("1x", Flux, Common_functions.CbSelectedValue_Convert_Int(cbPont), Common_functions.CbSelectedValue_Convert_Int(cbWeighingSettingsId), Common_functions.CbSelectedValue_Convert_Int(cbFirme), Common_functions.CbSelectedValue_Convert_Int(cbCamion),
                                    Common_functions.CbSelectedValue_Convert_Int(cbChauffeur), Common_functions.CbSelectedValue_Convert_Int(cbTransporteur), Common_functions.CbSelectedValue_Convert_Int(cbProduit),
                                    Common_functions.CbSelectedValue_Convert_Int(cbClient), Common_functions.CbSelectedValue_Convert_Int(cbChamp1), Table1Id, Table1Name, cbChamp1.Text, Common_functions.CbSelectedValue_Convert_Int(cbChamp2), Table2Id, Table2Name, cbChamp2.Text,
                                    Common_functions.CbSelectedValue_Convert_Int(cbChamp3), Table3Id, Table3Name, cbChamp3.Text, Common_functions.CbSelectedValue_Convert_Int(cbChamp4), Table4Id, Table4Name, cbChamp4.Text, Common_functions.CbSelectedValue_Convert_Int(cbChamp5), Table5Id, Table5Name, cbChamp5.Text,
                                    Common_functions.CbSelectedValue_Convert_Int(cbChamp6), Table6Id, Table6Name, cbChamp6.Text, Common_functions.CbSelectedValue_Convert_Int(cbChamp7), Table7Id, Table7Name, cbChamp7.Text
                                    , Poids, DateHeurePoidsBrut, Tare, DateHeurePoidsTare, PoidsNet, lblusername.Text, lbStatus.Text, ChampLibre1Name, txtChampLibre1.Text, ChampLibre2Name, txtChampLibre2.Text, ChampLibre3Name, txtChampLibre3.Text, ChampLibre4Name, txtChampLibre4.Text, Common_functions.CbSelectedValue_Convert_Int(cbWalterre));

                                getMaxId();
                                int Id;
                                bool IsParsableId;
                                IsParsableId = Int32.TryParse(txtId.Text, out Id);
                                //Details de la pesée et impression
                                if (cbLang.Text == "FR")
                                    Custom_MessageBox.Show("FR", "Pesage Terminé, impression du ticket ...", "Pesée: " + txtId.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else if (cbLang.Text == "EN")
                                    Custom_MessageBox.Show("EN", "Weighing over", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (IsParsableId)
                                {
                                    Form form = new PeseePBTicketA5(Id);
                                    form.Show();
                                }

                                Clear();
                                InitializeWeighingSettings(Common_functions.CbSelectedValue_Convert_Int(cbPont));
                                Initialize_Data();
                            }
                            catch
                            {
                                throw;
                            }

                        }
                        else
                        {
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Le poids tare doit etre supérieur à 0 et inférieur au poids brut", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Tare weight must be greater than 0", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        if (cbLang.Text == "FR")
                            Custom_MessageBox.Show("FR", "Le poids doit etre supérieur à 0", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else if (cbLang.Text == "EN")
                            Custom_MessageBox.Show("EN", "Weight must be greater than 0", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            else if (TypePesee == "2x1")
            {
                if (check_fields())
                {
                    DateTime DateHeurePoidsTare;
                    Int32 Poids;
                    bool IsParsablePoids;
                    bool IsParsableTare;
                    Int32 Tare;
                    IsParsablePoids = Int32.TryParse(txtPoids.Text, out Poids);
                    if (IsParsablePoids && Poids > 0)
                    {
                        lbPoidsTare.Text = Poids.ToString();
                        IsParsableTare = Int32.TryParse(lbPoidsTare.Text, out Tare);
                        DateHeurePoidsTare = DateTime.Now;
                        lbDateHeurePoidsTare.Text = DateHeurePoidsTare.ToString();
                        lbStatus.Text = "Pending";
                        try
                        {
                            if (IsParsableTare)
                            {
                                PeseePB peseePB = new PeseePB();
                                peseePB.Add("2x", Flux, Common_functions.CbSelectedValue_Convert_Int(cbPont), Common_functions.CbSelectedValue_Convert_Int(cbWeighingSettingsId), Common_functions.CbSelectedValue_Convert_Int(cbFirme), Common_functions.CbSelectedValue_Convert_Int(cbCamion),
                                    Common_functions.CbSelectedValue_Convert_Int(cbChauffeur), Common_functions.CbSelectedValue_Convert_Int(cbTransporteur), Common_functions.CbSelectedValue_Convert_Int(cbProduit),
                                    Common_functions.CbSelectedValue_Convert_Int(cbClient), Common_functions.CbSelectedValue_Convert_Int(cbChamp1), Table1Id, Table1Name, cbChamp1.Text, Common_functions.CbSelectedValue_Convert_Int(cbChamp2), Table2Id, Table2Name, cbChamp2.Text,
                                    Common_functions.CbSelectedValue_Convert_Int(cbChamp3), Table3Id, Table3Name, cbChamp3.Text, Common_functions.CbSelectedValue_Convert_Int(cbChamp4), Table4Id, Table4Name, cbChamp4.Text, Common_functions.CbSelectedValue_Convert_Int(cbChamp5), Table5Id, Table5Name, cbChamp5.Text,
                                    Common_functions.CbSelectedValue_Convert_Int(cbChamp6), Table6Id, Table6Name, cbChamp6.Text, Common_functions.CbSelectedValue_Convert_Int(cbChamp7), Table7Id, Table7Name, cbChamp7.Text
                                    , 0, DateHeurePoidsTare, Tare, DateHeurePoidsTare, 0, lblusername.Text, lbStatus.Text, ChampLibre1Name, txtChampLibre1.Text, ChampLibre2Name, txtChampLibre2.Text, ChampLibre3Name, txtChampLibre3.Text, ChampLibre4Name, txtChampLibre4.Text, Common_functions.CbSelectedValue_Convert_Int(cbWalterre));



                                getMaxId();
                                //Details de la pesée et impression
                                if (cbLang.Text == "FR")
                                    Custom_MessageBox.Show("FR", "Premiere pesée enregistrée avec succès", "Pesée: " + txtId.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else if (cbLang.Text == "EN")
                                    Custom_MessageBox.Show("EN", "Weighing over", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                InitializeWeighingSettings(Common_functions.CbSelectedValue_Convert_Int(cbPont));
                                Initialize_Data();
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
                            Custom_MessageBox.Show("FR", "Le poids doit etre supérieur à 0", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else if (cbLang.Text == "EN")
                            Custom_MessageBox.Show("EN", "Weight must be greater than 0", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            //if (TypePesee == "2x2")
            else
            {
                if (check_fields())
                {
                    DateTime DateHeurePoidsBrut;
                    DateTime DateHeurePoidsTare;
                    Int32 Poids;
                    bool IsParsablePoids;
                    bool IsParsableBrut;
                    bool IsParsableTare;
                    bool IsParsableDateHeurePoidsTare;
                    Int32 Brut;
                    Int32 Tare;
                    Int32 PoidsNet;
                    IsParsablePoids = Int32.TryParse(txtPoids.Text, out Poids);
                    if (IsParsablePoids && Poids > 0)
                    {
                        lbPoidsBrut.Text = Poids.ToString();
                        IsParsableBrut = Int32.TryParse(lbPoidsBrut.Text, out Brut);
                        IsParsableTare = Int32.TryParse(lbPoidsTare.Text, out Tare);
                        IsParsableDateHeurePoidsTare = DateTime.TryParse(lbDateHeurePoidsTare.Text, out DateHeurePoidsTare);
                        DateHeurePoidsBrut = DateTime.Now;
                        lbDateHeurePoidsBrut.Text = DateHeurePoidsBrut.ToString();
                        PoidsNet = Math.Abs(Brut - Tare);
                        lbPoidsNet.Text = PoidsNet.ToString();
                        lbStatus.Text = "Complete";
                        try
                        {
                            if (IsParsableBrut && IsParsableTare && IsParsableDateHeurePoidsTare)
                            {
                                PeseePB peseePB = new PeseePB();
                                peseePB.Update(vg_Id, "2x", Flux, Common_functions.CbSelectedValue_Convert_Int(cbPont), Common_functions.CbSelectedValue_Convert_Int(cbWeighingSettingsId), Common_functions.CbSelectedValue_Convert_Int(cbFirme), Common_functions.CbSelectedValue_Convert_Int(cbCamion),
                                    Common_functions.CbSelectedValue_Convert_Int(cbChauffeur), Common_functions.CbSelectedValue_Convert_Int(cbTransporteur), Common_functions.CbSelectedValue_Convert_Int(cbProduit),
                                    Common_functions.CbSelectedValue_Convert_Int(cbClient), Common_functions.CbSelectedValue_Convert_Int(cbChamp1), Table1Id, Table1Name, cbChamp1.Text, Common_functions.CbSelectedValue_Convert_Int(cbChamp2), Table2Id, Table2Name, cbChamp2.Text,
                                    Common_functions.CbSelectedValue_Convert_Int(cbChamp3), Table3Id, Table3Name, cbChamp3.Text, Common_functions.CbSelectedValue_Convert_Int(cbChamp4), Table4Id, Table4Name, cbChamp4.Text, Common_functions.CbSelectedValue_Convert_Int(cbChamp5), Table5Id, Table5Name, cbChamp5.Text,
                                    Common_functions.CbSelectedValue_Convert_Int(cbChamp6), Table6Id, Table6Name, cbChamp6.Text, Common_functions.CbSelectedValue_Convert_Int(cbChamp7), Table7Id, Table7Name, cbChamp7.Text
                                    , Brut, DateHeurePoidsBrut, Tare, DateHeurePoidsTare, PoidsNet, lblusername.Text, lbStatus.Text, ChampLibre1Name, txtChampLibre1.Text, ChampLibre2Name, txtChampLibre2.Text, ChampLibre3Name, txtChampLibre3.Text, ChampLibre4Name, txtChampLibre4.Text, Common_functions.CbSelectedValue_Convert_Int(cbWalterre));


                                if (cbLang.Text == "FR")
                                    Custom_MessageBox.Show("FR", "Pesage Terminé, impression du ticket ...", "Pesée: " + txtId.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else if (cbLang.Text == "EN")
                                    Custom_MessageBox.Show("EN", "Weighing over", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Form form = new PeseePBTicketA5(vg_Id);
                                form.Show();
                                Clear();
                                rb1x.Checked = true;
                                InitializeWeighingSettings(Common_functions.CbSelectedValue_Convert_Int(cbPont));
                                Initialize_Data();

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
                            Custom_MessageBox.Show("FR", "Le poids doit etre supérieur à 0", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else if (cbLang.Text == "EN")
                            Custom_MessageBox.Show("EN", "Weight must be greater than 0", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async void btSimulateur_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Entrez un poids", "Simulateur Poids");
            txtPoids.Text = input;

            await TunnelCommunicationHelper.SendWeightMessageAsync(int.Parse(input), false);
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

        private void btAddPont_Click(object sender, EventArgs e)
        {

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


        private void rb2x2_CheckedChanged(object sender, EventArgs e)
        {
            //if (rb2x2.Checked)
            //{
            // Edit_Item_2x2();
            //}
        }



        private void MenuItemNouveau_Click(object sender, EventArgs e)
        {

        }

        private void MenuItemTerminer_Click(object sender, EventArgs e)
        {
            if (check_fields_min())
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "ATTENTION, les données non enregistrées seront perdues. Etes vous sur?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Camión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    vg_Id = Common_functions.GetDatagridViewSelectedId(DgvList);
                    Refresh_Dgv();
                    Edit_Item_2x2();
                }
                else
                {
                    if (rb1x.Checked)
                    {
                        vg_Clearing = true;
                        rb1x.Checked = true;
                    }
                    else
                    {
                        vg_Clearing = true;
                        rb2x1.Checked = true;
                    }
                }
            }
            else
            {
                Clear();
                vg_Id = Common_functions.GetDatagridViewSelectedId(DgvList);
                Enable();
                Refresh_Dgv();
                Edit_Item_2x2();
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
                language_Manager.ChangeLanguage("fr", this, typeof(PeseePontBascule));

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

        private void pontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new PeseePBList("1=1");
            form.Show();
        }

        private void ParamPoidstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new WeightSettingsList("1=1");
            form.Show();
        }

        private void camionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new CamionsListe("1=1");
            form.Show();
        }

        private void produitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ProduitsListe("1=1");
            form.Show();
        }

        private void chauffeursToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new ChauffeursListe("1=1");
            form.Show();
        }

        private void transporteursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new TransporteursListe("1=1");
            form.Show();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ClientsListe("1=1");
            form.Show();
        }

        private void firmesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FirmesList("1=1");
            form.Show();
        }

        private void pamamètresDePeséeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new WeighingSettingsList("1=1");
            form.Show();
        }

        private void tablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new TablesList("1=1");
            form.Show();
        }

        private void enregistrementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new EnregistrementsListe("1=1");
            form.Show();
        }

        private void cbWeighingSettingsId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbFirme_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbWeighingSettingsId_SelectedValueChanged(object sender, EventArgs e)
        {
            if (init_WeighingSettings)
                ApplyWeighingSettings(Common_functions.CbSelectedValue_Convert_Int(cbWeighingSettingsId), true);
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

        private void DgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtId.Text == "")
            {
                if (check_fields_min())
                {
                    DialogResult result;
                    if (cbLang.Text == "FR")
                        result = Custom_MessageBox.Show("FR", "ATTENTION, les données non enregistrées seront perdues. Etes vous sur?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    else if (cbLang.Text == "EN")
                        result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    else
                        result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Camión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        vg_Id = Common_functions.GetDatagridViewSelectedId(DgvList);
                        Refresh_Dgv();
                        Edit_Item_2x2();
                    }
                    else
                    {
                        if (rb1x.Checked)
                        {
                            vg_Clearing = true;
                            rb1x.Checked = true;
                        }
                        else
                        {
                            vg_Clearing = true;
                            rb2x1.Checked = true;
                        }
                    }
                }
                else
                {
                    Clear();
                    vg_Id = Common_functions.GetDatagridViewSelectedId(DgvList);
                    Enable();
                    Refresh_Dgv();
                    Edit_Item_2x2();
                }
            }

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (check_fields_min())
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "ATTENTION, les données non enregistrées seront perdues. Etes vous sur?", "Annulation pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Camión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    InitializeWeighingSettings(Common_functions.CbSelectedValue_Convert_Int(cbPont));
                    Initialize_Data();
                }
            }
        }

        private void toolStripSearch_TextChanged(object sender, EventArgs e)
        {
            PeseePB pesee = new PeseePB();
            DgvList.DataSource = pesee.SearchBoxPending(toolStripSearch.Text);
        }

        private void toolStripSearch_Click(object sender, EventArgs e)
        {

        }

        private void T50PLUS_TextChanged(object sender, EventArgs e)
        {

        }

        private void JaugeTimer_Tick(object sender, EventArgs e)
        {
            int Poids;
            bool IsParsablePoids;
            IsParsablePoids = Int32.TryParse(txtPoids.Text, out Poids);
            if (IsParsablePoids)
                JaugeManager(Poids);
            else
                JaugeManager(0);

        }

        private void JaugeManager(int Poids)
        {
            if (Poids >= 0 && Poids < 2000)
            {
                T0A2.Visible = true;
                T2A5.Visible = false;
                T5A7.Visible = false;
                T7A10.Visible = false;
                T10A13.Visible = false;
                T13A20.Visible = false;
                T20A30.Visible = false;
                T30A50.Visible = false;
                T50PLUS.Visible = false;
            }

            if (Poids >= 2000 && Poids < 5000)
            {
                T0A2.Visible = true;
                T2A5.Visible = true;
                T5A7.Visible = false;
                T7A10.Visible = false;
                T10A13.Visible = false;
                T13A20.Visible = false;
                T20A30.Visible = false;
                T30A50.Visible = false;
                T50PLUS.Visible = false;
            }

            if (Poids >= 5000 && Poids < 7000)
            {
                T0A2.Visible = true;
                T2A5.Visible = true;
                T5A7.Visible = true;
                T7A10.Visible = false;
                T10A13.Visible = false;
                T13A20.Visible = false;
                T20A30.Visible = false;
                T30A50.Visible = false;
                T50PLUS.Visible = false;
            }

            if (Poids >= 7000 && Poids < 10000)
            {
                T0A2.Visible = true;
                T2A5.Visible = true;
                T5A7.Visible = true;
                T7A10.Visible = true;
                T10A13.Visible = false;
                T13A20.Visible = false;
                T20A30.Visible = false;
                T30A50.Visible = false;
                T50PLUS.Visible = false;
            }

            if (Poids >= 10000 && Poids < 13000)
            {
                T0A2.Visible = true;
                T2A5.Visible = true;
                T5A7.Visible = true;
                T7A10.Visible = true;
                T10A13.Visible = true;
                T13A20.Visible = false;
                T20A30.Visible = false;
                T30A50.Visible = false;
                T50PLUS.Visible = false;
            }

            if (Poids >= 13000 && Poids < 20000)
            {
                T0A2.Visible = true;
                T2A5.Visible = true;
                T5A7.Visible = true;
                T7A10.Visible = true;
                T10A13.Visible = true;
                T13A20.Visible = true;
                T20A30.Visible = false;
                T30A50.Visible = false;
                T50PLUS.Visible = false;
            }

            if (Poids >= 20000 && Poids < 30000)
            {
                T0A2.Visible = true;
                T2A5.Visible = true;
                T5A7.Visible = true;
                T7A10.Visible = true;
                T10A13.Visible = true;
                T13A20.Visible = true;
                T20A30.Visible = true;
                T30A50.Visible = false;
                T50PLUS.Visible = false;
            }

            if (Poids >= 30000 && Poids < 50000)
            {
                T0A2.Visible = true;
                T2A5.Visible = true;
                T5A7.Visible = true;
                T7A10.Visible = true;
                T10A13.Visible = true;
                T13A20.Visible = true;
                T20A30.Visible = true;
                T30A50.Visible = true;
                T50PLUS.Visible = false;
            }

            if (Poids >= 50000)
            {
                T0A2.Visible = true;
                T2A5.Visible = true;
                T5A7.Visible = true;
                T7A10.Visible = true;
                T10A13.Visible = true;
                T13A20.Visible = true;
                T20A30.Visible = true;
                T30A50.Visible = true;
                T50PLUS.Visible = true;
            }

            if (Poids >= Poids_Detection)
                pbOnScale.Visible = true;
            else
                pbOnScale.Visible = false;


        }

        private void btAddChamp1_Click(object sender, EventArgs e)
        {
            if (cbChamp1.Text != "" && cbChamp1.Text.Trim().Length > 1)
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir ajouter l'enregistrement" + cbChamp1.Text + "?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure you want to add the record: " + cbChamp1.Text + "?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Enregistrements enregistrements = new Enregistrements();
                        enregistrements.Add(Table1Id, cbChamp1.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", 0);
                        cbChamp1.DataSource = enregistrements.FindByTableId(Table1Id); ;
                        cbChamp1.DisplayMember = "NOM";
                        cbChamp1.ValueMember = "ENREGISTREMENTSID";
                        //cbChamp1_SelectedValueChanged(this, EventArgs.Empty);                       
                        cbChamp1.SelectedIndex = cbChamp1.Items.Count - 1;
                        cbChamp1_Leave(this, EventArgs.Empty);
                    }
                    catch
                    {
                        throw;
                    }

                }
            }
        }

        private void btAddChamp2_Click(object sender, EventArgs e)
        {
            if (cbChamp2.Text != "" && cbChamp2.Text.Trim().Length > 1)
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir ajouter l'enregistrement" + cbChamp2.Text + "?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure you want to add the record: " + cbChamp2.Text + "?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Tables tables = new Tables();
                    Enregistrements enregistrements = new Enregistrements();
                    if (tables.IsTableRelated(Table2Id))
                    {
                        try
                        {
                            if (tables.GetParentTableId(Table2Id) == Table1Id)
                            {
                                if (cbChamp1.Text != "" && cbChamp1.Text.Trim().Length > 1)
                                {
                                    enregistrements.Add(Table2Id, cbChamp2.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", Common_functions.CbSelectedValue_Convert_Int(cbChamp1));
                                    cbChamp2.DataSource = enregistrements.FindByTableId(Table2Id); ;
                                    cbChamp2.DisplayMember = "NOM";
                                    cbChamp2.ValueMember = "ENREGISTREMENTSID";
                                    //cbChamp1_SelectedValueChanged(this, EventArgs.Empty);                       
                                    cbChamp2.SelectedIndex = cbChamp2.Items.Count - 1;
                                    cbChamp2_Leave(this, EventArgs.Empty);
                                }
                                else
                                {
                                    if (cbLang.Text == "FR")
                                        Custom_MessageBox.Show("FR", "L'enregistrement parent est obligatoire.", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else if (cbLang.Text == "EN")
                                        Custom_MessageBox.Show("EN", "Parent record is required", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                        Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else
                            {
                                if (cbLang.Text == "FR")
                                    Custom_MessageBox.Show("FR", "Il y'a une incoherence dans le parmétrage des liens entre les tables.", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else if (cbLang.Text == "EN")
                                    Custom_MessageBox.Show("EN", "There is an error in the links between the tables", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                    Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        catch
                        {
                            throw;
                        }
                    }
                    else
                    {
                        try
                        {
                            enregistrements.Add(Table2Id, cbChamp2.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", 0);
                            cbChamp2.DataSource = enregistrements.FindByTableId(Table2Id); ;
                            cbChamp2.DisplayMember = "NOM";
                            cbChamp2.ValueMember = "ENREGISTREMENTSID";
                            //cbChamp1_SelectedValueChanged(this, EventArgs.Empty);                       
                            cbChamp2.SelectedIndex = cbChamp2.Items.Count - 1;
                            cbChamp2_Leave(this, EventArgs.Empty);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }
        }

        private void btSaisirPoids_Click(object sender, EventArgs e)
        {

        }

        private void btAddChamp3_Click(object sender, EventArgs e)
        {
            if (cbChamp3.Text != "" && cbChamp3.Text.Trim().Length > 1)
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir ajouter l'enregistrement" + cbChamp3.Text + "?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure you want to add the record: " + cbChamp3.Text + "?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Tables tables = new Tables();
                    Enregistrements enregistrements = new Enregistrements();
                    if (tables.IsTableRelated(Table3Id))
                    {
                        try
                        {
                            if (tables.GetParentTableId(Table3Id) == Table2Id)
                            {
                                if (cbChamp2.Text != "" && cbChamp2.Text.Trim().Length > 1)
                                {
                                    enregistrements.Add(Table3Id, cbChamp3.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", Common_functions.CbSelectedValue_Convert_Int(cbChamp2));
                                    cbChamp3.DataSource = enregistrements.FindByTableId(Table3Id); ;
                                    cbChamp3.DisplayMember = "NOM";
                                    cbChamp3.ValueMember = "ENREGISTREMENTSID";
                                    //cbChamp1_SelectedValueChanged(this, EventArgs.Empty);                       
                                    cbChamp3.SelectedIndex = cbChamp3.Items.Count - 1;
                                    cbChamp3_Leave(this, EventArgs.Empty);
                                }
                                else
                                {
                                    if (cbLang.Text == "FR")
                                        Custom_MessageBox.Show("FR", "L'enregistrement parent est obligatoire.", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else if (cbLang.Text == "EN")
                                        Custom_MessageBox.Show("EN", "Parent record is required", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                        Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else
                            {
                                if (cbLang.Text == "FR")
                                    Custom_MessageBox.Show("FR", "Il y'a une incoherence dans le parmétrage des liens entre les tables.", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else if (cbLang.Text == "EN")
                                    Custom_MessageBox.Show("EN", "There is an error in the links between the tables", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                    Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        catch
                        {
                            throw;
                        }
                    }
                    else
                    {
                        try
                        {
                            enregistrements.Add(Table3Id, cbChamp3.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", 0);
                            cbChamp3.DataSource = enregistrements.FindByTableId(Table3Id); ;
                            cbChamp3.DisplayMember = "NOM";
                            cbChamp3.ValueMember = "ENREGISTREMENTSID";
                            //cbChamp1_SelectedValueChanged(this, EventArgs.Empty);                       
                            cbChamp3.SelectedIndex = cbChamp3.Items.Count - 1;
                            cbChamp3_Leave(this, EventArgs.Empty);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }
        }

        private void btAddChamp4_Click(object sender, EventArgs e)
        {
            if (cbChamp4.Text != "" && cbChamp4.Text.Trim().Length > 1)
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir ajouter l'enregistrement" + cbChamp4.Text + "?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure you want to add the record: " + cbChamp4.Text + "?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Tables tables = new Tables();
                    Enregistrements enregistrements = new Enregistrements();
                    if (tables.IsTableRelated(Table4Id))
                    {
                        try
                        {
                            if (tables.GetParentTableId(Table4Id) == Table3Id)
                            {
                                if (cbChamp3.Text != "" && cbChamp3.Text.Trim().Length > 1)
                                {
                                    enregistrements.Add(Table4Id, cbChamp4.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", Common_functions.CbSelectedValue_Convert_Int(cbChamp3));
                                    cbChamp4.DataSource = enregistrements.FindByTableId(Table4Id); ;
                                    cbChamp4.DisplayMember = "NOM";
                                    cbChamp4.ValueMember = "ENREGISTREMENTSID";
                                    //cbChamp1_SelectedValueChanged(this, EventArgs.Empty);                       
                                    cbChamp4.SelectedIndex = cbChamp4.Items.Count - 1;
                                    cbChamp4_Leave(this, EventArgs.Empty);
                                }
                                else
                                {
                                    if (cbLang.Text == "FR")
                                        Custom_MessageBox.Show("FR", "L'enregistrement parent est obligatoire.", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else if (cbLang.Text == "EN")
                                        Custom_MessageBox.Show("EN", "Parent record is required", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                        Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else
                            {
                                if (cbLang.Text == "FR")
                                    Custom_MessageBox.Show("FR", "Il y'a une incoherence dans le parmétrage des liens entre les tables.", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else if (cbLang.Text == "EN")
                                    Custom_MessageBox.Show("EN", "There is an error in the links between the tables", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                    Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        catch
                        {
                            throw;
                        }
                    }
                    else
                    {
                        try
                        {
                            enregistrements.Add(Table4Id, cbChamp4.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", 0);
                            cbChamp4.DataSource = enregistrements.FindByTableId(Table4Id); ;
                            cbChamp4.DisplayMember = "NOM";
                            cbChamp4.ValueMember = "ENREGISTREMENTSID";
                            //cbChamp1_SelectedValueChanged(this, EventArgs.Empty);                       
                            cbChamp4.SelectedIndex = cbChamp4.Items.Count - 1;
                            cbChamp4_Leave(this, EventArgs.Empty);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }
        }

        private void btAddChamp5_Click(object sender, EventArgs e)
        {
            if (cbChamp5.Text != "" && cbChamp5.Text.Trim().Length > 1)
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir ajouter l'enregistrement" + cbChamp5.Text + "?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure you want to add the record: " + cbChamp5.Text + "?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Tables tables = new Tables();
                    Enregistrements enregistrements = new Enregistrements();
                    if (tables.IsTableRelated(Table5Id))
                    {
                        try
                        {
                            if (tables.GetParentTableId(Table5Id) == Table4Id)
                            {
                                if (cbChamp4.Text != "" && cbChamp4.Text.Trim().Length > 1)
                                {
                                    enregistrements.Add(Table5Id, cbChamp5.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", Common_functions.CbSelectedValue_Convert_Int(cbChamp4));
                                    cbChamp5.DataSource = enregistrements.FindByTableId(Table5Id); ;
                                    cbChamp5.DisplayMember = "NOM";
                                    cbChamp5.ValueMember = "ENREGISTREMENTSID";
                                    //cbChamp1_SelectedValueChanged(this, EventArgs.Empty);                       
                                    cbChamp5.SelectedIndex = cbChamp5.Items.Count - 1;
                                    cbChamp5_Leave(this, EventArgs.Empty);
                                }
                                else
                                {
                                    if (cbLang.Text == "FR")
                                        Custom_MessageBox.Show("FR", "L'enregistrement parent est obligatoire.", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else if (cbLang.Text == "EN")
                                        Custom_MessageBox.Show("EN", "Parent record is required", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                        Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else
                            {
                                if (cbLang.Text == "FR")
                                    Custom_MessageBox.Show("FR", "Il y'a une incoherence dans le parmétrage des liens entre les tables.", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else if (cbLang.Text == "EN")
                                    Custom_MessageBox.Show("EN", "There is an error in the links between the tables", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                    Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        catch
                        {
                            throw;
                        }
                    }
                    else
                    {
                        try
                        {
                            enregistrements.Add(Table5Id, cbChamp5.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", 0);
                            cbChamp5.DataSource = enregistrements.FindByTableId(Table5Id); ;
                            cbChamp5.DisplayMember = "NOM";
                            cbChamp5.ValueMember = "ENREGISTREMENTSID";
                            //cbChamp1_SelectedValueChanged(this, EventArgs.Empty);                       
                            cbChamp5.SelectedIndex = cbChamp5.Items.Count - 1;
                            cbChamp5_Leave(this, EventArgs.Empty);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }
        }

        private void btAddChamp6_Click(object sender, EventArgs e)
        {
            if (cbChamp6.Text != "" && cbChamp6.Text.Trim().Length > 1)
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir ajouter l'enregistrement" + cbChamp6.Text + "?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure you want to add the record: " + cbChamp6.Text + "?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Tables tables = new Tables();
                    Enregistrements enregistrements = new Enregistrements();
                    if (tables.IsTableRelated(Table6Id))
                    {
                        try
                        {
                            if (tables.GetParentTableId(Table6Id) == Table5Id)
                            {
                                if (cbChamp5.Text != "" && cbChamp5.Text.Trim().Length > 1)
                                {
                                    enregistrements.Add(Table6Id, cbChamp6.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", Common_functions.CbSelectedValue_Convert_Int(cbChamp5));
                                    cbChamp6.DataSource = enregistrements.FindByTableId(Table6Id); ;
                                    cbChamp6.DisplayMember = "NOM";
                                    cbChamp6.ValueMember = "ENREGISTREMENTSID";
                                    //cbChamp1_SelectedValueChanged(this, EventArgs.Empty);                       
                                    cbChamp6.SelectedIndex = cbChamp6.Items.Count - 1;
                                    cbChamp6_Leave(this, EventArgs.Empty);
                                }
                                else
                                {
                                    if (cbLang.Text == "FR")
                                        Custom_MessageBox.Show("FR", "L'enregistrement parent est obligatoire.", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else if (cbLang.Text == "EN")
                                        Custom_MessageBox.Show("EN", "Parent record is required", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                        Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else
                            {
                                if (cbLang.Text == "FR")
                                    Custom_MessageBox.Show("FR", "Il y'a une incoherence dans le parmétrage des liens entre les tables.", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else if (cbLang.Text == "EN")
                                    Custom_MessageBox.Show("EN", "There is an error in the links between the tables", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                    Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        catch
                        {
                            throw;
                        }
                    }
                    else
                    {
                        try
                        {
                            enregistrements.Add(Table6Id, cbChamp6.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", 0);
                            cbChamp6.DataSource = enregistrements.FindByTableId(Table6Id); ;
                            cbChamp6.DisplayMember = "NOM";
                            cbChamp6.ValueMember = "ENREGISTREMENTSID";
                            //cbChamp1_SelectedValueChanged(this, EventArgs.Empty);                       
                            cbChamp6.SelectedIndex = cbChamp6.Items.Count - 1;
                            cbChamp6_Leave(this, EventArgs.Empty);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }
        }

        private void btAddChamp7_Click(object sender, EventArgs e)
        {
            if (cbChamp7.Text != "" && cbChamp7.Text.Trim().Length > 1)
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir ajouter l'enregistrement" + cbChamp7.Text + "?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure you want to add the record: " + cbChamp7.Text + "?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Tables tables = new Tables();
                    Enregistrements enregistrements = new Enregistrements();
                    if (tables.IsTableRelated(Table7Id))
                    {
                        try
                        {
                            if (tables.GetParentTableId(Table7Id) == Table6Id)
                            {
                                if (cbChamp6.Text != "" && cbChamp6.Text.Trim().Length > 1)
                                {
                                    enregistrements.Add(Table7Id, cbChamp7.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", Common_functions.CbSelectedValue_Convert_Int(cbChamp6));
                                    cbChamp7.DataSource = enregistrements.FindByTableId(Table7Id); ;
                                    cbChamp7.DisplayMember = "NOM";
                                    cbChamp7.ValueMember = "ENREGISTREMENTSID";
                                    //cbChamp1_SelectedValueChanged(this, EventArgs.Empty);                       
                                    cbChamp7.SelectedIndex = cbChamp7.Items.Count - 1;
                                    cbChamp7_Leave(this, EventArgs.Empty);
                                }
                                else
                                {
                                    if (cbLang.Text == "FR")
                                        Custom_MessageBox.Show("FR", "L'enregistrement parent est obligatoire.", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else if (cbLang.Text == "EN")
                                        Custom_MessageBox.Show("EN", "Parent record is required", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                        Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else
                            {
                                if (cbLang.Text == "FR")
                                    Custom_MessageBox.Show("FR", "Il y'a une incoherence dans le parmétrage des liens entre les tables.", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else if (cbLang.Text == "EN")
                                    Custom_MessageBox.Show("EN", "There is an error in the links between the tables", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                    Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        catch
                        {
                            throw;
                        }
                    }
                    else
                    {
                        try
                        {
                            enregistrements.Add(Table7Id, cbChamp7.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", 0);
                            cbChamp7.DataSource = enregistrements.FindByTableId(Table7Id); ;
                            cbChamp7.DisplayMember = "NOM";
                            cbChamp7.ValueMember = "ENREGISTREMENTSID";
                            //cbChamp1_SelectedValueChanged(this, EventArgs.Empty);                       
                            cbChamp7.SelectedIndex = cbChamp7.Items.Count - 1;
                            cbChamp7_Leave(this, EventArgs.Empty);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }
        }

        private void panelLang_Paint(object sender, PaintEventArgs e)
        {

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

        private void cbCamion_SelectedValueChanged(object sender, EventArgs e)
        {
            if (init_WeighingSettings  && cbCamion.Text.Trim() != "" && Common_functions.CbSelectedValue_Convert_Int(cbCamion) > 0)
            {
                Camion camion = new Camion();
                Chauffeur chauffeur = new Chauffeur();
                Transporteur transporteur = new Transporteur();
                CamionChauffeur camionChauffeur = new CamionChauffeur();
                CamionTransporteur camionTransporteur = new CamionTransporteur();



                if (EnableChauffeur > 0)
                {
                    if (CamionChauffeur > 0)
                    {
                        if (camionChauffeur.CountByCamionId(Common_functions.CbSelectedValue_Convert_Int(cbCamion)) > 0)
                        {
                            cbChauffeur.DataSource = camionChauffeur.FindByCamionId(Common_functions.CbSelectedValue_Convert_Int(cbCamion));
                            cbChauffeur.DisplayMember = "CHAUFFEUR";
                            cbChauffeur.ValueMember = "CHAUFFEURID";
                            cbChauffeur.Text = "";
                            cbChauffeur.SelectedIndex = -1;
                            cbChauffeur.BackColor = Color.Honeydew;
                            cbChauffeur.ForeColor = Color.Black;
                        }
                        else
                        {
                            //Rien
                        }
                    }
                }

                if (EnableTransporteur > 0)
                {
                    if (CamionTransporteur > 0)
                    {
                        if (camionTransporteur.CountByCamionId(Common_functions.CbSelectedValue_Convert_Int(cbCamion)) > 0)
                        {
                            cbTransporteur.DataSource = camionTransporteur.FindByCamionId(Common_functions.CbSelectedValue_Convert_Int(cbCamion));
                            cbTransporteur.DisplayMember = "TRANSPORTEUR";
                            cbTransporteur.ValueMember = "TRANSPORTEURID";
                            cbTransporteur.Text = "";
                            cbTransporteur.SelectedIndex = -1;
                            cbTransporteur.BackColor = Color.Honeydew;
                            cbTransporteur.ForeColor = Color.Black;
                        }
                        else
                        {
                            //Rien
                        }
                    }
                }  
            }
        }
    }
}