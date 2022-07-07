using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WidraSoft.BL;

namespace WidraSoft.UI
{
    public partial class Password : Form
    {
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
                        MenuGeneral form = new MenuGeneral(UtilisateurId);
                        form.Show();

                        cbLang.Enabled = false;
                        txtLogin.Text = "";
                        txtPassword.Text = "";
                        txtLogin.Enabled = false;
                        txtPassword.Enabled = false;
                        btConnecter.Enabled = false;
                        btConnecter.BackColor = Color.Transparent;
                        btQuitter.Enabled = false;
                        btQuitter.BackColor = Color.Transparent;
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

        private void btQuitter_MouseLeave(object sender, EventArgs e)
        {
            if (btQuitter.Enabled == true)
                btQuitter.BackColor = Color.FromArgb(72, 190, 117);
        }

        private void btQuitter_MouseEnter(object sender, EventArgs e)
        {
            if (btQuitter.Enabled == true)
                btQuitter.BackColor = Color.Honeydew;
        }

        private void btQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btConnecter_MouseLeave(object sender, EventArgs e)
        {
            if (btConnecter.Enabled == true)
                btConnecter.BackColor = Color.FromArgb(72, 190, 117);
        }

        private void btConnecter_MouseEnter(object sender, EventArgs e)
        {
            if (btConnecter.Enabled == true)
                btConnecter.BackColor = Color.Honeydew;
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.Text == "Francais(FR)")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(Password));
            }

            if (cbLang.Text == "Anglais(ANG)")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(Password));
            }

            if (cbLang.Text == "Espagnol(ESP)")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;

            }
        }
    }

}
