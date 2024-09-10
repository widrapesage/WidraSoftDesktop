using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class WeighingSettings
    {
        public DataTable List(string filter)
        {
            try
            {
                WeighingSettingsDA weighingSettings= new WeighingSettingsDA();
                return weighingSettings.List(filter);
            }
            catch
            {
                throw;
            }
        }

        public DataTable SearchBox(string filter)
        {
            try
            {
                WeighingSettingsDA weighingSettings = new WeighingSettingsDA();
                return weighingSettings.SearchBox(filter);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindById(Int32 Id)
        {
            try
            {
                WeighingSettingsDA weighingSettings = new WeighingSettingsDA();
                return weighingSettings.FindById(Id);
            }
            catch
            {
                throw;
            }
        }

        public Int32 CountNbWeighingSettingsTotal()
        {
            try
            {
                WeighingSettingsDA weighingSettings = new WeighingSettingsDA();
                return weighingSettings.CountNbWeighingSettingsTotal();
            }
            catch
            {
                throw;
            }
        }

        public string GetName(Int32 Id)
        {
            try
            {
                WeighingSettingsDA weighingSettings = new WeighingSettingsDA();
                return weighingSettings.GetName(Id);
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
            Int32 Table6_AjoutF, Int32 Table7_AjoutF, String ChampLibre1, String ChampLibre2, String ChampLibre3, String ChampLibre4, Int32 ChampLibre1_Obl, Int32 ChampLibre2_Obl, Int32 ChampLibre3_Obl, Int32 ChampLibre4_Obl,
            Int32 ChampLibre1_Ticket, Int32 ChampLibre2_Ticket, Int32 ChampLibre3_Ticket, Int32 ChampLibre4_Ticket, String ChampLibre1_Borne, String ChampLibre2_Borne, String ChampLibre3_Borne, String ChampLibre4_Borne,
            Int32 PontFirme, Int32 CamionChauffeur, Int32 CamionTransporteur, String Format, String Titre1, String Titre2, String Footer)
        {
            try
            {
                WeighingSettingsDA weighingSettings = new WeighingSettingsDA();
                weighingSettings.Add( Designation,  Camion,  Chauffeur,  Transporteur,  Produit,  Client,  Firme,  @Camion_Obl,  @Chauffeur_Obl,  Transporteur_Obl,
             Produit_Obl,  Client_Obl,  Firme_Obl,  Camion_Borne,  Chauffeur_Borne,  Transporteur_Borne,  Produit_Borne,  Client_Borne,  Firme_Borne,  Camion_AjoutF,
             Chauffeur_AjoutF,  Transporteur_AjoutF,  Produit_AjoutF,  Client_AjoutF,  Firme_AjoutF,  Table1Id,  Table2Id,  Table3Id,  Table4Id,  Table5Id,  Table6Id,
             Table7Id,  Table1_Obl,  Table2_Obl,  Table3_Obl,  Table4_Obl,  Table5_Obl,  Table6_Obl,  Table7_Obl,  Table1_Code,  Table2_Code,  Table3_Code,  Table4_Code,
             Table5_Code,  Table6_Code,  Table7_Code,  Table1_Borne,  Table2_Borne,  Table3_Borne,  Table4_Borne,  Table5_Borne,  Table6_Borne,  Table7_Borne,  Table1_Ticket,
             Table2_Ticket,  Table3_Ticket,  Table4_Ticket,  Table5_Ticket,  Table6_Ticket,  Table7_Ticket,  Table1_AjoutF,  Table2_AjoutF,  Table3_AjoutF,  Table4_AjoutF,  Table5_AjoutF,
             Table6_AjoutF,  Table7_AjoutF, ChampLibre1, ChampLibre2, ChampLibre3, ChampLibre4, ChampLibre1_Obl, ChampLibre2_Obl, ChampLibre3_Obl, ChampLibre4_Obl, ChampLibre1_Ticket, 
             ChampLibre2_Ticket, ChampLibre3_Ticket, ChampLibre4_Ticket, ChampLibre1_Borne, ChampLibre2_Borne, ChampLibre3_Borne, ChampLibre4_Borne,PontFirme, CamionChauffeur, CamionTransporteur, Format, Titre1, Titre2, Footer);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, String Designation, Int32 Camion, Int32 Chauffeur, Int32 Transporteur, Int32 Produit, Int32 Client, Int32 Firme, Int32 @Camion_Obl, Int32 @Chauffeur_Obl, Int32 Transporteur_Obl,
            Int32 Produit_Obl, Int32 Client_Obl, Int32 Firme_Obl, String Camion_Borne, String Chauffeur_Borne, String Transporteur_Borne, String Produit_Borne, String Client_Borne, String Firme_Borne, Int32 Camion_AjoutF,
            Int32 Chauffeur_AjoutF, Int32 Transporteur_AjoutF, Int32 Produit_AjoutF, Int32 Client_AjoutF, Int32 Firme_AjoutF, Int32 Table1Id, Int32 Table2Id, Int32 Table3Id, Int32 Table4Id, Int32 Table5Id, Int32 Table6Id,
            Int32 Table7Id, Int32 Table1_Obl, Int32 Table2_Obl, Int32 Table3_Obl, Int32 Table4_Obl, Int32 Table5_Obl, Int32 Table6_Obl, Int32 Table7_Obl, Int32 Table1_Code, Int32 Table2_Code, Int32 Table3_Code, Int32 Table4_Code,
            Int32 Table5_Code, Int32 Table6_Code, Int32 Table7_Code, String Table1_Borne, String Table2_Borne, String Table3_Borne, String Table4_Borne, String Table5_Borne, String Table6_Borne, String Table7_Borne, Int32 Table1_Ticket,
            Int32 Table2_Ticket, Int32 Table3_Ticket, Int32 Table4_Ticket, Int32 Table5_Ticket, Int32 Table6_Ticket, Int32 Table7_Ticket, Int32 Table1_AjoutF, Int32 Table2_AjoutF, Int32 Table3_AjoutF, Int32 Table4_AjoutF, Int32 Table5_AjoutF,
            Int32 Table6_AjoutF, Int32 Table7_AjoutF, String ChampLibre1, String ChampLibre2, String ChampLibre3, String ChampLibre4, Int32 ChampLibre1_Obl, Int32 ChampLibre2_Obl, Int32 ChampLibre3_Obl, Int32 ChampLibre4_Obl,
            Int32 ChampLibre1_Ticket, Int32 ChampLibre2_Ticket, Int32 ChampLibre3_Ticket, Int32 ChampLibre4_Ticket, String ChampLibre1_Borne, String ChampLibre2_Borne, String ChampLibre3_Borne, String ChampLibre4_Borne,
            Int32 PontFirme, Int32 CamionChauffeur, Int32 CamionTransporteur, String Format, String Titre1, String Titre2, String Footer)
        {
            try
            {
                WeighingSettingsDA weighingSettings = new WeighingSettingsDA();
                weighingSettings.Update(Id, Designation, Camion, Chauffeur, Transporteur, Produit, Client, Firme, @Camion_Obl, @Chauffeur_Obl, Transporteur_Obl,
             Produit_Obl, Client_Obl, Firme_Obl, Camion_Borne, Chauffeur_Borne, Transporteur_Borne, Produit_Borne, Client_Borne, Firme_Borne, Camion_AjoutF,
             Chauffeur_AjoutF, Transporteur_AjoutF, Produit_AjoutF, Client_AjoutF, Firme_AjoutF, Table1Id, Table2Id, Table3Id, Table4Id, Table5Id, Table6Id,
             Table7Id, Table1_Obl, Table2_Obl, Table3_Obl, Table4_Obl, Table5_Obl, Table6_Obl, Table7_Obl, Table1_Code, Table2_Code, Table3_Code, Table4_Code,
             Table5_Code, Table6_Code, Table7_Code, Table1_Borne, Table2_Borne, Table3_Borne, Table4_Borne, Table5_Borne, Table6_Borne, Table7_Borne, Table1_Ticket,
             Table2_Ticket, Table3_Ticket, Table4_Ticket, Table5_Ticket, Table6_Ticket, Table7_Ticket, Table1_AjoutF, Table2_AjoutF, Table3_AjoutF, Table4_AjoutF, Table5_AjoutF,
             Table6_AjoutF, Table7_AjoutF, ChampLibre1, ChampLibre2, ChampLibre3, ChampLibre4, ChampLibre1_Obl, ChampLibre2_Obl, ChampLibre3_Obl, ChampLibre4_Obl, ChampLibre1_Ticket,
             ChampLibre2_Ticket, ChampLibre3_Ticket, ChampLibre4_Ticket, ChampLibre1_Borne, ChampLibre2_Borne, ChampLibre3_Borne, ChampLibre4_Borne, PontFirme, CamionChauffeur, CamionTransporteur, 
             Format, Titre1, Titre2, Footer);
            }
            catch
            {
                throw;
            }
        }

        public void Delete(Int32 Id)
        {
            try
            {
                WeighingSettingsDA weighingSettings = new WeighingSettingsDA();
                weighingSettings.Delete(Id);
            }
            catch
            {
                throw;
            }
        }


    }
}
