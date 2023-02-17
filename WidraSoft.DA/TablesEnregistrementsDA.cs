using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidraSoft.DA
{
    public class TablesEnregistrementsDA
    {
        public string connString = ConnStrings.MainDb;
        SqlConnection conn = new SqlConnection();
        DataTable dt = new DataTable();

        public DataTable List()
        {
            String sql = "SELECT te.TABLESID, T.NOM AS TABLES, te.ENREGISTREMENTSID, e.NOM AS ENREGISTREMENT, te.DATECREATION FROM TABLES_ENREGISTREMENTS te, TABLES t, ENREGISTREMENTS e WHERE te.TABLESID = t.TABLESID AND te.ENREGISTREMENTSID = e.ENREGISTREMENTSID";
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

        public DataTable FindNonLinkedRecordsByTableId(Int32 Id)
        {
            String sql = "SELECT ENREGISTREMENTSID,NOM FROM ENREGISTREMENTS WHERE ENREGISTREMENTSID NOT IN (SELECT ENREGISTREMENTSID FROM TABLES_ENREGISTREMENTS WHERE TABLESID=" + Id + ")";
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

        public DataTable FindByTablesId(Int32 Id)
        {
            String sql = "SELECT te.ENREGISTREMENTSID, e.NOM AS ENREGISTREMENT, te.TABLESID, T.NOM AS TABLES, te.DATECREATION FROM TABLES_ENREGISTREMENTS te, TABLES t, ENREGISTREMENTS e WHERE te.TABLESID = t.TABLESID AND te.ENREGISTREMENTSID = e.ENREGISTREMENTSID AND te.TABLESID=" + Id;
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

        public DataTable FindByEnregistrementsId(Int32 Id)
        {
            String sql = "SELECT te.TABLESID, T.NOM AS TABLES, te.ENREGISTREMENTSID, e.NOM AS ENREGISTREMENT, te.DATECREATION FROM TABLES_ENREGISTREMENTS te, TABLES t, ENREGISTREMENTS e WHERE te.TABLESID = t.TABLESID AND te.ENREGISTREMENTSID = e.ENREGISTREMENTSID AND te.ENREGISTREMENTSID=" + Id;
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

        public void Add(Int32 TablesId, Int32 EnregistrementsId, Int32 EnregistrementParentId, Int32 Numero)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_ADD_TABLES_ENREGISTREMENTS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TABLESID", SqlDbType.Int).Value = TablesId;
                cmd.Parameters.Add("@ENREGISTREMENTSID", SqlDbType.Int).Value = EnregistrementsId;
                cmd.Parameters.Add("@ENREGISTREMENTPARENTID", SqlDbType.Int).Value = EnregistrementParentId;
                cmd.Parameters.Add("@NUMERO", SqlDbType.Int).Value = Numero;


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

        public void Delete(Int32 TablesId, Int32 EnregistrementsId)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_DELETE_TABLES_ENREGISTREMENTS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TABLESID", SqlDbType.Int).Value = TablesId;
                cmd.Parameters.Add("@ENREGISTREMENTSID", SqlDbType.Int).Value = EnregistrementsId;

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
