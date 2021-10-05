using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WidraSoft.BL;

namespace WidraSoft.UI
{
    public partial class UtilisateursList : Form
    {
        public UtilisateursList()
        {
            InitializeComponent();
        }

        private void UtilisateursList_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            Bind_Dgv();
        }

        private void Bind_Dgv()
        {
            Utilisateur utilisateur = new Utilisateur();
            DgvList.DataSource = utilisateur.List();
            DgvList.Columns[0].Visible = false;
            DgvList.ReadOnly = true;
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new UtilisateurDetail("Add",0);
            form.Show();
        }

        private Int32 GetId()
        {
            try
            {
                return  (int)DgvList[0, DgvList.CurrentCell.RowIndex].Value;
                
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
                if (SelectedRowsCount > 1)
                {
                    
                    for (int i = 0; i <SelectedRowsCount; i++ )
                    {
                        Selected[i] = Int32.Parse(DgvList.SelectedRows[i].Cells[0].Value.ToString()) ; 
                    }
                    
                }
                return Selected;
            }
            catch
            {
                throw;
            }
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new UtilisateurDetail("Edit", GetId());
            form.Show();
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new UtilisateurDetail("Edit", GetId());
            form.Show();
        }

        private void ActualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bind_Dgv();
        }

        private void DgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form form = new UtilisateurDetail("Edit", GetId());
            form.Show();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32[] selectedIds = new Int32[GetSelectedRowsId().Length];
            selectedIds = GetSelectedRowsId();
            for (int i = 0; i < GetSelectedRowsId().Length; i++ )
            {
                MessageBox.Show(selectedIds[i].ToString());
            }
        }
    }
}
