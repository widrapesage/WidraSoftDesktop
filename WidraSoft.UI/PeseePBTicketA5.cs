using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.Reporting.WinForms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WidraSoft.BL;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.SkiaSharp;

namespace WidraSoft.UI
{
    public partial class PeseePBTicketA5 : Form
    {
        int vg_Id;
        string p_Id;
        string p_Flux;
        string p_Type;
        string p_ParamPesee;
        string p_Pont;
        string p_Firme;
        string p_Camion;
        string p_Chauffeur;
        string p_Transporteur;
        string p_Produit;
        string p_Client;
        string p_Categorie;
        string p_Poids1;
        string p_Poids2;
        string p_PoidsNet;
        string p_DateHeure1;
        string p_DateHeure2;
        string p_TablesSupplementaires;
        string p_UserInfo;
        string p_NomEntreprise;
        string p_Titre1;
        string p_Titre2;
        string p_Footer;
        string p_ImageLogo;
        string p_qr_code;
        string p_qteAutoriseWalterre;
        string p_QteEnleveeWalterre;
        string p_ResteWalterre;
        string p_Walterre;

        System.Drawing.Imaging.ImageFormat f = System.Drawing.Imaging.ImageFormat.Png;
        
        public PeseePBTicketA5(int Id)
        {
            InitializeComponent();
            vg_Id = Id;
        }

        private void PeseePBTicketA5_Load(object sender, EventArgs e)
        {
            reportViewer.LocalReport.ReportEmbeddedResource = "WidraSoft.UI.PeseePBTicketA5.rdlc";

            PeseePB peseePE = new PeseePB();
            DataTable dtpeseePE = new DataTable();
            dtpeseePE = peseePE.FindById(vg_Id);
            Walterre walterre = new Walterre();
            DataTable dtWalterre = new DataTable();
            foreach (DataRow r in dtpeseePE.Rows)
            {
                p_Id = r["PESEEPBID"].ToString();
                p_Flux = r["FLUX"].ToString();
                p_Type = r["TYPEPESEE"].ToString();
                p_ParamPesee = r["PARAMPESEE"].ToString();
                p_Pont = r["PONT"].ToString();
                p_Firme = r["FIRME"].ToString();
                p_Camion = r["CAMION"].ToString();
                p_Chauffeur = r["CHAUFFEUR"].ToString();
                p_Transporteur = r["TRANSPORTEUR"].ToString();
                p_Produit = r["PRODUIT"].ToString();
                p_Client = r["CLIENT"].ToString();
                p_TablesSupplementaires = r["TABLES_SUPPLEMENTAIRES_STRING"].ToString();
                //p_Image = ImageToBase64(Common_functions.SetCategoriePictureToImage(p_Categorie), f);
                p_Poids1 = r["POIDS1"].ToString();
                p_Poids2 = r["POIDS2"].ToString();
                p_DateHeure1 = r["DATEHEUREPOIDS1"].ToString();
                p_DateHeure2 = r["DATEHEUREPOIDS2"].ToString();
                p_PoidsNet = r["POIDSNET"].ToString();               
                p_NomEntreprise = "FER";
                p_UserInfo = r["USER_INFO"].ToString();
                p_Titre1 = r["TITRE1"].ToString();
                p_Titre2 = r["TITRE2"].ToString();
                p_Footer = r["FOOTER"].ToString();
                p_Walterre = r["CODEWALTERRE"].ToString();


                QrCodeEncodingOptions options = new()
                {
                    DisableECI = true,
                    CharacterSet = "UTF-8",
                    Width = 1000,
                    Height = 1000
                };

                BarcodeWriter writer = new()
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new EncodingOptions
                    {
                        Height = 1000,
                        Width = 1000,
                        Margin = 5
                    }

                };

                using var bitmap = writer.Write(p_Id + "/n" + p_Pont + "/n" + p_Firme + "/n" + p_Camion + "/n" + p_PoidsNet + " Kg");
                using var stream = new MemoryStream();
                bitmap.Encode(stream, SKEncodedImageFormat.Png, 200);
                Image img_qrcode = System.Drawing.Image.FromStream(stream);
                p_qr_code = ImageToBase64(img_qrcode, f);
                //p_qr_code = ImageToBase64(writer.Write("This is my QR code!"), f);
                //qrCodeBitmap.Save(imageFileName);
            }


            ReportParameter[] parameters = new ReportParameter[26];

