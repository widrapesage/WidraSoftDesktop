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

        public DataTable FindByMachineName(String Name)
        {
            try
            {
                PontDA pont = new PontDA();
                return pont.FindByMachineName(Name);
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

        public bool IsMultipleParam(Int32 PontId)
        {
            try
            {
                PontDA pont = new PontDA();
                return pont.IsMultipleParam(PontId);
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

        public string GetFluxDefault(Int32 Id)
        {
            try
            {
                PontDA pont = new PontDA();
                return pont.GetFluxDefault(Id);
            }
            catch
            {
                throw;
            }
        }

        public string GetTypeScanner2(Int32 Id)
        {
            try
            {
                PontDA pont = new PontDA();
                return pont.GetTypeScanner2(Id);
            }
            catch
            {
                throw;
            }
        }

        public int GetActiverScanner2(Int32 Id)
        {
            try
            {
                PontDA pont = new PontDA();
                return pont.GetActiverScanner2(Id);
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

        public String GetCOMBarriere(Int32 Id)
        {
            try
            {
                PontDA pont = new PontDA();
                return pont.GetCOMBarriere(Id);
            }
            catch
            {
                throw;
            }
        }

        public String GetCOMScanner(Int32 Id)
        {
            try
            {
                PontDA pont = new PontDA();
                return pont.GetCOMScanner(Id);
            }
            catch
            {
                throw;
            }
        }
        public Boolean Borne_Autoriser_Premiere_Pesee(Int32 Id)
        {
            try
            {
                PontDA pont = new PontDA();
                return pont.Borne_Autoriser_Premiere_Pesee(Id);
            }
            catch
            {
                throw;
            }
        }

        public Boolean Borne_Autoriser_Deuxieme_Pesee(Int32 Id)
        {
            try
            {
                PontDA pont = new PontDA();
                return pont.Borne_Autoriser_Deuxieme_Pesee(Id);
            }
            catch
            {
                throw;
            }
        }

        public Boolean Borne_Autoriser_Tare_Manuelle(Int32 Id)
        {
            try
            {
                PontDA pont = new PontDA();
                return pont.Borne_Autoriser_Tare_Manuelle(Id);
            }
            catch
            {
                throw;
            }
        }

        public void Add(String Designation, String NumPortCOM, Int32 Weight_SettingsId, Int32 Weighing_SettingsId, Int32 ActiverPoids, Int32 BaudRate,
                        Int32 DataBits, String StopBits, String Handshake, Int32 ReadTimeOut,  String Machine, String Demarrage, Int32 UtilisateurId, Int32 ActiverMultipleParam, Int32 Poids_Detection,
                        String BornePremierePesee, String BorneDeuxiemePesee, String BorneTareManuelle, String Flux_Default, Int32 Activer_Scanner, String TypeScanner, Int32 Activer_Barriere, String NumPortCom_Barriere,
                        String NumPortCom_Scanner, String Contact1, String Contact2, String Contact3, Int32 IsBorneLaunched, Int32 ActiverCamera1, String AdresseIp1, String Port1, String Login1,
                        String Password1, Int32 ActiverCamera2, String AdresseIp2, String Port2, String Login2, String Password2, Int32 ActiverCamera3, String AdresseIp3, String Port3, String Login3,
                        String Password3, Int32 ActiverScanner2, String TypeScanner2)
        {
            try
            {
                PontDA pont = new PontDA();
                pont.Add(Designation, NumPortCOM, Weight_SettingsId, Weighing_SettingsId, ActiverPoids, BaudRate,
                         DataBits, StopBits, Handshake, ReadTimeOut, Machine, Demarrage, UtilisateurId, ActiverMultipleParam, Poids_Detection, BornePremierePesee, BorneDeuxiemePesee, 
                         BorneTareManuelle, Flux_Default, Activer_Scanner, TypeScanner, Activer_Barriere, NumPortCom_Barriere, NumPortCom_Scanner, Contact1, Contact2, Contact3, IsBorneLaunched,  ActiverCamera1, AdresseIp1,  Port1,  Login1,
                         Password1,  ActiverCamera2,  AdresseIp2,  Port2,  Login2,  Password2,  ActiverCamera3,  AdresseIp3,  Port3,  Login3,
                         Password3, ActiverScanner2, TypeScanner2);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Int32 Id, String Designation, String NumPortCOM, Int32 Weight_SettingsId, Int32 Weighing_SettingsId, Int32 ActiverPoids, Int32 BaudRate,
                        Int32 DataBits, String StopBits, String Handshake, Int32 ReadTimeOut, String Machine, String Demarrage, Int32 UtilisateurId, Int32 ActiverMultipleParam, Int32 Poids_Detection,
                        String BornePremierePesee, String BorneDeuxiemePesee, String BorneTareManuelle, String Flux_Default, Int32 Activer_Scanner, String TypeScanner, Int32 Activer_Barriere, String NumPortCom_Barriere,
                        String NumPortCom_Scanner, String Contact1, String Contact2, String Contact3, Int32 IsBorneLaunched, Int32 ActiverCamera1, String AdresseIp1, String Port1, String Login1,
                        String Password1, Int32 ActiverCamera2, String AdresseIp2, String Port2, String Login2, String Password2, Int32 ActiverCamera3, String AdresseIp3, String Port3, String Login3,
                        String Password3, Int32 ActiverScanner2, String TypeScanner2)
        {
            try
            {
                PontDA pont = new PontDA();
                pont.Update(Id, Designation, NumPortCOM, Weight_SettingsId, Weighing_SettingsId, ActiverPoids, BaudRate,
                         DataBits, StopBits, Handshake, ReadTimeOut, Machine, Demarrage, UtilisateurId, ActiverMultipleParam, Poids_Detection, BornePremierePesee, BorneDeuxiemePesee,
                         BorneTareManuelle, Flux_Default, Activer_Scanner, TypeScanner, Activer_Barriere, NumPortCom_Barriere, NumPortCom_Scanner, Contact1, Contact2, Contact3, IsBorneLaunched, ActiverCamera1, AdresseIp1, Port1, Login1,
                         Password1, ActiverCamera2, AdresseIp2, Port2, Login2, Password2, ActiverCamera3, AdresseIp3, Port3, Login3,
                         Password3, ActiverScanner2, TypeScanner2);
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
