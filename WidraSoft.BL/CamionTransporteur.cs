using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class CamionTransporteur
    {
        public DataTable List()
        {
            try
            {
                CamionTransporteurDA camionTransporteur = new CamionTransporteurDA();
                return camionTransporteur.List();
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindNonLinkedCarriersByCamionId(Int32 Id)
        {
            try
            {
                CamionTransporteurDA camionTransporteur = new CamionTransporteurDA();
                return camionTransporteur.FindNonLinkedCarriersByCamionId(Id);
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
                CamionTransporteurDA camionTransporteur = new CamionTransporteurDA();
                return camionTransporteur.FindByCamionId(Id);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindByTransporteurId(Int32 Id)
        {
            try
            {
                CamionTransporteurDA camionTransporteur = new CamionTransporteurDA();
                return camionTransporteur.FindByTransporteurId(Id);
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
                CamionTransporteurDA camionTransporteur = new CamionTransporteurDA();
                return camionTransporteur.CountByCamionId(Id);
            }
            catch
            {
                throw;
            }
        }

            public int GetFirstTransporteurByCamionId(int Id)
            {
            try
            {
                CamionTransporteurDA camionTransporteur = new CamionTransporteurDA();
                return camionTransporteur.GetFirstTransporteurByCamionId(Id);
            }
            catch
            {
                throw;
            }
        }


        public void Add(Int32 CamionId, Int32 TransporteurId)
        {
            try
            {
                CamionTransporteurDA camionTransporteur = new CamionTransporteurDA();
                camionTransporteur.Add(CamionId, TransporteurId);
            }
            catch
            {
                throw;
            }
        }

        public void Delete(Int32 CamionId, Int32 TransporteurId)
        {
            try
            {
                CamionTransporteurDA camionTransporteur = new CamionTransporteurDA();
                camionTransporteur.Delete(CamionId, TransporteurId);
            }
            catch
            {
                throw;
            }
        }
    }
}
