using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidraSoft.UI
{
    public static class LanguageList
    {
        public static List<String> Languages = new List<String>();

        static LanguageList()
        {
            Languages.Add("FR");
            Languages.Add("EN");
            Languages.Add("ES");
        }

    }
}
