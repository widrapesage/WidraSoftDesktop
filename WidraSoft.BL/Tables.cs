using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class Tables
    {
        public DataTable List(string filter)
        {
            try
            {
                TablesDA tables = new TablesDA();
                return tables.List(filter);
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
                TablesDA tables = new TablesDA();
                return tables.SearchBox(Filter);
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
                TablesDA tables = new TablesDA();
                return tables.FindById(Id);
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindExceptId(Int32 Id)
        {
            try
            {
                TablesDA tables = new TablesDA();
                return tables.FindExceptId(Id);
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
                TablesDA tables = new TablesDA();
                return tables.GetName(Id);
            }
            catch
            {
                throw;
            }
        }

        public void Add(String Nom, Int32 InclureDansPesee, Int32 InclureDansTicket, Int32 EstEntrant, Int32 EstSortant, Int32 TableParentId, String Observations)
        {
            try
            {
                TablesDA tables = new TablesDA();
                tables.Add(Nom, InclureDansPesee, InclureDansTicket, EstEntrant, EstSortant, TableParentId, Observations);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, String Nom, Int32 InclureDansPesee, Int32 InclureDansTicket, Int32 EstEntrant, Int32 EstSortant, Int32 TableParentId, String Observations)
        {
            try
            {
                TablesDA tables = new TablesDA();
                tables.Update(Id, Nom, InclureDansPesee, InclureDansTicket, EstEntrant, EstSortant, TableParentId, Observations);
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
                TablesDA tables = new TablesDA();
                tables.Delete(Id);
            }
            catch
            {
                throw;
            }
        }

    }
}
