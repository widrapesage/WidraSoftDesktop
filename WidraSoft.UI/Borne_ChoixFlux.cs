using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidraSoft.UI
{
    public partial class Borne_ChoixFlux : Form
    {
        String vg_Lang;
        public Borne_ChoixFlux(string Lang)
        {
            InitializeComponent();
            vg_Lang = Lang;
        }

        private void Borne_ChoixFlux_Load(object sender, EventArgs e)
        {
            if (vg_Lang == "fr")
            {
                lbTexte.Text = "Choisir le flux";
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(Borne_ChoixFlux));
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
            }               
            else if (vg_Lang == "en")
            {
                lbTexte.Text = "Choose the flow";
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(Borne_ChoixFlux));
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
            }
            else
            {
                lbTexte.Text = "Elegir flujo";
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(Borne_ChoixFlux));
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
            }               
        }
    }
}
