using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidraSoft.UI
{
    public static class Values
    {
        public static List<Int32> BaudRate = new List<Int32>();
        public static List<Int32> Databits = new List<Int32>();
        public static List<String> StopBits = new List<String>();
        public static List<String> Handshake = new List<String>();
        public static List<String> WeightSettigs_ModeLecture = new List<String>();
        public static List<String> Borne_Style = new List<String>();
        public static List<String> DemarrageType = new List<String>();
        public static List<String> FormatTicket = new List<String>();
        public static List<String> YesNoBornePremierePesee = new List<String>();
        public static List<String> YesNoBorneDeuxiemePesee = new List<String>();
        public static List<String> YesNoBorneTareManuelle = new List<String>();
        public static List<String> Langue_Utilisateur = new List<String>();
        public static List<String> Regions_Belgique_Walterre = new List<String>();
        public static List<String> Flux_Default = new List<String>();
        public static List<String> TypeScanner = new List<String>();
        public static List<String> TypeScanner2 = new List<String>();
        static Values()
        {
            //BaudRate
            BaudRate.Add(75);
            BaudRate.Add(110);
            BaudRate.Add(134);
            BaudRate.Add(150);
            BaudRate.Add(300);
            BaudRate.Add(600);
            BaudRate.Add(1200);
            BaudRate.Add(1800);
            BaudRate.Add(2400);
            BaudRate.Add(4800);
            BaudRate.Add(7200);
            BaudRate.Add(9600);
            BaudRate.Add(14400);
            BaudRate.Add(19200);
            BaudRate.Add(38400);
            BaudRate.Add(57600);
            BaudRate.Add(115200);
            BaudRate.Add(128000);
            BaudRate.Add(153605);

            //DataBits
            Databits.Add(4);
            Databits.Add(5);
            Databits.Add(6);
            Databits.Add(7);
            Databits.Add(8);

            //StopBits
            StopBits.Add("None");
            StopBits.Add("1");
            StopBits.Add("1,5");
            StopBits.Add("2");

            //Handshake
            Handshake.Add("None");
            Handshake.Add("RequestToSend");
            Handshake.Add("RequestedToSendXOnXOff");
            Handshake.Add("XOnXOff");

            //WeightSettings_ModeLecture
            WeightSettigs_ModeLecture.Add("Ligne");
            WeightSettigs_ModeLecture.Add("Tableau");

            //Borne_Style
            Borne_Style.Add("List");
            Borne_Style.Add("Scan");
            Borne_Style.Add("List&Scan");
            Borne_Style.Add("Text");

            //Borne_Style
            DemarrageType.Add("Standard");
            DemarrageType.Add("Terminal");

            //Format_Ticket
            FormatTicket.Add("A5");

            //YesNo Borne Premiere Pesee
            YesNoBornePremierePesee.Add("Yes");
            YesNoBornePremierePesee.Add("No");

            //YesNo Borne Deuxieme Pesee
            YesNoBorneDeuxiemePesee.Add("Yes");
            YesNoBorneDeuxiemePesee.Add("No");

            //YesNo Borne Tare Manuelle
            YesNoBorneTareManuelle.Add("Yes");
            YesNoBorneTareManuelle.Add("No");

            //Langues Utilisateur
            Langue_Utilisateur.Add("FR");
            Langue_Utilisateur.Add("EN");
            Langue_Utilisateur.Add("ES");

            //Regions Belgique Walterre 
            Regions_Belgique_Walterre.Add("Anvers");
            Regions_Belgique_Walterre.Add("Gand");
            Regions_Belgique_Walterre.Add("Charleroi");
            Regions_Belgique_Walterre.Add("Ville de Bruxelles");
            Regions_Belgique_Walterre.Add("Liège");
            Regions_Belgique_Walterre.Add("Schaerbeek");
            Regions_Belgique_Walterre.Add("Anderlecht");
            Regions_Belgique_Walterre.Add("Bruges");
            Regions_Belgique_Walterre.Add("Namur");
            Regions_Belgique_Walterre.Add("Molenbeek-Saint-Jean");
            Regions_Belgique_Walterre.Add("Mons");
            Regions_Belgique_Walterre.Add("Alost");
            Regions_Belgique_Walterre.Add("Hasselt");
            Regions_Belgique_Walterre.Add("Ixelles");
            Regions_Belgique_Walterre.Add("Beveren-Kruibeke-Zwijndrecht");
            Regions_Belgique_Walterre.Add("Saint-Nicolas");
            Regions_Belgique_Walterre.Add("La Louvière");
            Regions_Belgique_Walterre.Add("Courtrai");
            Regions_Belgique_Walterre.Add("Ostende");
            Regions_Belgique_Walterre.Add("Genk");
            Regions_Belgique_Walterre.Add("Roulers");
            Regions_Belgique_Walterre.Add("Seraing");
            Regions_Belgique_Walterre.Add("Woluwe-Saint-Lambert");
            Regions_Belgique_Walterre.Add("Mouscron");
            Regions_Belgique_Walterre.Add("Forest");
            Regions_Belgique_Walterre.Add("Verviers");


            //Flux_Default
            Flux_Default.Add("In");
            Flux_Default.Add("Out");

            //Type Scanner 
            TypeScanner.Add("Lecteur QR Code HoneyWell");
            TypeScanner.Add("Lecteur badge RFID");

            //Type Scanner 2
            TypeScanner2.Add("Ticket pesee");
            TypeScanner2.Add("Walterre");

        }
    }
}
