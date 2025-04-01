using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class Chauffeur
    {
        public DataTable List(string filter)
        {
            try
            {
                ChauffeurDA chauffeur = new ChauffeurDA();
                return chauffeur.List(filter);
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
                ChauffeurDA chauffeur = new ChauffeurDA();
                return chauffeur.SearchBox(Filter);
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
                ChauffeurDA chauffeur = new ChauffeurDA();
                return chauffeur.FindById(Id);
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
                ChauffeurDA chauffeur = new ChauffeurDA();
                return chauffeur.IfExists(Name);
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
                ChauffeurDA chauffeur = new ChauffeurDA();
                return chauffeur.GetName(Id);
            }
            catch
            {
                throw;
            }
        }

        public int GetMaxId()
        {
            try
            {
                ChauffeurDA chauffeur = new ChauffeurDA();
                return chauffeur.GetMaxId();
            }
            catch
            {
                throw;
            }
        }

        public string GetBadge(Int32 Id)
        {
            try
            {
                ChauffeurDA chauffeur = new ChauffeurDA();
                return chauffeur.GetBadge(Id);
            }
            catch
            {
                throw;
            }
        }

        public int GetIdByBadge(string Name)
        {
            try
            {
                ChauffeurDA chauffeur = new ChauffeurDA();
                return chauffeur.GetIdByBadge(Name);
            }
            catch
            {
                throw;
            }
        }

        public int CountByBadge(string Name)
        {
            try
            {
                CamionDA camion = new CamionDA();
                return camion.CountByBadge(Name);
            }
            catch
            {
                throw;
            }
        }

        public void Add(String Badge, String Nom, String NumeroNational, String NumeroPermis, String Adresse, String CodePostal, String Localite, String Pays,
           String Telephone, String Observations, Int32 Valide, Int32 Bloque, String TexteBloque, Int32 Attention, String TexteAttention)
        {
            try
            {
                ChauffeurDA chauffeur = new ChauffeurDA();
                chauffeur.Add(Badge, Nom, NumeroNational, NumeroPermis, Adresse, CodePostal, Localite, Pays,
                                Telephone, Observations, Valide, Bloque, TexteBloque, Attention, TexteAttention);

            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, String Badge, String Nom, String NumeroNational, String NumeroPermis, String Adresse, String CodePostal, String Localite, String Pays,
                           String Telephone, String Observations, Int32 Valide, Int32 Bloque, String TexteBloque, Int32 Attention, String TexteAttention)
        {
            try
            {
                ChauffeurDA chauffeur = new ChauffeurDA();
                chauffeur.Update(Id, Badge, Nom, NumeroNational, NumeroPermis, Adresse, CodePostal, Localite, Pays,
                                Telephone, Observations, Valide, Bloque, TexteBloque, Attention, TexteAttention);

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
                ChauffeurDA chauffeur = new ChauffeurDA();
                chauffeur.Delete(Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
