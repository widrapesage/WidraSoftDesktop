using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidraSoft.DA
{
    public class WeighingSettingsDA
    {
        public string connString = ConnStrings.MainDb;
        SqlConnection conn = new SqlConnection();
        DataTable dt = new DataTable();

        public DataTable List(string filter)
        {
            String sql = "SELECT * FROM WEIGHING_SETTINGS WHERE " + filter;
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
            String sql = "SELECT * FROM WEIGHING_SETTINGS WHERE DESIGNATION LIKE '%" + filter + "%'";
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
            String sql = "SELECT * FROM WEIGHING_SETTINGS WHERE WEIGHING_SETTINGSID=" + Id;
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

            String sql = "SELECT DESIGNATION FROM WEIGHING_SETTINGS WHERE WEIGHING_SETTINGSID=" + Id;
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

        public void Add(String Designation, Int32 Camion, Int32 Chauffeur, Int32 Transporteur, Int32 Produit, Int32 Client, Int32 Destination, Int32 Provenance)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_ADD_WEIGHING_SETTINGS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DESIGNATION", SqlDbType.VarChar).Value = Designation;
                cmd.Parameters.Add("@CAMION", SqlDbType.Int).Value = Camion;
                cmd.Parameters.Add("@CHAUFFEUR", SqlDbType.Int).Value = Chauffeur;
                cmd.Parameters.Add("@TRANSPORTEUR", SqlDbType.Int).Value = Transporteur;
                cmd.Parameters.Add("@PRODUIT", SqlDbType.Int).Value = Produit;
                cmd.Parameters.Add("@CLIENT", SqlDbType.Int).Value = Client;
                cmd.Parameters.Add("@DESTINATION", SqlDbType.Int).Value = Destination;
                cmd.Parameters.Add("@PROVENANCE", SqlDbType.Int).Value = Provenance;
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

        public void Update(Int32 Id,String Designation, Int32 Camion, Int32 Chauffeur, Int32 Transporteur, Int32 Produit, Int32 Client, Int32 Destination, Int32 Provenance)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_UPDATE_WEIGHING_SETTINGS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@DESIGNATION", SqlDbType.VarChar).Value = Designation;
                cmd.Parameters.Add("@CAMION", SqlDbType.Int).Value = Camion;
                cmd.Parameters.Add("@CHAUFFEUR", SqlDbType.Int).Value = Chauffeur;
                cmd.Parameters.Add("@TRANSPORTEUR", SqlDbType.Int).Value = Transporteur;
                cmd.Parameters.Add("@PRODUIT", SqlDbType.Int).Value = Produit;
                cmd.Parameters.Add("@CLIENT", SqlDbType.Int).Value = Client;
                cmd.Parameters.Add("@DESTINATION", SqlDbType.Int).Value = Destination;
                cmd.Parameters.Add("@PROVENANCE", SqlDbType.Int).Value = Provenance;
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
                SqlCommand cmd = new SqlCommand("PS_DELETE_WEIGHING_SETTINGS", conn);
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
