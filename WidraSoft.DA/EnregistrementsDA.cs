using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidraSoft.DA
{
    public class EnregistrementsDA
    {
        public string connString = ConnStrings.MainDb;
        SqlConnection conn = new SqlConnection();
        DataTable dt = new DataTable();

        public DataTable List(string filter)
        {
            String sql = "SELECT * FROM ENREGISTREMENTS WHERE " + filter;
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

        public DataTable SearchBox(string filter, Int32 TablesId)
        {
            String sql = "SELECT * FROM ENREGISTREMENTS WHERE NOM LIKE '%" + filter + "%' AND TABLESID=" + TablesId;
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
            String sql = "SELECT * FROM ENREGISTREMENTS WHERE ENREGISTREMENTSID=" + Id;
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

        public bool IfExists(String Name, Int32 TablesId, Int32 ParentId)
        {
            String sql;
            if (ParentId == 0)
                sql = "SELECT COUNT(*) FROM ENREGISTREMENTS WHERE NOM='" + Name + "' AND TABLESID=" + TablesId;
            else
                sql = "SELECT COUNT(*) FROM ENREGISTREMENTS WHERE NOM='" + Name + "' AND TABLESID=" + TablesId + " AND PARENTID=" + ParentId;
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

        public bool IfExistsWithCode(String Name, Int32 TablesId, Int32 ParentId)
        {
            String sql;
            if (ParentId == 0)
                sql = "SELECT COUNT(*) FROM ENREGISTREMENTS WHERE NOM + ' (' + CODE + ')'='" + Name + "' AND TABLESID=" + TablesId;
            else
                sql = "SELECT COUNT(*) FROM ENREGISTREMENTS WHERE NOM + ' (' + CODE + ')'='" + Name + "' AND TABLESID=" + TablesId + " AND PARENTID=" + ParentId;
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



        public DataTable FindByTableId(Int32 Id)
        {
            String sql = "SELECT * FROM ENREGISTREMENTS WHERE TABLESID=" + Id;
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

        public DataTable FindByTableIdAndParentId(Int32 TablesId, Int32 ParentId)
        {
            String sql = "SELECT * FROM ENREGISTREMENTS WHERE TABLESID=" + TablesId + " AND PARENTID=" + ParentId;
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

        public DataTable SearchBoxWithParentId(string filter, Int32 TablesId, Int32 ParentId)
        {
            String sql = "SELECT * FROM ENREGISTREMENTS WHERE NOM LIKE '%" + filter + "%' AND TABLESID=" + TablesId + " AND PARENTID=" + ParentId;
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

            String sql = "SELECT NOM FROM ENREGISTREMENTS WHERE ENREGISTREMENTSID=" + Id;
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

        public string GetCode(Int32 Id)
        {

            String sql = "SELECT CODE FROM ENREGISTREMENTS WHERE ENREGISTREMENTSID=" + Id;
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

            String sql = "SELECT MAX(ENREGISTREMENTSID) FROM ENREGISTREMENTS";
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

        public void Add(Int32 TablesId, String Nom, String Code,String Adresse, String CodePostal, String Localite, String Pays,
            String Telephone, String Email, String NumTVA, String SiteWeb_Url, String Observations,
            Int32 Bloque, String TexteBloque, Int32 Attention, String TexteAttention, Int32 ParentId)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_ADD_ENREGISTREMENTS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TABLESID", SqlDbType.Int).Value = TablesId;
                cmd.Parameters.Add("@NOM", SqlDbType.VarChar).Value = Nom;
                cmd.Parameters.Add("@CODE", SqlDbType.VarChar).Value = Code;
                cmd.Parameters.Add("@ADRESSE", SqlDbType.VarChar).Value = Adresse;
                cmd.Parameters.Add("@CODEPOSTAL", SqlDbType.VarChar).Value = CodePostal;
                cmd.Parameters.Add("@LOCALITE", SqlDbType.VarChar).Value = Localite;
                cmd.Parameters.Add("@PAYS", SqlDbType.VarChar).Value = Pays;
                cmd.Parameters.Add("@TELEPHONE", SqlDbType.VarChar).Value = Telephone;
                cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@NUMTVA", SqlDbType.VarChar).Value = NumTVA;
                cmd.Parameters.Add("@SITEWEB_URL", SqlDbType.VarChar).Value = SiteWeb_Url;
                cmd.Parameters.Add("@OBSERVATIONS", SqlDbType.VarChar).Value = Observations;
                cmd.Parameters.Add("@BLOQUE", SqlDbType.Int).Value = Bloque;
                cmd.Parameters.Add("@TEXTEBLOQUE", SqlDbType.VarChar).Value = TexteBloque;
                cmd.Parameters.Add("@ATTENTION", SqlDbType.Int).Value = Attention;
                cmd.Parameters.Add("@TEXTEATTENTION", SqlDbType.VarChar).Value = TexteAttention;
                cmd.Parameters.Add("@PARENTID", SqlDbType.Int).Value = ParentId;

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

        public void Update(Int32 Id, Int32 TablesId, String Nom, String Code, String Adresse, String CodePostal, String Localite, String Pays,
            String Telephone, String Email, String NumTVA, String SiteWeb_Url, String Observations,
            Int32 Bloque, String TexteBloque, Int32 Attention, String TexteAttention, Int32 ParentId)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_UPDATE_ENREGISTREMENTS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@TABLESID", SqlDbType.Int).Value = TablesId;
                cmd.Parameters.Add("@NOM", SqlDbType.VarChar).Value = Nom;
                cmd.Parameters.Add("@CODE", SqlDbType.VarChar).Value = Code;
                cmd.Parameters.Add("@ADRESSE", SqlDbType.VarChar).Value = Adresse;
                cmd.Parameters.Add("@CODEPOSTAL", SqlDbType.VarChar).Value = CodePostal;
                cmd.Parameters.Add("@LOCALITE", SqlDbType.VarChar).Value = Localite;
                cmd.Parameters.Add("@PAYS", SqlDbType.VarChar).Value = Pays;
                cmd.Parameters.Add("@TELEPHONE", SqlDbType.VarChar).Value = Telephone;
                cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@NUMTVA", SqlDbType.VarChar).Value = NumTVA;
                cmd.Parameters.Add("@SITEWEB_URL", SqlDbType.VarChar).Value = SiteWeb_Url;
                cmd.Parameters.Add("@OBSERVATIONS", SqlDbType.VarChar).Value = Observations;
                cmd.Parameters.Add("@BLOQUE", SqlDbType.Int).Value = Bloque;
                cmd.Parameters.Add("@TEXTEBLOQUE", SqlDbType.VarChar).Value = TexteBloque;
                cmd.Parameters.Add("@ATTENTION", SqlDbType.Int).Value = Attention;
                cmd.Parameters.Add("@TEXTEATTENTION", SqlDbType.VarChar).Value = TexteAttention;
                cmd.Parameters.Add("@PARENTID", SqlDbType.Int).Value = ParentId;

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
                SqlCommand cmd = new SqlCommand("PS_DELETE_ENREGISTREMENTS", conn);
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
