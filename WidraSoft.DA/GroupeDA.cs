using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WidraSoft.DA
{
    public class GroupeDA
    {
        public string connString = ConnStrings.MainDb;
        SqlConnection conn = new SqlConnection();
        DataTable dt = new DataTable();

        public DataTable List()
        {
            String sql = "SELECT * FROM GROUPE";
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
            String sql = "SELECT * FROM GROUPE WHERE GROUPEID=" + Id;
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

            String sql = "SELECT DESIGNATION FROM GROUPE WHERE GroupeId=" + Id;
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

        public void Add(String Designation,String Code, Int32 Limiter, Int32 NbLimite)
        {
            String sql = "INSERT INTO GROUPE (Designation,Code,Limiter,NbLimite) VALUES ('" + Designation + "','" + Code + "'," + Limiter + "," + NbLimite +")";
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
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
