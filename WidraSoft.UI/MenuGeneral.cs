﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WidraSoft.BL;
using System.Globalization;
using System.Threading;

namespace WidraSoft.UI
{
    public partial class MenuGeneral : Form
    {
        int vg_UtilisateurId;
        public MenuGeneral(Int32 UtilisateurId)
        {
            InitializeComponent();
            menuStrip.Renderer = new MyRenderer();
            vg_UtilisateurId = UtilisateurId;
        }


        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyMenuColors()) { }
        }



        private void MenuGeneral_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            WindowState = FormWindowState.Maximized;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            cbLang.SelectedIndex = 0;

            Utilisateur utilisateur = new Utilisateur();
            lblusername.Text = utilisateur.GetFullUsername(vg_UtilisateurId);
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void  SendMessage(System.IntPtr hWnd, int Msg, int wParam, int lParam);
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void camionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new UtilisateursList("1=1");
            form.Show();
        }

        private void chauffeursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new GroupesList("1=1");
            form.Show();
        }

        private void btFirmes_Click(object sender, EventArgs e)
        {
            Form form = new FirmesList("1=1");
            form.Show();
        }

        private void btCamions_Click(object sender, EventArgs e)
        {
            Form form = new CamionsListe("1=1");
            form.Show();
        }

        private void firmesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FirmesList("1=1");
            form.Show();
        }

        private void camionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new CamionsListe("1=1");
            form.Show();
        }

        private void panelUserInfo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            if (cbLang.Text == "Francais(FR)")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(MenuGeneral));
             }

            if (cbLang.Text == "Anglais(ANG)")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(MenuGeneral));
            }

            if (cbLang.Text == "Espagnol(ESP)")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
              
            }
            Utilisateur utilisateur = new Utilisateur();
            lblusername.Text = utilisateur.GetFullUsername(vg_UtilisateurId);
        }     
    }
}
