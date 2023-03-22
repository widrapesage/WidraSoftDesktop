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
using WidraSoft.BL;

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

        // Weighing Settings Informations
        int EnableCamion;
        int EnableChauffeur;
        int EnableTransporteur;
        int EnableProduit;
        int EnableClient;
        int EnableDestination;
        int EnableProvenance;

        //Weighing Type 
        string TypePesee;
        //Flux
        string Flux;

        public PeseePontBascule()
        {
            InitializeComponent();
            menuStrip.Renderer = menuStrip1.Renderer = new MyRenderer();
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
            cbPont.DataSource = pont.List("1=1");
            cbPont.DisplayMember = "DESIGNATION";
            cbPont.ValueMember = "PONTID";

            Int32 pontId = 16;

            lbCOM.Text = "COM" + pont.GetCOM(pontId);
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
                try
                {
                    //com.Open();
                }
                catch { throw; }


                WeightSettings weightSettings = new WeightSettings();
                DataTable dtWeightSettings = new DataTable();
                dtWeightSettings = weightSettings.FindById(pont.GetWeightSettingsId(pontId));
                foreach (DataRow r in dtWeightSettings.Rows)
                {
                    lbWeightSettings.Text = r["DESIGNATION"].ToString();
                    TimerInterval = (int)r["TIMERINTERVAL"];
                    Weight_Timer.Interval = TimerInterval;
                    Weight_Timer.Stop();
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

                WeighingSettings weighingSettings = new WeighingSettings();
                DataTable dtWeighingSettings = new DataTable();
                dtWeighingSettings = weighingSettings.FindById(pont.GetWeighingSettingsId(pontId));
                foreach (DataRow ro in dtWeighingSettings.Rows)
                {
                    lbWeighingSettings.Text = ro["DESIGNATION"].ToString();
                    EnableCamion = (int)ro["CAMION"];
                    EnableChauffeur = (int)ro["CHAUFFEUR"];
                    EnableTransporteur = (int)ro["TRANSPORTEUR"];
                    EnableProduit = (int)ro["PRODUIT"];
                    EnableClient = (int)ro["CLIENT"];
                    EnableDestination = (int)ro["DESTINATION"];
                    EnableProvenance = (int)ro["PROVENANCE"];
                }
            }

            Initialize_Data();

            rb1x.Checked = true;
            
            //Lang
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = 0;

        }

        private void Initialize_Data()
        {
            lbStatus.Text = "En cours";

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
            DgvList.Columns["PONT"].Visible = true;
            DgvList.Columns["FIRMEID"].Visible = false;
            DgvList.Columns["FIRME"].Visible = false;
            DgvList.Columns["CAMIONID"].Visible = false;
            DgvList.Columns["CAMION"].Visible = true;
            DgvList.Columns["CHAUFFEURID"].Visible = false;
            DgvList.Columns["CHAUFFEUR"].Visible = false;
            DgvList.Columns["TRANSPORTEURID"].Visible = false;
            DgvList.Columns["TRANSPORTEUR"].Visible = false;
            DgvList.Columns["PRODUITID"].Visible = false;
            DgvList.Columns["PRODUIT"].Visible = false;
            DgvList.Columns["CLIENTID"].Visible = false;
            DgvList.Columns["CLIENT"].Visible = false;
            DgvList.Columns["POIDS1"].Visible = false;
            DgvList.Columns["DATEHEUREPOIDS1"].Visible = false;
            DgvList.Columns["POIDS2"].Visible = false;
            DgvList.Columns["DATEHEUREPOIDS2"].Visible = false;
            DgvList.Columns["POIDSNET"].Visible = false;
            DgvList.Columns["USER_INFO"].Visible = false;
            DgvList.Columns["ETATPESEE"].Visible = true;
            DgvList.Columns["ETATPESEE"].HeaderText = "ETAT";
            DgvList.Columns["DATECREATION"].Visible = false;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            DgvList.ReadOnly = true;

        }

        private void Localize_Dgv(string lang)
        {
            if (lang == "fr")
            {
                DgvList.Columns[0].HeaderText = "NUMERO";
                DgvList.Columns["PONT"].HeaderText = "PONT";
                DgvList.Columns["CAMION"].HeaderText = "CAMION";
                DgvList.Columns["PRODUIT"].HeaderText = "PRODUIT";
                DgvList.Columns["POIDS1"].HeaderText = "POIDS BRUT";
                DgvList.Columns["DATEHEUREPOIDS1"].HeaderText = "DATE POIDS BRUT";
                DgvList.Columns["POIDS2"].HeaderText = "TARE";
                DgvList.Columns["DATEHEUREPOIDS2"].HeaderText = "DATE TARE";
                DgvList.Columns["ETATPESEE"].HeaderText = "ETAT";
            }
            if (lang == "en")
            {
                DgvList.Columns["DESIGNATION"].HeaderText = "NAME";
                DgvList.Columns["CODE"].HeaderText = "CODE";
                DgvList.Columns["LIMITER"].HeaderText = "LIMIT";
                DgvList.Columns["NBLIMITE"].HeaderText = "LIMIT NUMBER";
                DgvList.Columns["DATECREATION"].HeaderText = "CREATION DATE";
                DgvList.Columns["ETATPESEE"].HeaderText = "ETAT";
            }
            if (lang == "es")
            {
                DgvList.Columns["DESIGNATION"].HeaderText = "DESIGNACION";
                DgvList.Columns["CODE"].HeaderText = "CODIGO";
                DgvList.Columns["LIMITER"].HeaderText = "LÍMITE";
                DgvList.Columns["NBLIMITE"].HeaderText = "NÚMERO LIMITADO";
                DgvList.Columns["DATECREATION"].HeaderText = "FECHA DE CREACIÓN";
                DgvList.Columns["ETATPESEE"].HeaderText = "ETAT";
            }

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
                    if (txtId.Text == "" && cbPont.Text == "" && cbFirme.Text == "" && cbCamion.Text == "" && cbChauffeur.Text == "" && cbTransporteur.Text == "" && cbProduit.Text == "" && cbClient.Text == "")
                    {

                        rbxEntrant.Checked = true;
                        TypePesee = "1x";
                        txtTareCamion.Visible = true;
                        lbTareCamion.Visible = true;
                        txtTareCamion.Text = "";
                        ApplyWeighingSettings();
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
                if (txtId.Text == "" && cbPont.Text == "" && cbFirme.Text == "" && cbCamion.Text == "" && cbChauffeur.Text == "" && cbTransporteur.Text == "" && cbProduit.Text == "" && cbClient.Text == "")
                {

                    rbxEntrant.Checked = true;
                    TypePesee = "1x";
                    txtTareCamion.Visible = true;
                    lbTareCamion.Visible = true;
                    txtTareCamion.Text = "";
                    ApplyWeighingSettings();
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
                    if (txtId.Text == "" && cbPont.Text == "" && cbFirme.Text == "" && cbCamion.Text == "" && cbChauffeur.Text == "" && cbTransporteur.Text == "" && cbProduit.Text == "" && cbClient.Text == "")
                    {

                        rbxEntrant.Checked = true;
                        TypePesee = "2x1";
                        txtTareCamion.Visible = false;
                        lbTareCamion.Visible = false;
                        ApplyWeighingSettings();

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
                if (txtId.Text == "" && cbPont.Text == "" && cbFirme.Text == "" && cbCamion.Text == "" && cbChauffeur.Text == "" && cbTransporteur.Text == "" && cbProduit.Text == "" && cbClient.Text == "")
                {

                    rbxEntrant.Checked = true;
                    TypePesee = "2x1";
                    txtTareCamion.Visible = false;
                    lbTareCamion.Visible = false;
                    ApplyWeighingSettings();
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
                ApplyWeighingSettings();
            }           
        }

        private void Bind_Fields()
        {
            //Pont 
            Pont pont = new Pont();
            cbPont.DataSource = pont.List("1=1");
            cbPont.DisplayMember = "DESIGNATION";
            cbPont.ValueMember = "PONTID";

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

            DataTable dt = new DataTable();
            PeseePB peseePB = new PeseePB();
            dt = peseePB.FindById(vg_Id);
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["PESEEPBID"];
                txtId.Text = Id.ToString();
                //TypePesee
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
                lbPoidsBrut.Text = row["POIDS1"].ToString();
                lbDateHeurePoidsBrut.Text = row["DATEHEUREPOIDS1"].ToString();
                lbPoidsTare.Text = row["POIDS2"].ToString();
                lbDateHeurePoidsTare.Text = row["DATEHEUREPOIDS2"].ToString();
                lbPoidsNet.Text = row["POIDSNET"].ToString();
                lbStatus.Text = row["ETATPESEE"].ToString();
            }
        }
        private void ApplyWeighingSettings()
        {
            if (EnableCamion == 0)
            {
                cbCamion.Enabled = false;
                RqCamion.Visible = false;
            }
            if (EnableChauffeur == 0)
            {
                cbChauffeur.Enabled = false;
                RqChauffeur.Visible = false;
            }
            if (EnableTransporteur == 0)
            {
                cbTransporteur.Enabled = false;
                RqTransporteur.Visible = false;
            }
            if (EnableProduit == 0)
            {
                cbProduit.Enabled = false;
                RqProduit.Visible = false;
            }
            if (EnableClient == 0)
            {
                cbClient.Enabled = false;
                RqClient.Visible = false;
            }


        }

        private bool check_fields_min()
        {
            bool vl_return;
            if (txtId.Text != "" || cbPont.Text != "" || cbFirme.Text != "" || cbCamion.Text != "" || cbChauffeur.Text != "" || cbTransporteur.Text != "" || cbProduit.Text != "" || cbClient.Text != "")
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
            bool vl_Client;



            if (EnableCamion != 0)
            {
                if (cbCamion.Text != "" && cbCamion.SelectedIndex != -1)
                    vl_Camion = true;
                else
                    vl_Camion = false;
            }
            else
                vl_Camion = true;
            if (EnableChauffeur != 0)
            {
                if (cbChauffeur.Text != "" && cbChauffeur.SelectedIndex != -1)
                    vl_Chauffeur = true;
                else
                    vl_Chauffeur = false;
            }
            else
                vl_Chauffeur = true;
            if (EnableTransporteur != 0)
            {
                if (cbTransporteur.Text != "" && cbTransporteur.SelectedIndex != -1)
                    vl_Transporteur = true;
                else
                    vl_Transporteur = false;
            }
            else
                vl_Transporteur = true;
            if (EnableProduit != 0)
            {
                if (cbProduit.Text != "" && cbProduit.SelectedIndex != -1)
                    vl_Produit = true;
                else
                    vl_Produit = false;
            }
            else
                vl_Produit = true;
            if (EnableClient != 0)
            {
                if (cbClient.Text != "" && cbClient.SelectedIndex != -1)
                    vl_Client = true;
                else
                    vl_Client = false;
            }
            else
                vl_Client = true;

            if (vl_Camion && vl_Chauffeur && vl_Transporteur && vl_Produit && vl_Client)
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
            cbPont.Text = "";
            cbPont.SelectedIndex = -1;
            cbPont.BackColor = Color.Honeydew;
            cbPont.ForeColor = Color.Black;
            btAddPont.Visible = false;
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

            if (txtTareCamion.Visible)
                txtTareCamion.Text = "";
            txtId.Text = "";
            lbPoidsBrut.Text = "";
            lbPoidsTare.Text = "";
            lbPoidsNet.Text = "";
            lbDateHeurePoidsBrut.Text = "";
            lbDateHeurePoidsTare.Text = "";

            Disable_Checked_rbxs_only();
        }

        private void Disable()
        {
            //gbTypePesee.Enabled = false;
            //gbFlux.Enabled = false;
            cbPont.Enabled = false;
            cbFirme.Enabled = false;
            cbCamion.Enabled = false;
            cbChauffeur.Enabled = false;
            cbTransporteur.Enabled = false;
            cbProduit.Enabled = false;
            cbClient.Enabled = false;
            btPeser.Enabled = false;
            if (txtTareCamion.Visible)
                txtTareCamion.Enabled = false;

            vg_IsEnabled = false;
        }

        private void Enable()
        {
            //gbTypePesee.Enabled = true;
            //gbFlux.Enabled = true;
            cbPont.Enabled = true;
            cbFirme.Enabled = true;
            cbCamion.Enabled = true;
            cbChauffeur.Enabled = true;
            cbTransporteur.Enabled = true;
            cbProduit.Enabled = true;
            cbClient.Enabled = true;
            btPeser.Enabled = true;
            if (txtTareCamion.Visible)
                txtTareCamion.Enabled = true;

            vg_IsEnabled = true;
        }

        private void Enable_Checked_rbxs_only()
        {
            if (rb1x.Checked == true)
            {
                rb2x1.Visible = false;
            }
            if (rb2x1.Checked == true)
            {
                rb1x.Visible = false;
            }           
        }

        private void Disable_Checked_rbxs_only()
        {
            rb1x.Visible = true;
            rb2x1.Visible = true;
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
                    txtPoids.ForeColor = Color.FromArgb(112, 228, 132) ;
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

        public void ReceiveSerialData()
        {
            string s;
            byte[] trame = new byte[com.BytesToRead];
            com.Read(trame, 0, trame.Length);
            s = System.Text.Encoding.ASCII.GetString(trame);
            if (s.Length >= LongueurMinChaine)
                txtPoids.Text = filtredataBilancia(s);
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
                        if (IsParsableTare && Tare > 0)
                        {
                            lbPoidsTare.Text = Tare.ToString();
                            DateHeurePoidsTare = DateTime.Now;
                            lbDateHeurePoidsTare.Text = DateHeurePoidsTare.ToString();
                            txtTareCamion.Visible = false;
                            lbTareCamion.Visible = false;

                            PoidsNet = Poids - Tare;
                            lbPoidsNet.Text = PoidsNet.ToString();
                            lbStatus.Text = "Terminée";
                            try
                            {
                                PeseePB peseePB = new PeseePB();
                                peseePB.Add("1x", Flux, Common_functions.CbSelectedValue_Convert_Int(cbPont), Common_functions.CbSelectedValue_Convert_Int(cbFirme), Common_functions.CbSelectedValue_Convert_Int(cbCamion),
                                    Common_functions.CbSelectedValue_Convert_Int(cbChauffeur), Common_functions.CbSelectedValue_Convert_Int(cbTransporteur), Common_functions.CbSelectedValue_Convert_Int(cbProduit),
                                    Common_functions.CbSelectedValue_Convert_Int(cbClient), 0, 0, Poids, DateHeurePoidsBrut, Tare, DateHeurePoidsTare, PoidsNet, "", lbStatus.Text);
                                Refresh_Dgv();
                                Disable();
                                Enable_Checked_rbxs_only();
                                getMaxId();
                                //Details de la pesée et impression
                                if (cbLang.Text == "FR")
                                    Custom_MessageBox.Show("FR", "Pesage Terminé, impression du ticket ...", "Pesée: " + txtId.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else if (cbLang.Text == "EN")
                                    Custom_MessageBox.Show("EN", "Weighing over", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
                                Add_Item_1x();
                            }
                            catch
                            {
                                throw;
                            }

                        }
                        else
                        {
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Le poids tare doit etre supérieur à 0", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (TypePesee == "2x1")
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
                        lbStatus.Text = "En cours";
                        try
                        {
                            if (IsParsableTare)
                            {
                                PeseePB peseePB = new PeseePB();
                                peseePB.Add("2x", Flux, Common_functions.CbSelectedValue_Convert_Int(cbPont), Common_functions.CbSelectedValue_Convert_Int(cbFirme), Common_functions.CbSelectedValue_Convert_Int(cbCamion),
                                    Common_functions.CbSelectedValue_Convert_Int(cbChauffeur), Common_functions.CbSelectedValue_Convert_Int(cbTransporteur), Common_functions.CbSelectedValue_Convert_Int(cbProduit),
                                    Common_functions.CbSelectedValue_Convert_Int(cbClient), 0, 0, 0, DateHeurePoidsTare, Tare, DateHeurePoidsTare, 0, "", lbStatus.Text);
                                Refresh_Dgv();                                
                                Disable();
                                Enable_Checked_rbxs_only();
                                getMaxId();
                                //Details de la pesée et impression
                                if (cbLang.Text == "FR")
                                    Custom_MessageBox.Show("FR", "Pesage Terminé, impression du ticket ...", "Pesée: " + txtId.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else if (cbLang.Text == "EN")
                                    Custom_MessageBox.Show("EN", "Weighing over", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
                                Add_Item_2x1();
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

            if (TypePesee == "2x2")
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
                        PoidsNet = Brut - Tare;
                        lbPoidsNet.Text = PoidsNet.ToString();
                        lbStatus.Text = "Terminée";
                        try
                        {
                            if (IsParsableBrut && IsParsableTare && IsParsableDateHeurePoidsTare)
                            {
                                PeseePB peseePB = new PeseePB();
                                peseePB.Update(vg_Id, "2x", Flux, Common_functions.CbSelectedValue_Convert_Int(cbPont), Common_functions.CbSelectedValue_Convert_Int(cbFirme), Common_functions.CbSelectedValue_Convert_Int(cbCamion),
                                    Common_functions.CbSelectedValue_Convert_Int(cbChauffeur), Common_functions.CbSelectedValue_Convert_Int(cbTransporteur), Common_functions.CbSelectedValue_Convert_Int(cbProduit),
                                    Common_functions.CbSelectedValue_Convert_Int(cbClient), 0, 0, Brut, DateHeurePoidsBrut, Tare, DateHeurePoidsTare, PoidsNet, "", lbStatus.Text);
                                Refresh_Dgv();
                                Disable();
                                Enable_Checked_rbxs_only();
                                if (cbLang.Text == "FR")
                                    Custom_MessageBox.Show("FR", "Pesage Terminé, impression du ticket ...", "Pesée: " + txtId.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else if (cbLang.Text == "EN")
                                    Custom_MessageBox.Show("EN", "Weighing over", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    Custom_MessageBox.Show("ES", "Ningún registro seleccionado", "Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
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

        private void btSimulateur_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Entrez un poids", "Simulateur Poids");
            txtPoids.Text = input;
        }

        private void rbxEntrant_CheckedChanged(object sender, EventArgs e)
        {
            if (rbxEntrant.Checked)
                Flux = "Entrant";
        }

        private void rbxSortant_CheckedChanged(object sender, EventArgs e)
        {
            if (rbxSortant.Checked)
                Flux = "Sortant";
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
                    btAddFirme.Visible = true;
                }
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
                    btAddCamion.Visible = true;
                }
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
                    btAddChauffeur.Visible = true;
                }
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
                    btAddTransporteur.Visible = true;
                }
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
                    btAddProduit.Visible = true;
                }
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
                    btAddClient.Visible = true;
                }
            }
        }

        private void btAddPont_Click(object sender, EventArgs e)
        {
            if (cbPont.Text != "" && cbPont.Text.Trim().Length > 1)
            {
                DialogResult result;
                if (cbLang.Text == "FR")
                    result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir ajouter le pont: " + cbPont.Text + "?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else if (cbLang.Text == "EN")
                    result = Custom_MessageBox.Show("EN", "Are you sure you want to add the weighbridge: " + cbPont.Text + "?", "Weighing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                    result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Pesaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Pont pont = new Pont();
                        pont.Add(cbPont.Text, "1", 0, 0, 1, 9600, 8, "1", "None", 1000);
                        cbPont.DataSource = pont.List("1=1");
                        cbPont.SelectedIndex = cbPont.Items.Count - 1;
                        cbPont.Focus();
                        cbFirme.Focus();
                    }
                    catch
                    {
                        throw;
                    }

                }
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
                        chauffeur.Add("",cbChauffeur.Text,"","","","","","","","",1,0,"",0,"");
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
                        produit.Add(cbProduit.Text, 0, 0,0,1,0,0,0,0,0,0,0);
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
                        client.Add("",cbClient.Text,0,"","","","","","","","","",1,0,"",0,"");
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
                    result = Custom_MessageBox.Show("FR", "ATTENTION, les données non enregistrées seront perdues. Etes vous sur?", "Pesée", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ;
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
                rb2x1.Checked = true;
            }
            
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                //Language_Manager language_Manager = new Language_Manager();
                //language_Manager.ChangeLanguage("fr", this, typeof(TransporteurDetail));
               
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
            Form form = new PontsListe("1=1");
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
    }
}