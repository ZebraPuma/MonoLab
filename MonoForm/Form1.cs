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

namespace MonoForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Command = "";
            String Arguments = "";
            Platform Platform =  GetPlatform();
            switch (Platform)
            {
                case Platform.Windows:
                    Command = "ipconfig";
                    break;
                case Platform.Linux:
                    Command = "ifconfig";
                    break;
                case Platform.MacOSX:
                    Command = "ifconfig";
                    break;
                default:
                    break;
            }
            txtInfo.Text = Platform + " Box\r\n" + "\r\n";

            Process pNet = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(Command);
            psi.Arguments = Arguments;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            pNet.StartInfo = psi;
            pNet.Start();
            txtInfo.Text += pNet.StandardOutput.ReadToEnd();
        }

        private Platform GetPlatform() {
            switch (System.Environment.OSVersion.Platform )
            {
                case PlatformID.MacOSX:
                    return Platform.MacOSX;
                case PlatformID.Unix:
                    return Platform.Linux;
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
    }
}
