using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class Walterre
    {
        public DataTable List(string filter)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                return walterre.List(filter);
            }
            catch
            {
                throw;
            }

        }

        public DataTable List_Valid(string filter)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                return walterre.List_Valid(filter);
            }
            catch
            {
                throw;
            }
        }

        public DataTable List_Enlevements(string filter)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                return walterre.List_Enlevements(filter);
            }
            catch
            {
                throw;
            }
        }
        public DataTable SearchBox(string Filter)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                return walterre.SearchBox(Filter);
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
                WalterreDA walterre = new WalterreDA();
                return walterre.FindById(Id);
            }
            catch
            {
                throw;
            }
        }

        public bool IsDepassementSeuilMaxAutorise(Int32 Id)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                return walterre.IsDepassementSeuilMaxAutorise(Id);
            }
            catch
            {
                throw;
            }
        }

        public bool IsDepassementVolumeAutorise(Int32 Id)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                return walterre.IsDepassementVolumeAutorise(Id);
            }
            catch
            {
                throw;
            }
        }
        public DataTable FindEnlevementsById(Int32 Id)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                return walterre.FindEnlevementsById(Id);
            }
            catch
            {
                throw;
            }
        }

        public decimal GetQteEnlevements(Int32 Id)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                return walterre.GetQteEnlevements(Id);
            }
            catch
            {
                throw;
            }
        }

        public decimal GetSeuilMax(Int32 Id)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                return walterre.GetSeuilMax(Id);
            }
            catch
            {
                throw;
            }
        }

        public decimal GetVolume(Int32 Id)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                return walterre.GetVolume(Id);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindPeseePBById(Int32 Id)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                return walterre.FindPeseePBById(Id);
            }
            catch
            {
                throw;
            }
        }

        public bool IfExists(String Name)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                return walterre.IfExists(Name);
            }
            catch
            {
                throw;
            }
        }

        public bool IfExistsByIdString(String Name)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                return walterre.IfExistsByIdString(Name);
            }
            catch
            {
                throw;
            }
        }

        public bool IfExists_Valid(String Name)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                return walterre.IfExists_Valid(Name);
            }
            catch
            {
                throw;
            }
        }

        public bool IfExists_Valid_ByIdString(String Name)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                return walterre.IfExists_Valid_ByIdString(Name);
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
                WalterreDA walterre = new WalterreDA();
                return walterre.GetName(Id);
            }
            catch
            {
                throw;
            }
        }

        public int GetIdByName(string Name)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                return walterre.GetIdByName(Name);
            }
            catch
            {
                throw;
            }
        }
        public void Add(String Code, Int32 ProduitId, Int32 ClientId, Decimal Volume, Decimal Seuil_Max,
           String Region, String Texte_Borne, String Observations, Int32 Depassement, Int32 Cloture, SqlDateTime DateCloture, String Status, Int32 Depassement_Seuil_Max, String Nom)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                walterre.Add(Code, ProduitId, ClientId, Volume, Seuil_Max, Region, Texte_Borne , Observations , Depassement, Cloture, DateCloture, Status, Depassement_Seuil_Max, Nom);
            }
            catch
            {
                throw;
            }           
        }

        public void Update(Int32 Id, String Code, Int32 ProduitId, Int32 ClientId, Decimal Volume, Decimal Seuil_Max,
           String Region, String Texte_Borne, String Observations, Int32 Depassement, Int32 Cloture, SqlDateTime DateCloture, String Status, Int32 Depassement_Seuil_Max, String Nom)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                walterre.Update(Id, Code, ProduitId, ClientId, Volume, Seuil_Max, Region, Texte_Borne, Observations, Depassement, Cloture, DateCloture, Status, Depassement_Seuil_Max, Nom);
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
                WalterreDA walterre = new WalterreDA();
                walterre.Delete(Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
