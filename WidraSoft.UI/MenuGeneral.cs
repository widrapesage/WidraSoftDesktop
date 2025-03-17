using System;
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
using CustomMessageBox;
using System.IO.Ports;

namespace WidraSoft.UI
{
    public partial class MenuGeneral : Form
    {
        int vg_UtilisateurId;
        int vg_GroupeId;
        public static int languuage_index;
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
            Utilisateur utilisateur = new Utilisateur();
            cbLang.DataSource = Language.Languages;
            cbLang.ValueMember = null;
            cbLang.DisplayMember = Language.Languages[0];
            languuage_index = utilisateur.GetUserLanguageIndex(vg_UtilisateurId);
            cbLang.SelectedIndex = languuage_index;


            lblusername.Text = utilisateur.GetFullUsername(vg_UtilisateurId);
            vg_GroupeId = utilisateur.GetGroupeIdById(vg_UtilisateurId);

            txtEntreprise.Text = "WIDRA";
            txtTypeAbonnement.Text = "Demo";
            txtValidite.Text = "---";

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int Msg, int wParam, int lParam);
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void camionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Utilisateurs
            if (Common_functions.GetAccess(vg_GroupeId, "UTI"))
            {
                Form form = new UtilisateursList("1=1");
                form.Show();
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous n'avez pas les autorisations nécessaires pour accéder à ce module.", "WidraSoft - Gestionnaires d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You d'ont have the permission to access this module.", "WidraSoft - Access manager", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void chauffeursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Groupes
            if (Common_functions.GetAccess(vg_GroupeId, "GRO"))
            {
                Form form = new GroupesList("1=1");
                form.Show();
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous n'avez pas les autorisations nécessaires pour accéder à ce module.", "WidraSoft - Gestionnaires d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You d'ont have the permission to access this module.", "WidraSoft - Access manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btFirmes_Click(object sender, EventArgs e)
        {
            //Firmes
            if (Common_functions.GetAccess(vg_GroupeId, "FIR"))
            {
                Form form = new FirmesList("1=1");
                form.Show();
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous n'avez pas les autorisations nécessaires pour accéder à ce module.", "WidraSoft - Gestionnaires d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You d'ont have the permission to access this module.", "WidraSoft - Access manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btCamions_Click(object sender, EventArgs e)
        {
            //Camions
            if (Common_functions.GetAccess(vg_GroupeId, "CAM"))
            {
                Form form = new CamionsListe("1=1");
                form.Show();
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous n'avez pas les autorisations nécessaires pour accéder à ce module.", "WidraSoft - Gestionnaires d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You d'ont have the permission to access this module.", "WidraSoft - Access manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void firmesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Firmes
            if (Common_functions.GetAccess(vg_GroupeId, "FIR"))
            {
                Form form = new FirmesList("1=1");
                form.Show();
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous n'avez pas les autorisations nécessaires pour accéder à ce module.", "WidraSoft - Gestionnaires d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You d'ont have the permission to access this module.", "WidraSoft - Access manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void camionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Camions
            if (Common_functions.GetAccess(vg_GroupeId, "CAM"))
            {
                Form form = new CamionsListe("1=1");
                form.Show();
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous n'avez pas les autorisations nécessaires pour accéder à ce module.", "WidraSoft - Gestionnaires d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You d'ont have the permission to access this module.", "WidraSoft - Access manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void produitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Produits
            if (Common_functions.GetAccess(vg_GroupeId, "PRO"))
            {
                Form form = new ProduitsListe("1=1");
                form.Show();
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous n'avez pas les autorisations nécessaires pour accéder à ce module.", "WidraSoft - Gestionnaires d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You d'ont have the permission to access this module.", "WidraSoft - Access manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chauffeursToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Chauffeurs
            if (Common_functions.GetAccess(vg_GroupeId, "CHAU"))
            {
                Form form = new ChauffeursListe("1=1");
                form.Show();
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous n'avez pas les autorisations nécessaires pour accéder à ce module.", "WidraSoft - Gestionnaires d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You d'ont have the permission to access this module.", "WidraSoft - Access manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void transporteursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Transporteurs
            if (Common_functions.GetAccess(vg_GroupeId, "TRA"))
            {
                Form form = new TransporteursListe("1=1");
                form.Show();
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous n'avez pas les autorisations nécessaires pour accéder à ce module.", "WidraSoft - Gestionnaires d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You d'ont have the permission to access this module.", "WidraSoft - Access manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelUserInfo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbLang.Text == "FR")
            {
                France_flag.Visible = true;
                England_flag.Visible = false;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("fr", this, typeof(MenuGeneral));

            }

            if (cbLang.Text == "EN")
            {
                France_flag.Visible = false;
                England_flag.Visible = true;
                Spain_flag.Visible = false;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("en", this, typeof(MenuGeneral));
            }

            if (cbLang.Text == "ES")
            {
                France_flag.Visible = false;
                England_flag.Visible = false;
                Spain_flag.Visible = true;
                Language_Manager language_Manager = new Language_Manager();
                language_Manager.ChangeLanguage("es", this, typeof(MenuGeneral));
            }
            Utilisateur utilisateur = new Utilisateur();
            lblusername.Text = utilisateur.GetFullUsername(vg_UtilisateurId);
        }

        private void pontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Ponts
            if (Common_functions.GetAccess(vg_GroupeId, "PON"))
            {
                Form form = new PontsListe("1=1");
                form.Show();
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous n'avez pas les autorisations nécessaires pour accéder à ce module.", "WidraSoft - Gestionnaires d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You d'ont have the permission to access this module.", "WidraSoft - Access manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Pesee pont bascule
            if (Common_functions.GetAccess(vg_GroupeId, "PES"))
            {
                Form form = new PeseePontBascule(vg_UtilisateurId);
                form.Show();
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous n'avez pas les autorisations nécessaires pour accéder à ce module.", "WidraSoft - Gestionnaires d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You d'ont have the permission to access this module.", "WidraSoft - Access manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clients
            if (Common_functions.GetAccess(vg_GroupeId, "CLI"))
            {
                Form form = new ClientsListe("1=1");
                form.Show();
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous n'avez pas les autorisations nécessaires pour accéder à ce module.", "WidraSoft - Gestionnaires d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You d'ont have the permission to access this module.", "WidraSoft - Access manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ParamPoidstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Parametres poids
            if (Common_functions.GetAccess(vg_GroupeId, "PPO"))
            {
                Form form = new WeightSettingsList("1=1");
                form.Show();
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous n'avez pas les autorisations nécessaires pour accéder à ce module.", "WidraSoft - Gestionnaires d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You d'ont have the permission to access this module.", "WidraSoft - Access manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pamamètresDePeséeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Parametres pesée
            if (Common_functions.GetAccess(vg_GroupeId, "PPE"))
            {
                Form form = new WeighingSettingsList("1=1");
                form.Show();
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous n'avez pas les autorisations nécessaires pour accéder à ce module.", "WidraSoft - Gestionnaires d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You d'ont have the permission to access this module.", "WidraSoft - Access manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void reportingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tables supplementaires
            if (Common_functions.GetAccess(vg_GroupeId, "TAB"))
            {
                Form form = new TablesList("1=1");
                form.Show();
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous n'avez pas les autorisations nécessaires pour accéder à ce module.", "WidraSoft - Gestionnaires d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You d'ont have the permission to access this module.", "WidraSoft - Access manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void enregistrementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Enregistrements
            if (Common_functions.GetAccess(vg_GroupeId, "ENR"))
            {
                Form form = new EnregistrementsListe("1=1");
                form.Show();
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous n'avez pas les autorisations nécessaires pour accéder à ce module.", "WidraSoft - Gestionnaires d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You d'ont have the permission to access this module.", "WidraSoft - Access manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new TestANPR();
            form.Show();
        }

        private void BorneToolpStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Borne_Home();
            form.Show();
        }

        private void listePeseesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Liste pesées
            if (Common_functions.GetAccess(vg_GroupeId, "LISP"))
            {
                Form form = new PeseePBList("1=1");
                form.Show();
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous n'avez pas les autorisations nécessaires pour accéder à ce module.", "WidraSoft - Gestionnaires d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You d'ont have the permission to access this module.", "WidraSoft - Access manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void walterreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Common_functions.GetAccess(vg_GroupeId, "WAL"))
            {
                Form form = new WalterreList("1=1");
                form.Show();
            }
            else
            {
                if (cbLang.Text == "FR")
                    Custom_MessageBox.Show("FR", "Vous n'avez pas les autorisations nécessaires pour accéder à ce module.", "WidraSoft - Gestionnaires d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (cbLang.Text == "EN")
                    Custom_MessageBox.Show("EN", "You d'ont have the permission to access this module.", "WidraSoft - Access manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SerialPort comBarriere = new SerialPort();

            comBarriere.PortName = "COM8";
            comBarriere.ReadTimeout = 1000;
            comBarriere.BaudRate = 9600;
            comBarriere.Parity = Parity.None;
            comBarriere.StopBits = StopBits.One;
            comBarriere.DataBits = 8;
            comBarriere.Handshake = Handshake.None;


            try
            {
                comBarriere.Open();
            }
            catch
            {
                throw;
            }

            try
            {
                comBarriere.Write("@01" + (char)13);
            }
            catch { throw; }

            if (comBarriere.IsOpen)
            { comBarriere.Close(); }
        }
    }
}
