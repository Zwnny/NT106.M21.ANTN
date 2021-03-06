using System;
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
        private readonly Thread Listening;
        public DashBoard()
        {
            CheckForIllegalCrossThreadCalls = false;
            Listening = new Thread(StartListening);
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

                    connectionInfo.Text += client.Client.RemoteEndPoint.ToString() + "\n";

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
            string clientID = client.Client.RemoteEndPoint.ToString();
            Form controlForm = new ControlForm(client, logClient, screenClient, clientID);
            controlForm.Name = clientID;
            controlForm.Text = clientID;
            controlForm.Show();
            Application.Run();
        }
    }
}