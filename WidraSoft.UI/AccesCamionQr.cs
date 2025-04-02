using Microsoft.Reporting.WinForms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.SkiaSharp;

namespace WidraSoft.UI
{
    public partial class AccesCamionQr : Form
    {
        string vg_Name;
        string vg_Id;
        string qr_code;
        string vg_Client;
        System.Drawing.Imaging.ImageFormat f = System.Drawing.Imaging.ImageFormat.Png;
        public AccesCamionQr(string Plaque, String Id, String Client)
        {
            InitializeComponent();
            vg_Name = Plaque;
            vg_Id = Id;
            vg_Client = Client;
        }

        private void AccesCamionQr_Load(object sender, EventArgs e)
        {
            reportViewer.LocalReport.ReportEmbeddedResource = "WidraSoft.UI.AccesCamionQR.rdlc";

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

            using var bitmap = writer.Write(vg_Id);
            using var stream = new MemoryStream();
            bitmap.Encode(stream, SKEncodedImageFormat.Png, 200);
            Image img_qrcode = System.Drawing.Image.FromStream(stream);
            qr_code = ImageToBase64(img_qrcode, f);

            ReportParameter[] parameters = new ReportParameter[3];

            parameters[0] = new ReportParameter("Name", vg_Name);
            parameters[1] = new ReportParameter("Client", vg_Client);
            parameters[2] = new ReportParameter("Qr", qr_code);

            this.reportViewer.LocalReport.SetParameters(parameters);

            reportViewer.RefreshReport();
        }

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
