using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidraSoft.DA
{
    public class CamionTransporteurDA
    {
        public string connString = ConnStrings.MainDb;
        SqlConnection conn = new SqlConnection();
        DataTable dt = new DataTable();

        public DataTable List()
        {
            String sql = "SELECT ct.CAMIONID, ca.PLAQUE AS CAMION, ct.TRANSPORTEURID, tr.NOM AS TRANSPORTEUR, ct.DATECREATION FROM CAMIONTRANSPORTEUR ct, CAMION ca, TRANSPORTEUR tr WHERE ct.CAMIONID = ca.CAMIONID AND ct.TRANSPORTEURID = tr.TRANSPORTEURID";
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

        public DataTable FindNonLinkedCarriersByCamionId(Int32 Id)
        {
            String sql = "SELECT TRANSPORTEURID,NOM FROM TRANSPORTEUR WHERE TRANSPORTEURID NOT IN (SELECT TRANSPORTEURID FROM CAMIONTRANSPORTEUR WHERE CAMIONID=" + Id + ")";
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
            String sql = "SELECT  ct.TRANSPORTEURID, ct.CAMIONID, tr.NOM AS TRANSPORTEUR, ca.PLAQUE AS CAMION, ct.DATECREATION FROM CAMIONTRANSPORTEUR ct, CAMION ca, TRANSPORTEUR tr WHERE ct.CAMIONID = ca.CAMIONID AND ct.TRANSPORTEURID = tr.TRANSPORTEURID AND ct.CAMIONID=" + Id;
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

        public DataTable FindByTransporteurId(Int32 Id)
        {
            String sql = "SELECT ct.CAMIONID, ca.PLAQUE AS CAMION, ct.TRANSPORTEURID, tr.NOM AS TRANSPORTEUR, ct.DATECREATION FROM CAMIONTRANSPORTEUR ct, CAMION ca, TRANSPORTEUR tr WHERE ct.CAMIONID = ca.CAMIONID AND ct.TRANSPORTEURID = tr.TRANSPORTEURID AND ct.TRANSPORTEURID=" + Id;
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

            String sql = "SELECT COUNT (*) FROM CAMIONTRANSPORTEUR WHERE CAMIONID = " + Id;
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

        public int GetFirstTransporteurByCamionId(int Id)
        {

            String sql = "SELECT TOP 1 TRANSPORTEURID FROM CAMIONTRANSPORTEUR  WHERE CAMIONID  = " + Id;
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

        public void Add(Int32 CamionId, Int32 TransporteurId)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_ADD_CAMIONTRANSPORTEUR", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CAMIONID", SqlDbType.Int).Value = CamionId;
                cmd.Parameters.Add("@TRANSPORTEURID", SqlDbType.Int).Value = TransporteurId;

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

        public void Delete(Int32 CamionId, Int32 TransporteurId)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_DELETE_CAMIONTRANSPORTEUR", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CAMIONID", SqlDbType.Int).Value = CamionId;
                cmd.Parameters.Add("@TRANSPORTEURID", SqlDbType.Int).Value = TransporteurId;

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
