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
    public partial class UtilisateurDetail : Form
    {
        String vg_Mode = "";
        Int32 vg_Id = 0;
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;
        public UtilisateurDetail(String Mode, Int32 Id)
        {
            InitializeComponent();
            vg_Mode = Mode;
            vg_Id = Id;
        }

        private void UtilisateurDetail_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            
            Groupe groupe = new Groupe();
            cbGroupeId.DataSource = groupe.List("1=1");
            cbGroupeId.DisplayMember = "DESIGNATION";
            cbGroupeId.ValueMember = "GROUPEID";
            

            if (vg_Mode == "Add")
            {
                try
                {
                    Clear();
                    Add_Item(); 
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                if (vg_Mode == "Edit")
                {
                    try
                    {
                        Edit_Item();
                    } 
                    catch
                    {
                        throw;
                    }
                }
            }
        }

        private void Add_Item()
        {
            if (txtId.Text == "" && txtDateCreation.Text == "" && txtNom.Text=="" && txtPrenom.Text=="" && txtLogin.Text == "" && txtPassword.Text == "" && cbGroupeId.Text == "")
            {
                btModifier.Enabled = false;
                btModifier.BackColor = Color.Transparent;
                btSupprimer.Enabled = false;
                btSupprimer.BackColor = Color.Transparent;


            }
                        
        }

        private void Edit_Item()
        {
                btAjouter.Enabled = false;
                btAjouter.BackColor = Color.Transparent;
                Disable();
                Bind_Fields();
           
        }
        private void Bind_Fields()
        {
            DataTable dt = new DataTable();
            Utilisateur utilisateur = new Utilisateur();
            dt = utilisateur.GetById(vg_Id);
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["UTILISATEURID"];
                txtId.Text = Id.ToString();
                txtDateCreation.Text = row["DATECREATION"].ToString();
                txtNom.Text = row["NOM"].ToString();
                txtPrenom.Text = row["PRENOM"].ToString();
                txtLogin.Text = row["LOGIN"].ToString();
                txtPassword.Text = row["PASSWORD"].ToString();
                if (row["GROUPEID"] is System.DBNull)
                    cbGroupeId.SelectedValue = 0;
                else
                    cbGroupeId.SelectedValue = (int)row["GROUPEID"];
            }
        }

        private void Disable()
        {
            txtNom.Enabled = false;
            txtDateCreation.Enabled = false;
            txtPrenom.Enabled = false;
            txtLogin.Enabled = false;
            txtPassword.Enabled = false;
            cbGroupeId.Enabled = false;
            
            vg_IsEnabled = false;
        }

        private void Enable()
        {
            txtNom.Enabled = true;
            txtDateCreation.Enabled = true;
            txtPrenom.Enabled = true;
            txtLogin.Enabled = true;
            txtPassword.Enabled = true;
            cbGroupeId.Enabled = true;

            vg_IsEnabled = true;
        }

        private void Clear()
        {
            txtId.Text = "";
            txtDateCreation.Text = "";
            txtNom.Text = "";
            txtPrenom.Text = "";
            txtLogin.Text = "";
            txtPassword.Text = "";
            cbGroupeId.Text = "";
        }

        private Int32 CbSelectedValue_Convert_Int(ComboBox o)
        {
            if (o.SelectedValue == null)
            {
                return 0;
            }
            else
            {
                return (Int32)o.SelectedValue;
            }
        }

        private void btAjouter_Click(object sender, EventArgs e)
        {
            try
            {                
                if (txtId.Text == "" && txtDateCreation.Text == "" && txtNom.Text != "" && txtPrenom.Text != "" && txtLogin.Text != "" && txtPassword.Text != "")
                {
                    Utilisateur utilisateur = new Utilisateur();
                    utilisateur.Add(txtNom.Text, txtPrenom.Text, txtLogin.Text, txtPassword.Text, CbSelectedValue_Convert_Int(cbGroupeId));
                    MessageBox.Show("Utilisateur ajouté avec succès");
                    Close();
                }
                else
                {   
                    MessageBox.Show("Informations incomplètes");
                }
            }
            catch
            {
                throw;
            }
        }

        private void btAjouter_MouseEnter(object sender, EventArgs e)
        {
            if (btAjouter.Enabled == true)
                btAjouter.BackColor = Color.MintCream;
        }

        private void btAjouter_MouseLeave(object sender, EventArgs e)
        {
            if (btAjouter.Enabled == true)
                btAjouter.BackColor = Color.MediumSeaGreen;
        }

        private void btModifier_MouseEnter(object sender, EventArgs e)
        {
            if (btModifier.Enabled == true)
                btModifier.BackColor = Color.MintCream;
        }

        private void btModifier_MouseLeave(object sender, EventArgs e)
        {
            if (btModifier.Enabled == true)
                btModifier.BackColor = Color.MediumSeaGreen;
        }

        private void btSupprimer_MouseEnter(object sender, EventArgs e)
        {
            if (btSupprimer.Enabled == true)
                btSupprimer.BackColor = Color.MintCream;
        }

        private void btSupprimer_MouseLeave(object sender, EventArgs e)
        {
            if (btSupprimer.Enabled == true)
                btSupprimer.BackColor = Color.MediumSeaGreen;
        }

        private void btModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (vg_Update == false && vg_IsEnabled == false)
                {
                    Enable();
                    btModifier.Text = "Valider";
                    vg_Update = true;
                }
                else
                {
                    try
                    {
                        if (txtId.Text != "" && txtNom.Text != "" && txtPrenom.Text != "" && txtLogin.Text != "" && txtPassword.Text != "")
                        {
                            Utilisateur utilisateur = new Utilisateur();
                            Int32 Id;
                            bool IsParsableId;
                            IsParsableId = Int32.TryParse(txtId.Text, out Id);
                            if (IsParsableId)
                            {
                                utilisateur.Update(Id,txtNom.Text, txtPrenom.Text , txtLogin.Text, txtPassword.Text, CbSelectedValue_Convert_Int(cbGroupeId));
                                MessageBox.Show("Utilisateur modifié avec succès");
                                btModifier.Text = "Modifier";
                                vg_Update = false;
                                Disable();
                                Bind_Fields();
                            }

                        }
                        else
                            MessageBox.Show("Informations incomplètes");
                    }
                    catch
                    {
                        throw;
                    }
                }
                
            }
            catch
            {
                throw;
            }
        }

        private void btSupprimer_Click(object sender, EventArgs e)
        {
            if (vg_Update)
            {
                MessageBox.Show("Vous ne pouvez pas supprimer l'enregistrement terminez d'abord la modification");
            }
            else
            {
                try
                {
                    Utilisateur utilisateur = new Utilisateur();
                    Int32 Id;
                    bool IsParsableId;
                    IsParsableId = Int32.TryParse(txtId.Text, out Id);
                    if (IsParsableId)
                    {
                        utilisateur.Delete(Id);
                        MessageBox.Show("Utilisateur supprimé avec succès");
                        Close();
                    }
                }
                catch
                {
                    throw;
                }
               
            }
        }
    }
}
