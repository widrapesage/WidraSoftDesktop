using CustomMessageBox;
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
    public partial class TablesEnregistrementsDetail : Form
    {
        String vg_Mode = "";
        Int32 vg_Id = 0;
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;
        public TablesEnregistrementsDetail(String Mode, Int32 Id)
        {
            InitializeComponent();
            vg_Mode = Mode;
            vg_Id = Id;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void TablesEnregistrementsDetail_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            Enregistrements enregistrements = new Enregistrements();
            cbEnregistrement.DataSource = enregistrements.List("1=1");
            cbEnregistrement.DisplayMember = "NOM";
            cbEnregistrement.ValueMember = "ENREGISTREMENTSID";
            

            cbParent.DataSource = enregistrements.List("1=1");
            cbParent.DisplayMember = "NOM";
            cbParent.ValueMember = "ENREGISTREMENTSID";

            Tables tables = new Tables();
            cbTable.DataSource = tables.List("1=1");
            cbTable.DisplayMember = "NOM";
            cbTable.ValueMember = "TABLESID";

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
            cbEnregistrement.SelectedValue = vg_Id;
            cbEnregistrement.Text = enregistrements.GetName(vg_Id);
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = 0;
        }

        private void Add_Item()
        {
            if (cbEnregistrement.Text == "" && txtDateCreation.Text == "" && cbTable.Text == "" && cbParent.Text == "" && txtNumero.Text == "")
            {
                lbModifier.Enabled = false;
                lbModifier.BackColor = Color.Transparent;
                lbSupprimer.Enabled = false;
                lbSupprimer.BackColor = Color.Transparent;

                cbEnregistrement.Enabled = false;
                txtNumero.Text = "0";

            }
        }

        private void Edit_Item()
        {
            lbAjouter.Enabled = false;
            lbAjouter.BackColor = Color.Transparent;
            Disable();
            Bind_Fields();
        }

        private void Bind_Fields()
        {
            DataTable dt = new DataTable();
            TablesEnregistrements tablesEnregistrements = new TablesEnregistrements();
            dt = tablesEnregistrements.FindByTablesIdEnregistrementsId( Common_functions.CbSelectedValue_Convert_Int(cbTable),vg_Id);
            foreach (DataRow row in dt.Rows)
            {
                txtDateCreation.Text = row["DATECREATION"].ToString();
                if (row["ENREGISTREMENTSID"] is System.DBNull)
                    cbEnregistrement.SelectedValue = 0;
                else
                    cbEnregistrement.SelectedValue = (int)row["ENREGISTREMENTSID"];
                if (row["TABLESID"] is System.DBNull)
                    cbTable.SelectedValue = 0;
                else
                    cbTable.SelectedValue = (int)row["TABLESID"];
                if (row["ENREGISTREMENTPARENTID"] is System.DBNull)
                    cbParent.SelectedValue = 0;
                else
                    cbParent.SelectedValue = (int)row["ENREGISTREMENTPARENTID"];
                txtNumero.Text = row["NUMERO"].ToString();
                
            }
        }

        private void Disable()
        {
            txtDateCreation.Enabled = false;
            cbEnregistrement.Enabled = false;
            cbTable.Enabled = false;
            cbParent.Enabled = false;
            txtNumero.Enabled = false;
            pbUpdating.Visible = false;

            vg_IsEnabled = false;
        }

        private void Enable()
        {
            txtDateCreation.Enabled = true;
            cbEnregistrement.Enabled = true;
            cbTable.Enabled = true;
            cbParent.Enabled = true;
            txtNumero.Enabled = true;
            pbUpdating.Visible = true;

            vg_IsEnabled = true;
        }

        private void Clear()
        {
            
            txtDateCreation.Text = "";
            cbEnregistrement.Text = "";
            cbTable.Text = "";
            cbParent.Text = "";
            txtNumero.Text = "";            
        }

        private void lbAjouter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtDateCreation.Text == "" && cbEnregistrement.Text != "" &&  cbTable.Text != "")
                {
                    int Numero;
                    bool IsParsableNumero;
                    IsParsableNumero = Int32.TryParse(txtNumero.Text, out Numero);
                    try
                    {  
                        if (IsParsableNumero)
                        {
                            TablesEnregistrements tablesEnregistrements = new TablesEnregistrements();
                            tablesEnregistrements.Add(Common_functions.CbSelectedValue_Convert_Int(cbTable), Common_functions.CbSelectedValue_Convert_Int(cbEnregistrement),
                                    Common_functions.CbSelectedValue_Convert_Int(cbParent), Numero);
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", cbEnregistrement.Text + " lié avec succès à la table " + cbTable.Text, "Enregistrement-Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", cbEnregistrement.Text + " linked successfully with the table " + cbTable.Text, "Record-Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", cbEnregistrement.Text + " asociado a la tabla " + cbTable.Text, "Registro-Tabla", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Informations incomplètes", "Enregistrement-Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "Incomplete informations", "Record-Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Custom_MessageBox.Show("ES", "Información incompleta", "Registro-Tabla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }              
            }
            catch
            {
                throw;
            }
        }

        private void lbModifier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                
                if (vg_Update == false && vg_IsEnabled == false)
                {
                    Enable();
                    cbEnregistrement.Enabled = false;
                    cbTable.Enabled = false;
                    lbModifier.Text = Language_Manager.Localize("Valider", cbLang.Text);
                    vg_Update = true;
                }
                else
                {
                    try
                    {
                        cbEnregistrement.Enabled = false;
                        cbTable.Enabled = false;
                        if (txtDateCreation.Text != "" && cbEnregistrement.Text != "" && cbTable.Text != "")
                        {
                            int Numero;
                            bool IsParsableNumero;
                            IsParsableNumero = Int32.TryParse(txtNumero.Text, out Numero);
                            try
                            {
                                if (IsParsableNumero)
                                {
                                    TablesEnregistrements tablesEnregistrements = new TablesEnregistrements();
                                    tablesEnregistrements.Update(Common_functions.CbSelectedValue_Convert_Int(cbTable), Common_functions.CbSelectedValue_Convert_Int(cbEnregistrement),
                                            Common_functions.CbSelectedValue_Convert_Int(cbParent), Numero);
                                    if (cbLang.Text == "FR")
                                        Custom_MessageBox.Show("FR", cbEnregistrement.Text + " lié avec succès à la table " + cbTable.Text, "Enregistrement-Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else if (cbLang.Text == "EN")
                                        Custom_MessageBox.Show("EN", cbEnregistrement.Text + " linked successfully with the table " + cbTable.Text, "Record-Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                        Custom_MessageBox.Show("ES", cbEnregistrement.Text + " asociado a la tabla " + cbTable.Text, "Registro-Tabla", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Informations incomplètes", "Enregistrement-Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Incomplete informations", "Record-Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Información incompleta", "Registro-Tabla", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void lbSupprimer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (vg_Update)
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous ne pouvez pas supprimer l'enregistrement tant que la modification n'est pas validée", "Enregistrement-Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You can't delete this record before the update is completed", "Record-Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    Custom_MessageBox.Show("ES", "No puede eliminar el registro hasta que se confirme el cambio", "Registro-Tabla", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    TablesEnregistrements tablesEnregistrements = new TablesEnregistrements();
                    
                        DialogResult result;
                        if (cbLang.Text == "FR")
                            result = Custom_MessageBox.Show("FR", "Etes vous sur de vouloir supprimer cet enregistrement?", "Enregistrement-Table", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else if (cbLang.Text == "EN")
                            result = Custom_MessageBox.Show("EN", "Are you sure you want to delete this record?", "Record-Table", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else
                            result = Custom_MessageBox.Show("ES", "¿Está seguro de que desea eliminar este registro?", "Registro-Tabla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            tablesEnregistrements.Delete(Common_functions.CbSelectedValue_Convert_Int(cbTable),Common_functions.CbSelectedValue_Convert_Int(cbEnregistrement));
                            if (cbLang.Text == "FR")
                                Custom_MessageBox.Show("FR", "Enregistrement supprimé avec succès", "Enregistrement-Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (cbLang.Text == "EN")
                                Custom_MessageBox.Show("EN", "Record deleted successfully", "Record-Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                Custom_MessageBox.Show("ES", "Registro eliminado", "Registro-Tabla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                    
               }
                catch
                {
                    throw;
                }

            }
        }

        private void TablesEnregistrementsDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vg_Mode == "Edit")
            {
                if (pbUpdating.Visible)
                {
                    if (cbLang.Text == "FR")
                        Custom_MessageBox.Show("FR", "Vous ne pouvez pas fermer la fenetre tant que la modification n'est pas validée", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else if (cbLang.Text == "EN")
                        Custom_MessageBox.Show("EN", "You can't close this window before the update is completed", "Record", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        Custom_MessageBox.Show("ES", "No puede cerrar la página hasta que se valide el cambio", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    e.Cancel = true;
                }
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
                language_Manager.ChangeLanguage("fr", this, typeof(TablesEnregistrementsDetail));
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(TablesEnregistrementsDetail));
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(TablesEnregistrementsDetail));
            }
        }
    }
}

