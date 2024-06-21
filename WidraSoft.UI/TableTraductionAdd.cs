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
    public partial class TableTraductionAdd : Form
    {
        String vg_Mode = "";
        Int32 vg_TablesId = 0;
        Boolean vg_IsEnabled = true;
        Boolean vg_Update = false;

        public TableTraductionAdd(Int32 TablesId)
        {
            InitializeComponent();
            vg_TablesId = TablesId;
        }

        private void TableTraductionAdd_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            Add_Item();

            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = 0;
        }

        private void Add_Item()
        {
            try
            {
                if ( cbCodeLang.Text == "" && txtTraduction.Text == "")
                {
                    Tables tables = new Tables();
                    cbTableId.DataSource = tables.FindById(vg_TablesId);
                    cbTableId.DisplayMember = "NOM";
                    cbTableId.ValueMember = "TABLESID";
                    cbTableId.SelectedIndex = 0;

                    cbCodeLang.DataSource = LanguageList.Languages;
                    cbCodeLang.ValueMember = null; 
                    cbCodeLang.DisplayMember = LanguageList.Languages[0];
                    cbCodeLang.Text = "";

                    txtTraduction.Text = "";

                }
            }
            catch { throw; }
        }

        private void btAfficher_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbTableId.Text != "" && cbCodeLang.Text != "" && txtTraduction.Text != "")
                {
                    try
                    {
                        TablesTraduction tablesTraduction = new TablesTraduction();
                        tablesTraduction.Add(vg_TablesId, cbCodeLang.Text, txtTraduction.Text);
                        Close();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            catch { throw; }
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(TableTraductionAdd));
                
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(TableTraductionAdd));
                this.Text = "Adding translations";
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(TableTraductionAdd));
                this.Text = "Traducción agregada";
            }
        }
    }
}
