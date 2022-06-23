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
            vg_filter = filter;
        }

        private void CamionsListe_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            Bind_Dgv();
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

            DgvList.ReadOnly = true;
        }

        private Int32 GetId()
        {
            try
            {
                return (int)DgvList[0, DgvList.CurrentCell.RowIndex].Value;

            }
            catch
            {
                throw;
            }
        }
        private Int32[] GetSelectedRowsId()
        {
            try
            {
                Int32 SelectedRowsCount = DgvList.Rows.GetRowCount(DataGridViewElementStates.Selected);
                Int32[] Selected = new Int32[SelectedRowsCount];
                if (SelectedRowsCount > 0)
                {

                    for (int i = 0; i < SelectedRowsCount; i++)
                    {
                        Selected[i] = Int32.Parse(DgvList.SelectedRows[i].Cells[0].Value.ToString());
                    }

                }
                return Selected;
            }
            catch
            {
                throw;
            }
        }

        private void ActualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vg_filter = "1=1";
            Bind_Dgv();
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new CamionDetail("Edit", GetId());
            form.Show();
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new CamionDetail("Edit", GetId());
            form.Show();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new CamionDetail("Add", 0);
            form.Show();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32[] selectedIds = new Int32[GetSelectedRowsId().Length];
            selectedIds = GetSelectedRowsId();
            if (GetSelectedRowsId().Length > 0)
            {
                for (int i = 0; i < GetSelectedRowsId().Length; i++)
                {
                    //MessageBox.Show(selectedIds[i].ToString());
                    Camion camion = new Camion();
                    camion.Delete(selectedIds[i]);
                }
                MessageBox.Show(GetSelectedRowsId().Length + " camion(s) supprimé(s)");
            }
            else
            {
                MessageBox.Show("Vous n'avez selectionné aucun enregistrement à supprimer");
            }
        }
    }
}
