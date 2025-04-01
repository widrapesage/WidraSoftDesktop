using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidraSoft.DA
{
    public class TablesDA
    {
        public string connString = ConnStrings.MainDb;
        SqlConnection conn = new SqlConnection();
        DataTable dt = new DataTable();

        public DataTable List(string filter)
        {
            String sql = "SELECT * FROM TABLES WHERE " + filter;
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
            String sql = "SELECT * FROM TABLES WHERE NOM LIKE '%" + filter + "%'";
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
            String sql = "SELECT * FROM TABLES WHERE TABLESID=" + Id;
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

        public DataTable FindExceptId(Int32 Id)
        {
            String sql = "SELECT * FROM TABLES WHERE TABLESID<>" + Id;
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

        public string GetName(Int32 Id)
        {

            String sql = "SELECT NOM FROM TABLES WHERE TABLESID=" + Id;
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

        public bool IsTableRelated(Int32 TablesId)
        {
            String sql = "SELECT TABLEPARENTID FROM TABLES WHERE TABLESID=" + TablesId;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                Int32 Id = (int)cmd.ExecuteScalar();
                if (Id > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        public int GetParentTableId(Int32 TablesId)
        {
            String sql = "SELECT TABLEPARENTID FROM TABLES WHERE TABLESID=" + TablesId;
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

        public void Add(String Nom, Int32 InclureDansPesee, Int32 InclureDansTicket, Int32 EstEntrant, Int32 EstSortant, Int32 TableParentId, String Observations)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_ADD_TABLES", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NOM", SqlDbType.VarChar).Value = Nom;
                cmd.Parameters.Add("@INCLUREDANSPESEE", SqlDbType.Int).Value = InclureDansPesee;
                cmd.Parameters.Add("@INCLUREDANSTICKET", SqlDbType.Int).Value = InclureDansTicket;
                cmd.Parameters.Add("@ESTENTRANT", SqlDbType.Int).Value = EstEntrant;
                cmd.Parameters.Add("@ESTSORTANT", SqlDbType.Int).Value = EstSortant;
                cmd.Parameters.Add("@TABLEPARENTID", SqlDbType.Int).Value = TableParentId;
                cmd.Parameters.Add("@OBSERVATIONS", SqlDbType.VarChar).Value = Observations;
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

        public void Update(Int32 Id, String Nom, Int32 InclureDansPesee, Int32 InclureDansTicket, Int32 EstEntrant, Int32 EstSortant, Int32 TableParentId, String Observations)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_UPDATE_TABLES", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@NOM", SqlDbType.VarChar).Value = Nom;
                cmd.Parameters.Add("@INCLUREDANSPESEE", SqlDbType.Int).Value = InclureDansPesee;
                cmd.Parameters.Add("@INCLUREDANSTICKET", SqlDbType.Int).Value = InclureDansTicket;
                cmd.Parameters.Add("@ESTENTRANT", SqlDbType.Int).Value = EstEntrant;
                cmd.Parameters.Add("@ESTSORTANT", SqlDbType.Int).Value = EstSortant;
                cmd.Parameters.Add("@TABLEPARENTID", SqlDbType.Int).Value = TableParentId;
                cmd.Parameters.Add("@OBSERVATIONS", SqlDbType.VarChar).Value = Observations;
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
                SqlCommand cmd = new SqlCommand("PS_DELETE_TABLES", conn);
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
