using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Server
{
    public partial class HenGio : Form
    {
        NetworkStream hengioStream;
        public HenGio(NetworkStream mainStream, string ID)
        {
            InitializeComponent();
            hengioStream = mainStream;
            this.Name += ' ' + ID;
            this.Text += ' ' + ID;
        }
        void Shutdown(string command)
        {
            System.Diagnostics.Process.Start("shutdown", command);
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {

            decimal secondtoShutdown = (Hour.Value) * 3600 + (Minute.Value) * 60 + Second.Value;
            string command = "shutdown -s -t " + secondtoShutdown.ToString() + "$";
            Byte[] ShutdownCommand = Encoding.ASCII.GetBytes(command);
            hengioStream.Write(ShutdownCommand, 0, ShutdownCommand.Length);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string command = "shutdown -a$";
            Byte[] CancelShutdownCommand = Encoding.ASCII.GetBytes(command);
            hengioStream.Write(CancelShutdownCommand, 0, CancelShutdownCommand.Length);
        }
    }
}