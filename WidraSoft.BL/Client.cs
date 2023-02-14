using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class Client
    {
        public DataTable List(string filter)
        {
            try
            {
                ClientDA client = new ClientDA();
                return client.List(filter);
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
                ClientDA client = new ClientDA();
                return client.SearchBox(Filter);
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
                ClientDA client = new ClientDA();
                return client.FindById(Id);
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
                ClientDA client = new ClientDA();
                return client.IfExists(Name);
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
                ClientDA client = new ClientDA();
                return client.GetName(Id);
            }
            catch
            {
                throw;
            }
        }

        public void Add(String Badge, String Designation, Int32 TypeClientId, String Adresse, String CodePostal, String Localite,
            String Pays, String Telephone,
            String Email, String NumTVA, String SiteWeb_Url, String Observations, Int32 Valide, Int32 Bloque,
            String TexteBloque, Int32 Attention, String TexteAttention)
        {
            try
            {
                ClientDA client = new ClientDA();
                client.Add(Badge, Designation, TypeClientId, Adresse, CodePostal, Localite, Pays, Telephone,
                    Email, NumTVA, SiteWeb_Url, Observations, Valide, Bloque, TexteBloque, Attention, TexteAttention);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, String Badge, String Designation, Int32 TypeClientId, String Adresse, String CodePostal, String Localite,
            String Pays, String Telephone,
            String Email, String NumTVA, String SiteWeb_Url, String Observations, Int32 Valide, Int32 Bloque,
            String TexteBloque, Int32 Attention, String TexteAttention)
        {
            try
            {
                ClientDA client = new ClientDA();
                client.Update(Id, Badge, Designation, TypeClientId, Adresse, CodePostal, Localite, Pays, Telephone,
                    Email, NumTVA, SiteWeb_Url, Observations, Valide, Bloque, TexteBloque, Attention, TexteAttention);
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
                ClientDA client = new ClientDA();
                client.Delete(Id);
            }
            catch
            {
                throw;
            }
        }

    }
}
