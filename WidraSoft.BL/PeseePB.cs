using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class PeseePB
    {
        public DataTable List(string filter)
        {
            try
            {
                PeseePBDA peseePBDA = new PeseePBDA();
                return peseePBDA.List(filter);
            }
            catch
            {
                throw;
            }
        }

        public DataTable SearchBox(string filter)
        {
            try
            {
                PeseePBDA peseePBDA = new PeseePBDA();
                return peseePBDA.SearchBox(filter);
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
                PeseePBDA peseePBDA = new PeseePBDA();
                return peseePBDA.FindById(Id);
            }
            catch
            {
                throw;
            }
        }

        public void Add(String TypePesee, String Flux, Int32 PontId, Int32 FirmeId, Int32 CamionId, Int32 ChauffeurId, Int32 TransporteurId, Int32 ProduitId, Int32 ClientId, Int32 ProvenanceId, Int32 DestinationId,
                        Int32 Poids1, DateTime DateHeurePoids1, Int32 Poids2, DateTime DateHeurePoids2, Int32 PoidsNet, String UserInfo, String EtatPesee)
        {
            try
            {
                PeseePBDA peseePBDA = new PeseePBDA();
                peseePBDA.Add(TypePesee, Flux, PontId, FirmeId, CamionId, ChauffeurId, TransporteurId, ProduitId, ClientId, ProvenanceId, DestinationId, Poids1, DateHeurePoids1, Poids2, DateHeurePoids2, PoidsNet,
                            UserInfo, EtatPesee);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, String TypePesee, String Flux, Int32 PontId, Int32 FirmeId, Int32 CamionId, Int32 ChauffeurId, Int32 TransporteurId, Int32 ProduitId, Int32 ClientId, Int32 ProvenanceId, Int32 DestinationId,
                        Int32 Poids1, DateTime DateHeurePoids1, Int32 Poids2, DateTime DateHeurePoids2, Int32 PoidsNet, String UserInfo, String EtatPesee)
        {
            try
            {
                PeseePBDA peseePBDA = new PeseePBDA();
                peseePBDA.Update(Id,TypePesee, Flux, PontId, FirmeId, CamionId, ChauffeurId, TransporteurId, ProduitId, ClientId, ProvenanceId, DestinationId, Poids1, DateHeurePoids1, Poids2, DateHeurePoids2, PoidsNet,
                            UserInfo, EtatPesee);
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
                PeseePBDA peseePBDA = new PeseePBDA();
                peseePBDA.Delete(Id);
            }
            catch
            {
                throw;
            }
        }



    }
}
