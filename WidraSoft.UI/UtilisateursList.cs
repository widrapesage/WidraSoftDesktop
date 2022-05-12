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
        string vg_filter = "";
        public UtilisateursList(string filter)
        {
            InitializeComponent();
            vg_filter = filter;
        }

        private void UtilisateursList_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            Bind_Dgv();
        }

        private void Bind_Dgv()
        {
            Utilisateur utilisateur = new Utilisateur();
            DgvList.DataSource = utilisateur.List(vg_filter);
            DgvList.Columns[0].Visible = false;
            DgvList.Columns["GROUPEID"].Visible = false;
            DgvList.Columns["NOM"].Width = 250;
            DgvList.Columns["PRENOM"].Width = 250;
            DgvList.Columns["LOGIN"].Width = 200;
            DgvList.Columns["GROUPE"].Width = 200;
            DgvList.Columns["DATECREATION"].Width = 200;
            DgvList.Columns["DATECREATION"].HeaderText = "DATE CREATION";
            
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
                if (SelectedRowsCount > 0)
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
            vg_filter = "1=1";
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
            if (GetSelectedRowsId().Length > 0)
            {
                for (int i = 0; i < GetSelectedRowsId().Length; i++)
                {
                    //MessageBox.Show(selectedIds[i].ToString());
                    Utilisateur utilisateur = new Utilisateur();
                    utilisateur.Delete(selectedIds[i]);
                }
                MessageBox.Show(GetSelectedRowsId().Length + " utilisateur(s) supprimé(s)");
                Bind_Dgv();

            }
            else
            {
                MessageBox.Show("Vous n'avez selectionné aucun enregistrement à supprimer");
            }
            
        }

        private void rechercherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
                if (f.Name == "UtilisateurSearch")
                {
                    f.Close();
                }
            Form form = new UtilisateurSearch();
            form.Show();
            Close();
            
        }
    }
}
