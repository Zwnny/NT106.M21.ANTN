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
    public partial class ControlForm : Form
    {
        private TcpClient client;
        private TcpListener server;
        private NetworkStream mainStream;

        private readonly Thread Listening;
        private readonly Thread GetImage;
        public ControlForm()
        {
            //client = new TcpClient();
            Listening = new Thread(StartListening);
            GetImage = new Thread(ReceiveImage);
            InitializeComponent();
        }
        private void StartListening()
        {
            try
            {
                server.Start();
                while (true)
                {
                               
                    client = server.AcceptTcpClient();
                    MessageBox.Show("Client connected");
                }
                
            }
            catch
            {
                StopListening();
            }
        }
        private void StopListening()
        {
            server.Stop();
            if (Listening.IsAlive)
                Listening.Abort();
            if (GetImage.IsAlive)
                GetImage.Abort();
        }
        private void ReceiveImage()
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                while (client.Connected)
                {
                    mainStream = client.GetStream();
                    ScreenCapture.Image = (Image)binaryFormatter.Deserialize(mainStream);
                    //MessageBox.Show("Server receiving screen from client");
                }
            }
            catch { }
        }
/*        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            StopListening();
        }*/
        private void btnShareScreen_Click(object sender, EventArgs e)
        {
            if (btnShareScreen.Text == "Share screen")
            {
                mainStream = client.GetStream();
                Byte[] ShareScreenComand = Encoding.ASCII.GetBytes("Share Screen$");
                mainStream.Write(ShareScreenComand, 0, ShareScreenComand.Length);
                GetImage.Start();
                btnShareScreen.Text = "Stop sharing";
            }
            else if(btnShareScreen.Text == "Stop sharing")
            {
                StopListening();
                btnShareScreen.Text = "Share screen";
                ScreenCapture.Image = null;

            }    
        }

        private void ControlForm_Load(object sender, EventArgs e)
        {
            server = new TcpListener(IPAddress.Any, 8080);
            Listening.Start();
        }
    }
}
