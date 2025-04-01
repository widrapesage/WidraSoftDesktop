using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class CamionChauffeur
    {
        public DataTable List()
        {
            try
            {
                CamionChauffeurDA camionChauffeur = new CamionChauffeurDA();
                return camionChauffeur.List();
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindNonLinkedDriversByCamionId(Int32 Id)
        {
            try
            {
                CamionChauffeurDA camionChauffeur = new CamionChauffeurDA();
                return camionChauffeur.FindNonLinkedDriversByCamionId(Id);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindByCamionId(Int32 Id)
        {
            try
            {
                CamionChauffeurDA camionChauffeur = new CamionChauffeurDA();
                return camionChauffeur.FindByCamionId(Id);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindByChauffeurId(Int32 Id)
        {
            try
            {
                CamionChauffeurDA camionChauffeur = new CamionChauffeurDA();
                return camionChauffeur.FindByChauffeurId(Id);
            }
            catch
            {
                throw;
            }
        }

        public int CountByCamionId(int Id)
        {
            try
            {
                CamionChauffeurDA camionChauffeur = new CamionChauffeurDA();
                return camionChauffeur.CountByCamionId(Id);
            }
            catch
            {
                throw;
            }
        }

        public int GetFirstChauffeurByCamionId(int Id)
        {
            try
            {
                CamionChauffeurDA camionChauffeur = new CamionChauffeurDA();
                return camionChauffeur.GetFirstChauffeurByCamionId(Id);
            }
            catch
            {
                throw;
            }
        }

        public void Add(Int32 CamionId, Int32 ChauffeurId)
        {
            try
            {
                CamionChauffeurDA camionChauffeur = new CamionChauffeurDA();
                camionChauffeur.Add(CamionId, ChauffeurId);
            }
            catch
            {
                throw;
            }
        }

        public void Delete(Int32 CamionId, Int32 ChauffeurId)
        {
            try
            {
                CamionChauffeurDA camionChauffeur = new CamionChauffeurDA();
                camionChauffeur.Delete(CamionId, ChauffeurId);
            }
            catch
            {
                throw;
            }
        }
    }
}
