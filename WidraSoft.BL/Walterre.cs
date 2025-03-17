using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        public void Add(String Code, Int32 ProduitId, Int32 ClientId, Decimal Volume, Decimal Seuil_Max,
           String Region, String Texte_Borne, String Observations, Int32 Depassement, Int32 Cloture, SqlDateTime DateCloture, String Status)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                walterre.Add(Code, ProduitId, ClientId, Volume, Seuil_Max, Region, Texte_Borne , Observations , Depassement, Cloture, DateCloture, Status);
            }
            catch
            {
                throw;
            }           
        }

        public void Update(Int32 Id, String Code, Int32 ProduitId, Int32 ClientId, Decimal Volume, Decimal Seuil_Max,
           String Region, String Texte_Borne, String Observations, Int32 Depassement, Int32 Cloture, SqlDateTime DateCloture, String Status)
        {
            try
            {
                WalterreDA walterre = new WalterreDA();
                walterre.Update(Id, Code, ProduitId, ClientId, Volume, Seuil_Max, Region, Texte_Borne, Observations, Depassement, Cloture, DateCloture, Status);
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
