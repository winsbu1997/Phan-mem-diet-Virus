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
using Ladin.UsbManager;
using System.IO;
using Ladin.mtaAV.Model;
using BinarySearch;
using System.Globalization;

namespace Ladin.mtaAV.Views
{
    public partial class UC_Main : System.Windows.Forms.UserControl
    {
        string loc_to_search = null;
        private UsbManager.UsbManager usb = new UsbManager.UsbManager();
        private string smart_ext = "*.exe|*.cpl|*.reg|*.ini|*.bat|*.com|*.dll|*.pif|*.lnk|*.scr|*.vbs|*.ocx|*.drv|*.sys";
        public UC_Main()
        {
            InitializeComponent();
        }

        #region Method
        public void Reload()
        {
            int flag = 0;
            if (Provider.firewallOn) { ico_Firewall.Image = Resources.Checked_48px; flag++; }
            else ico_Firewall.Image = Resources.Cancel_48px;

            if (Provider.autorunOn) { ico_Autorun.Image = Resources.Checked_48px; flag++; }
            else ico_Autorun.Image = Resources.Cancel_48px;

            if (Provider.autoUsbOn) { ico_Usb.Image = Resources.Checked_48px; flag++; }
            else ico_Usb.Image = Resources.Cancel_48px;

            if (Provider.realtimeOn) { ico_Realtime.Image = Resources.Checked_48px; flag++; }
            else ico_Realtime.Image = Resources.Cancel_48px;

            if (Provider.monitoring_NetworkOn) { ico_MonitorNetwork.Image = Resources.Checked_48px; }
            else ico_MonitorNetwork.Image = Resources.Cancel_48px;

            if (Provider.monitoring_ProcessOn) { ico_MontitorProcess.Image = Resources.Checked_48px; }
            else ico_MontitorProcess.Image = Resources.Cancel_48px;

            lb_CurrentDate.Text = "Lần quét gần nhất vào: " + Provider.currentScan;
            if (flag == 4)
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
        public void ScanUSB()
        {
            int infected = 0;
            string[] files = Provider.GetFiles(loc_to_search, smart_ext, SearchOption.AllDirectories);
            int count = files.Length;
            if (count == 0) return;
            Invoke(new Action(() =>
            {
                Provider.Alert("MtaAV bắt đầu quét USB", frmAlert.alertTypeEnum.Info);
            }));
            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        Invoke(new Action(() =>
                        {
                            txt_ScanUSB.Text = "Quét USB: " + Path.GetFileName(file);
                        }));
                        var res = Manage.MD5Scan(file);

                        if (!res.IsEmpty)
                        {
                            infected++;
                            QUARANTINES quarantine = new QUARANTINES(file, res.VirusName, "Tĩnh", DateTime.Now.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture));
                            lock (Provider.list_NewQuarantines)
                            {
                                Provider.list_NewQuarantines.Add(quarantine);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            Invoke(new Action(() =>
            {
                txt_ScanUSB.Text = "";
                if (infected > 0) Provider.Alert("USB có virus", frmAlert.alertTypeEnum.Warning);
                else Provider.Alert("USB an toàn", frmAlert.alertTypeEnum.Success);
            }));
        }
        private void DoStateChanged(UsbStateChangedEventArgs e)
        {
            if (e.State == UsbStateChange.Added)
            {
                if (Provider.autoUsbOn)
                {
                    loc_to_search = e.Disk.Name;
                    Provider.scanUSB = new Task(ScanUSB);
                    Provider.scanUSB.Start();
                }
            }
        }
        #endregion

        #region Event
        private void UC_Main_Load(object sender, EventArgs e)
        {
            Reload();
            usb.StateChanged += new UsbStateChangedEventHandler(DoStateChanged);
        }
        #endregion
    }
}
