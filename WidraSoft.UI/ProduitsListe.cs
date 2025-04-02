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
    public partial class ProduitsListe : Form
    {
        string vg_filter = "";
        public ProduitsListe(string filter)
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            vg_filter = filter;
        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyMenuColors()) { }
        }


        private void ProduitsListe_Load(object sender, EventArgs e)
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
            Produit produit = new Produit();
            DgvList.DataSource = produit.List(vg_filter);
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["DESIGNATION"].Width = 170;
            DgvList.Columns["GROUPEPRODUITID"].Visible = false;
            DgvList.Columns["ESTENTRANT"].Visible = false;
            DgvList.Columns["ESTSORTANT"].Visible = false;
            DgvList.Columns["VALIDE"].Visible = false;
            DgvList.Columns["POIDSALERTEMIN"].Visible = false;
            DgvList.Columns["ACTIVERALERTEMIN"].Visible = false;
            DgvList.Columns["POIDSALERTEMAX"].Visible = false;
            DgvList.Columns["ACTIVERALERTEMAX"].Visible = false;
            DgvList.Columns["EMPECHERTICKETSIALERTE"].Visible = false;
            DgvList.Columns["DECHET"].Visible = false;
            DgvList.Columns["TYPEDECHETID"].Visible = false;
            DgvList.Columns["PRIXUNITAIRE"].Visible = false;
            DgvList.Columns["TVA"].Visible = false;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;
        }

        private void Localize_Dgv(string lang)
        {
            if (lang == "fr")
            {
                DgvList.Columns["DESIGNATION"].HeaderText = "DESIGNATION";
                DgvList.Columns["ESTENTRANT"].HeaderText = "ENTRANT";
                DgvList.Columns["ESTSORTANT"].HeaderText = "SORTANT";
                DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            }

            if (lang == "en")
            {
                DgvList.Columns["DESIGNATION"].HeaderText = "NAME";
                DgvList.Columns["ESTENTRANT"].HeaderText = "INCOMING";
                DgvList.Columns["ESTSORTANT"].HeaderText = "OUTGOING";
                DgvList.Columns["DATECREATION"].HeaderText = "CREATION DATE";
            }

            if (lang == "es")
            {
                DgvList.Columns["DESIGNATION"].HeaderText = "DESIGNACIÓN";
                DgvList.Columns["ESTENTRANT"].HeaderText = "ENTRANTE";
                DgvList.Columns["ESTSORTANT"].HeaderText = "SALIENTE";
                DgvList.Columns["DATECREATION"].HeaderText = "FECHA DE CREACIÓN";
            }
        }



        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DgvList.Focus();
            Form form = new ProduitDetail("Edit", Common_functions.GetDatagridViewSelectedId(DgvList));
            form.Show();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ProduitDetail("Add", 0);
            form.Show();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32[] selectedIds = new Int32[Common_functions.GetDatagridViewSelectedRowsId(DgvList).Length];
            selectedIds = Common_functions.GetDatagridViewSelectedRowsId(DgvList);
            if (Common_functions.GetDatagridViewSelectedRowsId(DgvList).Length > 0)
            {
                for (int i = 0; i < Common_functions.GetDatagridViewSelectedRowsId(DgvList).Length; i++)
                {
                    //MessageBox.Show(selectedIds[i].ToString());
                    Produit produit = new Produit();
                    produit.Delete(selectedIds[i]);
                }
                MessageBox.Show(Common_functions.GetDatagridViewSelectedRowsId(DgvList).Length + " produits(s) supprimé(s)");
            }
            else
            {
                MessageBox.Show("Vous n'avez selectionné aucun enregistrement à supprimer");
            }
        }

        private void ActualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vg_filter = "1=1";
            Bind_Dgv();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            Produit produit = new Produit();
            DgvList.DataSource = produit.SearchBox(txtSearchBox.Text);
        }



        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(ProduitsListe));
                Localize_Dgv("fr");
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(ProduitsListe));
                Localize_Dgv("en");
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(ProduitsListe));
                Localize_Dgv("es");
            }
        }

        private void DgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Form form = new ProduitDetail("Edit", Common_functions.GetDatagridViewSelectedId(DgvList));
                form.Show();
            }
            catch { throw; }
        }
    }
}