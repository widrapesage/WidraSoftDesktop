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

        public DataTable SearchBox(string Filter)
        {
            try
            {
                EnregistrementsDA enregistrements = new EnregistrementsDA();
                return enregistrements.SearchBox(Filter);
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

        public void Add(String Nom, String Adresse, String CodePostal, String Localite, String Pays,
            String Telephone, String Email, String NumTVA, String SiteWeb_Url, String Observations,
            Int32 Bloque, String TexteBloque, Int32 Attention, String TexteAttention)
        {
            try
            {
                EnregistrementsDA enregistrements = new EnregistrementsDA();
                enregistrements.Add(Nom, Adresse, CodePostal, Localite, Pays,Telephone, Email, NumTVA, SiteWeb_Url, Observations,
                Bloque, TexteBloque, Attention, TexteAttention);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, String Nom, String Adresse, String CodePostal, String Localite, String Pays,
           String Telephone, String Email, String NumTVA, String SiteWeb_Url, String Observations,
           Int32 Bloque, String TexteBloque, Int32 Attention, String TexteAttention)
        {
            try
            {
                EnregistrementsDA enregistrements = new EnregistrementsDA();
                enregistrements.Update(Id, Nom, Adresse, CodePostal, Localite, Pays, Telephone, Email, NumTVA, SiteWeb_Url, Observations,
                Bloque, TexteBloque, Attention, TexteAttention);
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
