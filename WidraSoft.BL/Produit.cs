using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class Produit
    {
        public DataTable List(string filter)
        {
            try
            {
                ProduitDA produit = new ProduitDA();
                return produit.List(filter);
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
                ProduitDA produit = new ProduitDA();
                return produit.SearchBox(Filter);
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
                ProduitDA produit = new ProduitDA();
                return produit.FindById(Id);
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
                ProduitDA produit = new ProduitDA();
                return produit.IfExists(Name);
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
                ProduitDA produit = new ProduitDA();
                return produit.GetName(Id);
            }
            catch
            {
                throw;
            }
        }

        public void Add(String Designation, Int32 GroupeProduitId, Int32 EstEntrant, Int32 EstSortant, Int32 Valide,
           Int32 PoidsAlerteMin, Int32 ActiverAlerteMin, Int32 PoidsAlerteMax, Int32 ActiverAlerteMax, Int32 EmpecherTicketSiAlerte,
           Int32 Dechet, Int32 TypeDechetId)
        {
            try
            {
                ProduitDA produit = new ProduitDA();
                produit.Add(Designation, GroupeProduitId, EstEntrant, EstSortant, Valide,
                        PoidsAlerteMin, ActiverAlerteMin, PoidsAlerteMax, ActiverAlerteMax, EmpecherTicketSiAlerte,
                        Dechet, TypeDechetId);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, String Designation, Int32 GroupeProduitId, Int32 EstEntrant, Int32 EstSortant, Int32 Valide,
           Int32 PoidsAlerteMin, Int32 ActiverAlerteMin, Int32 PoidsAlerteMax, Int32 ActiverAlerteMax, Int32 EmpecherTicketSiAlerte,
           Int32 Dechet, Int32 TypeDechetId)
        {
            try
            {
                ProduitDA produit = new ProduitDA();
                produit.Update(Id, Designation, GroupeProduitId, EstEntrant, EstSortant, Valide,
                        PoidsAlerteMin, ActiverAlerteMin, PoidsAlerteMax, ActiverAlerteMax, EmpecherTicketSiAlerte,
                        Dechet, TypeDechetId);
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
                ProduitDA produit = new ProduitDA();
                produit.Delete(Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
