using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ladin.mtaAV.Utilities;

namespace Ladin.mtaAV.Views
{
    public partial class Reprot_DynamicScan : Form
    {
        public delegate void Send_ReportDynamic(List<ConnectApi> dt_Report);
        private List<ConnectApi> lst = new List<ConnectApi>();
        public Send_ReportDynamic sender;
        public Reprot_DynamicScan()
        {
            InitializeComponent();
            sender = new Send_ReportDynamic(Get_Report);
        }

        private void Get_Report(List<ConnectApi> dt_Report)
        {
            dgv_DynamicResult.DataSource = dt_Report;
        }
    }
}
