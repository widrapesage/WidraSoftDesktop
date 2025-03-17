using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidraSoft.DA
{
    public class ClientDA
    {
        public string connString = ConnStrings.MainDb;
        SqlConnection conn = new SqlConnection();
        DataTable dt = new DataTable();

        public DataTable List(string filter)
        {
            String sql = "SELECT * FROM CLIENT WHERE " + filter;
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
            String sql = "SELECT * FROM CLIENT WHERE DESIGNATION LIKE '%" + filter + "%'";
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
            String sql = "SELECT * FROM CLIENT WHERE CLIENTID=" + Id;
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
            String sql = "SELECT COUNT(*) FROM CLIENT WHERE DESIGNATION='" + Name + "'";
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

            String sql = "SELECT DESIGNATION FROM CLIENT WHERE CLIENTID=" + Id;
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

            String sql = "SELECT MAX(CLIENTID) FROM CLIENT";
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

        public string GetBadge(Int32 Id)
        {

            String sql = "SELECT BADGE FROM CLIENT WHERE CLIENTID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                String name = (string)cmd.ExecuteScalar();
                name = name.PadLeft(6, '0');
                return name;
            }
            catch
            {
                throw;
            }
        }

        public int GetIdByBadge(string Name)
        {

            String sql = "SELECT CLIENTID FROM CLIENT WHERE BADGE='" + Name + "'";
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

        public int CountByBadge(string Name)
        {

            String sql = "SELECT COUNT(*) FROM CLIENT WHERE BADGE='" + Name + "'";
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                int nb = (int)cmd.ExecuteScalar();
                return nb;
            }
            catch
            {
                throw;
            }
        }

        public void Add(String Badge, String Designation, Int32 TypeClientId, String Adresse, String CodePostal, String Localite, String Pays,
            String Telephone, String Email, String NumTVA, String SiteWeb_Url, String Observations,
            Int32 Valide, Int32 Bloque, String TexteBloque, Int32 Attention, String TexteAttention)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_ADD_CLIENT", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BADGE", SqlDbType.VarChar).Value = Badge;
                cmd.Parameters.Add("@DESIGNATION", SqlDbType.VarChar).Value = Designation;
                cmd.Parameters.Add("@TYPECLIENTID", SqlDbType.Int).Value = TypeClientId;
                cmd.Parameters.Add("@ADRESSE", SqlDbType.VarChar).Value = Adresse;
                cmd.Parameters.Add("@CODEPOSTAL", SqlDbType.VarChar).Value = CodePostal;
                cmd.Parameters.Add("@LOCALITE", SqlDbType.VarChar).Value = Localite;
                cmd.Parameters.Add("@PAYS", SqlDbType.VarChar).Value = Pays;
                cmd.Parameters.Add("@TELEPHONE", SqlDbType.VarChar).Value = Telephone;
                cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@NUMTVA", SqlDbType.VarChar).Value = NumTVA;
                cmd.Parameters.Add("@SITEWEB_URL", SqlDbType.VarChar).Value = SiteWeb_Url;
                cmd.Parameters.Add("@OBSERVATIONS", SqlDbType.VarChar).Value = Observations;
                cmd.Parameters.Add("@VALIDE", SqlDbType.Int).Value = Valide;
                cmd.Parameters.Add("@BLOQUE", SqlDbType.Int).Value = Bloque;
                cmd.Parameters.Add("@TEXTEBLOQUE", SqlDbType.VarChar).Value = TexteBloque;
                cmd.Parameters.Add("@ATTENTION", SqlDbType.Int).Value = Attention;
                cmd.Parameters.Add("@TEXTEATTENTION", SqlDbType.VarChar).Value = TexteAttention;

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

        public void Update(Int32 Id, String Badge, String Designation, Int32 TypeClientId, String Adresse, String CodePostal,
            String Localite, String Pays, String Telephone,
            String Email, String NumTVA, String SiteWeb_Url, String Observations,
            Int32 Valide, Int32 Bloque, String TexteBloque, Int32 Attention, String TexteAttention)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_UPDATE_CLIENT", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@BADGE", SqlDbType.VarChar).Value = Badge;
                cmd.Parameters.Add("@DESIGNATION", SqlDbType.VarChar).Value = Designation;
                cmd.Parameters.Add("@TYPECLIENTID", SqlDbType.Int).Value = TypeClientId;
                cmd.Parameters.Add("@ADRESSE", SqlDbType.VarChar).Value = Adresse;
                cmd.Parameters.Add("@CODEPOSTAL", SqlDbType.VarChar).Value = CodePostal;
                cmd.Parameters.Add("@LOCALITE", SqlDbType.VarChar).Value = Localite;
                cmd.Parameters.Add("@PAYS", SqlDbType.VarChar).Value = Pays;
                cmd.Parameters.Add("@TELEPHONE", SqlDbType.VarChar).Value = Telephone;
                cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@NUMTVA", SqlDbType.VarChar).Value = NumTVA;
                cmd.Parameters.Add("@SITEWEB_URL", SqlDbType.VarChar).Value = SiteWeb_Url;
                cmd.Parameters.Add("@OBSERVATIONS", SqlDbType.VarChar).Value = Observations;
                cmd.Parameters.Add("@VALIDE", SqlDbType.Int).Value = Valide;
                cmd.Parameters.Add("@BLOQUE", SqlDbType.Int).Value = Bloque;
                cmd.Parameters.Add("@TEXTEBLOQUE", SqlDbType.VarChar).Value = TexteBloque;
                cmd.Parameters.Add("@ATTENTION", SqlDbType.Int).Value = Attention;
                cmd.Parameters.Add("@TEXTEATTENTION", SqlDbType.VarChar).Value = TexteAttention;

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
                SqlCommand cmd = new SqlCommand("PS_DELETE_CLIENT", conn);
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
