using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class Firme
    {
        public DataTable List(string filter)
        {
            try
            {
                FirmeDA firme = new FirmeDA();
                return firme.List(filter);
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
                FirmeDA firme = new FirmeDA();
                return firme.FindById(Id);
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
                FirmeDA firme = new FirmeDA();
                return firme.GetName(Id);
            }
            catch
            {
                throw;
            }
        }

        public void Add(String Badge, String Designation, String Adresse, String CodePostal, String Localite, 
            String Pays, String Telephone,
            String Email, String NumTVA, String SiteWeb_Url, String Observations, Int32 Valide, Int32 Bloque, 
            String TexteBloque, Int32 Attention, String TexteAttention)
        {
            try
            {
                FirmeDA firme = new FirmeDA();
                firme.Add(Badge, Designation, Adresse, CodePostal, Localite, Pays, Telephone,
                    Email, NumTVA, SiteWeb_Url, Observations, Valide, Bloque, TexteBloque, Attention, TexteAttention);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, String Badge, String Designation, String Adresse, String CodePostal,
            String Localite, String Pays, String Telephone,
            String Email, String NumTVA, String SiteWeb_Url, String Observations,
            Int32 Valide, Int32 Bloque, String TexteBloque, Int32 Attention, String TexteAttention)
        {
            try
            {
                FirmeDA firme = new FirmeDA();
                firme.Update(Id, Badge, Designation, Adresse, CodePostal, Localite, Pays, Telephone,
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
                FirmeDA firme = new FirmeDA();
                firme.Delete(Id);
            }
            catch
            {
                throw;
            }
        }


    }

    
}
