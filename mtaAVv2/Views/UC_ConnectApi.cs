using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ladin.mtaAV.Views
{
    public partial class UC_ConnectApi : UserControl
    {
        public UC_ConnectApi()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Provider.url = txtUrl.Text;
            Provider.port = txtPort.Text;
        }
    }
}
