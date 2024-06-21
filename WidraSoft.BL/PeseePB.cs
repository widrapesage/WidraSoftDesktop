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

        public DataTable FindWeighingsInProgress()
        {
            try
            {
                PeseePBDA peseePBDA = new PeseePBDA();
                return peseePBDA.FindWeighingsInProgress();
            }
            catch
            {
                throw;
            }
        }

        public Int32 GetMaxIdByPontId(Int32 Id)
        {
            try
            {
                PeseePBDA peseePBDA= new PeseePBDA();
                return peseePBDA.GetMaxIdByPontId(Id);
            }
            catch
            {
                throw;
            }
        }


        public void Add(String TypePesee, String Flux, Int32 PontId, Int32 WeighingSettingsId, Int32 FirmeId, Int32 CamionId, Int32 ChauffeurId, Int32 TransporteurId, Int32 ProduitId, Int32 ClientId, Int32 EnregistrementsId1,
            Int32 TablesId1, String TablesName1, String Enregistrements1, Int32 EnregistrementsId2, Int32 TablesId2, String TablesName2, String Enregistrements2, Int32 EnregistrementsId3, Int32 TablesId3, String TablesName3, String Enregistrements3,
            Int32 EnregistrementsId4, Int32 TablesId4, String TablesName4, String Enregistrements4, Int32 EnregistrementsId5, Int32 TablesId5, String TablesName5, String Enregistrements5, Int32 EnregistrementsId6, Int32 TablesId6, String TablesName6, String Enregistrements6,
            Int32 EnregistrementsId7, Int32 TablesId7, String TablesName7, String Enregistrements7,
            Int32 Poids1, DateTime DateHeurePoids1, Int32 Poids2, DateTime DateHeurePoids2, Int32 PoidsNet, String UserInfo, String EtatPesee)
        {
            try
            {
                PeseePBDA peseePBDA = new PeseePBDA();
                peseePBDA.Add(TypePesee, Flux, PontId, WeighingSettingsId, FirmeId, CamionId, ChauffeurId, TransporteurId, ProduitId, ClientId, EnregistrementsId1, TablesId1, TablesName1, Enregistrements1,
                    EnregistrementsId2, TablesId2, TablesName2, Enregistrements2, EnregistrementsId3, TablesId3, TablesName3, Enregistrements3, EnregistrementsId4, TablesId4, TablesName4, Enregistrements4,
                    EnregistrementsId5, TablesId5, TablesName5, Enregistrements5, EnregistrementsId6, TablesId6, TablesName6, Enregistrements6, EnregistrementsId7, TablesId7, TablesName7, Enregistrements7,
                    Poids1, DateHeurePoids1, Poids2, DateHeurePoids2, PoidsNet,
                            UserInfo, EtatPesee);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, String TypePesee, String Flux, Int32 PontId, Int32 WeighingSettingsId, Int32 FirmeId, Int32 CamionId, Int32 ChauffeurId, Int32 TransporteurId, Int32 ProduitId, Int32 ClientId, Int32 EnregistrementsId1,
            Int32 TablesId1, String TablesName1, String Enregistrements1, Int32 EnregistrementsId2, Int32 TablesId2, String TablesName2, String Enregistrements2, Int32 EnregistrementsId3, Int32 TablesId3, String TablesName3, String Enregistrements3,
            Int32 EnregistrementsId4, Int32 TablesId4, String TablesName4, String Enregistrements4, Int32 EnregistrementsId5, Int32 TablesId5, String TablesName5, String Enregistrements5, Int32 EnregistrementsId6, Int32 TablesId6, String TablesName6, String Enregistrements6,
            Int32 EnregistrementsId7, Int32 TablesId7, String TablesName7, String Enregistrements7,
            Int32 Poids1, DateTime DateHeurePoids1, Int32 Poids2, DateTime DateHeurePoids2, Int32 PoidsNet, String UserInfo, String EtatPesee)
        {
            try
            {
                PeseePBDA peseePBDA = new PeseePBDA();
                peseePBDA.Update(Id, TypePesee, Flux, PontId, WeighingSettingsId, FirmeId, CamionId, ChauffeurId, TransporteurId, ProduitId, ClientId, EnregistrementsId1, TablesId1, TablesName1, Enregistrements1,
                    EnregistrementsId2, TablesId2, TablesName2, Enregistrements2, EnregistrementsId3, TablesId3, TablesName3, Enregistrements3, EnregistrementsId4, TablesId4, TablesName4, Enregistrements4,
                    EnregistrementsId5, TablesId5, TablesName5, Enregistrements5, EnregistrementsId6, TablesId6, TablesName6, Enregistrements6, EnregistrementsId7, TablesId7, TablesName7, Enregistrements7,
                    Poids1, DateHeurePoids1, Poids2, DateHeurePoids2, PoidsNet,
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
