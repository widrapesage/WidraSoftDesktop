using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidraSoft.DA;

namespace WidraSoft.BL
{
    public class WeightSettings
    {
        public DataTable List(string filter)
        {
            try
            {
                WeightSettingsDA weightSettings = new WeightSettingsDA();
                return weightSettings.List(filter);
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
                WeightSettingsDA weightSettings = new WeightSettingsDA();
                return weightSettings.SearchBox(filter);
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
                WeightSettingsDA weightSettings = new WeightSettingsDA();
                return weightSettings.FindById(Id);
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
                WeightSettingsDA weightSettings = new WeightSettingsDA();
                return weightSettings.GetName(Id);
            }
            catch
            {
                throw;
            }
        }

        public void Add(String Designation, Int32 TimerInterval, Int32 LongueurMinChaine, Int32 PositionDebut, Int32 LongueurChaine,
                       String CaractereSeparation, String ModeLecture, Int32 Stabilite, Int32 PositionStabilite, String ValeurStable, Int32 Negatif,
                       Int32 PositionNegatif, String ValeurNegatif)
        {
            try
            {
                WeightSettingsDA weightSettings = new WeightSettingsDA();
                weightSettings.Add(Designation, TimerInterval,  LongueurMinChaine,  PositionDebut,  LongueurChaine,
                        CaractereSeparation,  ModeLecture,  Stabilite,  PositionStabilite,  ValeurStable,  Negatif,
                        PositionNegatif,  ValeurNegatif);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, String Designation, Int32 TimerInterval, Int32 LongueurMinChaine, Int32 PositionDebut, Int32 LongueurChaine,
                        String CaractereSeparation, String ModeLecture, Int32 Stabilite, Int32 PositionStabilite, String ValeurStable, Int32 Negatif,
                        Int32 PositionNegatif, String ValeurNegatif)
        {
            try
            {
                WeightSettingsDA weightSettings = new WeightSettingsDA();
                weightSettings.Update(Id, Designation, TimerInterval, LongueurMinChaine, PositionDebut, LongueurChaine,
                        CaractereSeparation, ModeLecture, Stabilite, PositionStabilite, ValeurStable, Negatif,
                        PositionNegatif, ValeurNegatif);
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
                WeightSettingsDA weightSettings = new WeightSettingsDA();
                weightSettings.Delete(Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
