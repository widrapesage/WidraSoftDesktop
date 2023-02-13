using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidraSoft.DA
{
    public class PontFirmeDA
    {
        public string connString = ConnStrings.MainDb;
        SqlConnection conn = new SqlConnection();
        DataTable dt = new DataTable();

        public DataTable List()
        {
            String sql = "SELECT pf.PONTID, p.DESIGNATION AS PONT, pf.FIRMEID, f.DESIGNATION AS FIRME, pf.DATECREATION FROM PONTFIRME pf, PONT p, FIRME f WHERE pf.PONTID = p.PONTID AND pf.FIRMEID = f.FIRMEID";
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

        public DataTable FindNonLinkedFirmsByPontId(Int32 Id)
        {
            String sql = "SELECT FIRMEID,DESIGNATION FROM FIRME WHERE FIRMEID NOT IN (SELECT FIRMEID FROM PONTFIRME WHERE PONTID=" + Id + ")";
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

        public DataTable FindByPontId(Int32 Id)
        {
            String sql = "SELECT  pf.FIRMEID, f.DESIGNATION AS FIRME, pf.PONTID, p.DESIGNATION AS PONT, pf.DATECREATION FROM PONTFIRME pf, PONT p, FIRME f WHERE pf.PONTID = p.PONTID AND pf.FIRMEID = f.FIRMEID AND pf.PONTID=" + Id;
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

        public DataTable FindByFirmeId(Int32 Id)
        {
            String sql = "SELECT pf.FIRMEID, f.DESIGNATION AS FIRME, pf.PONTID, p.DESIGNATION AS PONT, pf.DATECREATION FROM PONTFIRME pf, PONT p, FIRME f WHERE pf.PONTID = p.PONTID AND pf.FIRMEID = f.FIRMEID AND pf.FIRMEID=" + Id;
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

        public void Add(Int32 PontId, Int32 FirmeId)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_ADD_PONTFIRME", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PONTID", SqlDbType.Int).Value = PontId;
                cmd.Parameters.Add("@FIRMEID", SqlDbType.Int).Value = FirmeId;

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

        public void Delete(Int32 PontId, Int32 FirmeId)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_DELETE_PONTFIRME", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PONTID", SqlDbType.Int).Value = PontId;
                cmd.Parameters.Add("@FIRMEID", SqlDbType.Int).Value = FirmeId;

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
