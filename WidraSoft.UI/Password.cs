using CustomMessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WidraSoft.BL;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace WidraSoft.UI
{
    public partial class Password : Form
    {
        bool IsTerminal = false;
        bool vg_IsBorneLaunched = false;
        public Password()
        {
            InitializeComponent();

        }
        private void Password_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = 0;

            GetPontId();

        }

        private void GetPontId()
        {
            //Pont 
            Pont pont = new Pont();
            DataTable dtPont = pont.FindByMachineName(System.Environment.MachineName);
            int pontId = 0;
            string typeDemarrage = "";
            int IsBorneLaunched = 0;
            int utilisateurId = 0;
            if (dtPont.Rows.Count < 1)
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Aucun pont paramétré pour cette machine, impossible d'effectuer une pesée.", "Pesée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "No weighbridge set for this computer", "Weighing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Custom_MessageBox.Show("ES", "Ningún puente seleccionado", "Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            else
            {
                if (dtPont.Rows.Count == 1)
                {
                    foreach (DataRow row in dtPont.Rows)
                    {
                        try
                        {
                            pontId = (int)row["PONTID"];
                            typeDemarrage = row["DEMARRAGE"].ToString();
                            utilisateurId = (int)row["UTILISATEURID"];
                            IsBorneLaunched = (int)row["IS_BORNE_LAUNCHED"];
                            if (IsBorneLaunched == 0)
                                vg_IsBorneLaunched = false;
                            else
                                vg_IsBorneLaunched = true;
                            Utilisateur utilisateur = new Utilisateur(); 
                            if (typeDemarrage == "Terminal" && IsBorneLaunched == 0)
                            {
                                txtLogin.Text = utilisateur.GetUsername(utilisateurId);
                                txtPassword.Text = utilisateur.GetPassword(utilisateurId);
                                IsTerminal = true;
                                btConnecter_Click(this, new EventArgs());
                            }
                            else
                            {
                                IsTerminal = false;
                            }
                        }
                        catch { throw; }

                    }
                }

            }

        }

        private void btConnecter_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text != "" && txtPassword.Text != "")
            {
                try
                {
                    Boolean CanConnect = false;
                    Int32 UtilisateurId = 0;
                    Utilisateur utilisateur = new Utilisateur();
                    CanConnect = utilisateur.CanConnect(txtLogin.Text, txtPassword.Text);
                    if (CanConnect == true)
                    {
                        UtilisateurId = utilisateur.GetUserIdByLoginAndPassword(txtLogin.Text, txtPassword.Text);
                        MenuGeneral form = new MenuGeneral(UtilisateurId, IsTerminal, vg_IsBorneLaunched);
                        form.ShowDialog();

                        cbLang.Enabled = false;
                        txtLogin.Text = "";
                        txtPassword.Text = "";
                        txtLogin.Enabled = false;
                        txtPassword.Enabled = false;
                        btConnecter.Enabled = false;
                        btConnecter.BackColor = Color.Transparent;
                    }
                    else
                        MessageBox.Show("Aucun utilisateur ne correspond aux identifiants fournis");
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


        private void btConnecter_MouseLeave(object sender, EventArgs e)
        {
            if (btConnecter.Enabled == true)
                btConnecter.BackColor = Color.FromArgb(110, 230, 130);
        }

        private void btConnecter_MouseEnter(object sender, EventArgs e)
        {
            if (btConnecter.Enabled == true)
                btConnecter.BackColor = Color.Honeydew;
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(Password));
            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(Password));
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;

            }
        }

        private void lbPont_Click(object sender, EventArgs e)
        {

        }
    }

}
