using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidraSoft.DA
{
    public class PontDA
    {
        public string connString = ConnStrings.MainDb;
        SqlConnection conn = new SqlConnection();
        DataTable dt = new DataTable();

        public DataTable List(string filter)
        {
            String sql = "SELECT * FROM PONT WHERE " + filter;
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
            String sql = "SELECT * FROM PONT WHERE DESIGNATION LIKE '%" + filter + "%'";
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
            String sql = "SELECT * FROM PONT WHERE PONTID=" + Id;
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

        public DataTable FindByMachineName(String Name)
        {
            String sql = "SELECT * FROM PONT WHERE MACHINE='" + Name + "'";
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
            String sql = "SELECT COUNT(*) FROM PONT WHERE DESIGNATION='" + Name + "'";
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

        public bool IsMultipleParam(Int32 PontId)
        {
            String sql = "SELECT ACTIVER_MULTIPLE_PARAM FROM PONT WHERE PONTID=" + PontId;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                Int32 result = (int)cmd.ExecuteScalar();
                if (result == 1)
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

            String sql = "SELECT DESIGNATION FROM PONT WHERE PONTID=" + Id;
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

        public string GetCOM(Int32 Id)
        {

            String sql = "SELECT NUMPORTCOM FROM PONT WHERE PONTID=" + Id;
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

        public string GetFluxDefault(Int32 Id)
        {

            String sql = "SELECT FLUX_DEFAULT FROM PONT WHERE PONTID=" + Id;
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

        public Int32 GetWeightSettingsId(Int32 Id)
        {

            String sql = "SELECT WEIGHT_SETTINGSID FROM PONT WHERE PONTID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                Int32 WeightSettingsId = (Int32)cmd.ExecuteScalar();
                return WeightSettingsId;
            }
            catch
            {
                throw;
            }
        }

        public Int32 GetWeighingSettingsId(Int32 Id)
        {

            String sql = "SELECT WEIGHING_SETTINGSID FROM PONT WHERE PONTID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                Int32 WeighingSettingsId = (Int32)cmd.ExecuteScalar();
                return WeighingSettingsId;
            }
            catch
            {
                throw;
            }
        }

        public String GetCOMBarriere(Int32 Id)
        {

            String sql = "SELECT ISNULL(NUMPORTCOM_BARRIERE,'0') FROM PONT WHERE PONTID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                String com = cmd.ExecuteScalar().ToString();
                return com;
            }
            catch
            {
                throw;
            }
        }

        public String GetCOMScanner(Int32 Id)
        {

            String sql = "SELECT ISNULL(NUMPORTCOM_SCANNER,'0') FROM PONT WHERE PONTID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                String com = cmd.ExecuteScalar().ToString();
                return com;
            }
            catch
            {
                throw;
            }
        }

        public Boolean Borne_Autoriser_Premiere_Pesee(Int32 Id)
        {
            String sql = "SELECT BORNEPREMIEREPESEE FROM PONT WHERE PONTID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                String result = (string)cmd.ExecuteScalar();
                if (result == null || result == "")
                    return false;
                else if (result == "Yes")
                    return true;
                else return false;
            }
            catch
            {
                throw;
            }
        }

        public Boolean Borne_Autoriser_Deuxieme_Pesee(Int32 Id)
        {
            String sql = "SELECT BORNEDEUXIEMEPESEE FROM PONT WHERE PONTID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                String result = (string)cmd.ExecuteScalar();
                if (result == null || result == "")
                    return false;
                else if (result == "Yes")
                    return true;
                else return false;
            }
            catch
            {
                throw;
            }
        }

        public Boolean Borne_Autoriser_Tare_Manuelle(Int32 Id)
        {
            String sql = "SELECT BORNETAREMANUELLE FROM PONT WHERE PONTID=" + Id;
            conn.ConnectionString = connString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                String result = (string)cmd.ExecuteScalar();
                if (result == null || result == "")
                    return false;
                else if (result == "Yes")
                    return true;
                else return false;
            }
            catch
            {
                throw;
            }
        }


        public void Add(String Designation, String NumPortCOM, Int32 Weight_SettingsId, Int32 Weighing_SettingsId, Int32 ActiverPoids, Int32 BaudRate,
                        Int32 DataBits, String StopBits, String Handshake, Int32 ReadTimeOut, String Machine, String Demarrage, Int32 UtilisateurId, Int32 ActiverMultipleParam, Int32 Poids_Detection,
                        String BornePremierePesee, String BorneDeuxiemePesee, String BorneTareManuelle, String Flux_Default, Int32 Activer_Scanner, String TypeScanner, Int32 Activer_Barriere, String NumPortCom_Barriere, 
                        String NumPortCom_Scanner)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_ADD_PONT", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DESIGNATION", SqlDbType.VarChar).Value = Designation;
                cmd.Parameters.Add("@NUMPORTCOM", SqlDbType.VarChar).Value = NumPortCOM;
                cmd.Parameters.Add("@WEIGHT_SETTINGSID", SqlDbType.Int).Value = Weight_SettingsId;
                cmd.Parameters.Add("@WEIGHING_SETTINGSID", SqlDbType.Int).Value = Weighing_SettingsId;
                cmd.Parameters.Add("@ACTIVERPOIDS", SqlDbType.Int).Value = ActiverPoids;
                cmd.Parameters.Add("@BAUDRATE", SqlDbType.Int).Value = BaudRate;
                cmd.Parameters.Add("@DATABITS", SqlDbType.Int).Value = DataBits;
                cmd.Parameters.Add("@STOPBITS", SqlDbType.VarChar).Value = StopBits;
                cmd.Parameters.Add("@HANDSHAKE", SqlDbType.VarChar).Value = Handshake;
                cmd.Parameters.Add("@READTIMEOUT", SqlDbType.Int).Value = ReadTimeOut;
                cmd.Parameters.Add("@MACHINE", SqlDbType.VarChar).Value = Machine;
                cmd.Parameters.Add("@DEMARRAGE", SqlDbType.VarChar).Value = Demarrage;
                cmd.Parameters.Add("@UTILISATEURID", SqlDbType.Int).Value = UtilisateurId;
                cmd.Parameters.Add("@ACTIVER_MULTIPLE_PARAM", SqlDbType.Int).Value = ActiverMultipleParam;
                cmd.Parameters.Add("@POIDS_DETECTION", SqlDbType.Int).Value = Poids_Detection;
                cmd.Parameters.Add("@BORNEPREMIEREPESEE", SqlDbType.VarChar).Value = BornePremierePesee;
                cmd.Parameters.Add("@BORNEDEUXIEMEPESEE", SqlDbType.VarChar).Value = BorneDeuxiemePesee;
                cmd.Parameters.Add("@BORNETAREMANUELLE", SqlDbType.VarChar).Value = BorneTareManuelle;
                cmd.Parameters.Add("@FLUX_DEFAULT", SqlDbType.VarChar).Value = Flux_Default;
                cmd.Parameters.Add("@ACTIVER_SCANNER", SqlDbType.Int).Value = Activer_Scanner;
                cmd.Parameters.Add("@TYPESCANNER", SqlDbType.VarChar).Value = TypeScanner;
                cmd.Parameters.Add("@ACTIVER_BARRIERE", SqlDbType.Int).Value = Activer_Barriere;
                cmd.Parameters.Add("@NUMPORTCOM_BARRIERE", SqlDbType.VarChar).Value = NumPortCom_Barriere;
                cmd.Parameters.Add("@NUMPORTCOM_SCANNER", SqlDbType.VarChar).Value = NumPortCom_Scanner;
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

        public void Update(Int32 Id, String Designation, String NumPortCOM, Int32 Weight_SettingsId, Int32 Weighing_SettingsId, Int32 ActiverPoids, Int32 BaudRate,
                        Int32 DataBits, String StopBits, String Handshake, Int32 ReadTimeOut, String Machine, String Demarrage, Int32 UtilisateurId, Int32 ActiverMultipleParam, Int32 Poids_Detection,
                        String BornePremierePesee, String BorneDeuxiemePesee, String BorneTareManuelle, String Flux_Default, Int32 Activer_Scanner, String TypeScanner, Int32 Activer_Barriere, String NumPortCom_Barriere,
                        String NumPortCom_Scanner)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_UPDATE_PONT", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@DESIGNATION", SqlDbType.VarChar).Value = Designation;
                cmd.Parameters.Add("@NUMPORTCOM", SqlDbType.VarChar).Value = NumPortCOM;
                cmd.Parameters.Add("@WEIGHT_SETTINGSID", SqlDbType.Int).Value = Weight_SettingsId;
                cmd.Parameters.Add("@WEIGHING_SETTINGSID", SqlDbType.Int).Value = Weighing_SettingsId;
                cmd.Parameters.Add("@ACTIVERPOIDS", SqlDbType.Int).Value = ActiverPoids;
                cmd.Parameters.Add("@BAUDRATE", SqlDbType.Int).Value = BaudRate;
                cmd.Parameters.Add("@DATABITS", SqlDbType.Int).Value = DataBits;
                cmd.Parameters.Add("@STOPBITS", SqlDbType.VarChar).Value = StopBits;
                cmd.Parameters.Add("@HANDSHAKE", SqlDbType.VarChar).Value = Handshake;
                cmd.Parameters.Add("@READTIMEOUT", SqlDbType.Int).Value = ReadTimeOut;
                cmd.Parameters.Add("@MACHINE", SqlDbType.VarChar).Value = Machine;
                cmd.Parameters.Add("@DEMARRAGE", SqlDbType.VarChar).Value = Demarrage;
                cmd.Parameters.Add("@UTILISATEURID", SqlDbType.Int).Value = UtilisateurId;
                cmd.Parameters.Add("@ACTIVER_MULTIPLE_PARAM", SqlDbType.Int).Value = ActiverMultipleParam;
                cmd.Parameters.Add("@POIDS_DETECTION", SqlDbType.Int).Value = Poids_Detection;
                cmd.Parameters.Add("@BORNEPREMIEREPESEE", SqlDbType.VarChar).Value = BornePremierePesee;
                cmd.Parameters.Add("@BORNEDEUXIEMEPESEE", SqlDbType.VarChar).Value = BorneDeuxiemePesee;
                cmd.Parameters.Add("@BORNETAREMANUELLE", SqlDbType.VarChar).Value = BorneTareManuelle;
                cmd.Parameters.Add("@FLUX_DEFAULT", SqlDbType.VarChar).Value = Flux_Default;
                cmd.Parameters.Add("@ACTIVER_SCANNER", SqlDbType.Int).Value = Activer_Scanner;
                cmd.Parameters.Add("@TYPESCANNER", SqlDbType.VarChar).Value = TypeScanner;
                cmd.Parameters.Add("@ACTIVER_BARRIERE", SqlDbType.Int).Value = Activer_Barriere;
                cmd.Parameters.Add("@NUMPORTCOM_BARRIERE", SqlDbType.VarChar).Value = NumPortCom_Barriere;
                cmd.Parameters.Add("@NUMPORTCOM_SCANNER", SqlDbType.VarChar).Value = NumPortCom_Scanner;
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
                SqlCommand cmd = new SqlCommand("PS_DELETE_PONT", conn);
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
