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

        public DataTable List(string filter)
        {
            String sql = "SELECT * FROM VW_UTILISATEUR WHERE " + filter ;
            conn.ConnectionString = connString;
            using (conn)
            {
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
           
        }

        public DataTable FindById(Int32 Id)
        {
            String sql = "SELECT * FROM UTILISATEUR WHERE UTILISATEURID=" + Id;
            conn.ConnectionString = connString;
            using (conn)
            {
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
            
        }

       public Boolean CanConnect(string Login, string Password)
        {
            String sql = "SELECT utilisateurid FROM UTILISATEUR WHERE Login='" + Login + "' AND Password='" + Password +"'";
            conn.ConnectionString = connString;
            using (conn)
            {
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
        }
           

        public Int32 GetUserIdByLoginAndPassword(string Login, string Password)
        {
            String sql = "SELECT utilisateurid FROM UTILISATEUR WHERE Login='" + Login + "' AND Password='" + Password + "'";
            conn.ConnectionString = connString;
            using (conn)
            {
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
 
        }
        public string GetFullUsername(Int32 Id)
        {
     
                String sql = "SELECT prenom + ' ' + nom FROM UTILISATEUR WHERE UtilisateurId=" + Id ;
                conn.ConnectionString = connString;
            using (conn)
            {
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
                
        }
        
        public void Add(string Nom, string Prenom, string Login, string Password, Int32 GroupeId)
        {

            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_ADD_UTILISATEUR", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NOM", SqlDbType.VarChar).Value = Nom ;
                cmd.Parameters.Add("@PRENOM", SqlDbType.VarChar).Value = Prenom;
                cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar).Value = Login;
                cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = Password;
                cmd.Parameters.Add("@GROUPEID", SqlDbType.Int).Value = GroupeId;

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

        public void Update(Int32 Id,string Nom, string Prenom, string Login, string Password, Int32 GroupeId)
        {

            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_UPDATE_UTILISATEUR", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@NOM", SqlDbType.VarChar).Value = Nom;
                cmd.Parameters.Add("@PRENOM", SqlDbType.VarChar).Value = Prenom;
                cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar).Value = Login;
                cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = Password;
                cmd.Parameters.Add("@GROUPEID", SqlDbType.Int).Value = GroupeId;

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
                SqlCommand cmd = new SqlCommand("PS_DELETE_UTILISATEUR", conn);
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

