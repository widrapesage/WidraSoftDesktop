using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidraSoft.UI
{
    public static class Language
    {
        public static List<String> Languages = new List<String>();

        static Language()
        {
            Languages.Add("Francais(FR)");
            Languages.Add("Anglais(ANG)");
            Languages.Add("Espagnol(ESP)");
        }

    }
}
