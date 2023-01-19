using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WidraSoft.DA
{
    public class GroupeModuleDA
    {
        public string connString = ConnStrings.MainDb;
        SqlConnection conn = new SqlConnection();
        DataTable dt = new DataTable();

        public DataTable List()
        {
            String sql = "SELECT * FROM GROUPEMODULE";
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

        public DataTable FindAuthorizedModulesByGroupeId(Int32 Id)
        {
            String sql = "SELECT gm.MODULEID, m.DESIGNATION, gm.TYPEACESS FROM MODULE m, GROUPEMODULE gm WHERE gm.MODULEID = m.MODULEID AND gm.GROUPEID=" + Id ;
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

        public DataTable FindNonAuthorizedModulesByGroupeId(Int32 Id)
        {
            String sql = "SELECT MODULEID,DESIGNATION FROM MODULE WHERE MODULEID NOT IN (SELECT MODULEID FROM GROUPEMODULE WHERE GROUPEID=" + Id + ")";
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

        public DataTable FindByGroupeId(Int32 Id)
        {
            String sql = "SELECT * FROM GROUPEMODULE WHERE GROUPEID=" + Id;
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

        public DataTable FindByModuleId(Int32 Id)
        {
            String sql = "SELECT * FROM GROUPEMODULE WHERE MODULEID=" + Id;
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

        public int Get_Max_Id()
        {
            String sql = "SELECT ISNULL(MAX(GROUPEMODULEID),0) FROM GROUPEMODULE";
            int max = 0;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                max = (int)cmd.ExecuteScalar();
            }
            catch
            {
                throw;
            }
            return max;
        }
        public void Add(Int32 GroupeId, Int32 ModuleId, Int32 Access, String TypeAcess)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_ADD_GROUPEMODULE", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GROUPEID", SqlDbType.Int).Value = GroupeId;
                cmd.Parameters.Add("@MODULEID", SqlDbType.Int).Value = ModuleId;
                cmd.Parameters.Add("@ACCES", SqlDbType.Int).Value = Access;
                cmd.Parameters.Add("@TYPEACESS", SqlDbType.VarChar).Value = TypeAcess;

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

        public void Update(Int32 Id, Int32 GroupeId, Int32 ModuleId, Int32 Access, String TypeAcess)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_UPDATE_GROUPEMODULE", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@GROUPEID", SqlDbType.Int).Value = GroupeId;
                cmd.Parameters.Add("@MODULEID", SqlDbType.Int).Value = ModuleId;
                cmd.Parameters.Add("@ACCES", SqlDbType.Int).Value = Access;
                cmd.Parameters.Add("@TYPEACESS", SqlDbType.VarChar).Value = TypeAcess;

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
                SqlCommand cmd = new SqlCommand("PS_DELETE_GROUPEMODULE", conn);
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
