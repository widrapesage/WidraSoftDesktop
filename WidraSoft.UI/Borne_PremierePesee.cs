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
using WidraSoft.DA;

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
        int WalterreId;
        int vg_ScanCamionId;
        int vg_ScanChauffeurId;
        int vg_ScanClientId;
        int vg_CamionChauffeurId;
        int vg_CamionTransporteurId;
        int vg_ScanWalterreId;
        string vg_Flux;
        int vg_P;
        string vg_Lang;
        int vg_Tare;

        int Enregistrement1Id;
        string Enregistrement1 = "";
        int Tables1Id;
        string Tables1Name = "";

        int Enregistrement2Id;
        string Enregistrement2 = "";
        int Tables2Id;
        string Tables2Name = "";

        int Enregistrement3Id;
        string Enregistrement3 = "";
        int Tables3Id;
        string Tables3Name = "";

        int Enregistrement4Id;
        string Enregistrement4 = "";
        int Tables4Id;
        string Tables4Name = "";

        int Enregistrement5Id;
        string Enregistrement5 = "";
        int Tables5Id;
        string Tables5Name = "";

        int Enregistrement6Id;
        string Enregistrement6 = "";
        int Tables6Id;
        string Tables6Name = "";

        int Enregistrement7Id;
        string Enregistrement7 = "";
        int Tables7Id;
        string Tables7Name = "";

        string ChampLibreName1;
        string ChampLibre1;

        string ChampLibreName2;
        string ChampLibre2;


        string ChampLibreName3;
        string ChampLibre3;

        string ChampLibreName4;
        string ChampLibre4;

        bool vg_Demander_Parametre;
        bool vg_ChampLibre;
        string Etape = "";

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

        bool IsNumeric = false;
        public Borne_PremierePesee(string Lang, int PontId, bool Demander_Paramatre, string Flux, int ScanCamionId, int P, int Tare, int ScanChauffeurId, int ScanClientId, int ScanWalterreId)
        {
            InitializeComponent();
            vg_PontId = PontId;
            vg_Demander_Parametre = Demander_Paramatre;
            vg_ScanCamionId = ScanCamionId;
            vg_Flux = Flux;
            vg_P = P;
            vg_Lang = Lang;
            vg_Tare = Tare;
            vg_ScanClientId = ScanClientId;
            vg_ScanChauffeurId = ScanChauffeurId;
            vg_ScanWalterreId = ScanWalterreId;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Borne_PremierePesee_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            WindowState = FormWindowState.Maximized;

            this.TopMost = true;

            if (vg_Lang == "fr")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(Borne_PremierePesee));
            }

            if (vg_Lang == "en")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(Borne_PremierePesee));
            }

            if (vg_Lang == "es")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(Borne_PremierePesee));
            }


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
        }

        private void Init_Keyboard()
        {
            panelClavier.Visible = false;
            lbMessage.Text = "";
            //lbMessage.Visible = false;
            btRecherche.Text = Language_Manager.Localize("AFFICHER CLAVIER", vg_Lang);
            btAjouter.Visible = false;
            btAnnulerRecherche.Visible = false;
            btIgnorer.Visible = false;
            lbNotFound.Visible = false;
            lbRequired.Visible = false;
            lbOptional.Visible = false;
            lbInvalide.Visible = false;
            IsNumeric = false;
        }

        private void Gestion_Etapes()
        {
            Init_Keyboard();
            vg_ChampLibre = false;

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
                    Gestion_Navigation("Parametre");
                }
                else
                {
                    Pont pont = new Pont();
                    WeighingSettingsId = pont.GetWeighingSettingsId(vg_PontId);
                    Etape = "Camion";
                    Gestion_Etapes();
                }

                return;
            }

            if (Etape == "Camion")
            {
                ApplyWeighingSettings(WeighingSettingsId);
                if (vg_ScanCamionId <= 0)
                {
                    if (EnableCamion > 0)
                    {
                        lbTexte.Text = "Entrez la plaque du camion";
                        /*Camion camion = new Camion();
                        DataTable dt = new DataTable();
                        dt = camion.List("1=1");
                        DgvList.DataSource = dt;
                        Bind_Camions();*/
                        if (Camion_Obl > 0)
                        {
                            btIgnorer.Visible = false;
                            lbRequired.Visible = true;
                        }
                        else
                        {
                            btIgnorer.Visible = true;
                            lbOptional.Visible = true;
                        }
                        Gestion_Navigation("Camion");
                    }
                    else
                    {
                        CamionId = 0;
                        Etape = "Firme";
                        Gestion_Etapes();
                    }
                }
                else
                {
                    CamionId = vg_ScanCamionId;
                    vg_CamionChauffeurId = 0;
                    vg_CamionTransporteurId = 0;
                    CamionChauffeur camionChauffeur = new CamionChauffeur();
                    CamionTransporteur camionTransporteur = new CamionTransporteur();
                    if (CamionChauffeur > 0)
                    {
                        if (camionChauffeur.CountByCamionId(CamionId) > 0)
                        {
                            if (camionChauffeur.CountByCamionId(CamionId) == 1)
                                vg_CamionChauffeurId = camionChauffeur.GetFirstChauffeurByCamionId(CamionId);
                            else
                                vg_CamionChauffeurId = -1000;
                        }
                        else
                        {
                            vg_CamionChauffeurId = 0;
                        }
                    }
                    if (CamionTransporteur > 0)
                    {
                        if (camionTransporteur.CountByCamionId(CamionId) > 0)
                        {
                            if (camionTransporteur.CountByCamionId(CamionId) == 1)
                                vg_CamionTransporteurId = camionTransporteur.GetFirstTransporteurByCamionId(CamionId);
                            else
                                vg_CamionTransporteurId = -1000;
                        }
                        else
                        {
                            vg_CamionTransporteurId = 0;
                        }
                    }

                    Etape = "Firme";
                    Gestion_Etapes();


                }

                return;
            }

            if (Etape == "Firme")
            {

                if (EnableFirme > 0)
                {
                    lbTexte.Text = "Choisir la firme";
                    Firme firme = new Firme();
                    DataTable dt = new DataTable();
                    dt = firme.List("1=1");
                    DgvList.DataSource = dt;
                    Bind_Firmes();
                    if (Firme_Obl > 0)
                    {
                        btIgnorer.Visible = false;
                        lbRequired.Visible = true;
                    }
                    else
                    {
                        btIgnorer.Visible = true;
                        lbOptional.Visible = true;
                    }
                    Gestion_Navigation("Firme");
                }
                else
                {
                    FirmeId = 0;
                    Etape = "Chauffeur";
                    Gestion_Etapes();
                }

                return;
            }

            if (Etape == "Chauffeur")
            {
                if (vg_ScanChauffeurId <= 0)
                {
                    if (EnableChauffeur > 0)
                    {
                        if (vg_CamionChauffeurId > 0)
                        {
                            ChauffeurId = vg_CamionChauffeurId;
                            Etape = "Transporteur";
                            Gestion_Etapes();
                        }
                        else
                        {
                            lbTexte.Text = "Choisir le chauffeur";
                            Chauffeur chauffeur = new Chauffeur();
                            CamionChauffeur camionChauffeur = new CamionChauffeur();
                            DataTable dt = new DataTable();
                            if (vg_CamionChauffeurId == -1000)
                            {
                                dt = camionChauffeur.FindByCamionId(CamionId);
                                DgvList.DataSource = dt;
                                Bind_CamionChauffeurs();
                            }
                            else
                            {
                                dt = chauffeur.List("1=1");
                                DgvList.DataSource = dt;
                                Bind_Chauffeurs();
                            }

                            if (Chauffeur_Obl > 0)
                            {
                                btIgnorer.Visible = false;
                                lbRequired.Visible = true;
                            }
                            else
                            {
                                btIgnorer.Visible = true;
                                lbOptional.Visible = true;
                            }
                            Gestion_Navigation("Chauffeur");
                        }
                    }
                    else
                    {
                        ChauffeurId = 0;
                        Etape = "Transporteur";
                        Gestion_Etapes();
                    }


                }
                else
                {
                    ChauffeurId = vg_ScanChauffeurId;
                    Etape = "Transporteur";
                    Gestion_Etapes();
                }
                return;
            }

            if (Etape == "Transporteur")
            {
                if (EnableTransporteur > 0)
                {
                    if (vg_CamionTransporteurId > 0)
                    {
                        TransporteurId = vg_CamionTransporteurId;
                        Etape = "Walterre";
                        Gestion_Etapes();
                    }
                    else
                    {
                        lbTexte.Text = "Choisir le transporteur";
                        Transporteur transporteur = new Transporteur();
                        CamionTransporteur camionTransporteur = new CamionTransporteur();
                        DataTable dt = new DataTable();
                        if (vg_CamionTransporteurId == -1000)
                        {
                            dt = camionTransporteur.FindByCamionId(CamionId);
                            DgvList.DataSource = dt;
                            Bind_CamionTransporteurs();
                        }
                        else
                        {
                            dt = transporteur.List("1=1");
                            DgvList.DataSource = dt;
                            Bind_Transporteurs();
                        }

                        if (Transporteur_Obl > 0)
                        {
                            btIgnorer.Visible = false;
                            lbRequired.Visible = true;
                        }
                        else
                        {
                            btIgnorer.Visible = true;
                            lbOptional.Visible = true;
                        }
                        Gestion_Navigation("Transporteur");
                    }

                }
                else
                {
                    TransporteurId = 0;
                    Etape = "Walterre";
                    Gestion_Etapes();

                }

                return;
            }

            if (Etape == "Walterre")
            {

                if (EnableWalterre > 0)
                {
                    if (vg_ScanWalterreId > 0)
                    {
                        WalterreId = vg_ScanWalterreId;
                        Etape = "Produit";
                        Gestion_Etapes();
                    }
                    else
                    {
                        lbTexte.Text = "Entrez le code Walterre";
                        /*Walterre walterre = new Walterre();
                        DataTable dt = new DataTable();
                        dt = walterre.List("1=1");
                        DgvList.DataSource = dt;
                        Bind_Walterre();*/
                        btIgnorer.Visible = false;
                        lbRequired.Visible = true;
                        Gestion_Navigation("Walterre");
                    }
                    
                }
                else
                {
                    WalterreId = 0;
                    Etape = "Produit";
                    Gestion_Etapes();
                }

                return;
            }

            if (Etape == "Produit")
            {
                if (EnableProduit > 0)
                {
                    int WalterreProduitId = 0;
                    if (EnableWalterre > 0 && WalterreId > 0)
                    {
                        Walterre walterre = new Walterre();
                        DataTable dtw = new DataTable();
                        dtw = walterre.FindById(WalterreId);
                        foreach (DataRow row in dtw.Rows)
                        {
                            if (row["PRODUITID"] is System.DBNull)
                                WalterreProduitId = 0;
                            else
                                WalterreProduitId = (int)row["PRODUITID"];
                        }
                    }

                    if (WalterreProduitId > 0)
                    {
                        ProduitId = WalterreProduitId;
                        Etape = "Client";
                        Gestion_Etapes();
                    }
                    else
                    {
                        lbTexte.Text = "Choisir le produit";
                        Produit produit = new Produit();
                        DataTable dt = new DataTable();
                        dt = produit.List("1=1");
                        DgvList.DataSource = dt;
                        Bind_Produits();
                        if (Produit_Obl > 0)
                        {
                            btIgnorer.Visible = false;
                            lbRequired.Visible = true;
                        }
                        else
                        {
                            btIgnorer.Visible = true;
                            lbOptional.Visible = true;
                        }
                        Gestion_Navigation("Produit");
                    }
                }
                else
                {
                    ProduitId = 0;
                    Etape = "Client";
                    Gestion_Etapes();
                }

                return;
            }

            if (Etape == "Client")
            {
                if (vg_ScanClientId <= 0)
                {
                    if (EnableClient > 0)
                    {
                        int WalterreClientId = 0;
                        if (EnableWalterre > 0 && WalterreId > 0)
                        {
                            Walterre walterre = new Walterre();
                            DataTable dtw = new DataTable();
                            dtw = walterre.FindById(WalterreId);
                            foreach (DataRow row in dtw.Rows)
                            {
                                if (row["CLIENTID"] is System.DBNull)
                                    WalterreClientId = 0;
                                else
                                    WalterreClientId = (int)row["CLIENTID"];
                            }
                        }

                        if (WalterreClientId > 0)
                        {
                            ClientId = WalterreClientId;
                            Etape = "Table1";
                            Gestion_Etapes();
                        }
                        else
                        {
                            lbTexte.Text = "Choisir le client";
                            Client client = new Client();
                            DataTable dt = new DataTable();
                            dt = client.List("1=1");
                            DgvList.DataSource = dt;
                            Bind_Clients();
                            if (Client_Obl > 0)
                            {
                                btIgnorer.Visible = false;
                                lbRequired.Visible = true;
                            }
                            else
                            {
                                btIgnorer.Visible = true;
                                lbOptional.Visible = true;
                            }
                            Gestion_Navigation("Client");
                        }
                    }
                    else
                    {
                        ClientId = 0;
                        Etape = "Table1";
                        Gestion_Etapes();
                    }

                }
                else
                {
                    ClientId = vg_ScanClientId;
                    Etape = "Table1";
                    Gestion_Etapes();
                }
                return;
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
                    if (Table1_Obl > 0)
                    {
                        btIgnorer.Visible = false;
                        lbRequired.Visible = true;
                    }
                    else
                    {
                        btIgnorer.Visible = true;
                        lbOptional.Visible = true;
                    }
                    Gestion_Navigation("Table1");
                }
                else
                {
                    Enregistrement1Id = 0;
                    Tables1Id = 0;
                    Etape = "Table2";
                    Gestion_Etapes();
                }

                return;
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
                    if (Table2_Obl > 0)
                    {
                        btIgnorer.Visible = false;
                        lbRequired.Visible = true;
                    }
                    else
                    {
                        btIgnorer.Visible = true;
                        lbOptional.Visible = true;
                    }
                    Gestion_Navigation("Table2");
                }
                else
                {
                    Enregistrement2Id = 0;
                    Tables2Id = 0;
                    Etape = "Table3";
                    Gestion_Etapes();
                }

                return;
            }

            if (Etape == "Table3")
            {
                if (Table3Id > 0)
                {
                    Tables tables = new Tables();
                    string table_name = tables.GetName(Table3Id);
                    Tables3Name = table_name;
                    Tables3Id = Table3Id;
                    DataTable dt = new DataTable();
                    if (tables.IsTableRelated(Table3Id) && tables.GetParentTableId(Table3Id) == Tables2Id)
                    {
                        lbTexte.Text = "Choisir " + table_name + " De " + Enregistrement2;
                        Enregistrements enregistrements = new Enregistrements();
                        dt = enregistrements.FindByTableIdAndParentId(Table3Id, Enregistrement2Id);

                    }
                    else
                    {
                        lbTexte.Text = "Choisir " + table_name;
                        Enregistrements enregistrements = new Enregistrements();
                        dt = enregistrements.FindByTableId(Table3Id);
                    }
                    DgvList.DataSource = dt;
                    Bind_Enregistrements();
                    if (Table3_Obl > 0)
                    {
                        btIgnorer.Visible = false;
                        lbRequired.Visible = true;
                    }
                    else
                    {
                        btIgnorer.Visible = true;
                        lbOptional.Visible = true;
                    }
                    Gestion_Navigation("Table3");
                }
                else
                {
                    Enregistrement3Id = 0;
                    Tables3Id = 0;
                    Etape = "Table4";
                    Gestion_Etapes();
                }

                return;
            }

            if (Etape == "Table4")
            {
                if (Table4Id > 0)
                {
                    Tables tables = new Tables();
                    string table_name = tables.GetName(Table4Id);
                    Tables4Name = table_name;
                    Tables4Id = Table4Id;
                    DataTable dt = new DataTable();
                    if (tables.IsTableRelated(Table4Id) && tables.GetParentTableId(Table4Id) == Tables3Id)
                    {
                        lbTexte.Text = "Choisir " + table_name + " De " + Enregistrement3;
                        Enregistrements enregistrements = new Enregistrements();
                        dt = enregistrements.FindByTableIdAndParentId(Table4Id, Enregistrement3Id);

                    }
                    else
                    {
                        lbTexte.Text = "Choisir " + table_name;
                        Enregistrements enregistrements = new Enregistrements();
                        dt = enregistrements.FindByTableId(Table4Id);
                    }
                    DgvList.DataSource = dt;
                    Bind_Enregistrements();
                    if (Table4_Obl > 0)
                    {
                        btIgnorer.Visible = false;
                        lbRequired.Visible = true;
                    }
                    else
                    {
                        btIgnorer.Visible = true;
                        lbOptional.Visible = true;
                    }
                    Gestion_Navigation("Table4");
                }
                else
                {
                    Enregistrement4Id = 0;
                    Tables4Id = 0;
                    Etape = "Table5";
                    Gestion_Etapes();
                }

                return;
            }

            if (Etape == "Table5")
            {
                if (Table5Id > 0)
                {
                    Tables tables = new Tables();
                    string table_name = tables.GetName(Table5Id);
                    Tables5Name = table_name;
                    Tables5Id = Table5Id;
                    DataTable dt = new DataTable();
                    if (tables.IsTableRelated(Table5Id) && tables.GetParentTableId(Table5Id) == Tables4Id)
                    {
                        lbTexte.Text = "Choisir " + table_name + " De " + Enregistrement4;
                        Enregistrements enregistrements = new Enregistrements();
                        dt = enregistrements.FindByTableIdAndParentId(Table5Id, Enregistrement4Id);
                    }
                    else
                    {
                        lbTexte.Text = "Choisir " + table_name;
                        Enregistrements enregistrements = new Enregistrements();
                        dt = enregistrements.FindByTableId(Table5Id);
                    }
                    DgvList.DataSource = dt;
                    Bind_Enregistrements();
                    if (Table5_Obl > 0)
                    {
                        btIgnorer.Visible = false;
                        lbRequired.Visible = true;
                    }
                    else
                    {
                        btIgnorer.Visible = true;
                        lbOptional.Visible = true;
                    }
                    Gestion_Navigation("Table5");
                }
                else
                {
                    Enregistrement5Id = 0;
                    Tables5Id = 0;
                    Etape = "Table6";
                    Gestion_Etapes();
                }

                return;
            }

            if (Etape == "Table6")
            {
                if (Table6Id > 0)
                {
                    Tables tables = new Tables();
                    string table_name = tables.GetName(Table6Id);
                    Tables6Name = table_name;
                    Tables6Id = Table6Id;
                    DataTable dt = new DataTable();
                    if (tables.IsTableRelated(Table6Id) && tables.GetParentTableId(Table6Id) == Tables5Id)
                    {
                        lbTexte.Text = "Choisir " + table_name + " De " + Enregistrement5;
                        Enregistrements enregistrements = new Enregistrements();
                        dt = enregistrements.FindByTableIdAndParentId(Table6Id, Enregistrement5Id);
                    }
                    else
                    {
                        lbTexte.Text = "Choisir " + table_name;
                        Enregistrements enregistrements = new Enregistrements();
                        dt = enregistrements.FindByTableId(Table6Id);
                    }
                    DgvList.DataSource = dt;
                    Bind_Enregistrements();
                    if (Table6_Obl > 0)
                    {
                        btIgnorer.Visible = false;
                        lbRequired.Visible = true;
                    }
                    else
                    {
                        btIgnorer.Visible = true;
                        lbOptional.Visible = true;
                    }
                    Gestion_Navigation("Table6");
                }
                else
                {
                    Enregistrement6Id = 0;
                    Tables6Id = 0;
                    Etape = "Table7";
                    Gestion_Etapes();
                }

                return;
            }

            if (Etape == "Table7")
            {
                if (Table7Id > 0)
                {
                    Tables tables = new Tables();
                    string table_name = tables.GetName(Table7Id);
                    Tables7Name = table_name;
                    Tables7Id = Table7Id;
                    DataTable dt = new DataTable();
                    if (tables.IsTableRelated(Table7Id) && tables.GetParentTableId(Table7Id) == Tables6Id)
                    {
                        lbTexte.Text = "Choisir " + table_name + " De " + Enregistrement6;
                        Enregistrements enregistrements = new Enregistrements();
                        dt = enregistrements.FindByTableIdAndParentId(Table7Id, Enregistrement6Id);
                    }
                    else
                    {
                        lbTexte.Text = "Choisir " + table_name;
                        Enregistrements enregistrements = new Enregistrements();
                        dt = enregistrements.FindByTableId(Table7Id);
                    }
                    DgvList.DataSource = dt;
                    Bind_Enregistrements();
                    if (Table7_Obl > 0)
                    {
                        btIgnorer.Visible = false;
                        lbRequired.Visible = true;
                    }
                    else
                    {
                        btIgnorer.Visible = true;
                        lbOptional.Visible = true;
                    }
                    Gestion_Navigation("Table7");
                }
                else
                {
                    Enregistrement7Id = 0;
                    Tables7Id = 0;
                    Etape = "ChampLibre1";
                    Gestion_Etapes();
                }

                return;
            }

            if (Etape == "ChampLibre1")
            {
                if (ChampLibre1Name.Trim().Length > 2)
                {
                    vg_ChampLibre = true;
                    lbTexte.Text = "Entrez " + ChampLibre1Name;
                    DgvList.Visible = false;
                    btUp.Visible = false;
                    btDown.Visible = false;
                    btDoubleUp.Visible = false;
                    btDoubleDown.Visible = false;
                    if (ChampLibre1_Obl > 0)
                    {
                        btIgnorer.Visible = false;
                        lbRequired.Visible = true;
                    }
                    else
                    {
                        btIgnorer.Visible = true;
                        lbOptional.Visible = true;
                    }
                    Gestion_Navigation("ChampLibre1");
                }
                else
                {
                    ChampLibreName1 = "";
                    ChampLibre1 = "";
                    Etape = "ChampLibre2";
                    Gestion_Etapes();
                }

                return;
            }

            if (Etape == "ChampLibre2")
            {
                if (ChampLibre2Name.Trim().Length > 2)
                {
                    vg_ChampLibre = true;
                    lbTexte.Text = "Entrez " + ChampLibre2Name;
                    DgvList.Visible = false;
                    btUp.Visible = false;
                    btDown.Visible = false;
                    btDoubleUp.Visible = false;
                    btDoubleDown.Visible = false;
                    if (ChampLibre2_Obl > 0)
                    {
                        btIgnorer.Visible = false;
                        lbRequired.Visible = true;
                    }
                    else
                    {
                        btIgnorer.Visible = true;
                        lbOptional.Visible = true;
                    }
                    Gestion_Navigation("ChampLibre2");
                }
                else
                {
                    ChampLibreName2 = "";
                    ChampLibre2 = "";
                    Etape = "ChampLibre3";
                    Gestion_Etapes();
                }

                return;
            }

            if (Etape == "ChampLibre3")
            {
                if (ChampLibre3Name.Trim().Length > 2)
                {
                    vg_ChampLibre = true;
                    lbTexte.Text = "Entrez " + ChampLibre3Name;
                    DgvList.Visible = false;
                    btUp.Visible = false;
                    btDown.Visible = false;
                    btDoubleUp.Visible = false;
                    btDoubleDown.Visible = false;
                    if (ChampLibre3_Obl > 0)
                    {
                        btIgnorer.Visible = false;
                        lbRequired.Visible = true;
                    }
                    else
                    {
                        btIgnorer.Visible = true;
                        lbOptional.Visible = true;
                    }
                    Gestion_Navigation("ChampLibre3");
                }
                else
                {
                    ChampLibreName3 = "";
                    ChampLibre3 = "";
                    Etape = "ChampLibre4";
                    Gestion_Etapes();
                }

                return;
            }

            if (Etape == "ChampLibre4")
            {
                if (ChampLibre4Name.Trim().Length > 2)
                {
                    vg_ChampLibre = true;
                    lbTexte.Text = "Entrez " + ChampLibre4Name;
                    DgvList.Visible = false;
                    btUp.Visible = false;
                    btDown.Visible = false;
                    btDoubleUp.Visible = false;
                    btDoubleDown.Visible = false;
                    if (ChampLibre4_Obl > 0)
                    {
                        btIgnorer.Visible = false;
                        lbRequired.Visible = true;
                    }
                    else
                    {
                        btIgnorer.Visible = true;
                        lbOptional.Visible = true;
                    }
                    Gestion_Navigation("ChampLibre4");
                }
                else
                {
                    ChampLibreName4 = "";
                    ChampLibre4 = "";
                    Etape = "Fin";
                    Gestion_Etapes();
                }

                return;
            }

            if (Etape == "Fin")
            {
                lbTexte.Text = "";
                try
                {
                    if (vg_Tare <= 0)
                    {
                        PeseePB pesee = new PeseePB();
                        pesee.Add("2x", vg_Flux, vg_PontId, WeighingSettingsId, FirmeId, CamionId, ChauffeurId, TransporteurId, ProduitId, ClientId, Enregistrement1Id, Tables1Id, Tables1Name, Enregistrement1,
                            Enregistrement2Id, Tables2Id, Tables2Name, Enregistrement2, Enregistrement3Id, Table3Id, Tables3Name, Enregistrement3, Enregistrement4Id, Table4Id, Tables4Name, Enregistrement4,
                            Enregistrement5Id, Table5Id, Tables5Name, Enregistrement5, Enregistrement6Id, Table6Id, Tables6Name, Enregistrement6, Enregistrement7Id, Table7Id, Tables7Name, Enregistrement7, 0, DateTime.Now, vg_P,
                            DateTime.Now, 0, "Borne", "Pending", ChampLibreName1, ChampLibre1, ChampLibreName2, ChampLibre2, ChampLibreName3, ChampLibre3, ChampLibreName4, ChampLibre4, WalterreId);
                        Form form = new Borne_FinPesee(vg_Lang, "2x1", pesee.GetMaxIdByPontId(vg_PontId), false, 0, vg_PontId);
                        form.Show(this);
                        //Close();
                    }
                    else
                    {
                        // IL FAUT AUSSI GERER LES PESEES WALTERRE POUR LES PESEES EN UNE FOIS POUR L'INSTANT PAS PRIS EN COMPTE
                        PeseePB pesee = new PeseePB();
                        pesee.Add("1x", vg_Flux, vg_PontId, WeighingSettingsId, FirmeId, CamionId, ChauffeurId, TransporteurId, ProduitId, ClientId, Enregistrement1Id, Tables1Id, Tables1Name, Enregistrement1,
                            Enregistrement2Id, Tables2Id, Tables2Name, Enregistrement2, Enregistrement3Id, Table3Id, Tables3Name, Enregistrement3, Enregistrement4Id, Table4Id, Tables4Name, Enregistrement4,
                            Enregistrement5Id, Table5Id, Tables5Name, Enregistrement5, Enregistrement6Id, Table6Id, Tables6Name, Enregistrement6, Enregistrement7Id, Table7Id, Tables7Name, Enregistrement7, vg_P, DateTime.Now, vg_Tare,
                            DateTime.Now, Math.Abs(vg_P - vg_Tare), "Borne", "Complete", ChampLibreName1, ChampLibre1, ChampLibreName2, ChampLibre2, ChampLibreName3, ChampLibre3, ChampLibreName4, ChampLibre4, WalterreId);
                        Form form = new Borne_FinPesee(vg_Lang, "2x2", pesee.GetMaxIdByPontId(vg_PontId), false, 0, vg_PontId);
                        form.Show(this);
                        //Close();
                    }

                }
                catch
                { throw; }
            }

            DgvList.Focus();
        }




        private void Gestion_Navigation(string Etape)
        {
            if (Etape == "ChampLibre1" || Etape == "ChampLibre2" || Etape == "ChampLibre3" || Etape == "ChampLibre4")
            {
                lbCount.Text = "";
                panelClavier.Visible = true;
                btRecherche.Text = Language_Manager.Localize("MASQUER CLAVIER", vg_Lang);
            }
            else if (Etape == "Camion" || Etape == "Walterre")
            {
                DgvList.Visible = false;
                lbCount.Visible = false;
                if (Etape == "Walterre")
                    IsNumeric = true;
                btClavier_Click(this, new EventArgs());
                btRecherche.Visible = false;
                btAnnulerRecherche.Visible = false;
                btDown.Visible = false;
                btUp.Visible = false;
                btDoubleDown.Visible = false;
                btDoubleUp.Visible = false;
            }
            else
            {
                DgvList.Visible = true;
                lbCount.Text = DgvList.RowCount.ToString();
                lbCount.Visible = true;
                btDown.Visible = true;
                btUp.Visible = true;
                btRecherche.Visible = true;
                btAnnulerRecherche.Visible = true;
                if (DgvList.RowCount > 4)
                {
                    btDoubleDown.Visible = true;
                    btDoubleUp.Visible = true;
                }
                else
                {
                    btDoubleDown.Visible = false;
                    btDoubleUp.Visible = false;
                }
            }

            DgvList.Focus();
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
            DgvList.Columns["CHAMPLIBRE1"].Visible = false;
            DgvList.Columns["CHAMPLIBRE2"].Visible = false;
            DgvList.Columns["CHAMPLIBRE3"].Visible = false;
            DgvList.Columns["CHAMPLIBRE4"].Visible = false;
            DgvList.Columns["CHAMPLIBRE1_OBL"].Visible = false;
            DgvList.Columns["CHAMPLIBRE2_OBL"].Visible = false;
            DgvList.Columns["CHAMPLIBRE3_OBL"].Visible = false;
            DgvList.Columns["CHAMPLIBRE4_OBL"].Visible = false;
            DgvList.Columns["CHAMPLIBRE1_TICKET"].Visible = false;
            DgvList.Columns["CHAMPLIBRE2_TICKET"].Visible = false;
            DgvList.Columns["CHAMPLIBRE3_TICKET"].Visible = false;
            DgvList.Columns["CHAMPLIBRE4_TICKET"].Visible = false;
            DgvList.Columns["CHAMPLIBRE1_BORNE"].Visible = false;
            DgvList.Columns["CHAMPLIBRE2_BORNE"].Visible = false;
            DgvList.Columns["CHAMPLIBRE3_BORNE"].Visible = false;
            DgvList.Columns["CHAMPLIBRE4_BORNE"].Visible = false;
            DgvList.Columns["PONTFIRME"].Visible = false;
            DgvList.Columns["CAMIONCHAUFFEUR"].Visible = false;
            DgvList.Columns["CAMIONTRANSPORTEUR"].Visible = false;
            DgvList.Columns["FORMAT"].Visible = false;
            DgvList.Columns["TITRE1"].Visible = false;
            DgvList.Columns["TITRE2"].Visible = false;
            DgvList.Columns["FOOTER"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = false;
            DgvList.Columns["WALTERRE"].Visible = false;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;

            DgvList.Focus();
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

            DgvList.Focus();

        }

        private void Bind_Walterre()
        {
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["CODE"].Visible = true;
            DgvList.Columns["PRODUITID"].Visible = false;
            DgvList.Columns["PRODUIT"].Visible = false;
            DgvList.Columns["CLIENTID"].Visible = false;
            DgvList.Columns["CLIENT"].Visible = false;
            DgvList.Columns["VOLUME"].Visible = false;
            DgvList.Columns["SEUIL_MAX"].Visible = false;
            DgvList.Columns["REGION"].Visible = false;
            DgvList.Columns["TEXTE_BORNE"].Visible = false;
            DgvList.Columns["OBSERVATIONS"].Visible = false;
            DgvList.Columns["DEPASSEMENT"].Visible = false;
            DgvList.Columns["CLOTURE"].Visible = false;
            DgvList.Columns["DATECLOTURE"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = false;
            DgvList.Columns["STATUS"].Visible = false;
            DgvList.Columns["DEPASSEMENT_SEUIL_MAX"].Visible = false;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;

            DgvList.Focus();

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

            DgvList.Focus();
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

            DgvList.Focus();

        }

        private void Bind_CamionChauffeurs()
        {
            DgvList.Columns[0].Visible = false;

            DgvList.Columns["CAMIONID"].Visible = false;
            DgvList.Columns["CHAUFFEUR"].Visible = true;
            DgvList.Columns["CAMION"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = false;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;

            DgvList.Focus();

        }

        private void Bind_CamionTransporteurs()
        {
            DgvList.Columns[0].Visible = false;

            DgvList.Columns["CAMIONID"].Visible = false;
            DgvList.Columns["TRANSPORTEUR"].Visible = true;
            DgvList.Columns["CAMION"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = false;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;

            DgvList.Focus();

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

            DgvList.Focus();

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
            DgvList.Columns["PRIXUNITAIRE"].Visible = false;
            DgvList.Columns["TVA"].Visible = false;
            DgvList.Columns["DATECREATION"].Visible = false;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;

            DgvList.Focus();
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

            DgvList.Focus();
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

            DgvList.Focus();

        }

        private void btValider_Click(object sender, EventArgs e)
        {
            DgvList.Focus();
            if (Etape == "Parametre")
            {
                if (DgvList.RowCount > 0)
                {
                    WeighingSettingsId = Common_functions.GetDatagridViewSelectedId(DgvList);
                    Etape = "Camion";
                    Gestion_Etapes();
                }
                return;
            }

            if (Etape == "Camion")
            {
                if (lbMessage.Text.Length > 2)
                {
                    //CamionId = Common_functions.GetDatagridViewSelectedId(DgvList);
                    Camion camion = new Camion();
                    if (camion.IfExists(lbMessage.Text))
                    {
                        if (camion.IfExists_Valid(lbMessage.Text))
                        {
                            CamionId = camion.GetIdByName(lbMessage.Text);
                            vg_CamionChauffeurId = 0;
                            vg_CamionTransporteurId = 0;
                            CamionChauffeur camionChauffeur = new CamionChauffeur();
                            CamionTransporteur camionTransporteur = new CamionTransporteur();
                            if (CamionChauffeur > 0)
                            {
                                if (camionChauffeur.CountByCamionId(CamionId) > 0)
                                {
                                    if (camionChauffeur.CountByCamionId(CamionId) == 1)
                                        vg_CamionChauffeurId = camionChauffeur.GetFirstChauffeurByCamionId(CamionId);
                                    else
                                        vg_CamionChauffeurId = -1000;
                                }
                                else
                                {
                                    vg_CamionChauffeurId = 0;
                                }
                            }
                            if (CamionTransporteur > 0)
                            {
                                if (camionTransporteur.CountByCamionId(CamionId) > 0)
                                {
                                    if (camionTransporteur.CountByCamionId(CamionId) == 1)
                                        vg_CamionTransporteurId = camionTransporteur.GetFirstTransporteurByCamionId(CamionId);
                                    else
                                        vg_CamionTransporteurId = -1000;
                                }
                                else
                                {
                                    vg_CamionTransporteurId = 0;
                                }
                            }
                            Etape = "Firme";
                            Gestion_Etapes();
                        }
                        else
                        {
                            lbInvalide.Visible = true; 
                        }
                        
                    }
                    else
                    {
                        if (Camion_Ajout > 0)
                        {
                            try
                            {
                                int maxid;
                                camion.Add("", lbMessage.Text, "", 0, 1, 0, "", 0, "", "");
                                maxid = camion.GetMaxId();
                                CamionId = maxid;
                                Etape = "Firme";
                                Gestion_Etapes();
                            }
                            catch
                            {
                                throw;
                            }

                        }
                        else
                        {
                            lbNotFound.Visible = true;
                        }
                    }

                }
                return;

            }

            if (Etape == "Firme")
            {
                if (DgvList.RowCount > 0)
                {
                    FirmeId = Common_functions.GetDatagridViewSelectedId(DgvList);
                    Etape = "Chauffeur";
                    Gestion_Etapes();
                }
                return;
            }

            if (Etape == "Chauffeur")
            {
                if (DgvList.RowCount > 0)
                {
                    ChauffeurId = Common_functions.GetDatagridViewSelectedId(DgvList);
                    Etape = "Transporteur";
                    Gestion_Etapes();
                }
                return;
            }

            if (Etape == "Transporteur")
            {
                if (DgvList.RowCount > 0)
                {
                    TransporteurId = Common_functions.GetDatagridViewSelectedId(DgvList);
                    Etape = "Walterre";
                    Gestion_Etapes();
                }
                return;
            }

            if (Etape == "Walterre")
            {
                if (DgvList.RowCount >= 0)
                {
                    //WalterreId = Common_functions.GetDatagridViewSelectedId(DgvList);
                    Walterre walterre = new Walterre();
                    if (walterre.IfExists_Valid("WT" + lbMessage.Text))
                    {
                        WalterreId = walterre.GetIdByName("WT" + lbMessage.Text);
                        Etape = "Produit";
                        Gestion_Etapes();
                    }
                    else
                    {
                        lbNotFound.Visible = true;
                    }
                }
                return;
            }

            if (Etape == "Produit")
            {
                if (DgvList.RowCount > 0)
                {
                    ProduitId = Common_functions.GetDatagridViewSelectedId(DgvList);
                    Etape = "Client";
                    Gestion_Etapes();
                }
                return;
            }

            if (Etape == "Client")
            {
                if (DgvList.RowCount > 0)
                {
                    ClientId = Common_functions.GetDatagridViewSelectedId(DgvList);
                    Etape = "Table1";
                    Gestion_Etapes();
                }
                return;
            }

            if (Etape == "Table1")
            {
                if (DgvList.RowCount > 0)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    Enregistrement1Id = Common_functions.GetDatagridViewSelectedId(DgvList);
                    Enregistrement1 = enregistrements.GetName(Enregistrement1Id);
                    Etape = "Table2";
                    Gestion_Etapes();
                }
                return;
            }

            if (Etape == "Table2")
            {
                if (DgvList.RowCount > 0)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    Enregistrement2Id = Common_functions.GetDatagridViewSelectedId(DgvList);
                    Enregistrement2 = enregistrements.GetName(Enregistrement2Id);
                    Etape = "Table3";
                    Gestion_Etapes();
                }
                return;
            }

            if (Etape == "Table3")
            {
                if (DgvList.RowCount > 0)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    Enregistrement3Id = Common_functions.GetDatagridViewSelectedId(DgvList);
                    Enregistrement3 = enregistrements.GetName(Enregistrement3Id);
                    Etape = "Table4";
                    Gestion_Etapes();
                }
                return;
            }

            if (Etape == "Table4")
            {
                if (DgvList.RowCount > 0)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    Enregistrement4Id = Common_functions.GetDatagridViewSelectedId(DgvList);
                    Enregistrement4 = enregistrements.GetName(Enregistrement4Id);
                    Etape = "Table5";
                    Gestion_Etapes();
                }
                return;
            }

            if (Etape == "Table5")
            {
                if (DgvList.RowCount > 0)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    Enregistrement5Id = Common_functions.GetDatagridViewSelectedId(DgvList);
                    Enregistrement5 = enregistrements.GetName(Enregistrement5Id);
                    Etape = "Table6";
                    Gestion_Etapes();
                }
                return;
            }

            if (Etape == "Table6")
            {
                if (DgvList.RowCount > 0)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    Enregistrement6Id = Common_functions.GetDatagridViewSelectedId(DgvList);
                    Enregistrement6 = enregistrements.GetName(Enregistrement6Id);
                    Etape = "Table7";
                    Gestion_Etapes();
                }
                return;
            }

            if (Etape == "Table7")
            {
                if (DgvList.RowCount > 0)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    Enregistrement7Id = Common_functions.GetDatagridViewSelectedId(DgvList);
                    Enregistrement7 = enregistrements.GetName(Enregistrement7Id);
                    Etape = "ChampLibre1";
                    Gestion_Etapes();
                }
                return;
            }

            if (Etape == "ChampLibre1")
            {
                if (lbMessage.Text.Trim().Length >= 2)
                {
                    ChampLibreName1 = ChampLibre1Name;
                    ChampLibre1 = lbMessage.Text;
                    Etape = "ChampLibre2";
                    Gestion_Etapes();
                }
                return;
            }

            if (Etape == "ChampLibre2")
            {
                if (lbMessage.Text.Trim().Length >= 2)
                {
                    ChampLibreName2 = ChampLibre2Name;
                    ChampLibre2 = lbMessage.Text;
                    Etape = "ChampLibre3";
                    Gestion_Etapes();
                }
                return;
            }

            if (Etape == "ChampLibre3")
            {
                if (lbMessage.Text.Trim().Length >= 2)
                {
                    ChampLibreName3 = ChampLibre3Name;
                    ChampLibre3 = lbMessage.Text;
                    Etape = "ChampLibre4";
                    Gestion_Etapes();
                }
                return;
            }

            if (Etape == "ChampLibre4")
            {
                if (lbMessage.Text.Trim().Length >= 2)
                {
                    ChampLibreName4 = ChampLibre4Name;
                    ChampLibre4 = lbMessage.Text;
                    Etape = "Fin";
                    Gestion_Etapes();
                }
                return;
            }
        }

        private void btAnnuler_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btUp_Click(object sender, EventArgs e)
        {
            DgvList.Focus();
            int i;
            if (Etape == "Parametre" || Etape == "Produit" || Etape == "Walterre")
            {
                i = 1;
            }
            else
            {
                i = 2;
            }
            int currentRow = DgvList.CurrentCell.RowIndex;
            if (currentRow > 0)
            {
                DgvList.Rows[currentRow - 1].Cells[i].Selected = true;
                DgvList.CurrentCell = DgvList.Rows[currentRow - 1].Cells[i];
            }
        }

        private void btDown_Click(object sender, EventArgs e)
        {
            DgvList.Focus();
            int i;
            if (Etape == "Parametre" || Etape == "Produit" || Etape == "Walterre")
            {
                i = 1;
            }
            else
            {
                i = 2;
            }
            int currentRow = DgvList.CurrentCell.RowIndex;
            if (currentRow < DgvList.RowCount - 1)
            {
                DgvList.Rows[currentRow + 1].Cells[i].Selected = true;
                DgvList.CurrentCell = DgvList.Rows[currentRow + 1].Cells[i];
            }
        }

        private void btDoubleUp_Click(object sender, EventArgs e)
        {
            DgvList.Focus();
            int i;
            if (Etape == "Parametre" || Etape == "Produit" || Etape == "Walterre")
            {
                i = 1;
            }
            else
            {
                i = 2;
            }
            int currentRow = DgvList.CurrentCell.RowIndex;
            if (currentRow > 3)
            {
                DgvList.Rows[currentRow - 3].Cells[i].Selected = true;
                DgvList.CurrentCell = DgvList.Rows[currentRow - 3].Cells[i];
            }
            else
            {
                DgvList.Rows[0].Cells[i].Selected = true;
                DgvList.CurrentCell = DgvList.Rows[0].Cells[i];
            }
        }

        private void btDoubleDown_Click(object sender, EventArgs e)
        {
            DgvList.Focus();
            int i;
            if (Etape == "Parametre" || Etape == "Produit" || Etape == "Walterre")
            {
                i = 1;
            }
            else
            {
                i = 2;
            }
            int currentRow = DgvList.CurrentCell.RowIndex;
            if (currentRow < DgvList.RowCount - 3)
            {
                DgvList.Rows[currentRow + 3].Cells[i].Selected = true;
                DgvList.CurrentCell = DgvList.Rows[currentRow + 3].Cells[i];
            }
            else
            {
                DgvList.Rows[DgvList.RowCount - 1].Cells[i].Selected = true;
                DgvList.CurrentCell = DgvList.Rows[DgvList.RowCount - 1].Cells[i];
            }
        }

        private void btClavier_Click(object sender, EventArgs e)
        {
            Clavier();
        }

        private void Clavier()
        {
            if (panelClavier.Visible)
            {
                panelClavier.Visible = false;
                //lbMessage.Visible = false;
                btRecherche.Text = Language_Manager.Localize("AFFICHER CLAVIER", vg_Lang);
            }
            else
            {
                panelClavier.Visible = true;
                //lbMessage.Visible = true;
                btRecherche.Text = Language_Manager.Localize("MASQUER CLAVIER", vg_Lang);
                if (IsNumeric)
                {
                    A.Visible = false;
                    B.Visible = false;
                    C.Visible = false;
                    D.Visible = false;
                    E.Visible = false;
                    F.Visible = false;
                    G.Visible = false;
                    H.Visible = false;
                    I.Visible = false;
                    J.Visible = false;
                    K.Visible = false;
                    L.Visible = false;
                    M.Visible = false;
                    N.Visible = false;
                    O.Visible = false;
                    P.Visible = false;
                    Q.Visible = false;
                    R.Visible = false;
                    S.Visible = false;
                    T.Visible = false;
                    U.Visible = false;
                    V.Visible = false;
                    W.Visible = false;
                    X.Visible = false;
                    Y.Visible = false;
                    Z.Visible = false;
                    Tiret.Visible = false;
                    Slash.Visible = false;
                    Space.Visible = false;
                }
                else
                {
                    A.Visible = true;
                    B.Visible = true;
                    C.Visible = true;
                    D.Visible = true;
                    E.Visible = true;
                    F.Visible = true;
                    G.Visible = true;
                    H.Visible = true;
                    I.Visible = true;
                    J.Visible = true;
                    K.Visible = true;
                    L.Visible = true;
                    M.Visible = true;
                    N.Visible = true;
                    O.Visible = true;
                    P.Visible = true;
                    Q.Visible = true;
                    R.Visible = true;
                    S.Visible = true;
                    T.Visible = true;
                    U.Visible = true;
                    V.Visible = true;
                    W.Visible = true;
                    X.Visible = true;
                    Y.Visible = true;
                    Z.Visible = true;
                    Tiret.Visible = true;
                    Slash.Visible = true;
                    Space.Visible = true;
                }

            }

            IsNumeric = false;
        }

        private void Search(String text, string Etape)
        {
            if (Etape == "Parametre")
            {
                WeighingSettings weighingSettings = new WeighingSettings();
                DataTable dt = new DataTable();
                dt = weighingSettings.SearchBox(text);
                DgvList.DataSource = dt;
            }

            if (Etape == "Camion")
            {
                /*Camion camion = new Camion();
                DataTable dt = new DataTable();
                dt = camion.SearchBox_Terminal(text);
                DgvList.DataSource = dt;
                int RowsCount = dt.Rows.Count;
                if (RowsCount <= 0)
                    lbNotFound.Visible = true;
                else
                    lbNotFound.Visible = false;
                if (Camion_Ajout > 0)
                {
                    if (text.Length > 1)
                    {
                        if (RowsCount <= 0)
                            btAjouter.Visible = true;
                        else
                            btAjouter.Visible = false;
                    }
                }*/

            }

            if (Etape == "Firme")
            {
                Firme firme = new Firme();
                DataTable dt = new DataTable();
                dt = firme.SearchBox(text);
                DgvList.DataSource = dt;
                int RowsCount = dt.Rows.Count;
                if (RowsCount <= 0)
                    lbNotFound.Visible = true;
                else
                    lbNotFound.Visible = false;
                if (Firme_Ajout > 0)
                {
                    if (text.Length > 1)
                    {
                        if (dt.Rows.Count <= 0)
                            btAjouter.Visible = true;
                        else
                            btAjouter.Visible = false;
                    }
                }
            }

            if (Etape == "Chauffeur")
            {
                Chauffeur chauffeur = new Chauffeur();
                DataTable dt = new DataTable();
                dt = chauffeur.SearchBox(text);
                DgvList.DataSource = dt;
                int RowsCount = dt.Rows.Count;
                if (RowsCount <= 0)
                    lbNotFound.Visible = true;
                else
                    lbNotFound.Visible = false;
                if (Chauffeur_Ajout > 0)
                {
                    if (text.Length > 1)
                    {
                        if (dt.Rows.Count <= 0)
                            btAjouter.Visible = true;
                        else
                            btAjouter.Visible = false;
                    }
                }
            }

            if (Etape == "Transporteur")
            {
                Transporteur transporteur = new Transporteur();
                DataTable dt = new DataTable();
                dt = transporteur.SearchBox(text);
                DgvList.DataSource = dt;
                int RowsCount = dt.Rows.Count;
                if (RowsCount <= 0)
                    lbNotFound.Visible = true;
                else
                    lbNotFound.Visible = false;
                if (Transporteur_Ajout > 0)
                {
                    if (text.Length > 1)
                    {
                        if (dt.Rows.Count <= 0)
                            btAjouter.Visible = true;
                        else
                            btAjouter.Visible = false;
                    }
                }
            }

            if (Etape == "Walterre")
            {
                /*Walterre walterre = new Walterre();
                DataTable dt = new DataTable();
                dt = walterre.SearchBox(text);
                DgvList.DataSource = dt;
                int RowsCount = dt.Rows.Count;
                if (RowsCount <= 0)
                    lbNotFound.Visible = true;
                else
                    lbNotFound.Visible = false;*/
            }

            if (Etape == "Produit")
            {
                Produit produit = new Produit();
                DataTable dt = new DataTable();
                dt = produit.SearchBox(text);
                DgvList.DataSource = dt;
                int RowsCount = dt.Rows.Count;
                if (RowsCount <= 0)
                    lbNotFound.Visible = true;
                else
                    lbNotFound.Visible = false;
                if (Produit_Ajout > 0)
                {
                    if (text.Length > 1)
                    {
                        if (dt.Rows.Count <= 0)
                            btAjouter.Visible = true;
                        else
                            btAjouter.Visible = false;
                    }
                }
            }

            if (Etape == "Client")
            {
                Client client = new Client();
                DataTable dt = new DataTable();
                dt = client.SearchBox(text);
                DgvList.DataSource = dt;
                int RowsCount = dt.Rows.Count;
                if (RowsCount <= 0)
                    lbNotFound.Visible = true;
                else
                    lbNotFound.Visible = false;
                if (Client_Ajout > 0)
                {
                    if (text.Length > 1)
                    {
                        if (dt.Rows.Count <= 0)
                            btAjouter.Visible = true;
                        else
                            btAjouter.Visible = false;
                    }
                }
            }

            if (Etape == "Table1")
            {
                Enregistrements enregistrements = new Enregistrements();
                DataTable dt = new DataTable();
                dt = enregistrements.SearchBox(text, Table1Id);
                DgvList.DataSource = dt;
                int RowsCount = dt.Rows.Count;
                if (RowsCount <= 0)
                    lbNotFound.Visible = true;
                else
                    lbNotFound.Visible = false;
                if (Table1_Ajout > 0)
                {
                    if (text.Length > 1)
                    {
                        if (dt.Rows.Count <= 0)
                            btAjouter.Visible = true;
                        else
                            btAjouter.Visible = false;
                    }
                }
            }

            if (Etape == "Table2")
            {
                Tables tables = new Tables();
                DataTable dt = new DataTable();
                if (tables.IsTableRelated(Table2Id) && tables.GetParentTableId(Table2Id) == Table1Id)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.SearchBoxWithParentId(text, Table2Id, Enregistrement1Id);
                }
                else
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.SearchBox(text, Table2Id);
                }
                DgvList.DataSource = dt;
                int RowsCount = dt.Rows.Count;
                if (RowsCount <= 0)
                    lbNotFound.Visible = true;
                else
                    lbNotFound.Visible = false;
                if (Table2_Ajout > 0)
                {
                    if (text.Length > 1)
                    {
                        if (dt.Rows.Count <= 0)
                            btAjouter.Visible = true;
                        else
                            btAjouter.Visible = false;
                    }
                }
            }

            if (Etape == "Table3")
            {
                Tables tables = new Tables();
                DataTable dt = new DataTable();
                if (tables.IsTableRelated(Table3Id) && tables.GetParentTableId(Table3Id) == Table2Id)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.SearchBoxWithParentId(text, Table3Id, Enregistrement2Id);
                }
                else
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.SearchBox(text, Table3Id);
                }
                DgvList.DataSource = dt;
                int RowsCount = dt.Rows.Count;
                if (RowsCount <= 0)
                    lbNotFound.Visible = true;
                else
                    lbNotFound.Visible = false;
                if (Table3_Ajout > 0)
                {
                    if (text.Length > 1)
                    {
                        if (dt.Rows.Count <= 0)
                            btAjouter.Visible = true;
                        else
                            btAjouter.Visible = false;
                    }
                }
            }

            if (Etape == "Table4")
            {
                Tables tables = new Tables();
                DataTable dt = new DataTable();
                if (tables.IsTableRelated(Table4Id) && tables.GetParentTableId(Table4Id) == Table3Id)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.SearchBoxWithParentId(text, Table4Id, Enregistrement3Id);
                }
                else
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.SearchBox(text, Table4Id);
                }
                DgvList.DataSource = dt;
                int RowsCount = dt.Rows.Count;
                if (RowsCount <= 0)
                    lbNotFound.Visible = true;
                else
                    lbNotFound.Visible = false;
                if (Table4_Ajout > 0)
                {
                    if (text.Length > 1)
                    {
                        if (dt.Rows.Count <= 0)
                            btAjouter.Visible = true;
                        else
                            btAjouter.Visible = false;
                    }
                }
            }

            if (Etape == "Table5")
            {
                Tables tables = new Tables();
                DataTable dt = new DataTable();
                if (tables.IsTableRelated(Table5Id) && tables.GetParentTableId(Table5Id) == Table4Id)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.SearchBoxWithParentId(text, Table5Id, Enregistrement4Id);
                }
                else
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.SearchBox(text, Table5Id);
                }
                DgvList.DataSource = dt;
                int RowsCount = dt.Rows.Count;
                if (RowsCount <= 0)
                    lbNotFound.Visible = true;
                else
                    lbNotFound.Visible = false;
                if (Table5_Ajout > 0)
                {
                    if (text.Length > 1)
                    {
                        if (dt.Rows.Count <= 0)
                            btAjouter.Visible = true;
                        else
                            btAjouter.Visible = false;
                    }
                }
            }

            if (Etape == "Table6")
            {
                Tables tables = new Tables();
                DataTable dt = new DataTable();
                if (tables.IsTableRelated(Table6Id) && tables.GetParentTableId(Table6Id) == Table5Id)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.SearchBoxWithParentId(text, Table6Id, Enregistrement5Id);
                }
                else
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.SearchBox(text, Table6Id);
                }
                DgvList.DataSource = dt;
                int RowsCount = dt.Rows.Count;
                if (RowsCount <= 0)
                    lbNotFound.Visible = true;
                else
                    lbNotFound.Visible = false;
                if (Table6_Ajout > 0)
                {
                    if (text.Length > 1)
                    {
                        if (dt.Rows.Count <= 0)
                            btAjouter.Visible = true;
                        else
                            btAjouter.Visible = false;
                    }
                }
            }

            if (Etape == "Table7")
            {
                Tables tables = new Tables();
                DataTable dt = new DataTable();
                if (tables.IsTableRelated(Table7Id) && tables.GetParentTableId(Table7Id) == Table6Id)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.SearchBoxWithParentId(text, Table7Id, Enregistrement6Id);
                }
                else
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.SearchBox(text, Table7Id);
                }
                DgvList.DataSource = dt;
                int RowsCount = dt.Rows.Count;
                if (RowsCount <= 0)
                    lbNotFound.Visible = true;
                else
                    lbNotFound.Visible = false;
                if (Table7_Ajout > 0)
                {
                    if (text.Length > 1)
                    {
                        if (dt.Rows.Count <= 0)
                            btAjouter.Visible = true;
                        else
                            btAjouter.Visible = false;
                    }
                }
            }
        }

        private void Cancel_Search(String text, string Etape)
        {
            if (Etape == "Parametre")
            {
                WeighingSettings weighingSettings = new WeighingSettings();
                DataTable dt = new DataTable();
                dt = weighingSettings.List("1=1");
                DgvList.DataSource = dt;
            }

            if (Etape == "Camion")
            {
                /*Camion camion = new Camion();
                DataTable dt = new DataTable();
                dt = camion.List("1=1");
                DgvList.DataSource = dt;*/
            }

            if (Etape == "Firme")
            {
                Firme firme = new Firme();
                DataTable dt = new DataTable();
                dt = firme.List("1=1");
                DgvList.DataSource = dt;
            }

            if (Etape == "Chauffeur")
            {
                Chauffeur chauffeur = new Chauffeur();
                DataTable dt = new DataTable();
                dt = chauffeur.List("1=1");
                DgvList.DataSource = dt;
            }

            if (Etape == "Transporteur")
            {
                Transporteur transporteur = new Transporteur();
                DataTable dt = new DataTable();
                dt = transporteur.List("1=1");
                DgvList.DataSource = dt;
            }

            if (Etape == "Walterre")
            {
                /*Walterre walterre = new Walterre();
                DataTable dt = new DataTable();
                dt = walterre.List("1=1");
                DgvList.DataSource = dt;*/
            }

            if (Etape == "Produit")
            {
                Produit produit = new Produit();
                DataTable dt = new DataTable();
                dt = produit.List("1=1");
                DgvList.DataSource = dt;
            }

            if (Etape == "Client")
            {
                Client client = new Client();
                DataTable dt = new DataTable();
                dt = client.List("1=1");
                DgvList.DataSource = dt;
            }

            if (Etape == "Table1")
            {
                Enregistrements enregistrements = new Enregistrements();
                DataTable dt = new DataTable();
                dt = enregistrements.FindByTableId(Table1Id);
                DgvList.DataSource = dt;
            }

            if (Etape == "Table2")
            {
                Tables tables = new Tables();
                DataTable dt = new DataTable();
                if (tables.IsTableRelated(Table2Id) && tables.GetParentTableId(Table2Id) == Table1Id)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.FindByTableIdAndParentId(Table2Id, Enregistrement1Id);
                }
                else
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.FindByTableId(Table2Id);
                }
                DgvList.DataSource = dt;
            }

            if (Etape == "Table3")
            {
                Tables tables = new Tables();
                DataTable dt = new DataTable();
                if (tables.IsTableRelated(Table3Id) && tables.GetParentTableId(Table3Id) == Table2Id)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.FindByTableIdAndParentId(Table3Id, Enregistrement2Id);
                }
                else
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.FindByTableId(Table3Id);
                }
                DgvList.DataSource = dt;
            }

            if (Etape == "Table4")
            {
                Tables tables = new Tables();
                DataTable dt = new DataTable();
                if (tables.IsTableRelated(Table4Id) && tables.GetParentTableId(Table4Id) == Table3Id)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.FindByTableIdAndParentId(Table4Id, Enregistrement3Id);
                }
                else
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.FindByTableId(Table4Id);
                }
                DgvList.DataSource = dt;
            }

            if (Etape == "Table5")
            {
                Tables tables = new Tables();
                DataTable dt = new DataTable();
                if (tables.IsTableRelated(Table5Id) && tables.GetParentTableId(Table5Id) == Table4Id)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.FindByTableIdAndParentId(Table5Id, Enregistrement4Id);
                }
                else
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.FindByTableId(Table5Id);
                }
                DgvList.DataSource = dt;
            }

            if (Etape == "Table6")
            {
                Tables tables = new Tables();
                DataTable dt = new DataTable();
                if (tables.IsTableRelated(Table6Id) && tables.GetParentTableId(Table6Id) == Table5Id)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.FindByTableIdAndParentId(Table6Id, Enregistrement5Id);
                }
                else
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.FindByTableId(Table6Id);
                }
                DgvList.DataSource = dt;
            }

            if (Etape == "Table7")
            {
                Tables tables = new Tables();
                DataTable dt = new DataTable();
                if (tables.IsTableRelated(Table7Id) && tables.GetParentTableId(Table7Id) == Table6Id)
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.FindByTableIdAndParentId(Table7Id, Enregistrement6Id);
                }
                else
                {
                    Enregistrements enregistrements = new Enregistrements();
                    dt = enregistrements.FindByTableId(Table7Id);
                }
                DgvList.DataSource = dt;
            }
        }

        private void A_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "A";
        }

        private void B_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "B";
        }

        private void C_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "C";
        }

        private void D_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "D";
        }

        private void E_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "E";
        }

        private void F_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "F";
        }

        private void G_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "G";
        }

        private void H_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "H";
        }

        private void I_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "I";
        }

        private void J_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "J";
        }

        private void K_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "K";
        }

        private void L_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "L";
        }

        private void M_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "M";
        }

        private void N_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "N";
        }

        private void O_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "O";
        }

        private void P_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "P";
        }

        private void Q_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "Q";
        }

        private void R_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "R";
        }

        private void S_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "S";
        }

        private void T_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "T";
        }

        private void U_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "U";
        }

        private void V_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "V";
        }

        private void W_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "W";
        }

        private void X_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "X";
        }

        private void Y_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "Y";
        }

        private void Z_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "Z";
        }

        private void bt_1_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "1";
        }

        private void bt_2_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "2";
        }

        private void bt_3_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "3";
        }

        private void bt_4_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "4";
        }

        private void bt_5_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "5";
        }

        private void bt_6_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "6";
        }

        private void bt_7_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "7";
        }

        private void bt_8_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "8";
        }

        private void bt_9_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "9";
        }

        private void bt_0_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "0";
        }

        private void Tiret_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "-";
        }

        private void Slash_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + "/";
        }

        private void btEffacer_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length > 0)
            {
                lbMessage.Text = lbMessage.Text.Remove(lbMessage.Text.Length - 1);
                if (lbMessage.Text.Length <= 0)
                {
                    if (vg_ChampLibre)
                    {
                        lbCount.Text = "";
                    }
                    else
                    {
                        if (Etape == "Camion" || Etape == "Walterre")
                        {

                        }
                        else
                        {
                            Cancel_Search(lbMessage.Text, Etape);
                            lbCount.Text = DgvList.RowCount.ToString();
                            Init_Keyboard();
                        }

                    }

                }
            }
        }

        private void lbMessage_TextChanged(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length > 0)
            {
                if (vg_ChampLibre)
                {
                    lbCount.Text = "";
                }
                else
                {
                    if (Etape == "Camion" || Etape == "Walterre")
                    {

                    }
                    else
                    {
                        Search(lbMessage.Text, Etape);
                        lbCount.Text = DgvList.RowCount.ToString();
                        btAnnulerRecherche.Visible = true;
                    }

                }

            }
        }

        private void btAnnulerRecherche_Click(object sender, EventArgs e)
        {
            Cancel_Search(lbMessage.Text, Etape);
            lbCount.Text = DgvList.RowCount.ToString();
            Init_Keyboard();
        }

        private void lbMessage_Click(object sender, EventArgs e)
        {

        }

        private void Space_Click(object sender, EventArgs e)
        {
            if (lbMessage.Text.Length < 15)
                lbMessage.Text = lbMessage.Text + " ";
        }

        private void btAjouter_Click(object sender, EventArgs e)
        {
            if (Etape == "Camion")
            {
                Camion camion = new Camion();
                int maxid = 0;
                try
                {
                    camion.Add("", lbMessage.Text, "", 0, 1, 0, "", 0, "", "");
                    maxid = camion.GetMaxId();
                }
                catch
                {
                    throw;
                }
                CamionId = maxid;
                Etape = "Firme";
                Gestion_Etapes();
                return;

            }

            if (Etape == "Firme")
            {
                Firme firme = new Firme();
                int maxid = 0;
                try
                {
                    firme.Add("", lbMessage.Text, "", "", "", "", "", "", "", "", "", 1, 0, "", 0, "");
                    maxid = firme.GetMaxId();
                }
                catch
                {
                    throw;
                }
                FirmeId = maxid;
                Etape = "Chauffeur";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Chauffeur")
            {
                Chauffeur chauffeur = new Chauffeur();
                int maxid = 0;
                try
                {
                    chauffeur.Add("", lbMessage.Text, "", "", "", "", "", "", "", "", 1, 0, "", 0, "");
                    maxid = chauffeur.GetMaxId();
                }
                catch
                {
                    throw;
                }
                ChauffeurId = maxid;
                Etape = "Transporteur";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Transporteur")
            {
                Transporteur transporteur = new Transporteur();
                int maxid = 0;
                try
                {
                    transporteur.Add("", lbMessage.Text, "", "", "", "", "", "", "", "", "", 1, 0, "", 0, "");
                    maxid = transporteur.GetMaxId();
                }
                catch
                {
                    throw;
                }
                TransporteurId = maxid;
                Etape = "Produit";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Walterre")
            {
                //Rien 
            }

            if (Etape == "Produit")
            {
                Produit produit = new Produit();
                int maxid = 0;
                try
                {
                    produit.Add(lbMessage.Text, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    maxid = produit.GetMaxId();
                }
                catch
                {
                    throw;
                }
                ProduitId = maxid;
                Etape = "Client";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Client")
            {
                Client client = new Client();
                int maxid = 0;
                try
                {
                    client.Add("", lbMessage.Text, 0, "", "", "", "", "", "", "", "", "", 1, 0, "", 0, "");
                    maxid = client.GetMaxId();
                }
                catch
                {
                    throw;
                }
                ClientId = maxid;
                Etape = "Table1";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table1")
            {
                Enregistrements enregistrements = new Enregistrements();
                int maxid = 0;
                try
                {
                    enregistrements.Add(Table1Id, lbMessage.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", 0);
                    maxid = enregistrements.GetMaxId();
                }
                catch
                {
                    throw;
                }
                Enregistrement1Id = maxid;
                Enregistrement1 = enregistrements.GetName(Enregistrement1Id);
                Etape = "Table2";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table2")
            {
                Tables tables = new Tables();
                Enregistrements enregistrements = new Enregistrements();
                int maxid = 0;
                try
                {
                    if (tables.IsTableRelated(Table2Id))
                    {
                        if (tables.GetParentTableId(Table2Id) == Table1Id)
                        {
                            enregistrements.Add(Table2Id, lbMessage.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", Enregistrement1Id);
                            maxid = enregistrements.GetMaxId();
                        }
                    }
                    else
                    {
                        enregistrements.Add(Table2Id, lbMessage.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", 0);
                        maxid = enregistrements.GetMaxId();
                    }
                }
                catch
                {
                    throw;
                }

                Enregistrement2Id = maxid;
                Enregistrement2 = enregistrements.GetName(Enregistrement2Id);
                Etape = "Table3";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table3")
            {
                Tables tables = new Tables();
                Enregistrements enregistrements = new Enregistrements();
                int maxid = 0;
                try
                {
                    if (tables.IsTableRelated(Table3Id))
                    {
                        if (tables.GetParentTableId(Table3Id) == Table2Id)
                        {
                            enregistrements.Add(Table3Id, lbMessage.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", Enregistrement2Id);
                            maxid = enregistrements.GetMaxId();
                        }
                    }
                    else
                    {
                        enregistrements.Add(Table3Id, lbMessage.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", 0);
                        maxid = enregistrements.GetMaxId();
                    }
                }
                catch
                {
                    throw;
                }

                Enregistrement3Id = maxid;
                Enregistrement3 = enregistrements.GetName(Enregistrement3Id);
                Etape = "Table4";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table4")
            {
                Tables tables = new Tables();
                Enregistrements enregistrements = new Enregistrements();
                int maxid = 0;
                try
                {
                    if (tables.IsTableRelated(Table4Id))
                    {
                        if (tables.GetParentTableId(Table4Id) == Table3Id)
                        {
                            enregistrements.Add(Table4Id, lbMessage.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", Enregistrement3Id);
                            maxid = enregistrements.GetMaxId();
                        }
                    }
                    else
                    {
                        enregistrements.Add(Table4Id, lbMessage.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", 0);
                        maxid = enregistrements.GetMaxId();
                    }
                }
                catch
                {
                    throw;
                }

                Enregistrement4Id = maxid;
                Enregistrement4 = enregistrements.GetName(Enregistrement4Id);
                Etape = "Table5";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table5")
            {
                Tables tables = new Tables();
                Enregistrements enregistrements = new Enregistrements();
                int maxid = 0;
                try
                {
                    if (tables.IsTableRelated(Table5Id))
                    {
                        if (tables.GetParentTableId(Table5Id) == Table4Id)
                        {
                            enregistrements.Add(Table5Id, lbMessage.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", Enregistrement4Id);
                            maxid = enregistrements.GetMaxId();
                        }
                    }
                    else
                    {
                        enregistrements.Add(Table5Id, lbMessage.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", 0);
                        maxid = enregistrements.GetMaxId();
                    }
                }
                catch
                {
                    throw;
                }

                Enregistrement5Id = maxid;
                Enregistrement5 = enregistrements.GetName(Enregistrement5Id);
                Etape = "Table6";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table6")
            {
                Tables tables = new Tables();
                Enregistrements enregistrements = new Enregistrements();
                int maxid = 0;
                try
                {
                    if (tables.IsTableRelated(Table6Id))
                    {
                        if (tables.GetParentTableId(Table6Id) == Table5Id)
                        {
                            enregistrements.Add(Table6Id, lbMessage.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", Enregistrement5Id);
                            maxid = enregistrements.GetMaxId();
                        }
                    }
                    else
                    {
                        enregistrements.Add(Table6Id, lbMessage.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", 0);
                        maxid = enregistrements.GetMaxId();
                    }
                }
                catch
                {
                    throw;
                }

                Enregistrement6Id = maxid;
                Enregistrement6 = enregistrements.GetName(Enregistrement6Id);
                Etape = "Table7";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table7")
            {
                Tables tables = new Tables();
                Enregistrements enregistrements = new Enregistrements();
                int maxid = 0;
                try
                {
                    if (tables.IsTableRelated(Table7Id))
                    {
                        if (tables.GetParentTableId(Table7Id) == Table6Id)
                        {
                            enregistrements.Add(Table7Id, lbMessage.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", Enregistrement6Id);
                            maxid = enregistrements.GetMaxId();
                        }
                    }
                    else
                    {
                        enregistrements.Add(Table7Id, lbMessage.Text, "", "", "", "", "", "", "", "", "", "", 0, "", 0, "", 0);
                        maxid = enregistrements.GetMaxId();
                    }
                }
                catch
                {
                    throw;
                }

                Enregistrement7Id = maxid;
                Enregistrement7 = enregistrements.GetName(Enregistrement7Id);
                Etape = "Fin";
                Gestion_Etapes();
                return;
            }
        }

        private void btIgnorer_Click(object sender, EventArgs e)
        {
            if (Etape == "Camion")
            {
                CamionId = 0;
                Etape = "Firme";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Firme")
            {
                FirmeId = 0;
                Etape = "Chauffeur";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Chauffeur")
            {
                ChauffeurId = 0;
                Etape = "Transporteur";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Transporteur")
            {
                TransporteurId = 0;
                Etape = "Produit";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Walterre")
            {
                //Rien
            }

            if (Etape == "Produit")
            {
                ProduitId = 0;
                Etape = "Client";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Client")
            {
                ClientId = 0;
                Etape = "Table1";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table1")
            {
                Enregistrement1Id = 0;
                Enregistrement1 = "";
                Etape = "Table2";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table2")
            {
                Enregistrement2Id = 0;
                Enregistrement2 = "";
                Etape = "Table3";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table3")
            {
                Enregistrement3Id = 0;
                Enregistrement3 = "";
                Etape = "Table4";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table4")
            {
                Enregistrement4Id = 0;
                Enregistrement4 = "";
                Etape = "Table5";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table5")
            {

                Enregistrement5Id = 0;
                Enregistrement5 = "";
                Etape = "Table6";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table6")
            {

                Enregistrement6Id = 0;
                Enregistrement6 = "";
                Etape = "Table7";
                Gestion_Etapes();
                return;
            }

            if (Etape == "Table7")
            {
                Enregistrement7Id = 0;
                Enregistrement7 = "";
                Etape = "ChampLibre1";
                Gestion_Etapes();
                return;
            }

            if (Etape == "ChampLibre1")
            {
                ChampLibreName1 = "";
                ChampLibre1 = "";
                Etape = "ChampLibre2";
                Gestion_Etapes();
                return;
            }

            if (Etape == "ChampLibre2")
            {
                ChampLibreName2 = "";
                ChampLibre2 = "";
                Etape = "ChampLibre3";
                Gestion_Etapes();
                return;
            }

            if (Etape == "ChampLibre3")
            {
                ChampLibreName3 = "";
                ChampLibre3 = "";
                Etape = "ChampLibre4";
                Gestion_Etapes();
                return;
            }

            if (Etape == "ChampLibre4")
            {
                ChampLibreName4 = "";
                ChampLibre4 = "";
                Etape = "Fin";
                Gestion_Etapes();
                return;
            }
        }

        private void btRecherche_Click(object sender, EventArgs e)
        {
            panelClavier.Visible = true;
        }

        private void Borne_PremierePesee_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
