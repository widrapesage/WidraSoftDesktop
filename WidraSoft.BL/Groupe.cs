using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class Groupe
    {
        public DataTable List()
        {
            try
            {
                GroupeDA groupe = new GroupeDA();
                return  groupe.List();               
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

        public void Add(String Designation, String Code, Int32 Limiter, Int32 NbLimite)
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
    }
}
