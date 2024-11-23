using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class Camion
    {
        public DataTable List(string filter)
        {
            try
            {
                CamionDA camion = new CamionDA();
                return camion.List(filter);
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
                CamionDA camion = new CamionDA();
                return camion.SearchBox(Filter);
            } 
            catch
            {
                throw;
            }
        }

        public DataTable SearchBox_Terminal(string Filter)
        {
            try
            {
                CamionDA camion = new CamionDA();
                return camion.SearchBox_Terminal(Filter);
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
                CamionDA camion = new CamionDA();
                return camion.FindById(Id);
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
                CamionDA camion = new CamionDA();
                return camion.IfExists(Name);
            }
            catch
            {
                throw;
            }
        }

        public bool IfIsPending(String Name)
        {
            try
            {
                CamionDA camion = new CamionDA();
                return camion.IfIsPending(Name);
            }
            catch
            {
                throw;
            }
        }

        public int GetPendingId(string Name)
        {
            try
            {
                CamionDA camion = new CamionDA();
                return camion.GetPendingId(Name);
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
                CamionDA camion = new CamionDA();
                return camion.GetName(Id);
            }
            catch
            {
                throw;
            }
        }

        public int GetIdByName(string Name)
        {
            try
            {
                CamionDA camion = new CamionDA();
                return camion.GetIdByName(Name);
            }
            catch
            {
                throw;
            }
        }

        public void Add(String Code, String Plaque, String Badge, Int32 Tare, Int32 Valide,
           Int32 Bloque, String TexteBloque, Int32 Attention, String TexteAttention, String Observations)
        {
            try
            {
                CamionDA camion = new CamionDA();
                camion.Add(Code, Plaque,  Badge,  Tare,  Valide,
                    Bloque,  TexteBloque,  Attention,  TexteAttention,  Observations);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id,String Code, String Plaque, String Badge, Int32 Tare, Int32 Valide,
           Int32 Bloque, String TexteBloque, Int32 Attention, String TexteAttention, String Observations)
        {
            try
            {
                CamionDA camion = new CamionDA();
                camion.Update(Id, Code, Plaque, Badge, Tare, Valide,
                    Bloque, TexteBloque, Attention, TexteAttention, Observations);
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
                CamionDA camion = new CamionDA();
                camion.Delete(Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
