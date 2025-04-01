using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class Module
    {
        public DataTable List()
        {
            try
            {
                ModuleDA module = new ModuleDA();
                return module.List();
            }catch
            {
                throw;
            }
        }
        public DataTable FindById(Int32 Id)
        {
            try
            {
                ModuleDA module = new ModuleDA();
                return module.FindById(Id);

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
                ModuleDA module = new ModuleDA();
                return module.GetName(Id);
            }
            catch
            {
                throw;
            }
        }

        public string GetNameByCode(String Code)
        {
            try
            {
                ModuleDA module = new ModuleDA();
                return module.GetNameByCode(Code);
            }
            catch
            {
                throw;
            }
        }

        public void Add(String Designation, String Code)
        {
            try
            {
                ModuleDA module = new ModuleDA();
                module.Add(Designation, Code);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, String Designation, String Code)
        {
            try
            {
                ModuleDA module = new ModuleDA();
                module.Update(Id, Designation, Code);
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
                ModuleDA module = new ModuleDA();
                module.Delete(Id);
            }
            catch
            {
                throw;
            }
        }

    }
}
