using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class Transporteur
    {
        public DataTable List(string filter)
        {
            try
            {
                TransporteurDA transporteur = new TransporteurDA();
                return transporteur.List(filter);
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
                TransporteurDA transporteur = new TransporteurDA();
                return transporteur.SearchBox(Filter);
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
                TransporteurDA transporteur = new TransporteurDA();
                return transporteur.FindById(Id);
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
                TransporteurDA transporteur = new TransporteurDA();
                return transporteur.GetName(Id);
            }
            catch
            {
                throw;
            }
        }

        public void Add(String Licence, String Nom, String Adresse, String CodePostal, String Localite, String Pays,
            String Telephone, String Email, String NumTVA, String SiteWeb_Url, String Observations,
            Int32 Valide, Int32 Bloque, String TexteBloque, Int32 Attention, String TexteAttention)
        {
            try
            {
                TransporteurDA transporteur = new TransporteurDA();
                transporteur.Add(Licence, Nom, Adresse, CodePostal, Localite, Pays, Telephone,
                    Email, NumTVA, SiteWeb_Url, Observations, Valide, Bloque, TexteBloque, Attention, TexteAttention);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, String Licence, String Nom, String Adresse, String CodePostal, String Localite, String Pays,
            String Telephone, String Email, String NumTVA, String SiteWeb_Url, String Observations,
            Int32 Valide, Int32 Bloque, String TexteBloque, Int32 Attention, String TexteAttention)
        {
            try
            {
                TransporteurDA transporteur = new TransporteurDA();
                transporteur.Update(Id, Licence, Nom, Adresse, CodePostal, Localite, Pays, Telephone,
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
                TransporteurDA transporteur = new TransporteurDA();
                transporteur.Delete(Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