            parameters[0] = new ReportParameter("Id", p_Id);
            parameters[1] = new ReportParameter("Flux", p_Flux);
            parameters[2] = new ReportParameter("Type", p_Type);
            parameters[3] = new ReportParameter("ParamPesee", p_ParamPesee);
            parameters[4] = new ReportParameter("Pont", p_Pont);
            parameters[5] = new ReportParameter("Firme", p_Firme);
            parameters[6] = new ReportParameter("Camion", p_Camion);
            parameters[7] = new ReportParameter("Chauffeur", p_Chauffeur);
            parameters[8] = new ReportParameter("Transporteur", p_Transporteur);
            parameters[9] = new ReportParameter("Produit", p_Produit);
            parameters[10] = new ReportParameter("Client", p_Client);
            parameters[11] = new ReportParameter("Poids1", p_Poids1);
            parameters[12] = new ReportParameter("Poids2", p_Poids2);
            parameters[13] = new ReportParameter("PoidsNet", p_PoidsNet);
            parameters[14] = new ReportParameter("DateHeure1", p_DateHeure1);
            parameters[15] = new ReportParameter("DateHeure2", p_DateHeure2);
            parameters[16] = new ReportParameter("UserInfo", p_UserInfo);
            parameters[17] = new ReportParameter("QrCode", p_qr_code);
            parameters[18] = new ReportParameter("TablesSupplementaires", p_TablesSupplementaires);
            parameters[19] = new ReportParameter("Titre1", p_Titre1);
            parameters[20] = new ReportParameter("Titre2", p_Titre2);
            parameters[21] = new ReportParameter("Footer", p_Footer);
            parameters[22] = new ReportParameter("Walterre", p_Walterre);

            foreach(DataRow r in dtWalterre.Rows)
            {
                p_qteAutoriseWalterre = r["VOLUME"].ToString();
                p_QteEnleveeWalterre = r["QTE_ENLEVEMENTS"].ToString();
                p_ResteWalterre = r["RESTE_VOLUME"].ToString();
            }

            parameters[23] = new ReportParameter("QteAutoriseWalterre", p_qteAutoriseWalterre);
            parameters[24] = new ReportParameter("QteEnleveeWalterre", p_QteEnleveeWalterre);
            parameters[25] = new ReportParameter("ResteWalterre", p_ResteWalterre);

            this.reportViewer.LocalReport.SetParameters(parameters);

            reportViewer.RefreshReport();

            Export_Pdf();

            SendToPrinter("~/output.pdf");

        }

        private void SendToPrinter(string prepDok)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";
            info.FileName = prepDok;
            info.CreateNoWindow = false;
            info.WindowStyle = ProcessWindowStyle.Hidden;

            System.Windows.Forms.PrintDialog pd = new System.Windows.Forms.PrintDialog();
            pd.PrinterSettings.Copies = 1;
            Process p = new Process();
            p.StartInfo = info;
            p.StartInfo.Arguments = pd.PrinterSettings.PrinterName;
            p.Start();
            p.CloseMainWindow();

            Thread.Sleep(4000);
            if (!p.WaitForExit(5000))
            {
                if (!p.HasExited)
                {
                    p.Kill();
                }
            }

        }

        private void Export_Pdf()
        {
            Microsoft.Reporting.WinForms.Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            byte[] bytes = reportViewer.LocalReport.Render(
                "PDF", null, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);

            using (FileStream fs = new FileStream("/output.pdf", FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
        }

        /*private void Print(object sender)
        {
            Microsoft.Reporting.Map.WebForms.BingMaps.Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            string deviceInfo = "<DeviceInfo>"
                                + "<OutputFormat>EMF</OutputFormat>"
                                + "<PageWidth>8.5in</PageWidth>"
                                + "<PageHeight>11in</PageHeight>"
                                + "<MarginTop>0.25in</MarginTop>"
                                + "<MarginLeft>0.25in</MarginLeft>"
                                + "<MarginRight>0.25in</MarginRight>"
                                + "<MarginBottom>0.25in</MarginBottom>"
                                + "</DeviceInfo>";
            byte[] bytes = reportViewer.LocalReport.Render((sender as Button).CommandName, deviceInfo, out mimeType, out encoding, out extension, out streamIds, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=Customers." + extension);
            Response.BinaryWrite(bytes);
            Response.Flush();
        }
        */
        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

    }
}
