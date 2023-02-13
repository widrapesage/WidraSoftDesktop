using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class PontFirme
    {
        public DataTable List()
        {
            try
            {
                PontFirmeDA pontFirme = new PontFirmeDA();
                return pontFirme.List();
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindNonLinkedFirmsByPontId(Int32 Id)
        {
            try
            {
                PontFirmeDA pontFirme = new PontFirmeDA();
                return pontFirme.FindNonLinkedFirmsByPontId(Id);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindByPontId(Int32 Id)
        {
            try
            {
                PontFirmeDA pontFirme = new PontFirmeDA();
                return pontFirme.FindByPontId(Id);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindByFirmeId(Int32 Id)
        {
            try
            {
                PontFirmeDA pontFirme = new PontFirmeDA();
                return pontFirme.FindByFirmeId(Id);
            }
            catch
            {
                throw;
            }
        }

        public void Add(Int32 PontId, Int32 FirmeId)
        {
            try
            {
                PontFirmeDA pontFirme = new PontFirmeDA();
                pontFirme.Add(PontId, FirmeId);
            }
            catch
            {
                throw;
            }
        }

        public void Delete(Int32 PontId, Int32 FirmeId)
        {
            try
            {
                PontFirmeDA pontFirme = new PontFirmeDA();
                pontFirme.Delete(PontId, FirmeId);
            }
            catch
            {
                throw;
            }
        }

    }   
}
