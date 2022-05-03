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
        public Client()
        {
            InitializeComponent();
        }
        private Image GrabDesktop()
        {
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            //MessageBox.Show(rect.Size.ToString());
            Bitmap screenBitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics screenGraphics = Graphics.FromImage(screenBitmap);
            screenGraphics.CopyFromScreen(rect.X, rect.Y, 0, 0, rect.Size, CopyPixelOperation.SourceCopy);

            return screenBitmap;
        }
        private void SendDesktopImage()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            //mainStream = client.GetStream();
            binaryFormatter.Serialize(mainStream, GrabDesktop());

        }
        private void Client_Load(object sender, EventArgs e)
        {
            client.Connect(IPAddress.Parse("127.0.0.1"), 8080);
            //timer1.Start();
            while (true)
            {
                mainStream = client.GetStream();
                MessageBox.Show("Client said hello");
                byte[] data = new byte[1024];
                int numBytesRead = mainStream.Read(data, 0, data.Length);
                string command;
                if (numBytesRead > 0)
                {
                    command = Encoding.ASCII.GetString(data, 0, numBytesRead);

                    if (command.Substring(0, command.IndexOf('$')) == "Share Screen")
                    {                      
                        timer1.Start();
                        //SignalStream.Close();
                        MessageBox.Show(command.Substring(0, command.IndexOf('$')));
                        break;
                        
                    }
                }

            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                SendDesktopImage();
            }
            catch
            {
                timer1.Stop();
            }
        }
    }
}
