using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;

namespace MonoForm
{
    public partial class Form1 : Form
    {
        [DllImport("libc")]
        static extern int uname(IntPtr buf);


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Command = "";
            String Arguments = "";
            Platform Os = GetPlatform();
            switch (Os)
            {
                case Platform.Windows:
                    Command = "ipconfig";
                    break;
                case Platform.Linux:
                    Command = "ifconfig";
                    Arguments = "eth0";
                    break;
                case Platform.MacOSX:
                    Command = "ifconfig";
                    Arguments = "en0";
                    break;
                default:
                    break;
            }

            String HostName = Dns.GetHostName().ToLower();
            txtInfo.Text = string.Format("{0} Box : {1}\r\n\r\n", Os, HostName);

            Process pNet = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(Command);
            psi.Arguments = Arguments;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            pNet.StartInfo = psi;
            pNet.Start();
            txtInfo.Text += pNet.StandardOutput.ReadToEnd();
        }

        private Platform GetPlatform()
        {
            switch (System.Environment.OSVersion.Platform)
            {
                case PlatformID.MacOSX:
                    return Platform.MacOSX;
                case PlatformID.Unix:
                    return ( IsMacOS() ? Platform.MacOSX : Platform.Linux);
                default:
                    return Platform.Windows;
            }
        }

        private enum Platform
        {
            Windows,
            Linux,
            MacOSX
        }

        private bool IsMacOS()
        {
            {
                Boolean bReturn = false;
                if (Environment.OSVersion.Platform == PlatformID.Unix)
                {

                    IntPtr buf = Marshal.AllocHGlobal(8192);
                    if (uname(buf) == 0)
                    {
                        string os = Marshal.PtrToStringAnsi(buf);
                        if (os == "Darwin")
                            bReturn = true;
                    }
                    Marshal.FreeHGlobal(buf);
                };
                return bReturn;
            }
        }
    }
}
