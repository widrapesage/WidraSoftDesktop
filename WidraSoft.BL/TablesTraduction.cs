using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class TablesTraduction
    {
        public DataTable List()
        {
            try
            {
                TablesTraductionDA tablesTraduction = new TablesTraductionDA();
                return tablesTraduction.List();
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
                TablesTraductionDA tablesTraduction = new TablesTraductionDA();
                return tablesTraduction.FindById(Id);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindByTableId(Int32 Id)
        {
            try
            {
                TablesTraductionDA tablesTraduction = new TablesTraductionDA();
                return tablesTraduction.FindByTableId(Id);
            }
            catch
            {
                throw;
            }
        }

        public string GetValueByTablesIdAndLang(Int32 TablesId, String CodeLang)
        {
            try
            {
                TablesTraductionDA tablesTraduction = new TablesTraductionDA();
                return tablesTraduction.GetValueByTablesIdAndLang(TablesId, CodeLang);
            }
            catch
            {
                throw;
            }
        }

        public void Add(Int32 TablesId, String CodeLang, String Value)
        {
            try
            {
                TablesTraductionDA tablesTraduction = new TablesTraductionDA();
                tablesTraduction.Add(TablesId, CodeLang, Value);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, Int32 TablesId, String CodeLang, String Value)
        {
            try
            {
                TablesTraductionDA tablesTraduction = new TablesTraductionDA();
                tablesTraduction.Update(Id, TablesId, CodeLang, Value);
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
                TablesTraductionDA tablesTraduction = new TablesTraductionDA();
                tablesTraduction.Delete(Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
