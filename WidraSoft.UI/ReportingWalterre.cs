using Microsoft.Reporting.WinForms;
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
    public partial class ReportingWalterre : Form
    {
        int vg_WalterreId;
        string vg_Filter;
        public ReportingWalterre(int WalterreId, string Filter)
        {
            InitializeComponent();
            vg_WalterreId = WalterreId;
            vg_Filter = Filter;
        }

        private void ReportingWalterre_Load(object sender, EventArgs e)
        {
            reportViewer.LocalReport.ReportEmbeddedResource = "WidraSoft.UI.ReportingWalterre.rdlc";
            PeseePB peseePB = new PeseePB();
            DataTable dtpeseePB = new DataTable();
            dtpeseePB = peseePB.List(vg_Filter);
            ReportDataSource rds1 = new ReportDataSource("DataSet1", dtpeseePB);
            Walterre walterre = new Walterre();
            DataTable dtWalterrePeseePB = new DataTable();
            dtWalterrePeseePB = walterre.FindEnlevementsById(vg_WalterreId);
            ReportDataSource rds2 = new ReportDataSource("WalterrePeseePB", dtWalterrePeseePB);

            this.reportViewer.LocalReport.DataSources.Clear();
            this.reportViewer.LocalReport.DataSources.Add(rds1);
            this.reportViewer.LocalReport.DataSources.Add(rds2);

            reportViewer.RefreshReport();
        }
    }
}
