using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace WidraSoft.DA
{
    public class UtilisateurDA
    {
        public string connString = ConnStrings.MainDb;
        SqlConnection conn = new SqlConnection();
        DataTable dt = new DataTable(); 

        public DataTable List()
        {
            String sql = "SELECT * FROM  VW_UTILISATEUR";
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
            String sql = "SELECT * FROM  VW_UTILISATEUR WHERE UTILISATEURID=" + Id;
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

       public Boolean CanConnect(string Login, string Password)
        {
            String sql = "SELECT utilisateurid FROM VW_UTILISATEUR WHERE Login='" + Login + "' AND Password='" + Password +"'";
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;

             }
            catch
            {
                throw;
            }
        }

        public Int32 GetUserIdByLoginAndPassword(string Login, string Password)
        {
            String sql = "SELECT utilisateurid FROM VW_UTILISATEUR WHERE Login='" + Login + "' AND Password='" + Password + "'";
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                Int32 Id = (Int32)cmd.ExecuteScalar();
                return Id;
            }
            catch
            {
                throw;
            }
        }
        public string GetFullUsername(Int32 Id)
        {
     
                String sql = "SELECT prenom + ' ' + nom FROM VW_UTILISATEUR WHERE UtilisateurId=" + Id ;
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    String username = (string)cmd.ExecuteScalar();
                    return username;
                }
                catch
                {
                    throw;
                }
        }
        public void Add(string Nom, string Prenom, string Login, string Password, Int16 IsAdmin, Int16 PontDefaultId, DateTime DateCreation, DateTime DateInvalide, String Profil, String PeseeManuel)
        {
            String sql = "INSERT INTO UTILISATEUR (Nom,Prenom,Login,Password,IsAdmin,PontDefaultId,DateCreation,DateInvalide,Profil,PeseeManuel) VALUES ('"+Nom+"','"+Prenom+"','"+Login+"','"+Password+"',"+IsAdmin+","+PontDefaultId+",'"+DateCreation+"','"+DateInvalide+"','"+Profil+"','"+PeseeManuel+"')";
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

