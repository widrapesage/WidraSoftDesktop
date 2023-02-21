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
            String sql = "SELECT * FROM VW_PESEEPB WHERE " + filter;
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
                "OR PRODUIT LIKE '%" + filter + "%' OR CLIENT LIKE '%" + filter + "%'";
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
            String sql = "SELECT * FROM VW_PESEEPB WHERE ETATPESEE='En cours' ORDER BY PESEEPBID DESC";
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

        public void Add(String TypePesee, String Flux, Int32 PontId, Int32 FirmeId, Int32 CamionId, Int32 ChauffeurId, Int32 TransporteurId, Int32 ProduitId, Int32 ClientId, Int32 ProvenanceId, Int32 DestinationId,
                        Int32 Poids1, DateTime DateHeurePoids1, Int32 Poids2, DateTime DateHeurePoids2, Int32 PoidsNet, String UserInfo, String EtatPesee)
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
                cmd.Parameters.Add("@FIRMEID", SqlDbType.Int).Value = FirmeId;
                cmd.Parameters.Add("@CAMIONID", SqlDbType.Int).Value = CamionId;
                cmd.Parameters.Add("@CHAUFFEURID", SqlDbType.Int).Value = ChauffeurId;
                cmd.Parameters.Add("@TRANSPORTEURID", SqlDbType.Int).Value = TransporteurId;
                cmd.Parameters.Add("@PRODUITID", SqlDbType.Int).Value = ProduitId;
                cmd.Parameters.Add("@CLIENTID", SqlDbType.Int).Value = ClientId;
                cmd.Parameters.Add("@PROVENANCEID", SqlDbType.Int).Value = ProvenanceId;
                cmd.Parameters.Add("@DESTINATIONID", SqlDbType.Int).Value = DestinationId;
                cmd.Parameters.Add("@POIDS1", SqlDbType.Int).Value = Poids1;
                cmd.Parameters.Add("@DATEHEUREPOIDS1", SqlDbType.DateTime).Value = DateHeurePoids1;
                cmd.Parameters.Add("@POIDS2", SqlDbType.Int).Value = Poids2;
                cmd.Parameters.Add("@DATEHEUREPOIDS2", SqlDbType.DateTime).Value = DateHeurePoids2;
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

        public void Update(Int32 Id, String TypePesee, String Flux, Int32 PontId, Int32 FirmeId, Int32 CamionId, Int32 ChauffeurId, Int32 TransporteurId, Int32 ProduitId, Int32 ClientId, Int32 ProvenanceId, Int32 DestinationId,
                        Int32 Poids1, DateTime DateHeurePoids1, Int32 Poids2, DateTime DateHeurePoids2, Int32 PoidsNet, String UserInfo, String EtatPesee)
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
                cmd.Parameters.Add("@FIRMEID", SqlDbType.Int).Value = FirmeId;
                cmd.Parameters.Add("@CAMIONID", SqlDbType.Int).Value = CamionId;
                cmd.Parameters.Add("@CHAUFFEURID", SqlDbType.Int).Value = ChauffeurId;
                cmd.Parameters.Add("@TRANSPORTEURID", SqlDbType.Int).Value = TransporteurId;
                cmd.Parameters.Add("@PRODUITID", SqlDbType.Int).Value = ProduitId;
                cmd.Parameters.Add("@CLIENTID", SqlDbType.Int).Value = ClientId;
                cmd.Parameters.Add("@PROVENANCEID", SqlDbType.Int).Value = ProvenanceId;
                cmd.Parameters.Add("@DESTINATIONID", SqlDbType.Int).Value = DestinationId;
                cmd.Parameters.Add("@POIDS1", SqlDbType.Int).Value = Poids1;
                cmd.Parameters.Add("@DATEHEUREPOIDS1", SqlDbType.DateTime).Value = DateHeurePoids1;
                cmd.Parameters.Add("@POIDS2", SqlDbType.Int).Value = Poids2;
                cmd.Parameters.Add("@DATEHEUREPOIDS2", SqlDbType.DateTime).Value = DateHeurePoids2;
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
