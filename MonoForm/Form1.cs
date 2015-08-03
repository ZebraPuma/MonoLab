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
            String OSVersion =  System.Environment.OSVersion.ToString();
            txtInfo.Text = OSVersion + "\r\n";

            Process pNet = new Process();
            ProcessStartInfo psi = new ProcessStartInfo("ipconfig");
            psi.Arguments = "";
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            pNet.StartInfo = psi;
            pNet.Start();
            txtInfo.Text += pNet.StandardOutput.ReadToEnd();
        }
    }
}
