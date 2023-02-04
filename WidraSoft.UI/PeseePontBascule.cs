using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WidraSoft.BL;

namespace WidraSoft.UI
{
    public partial class PeseePontBascule : Form
    {
        public PeseePontBascule()
        {
            InitializeComponent();
        }

        private void PeseePontBascule_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            Pont pont = new Pont();
            cbPont.DataSource = pont.List("1=1");
            cbPont.DisplayMember = "DESIGNATION";
            cbPont.ValueMember = "PONTID";
            cbPont.SelectedIndex = 0;

            Firme firme = new Firme();
            cbFirme.DataSource = firme.List("1=1");
            cbFirme.DisplayMember = "DESIGNATION";
            cbFirme.ValueMember = "FIRMEID";
            cbFirme.SelectedIndex = 0;

            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = 0;


            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            richTextBox2.SelectionAlignment = HorizontalAlignment.Right;
            richTextBox3.SelectionAlignment = HorizontalAlignment.Right;
            richTextBox4.SelectionAlignment = HorizontalAlignment.Right;
            
        }
    }
}
