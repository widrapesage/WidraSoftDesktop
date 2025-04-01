using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class TablesEnregistrements
    {
        public DataTable List()
        {
            try
            {
                TablesEnregistrementsDA tablesEnregistrements = new TablesEnregistrementsDA();
                return tablesEnregistrements.List();
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindNonLinkedRecordsByTableId(Int32 Id)
        {
            try
            {
                TablesEnregistrementsDA tablesEnregistrements = new TablesEnregistrementsDA();
                return tablesEnregistrements.FindNonLinkedRecordsByTableId(Id);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindByTablesId(Int32 Id)
        {
            try
            {
                TablesEnregistrementsDA tablesEnregistrements = new TablesEnregistrementsDA();
                return tablesEnregistrements.FindByTablesId(Id);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindByEnregistrementsId(Int32 Id)
        {
            try
            {
                TablesEnregistrementsDA tablesEnregistrements = new TablesEnregistrementsDA();
                return tablesEnregistrements.FindByEnregistrementsId(Id);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindByTablesIdEnregistrementsId(Int32 TablesId, Int32 EnregistrementId)
        {
            try
            {
                TablesEnregistrementsDA tablesEnregistrements = new TablesEnregistrementsDA();
                return tablesEnregistrements.FindByTablesIdEnregistrementsId(TablesId, EnregistrementId);
            }
            catch
            {
                throw;
            }
        }

        public void Add(Int32 TablesId, Int32 EnregistrementsId, Int32 EnregistrementParentId, Int32 Numero)
        {
            try
            {
                TablesEnregistrementsDA tablesEnregistrements = new TablesEnregistrementsDA();
                tablesEnregistrements.Add(TablesId, EnregistrementsId, EnregistrementParentId, Numero);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 TablesId, Int32 EnregistrementsId, Int32 EnregistrementParentId, Int32 Numero)
        {
            try
            {
                TablesEnregistrementsDA tablesEnregistrements = new TablesEnregistrementsDA();
                tablesEnregistrements.Update(TablesId, EnregistrementsId, EnregistrementParentId, Numero);
            }
            catch
            {
                throw;
            }
        }

        public void Delete(Int32 TablesId, Int32 EnregistrementsId)
        {
            try
            {
                TablesEnregistrementsDA tablesEnregistrements = new TablesEnregistrementsDA();
                tablesEnregistrements.Delete(TablesId, EnregistrementsId);
            }
            catch
            {
                throw;
            }
        }
    }
}
