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
            Process pNet = new Process();
            ProcessStartInfo psi = new ProcessStartInfo("ifconfig");
            psi.Arguments = "ifconfig eth0";
            pNet.StartInfo = psi;
            pNet.Start();
            
            MessageBox.Show("Hello World !");


            

        }
    }
}
