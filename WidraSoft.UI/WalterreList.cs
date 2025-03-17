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
    public partial class WalterreList : Form
    {
        string vg_filter = "";
        public WalterreList(string filter)
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            vg_filter = filter;
        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyMenuColors()) { }
        }


        private void WalterreList_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            WindowState = FormWindowState.Maximized;
            Bind_Dgv();
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = MenuGeneral.languuage_index;
        }

        private void Bind_Dgv()
        {
            Walterre walterre = new Walterre();
            DgvList.DataSource = walterre.List(vg_filter);
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["CODE"].Visible = true;
            DgvList.Columns["PRODUITID"].Visible = false;
            DgvList.Columns["PRODUIT"].Visible = true;
            DgvList.Columns["CLIENTID"].Visible = false;
            DgvList.Columns["CLIENT"].Visible = true;
            DgvList.Columns["VOLUME"].Visible = false;
            DgvList.Columns["SEUIL_MAX"].Visible = false;
            DgvList.Columns["REGION"].Visible = true;
            DgvList.Columns["TEXTE_BORNE"].Visible = false;
            DgvList.Columns["OBSERVATIONS"].Visible = false;
            DgvList.Columns["DEPASSEMENT"].Visible = false;
            DgvList.Columns["CLOTURE"].Visible = false;
            DgvList.Columns["DATECLOTURE"].Visible = true;
            DgvList.Columns["DATECREATION"].Visible = true;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;
        }

        private void Localize_Dgv(string lang)
        {
            if (lang == "fr")
            {
                DgvList.Columns["CODE"].HeaderText = "CODE";
                DgvList.Columns["PRODUIT"].HeaderText = "PRODUIT";
                DgvList.Columns["CLIENT"].HeaderText = "CLIENT";
                DgvList.Columns["DATECLOTURE"].HeaderText = "DATECLOTURE";
                DgvList.Columns["DATECREATION"].HeaderText = "DATECREATION";
            }

            if (lang == "en")
            {
                DgvList.Columns["CODE"].HeaderText = "CODE";
                DgvList.Columns["PRODUIT"].HeaderText = "PRODUCT";
                DgvList.Columns["CLIENT"].HeaderText = "CUSTOMER";
                DgvList.Columns["DATECLOTURE"].HeaderText = "CLOSING DATE";
                DgvList.Columns["DATECREATION"].HeaderText = "CREATION DATE";
            }

            if (lang == "es")
            {
                DgvList.Columns["CODE"].HeaderText = "CODE";
                DgvList.Columns["PRODUIT"].HeaderText = "PRODUIT";
                DgvList.Columns["CLIENT"].HeaderText = "CLIENT";
                DgvList.Columns["DATECLOTURE"].HeaderText = "DATECLOTURE";
                DgvList.Columns["DATECREATION"].HeaderText = "DATECREATION";
            }

        }

        private void ActualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vg_filter = "1=1";
            Bind_Dgv();
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DgvList.Focus();
            Form form = new WalterreDetail("Edit", Common_functions.GetDatagridViewSelectedId(DgvList));
            form.Show();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new WalterreDetail("Add", 0);
            form.Show();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            Walterre walterre = new Walterre();
            DgvList.DataSource = walterre.SearchBox(txtSearchBox.Text);
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(WalterreList));
                Localize_Dgv("fr");
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                //language_Manager.ChangeLanguage("en", this, typeof(WalterreList));
                Localize_Dgv("en");
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                //language_Manager.ChangeLanguage("es", this, typeof(WalterreList));
                Localize_Dgv("es");
            }
        }

        private void DgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DgvList.Columns[e.ColumnIndex].Name.Equals("STATUS"))
            {
                //Int32 intValue;
                if ((String)e.Value == "Pending")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(214, 60, 60);
                    e.CellStyle.SelectionBackColor = Color.DarkRed;
                }
                if ((String)e.Value == "Closed")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(23, 117, 63);
                    e.CellStyle.SelectionBackColor = Color.DarkSeaGreen;
                }

            }
        }
    }
}
