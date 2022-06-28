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
    public partial class CamionDetail : Form
    {
        String vg_Mode = "";
        Int32 vg_Id = 0;
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;
        public CamionDetail(String Mode, Int32 Id)
        {
            InitializeComponent();
            vg_Mode = Mode;
            vg_Id = Id;
        }

        private void CamionDetail_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
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
            if (txtId.Text == "" && txtDateCreation.Text == "" && txtBadge.Text == "" && txtPlaque.Text == "" && txtCode.Text == "" && txtTare.Text == ""
                && txtValide.Text == "" && txtBloque.Text == "" && txtBlocage.Text == "" && txtAttention.Text == "" && txtAlerte.Text == "" && txtObservations.Text == "")
            {
                btModifier.Enabled = false;
                btModifier.BackColor = Color.Transparent;
                btSupprimer.Enabled = false;
                btSupprimer.BackColor = Color.Transparent;

                txtTare.Text = "0";
                txtValide.Text = "1";
                chx_Valide.Checked = true;
                txtBloque.Text = "0";
                chx_Bloque.Checked = false;
                txtAttention.Text = "0";
                chx_Attention.Checked = false;

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
            Camion camion = new Camion();
            dt = camion.FindById(vg_Id);
            foreach (DataRow row in dt.Rows)
            {
                int Id = (int)row["CAMIONID"];
                txtId.Text = Id.ToString();
                txtDateCreation.Text = row["DATECREATION"].ToString();
                txtBadge.Text = row["BADGE"].ToString();
                txtPlaque.Text = row["PLAQUE"].ToString();
                txtTare.Text = row["TARE"].ToString();
                txtValide.Text = row["VALIDE"].ToString();
                txtValide.Visible = false;
                if (txtValide.Text == "1")
                    chx_Valide.Checked = true;
                else
                    chx_Valide.Checked = false;
                txtBloque.Text = row["BLOQUE"].ToString();
                txtBloque.Visible = false;
                if (txtBloque.Text == "1")
                    chx_Bloque.Checked = true;
                else
                    chx_Bloque.Checked = false;
                txtBlocage.Text = row["TEXTEBLOQUE"].ToString();
                txtAttention.Text = row["ATTENTION"].ToString();
                txtAttention.Visible = false;
                if (txtAttention.Text == "1")
                    chx_Attention.Checked = true;
                else
                    chx_Attention.Checked = false;
                txtAlerte.Text = row["TEXTEATTENTION"].ToString();
                txtObservations.Text = row["OBSERVATIONS"].ToString();
            }
        }

        private void Disable()
        {
            txtDateCreation.Enabled = false;
            txtBadge.Enabled = false;
            txtPlaque.Enabled = false;
            txtCode.Enabled = false;
            txtTare.Enabled = false;
            chx_Valide.Enabled = false;
            chx_Bloque.Enabled = false;
            txtBlocage.Enabled = false;
            chx_Attention.Enabled = false;
            txtAlerte.Enabled = false;
            txtObservations.Enabled = false;

            vg_IsEnabled = false;
        }

        private void Enable()
        {
            txtDateCreation.Enabled = true;
            txtBadge.Enabled = true;
            txtPlaque.Enabled = true;
            txtCode.Enabled = true;
            txtTare.Enabled = true;
            chx_Valide.Enabled = true;
            chx_Bloque.Enabled = true;
            txtBlocage.Enabled = true;
            chx_Attention.Enabled = true;
            txtAlerte.Enabled = true;
            txtObservations.Enabled = true;

            vg_IsEnabled = true;
        }

        private void Clear()
        {
            txtId.Text = "";
            txtDateCreation.Text = "";
            txtBadge.Text = "";
            txtPlaque.Text = "";
            txtCode.Text = "";
            txtTare.Text = "";            
            txtBlocage.Text = "";
            txtAlerte.Text = "";
            txtObservations.Text = "";
            chx_Valide.Checked = false;
            chx_Bloque.Checked = false;
            chx_Attention.Checked = false;
        }

        private void btAjouter_MouseEnter(object sender, EventArgs e)
        {
            if (btAjouter.Enabled == true)
                btAjouter.BackColor = Color.FromArgb(72, 86, 77);
        }

        private void btAjouter_MouseLeave(object sender, EventArgs e)
        {
            if (btAjouter.Enabled == true)
                btAjouter.BackColor = Color.FromArgb(58, 62 ,60) ;
        }

        private void btModifier_MouseEnter(object sender, EventArgs e)
        {
            if (btModifier.Enabled == true)
                btModifier.BackColor = Color.FromArgb(72, 86, 77);
        }

        private void btModifier_MouseLeave(object sender, EventArgs e)
        {
            if (btModifier.Enabled == true)
                btModifier.BackColor = Color.FromArgb(58, 62, 60);
        }

        private void btSupprimer_MouseEnter(object sender, EventArgs e)
        {
            if (btSupprimer.Enabled == true)
                btSupprimer.BackColor = Color.FromArgb(72, 86, 77);
        }

        private void btSupprimer_MouseLeave(object sender, EventArgs e)
        {
            if (btSupprimer.Enabled == true)
                btSupprimer.BackColor = Color.FromArgb(58, 62, 60);
        }

        private void chx_Valide_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Valide.Checked)
                txtValide.Text = "1";
            else
                txtValide.Text = "0";
        }

        private void chx_Bloque_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Bloque.Checked)
                txtBloque.Text = "1";
            else
                txtBloque.Text = "0";
        }

        private void chx_Attention_CheckedChanged(object sender, EventArgs e)
        {
            if (chx_Attention.Checked)
                txtAttention.Text = "1";
            else
                txtAttention.Text = "0";
        }

        private void btAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "" && txtDateCreation.Text == "" && txtPlaque.Text != "" && txtValide.Text != "" && txtBloque.Text != "" && txtAttention.Text != "")
                {
                    int Tare;
                    int Valide;
                    int Bloque;
                    int Attention;
                    bool IsParsableTare;
                    bool IsParsableValide;
                    bool IsParsableBloque;
                    bool IsParsableAttention;
                    IsParsableTare = Int32.TryParse(txtTare.Text, out Tare);
                    IsParsableValide = Int32.TryParse(txtValide.Text, out Valide);
                    IsParsableBloque = Int32.TryParse(txtBloque.Text, out Bloque);
                    IsParsableAttention = Int32.TryParse(txtAttention.Text, out Attention);
                    try
                    {
                        if (IsParsableTare && IsParsableValide && IsParsableBloque && IsParsableAttention)
                        {
                            Camion camion = new Camion();
                            camion.Add(txtCode.Text, txtPlaque.Text, txtBadge.Text, Tare, Valide, Bloque, txtBlocage.Text,
                                 Attention, txtAlerte.Text, txtObservations.Text);
                            MessageBox.Show("Camion ajouté avec succès");
                            Close();
                        }
                    }
                    catch
                    {
                        throw;
                    }

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
                        if (txtId.Text != "" && txtDateCreation.Text != "" && txtPlaque.Text != "" && txtValide.Text != "" && txtBloque.Text != "" && txtAttention.Text != "")
                        {
                            int Id;
                            int Tare;
                            int Valide;
                            int Bloque;
                            int Attention;
                            bool IsParsableId;
                            bool IsParsableTare;
                            bool IsParsableValide;
                            bool IsParsableBloque;
                            bool IsParsableAttention;
                            IsParsableId = Int32.TryParse(txtId.Text, out Id);  
                            IsParsableTare = Int32.TryParse(txtTare.Text, out Tare);
                            IsParsableValide = Int32.TryParse(txtValide.Text, out Valide);
                            IsParsableBloque = Int32.TryParse(txtBloque.Text, out Bloque);
                            IsParsableAttention = Int32.TryParse(txtAttention.Text, out Attention);
                            try
                            {
                                if (IsParsableId && IsParsableTare && IsParsableValide && IsParsableBloque && IsParsableAttention)
                                {
                                    Camion camion = new Camion();
                                    camion.Update(Id, txtCode.Text, txtPlaque.Text, txtBadge.Text, Tare, Valide, Bloque, txtBlocage.Text,
                                       Attention, txtAlerte.Text, txtObservations.Text) ;
                                    MessageBox.Show("Camion modifié avec succès");
                                    btModifier.Text = "Modifier";
                                    vg_Update = false;
                                    Disable();
                                    Bind_Fields();
                                }
                            }
                            catch
                            {
                                throw;
                            }
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
                    Camion camion = new Camion();
                    int Id;
                    bool IsParsableId;
                    IsParsableId = Int32.TryParse(txtId.Text, out Id);
                    if (IsParsableId)
                    {
                        camion.Delete(Id);
                        MessageBox.Show("Camion supprimé avec succès");
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
