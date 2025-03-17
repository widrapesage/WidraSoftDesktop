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

        public void Add(String Code, Int32 ProduitId, Int32 ClientId, Decimal Volume, Decimal Seuil_Max,
           String Region, String Texte_Borne, String Observations, Int32 Depassement, Int32 Cloture, SqlDateTime DateCloture, String Status)
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
           String Region, String Texte_Borne, String Observations, Int32 Depassement, Int32 Cloture, SqlDateTime DateCloture, String Status)
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
