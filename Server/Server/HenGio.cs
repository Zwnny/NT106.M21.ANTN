using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server
{
    public partial class HenGio : Form
    {
        NetworkStream hengioStream;
        public HenGio(NetworkStream mainStream)
        {
            hengioStream = mainStream;
            InitializeComponent();
        }
        void Shutdown(string command)
        {
             System.Diagnostics.Process.Start("shutdown", command);
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
               
            decimal secondtoShutdown = (Hour.Value) * 3600 + (Minute.Value) * 60 + Second.Value;
            string command = "shutdown -s -t " + secondtoShutdown.ToString() + "$";

            //MessageBox.Show(command);
            //Shutdown(command);
            //System.Diagnostics.Process.Start("shutdown", "-s -t 3600");

            Byte[] ShutdownCommand = Encoding.ASCII.GetBytes(command);
            hengioStream.Write(ShutdownCommand, 0, ShutdownCommand.Length);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string command = "shutdown -a$";
            Byte[] CancelShutdownCommand = Encoding.ASCII.GetBytes(command);
            hengioStream.Write(CancelShutdownCommand, 0, CancelShutdownCommand.Length);
            //Shutdown(command); // Cancel Shutdown
        }
    }
}
