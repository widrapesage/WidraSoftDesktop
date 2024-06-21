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




        }
    }
}
