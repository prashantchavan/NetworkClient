using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkClient
{
    public partial class ServerDetails : Form
    {
        public string _srvAddress;
        public string _srvPort;
           
      
        public ServerDetails()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            _srvAddress = txtServerAddress.Text;
            _srvPort = txtServerPort.Text;
            this.Close();         
        }
    }
}
