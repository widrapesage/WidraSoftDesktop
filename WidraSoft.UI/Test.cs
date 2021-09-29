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
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            try
            {
                Utilisateur utilsateur = new Utilisateur();
                this.dataGridView1.DataSource = utilsateur.List();
            }
            catch
            {
                throw;
            }
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    Utilisateur utilsateur = new Utilisateur();
                    this.dataGridView1.DataSource = utilsateur.GetById(Int16.Parse(textBox1.Text)); ;
                }
                catch
                {
                    throw;
                }
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Utilisateur utilsateur = new Utilisateur();
                utilsateur.Add(txtNom.Text, txtPrenom.Text, txtLogin.Text, txtPassword.Text, Int16.Parse(txtIsAdmin.Text), Int16.Parse(txtPontId.Text), DateTime.Now, DateTime.Now, txtProfil.Text, txtPeseeManuel.Text);

            }
            catch
            {
                throw;
            }
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            try
            {
                bool CanConnect;
                Utilisateur utilisateur = new Utilisateur();
                CanConnect = utilisateur.CanConnect(txtLogin.Text, txtPassword.Text);
                if (CanConnect == true)
                {
                    MessageBox.Show("Can connect to WIDRASOFT, have a great experience");
                }
                else
                {
                    MessageBox.Show("Can't connect, please subscribe");
                }
                
            }
            catch 
            { 
                throw; 
            }
        }
    }
}

