using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class Enregistrements
    {
        public DataTable List(string filter)
        {
            try
            {
                EnregistrementsDA enregistrements = new EnregistrementsDA();
                return enregistrements.List(filter);
            }
            catch
            {
                throw;
            }
        }

        public DataTable SearchBox(string Filter, Int32 TablesId)
        {
            try
            {
                EnregistrementsDA enregistrements = new EnregistrementsDA();
                return enregistrements.SearchBox(Filter, TablesId);
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
                EnregistrementsDA enregistrements = new EnregistrementsDA();
                return enregistrements.FindById(Id);
            }
            catch
            {
                throw;
            }
        }

        public bool IfExists(String Name, Int32 TablesId, Int32 ParentId)
        {
            try
            {
                EnregistrementsDA enregistrements = new EnregistrementsDA();
                return enregistrements.IfExists(Name, TablesId, ParentId);
            }
            catch
            {
                throw;
            }
        }

        public bool IfExistsWithCode(String Name, Int32 TablesId, Int32 ParentId)
        {
            try
            {
                EnregistrementsDA enregistrements = new EnregistrementsDA();
                return enregistrements.IfExistsWithCode(Name, TablesId, ParentId);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindByTableId(Int32 Id)
        {
            try
            {
                EnregistrementsDA enregistrements = new EnregistrementsDA();
                return enregistrements.FindByTableId(Id);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindByTableIdAndParentId(Int32 TablesId, Int32 ParentId)
        {
            try
            {
                EnregistrementsDA enregistrements = new EnregistrementsDA();
                return enregistrements.FindByTableIdAndParentId(TablesId, ParentId);
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
                EnregistrementsDA enregistrements = new EnregistrementsDA();
                return enregistrements.GetName(Id);
            }
            catch
            {
                throw;
            }
        }

        public string GetCode(Int32 Id)
        {
            try
            {
                EnregistrementsDA enregistrements = new EnregistrementsDA();
                return enregistrements.GetCode(Id);
            }
            catch
            {
                throw;
            }
        }

        public void Add(Int32 TablesId, String Nom, String Code, String Adresse, String CodePostal, String Localite, String Pays,
            String Telephone, String Email, String NumTVA, String SiteWeb_Url, String Observations,
            Int32 Bloque, String TexteBloque, Int32 Attention, String TexteAttention, Int32 ParentId)
        {
            try
            {
                EnregistrementsDA enregistrements = new EnregistrementsDA();
                enregistrements.Add(TablesId, Nom, Code, Adresse, CodePostal, Localite, Pays,Telephone, Email, NumTVA, SiteWeb_Url, Observations,
                Bloque, TexteBloque, Attention, TexteAttention, ParentId);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, Int32 TablesId, String Nom, String Code, String Adresse, String CodePostal, String Localite, String Pays,
            String Telephone, String Email, String NumTVA, String SiteWeb_Url, String Observations,
            Int32 Bloque, String TexteBloque, Int32 Attention, String TexteAttention, Int32 ParentId)
        {
            try
            {
                EnregistrementsDA enregistrements = new EnregistrementsDA();
                enregistrements.Update(Id, TablesId, Nom, Code, Adresse, CodePostal, Localite, Pays, Telephone, Email, NumTVA, SiteWeb_Url, Observations,
                Bloque, TexteBloque, Attention, TexteAttention, ParentId);
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
                EnregistrementsDA enregistrements = new EnregistrementsDA();
                enregistrements.Delete(Id);
            }
            catch
            {
                throw;
            }
        }


    }
}
