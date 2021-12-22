using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class Groupe
    {
        public DataTable List(string filter)
        {
            try
            {
                GroupeDA groupe = new GroupeDA();
                return  groupe.List(filter);               
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
                GroupeDA groupe = new GroupeDA();
                return groupe.FindById(Id);
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
                GroupeDA groupe = new GroupeDA();
                return groupe.GetName(Id);
            }
            catch
            {
                throw;
            }
        }

        public void Add(String Designation, String Code, String Limiter, Int32 NbLimite)
        {
            try
            {
                GroupeDA groupe = new GroupeDA();
                groupe.Add(Designation, Code, Limiter, NbLimite);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, String Designation, String Code, String Limiter, Int32 NbLimite)
        {
            try
            {
                GroupeDA groupe = new GroupeDA();
                groupe.Update(Id, Designation, Code, Limiter, NbLimite);
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
                GroupeDA groupe = new GroupeDA();
                groupe.Delete(Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
