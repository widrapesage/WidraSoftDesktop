using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class GroupeModule
    {
        public DataTable List()
        {
            try
            {
                GroupeModuleDA groupemodule = new GroupeModuleDA();
                return groupemodule.List();
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindAuthorizedModulesByGroupeId(Int32 Id)
        {
            try
            {
                GroupeModuleDA groupemodule = new GroupeModuleDA();
                return groupemodule.FindAuthorizedModulesByGroupeId(Id);
            }
            catch
            {
                throw;
            }
        }
        public DataTable FindNonAuthorizedModulesByGroupeId(Int32 Id)
        {
            try
            {
                GroupeModuleDA groupemodule = new GroupeModuleDA();
                return groupemodule.FindNonAuthorizedModulesByGroupeId(Id);
            }
            catch
            {
                throw;
            }
        }

        public bool IsAuthorized(Int32 GroupeId, Int32 ModuleId)
        {
            try
            {
                GroupeModuleDA groupemodule = new GroupeModuleDA();
                return groupemodule.IsAuthorized(GroupeId, ModuleId);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindByGroupeId(Int32 Id)
        {
            try
            {
                GroupeModuleDA groupemodule = new GroupeModuleDA();
                return groupemodule.FindByGroupeId(Id);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindByModuleId(Int32 Id)
        {
            try
            {
                GroupeModuleDA groupemodule = new GroupeModuleDA();
                return groupemodule.FindByModuleId(Id);
            }
            catch
            {
                throw;
            }
        }

        public int Get_Max_Id()
        {
            try
            {
                GroupeModuleDA groupemodule = new GroupeModuleDA();
                return groupemodule.Get_Max_Id();
            }
            catch
            {
                throw;
            }
        }
        public void Add(Int32 GroupeId, Int32 ModuleId, Int32 Access, String TypeAcess)
        {
            try
            {
                GroupeModuleDA groupemodule = new GroupeModuleDA();
                groupemodule.Add(GroupeId, ModuleId, Access, TypeAcess);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, Int32 GroupeId, Int32 ModuleId, Int32 Access, String TypeAcess)
        {
            try
            {
                GroupeModuleDA groupemodule = new GroupeModuleDA();
                groupemodule.Update(Id, GroupeId, ModuleId, Access, TypeAcess);
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
                GroupeModuleDA groupemodule = new GroupeModuleDA();
                groupemodule.Delete(Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
