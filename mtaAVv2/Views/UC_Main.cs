using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ladin.mtaAV.Properties;

namespace Ladin.mtaAV.  Views
{
    public partial class UC_Main : System.Windows.Forms.UserControl
    {
        public void Reload()
        {
            int flag = 0;
            if (Provider.firewallOn) { ico_Firewall.Image = Resources.Checked_48px; flag++; }
            else ico_Firewall.Image = Resources.Cancel_48px;

            if (Provider.autorunOn) {ico_Autorun.Image = Resources.Checked_48px; flag++; }
            else ico_Autorun.Image = Resources.Cancel_48px;

            if (Provider.autousbOn) {ico_Usb.Image = Resources.Checked_48px; flag++; }
            else ico_Usb.Image = Resources.Cancel_48px;

            if (Provider.realtimeOn) {ico_Realtime.Image = Resources.Checked_48px; flag++; }
            else ico_Realtime.Image = Resources.Cancel_48px;
            
            if(flag == 4)
            {
                ptb_Security.Image = Resources.System_Information_96px;
                lb_Status.Text = Provider.txt_Alert[0];
            }
            else
            {
                ptb_Security.Image = Resources.System_Report_96px;
                lb_Status.Text = Provider.txt_Alert[1];
            }
        }

        public UC_Main()
        {
            InitializeComponent();
        }

        private void UC_Main_Load(object sender, EventArgs e)
        {
            Reload();
        }
    }
}
