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
    public partial class CamionsListe : Form
    {
        string vg_filter = "";
        public CamionsListe(string filter)
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            vg_filter = filter;
        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyMenuColors()) { }
        }

        private void CamionsListe_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            Bind_Dgv();
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = 0;
        }


        private void Bind_Dgv()
        {
            Camion camion = new Camion();
            DgvList.DataSource = camion.List(vg_filter);
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["CODE"].Width = 170; 
            DgvList.Columns["PLAQUE"].Width = 170; 
            DgvList.Columns["BADGE"].Visible = false;
            DgvList.Columns["TARE"].Width = 150;
            DgvList.Columns["TARE"].HeaderText = "TARE (KG)";
            DgvList.Columns["VALIDE"].Visible = false;
            DgvList.Columns["BLOQUE"].Visible = false;
            DgvList.Columns["TEXTEBLOQUE"].Visible = false;
            DgvList.Columns["ATTENTION"].Visible = false;
            DgvList.Columns["TEXTEATTENTION"].Visible = false;
            DgvList.Columns["DATECREATION"].Width = 200;
            DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            DgvList.Columns["OBSERVATIONS"].Visible = false;

            DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvList.ReadOnly = true;
        }

        private void Localize_Dgv(string lang)
        {
            if (lang == "fr")
            {
                DgvList.Columns["CODE"].HeaderText = "CODE";
                DgvList.Columns["PLAQUE"].HeaderText = "PLAQUE";
                DgvList.Columns["BADGE"].HeaderText = "N° BADGE";
                DgvList.Columns["TARE"].HeaderText = "TARE (KG)";
                DgvList.Columns["VALIDE"].HeaderText = "VALIDE";
                DgvList.Columns["BLOQUE"].HeaderText = "BLOQUE";
                DgvList.Columns["ATTENTION"].HeaderText = "ATTENTION";
                DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            }

            if (lang== "en")
            {
                DgvList.Columns["CODE"].HeaderText = "CODE";
                DgvList.Columns["PLAQUE"].HeaderText = "LICENSE PLATE";
                DgvList.Columns["BADGE"].HeaderText = "BADGE N°";
                DgvList.Columns["TARE"].HeaderText = "TARE (KG)";
                DgvList.Columns["VALIDE"].HeaderText = "VALID";
                DgvList.Columns["BLOQUE"].HeaderText = "BLOCKED";
                DgvList.Columns["ATTENTION"].HeaderText = "WARNING";
                DgvList.Columns["DATECREATION"].HeaderText = "CREATION DATE";
            }
            
            if (lang== "es")
            {
                DgvList.Columns["CODE"].HeaderText = "CÓDIGO";
                DgvList.Columns["PLAQUE"].HeaderText = "N° DE PLACA";
                DgvList.Columns["BADGE"].HeaderText = "N INSIGNIA°";
                DgvList.Columns["TARE"].HeaderText = "TARA (KG)";
                DgvList.Columns["VALIDE"].HeaderText = "VÁLIDO";
                DgvList.Columns["BLOQUE"].HeaderText = "OBSTRUIDO";
                DgvList.Columns["ATTENTION"].HeaderText = "ATENCIÓN";
                DgvList.Columns["DATECREATION"].HeaderText = "FECHA DE CREACIÓN";
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
            Form form = new CamionDetail("Edit", Common_functions.GetDatagridViewSelectedId(DgvList));
            form.Show();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new CamionDetail("Add", 0);
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
                    Camion camion = new Camion();
                    camion.Delete(selectedIds[i]);
                }
                MessageBox.Show(Common_functions.GetDatagridViewSelectedRowsId(DgvList).Length + " camion(s) supprimé(s)");
            }
            else
            {
                MessageBox.Show("Vous n'avez selectionné aucun enregistrement à supprimer");
            }
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(CamionsListe));
                Localize_Dgv("fr");
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(CamionsListe));
                Localize_Dgv("en");
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(CamionsListe));
                Localize_Dgv("es");
            }
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            Camion camion = new Camion();
            DgvList.DataSource = camion.SearchBox(txtSearchBox.Text);
        }
    }
}
