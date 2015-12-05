using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace NetworkClient
{
    public partial class GUI : Form
    {
        public string ServerAddress;
        public string ServerPort;
        TcpClient Client;
        NetworkStream ns;
        StreamReader sr;
        StreamWriter sw;

        public GUI()
        {
            InitializeComponent();            
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            try
            {
                getServerDetails();
                Client = new TcpClient(ServerAddress, Convert.ToInt32(ServerPort));
                ns = Client.GetStream();
                sr = new StreamReader(ns);
                sw = new StreamWriter(ns);
                sw.AutoFlush = true;
                lblConnectionDetails.Text = "Server connected - " + ServerAddress + ":" + ServerPort;
            }
            catch (Exception ex)
            {
                lblConnectionDetails.Text = "Failed to connect to server " + ServerAddress + ":" + ServerPort;
                MessageBox.Show(ex.Message);
                btnSend.Enabled = false;
            }
        }
        private void getServerDetails()
        {
            ServerDetails srv = new ServerDetails();
            srv.ShowDialog();
            ServerAddress = srv._srvAddress;
            ServerPort = srv._srvPort;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string str = txtMessage.Text;
            while (str != "SIGNOUT")
            {
                sw.WriteLine(str);
                str = txtMessage.Text;
            }
        }
    }
}
