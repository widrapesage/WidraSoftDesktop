using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidraSoft.DA
{
    public class CamionChauffeurDA
    {
        public string connString = ConnStrings.MainDb;
        SqlConnection conn = new SqlConnection();
        DataTable dt = new DataTable();

        public DataTable List()
        {
            String sql = "SELECT cc.CAMIONID, ca.PLAQUE AS CAMION, cc.CHAUFFEURID, ch.NOM AS CHAUFFEUR, cc.DATECREATION FROM CAMIONCHAUFFEUR cc, CAMION ca, CHAUFFEUR ch WHERE cc.CAMIONID = ca.CAMIONID AND cc.CHAUFFEURID = ch.CHAUFFEURID";
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

        public DataTable FindNonLinkedDriversByCamionId(Int32 Id)
        {
            String sql = "SELECT CHAUFFEURID,NOM FROM CHAUFFEUR WHERE CHAUFFEURID NOT IN (SELECT CHAUFFEURID FROM CAMIONCHAUFFEUR WHERE CAMIONID=" + Id + ")";
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

        public DataTable FindByCamionId(Int32 Id)
        {
            String sql = "SELECT cc.CHAUFFEURID, cc.CAMIONID, ch.NOM AS CHAUFFEUR, ca.PLAQUE AS CAMION, cc.DATECREATION FROM CAMIONCHAUFFEUR cc, CAMION ca, CHAUFFEUR ch WHERE cc.CAMIONID = ca.CAMIONID AND cc.CHAUFFEURID = ch.CHAUFFEURID AND cc.CAMIONID=" + Id;
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

        public DataTable FindByChauffeurId(Int32 Id)
        {
            String sql = "SELECT cc.CAMIONID, ca.PLAQUE AS CAMION, cc.CHAUFFEURID, ch.NOM AS CHAUFFEUR, cc.DATECREATION FROM CAMIONCHAUFFEUR cc, CAMION ca, CHAUFFEUR ch WHERE cc.CAMIONID = ca.CAMIONID AND cc.CHAUFFEURID = ch.CHAUFFEURID AND cc.CHAUFFEURID=" + Id;
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

        public int CountByCamionId(int Id)
        {

            String sql = "SELECT COUNT (*) FROM CAMIONCHAUFFEUR WHERE CAMIONID = " + Id;
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

        public int GetFirstChauffeurByCamionId(int Id)
        {

            String sql = "SELECT TOP 1 CHAUFFEURID FROM CAMIONCHAUFFEUR  WHERE CAMIONID  = " + Id;
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

        public void Add(Int32 CamionId, Int32 ChauffeurId)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_ADD_CAMIONCHAUFFEUR", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CAMIONID", SqlDbType.Int).Value = CamionId;
                cmd.Parameters.Add("@CHAUFFEURID", SqlDbType.Int).Value = ChauffeurId;

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

        public void Delete(Int32 CamionId, Int32 ChauffeurId)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_DELETE_CAMIONCHAUFFEUR", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CAMIONID", SqlDbType.Int).Value = CamionId;
                cmd.Parameters.Add("@CHAUFFEURID", SqlDbType.Int).Value = ChauffeurId;

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
