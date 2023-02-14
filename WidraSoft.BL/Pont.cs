using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class Pont
    {
        public DataTable List(string filter)
        {
            try
            {
                PontDA pont = new PontDA();
                return pont.List(filter);
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
                PontDA pont = new PontDA();
                return pont.SearchBox(filter);
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
                PontDA pont = new PontDA();
                return pont.FindById(Id);
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
                PontDA pont = new PontDA();
                return pont.IfExists(Name);
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
                PontDA pont = new PontDA();
                return pont.GetName(Id);
            }
            catch
            {
                throw;
            }
        }

        public string GetCOM(Int32 Id)
        {
            try
            {
                PontDA pont = new PontDA();
                return pont.GetCOM(Id);
            }
            catch
            {
                throw;
            }
        }

        public Int32 GetWeightSettingsId(Int32 Id)
        {
            try
            {
                PontDA pont = new PontDA();
                return pont.GetWeightSettingsId(Id);
            }
            catch
            {
                throw;
            }
        }

        public Int32 GetWeighingSettingsId(Int32 Id)
        {
            try
            {
                PontDA pont = new PontDA();
                return pont.GetWeighingSettingsId(Id);
            }
            catch
            {
                throw;
            }
        }

        public void Add(String Designation, String NumPortCOM, Int32 Weight_SettingsId, Int32 Weighing_SettingsId, Int32 ActiverPoids, Int32 BaudRate,
                        Int32 DataBits, String StopBits, String Handshake, Int32 ReadTimeOut)
        {
            try
            {
                PontDA pont = new PontDA();
                pont.Add(Designation, NumPortCOM, Weight_SettingsId, Weighing_SettingsId, ActiverPoids, BaudRate,
                         DataBits, StopBits, Handshake, ReadTimeOut);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, String Designation, String NumPortCOM, Int32 Weight_SettingsId, Int32 Weighing_SettingsId, Int32 ActiverPoids, Int32 BaudRate,
                        Int32 DataBits, String StopBits, String Handshake, Int32 ReadTimeOut)
        {
            try
            {
                PontDA pont = new PontDA();
                pont.Update(Id, Designation, NumPortCOM, Weight_SettingsId, Weighing_SettingsId, ActiverPoids, BaudRate,
                         DataBits, StopBits, Handshake, ReadTimeOut);
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
                PontDA pont = new PontDA();
                pont.Delete(Id);
            }
            catch
            {
                throw;
            }
        }
    }   
}
