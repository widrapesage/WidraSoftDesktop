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
            ComponentResourceManager resources = new ComponentResourceManager(typeOfForm);

            resources.ApplyResources(form, form.Name, new CultureInfo(lang));

            foreach (Control c in form.Controls)
            {
                Type controlType = c.GetType();
                String controlName = controlType.Name;
                
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
                if (lang == "FR") return_Value = "Valider";
                else if (lang == "EN") return_Value = "Save";
                else if (lang == "ES") return_Value = "Validar";
                else return_Value = "Valider";
            }
            if (text == "Modifier")
            {
                if (lang == "FR") return_Value = "Modifier";
                else if (lang == "EN") return_Value = "Edit";
                else if (lang == "ES") return_Value = "Editar";
                else return_Value = "Modifier";
            }
            if (text == "OK")
            {
                if (lang == "FR") return_Value = "OK";
                else if (lang == "EN")  return_Value = "OK";
                else if (lang == "ES") return_Value = "OK";
                else return_Value = "OK";
            }
            if (text == "Annuler")
            {
                if (lang == "FR") return_Value = "Annuler";
                else if (lang == "EN") return_Value = "Cancel";
                else if (lang == "ES") return_Value = "Anular";
                else return_Value = "Annuler";
            }           
            if (text == "Recommencer")
            {
                if (lang == "FR") return_Value = "Recommencer";
                else if (lang == "EN") return_Value = "Retry";
                else if (lang == "ES") return_Value = "Reiniciar";
                else return_Value = "Recommencer";
            }
            if (text == "Oui")
            {
                if (lang == "FR") return_Value = "Oui";
                else if (lang == "EN") return_Value = "Yes";
                else if (lang == "ES") return_Value = "Sí";
                else return_Value = "Oui";
            }
            if (text == "Non")
            {
                if (lang == "FR") return_Value = "Non";
                else if (lang == "EN") return_Value = "No";
                else if (lang == "ES") return_Value = "No";
                else return_Value = "Non";
            }
            if (text == "Abandonner")
            {
                if (lang == "FR") return_Value = "Abandonner";
                else if (lang == "EN") return_Value = "Abort";
                else if (lang == "ES") return_Value = "Abandonar";
                else return_Value = "Abandonner";
            } 
            if (text == "Ignorer")
            {
                if (lang == "FR") return_Value = "Ignorer";
                else if (lang == "EN") return_Value = "Ignore";
                else if (lang == "ES") return_Value = "Ignorar";
                else return_Value = "Ignorer";
            }

            return return_Value;
        }
    }
}