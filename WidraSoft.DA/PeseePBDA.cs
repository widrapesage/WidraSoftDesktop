using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidraSoft.DA
{
    public class PeseePBDA
    {
        public string connString = ConnStrings.MainDb;
        SqlConnection conn = new SqlConnection();
        DataTable dt = new DataTable();

        public DataTable List(string filter)
        {
            String sql = "SELECT * FROM VW_PESEEPB WHERE " + filter + " ORDER BY PESEEPBID DESC";
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                return dt;
            }
            catch
            {
                throw;
            }
        }

       

        public DataTable SearchBox(string filter)
        {
            String sql = "SELECT * FROM VW_PESEEPB WHERE PONT LIKE '%" + filter + "%' OR FIRME LIKE '%" + filter + "%' OR CAMION LIKE '%" + filter + "%' OR CHAUFFEUR LIKE '%" + filter + "%' OR TRANSPORTEUR LIKE '%" + filter + "%' " +
                "OR PRODUIT LIKE '%" + filter + "%' OR CLIENT LIKE '%" + filter + "%' AND ETATPESEE='Pending'";
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                return dt;
            }
            catch
            {
                throw;
            }
        }

        public DataTable SearchBoxPending(string filter)
        {
            String sql = "SELECT * FROM VW_PESEEPB_PENDING WHERE CAMION LIKE '%" + filter + "%' OR PRODUIT LIKE '%" + filter + "%' OR PESEEPBID LIKE '%" + filter + "%'";
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                return dt;
            }
            catch
            {
                throw;
            }
        }

        public int GetCountPendingByFilter(string filter)
        {
            String sql = "SELECT COUNT(*) FROM VW_PESEEPB_PENDING WHERE " + filter;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                Int32 Id = (int)cmd.ExecuteScalar();
                return Id;
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindById(Int32 Id)
        {
            String sql = "SELECT * FROM VW_PESEEPB WHERE PESEEPBID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                return dt;
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindWeighingsInProgress()
        {
            String sql = "SELECT * FROM VW_PESEEPB_PENDING ORDER BY PESEEPBID DESC";
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                return dt;
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindWeighingsInProgressById(Int32 Id)
        {
            String sql = "SELECT * FROM VW_PESEEPB_PENDING WHERE PESEEPBID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                return dt;
            }
            catch
            {
                throw;
            }
        }

        public Int32 GetMaxIdByPontId(Int32 Id)
        {
            String sql = "SELECT MAX(PESEEPBID) FROM PESEEPB WHERE PONTID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                Int32 WeighingSettingsId = (Int32)cmd.ExecuteScalar();
                return WeighingSettingsId;
            }
            catch
            {
                throw;
            }
        }

        public Int32 GetPoids2ById(Int32 Id)
        {
            String sql = "SELECT POIDS2 FROM PESEEPB WHERE PESEEPBID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                Int32 Poids2 = (Int32)cmd.ExecuteScalar();
                return Poids2;
            }
            catch
            {
                throw;
            }
        }

        public Int32 GetWalterreIdById(Int32 Id)
        {
            String sql = "SELECT WALTERREID FROM PESEEPB WHERE PESEEPBID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                Int32 result = (Int32)cmd.ExecuteScalar();
                return result;
            }
            catch
            {
                throw;
            }
        }
        public String GetShortResume(Int32 Id)
        {
            String sql = "SELECT CONCAT(CAMION, ' ', DATEHEUREPOIDS2, '  ', POIDS2 , ' Kg  ',  PRODUIT ) FROM VW_PESEEPB WHERE PESEEPBID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                String Resume = (String)cmd.ExecuteScalar();
                return Resume;
            }
            catch
            {
                throw;
            }
        }

        public void Add(String TypePesee, String Flux, Int32 PontId, Int32 WeighingSettingsId, Int32 FirmeId, Int32 CamionId, Int32 ChauffeurId, Int32 TransporteurId, Int32 ProduitId, Int32 ClientId, Int32 EnregistrementsId1,
            Int32 TablesId1, String TablesName1, String Enregistrements1, Int32 EnregistrementsId2, Int32 TablesId2, String TablesName2, String Enregistrements2, Int32 EnregistrementsId3, Int32 TablesId3, String TablesName3, String Enregistrements3,
            Int32 EnregistrementsId4, Int32 TablesId4, String TablesName4, String Enregistrements4, Int32 EnregistrementsId5, Int32 TablesId5, String TablesName5, String Enregistrements5, Int32 EnregistrementsId6, Int32 TablesId6, String TablesName6, String Enregistrements6,
            Int32 EnregistrementsId7, Int32 TablesId7, String TablesName7, String Enregistrements7,
            Int32 Poids1, DateTime DateHeurePoids1, Int32 Poids2, DateTime DateHeurePoids2, Int32 PoidsNet, String UserInfo, String EtatPesee, String ChampLibreName1, String ChampLibre1, String ChampLibreName2, String ChampLibre2, String ChampLibreName3, String ChampLibre3,
            String ChampLibreName4, String ChampLibre4, Int32 WalterreId)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_ADD_PESEEPB", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TYPEPESEE", SqlDbType.VarChar).Value = TypePesee;
                cmd.Parameters.Add("@FLUX", SqlDbType.VarChar).Value = Flux;
                cmd.Parameters.Add("@PONTID", SqlDbType.Int).Value = PontId;
                cmd.Parameters.Add("@WEIGHING_SETTINGSID", SqlDbType.Int).Value = WeighingSettingsId;
                cmd.Parameters.Add("@FIRMEID", SqlDbType.Int).Value = FirmeId;
                cmd.Parameters.Add("@CAMIONID", SqlDbType.Int).Value = CamionId;
                cmd.Parameters.Add("@CHAUFFEURID", SqlDbType.Int).Value = ChauffeurId;
                cmd.Parameters.Add("@TRANSPORTEURID", SqlDbType.Int).Value = TransporteurId;
                cmd.Parameters.Add("@PRODUITID", SqlDbType.Int).Value = ProduitId;
                cmd.Parameters.Add("@CLIENTID", SqlDbType.Int).Value = ClientId;
                cmd.Parameters.Add("@ENREGISTREMENTSID1", SqlDbType.Int).Value = EnregistrementsId1;
                cmd.Parameters.Add("@TABLESID1", SqlDbType.Int).Value = TablesId1;
                cmd.Parameters.Add("@TABLESNAME1", SqlDbType.VarChar).Value = TablesName1;
                cmd.Parameters.Add("@ENREGISTREMENTS1", SqlDbType.VarChar).Value = Enregistrements1;
                cmd.Parameters.Add("@ENREGISTREMENTSID2", SqlDbType.Int).Value = EnregistrementsId2;
                cmd.Parameters.Add("@TABLESID2", SqlDbType.Int).Value = TablesId2;
                cmd.Parameters.Add("@TABLESNAME2", SqlDbType.VarChar).Value = TablesName2;
                cmd.Parameters.Add("@ENREGISTREMENTS2", SqlDbType.VarChar).Value = Enregistrements2;
                cmd.Parameters.Add("@ENREGISTREMENTSID3", SqlDbType.Int).Value = EnregistrementsId3;
                cmd.Parameters.Add("@TABLESID3", SqlDbType.Int).Value = TablesId3;
                cmd.Parameters.Add("@TABLESNAME3", SqlDbType.VarChar).Value = TablesName3;
                cmd.Parameters.Add("@ENREGISTREMENTS3", SqlDbType.VarChar).Value = Enregistrements3;
                cmd.Parameters.Add("@ENREGISTREMENTSID4", SqlDbType.Int).Value = EnregistrementsId4;
                cmd.Parameters.Add("@TABLESID4", SqlDbType.Int).Value = TablesId4;
                cmd.Parameters.Add("@TABLESNAME4", SqlDbType.VarChar).Value = TablesName4;
                cmd.Parameters.Add("@ENREGISTREMENTS4", SqlDbType.VarChar).Value = Enregistrements4;
                cmd.Parameters.Add("@ENREGISTREMENTSID5", SqlDbType.Int).Value = EnregistrementsId5;
                cmd.Parameters.Add("@TABLESID5", SqlDbType.Int).Value = TablesId5;
                cmd.Parameters.Add("@TABLESNAME5", SqlDbType.VarChar).Value = TablesName5;
                cmd.Parameters.Add("@ENREGISTREMENTS5", SqlDbType.VarChar).Value = Enregistrements5;
                cmd.Parameters.Add("@ENREGISTREMENTSID6", SqlDbType.Int).Value = EnregistrementsId6;
                cmd.Parameters.Add("@TABLESID6", SqlDbType.Int).Value = TablesId6;
                cmd.Parameters.Add("@TABLESNAME6", SqlDbType.VarChar).Value = TablesName6;
                cmd.Parameters.Add("@ENREGISTREMENTS6", SqlDbType.VarChar).Value = Enregistrements6;
                cmd.Parameters.Add("@ENREGISTREMENTSID7", SqlDbType.Int).Value = EnregistrementsId7;
                cmd.Parameters.Add("@TABLESID7", SqlDbType.Int).Value = TablesId7;
                cmd.Parameters.Add("@TABLESNAME7", SqlDbType.VarChar).Value = TablesName7;
                cmd.Parameters.Add("@ENREGISTREMENTS7", SqlDbType.VarChar).Value = Enregistrements7;
                cmd.Parameters.Add("@POIDS1", SqlDbType.Int).Value = Poids1;
                cmd.Parameters.Add("@DATEHEUREPOIDS1", SqlDbType.DateTime).Value = DateHeurePoids1;
                cmd.Parameters.Add("@POIDS2", SqlDbType.Int).Value = Poids2;
                cmd.Parameters.Add("@DATEHEUREPOIDS2", SqlDbType.DateTime).Value = DateHeurePoids2;
                cmd.Parameters.Add("@POIDSNET", SqlDbType.Int).Value = PoidsNet;
                cmd.Parameters.Add("@USER_INFO", SqlDbType.VarChar).Value = UserInfo;
                cmd.Parameters.Add("@ETATPESEE", SqlDbType.VarChar).Value = EtatPesee;
                cmd.Parameters.Add("@CHAMPLIBRENAME1", SqlDbType.VarChar).Value = ChampLibreName1;
                cmd.Parameters.Add("@CHAMPLIBRE1", SqlDbType.VarChar).Value = ChampLibre1;
                cmd.Parameters.Add("@CHAMPLIBRENAME2", SqlDbType.VarChar).Value = ChampLibreName2;
                cmd.Parameters.Add("@CHAMPLIBRE2", SqlDbType.VarChar).Value = ChampLibre2;
                cmd.Parameters.Add("@CHAMPLIBRENAME3", SqlDbType.VarChar).Value = ChampLibreName3;
                cmd.Parameters.Add("@CHAMPLIBRE3", SqlDbType.VarChar).Value = ChampLibre3;
                cmd.Parameters.Add("@CHAMPLIBRENAME4", SqlDbType.VarChar).Value = ChampLibreName4;
                cmd.Parameters.Add("@CHAMPLIBRE4", SqlDbType.VarChar).Value = ChampLibre4;
                cmd.Parameters.Add("@WALTERREID", SqlDbType.Int).Value = WalterreId;
                
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }

        public void Update(Int32 Id, String TypePesee, String Flux, Int32 PontId, Int32 WeighingSettingsId, Int32 FirmeId, Int32 CamionId, Int32 ChauffeurId, Int32 TransporteurId, Int32 ProduitId, Int32 ClientId, Int32 EnregistrementsId1,
            Int32 TablesId1, String TablesName1, String Enregistrements1, Int32 EnregistrementsId2, Int32 TablesId2, String TablesName2, String Enregistrements2, Int32 EnregistrementsId3, Int32 TablesId3, String TablesName3, String Enregistrements3,
            Int32 EnregistrementsId4, Int32 TablesId4, String TablesName4, String Enregistrements4, Int32 EnregistrementsId5, Int32 TablesId5, String TablesName5, String Enregistrements5, Int32 EnregistrementsId6, Int32 TablesId6, String TablesName6, String Enregistrements6,
            Int32 EnregistrementsId7, Int32 TablesId7, String TablesName7, String Enregistrements7,
            Int32 Poids1, DateTime DateHeurePoids1, Int32 Poids2, DateTime DateHeurePoids2, Int32 PoidsNet, String UserInfo, String EtatPesee, String ChampLibreName1, String ChampLibre1, String ChampLibreName2, String ChampLibre2, String ChampLibreName3, String ChampLibre3,
            String ChampLibreName4, String ChampLibre4, Int32 WalterreId)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_UPDATE_PESEEPB", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@TYPEPESEE", SqlDbType.VarChar).Value = TypePesee;
                cmd.Parameters.Add("@FLUX", SqlDbType.VarChar).Value = Flux;
                cmd.Parameters.Add("@PONTID", SqlDbType.Int).Value = PontId;
                cmd.Parameters.Add("@WEIGHING_SETTINGSID", SqlDbType.Int).Value = WeighingSettingsId;
                cmd.Parameters.Add("@FIRMEID", SqlDbType.Int).Value = FirmeId;
                cmd.Parameters.Add("@CAMIONID", SqlDbType.Int).Value = CamionId;
                cmd.Parameters.Add("@CHAUFFEURID", SqlDbType.Int).Value = ChauffeurId;
                cmd.Parameters.Add("@TRANSPORTEURID", SqlDbType.Int).Value = TransporteurId;
                cmd.Parameters.Add("@PRODUITID", SqlDbType.Int).Value = ProduitId;
                cmd.Parameters.Add("@CLIENTID", SqlDbType.Int).Value = ClientId;
                cmd.Parameters.Add("@ENREGISTREMENTSID1", SqlDbType.Int).Value = EnregistrementsId1;
                cmd.Parameters.Add("@TABLESID1", SqlDbType.Int).Value = TablesId1;
                cmd.Parameters.Add("@TABLESNAME1", SqlDbType.VarChar).Value = TablesName1;
                cmd.Parameters.Add("@ENREGISTREMENTS1", SqlDbType.VarChar).Value = Enregistrements1;
                cmd.Parameters.Add("@ENREGISTREMENTSID2", SqlDbType.Int).Value = EnregistrementsId2;
                cmd.Parameters.Add("@TABLESID2", SqlDbType.Int).Value = TablesId2;
                cmd.Parameters.Add("@TABLESNAME2", SqlDbType.VarChar).Value = TablesName2;
                cmd.Parameters.Add("@ENREGISTREMENTS2", SqlDbType.VarChar).Value = Enregistrements2;
                cmd.Parameters.Add("@ENREGISTREMENTSID3", SqlDbType.Int).Value = EnregistrementsId3;
                cmd.Parameters.Add("@TABLESID3", SqlDbType.Int).Value = TablesId3;
                cmd.Parameters.Add("@TABLESNAME3", SqlDbType.VarChar).Value = TablesName3;
                cmd.Parameters.Add("@ENREGISTREMENTS3", SqlDbType.VarChar).Value = Enregistrements3;
                cmd.Parameters.Add("@ENREGISTREMENTSID4", SqlDbType.Int).Value = EnregistrementsId4;
                cmd.Parameters.Add("@TABLESID4", SqlDbType.Int).Value = TablesId4;
                cmd.Parameters.Add("@TABLESNAME4", SqlDbType.VarChar).Value = TablesName4;
                cmd.Parameters.Add("@ENREGISTREMENTS4", SqlDbType.VarChar).Value = Enregistrements4;
                cmd.Parameters.Add("@ENREGISTREMENTSID5", SqlDbType.Int).Value = EnregistrementsId5;
                cmd.Parameters.Add("@TABLESID5", SqlDbType.Int).Value = TablesId5;
                cmd.Parameters.Add("@TABLESNAME5", SqlDbType.VarChar).Value = TablesName5;
                cmd.Parameters.Add("@ENREGISTREMENTS5", SqlDbType.VarChar).Value = Enregistrements5;
                cmd.Parameters.Add("@ENREGISTREMENTSID6", SqlDbType.Int).Value = EnregistrementsId6;
                cmd.Parameters.Add("@TABLESID6", SqlDbType.Int).Value = TablesId6;
                cmd.Parameters.Add("@TABLESNAME6", SqlDbType.VarChar).Value = TablesName6;
                cmd.Parameters.Add("@ENREGISTREMENTS6", SqlDbType.VarChar).Value = Enregistrements6;
                cmd.Parameters.Add("@ENREGISTREMENTSID7", SqlDbType.Int).Value = EnregistrementsId7;
                cmd.Parameters.Add("@TABLESID7", SqlDbType.Int).Value = TablesId7;
                cmd.Parameters.Add("@TABLESNAME7", SqlDbType.VarChar).Value = TablesName7;
                cmd.Parameters.Add("@ENREGISTREMENTS7", SqlDbType.VarChar).Value = Enregistrements7;
                cmd.Parameters.Add("@POIDS1", SqlDbType.Int).Value = Poids1;
                cmd.Parameters.Add("@DATEHEUREPOIDS1", SqlDbType.DateTime).Value = DateHeurePoids1;
                cmd.Parameters.Add("@POIDS2", SqlDbType.Int).Value = Poids2;
                cmd.Parameters.Add("@DATEHEUREPOIDS2", SqlDbType.DateTime).Value = DateHeurePoids2;
                cmd.Parameters.Add("@POIDSNET", SqlDbType.Int).Value = PoidsNet;
                cmd.Parameters.Add("@USER_INFO", SqlDbType.VarChar).Value = UserInfo;
                cmd.Parameters.Add("@ETATPESEE", SqlDbType.VarChar).Value = EtatPesee;
                cmd.Parameters.Add("@CHAMPLIBRENAME1", SqlDbType.VarChar).Value = ChampLibreName1;
                cmd.Parameters.Add("@CHAMPLIBRE1", SqlDbType.VarChar).Value = ChampLibre1;
                cmd.Parameters.Add("@CHAMPLIBRENAME2", SqlDbType.VarChar).Value = ChampLibreName2;
                cmd.Parameters.Add("@CHAMPLIBRE2", SqlDbType.VarChar).Value = ChampLibre2;
                cmd.Parameters.Add("@CHAMPLIBRENAME3", SqlDbType.VarChar).Value = ChampLibreName3;
                cmd.Parameters.Add("@CHAMPLIBRE3", SqlDbType.VarChar).Value = ChampLibre3;
                cmd.Parameters.Add("@CHAMPLIBRENAME4", SqlDbType.VarChar).Value = ChampLibreName4;
                cmd.Parameters.Add("@CHAMPLIBRE4", SqlDbType.VarChar).Value = ChampLibre4;
                cmd.Parameters.Add("@WALTERREID", SqlDbType.Int).Value = WalterreId;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }

        public void Update_Borne(Int32 Id, Int32 Poids1, DateTime DateHeurePoids1, Int32 PoidsNet, String UserInfo, String EtatPesee)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_UPDATE_PESEEPB_BORNE", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;               
                cmd.Parameters.Add("@POIDS1", SqlDbType.Int).Value = Poids1;
                cmd.Parameters.Add("@DATEHEUREPOIDS1", SqlDbType.DateTime).Value = DateHeurePoids1;
                cmd.Parameters.Add("@POIDSNET", SqlDbType.Int).Value = PoidsNet;
                cmd.Parameters.Add("@USER_INFO", SqlDbType.VarChar).Value = UserInfo;
                cmd.Parameters.Add("@ETATPESEE", SqlDbType.VarChar).Value = EtatPesee;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }

        public void Update_UI(Int32 Id, String Flux, Int32 FirmeId, Int32 CamionId, Int32 ChauffeurId, Int32 TransporteurId, Int32 ProduitId, Int32 ClientId, Int32 EnregistrementsId1,
            Int32 TablesId1, String TablesName1, String Enregistrements1, Int32 EnregistrementsId2, Int32 TablesId2, String TablesName2, String Enregistrements2, Int32 EnregistrementsId3, Int32 TablesId3, String TablesName3, String Enregistrements3,
            Int32 EnregistrementsId4, Int32 TablesId4, String TablesName4, String Enregistrements4, Int32 EnregistrementsId5, Int32 TablesId5, String TablesName5, String Enregistrements5, Int32 EnregistrementsId6, Int32 TablesId6, String TablesName6, String Enregistrements6,
            Int32 EnregistrementsId7, Int32 TablesId7, String TablesName7, String Enregistrements7,
            String ChampLibreName1, String ChampLibre1, String ChampLibreName2, String ChampLibre2, String ChampLibreName3, String ChampLibre3, String ChampLibreName4, String ChampLibre4, Int32 WalterreId)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_UPDATE_PESEEPB_UI", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@FLUX", SqlDbType.VarChar).Value = Flux;
                cmd.Parameters.Add("@FIRMEID", SqlDbType.Int).Value = FirmeId;
                cmd.Parameters.Add("@CAMIONID", SqlDbType.Int).Value = CamionId;
                cmd.Parameters.Add("@CHAUFFEURID", SqlDbType.Int).Value = ChauffeurId;
                cmd.Parameters.Add("@TRANSPORTEURID", SqlDbType.Int).Value = TransporteurId;
                cmd.Parameters.Add("@PRODUITID", SqlDbType.Int).Value = ProduitId;
                cmd.Parameters.Add("@CLIENTID", SqlDbType.Int).Value = ClientId;
                cmd.Parameters.Add("@ENREGISTREMENTSID1", SqlDbType.Int).Value = EnregistrementsId1;
                cmd.Parameters.Add("@TABLESID1", SqlDbType.Int).Value = TablesId1;
                cmd.Parameters.Add("@TABLESNAME1", SqlDbType.VarChar).Value = TablesName1;
                cmd.Parameters.Add("@ENREGISTREMENTS1", SqlDbType.VarChar).Value = Enregistrements1;
                cmd.Parameters.Add("@ENREGISTREMENTSID2", SqlDbType.Int).Value = EnregistrementsId2;
                cmd.Parameters.Add("@TABLESID2", SqlDbType.Int).Value = TablesId2;
                cmd.Parameters.Add("@TABLESNAME2", SqlDbType.VarChar).Value = TablesName2;
                cmd.Parameters.Add("@ENREGISTREMENTS2", SqlDbType.VarChar).Value = Enregistrements2;
                cmd.Parameters.Add("@ENREGISTREMENTSID3", SqlDbType.Int).Value = EnregistrementsId3;
                cmd.Parameters.Add("@TABLESID3", SqlDbType.Int).Value = TablesId3;
                cmd.Parameters.Add("@TABLESNAME3", SqlDbType.VarChar).Value = TablesName3;
                cmd.Parameters.Add("@ENREGISTREMENTS3", SqlDbType.VarChar).Value = Enregistrements3;
                cmd.Parameters.Add("@ENREGISTREMENTSID4", SqlDbType.Int).Value = EnregistrementsId4;
                cmd.Parameters.Add("@TABLESID4", SqlDbType.Int).Value = TablesId4;
                cmd.Parameters.Add("@TABLESNAME4", SqlDbType.VarChar).Value = TablesName4;
                cmd.Parameters.Add("@ENREGISTREMENTS4", SqlDbType.VarChar).Value = Enregistrements4;
                cmd.Parameters.Add("@ENREGISTREMENTSID5", SqlDbType.Int).Value = EnregistrementsId5;
                cmd.Parameters.Add("@TABLESID5", SqlDbType.Int).Value = TablesId5;
                cmd.Parameters.Add("@TABLESNAME5", SqlDbType.VarChar).Value = TablesName5;
                cmd.Parameters.Add("@ENREGISTREMENTS5", SqlDbType.VarChar).Value = Enregistrements5;
                cmd.Parameters.Add("@ENREGISTREMENTSID6", SqlDbType.Int).Value = EnregistrementsId6;
                cmd.Parameters.Add("@TABLESID6", SqlDbType.Int).Value = TablesId6;
                cmd.Parameters.Add("@TABLESNAME6", SqlDbType.VarChar).Value = TablesName6;
                cmd.Parameters.Add("@ENREGISTREMENTS6", SqlDbType.VarChar).Value = Enregistrements6;
                cmd.Parameters.Add("@ENREGISTREMENTSID7", SqlDbType.Int).Value = EnregistrementsId7;
                cmd.Parameters.Add("@TABLESID7", SqlDbType.Int).Value = TablesId7;
                cmd.Parameters.Add("@TABLESNAME7", SqlDbType.VarChar).Value = TablesName7;
                cmd.Parameters.Add("@ENREGISTREMENTS7", SqlDbType.VarChar).Value = Enregistrements7;
                cmd.Parameters.Add("@CHAMPLIBRENAME1", SqlDbType.VarChar).Value = ChampLibreName1;
                cmd.Parameters.Add("@CHAMPLIBRE1", SqlDbType.VarChar).Value = ChampLibre1;
                cmd.Parameters.Add("@CHAMPLIBRENAME2", SqlDbType.VarChar).Value = ChampLibreName2;
                cmd.Parameters.Add("@CHAMPLIBRE2", SqlDbType.VarChar).Value = ChampLibre2;
                cmd.Parameters.Add("@CHAMPLIBRENAME3", SqlDbType.VarChar).Value = ChampLibreName3;
                cmd.Parameters.Add("@CHAMPLIBRE3", SqlDbType.VarChar).Value = ChampLibre3;
                cmd.Parameters.Add("@CHAMPLIBRENAME4", SqlDbType.VarChar).Value = ChampLibreName4;
                cmd.Parameters.Add("@CHAMPLIBRE4", SqlDbType.VarChar).Value = ChampLibre4;
                cmd.Parameters.Add("@WALTERREID", SqlDbType.Int).Value = WalterreId;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }

        public void Delete(Int32 Id)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_DELETE_PESEEPB", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }

            }
        }

    }
}
