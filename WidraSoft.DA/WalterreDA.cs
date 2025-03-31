using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace WidraSoft.DA
{
    public class WalterreDA
    {
        public string connString = ConnStrings.MainDb;
        SqlConnection conn = new SqlConnection();
        DataTable dt = new DataTable();

        public DataTable List(string filter)
        {
            String sql = "SELECT * FROM VW_WALTERRE WHERE " + filter;
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

        public DataTable List_Valid(string filter)
        {
            String sql = "SELECT * FROM VW_WALTERRE WHERE " + filter + " AND CLOTURE = 0";
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

        public DataTable List_Enlevements(string filter)
        {
            String sql = "SELECT * FROM VW_WALTERRE_PESEEPB WHERE " + filter;
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
            String sql = "SELECT * FROM VW_WALTERRE WHERE CODE LIKE '%" + filter + "%'";
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
            String sql = "SELECT * FROM WALTERRE WHERE WALTERREID=" + Id;
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

        public bool IsDepassementSeuilMaxAutorise(Int32 Id)
        {

            String sql = "SELECT ISNULL(DEPASSEMENT_SEUIL_MAX,0) FROM VW_WALTERRE WHERE WALTERREID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                int result = (int)cmd.ExecuteScalar();
                if (result == 0)
                    return false;
                else
                    return true;
            }
            catch
            {
                throw;
            }
        }

        public bool IsDepassementVolumeAutorise(Int32 Id)
        {

            String sql = "SELECT ISNULL(DEPASSEMENT,0) FROM VW_WALTERRE WHERE WALTERREID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                int result = (int)cmd.ExecuteScalar();
                if (result == 0)
                    return false;
                else
                    return true;
            }
            catch
            {
                throw;
            }
        }
        public DataTable FindEnlevementsById(Int32 Id)
        {
            String sql = "SELECT * FROM VW_WALTERRE_PESEEPB WHERE WALTERREID=" + Id;
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

        public decimal GetQteEnlevements(Int32 Id)
        {

            String sql = "SELECT ISNULL(QTE_ENLEVEMENTS,0) FROM VW_WALTERRE_PESEEPB WHERE WALTERREID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                decimal qte = (decimal)cmd.ExecuteScalar();
                return qte;
            }
            catch
            {
                throw;
            }
        }

        public decimal GetSeuilMax(Int32 Id)
        {

            String sql = "SELECT ISNULL(SEUIL_MAX,0) FROM VW_WALTERRE_PESEEPB WHERE WALTERREID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                decimal qte = (decimal)cmd.ExecuteScalar();
                return qte;
            }
            catch
            {
                throw;
            }
        }

        public decimal GetVolume(Int32 Id)
        {

            String sql = "SELECT ISNULL(VOLUME,0) FROM VW_WALTERRE_PESEEPB WHERE WALTERREID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                decimal qte = (decimal)cmd.ExecuteScalar();
                return qte;
            }
            catch
            {
                throw;
            }
        }
        public DataTable FindPeseePBById(Int32 Id)
        {
            String sql = "SELECT * FROM VW_PESEEPB WHERE WALTERREID=" + Id + " AND ETATPESEE='Complete' ORDER BY PESEEPBID DESC";
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

        public bool IfExists(String Name)
        {
            String sql = "SELECT COUNT(*) FROM WALTERRE WHERE CODE='" + Name + "'";
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                Int32 nb = (int)cmd.ExecuteScalar();
                if (nb > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        public bool IfExists_Valid(String Name)
        {
            String sql = "SELECT COUNT(*) FROM WALTERRE WHERE CODE='" + Name + "' AND CLOTURE = 0";
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                Int32 nb = (int)cmd.ExecuteScalar();
                if (nb > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        public string GetName(Int32 Id)
        {

            String sql = "SELECT CODE FROM WALTERRE WHERE WALTERREID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                String name = (string)cmd.ExecuteScalar();
                return name;
            }
            catch
            {
                throw;
            }
        }

        public int GetIdByName(string Name)
        {

            String sql = "SELECT WALTERREID FROM WALTERRE WHERE CODE='" + Name + "'";
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                int id = (int)cmd.ExecuteScalar();
                return id;
            }
            catch
            {
                throw;
            }
        }

        public void Add(String Code, Int32 ProduitId, Int32 ClientId, Decimal Volume, Decimal Seuil_Max,
           String Region, String Texte_Borne, String Observations, Int32 Depassement, Int32 Cloture, SqlDateTime DateCloture, String Status, Int32 Depassement_Seuil_Max, String Nom)
        {
            using (conn)
            {
                
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed) 
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_ADD_WALTERRE", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CODE", SqlDbType.VarChar).Value = Code;
                cmd.Parameters.Add("@PRODUITID", SqlDbType.Int).Value = ProduitId;
                cmd.Parameters.Add("@CLIENTID", SqlDbType.Int).Value = ClientId;
                cmd.Parameters.Add("@VOLUME", SqlDbType.Decimal).Value = Volume;
                cmd.Parameters.Add("@SEUIL_MAX", SqlDbType.Decimal).Value = Seuil_Max;
                cmd.Parameters.Add("@REGION", SqlDbType.VarChar).Value = Region;
                cmd.Parameters.Add("@TEXTE_BORNE", SqlDbType.VarChar).Value = Texte_Borne;
                cmd.Parameters.Add("@OBSERVATIONS", SqlDbType.VarChar).Value = Observations;
                cmd.Parameters.Add("@DEPASSEMENT", SqlDbType.Int).Value = Depassement;
                cmd.Parameters.Add("@CLOTURE", SqlDbType.Int).Value = Cloture;
                cmd.Parameters.Add("@DATECLOTURE", SqlDbType.DateTime).Value = DateCloture;
                cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = Status;
                cmd.Parameters.Add("@DEPASSEMENT_SEUIL_MAX", SqlDbType.Int).Value = Depassement_Seuil_Max;
                cmd.Parameters.Add("@NOM", SqlDbType.VarChar).Value = Nom;
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

        public void Update(Int32 Id, String Code, Int32 ProduitId, Int32 ClientId, Decimal Volume, Decimal Seuil_Max,
           String Region, String Texte_Borne, String Observations, Int32 Depassement, Int32 Cloture, SqlDateTime DateCloture, String Status, Int32 Depassement_Seuil_Max, String Nom)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_UPDATE_WALTERRE", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@CODE", SqlDbType.VarChar).Value = Code;
                cmd.Parameters.Add("@PRODUITID", SqlDbType.Int).Value = ProduitId;
                cmd.Parameters.Add("@CLIENTID", SqlDbType.Int).Value = ClientId;
                cmd.Parameters.Add("@VOLUME", SqlDbType.Decimal).Value = Volume;
                cmd.Parameters.Add("@SEUIL_MAX", SqlDbType.Decimal).Value = Seuil_Max;
                cmd.Parameters.Add("@REGION", SqlDbType.VarChar).Value = Region;
                cmd.Parameters.Add("@TEXTE_BORNE", SqlDbType.VarChar).Value = Texte_Borne;
                cmd.Parameters.Add("@OBSERVATIONS", SqlDbType.VarChar).Value = Observations;
                cmd.Parameters.Add("@DEPASSEMENT", SqlDbType.Int).Value = Depassement;
                cmd.Parameters.Add("@CLOTURE", SqlDbType.Int).Value = Cloture;
                cmd.Parameters.Add("@DATECLOTURE", SqlDbType.DateTime).Value = DateCloture;
                cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = Status;
                cmd.Parameters.Add("@DEPASSEMENT_SEUIL_MAX", SqlDbType.Int).Value = Depassement_Seuil_Max;
                cmd.Parameters.Add("@NOM", SqlDbType.VarChar).Value = Nom;
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
                SqlCommand cmd = new SqlCommand("PS_DELETE_WALTERRE", conn);
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
