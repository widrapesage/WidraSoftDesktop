using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidraSoft.DA
{
    public class ProduitDA
    {
        public string connString = ConnStrings.MainDb;
        SqlConnection conn = new SqlConnection();
        DataTable dt = new DataTable();

        public DataTable List(string filter)
        {
            String sql = "SELECT * FROM PRODUIT WHERE " + filter;
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
            String sql = "SELECT * FROM PRODUIT WHERE DESIGNATION LIKE '%" + filter + "%'";
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
            String sql = "SELECT * FROM PRODUIT WHERE PRODUITID=" + Id;
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
            String sql = "SELECT COUNT(*) FROM PRODUIT WHERE DESIGNATION='" + Name + "'";
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

            String sql = "SELECT DESIGNATION FROM PRODUIT WHERE PRODUITID=" + Id;
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

        public int GetMaxId()
        {

            String sql = "SELECT MAX(PRODUITID) FROM PRODUIT";
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

        public void Add(String Designation, Int32 GroupeProduitId, Int32 EstEntrant, Int32 EstSortant, Int32 Valide,
           Int32 PoidsAlerteMin, Int32 ActiverAlerteMin, Int32 PoidsAlerteMax, Int32 ActiverAlerteMax, Int32 EmpecherTicketSiAlerte,
           Int32 Dechet, Int32 TypeDechetId)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_ADD_PRODUIT", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DESIGNATION", SqlDbType.VarChar).Value = Designation;
                cmd.Parameters.Add("@GROUPEPRODUITID", SqlDbType.Int).Value = GroupeProduitId;
                cmd.Parameters.Add("@ESTENTRANT", SqlDbType.Int).Value = EstEntrant;
                cmd.Parameters.Add("@ESTSORTANT", SqlDbType.Int).Value = EstSortant;
                cmd.Parameters.Add("@VALIDE", SqlDbType.Int).Value = Valide;
                cmd.Parameters.Add("@POIDSALERTEMIN", SqlDbType.Int).Value = PoidsAlerteMin;
                cmd.Parameters.Add("@ACTIVERALERTEMIN", SqlDbType.Int).Value = ActiverAlerteMin;
                cmd.Parameters.Add("@POIDSALERTEMAX", SqlDbType.Int).Value = PoidsAlerteMax;
                cmd.Parameters.Add("@ACTIVERALERTEMAX", SqlDbType.Int).Value = ActiverAlerteMax;
                cmd.Parameters.Add("@EMPECHERTICKETSIALERTE", SqlDbType.Int).Value = EmpecherTicketSiAlerte;
                cmd.Parameters.Add("@DECHET", SqlDbType.Int).Value = Dechet;
                cmd.Parameters.Add("@TYPEDECHETID", SqlDbType.Int).Value = TypeDechetId;
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

        public void Update(Int32 Id, String Designation, Int32 GroupeProduitId, Int32 EstEntrant, Int32 EstSortant, Int32 Valide,
           Int32 PoidsAlerteMin, Int32 ActiverAlerteMin, Int32 PoidsAlerteMax, Int32 ActiverAlerteMax, Int32 EmpecherTicketSiAlerte,
           Int32 Dechet, Int32 TypeDechetId)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_UPDATE_PRODUIT", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@DESIGNATION", SqlDbType.VarChar).Value = Designation;
                cmd.Parameters.Add("@GROUPEPRODUITID", SqlDbType.Int).Value = GroupeProduitId;
                cmd.Parameters.Add("@ESTENTRANT", SqlDbType.Int).Value = EstEntrant;
                cmd.Parameters.Add("@ESTSORTANT", SqlDbType.Int).Value = EstSortant;
                cmd.Parameters.Add("@VALIDE", SqlDbType.Int).Value = Valide;
                cmd.Parameters.Add("@POIDSALERTEMIN", SqlDbType.Int).Value = PoidsAlerteMin;
                cmd.Parameters.Add("@ACTIVERALERTEMIN", SqlDbType.Int).Value = ActiverAlerteMin;
                cmd.Parameters.Add("@POIDSALERTEMAX", SqlDbType.Int).Value = PoidsAlerteMax;
                cmd.Parameters.Add("@ACTIVERALERTEMAX", SqlDbType.Int).Value = ActiverAlerteMax;
                cmd.Parameters.Add("@EMPECHERTICKETSIALERTE", SqlDbType.Int).Value = EmpecherTicketSiAlerte;
                cmd.Parameters.Add("@DECHET", SqlDbType.Int).Value = Dechet;
                cmd.Parameters.Add("@TYPEDECHETID", SqlDbType.Int).Value = TypeDechetId;
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
                SqlCommand cmd = new SqlCommand("PS_DELETE_PRODUIT", conn);
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
