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

       

        public void Add(String Designation, String NumPortCOM, Int32 Weight_SettingsId, Int32 Weighing_SettingsId, Int32 ActiverPoids, Int32 BaudRate,
                        Int32 DataBits, String StopBits, String Handshake, Int32 ReadTimeOut)
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
                        Int32 DataBits, String StopBits, String Handshake, Int32 ReadTimeOut)
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
