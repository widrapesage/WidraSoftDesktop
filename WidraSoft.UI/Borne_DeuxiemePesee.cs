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
    public partial class Borne_DeuxiemePesee : Form
    {
        int vg_P;
        int vg_PeseePBId;
        string vg_camion;
        public Borne_DeuxiemePesee(int P, int PeseePEId, string camion)
        {
            InitializeComponent();
            vg_P = P;
            vg_PeseePBId = PeseePEId;
            vg_camion = camion;
        }

        private void Borne_DeuxiemePesee_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            txtPoids.Text = vg_P.ToString();
            PeseePB peseePB = new PeseePB();
            lbMessage.Text = vg_camion.ToString() + " " + peseePB.GetShortResume(vg_PeseePBId) ;
        }

        private void btAnnuler_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btValider_Click(object sender, EventArgs e)
        {

        }
    }

}
