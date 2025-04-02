using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetSDKCS;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.Logging;
using WidraSoft.BL;


namespace WidraSoft.UI
{
    public partial class ANPR3 : Form
    {
        private IntPtr _LoginID = IntPtr.Zero;
        private IntPtr _PlayID = IntPtr.Zero;
        private fSnapRevCallBack _SnapRevCallBack;
        private NET_DEVICEINFO_Ex _DeviceInfo = new NET_DEVICEINFO_Ex();
        private bool _IsSpanCapture = false;
        string vg_ip;
        string vg_port;
        string vg_login;
        string vg_pwd;
        string vg_peseeId;
        string vg_type;
        string vg_num;
        public ANPR3(string ip, string port, string login, string pwd, string peseeId, string type, string num)
        {
            InitializeComponent();
            vg_ip = ip;
            vg_port = port;
            vg_login = login;
            vg_pwd = pwd;
            vg_peseeId = peseeId;
            vg_type = type;
            vg_num = num;
            try
            {
                _SnapRevCallBack = new fSnapRevCallBack(SnapRevCallBack);
                NETClient.Init(null, IntPtr.Zero, null);
                NETClient.SetSnapRevCallBack(_SnapRevCallBack, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Process.GetCurrentProcess().Kill();
            }
            //this.Load += new EventHandler(ANPR_Load);
        }

        private void ANPR3_Load(object sender, EventArgs e)
        {
            this.Visible = false;

            textBox_ip.Text = vg_ip;
            textBox_port.Text = vg_port;
            textBox_name.Text = vg_login;
            textBox_password.Text = vg_pwd;

            this.comboBox_channel.Enabled = false;
            this.button_realplay.Enabled = false;
            this.button_local.Enabled = false;
            this.button_remote.Enabled = false;
            this.button_span.Enabled = false;




            button_login_Click(this, new EventArgs());

            System.Threading.Thread.Sleep(200);
            button_realplay_Click(this, new EventArgs());

            System.Threading.Thread.Sleep(200);
            if (pictureBox_image.Image != null)
            {
                pictureBox_image.Image.Dispose();
            }

            string path = "C:\\Users\\HP\\Pictures\\Dahua_pics";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = path + "\\" + vg_peseeId + "_" + vg_num + "_" + vg_type + ".jpg";
            bool ret = NETClient.CapturePicture(_PlayID, filePath, EM_NET_CAPTURE_FORMATS.JPEG);
            if (!ret)
            {
                MessageBox.Show(NETClient.GetLastError());
                return;
            }
            Image image = Image.FromFile(filePath);
            pictureBox_image.Image = image;
            //NETClient.Cleanup();
            System.Threading.Thread.Sleep(700);

            Close();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == _LoginID)
            {
                ushort port = 0;
                try
                {
                    port = Convert.ToUInt16(this.textBox_port.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Input port error!");
                    return;
                }
                _LoginID = NETClient.LoginWithHighLevelSecurity(this.textBox_ip.Text.Trim(), port, this.textBox_name.Text.Trim(), this.textBox_password.Text, EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref _DeviceInfo);
                if (IntPtr.Zero == _LoginID)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }
                for (int i = 0; i < _DeviceInfo.nChanNum; i++)
                {
                    this.comboBox_channel.Items.Add(i + 1);
                }
                this.comboBox_channel.SelectedIndex = 0;
                this.comboBox_channel.Enabled = true;
                this.button_realplay.Enabled = true;
                this.button_remote.Enabled = true;
                this.button_span.Enabled = true;

                //this.button_login.Text = "Logout(登出)";
            }
            else
            {
                NETClient.Logout(_LoginID);
                _LoginID = IntPtr.Zero;
                this.comboBox_channel.Items.Clear();
                this.comboBox_channel.Enabled = false;
                this.button_realplay.Enabled = false;
                this.button_realplay.Text = "RealPlay";
                this.button_local.Enabled = false;
                this.button_remote.Enabled = false;
                this.button_span.Enabled = false;
                //this.button_login.Text = "Login(登录)";
                this.pictureBox_preview.Refresh();
                this.pictureBox_image.Image = null;
                this.pictureBox_image.Refresh();
                if (_IsSpanCapture)
                {
                    _IsSpanCapture = false;
                    this.button_span.Text = "Span Capture";
                }
            }
        }

        private void SnapRevCallBack(IntPtr lLoginID, IntPtr pBuf, uint RevLen, uint EncodeType, uint CmdSerial, IntPtr dwUser)
        {
            string path = "C:\'Users\'RYZEN7\'Pictures\'ANPR " + "image";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (EncodeType == 10) //.jpg
            {
                DateTime now = DateTime.Now;
                string fileName = string.Format("{0}-{1}-{2}-{3}-{4}-{5}", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second) + ".jpg";
                string filePath = path + "\\" + fileName;
                byte[] data = new byte[RevLen];
                Marshal.Copy(pBuf, data, 0, (int)RevLen);
                try
                {
                    //when the file is operate by local capture will throw expection.
                    using (FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate))
                    {
                        stream.Write(data, 0, (int)RevLen);
                        stream.Flush();
                        stream.Dispose();
                    }
                }
                catch
                {
                    return;
                }
                this.BeginInvoke(new Action(() =>
                {
                    if (pictureBox_image.Image != null)
                    {
                        pictureBox_image.Image.Dispose();
                    }
                    Image image = Image.FromFile(filePath);
                    pictureBox_image.Image = image;
                }));
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            NETClient.Cleanup();
        }

        private void button_realplay_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == _PlayID)
            {
                _PlayID = NETClient.RealPlay(_LoginID, comboBox_channel.SelectedIndex, this.pictureBox_preview.Handle);
                if (IntPtr.Zero == _PlayID)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }
                this.button_local.Enabled = true;
                this.button_realplay.Text = "StopRealPlay";
            }
            else
            {
                NETClient.StopRealPlay(_PlayID);
                _PlayID = IntPtr.Zero;
                this.button_local.Enabled = false;
                this.button_realplay.Text = "RealPlay";
                this.pictureBox_preview.Refresh();
            }
        }
    }
}
