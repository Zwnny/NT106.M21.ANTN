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
        private TcpClient dataclient;
        private TcpListener server;
        private TcpListener dataserver;
        private NetworkStream mainStream;
        private NetworkStream dataStream;
        private static ManualResetEvent mre = new ManualResetEvent(false);
        private readonly Thread Listening;
        
        private Thread GetImage;
        bool stopsharing = false;
        public ControlForm()
        {
            //client = new TcpClient();

            Listening = new Thread(StartListening);
            GetImage = new Thread(ReceiveImage);

            Listening.IsBackground = true;
            GetImage.IsBackground = true;

            InitializeComponent();
        }
        private void StartListening()
        {
            try
            {
                server.Start();
                dataserver.Start();
                while (true)
                {                             
                    client = server.AcceptTcpClient();
                    dataclient = dataserver.AcceptTcpClient();

                    Random random = new Random();
                    int length = 10;
                    var secret = "";
                    for (var i = 0; i < length; i++)
                    {
                        secret += ((char)(random.Next(1, 26) + 64)).ToString();

                    }
                    mainStream = client.GetStream();
                    Byte[] sendsecret = Encoding.ASCII.GetBytes("secrete:" + secret + "$");
                    mainStream.Write(sendsecret, 0, sendsecret.Length);

                    MessageBox.Show(secret);


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
            dataserver.Stop();
            if (Listening.IsAlive)
                Listening.Abort();
            //if (GetImage.IsAlive)
            //    GetImage.Abort();
                
        }
        private void StopSharing()
        {
            stopsharing = true;   
        }
        private void ReceiveImage()
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                
                while (client.Connected && Thread.CurrentThread.IsAlive)
                {
                    if (stopsharing)
                    {
                        ScreenCapture.Image = null;
                        mre.WaitOne();
                        
                    }
                    dataStream = dataclient.GetStream();
                    ScreenCapture.Image = (Image)binaryFormatter.Deserialize(dataStream);
                    
                }
                //else
                    MessageBox.Show("Client disconnected");
            }
            catch { MessageBox.Show("Client disconnected"); }
        }
        private void btnShareScreen_Click(object sender, EventArgs e)
        {
            //Thread GetImage; 

            if (btnShareScreen.Text == "Share screen")
            {           
                mainStream = client.GetStream();
                Byte[] ShareScreenComand = Encoding.ASCII.GetBytes("Share Screen$");
                mainStream.Write(ShareScreenComand, 0, ShareScreenComand.Length);

                stopsharing = false;
                //MessageBox.Show(mre.GetType().ToString());
                if (!GetImage.IsAlive)
                {
                    //GetImage = new Thread(ReceiveImage);
                    GetImage.Start();
                }
                else
                    mre.Set();
                



                btnShareScreen.Text = "Stop sharing";
            }
            else if(btnShareScreen.Text == "Stop sharing")
            {
                StopSharing();
                mainStream = client.GetStream();
                Byte[] StopShareScreenComand = Encoding.ASCII.GetBytes("Stop Share Screen$");
                mainStream.Write(StopShareScreenComand, 0, StopShareScreenComand.Length);

                btnShareScreen.Text = "Share screen";


            }    
        }

        private void ControlForm_Load(object sender, EventArgs e)
        {
            server = new TcpListener(IPAddress.Any, 8080);
            dataserver = new TcpListener(IPAddress.Any, 8081);
            Listening.Start();
        }

        private void btnHenGio_Click(object sender, EventArgs e)
        {
            mainStream = client.GetStream();
            Form HenGio = new HenGio(mainStream);
            HenGio.Show();
        }
    }
}
