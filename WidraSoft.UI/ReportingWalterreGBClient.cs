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
    public partial class ReportingWalterreGBClient : Form
    {
        string vg_filter;
        string vg_filtreClient;
        string vg_filtreDate;
        public ReportingWalterreGBClient(string filter, string filtreClient, string filtreDate)
        {
            InitializeComponent();
            vg_filter = filter;
            vg_filtreClient = filtreClient;
            vg_filtreDate = filtreDate;
        }

        private void ReportingWalterreGBClient_Load(object sender, EventArgs e)
        {
            reportViewer.LocalReport.ReportEmbeddedResource = "WidraSoft.UI.ReportingWalterreGBClient.rdlc";
            PeseePB peseePB = new PeseePB();
            DataTable dtpeseePB = new DataTable();
            dtpeseePB = peseePB.List(vg_filter);
            ReportDataSource rds1 = new ReportDataSource("DataSet1", dtpeseePB);

            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("filtreClient", vg_filtreClient);
            parameters[1] = new ReportParameter("filtreDate", vg_filtreDate);

            this.reportViewer.LocalReport.SetParameters(parameters);
            this.reportViewer.LocalReport.DataSources.Clear();
            this.reportViewer.LocalReport.DataSources.Add(rds1);

            reportViewer.RefreshReport();


        }
    }
}
