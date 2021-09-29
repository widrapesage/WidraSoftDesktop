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
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }
        private void Password_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

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

                        txtLogin.Text = "";
                        txtPassword.Text = "";
                        txtLogin.Enabled = false;
                        txtPassword.Enabled = false;
                        btConnecter.Enabled = false;
                        btQuitter.Enabled = false;
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
    }

}
