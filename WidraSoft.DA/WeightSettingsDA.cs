using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidraSoft.DA
{
    public class WeightSettingsDA
    {
        public string connString = ConnStrings.MainDb;
        SqlConnection conn = new SqlConnection();
        DataTable dt = new DataTable();

        public DataTable List(string filter)
        {
            String sql = "SELECT * FROM WEIGHT_SETTINGS WHERE " + filter;
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
            String sql = "SELECT * FROM WEIGHT_SETTINGS WHERE DESIGNATION LIKE '%" + filter + "%'";
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
            String sql = "SELECT * FROM WEIGHT_SETTINGS WHERE WEIGHT_SETTINGSID=" + Id;
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

            String sql = "SELECT DESIGNATION FROM WEIGHT_SETTINGS WHERE WEIGHT_SETTINGSID=" + Id;
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

        public void Add(String Designation, Int32 TimerInterval, Int32 LongueurMinChaine, Int32 PositionDebut, Int32 LongueurChaine,
                        String CaractereSeparation, String ModeLecture, Int32 Stabilite, Int32 PositionStabilite, String ValeurStable, Int32 Negatif,
                        Int32 PositionNegatif,  String ValeurNegatif)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_ADD_WEIGHT_SETTINGS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DESIGNATION", SqlDbType.VarChar).Value = Designation;
                cmd.Parameters.Add("@TIMERINTERVAL", SqlDbType.Int).Value = TimerInterval;
                cmd.Parameters.Add("@LONGUEURMINCHAINE", SqlDbType.Int).Value = LongueurMinChaine;
                cmd.Parameters.Add("@POSITIONDEBUT", SqlDbType.Int).Value = PositionDebut;
                cmd.Parameters.Add("@LONGUEURCHAINE", SqlDbType.Int).Value = LongueurChaine;
                cmd.Parameters.Add("@CARACTERESEPARATION", SqlDbType.VarChar).Value = CaractereSeparation;
                cmd.Parameters.Add("@MODELECTURE", SqlDbType.VarChar).Value = ModeLecture;
                cmd.Parameters.Add("@STABILITE", SqlDbType.Int).Value = Stabilite;
                cmd.Parameters.Add("@POSITIONSTABILTE", SqlDbType.Int).Value = PositionStabilite;
                cmd.Parameters.Add("@VALEURSTABLE", SqlDbType.VarChar).Value = ValeurStable;
                cmd.Parameters.Add("@NEGATIF", SqlDbType.Int).Value = Negatif;
                cmd.Parameters.Add("@POSITIONNEGATIF", SqlDbType.Int).Value = PositionNegatif;
                cmd.Parameters.Add("@VALEURNEGATIF", SqlDbType.VarChar).Value = ValeurNegatif;
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

        public void Update(Int32 Id, String Designation, Int32 TimerInterval, Int32 LongueurMinChaine, Int32 PositionDebut, Int32 LongueurChaine,
                        String CaractereSeparation, String ModeLecture, Int32 Stabilite, Int32 PositionStabilite, String ValeurStable, Int32 Negatif,
                        Int32 PositionNegatif, String ValeurNegatif)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_UPDATE_WEIGHT_SETTINGS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@DESIGNATION", SqlDbType.VarChar).Value = Designation;
                cmd.Parameters.Add("@TIMERINTERVAL", SqlDbType.Int).Value = TimerInterval;
                cmd.Parameters.Add("@LONGUEURMINCHAINE", SqlDbType.Int).Value = LongueurMinChaine;
                cmd.Parameters.Add("@POSITIONDEBUT", SqlDbType.Int).Value = PositionDebut;
                cmd.Parameters.Add("@LONGUEURCHAINE", SqlDbType.Int).Value = LongueurChaine;
                cmd.Parameters.Add("@CARACTERESEPARATION", SqlDbType.VarChar).Value = CaractereSeparation;
                cmd.Parameters.Add("@MODELECTURE", SqlDbType.VarChar).Value = ModeLecture;
                cmd.Parameters.Add("@STABILITE", SqlDbType.Int).Value = Stabilite;
                cmd.Parameters.Add("@POSITIONSTABILTE", SqlDbType.Int).Value = PositionStabilite;
                cmd.Parameters.Add("@VALEURSTABLE", SqlDbType.VarChar).Value = ValeurStable;
                cmd.Parameters.Add("@NEGATIF", SqlDbType.Int).Value = Negatif;
                cmd.Parameters.Add("@POSITIONNEGATIF", SqlDbType.Int).Value = PositionNegatif;
                cmd.Parameters.Add("@VALEURNEGATIF", SqlDbType.VarChar).Value = ValeurNegatif;
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
                SqlCommand cmd = new SqlCommand("PS_DELETE_WEIGHT_SETTINGS", conn);
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
