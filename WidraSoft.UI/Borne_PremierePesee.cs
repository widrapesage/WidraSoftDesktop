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
    public partial class Borne_PremierePesee : Form
    {
        int vg_PontId;
        int WeighingSettingsId;
        int CamionId;
        int ChauffeurId;
        int FirmeId;
        int TransporteurId;
        int ProduitId;
        int ClientId;

        int Enregistrement1Id;
        string Enregistrement1;
        int Tables1Id;
        string Tables1Name; 
        
        int Enregistrement2Id;
        string Enregistrement2;
        int Tables2Id;
        string Tables2Name;

        int Enregistrement3Id;
        string Enregistrement3;
        int Tables3Id;
        string Tables3Name;

        int Enregistrement4Id;
        string Enregistrement4;
        int Tables4Id;
        string Tables4Name;

        int Enregistrement5Id;
        string Enregistrement5;
        int Tables5Id;
        string Tables5Name;

        int Enregistrement6Id;
        string Enregistrement6;
        int Tables6Id;
        string Tables6Name;

        int Enregistrement7Id;
        string Enregistrement7;
        int Tables7Id;
        string Tables7Name;

        bool vg_Demander_Parametre;
        string Etape = "";

        // Weighing Settings Informations
        int EnableCamion;
        int EnableChauffeur;
        int EnableTransporteur;
        int EnableProduit;
        int EnableClient;
        int EnableFirme;
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
        int PontFirme;
        int CamionChauffeur;
        int CamionTransporteur;
        public Borne_PremierePesee(int PontId, bool Demander_Paramatre)
        {
            InitializeComponent();
            vg_PontId = PontId;
            vg_Demander_Parametre = Demander_Paramatre;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Borne_PremierePesee_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            btAjouter.Visible = false;
            France_flag.Visible = true;
            Spain_flag.Visible = false;
            England_flag.Visible = false;
            Etape = "Parametre";
            Gestion_Etapes();
        }

        private void ApplyWeighingSettings(Int32 WeighingSettingsId)
        {
            WeighingSettings weighingSettings = new WeighingSettings();
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

                PontFirme = (int)ro["PONTFIRME"];
                CamionChauffeur = (int)ro["CAMIONCHAUFFEUR"];
                CamionTransporteur = (int)ro["CAMIONTRANSPORTEUR"];

            }
        }

        private void Gestion_Etapes()
        {
            
            if (Etape == "Parametre")
            {
                if (vg_Demander_Parametre)
                {
                    lbTexte.Text = "Choisir le paramètre";
                    WeighingSettings weighingSettings = new WeighingSettings();
                    DataTable dt = new DataTable();
                    dt = weighingSettings.List("1=1");
                    DgvList.DataSource = dt;
                    Bind_WeighingSettings();
                }                           
                else
                {   Pont pont = new Pont();
                    WeighingSettingsId = pont.GetWeighingSettingsId(vg_PontId);
                    Etape = "Firme";
                }

                
            }

            if (Etape == "Firme")
            {
                ApplyWeighingSettings(WeighingSettingsId);
                if (EnableFirme > 0)
                {
                    lbTexte.Text = "Choisir la firme";
                    Firme firme = new Firme();
                    DataTable dt = new DataTable();
                    dt = firme.List("1=1");
                    DgvList.DataSource = dt;
                    Bind_Firmes();
                }
                else
                {
                    FirmeId = 0;
                    Etape = "Camion";
                    Gestion_Etapes();
                }
            }

            if (Etape == "Camion")
            {
                if (EnableCamion > 0)
                {
                    lbTexte.Text = "Choisir le camion";
                    Camion camion = new Camion();
                    DataTable dt = new DataTable();
                    dt = camion.List("1=1");
                    DgvList.DataSource = dt;
                    Bind_Camions();
                }
                else
                {
                    CamionId = 0;
                    Etape = "Chauffeur";
                    Gestion_Etapes();
                }
            }

            if (Etape == "Chauffeur")
            {
                if (EnableChauffeur > 0)
                {
                    lbTexte.Text = "Choisir le chauffeur";
                    Chauffeur chauffeur = new Chauffeur();
                    DataTable dt = new DataTable();
                    dt = chauffeur.List("1=1");
                    DgvList.DataSource = dt;
                    Bind_Chauffeurs();
                }
                else
                {
                    ChauffeurId = 0;
                    Etape = "Transporteur";
                    Gestion_Etapes();
                }
            }

            if (Etape == "Transporteur")
            {
                if (EnableTransporteur > 0)
                {
                    lbTexte.Text = "Choisir le transporteur";
                    Transporteur transporteur = new Transporteur();
                    DataTable dt = new DataTable();
                    dt = transporteur.List("1=1");
                    DgvList.DataSource = dt;
                    Bind_Transporteurs();
                }
                else
                {
                    TransporteurId = 0;
                    Etape = "Produit";
                    Gestion_Etapes();
                }
            }

            if (Etape == "Produit")
            {
                if (EnableProduit > 0)
                {
                    lbTexte.Text = "Choisir le produit";
                    Produit produit = new Produit();
                    DataTable dt = new DataTable();
                    dt = produit.List("1=1");
                    DgvList.DataSource = dt;
                    Bind_Produits();
                }
                else
                {
                    ProduitId = 0;
                    Etape = "Client";
                    Gestion_Etapes();
                }
            }

            if (Etape == "Client")
            {
                if (EnableClient > 0)
                {
                    lbTexte.Text = "Choisir le client";
                    Client client = new Client();
                    DataTable dt = new DataTable();
                    dt = client.List("1=1");
                    DgvList.DataSource = dt;
                    Bind_Clients();
                }
                else
                {
                    ClientId = 0;
                    Etape = "Table1";
                    Gestion_Etapes();
                }
            }

            if (Etape == "Table1")
            {
                if (Table1Id > 0)
                {
                    Tables tables = new Tables();
                    string table_name = tables.GetName(Table1Id);
                    Tables1Name = table_name;
                    Tables1Id = Table1Id;
                    lbTexte.Text = "Choisir " + table_name;
                    Enregistrements enregistrements = new Enregistrements();
                    DataTable dt = new DataTable();
                    dt = enregistrements.FindByTableId(Table1Id);
                    DgvList.DataSource = dt;
                    Bind_Enregistrements();
                }
                else
                {
                    Enregistrement1Id = 0;
                    Tables1Id = 0;
                    Etape = "Table2";
                    Gestion_Etapes();
                }
            }

            if (Etape == "Table2")
            {
                if (Table2Id > 0)
                {
                    Tables tables = new Tables();
                    string table_name = tables.GetName(Table2Id);
                    Tables2Name = table_name;
                    Tables2Id = Table2Id;
                    DataTable dt = new DataTable();
                    if (tables.IsTableRelated(Table2Id) && tables.GetParentTableId(Table2Id) == Tables1Id)
                    {                        
                        lbTexte.Text = "Choisir " + table_name + " De " + Enregistrement1;
                        Enregistrements enregistrements = new Enregistrements();
                       
                        dt = enregistrements.FindByTableIdAndParentId(Table2Id, Enregistrement1Id);

                    }
                    else
                    {
                        lbTexte.Text = "Choisir " + table_name;
                        Enregistrements enregistrements = new Enregistrements();
                        dt = enregistrements.FindByTableId(Table2Id);
                    }
                    


                    DgvList.DataSource = dt;
                    Bind_Enregistrements();
                }
                else
                {
                    Enregistrement2Id = 0;
                    Tables2Id = 0;
                    Etape = "Table3";
                    Gestion_Etapes();
                }
            }

            if (Etape == "Table3")
            {
                if (Table3Id > 0)
                {
                    Tables tables = new Tables();
                    string table_name = tables.GetName(Table3Id);
                    Tables3Name = table_name;
                    Tables3Id = Table3Id;
                    lbTexte.Text = "Choisir " + table_name;
                    Enregistrements enregistrements = new Enregistrements();
                    DataTable dt = new DataTable();
                    dt = enregistrements.FindByTableId(Table3Id);
                    DgvList.DataSource = dt;
                    Bind_Enregistrements();
                }
                else
                {
                    Enregistrement3Id = 0;
                    Tables3Id = 0;
                    Etape = "Table4";
                    Gestion_Etapes();
                }
            }

            if (Etape == "Table4")
            {
                if (Table4Id > 0)
                {
                    Tables tables = new Tables();
                    string table_name = tables.GetName(Table4Id);
                    Tables4Name = table_name;
                    Tables4Id = Table4Id;
                    lbTexte.Text = "Choisir " + table_name;
                    Enregistrements enregistrements = new Enregistrements();
                    DataTable dt = new DataTable();
                    dt = enregistrements.FindByTableId(Table4Id);
                    DgvList.DataSource = dt;
                    Bind_Enregistrements();
                }
                else
                {
                    Enregistrement4Id = 0;
                    Tables4Id = 0;
                    Etape = "Table5";
                    Gestion_Etapes();
                }
            }

            if (Etape == "Table5")
            {
                if (Table5Id > 0)
                {
                    Tables tables = new Tables();
                    string table_name = tables.GetName(Table5Id);
                    Tables5Name = table_name;
                    Tables5Id = Table5Id;
                    lbTexte.Text = "Choisir " + table_name;
                    Enregistrements enregistrements = new Enregistrements();
                    DataTable dt = new DataTable();
                    dt = enregistrements.FindByTableId(Table5Id);
                    DgvList.DataSource = dt;
                    Bind_Enregistrements();
                }
                else
                {
                    Enregistrement5Id = 0;
                    Tables5Id = 0;
                    Etape = "Table6";
                    Gestion_Etapes();
                }
            }

            if (Etape == "Table6")
            {
                if (Table6Id > 0)
                {
                    Tables tables = new Tables();
                    string table_name = tables.GetName(Table6Id);
                    Tables6Name = table_name;
                    Tables6Id = Table6Id;
                    lbTexte.Text = "Choisir " + table_name;
                    Enregistrements enregistrements = new Enregistrements();
                    DataTable dt = new DataTable();
                    dt = enregistrements.FindByTableId(Table6Id);
                    DgvList.DataSource = dt;
                    Bind_Enregistrements();
                }
                else
                {
                    Enregistrement6Id = 0;
                    Tables6Id = 0;
                    Etape = "Table7";
                    Gestion_Etapes();
                }
            }

            if (Etape == "Table7")
            {
                if (Table7Id > 0)
                {
                    Tables tables = new Tables();
                    string table_name = tables.GetName(Table7Id);
                    Tables7Name = table_name;
                    Tables7Id = Table7Id;
                    lbTexte.Text = "Choisir " + table_name;
                    Enregistrements enregistrements = new Enregistrements();
                    DataTable dt = new DataTable();
                    dt = enregistrements.FindByTableId(Table7Id);
                    DgvList.DataSource = dt;
                    Bind_Enregistrements();
                }
                else
                {
                    Close();
                }
            }

        }

        private void Bind_WeighingSettings()
        {
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["DESIGNATION"].Visible = true;
            DgvList.Columns["CAMION"].Visible = false;
            DgvList.Columns["CHAUFFEUR"].Visible = false;
            DgvList.Columns["TRANSPORTEUR"].Visible = false;
            DgvList.Columns["PRODUIT"].Visible = false;
            DgvList.Columns["CLIENT"].Visible = false;
            DgvList.Columns["FIRME"].Visible = false;
            DgvList.Columns["CAMION_OBL"].Visible = false;
            DgvList.Columns["CHAUFFEUR_OBL"].Visible = false;
            DgvList.Columns["TRANSPORTEUR_OBL"].Visible = false;
            DgvList.Columns["PRODUIT_OBL"].Visible = false;
            DgvList.Columns["CLIENT_OBL"].Visible = false;
            DgvList.Columns["FIRME_OBL"].Visible = false;
            DgvList.Columns["CAMION_BORNE"].Visible = false;
            DgvList.Columns["CHAUFFEUR_BORNE"].Visible = false;
            DgvList.Columns["TRANSPORTEUR_BORNE"].Visible = false;
            DgvList.Columns["PRODUIT_BORNE"].Visible = false;
            DgvList.Columns["CLIENT_BORNE"].Visible = false;
            DgvList.Columns["FIRME_BORNE"].Visible = false;
            DgvList.Columns["CAMION_AJOUT_F"].Visible = false;
            DgvList.Columns["CHAUFFEUR_AJOUT_F"].Visible = false;
            DgvList.Columns["TRANSPORTEUR_AJOUT_F"].Visible = false;
            DgvList.Columns["PRODUIT_AJOUT_F"].Visible = false;
            DgvList.Columns["CLIENT_AJOUT_F"].Visible = false;
            DgvList.Columns["FIRME_AJOUT_F"].Visible = false;
            DgvList.Columns["TABLE1_ID"].Visible = false;
            DgvList.Columns["TABLE2_ID"].Visible = false;
            DgvList.Columns["TABLE3_ID"].Visible = false;
            DgvList.Columns["TABLE4_ID"].Visible = false;
            DgvList.Columns["TABLE5_ID"].Visible = false;
            DgvList.Columns["TABLE6_ID"].Visible = false;
            DgvList.Columns["TABLE7_ID"].Visible = false;
            DgvList.Columns["TABLE1_OBL"].Visible = false;
            DgvList.Columns["TABLE2_OBL"].Visible = false;
            DgvList.Columns["TABLE3_OBL"].Visible = false;
            DgvList.Columns["TABLE4_OBL"].Visible = false;
            DgvList.Columns["TABLE5_OBL"].Visible = false;
            DgvList.Columns["TABLE6_OBL"].Visible = false;
            DgvList.Columns["TABLE7_OBL"].Visible = false;
            DgvList.Columns["TABLE1_CODE"].Visible = false;
            DgvList.Columns["TABLE2_CODE"].Visible = false;
            DgvList.Columns["TABLE3_CODE"].Visible = false;
            DgvList.Columns["TABLE4_CODE"].Visible = false;
            DgvList.Columns["TABLE5_CODE"].Visible = false;
            DgvList.Columns["TABLE6_CODE"].Visible = false;
            DgvList.Columns["TABLE7_CODE"].Visible = false;
            DgvList.Columns["TABLE1_BORNE"].Visible = false;
            DgvList.Columns["TABLE2_BORNE"].Visible = false;
            DgvList.Columns["TABLE3_BORNE"].Visible = false;
            DgvList.Columns["TABLE4_BORNE"].Visible = false;
            DgvList.Columns["TABLE5_BORNE"].Visible = false;
            DgvList.Columns["TABLE6_BORNE"].Visible = false;
            DgvList.Columns["TABLE7_BORNE"].Visible = false;
            DgvList.Columns["TABLE1_TICKET"].Visible = false;
            DgvList.Columns["TABLE2_TICKET"].Visible = false;
            DgvList.Columns["TABLE3_TICKET"].Visible = false;
            DgvList.Columns["TABLE4_TICKET"].Visible = false;
            DgvList.Columns["TABLE5_TICKET"].Visible = false;
            DgvList.Columns["TABLE6_TICKET"].Visible = false;
            DgvList.Columns["TABLE7_TICKET"].Visible = false;
            DgvList.Columns["TABLE1_AJOUT_F"].Visible = false;
            DgvList.Columns["TABLE2_AJOUT_F"].Visible = false;
            DgvList.Columns["TABLE3_AJOUT_F"].Visible = false;
            DgvList.Columns["TABLE4_AJOUT_F"].Visible = false;
            DgvList.Columns["TABLE5_AJOUT_F"].Visible = false;
            DgvList.Columns["TABLE6_AJOUT_F"].Visible = false;
            DgvList.Columns["TABLE7_AJOUT_F"].Visible = false;
            DgvList.Columns["PONTFIRME"].Visible = false;
            DgvList.Columns["CAMIONCHAUFFEUR"].Visible = false;
            DgvList.Columns["CAMIONTRANSPORTEUR"].Visible = false;
            DgvList.Columns["FORMAT"].Visible = false;
            DgvList.Columns["TITRE1"].Visible = false;
            DgvList.Columns["TITRE2"].Visible = false;
            DgvList.Columns["FOOTER"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = false;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;
        }

        private void Bind_Firmes()
        {
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["BADGE"].Visible = false;
            DgvList.Columns["DESIGNATION"].Visible = true;
            DgvList.Columns["ADRESSE"].Visible = false;
            DgvList.Columns["CODEPOSTAL"].Visible = false;
            DgvList.Columns["CODEPOSTAL"].HeaderText = "CODE POSTAL";
            DgvList.Columns["LOCALITE"].Visible = false;
            DgvList.Columns["PAYS"].Visible = false;
            DgvList.Columns["TELEPHONE"].Visible = false;
            DgvList.Columns["EMAIL"].Visible = false;
            DgvList.Columns["NUMTVA"].Visible = false;
            DgvList.Columns["SITEWEB_URL"].Visible = false;
            DgvList.Columns["OBSERVATIONS"].Visible = false;
            DgvList.Columns["VALIDE"].Visible = false;
            DgvList.Columns["BLOQUE"].Visible = false;
            DgvList.Columns["TEXTEBLOQUE"].Visible = false;
            DgvList.Columns["ATTENTION"].Visible = false;
            DgvList.Columns["TEXTEATTENTION"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = false;
            DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;

        }

        private void Bind_Camions()
        {
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["CODE"].Visible = false;
            DgvList.Columns["PLAQUE"].Visible = true;
            DgvList.Columns["BADGE"].Visible = false;
            DgvList.Columns["TARE"].Visible = false;
            DgvList.Columns["TARE"].HeaderText = "TARE (KG)";
            DgvList.Columns["VALIDE"].Visible = false;
            DgvList.Columns["BLOQUE"].Visible = false;
            DgvList.Columns["TEXTEBLOQUE"].Visible = false;
            DgvList.Columns["ATTENTION"].Visible = false;
            DgvList.Columns["TEXTEATTENTION"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = false;
            DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            DgvList.Columns["OBSERVATIONS"].Visible = false;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;
        }

        private void Bind_Chauffeurs()
        {
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["BADGE"].Visible = false;
            DgvList.Columns["NOM"].Visible = true;
            DgvList.Columns["NUMERONATIONAL"].Visible = false;
            DgvList.Columns["NUMEROPERMIS"].Visible = false;
            DgvList.Columns["ADRESSE"].Visible = false;
            DgvList.Columns["CODEPOSTAL"].Visible = false;
            DgvList.Columns["LOCALITE"].Visible = false;
            DgvList.Columns["PAYS"].Visible = false;
            DgvList.Columns["TELEPHONE"].Visible = false;
            DgvList.Columns["OBSERVATIONS"].Visible = false;
            DgvList.Columns["VALIDE"].Visible = false;
            DgvList.Columns["BLOQUE"].Visible = false;
            DgvList.Columns["TEXTEBLOQUE"].Visible = false;
            DgvList.Columns["ATTENTION"].Visible = false;
            DgvList.Columns["TEXTEATTENTION"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = false;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;

        }

        private void Bind_Transporteurs()
        {
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["LICENCE"].Visible = false;
            DgvList.Columns["NOM"].Visible = true;
            DgvList.Columns["ADRESSE"].Visible = false;
            DgvList.Columns["CODEPOSTAL"].Visible = false;
            DgvList.Columns["LOCALITE"].Visible = false;
            DgvList.Columns["PAYS"].Visible = false;
            DgvList.Columns["TELEPHONE"].Visible = false;
            DgvList.Columns["EMAIL"].Visible = false;
            DgvList.Columns["NUMTVA"].Visible = false;
            DgvList.Columns["SITEWEB_URL"].Visible = false;
            DgvList.Columns["OBSERVATIONS"].Visible = false;
            DgvList.Columns["VALIDE"].Visible = false;
            DgvList.Columns["BLOQUE"].Visible = false;
            DgvList.Columns["TEXTEBLOQUE"].Visible = false;
            DgvList.Columns["ATTENTION"].Visible = false;
            DgvList.Columns["TEXTEATTENTION"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = false;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;

        }


        private void Bind_Produits()
        {
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["DESIGNATION"].Visible = true;
            DgvList.Columns["GROUPEPRODUITID"].Visible = false;
            DgvList.Columns["ESTENTRANT"].Visible = false;
            DgvList.Columns["ESTSORTANT"].Visible = false;
            DgvList.Columns["VALIDE"].Visible = false;
            DgvList.Columns["POIDSALERTEMIN"].Visible = false;
            DgvList.Columns["ACTIVERALERTEMIN"].Visible = false;
            DgvList.Columns["POIDSALERTEMAX"].Visible = false;
            DgvList.Columns["ACTIVERALERTEMAX"].Visible = false;
            DgvList.Columns["EMPECHERTICKETSIALERTE"].Visible = false;
            DgvList.Columns["DECHET"].Visible = false;
            DgvList.Columns["TYPEDECHETID"].Visible = false;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;
        }

        private void Bind_Clients()
        {
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["BADGE"].Visible = false;
            DgvList.Columns["DESIGNATION"].Visible = true;
            DgvList.Columns["TYPECLIENTID"].Visible = false;
            DgvList.Columns["ADRESSE"].Visible = false;
            DgvList.Columns["CODEPOSTAL"].Visible = false;
            DgvList.Columns["CODEPOSTAL"].HeaderText = "CODE POSTAL";
            DgvList.Columns["LOCALITE"].Visible = false;
            DgvList.Columns["PAYS"].Visible = false;
            DgvList.Columns["TELEPHONE"].Visible = false;
            DgvList.Columns["EMAIL"].Visible = false;
            DgvList.Columns["NUMTVA"].Visible = false;
            DgvList.Columns["SITEWEB_URL"].Visible = false;
            DgvList.Columns["OBSERVATIONS"].Visible = false;
            DgvList.Columns["VALIDE"].Visible = false;
            DgvList.Columns["BLOQUE"].Visible = false;
            DgvList.Columns["TEXTEBLOQUE"].Visible = false;
            DgvList.Columns["ATTENTION"].Visible = false;
            DgvList.Columns["TEXTEATTENTION"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = false;
            DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;

        }

        private void Bind_Enregistrements()
        {
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["TABLESID"].Visible = false;
            DgvList.Columns["NOM"].Visible = true;
            DgvList.Columns["CODE"].Visible = false;
            DgvList.Columns["ADRESSE"].Visible = false;
            DgvList.Columns["CODEPOSTAL"].Visible = false;
            DgvList.Columns["LOCALITE"].Visible = false;
            DgvList.Columns["PAYS"].Visible = false;
            DgvList.Columns["TELEPHONE"].Visible = false;
            DgvList.Columns["EMAIL"].Visible = false;
            DgvList.Columns["NUMTVA"].Visible = false;
            DgvList.Columns["SITEWEB_URL"].Visible = false;
            DgvList.Columns["OBSERVATIONS"].Visible = false;
            DgvList.Columns["BLOQUE"].Visible = false;
            DgvList.Columns["TEXTEBLOQUE"].Visible = false;
            DgvList.Columns["ATTENTION"].Visible = false;
            DgvList.Columns["TEXTEATTENTION"].Visible = false;
            DgvList.Columns["PARENTID"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = false;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;

        }

        private void btValider_Click(object sender, EventArgs e)
        {
            if (Etape == "Parametre")
            {
                WeighingSettingsId = Common_functions.GetDatagridViewSelectedId(DgvList);
                Etape = "Firme";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Firme")
            {
                FirmeId = Common_functions.GetDatagridViewSelectedId(DgvList);
                Etape = "Camion";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Camion")
            {
                CamionId = Common_functions.GetDatagridViewSelectedId(DgvList);
                Etape = "Chauffeur";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Chauffeur")
            {
                ChauffeurId = Common_functions.GetDatagridViewSelectedId(DgvList);
                Etape = "Transporteur";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Transporteur")
            {
                TransporteurId = Common_functions.GetDatagridViewSelectedId(DgvList);
                Etape = "Produit";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Produit")
            {
                ProduitId = Common_functions.GetDatagridViewSelectedId(DgvList);
                Etape = "Client";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Client")
            {
                ClientId = Common_functions.GetDatagridViewSelectedId(DgvList);
                Etape = "Table1";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table1")
            {
                Enregistrements enregistrements = new Enregistrements();

                Enregistrement1Id = Common_functions.GetDatagridViewSelectedId(DgvList);
                Enregistrement1 = enregistrements.GetName(Enregistrement1Id);
                Etape = "Table2";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table2")
            {
                Enregistrements enregistrements = new Enregistrements();

                Enregistrement2Id = Common_functions.GetDatagridViewSelectedId(DgvList);
                Enregistrement2 = enregistrements.GetName(Enregistrement2Id);
                Etape = "Table3";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table3")
            {
                Enregistrements enregistrements = new Enregistrements();

                Enregistrement3Id = Common_functions.GetDatagridViewSelectedId(DgvList);
                Enregistrement3 = enregistrements.GetName(Enregistrement3Id);
                Etape = "Table4";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table4")
            {
                Enregistrements enregistrements = new Enregistrements();

                Enregistrement4Id = Common_functions.GetDatagridViewSelectedId(DgvList);
                Enregistrement4 = enregistrements.GetName(Enregistrement4Id);
                Etape = "Table5";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table5")
            {
                Enregistrements enregistrements = new Enregistrements();

                Enregistrement5Id = Common_functions.GetDatagridViewSelectedId(DgvList);
                Enregistrement5 = enregistrements.GetName(Enregistrement5Id);
                Etape = "Table6";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table6")
            {
                Enregistrements enregistrements = new Enregistrements();

                Enregistrement6Id = Common_functions.GetDatagridViewSelectedId(DgvList);
                Enregistrement6 = enregistrements.GetName(Enregistrement6Id);
                Etape = "Table7";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table7")
            {
                Enregistrements enregistrements = new Enregistrements();

                Enregistrement7Id = Common_functions.GetDatagridViewSelectedId(DgvList);
                Enregistrement7 = enregistrements.GetName(Enregistrement7Id);
                Etape = "Fin";
                Close();
            }
        }

        private void btAnnuler_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
