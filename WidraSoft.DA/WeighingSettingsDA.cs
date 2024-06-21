using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidraSoft.DA
{
    public class WeighingSettingsDA
    {
        public string connString = ConnStrings.MainDb;
        SqlConnection conn = new SqlConnection();
        DataTable dt = new DataTable();

        public DataTable List(string filter)
        {
            String sql = "SELECT * FROM WEIGHING_SETTINGS WHERE " + filter;
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
            String sql = "SELECT * FROM WEIGHING_SETTINGS WHERE DESIGNATION LIKE '%" + filter + "%'";
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
            String sql = "SELECT * FROM WEIGHING_SETTINGS WHERE WEIGHING_SETTINGSID=" + Id;
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

        public Int32 CountNbWeighingSettingsTotal()
        {

            String sql = "SELECT COUNT(*) FROM WEIGHING_SETTINGS";
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

        public string GetName(Int32 Id)
        {

            String sql = "SELECT DESIGNATION FROM WEIGHING_SETTINGS WHERE WEIGHING_SETTINGSID=" + Id;
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

        public void Add(String Designation, Int32 Camion, Int32 Chauffeur, Int32 Transporteur, Int32 Produit, Int32 Client, Int32 Firme, Int32 @Camion_Obl, Int32 @Chauffeur_Obl, Int32 Transporteur_Obl,
            Int32 Produit_Obl, Int32 Client_Obl, Int32 Firme_Obl, String Camion_Borne, String Chauffeur_Borne, String Transporteur_Borne, String Produit_Borne, String Client_Borne, String Firme_Borne, Int32 Camion_AjoutF,
            Int32 Chauffeur_AjoutF, Int32 Transporteur_AjoutF, Int32 Produit_AjoutF, Int32 Client_AjoutF, Int32 Firme_AjoutF, Int32 Table1Id, Int32 Table2Id, Int32 Table3Id, Int32 Table4Id, Int32 Table5Id, Int32 Table6Id,
            Int32 Table7Id, Int32 Table1_Obl, Int32 Table2_Obl, Int32 Table3_Obl, Int32 Table4_Obl, Int32 Table5_Obl, Int32 Table6_Obl, Int32 Table7_Obl, Int32 Table1_Code, Int32 Table2_Code, Int32 Table3_Code, Int32 Table4_Code,
            Int32 Table5_Code, Int32 Table6_Code, Int32 Table7_Code, String Table1_Borne, String Table2_Borne, String Table3_Borne, String Table4_Borne, String Table5_Borne, String Table6_Borne, String Table7_Borne, Int32 Table1_Ticket,
            Int32 Table2_Ticket, Int32 Table3_Ticket, Int32 Table4_Ticket, Int32 Table5_Ticket, Int32 Table6_Ticket, Int32 Table7_Ticket, Int32 Table1_AjoutF, Int32 Table2_AjoutF, Int32 Table3_AjoutF, Int32 Table4_AjoutF, Int32 Table5_AjoutF, 
            Int32 Table6_AjoutF, Int32 Table7_AjoutF, Int32 PontFirme, Int32 CamionChauffeur, Int32 CamionTransporteur, String Format, String Titre1, String Titre2, String Footer)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_ADD_WEIGHING_SETTINGS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DESIGNATION", SqlDbType.VarChar).Value = Designation;
                cmd.Parameters.Add("@CAMION", SqlDbType.Int).Value = Camion;
                cmd.Parameters.Add("@CHAUFFEUR", SqlDbType.Int).Value = Chauffeur;
                cmd.Parameters.Add("@TRANSPORTEUR", SqlDbType.Int).Value = Transporteur;
                cmd.Parameters.Add("@PRODUIT", SqlDbType.Int).Value = Produit;
                cmd.Parameters.Add("@CLIENT", SqlDbType.Int).Value = Client;
                cmd.Parameters.Add("@FIRME", SqlDbType.Int).Value = Firme;
                cmd.Parameters.Add("@CAMION_OBL", SqlDbType.Int).Value = Camion_Obl;
                cmd.Parameters.Add("@CHAUFFEUR_OBL", SqlDbType.Int).Value = Chauffeur_Obl;
                cmd.Parameters.Add("@TRANSPORTEUR_OBL", SqlDbType.Int).Value = Transporteur_Obl;
                cmd.Parameters.Add("@PRODUIT_OBL", SqlDbType.Int).Value = Produit_Obl;
                cmd.Parameters.Add("@CLIENT_OBL", SqlDbType.Int).Value = Client_Obl;
                cmd.Parameters.Add("@FIRME_OBL", SqlDbType.Int).Value = Firme_Obl;
                cmd.Parameters.Add("@CAMION_BORNE", SqlDbType.VarChar).Value = Camion_Borne;
                cmd.Parameters.Add("@CHAUFFEUR_BORNE", SqlDbType.VarChar).Value = Chauffeur_Borne;
                cmd.Parameters.Add("@TRANSPORTEUR_BORNE", SqlDbType.VarChar).Value = Transporteur_Borne;
                cmd.Parameters.Add("@PRODUIT_BORNE", SqlDbType.VarChar).Value = Produit_Borne;
                cmd.Parameters.Add("@CLIENT_BORNE", SqlDbType.VarChar).Value = Client_Borne;
                cmd.Parameters.Add("@FIRME_BORNE", SqlDbType.VarChar).Value = Firme_Borne;
                cmd.Parameters.Add("@CAMION_AJOUT_F", SqlDbType.Int).Value = Camion_AjoutF;
                cmd.Parameters.Add("@CHAUFFEUR_AJOUT_F", SqlDbType.Int).Value = Chauffeur_AjoutF;
                cmd.Parameters.Add("@TRANSPORTEUR_AJOUT_F", SqlDbType.Int).Value = Transporteur_AjoutF;
                cmd.Parameters.Add("@PRODUIT_AJOUT_F", SqlDbType.Int).Value = Produit_AjoutF;
                cmd.Parameters.Add("@CLIENT_AJOUT_F", SqlDbType.Int).Value = Client_AjoutF;
                cmd.Parameters.Add("@FIRME_AJOUT_F", SqlDbType.Int).Value = Firme_AjoutF;
                cmd.Parameters.Add("@TABLE1_ID", SqlDbType.Int).Value = Table1Id;
                cmd.Parameters.Add("@TABLE2_ID", SqlDbType.Int).Value = Table2Id;
                cmd.Parameters.Add("@TABLE3_ID", SqlDbType.Int).Value = Table3Id;
                cmd.Parameters.Add("@TABLE4_ID", SqlDbType.Int).Value = Table4Id;
                cmd.Parameters.Add("@TABLE5_ID", SqlDbType.Int).Value = Table5Id;
                cmd.Parameters.Add("@TABLE6_ID", SqlDbType.Int).Value = Table6Id;
                cmd.Parameters.Add("@TABLE7_ID", SqlDbType.Int).Value = Table7Id;
                cmd.Parameters.Add("@TABLE1_OBL", SqlDbType.Int).Value = Table1_Obl;
                cmd.Parameters.Add("@TABLE2_OBL", SqlDbType.Int).Value = Table2_Obl;
                cmd.Parameters.Add("@TABLE3_OBL", SqlDbType.Int).Value = Table3_Obl;
                cmd.Parameters.Add("@TABLE4_OBL", SqlDbType.Int).Value = Table4_Obl;
                cmd.Parameters.Add("@TABLE5_OBL", SqlDbType.Int).Value = Table5_Obl;
                cmd.Parameters.Add("@TABLE6_OBL", SqlDbType.Int).Value = Table6_Obl;
                cmd.Parameters.Add("@TABLE7_OBL", SqlDbType.Int).Value = Table7_Obl;
                cmd.Parameters.Add("@TABLE1_CODE", SqlDbType.Int).Value = Table1_Code;
                cmd.Parameters.Add("@TABLE2_CODE", SqlDbType.Int).Value = Table2_Code;
                cmd.Parameters.Add("@TABLE3_CODE", SqlDbType.Int).Value = Table3_Code;
                cmd.Parameters.Add("@TABLE4_CODE", SqlDbType.Int).Value = Table4_Code;
                cmd.Parameters.Add("@TABLE5_CODE", SqlDbType.Int).Value = Table5_Code;
                cmd.Parameters.Add("@TABLE6_CODE", SqlDbType.Int).Value = Table6_Code;
                cmd.Parameters.Add("@TABLE7_CODE", SqlDbType.Int).Value = Table7_Code;
                cmd.Parameters.Add("@TABLE1_BORNE", SqlDbType.VarChar).Value = Table1_Borne;
                cmd.Parameters.Add("@TABLE2_BORNE", SqlDbType.VarChar).Value = Table2_Borne;
                cmd.Parameters.Add("@TABLE3_BORNE", SqlDbType.VarChar).Value = Table3_Borne;
                cmd.Parameters.Add("@TABLE4_BORNE", SqlDbType.VarChar).Value = Table4_Borne;
                cmd.Parameters.Add("@TABLE5_BORNE", SqlDbType.VarChar).Value = Table5_Borne;
                cmd.Parameters.Add("@TABLE6_BORNE", SqlDbType.VarChar).Value = Table6_Borne;
                cmd.Parameters.Add("@TABLE7_BORNE", SqlDbType.VarChar).Value = Table7_Borne;
                cmd.Parameters.Add("@TABLE1_TICKET", SqlDbType.Int).Value = Table1_Ticket;
                cmd.Parameters.Add("@TABLE2_TICKET", SqlDbType.Int).Value = Table2_Ticket;
                cmd.Parameters.Add("@TABLE3_TICKET", SqlDbType.Int).Value = Table3_Ticket;
                cmd.Parameters.Add("@TABLE4_TICKET", SqlDbType.Int).Value = Table4_Code;
                cmd.Parameters.Add("@TABLE5_TICKET", SqlDbType.Int).Value = Table5_Code;
                cmd.Parameters.Add("@TABLE6_TICKET", SqlDbType.Int).Value = Table6_Code;
                cmd.Parameters.Add("@TABLE7_TICKET", SqlDbType.Int).Value = Table7_Code;
                cmd.Parameters.Add("@TABLE1_AJOUT_F", SqlDbType.Int).Value = Table1_AjoutF;
                cmd.Parameters.Add("@TABLE2_AJOUT_F", SqlDbType.Int).Value = Table2_AjoutF;
                cmd.Parameters.Add("@TABLE3_AJOUT_F", SqlDbType.Int).Value = Table3_AjoutF;
                cmd.Parameters.Add("@TABLE4_AJOUT_F", SqlDbType.Int).Value = Table4_AjoutF;
                cmd.Parameters.Add("@TABLE5_AJOUT_F", SqlDbType.Int).Value = Table5_AjoutF;
                cmd.Parameters.Add("@TABLE6_AJOUT_F", SqlDbType.Int).Value = Table6_AjoutF;
                cmd.Parameters.Add("@TABLE7_AJOUT_F", SqlDbType.Int).Value = Table7_AjoutF;
                cmd.Parameters.Add("@PONTFIRME", SqlDbType.Int).Value = PontFirme;
                cmd.Parameters.Add("@CAMIONCHAUFFEUR", SqlDbType.Int).Value = CamionChauffeur;
                cmd.Parameters.Add("@CAMIONTRANSPORTEUR", SqlDbType.Int).Value = CamionTransporteur;
                cmd.Parameters.Add("@FORMAT", SqlDbType.VarChar).Value = Format;
                cmd.Parameters.Add("@TITRE1", SqlDbType.VarChar).Value = Titre1;
                cmd.Parameters.Add("@TITRE2", SqlDbType.VarChar).Value = Titre2;
                cmd.Parameters.Add("@FOOTER", SqlDbType.VarChar).Value = Footer;
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

        public void Update(Int32 Id, String Designation, Int32 Camion, Int32 Chauffeur, Int32 Transporteur, Int32 Produit, Int32 Client, Int32 Firme, Int32 @Camion_Obl, Int32 @Chauffeur_Obl, Int32 Transporteur_Obl,
            Int32 Produit_Obl, Int32 Client_Obl, Int32 Firme_Obl, String Camion_Borne, String Chauffeur_Borne, String Transporteur_Borne, String Produit_Borne, String Client_Borne, String Firme_Borne, Int32 Camion_AjoutF,
            Int32 Chauffeur_AjoutF, Int32 Transporteur_AjoutF, Int32 Produit_AjoutF, Int32 Client_AjoutF, Int32 Firme_AjoutF, Int32 Table1Id, Int32 Table2Id, Int32 Table3Id, Int32 Table4Id, Int32 Table5Id, Int32 Table6Id,
            Int32 Table7Id, Int32 Table1_Obl, Int32 Table2_Obl, Int32 Table3_Obl, Int32 Table4_Obl, Int32 Table5_Obl, Int32 Table6_Obl, Int32 Table7_Obl, Int32 Table1_Code, Int32 Table2_Code, Int32 Table3_Code, Int32 Table4_Code,
            Int32 Table5_Code, Int32 Table6_Code, Int32 Table7_Code, String Table1_Borne, String Table2_Borne, String Table3_Borne, String Table4_Borne, String Table5_Borne, String Table6_Borne, String Table7_Borne, Int32 Table1_Ticket,
            Int32 Table2_Ticket, Int32 Table3_Ticket, Int32 Table4_Ticket, Int32 Table5_Ticket, Int32 Table6_Ticket, Int32 Table7_Ticket, Int32 Table1_AjoutF, Int32 Table2_AjoutF, Int32 Table3_AjoutF, Int32 Table4_AjoutF, Int32 Table5_AjoutF,
            Int32 Table6_AjoutF, Int32 Table7_AjoutF, Int32 PontFirme, Int32 CamionChauffeur, Int32 CamionTransporteur, String Format, String Titre1, String Titre2, String Footer)
        {
            using (conn)
            {
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("PS_UPDATE_WEIGHING_SETTINGS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@DESIGNATION", SqlDbType.VarChar).Value = Designation;
                cmd.Parameters.Add("@CAMION", SqlDbType.Int).Value = Camion;
                cmd.Parameters.Add("@CHAUFFEUR", SqlDbType.Int).Value = Chauffeur;
                cmd.Parameters.Add("@TRANSPORTEUR", SqlDbType.Int).Value = Transporteur;
                cmd.Parameters.Add("@PRODUIT", SqlDbType.Int).Value = Produit;
                cmd.Parameters.Add("@CLIENT", SqlDbType.Int).Value = Client;
                cmd.Parameters.Add("@FIRME", SqlDbType.Int).Value = Firme;
                cmd.Parameters.Add("@CAMION_OBL", SqlDbType.Int).Value = Camion_Obl;
                cmd.Parameters.Add("@CHAUFFEUR_OBL", SqlDbType.Int).Value = Chauffeur_Obl;
                cmd.Parameters.Add("@TRANSPORTEUR_OBL", SqlDbType.Int).Value = Transporteur_Obl;
                cmd.Parameters.Add("@PRODUIT_OBL", SqlDbType.Int).Value = Produit_Obl;
                cmd.Parameters.Add("@CLIENT_OBL", SqlDbType.Int).Value = Client_Obl;
                cmd.Parameters.Add("@FIRME_OBL", SqlDbType.Int).Value = Firme_Obl;
                cmd.Parameters.Add("@CAMION_BORNE", SqlDbType.VarChar).Value = Camion_Borne;
                cmd.Parameters.Add("@CHAUFFEUR_BORNE", SqlDbType.VarChar).Value = Chauffeur_Borne;
                cmd.Parameters.Add("@TRANSPORTEUR_BORNE", SqlDbType.VarChar).Value = Transporteur_Borne;
                cmd.Parameters.Add("@PRODUIT_BORNE", SqlDbType.VarChar).Value = Produit_Borne;
                cmd.Parameters.Add("@CLIENT_BORNE", SqlDbType.VarChar).Value = Client_Borne;
                cmd.Parameters.Add("@FIRME_BORNE", SqlDbType.VarChar).Value = Firme_Borne;
                cmd.Parameters.Add("@CAMION_AJOUT_F", SqlDbType.Int).Value = Camion_AjoutF;
                cmd.Parameters.Add("@CHAUFFEUR_AJOUT_F", SqlDbType.Int).Value = Chauffeur_AjoutF;
                cmd.Parameters.Add("@TRANSPORTEUR_AJOUT_F", SqlDbType.Int).Value = Transporteur_AjoutF;
                cmd.Parameters.Add("@PRODUIT_AJOUT_F", SqlDbType.Int).Value = Produit_AjoutF;
                cmd.Parameters.Add("@CLIENT_AJOUT_F", SqlDbType.Int).Value = Client_AjoutF;
                cmd.Parameters.Add("@FIRME_AJOUT_F", SqlDbType.Int).Value = Firme_AjoutF;
                cmd.Parameters.Add("@TABLE1_ID", SqlDbType.Int).Value = Table1Id;
                cmd.Parameters.Add("@TABLE2_ID", SqlDbType.Int).Value = Table2Id;
                cmd.Parameters.Add("@TABLE3_ID", SqlDbType.Int).Value = Table3Id;
                cmd.Parameters.Add("@TABLE4_ID", SqlDbType.Int).Value = Table4Id;
                cmd.Parameters.Add("@TABLE5_ID", SqlDbType.Int).Value = Table5Id;
                cmd.Parameters.Add("@TABLE6_ID", SqlDbType.Int).Value = Table6Id;
                cmd.Parameters.Add("@TABLE7_ID", SqlDbType.Int).Value = Table7Id;
                cmd.Parameters.Add("@TABLE1_OBL", SqlDbType.Int).Value = Table1_Obl;
                cmd.Parameters.Add("@TABLE2_OBL", SqlDbType.Int).Value = Table2_Obl;
                cmd.Parameters.Add("@TABLE3_OBL", SqlDbType.Int).Value = Table3_Obl;
                cmd.Parameters.Add("@TABLE4_OBL", SqlDbType.Int).Value = Table4_Obl;
                cmd.Parameters.Add("@TABLE5_OBL", SqlDbType.Int).Value = Table5_Obl;
                cmd.Parameters.Add("@TABLE6_OBL", SqlDbType.Int).Value = Table6_Obl;
                cmd.Parameters.Add("@TABLE7_OBL", SqlDbType.Int).Value = Table7_Obl;
                cmd.Parameters.Add("@TABLE1_CODE", SqlDbType.Int).Value = Table1_Code;
                cmd.Parameters.Add("@TABLE2_CODE", SqlDbType.Int).Value = Table2_Code;
                cmd.Parameters.Add("@TABLE3_CODE", SqlDbType.Int).Value = Table3_Code;
                cmd.Parameters.Add("@TABLE4_CODE", SqlDbType.Int).Value = Table4_Code;
                cmd.Parameters.Add("@TABLE5_CODE", SqlDbType.Int).Value = Table5_Code;
                cmd.Parameters.Add("@TABLE6_CODE", SqlDbType.Int).Value = Table6_Code;
                cmd.Parameters.Add("@TABLE7_CODE", SqlDbType.Int).Value = Table7_Code;
                cmd.Parameters.Add("@TABLE1_BORNE", SqlDbType.VarChar).Value = Table1_Borne;
                cmd.Parameters.Add("@TABLE2_BORNE", SqlDbType.VarChar).Value = Table2_Borne;
                cmd.Parameters.Add("@TABLE3_BORNE", SqlDbType.VarChar).Value = Table3_Borne;
                cmd.Parameters.Add("@TABLE4_BORNE", SqlDbType.VarChar).Value = Table4_Borne;
                cmd.Parameters.Add("@TABLE5_BORNE", SqlDbType.VarChar).Value = Table5_Borne;
                cmd.Parameters.Add("@TABLE6_BORNE", SqlDbType.VarChar).Value = Table6_Borne;
                cmd.Parameters.Add("@TABLE7_BORNE", SqlDbType.VarChar).Value = Table7_Borne;
                cmd.Parameters.Add("@TABLE1_TICKET", SqlDbType.Int).Value = Table1_Ticket;
                cmd.Parameters.Add("@TABLE2_TICKET", SqlDbType.Int).Value = Table2_Ticket;
                cmd.Parameters.Add("@TABLE3_TICKET", SqlDbType.Int).Value = Table3_Ticket;
                cmd.Parameters.Add("@TABLE4_TICKET", SqlDbType.Int).Value = Table4_Code;
                cmd.Parameters.Add("@TABLE5_TICKET", SqlDbType.Int).Value = Table5_Code;
                cmd.Parameters.Add("@TABLE6_TICKET", SqlDbType.Int).Value = Table6_Code;
                cmd.Parameters.Add("@TABLE7_TICKET", SqlDbType.Int).Value = Table7_Code;
                cmd.Parameters.Add("@TABLE1_AJOUT_F", SqlDbType.Int).Value = Table1_AjoutF;
                cmd.Parameters.Add("@TABLE2_AJOUT_F", SqlDbType.Int).Value = Table2_AjoutF;
                cmd.Parameters.Add("@TABLE3_AJOUT_F", SqlDbType.Int).Value = Table3_AjoutF;
                cmd.Parameters.Add("@TABLE4_AJOUT_F", SqlDbType.Int).Value = Table4_AjoutF;
                cmd.Parameters.Add("@TABLE5_AJOUT_F", SqlDbType.Int).Value = Table5_AjoutF;
                cmd.Parameters.Add("@TABLE6_AJOUT_F", SqlDbType.Int).Value = Table6_AjoutF;
                cmd.Parameters.Add("@TABLE7_AJOUT_F", SqlDbType.Int).Value = Table7_AjoutF;
                cmd.Parameters.Add("@PONTFIRME", SqlDbType.Int).Value = PontFirme;
                cmd.Parameters.Add("@CAMIONCHAUFFEUR", SqlDbType.Int).Value = CamionChauffeur;
                cmd.Parameters.Add("@CAMIONTRANSPORTEUR", SqlDbType.Int).Value = CamionTransporteur;
                cmd.Parameters.Add("@FORMAT", SqlDbType.VarChar).Value = Format;
                cmd.Parameters.Add("@TITRE1", SqlDbType.VarChar).Value = Titre1;
                cmd.Parameters.Add("@TITRE2", SqlDbType.VarChar).Value = Titre2;
                cmd.Parameters.Add("@FOOTER", SqlDbType.VarChar).Value = Footer;
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
                SqlCommand cmd = new SqlCommand("PS_DELETE_WEIGHING_SETTINGS", conn);
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
