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

namespace Client
{
    public partial class Client : Form
    {
        private static ManualResetEvent mre = new ManualResetEvent(false);
        private readonly TcpClient signalclient = new TcpClient();
        private readonly TcpClient dataclient = new TcpClient();
        private NetworkStream dataStream;
        private NetworkStream signalStream;

        private Thread ConnectServer;
        private Thread ShareScreen;
        bool stopsharing = false;
        string secret = "@#%^*&*)&*()*)(*)(*)"; // Initialize random char
        public Client()
        {
            CheckForIllegalCrossThreadCalls = false;
            ShareScreen = new Thread(SendDesktopImage);
            ShareScreen.IsBackground = true;
            
            InitializeComponent();
            
        }

        void TakeCommandFromServer()
        {
            this.Hide();
            while (signalclient.Connected)
            {
                try
                {
                    signalStream = signalclient.GetStream();

                    //MessageBox.Show("Client said hello");
                    byte[] data = new byte[1024];
                    int numBytesRead = signalStream.Read(data, 0, data.Length);
                    string signal;
                    string command;
                    if (numBytesRead > 0)
                    {
                        signal = Encoding.ASCII.GetString(data, 0, numBytesRead);
                        command = signal.Substring(0, signal.IndexOf('$'));

                        //dataStream = dataclient.GetStream();
                        if (command.StartsWith("secret"))
                        {
                            String[] separator = { ":" };
                            secret = command.Split(separator, StringSplitOptions.RemoveEmptyEntries)[1];
                            MessageBox.Show(secret);
                        }
                        if (command == "Share Screen")
                        {
                            if (!ShareScreen.IsAlive)
                                ShareScreen.Start();
                            else
                            {
                                stopsharing = false;
                                mre.Set();
                            }

                            //break;

                        }
                        if (command == "Stop Share Screen")
                        {
                            stopsharing = true;
                            //ShareScreen.Abort();
                        }
                        if (command.StartsWith("shutdown -s -t")) // command = shutdown -s -t
                        {
                            // timer1.Start();
                            //SignalStream.Close();
                            String[] separator = { "shutdown" };
                            String arg = command.Split(separator, StringSplitOptions.RemoveEmptyEntries)[0];
                            Shutdown(arg);
                        }

                        if (command == "shutdown -a") // command = shutdown -s -t
                        {
                            // timer1.Start();
                            //SignalStream.Close();
                            String[] separator = { "shutdown" };
                            String arg = command.Split(separator, StringSplitOptions.RemoveEmptyEntries)[0];
                            Shutdown(arg);
                        }

                    }
                }
                catch (Exception ex)
                {

                }

            }
            MessageBox.Show("Server disconnected");
            Application.Exit();

        }
        void Shutdown(string command)
        {
            System.Diagnostics.Process.Start("shutdown", command);
        }

        private Image GrabDesktop()
        {
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            //rect.Height = (int)(rect.Height * 1.5);
            //rect.Width = (int)(rect.Width * 1.5);
            //MessageBox.Show(rect.Size.ToString());
            Bitmap screenBitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics screenGraphics = Graphics.FromImage(screenBitmap);
            screenGraphics.CopyFromScreen(rect.X, rect.Y, 0, 0, rect.Size, CopyPixelOperation.SourceCopy);
           
           /* Uncomment câu này để dùng chức năng hiển thị con trỏ (còn hơi cùi, tọa độ k chính xác)
            
            screenGraphics.DrawIcon(new Icon("Sample.ico"), Cursor.Position.X - 50, Cursor.Position.Y - 50);

            */

            return screenBitmap;
        }

       
        private void SendDesktopImage()
        {
            try
            {
                while(signalclient.Connected && ShareScreen.IsAlive)
                {
                    if (stopsharing) mre.WaitOne();
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                dataStream = dataclient.GetStream();
                binaryFormatter.Serialize(dataStream, GrabDesktop());
                //Thread.Sleep(100);
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }



        }
        private void Client_Load(object sender, EventArgs e)
        {
            //this.Hide();
            //this.WindowState = FormWindowState.Maximized;
            //Rectangle rect = Screen.PrimaryScreen.Bounds;
            //rect.Height = (int) (rect.Height*1.5);
            //rect.Width = (int)(rect.Width * 1.5);
            //MessageBox.Show(rect.Size.ToString());

            //float dpiX, dpiY;
            //Graphics graphics = this.CreateGraphics();
            //dpiX = graphics.DpiX;
            //dpiY = graphics.DpiY;
            //MessageBox.Show(dpiX.ToString() + "  " + dpiY.ToString());


            signalclient.Connect(IPAddress.Parse("127.0.0.1"), 8080);
            dataclient.Connect(IPAddress.Parse("127.0.0.1"), 8081);

            ConnectServer = new Thread(TakeCommandFromServer);
            ConnectServer.IsBackground = true;
            ConnectServer.Start();

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            String password = Microsoft.VisualBasic.Interaction.InputBox("Nhập mật khẩu bảo vệ ", "Mật khẩu", "", -1, -1);
            
            if (password == secret )
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Bạn đã nhập mật khẩu sai ! ", " Lỗi");
            }
        }


    }
}
