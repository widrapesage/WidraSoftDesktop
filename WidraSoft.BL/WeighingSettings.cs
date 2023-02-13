using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class WeighingSettings
    {
        public DataTable List(string filter)
        {
            try
            {
                WeighingSettingsDA weighingSettings= new WeighingSettingsDA();
                return weighingSettings.List(filter);
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
                WeighingSettingsDA weighingSettings = new WeighingSettingsDA();
                return weighingSettings.SearchBox(filter);
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
                WeighingSettingsDA weighingSettings = new WeighingSettingsDA();
                return weighingSettings.FindById(Id);
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
                WeighingSettingsDA weighingSettings = new WeighingSettingsDA();
                return weighingSettings.GetName(Id);
            }
            catch
            {
                throw;
            }
        }

        public void Add(String Designation, Int32 Camion, Int32 Chauffeur, Int32 Transporteur, Int32 Produit, Int32 Client, Int32 Destination, Int32 Provenance)
        {
            try
            {
                WeighingSettingsDA weighingSettings = new WeighingSettingsDA();
                weighingSettings.Add(Designation, Camion, Chauffeur, Transporteur, Produit,
                        Client, Destination, Provenance);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, String Designation, Int32 Camion, Int32 Chauffeur, Int32 Transporteur, Int32 Produit, Int32 Client, Int32 Destination, Int32 Provenance)
        {
            try
            {
                WeighingSettingsDA weighingSettings = new WeighingSettingsDA();
                weighingSettings.Update(Id, Designation, Camion, Chauffeur, Transporteur, Produit,
                        Client, Destination, Provenance);
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
                WeighingSettingsDA weighingSettings = new WeighingSettingsDA();
                weighingSettings.Delete(Id);
            }
            catch
            {
                throw;
            }
        }


    }
}
