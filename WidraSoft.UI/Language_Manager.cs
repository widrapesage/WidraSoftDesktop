using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidraSoft.UI
{
    public class Language_Manager
    {
  
        public void ChangeLanguage(string lang, Form form, Type typeOfForm)
        {
            foreach (Control c in form.Controls)
            {
                Type controlType = c.GetType();
                String controlName = controlType.Name;
                ComponentResourceManager resources = new ComponentResourceManager(typeOfForm);
                if (controlName == "Panel" || controlName == "GroupBox")
                {
                    foreach (Control cc in c.Controls)
                    {
                        if (cc.GetType().Name == controlName)
                        {
                            foreach (Control sc in cc.Controls)
                            {
                                resources.ApplyResources(sc, sc.Name, new CultureInfo(lang));
                            }
                        }
                        else
                            resources.ApplyResources(cc, cc.Name, new CultureInfo(lang));
                    }
                }
                else if (controlName == "MenuStrip")
                {
                    MenuStrip strip = (MenuStrip)c;

                    ApplyResourceToToolStripItemCollection(strip.Items, resources, new CultureInfo(lang));
                }
                else
                {
                    resources.ApplyResources(c, c.Name, new CultureInfo(lang));
                }
            }


        }

        private static void ApplyResourceToToolStripItemCollection(ToolStripItemCollection col, ComponentResourceManager res, CultureInfo lang)
        {
            for (int i = 0; i < col.Count; i++)     // Apply to all sub items
            {
                ToolStripItem item = (ToolStripMenuItem)col[i];

                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    ToolStripMenuItem menuitem = (ToolStripMenuItem)item;
                    ApplyResourceToToolStripItemCollection(menuitem.DropDownItems, res, lang);
                }

                res.ApplyResources(item, item.Name, lang);
            }
        }

        public static String Localize(String text, string lang)
        {
            String return_Value = "";
            if (text == "Valider")
            {
                if (lang == "Francais(FR)")
                    return_Value = "Valider";
                else if (lang == "Anglais(ANG)")
                    return_Value = "Save";
                else
                    return_Value = "Valider";
            }
            if (text == "Modifier")
            {
                if (lang == "Francais(FR)")
                    return_Value = "Modifier";
                else if (lang == "Anglais(ANG)")
                    return_Value = "Edit";
                else
                    return_Value = "Modifier";
            }

            return return_Value;
        }
    }
}