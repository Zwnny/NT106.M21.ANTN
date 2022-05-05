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
        private readonly TcpClient client = new TcpClient();
        private NetworkStream mainStream;
        private NetworkStream SignalStream;
        private Thread Listening;
        public Client()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        void Shutdown(string command)
        {
            System.Diagnostics.Process.Start("shutdown", command);
        }

        private Image GrabDesktop()
        {
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
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
                while(true)
                {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                mainStream = client.GetStream();
                binaryFormatter.Serialize(mainStream, GrabDesktop());
                //Thread.Sleep(100);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        private void Client_Load(object sender, EventArgs e)
        {
            client.Connect(IPAddress.Parse("127.0.0.1"), 8080);
            while (true)
            {
                mainStream = client.GetStream();
                //MessageBox.Show("Client said hello");
                byte[] data = new byte[1024];
                int numBytesRead = mainStream.Read(data, 0, data.Length);
                string signal;
                string command;
                if (numBytesRead > 0)
                {
                    signal = Encoding.ASCII.GetString(data, 0, numBytesRead);
                    command = signal.Substring(0, signal.IndexOf('$'));

                    if (command == "Share Screen")
                    {
                        //Listening = new Thread(Timer_Processing);
                        //Listening.Start();
                        //timer1.Start();
                        //SignalStream.Close();
                        //System.Diagnostics.
                        Thread t = new Thread(SendDesktopImage);
                        t.Start();
                        //break;

                    }
                    if (command.StartsWith("shutdown")) // command = shutdown -s -t
                    {
                        // timer1.Start();
                        //SignalStream.Close();
                        String[] separator = { "shutdown" };
                        String arg = command.Split(separator, StringSplitOptions.RemoveEmptyEntries)[0];
                        Shutdown(arg);


                        //break;

                    }
                }

            }
        }


    }
}
