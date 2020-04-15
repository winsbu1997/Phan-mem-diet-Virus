using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Ladin.mtaAV.Manager;
using Ladin.mtaAV.Utilities;
using System.Collections.Generic;
using System.Globalization;
using BinarySearch;
using System.Threading;

namespace Ladin.mtaAV.Monitor_SubViews
{
    public partial class UC_Process : UserControl
    {
        static ConsoleSetups con = new ConsoleSetups();
        static ManagementEventWatcher startWatch = new ManagementEventWatcher(
              new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
        public UC_Process()
        {
            InitializeComponent();
            btn_PauseScan.Enabled = true;
        }
        #region Method
        private void AddRow(string FileName, string Virus, string Type_Scan)
        {
            //lock (dgv_MonitorProcess)
            //{
                int index = dgv_MonitorProcess.Rows.Add();
                DataGridViewRow row = dgv_MonitorProcess.Rows[index];
                row.Cells["FileName"].Value = FileName;
                row.Cells["Virus"].Value = Virus;
                row.Cells["Type_Scan"].Value = Type_Scan;
                row.Cells["Create_Date"].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            //}
        }
        private void ScanFile(string path)
        {
            var scanResult = BinarySearch.Manage.MD5Scan(path);
            if (scanResult.IsEmpty)
            {
                AddRow(path, scanResult.VirusName, "Tĩnh");
            }
        }
        public List<string> printDllLoaded(string id)
        {
            List<string> result = new List<string>();
            string runningPath = AppDomain.CurrentDomain.BaseDirectory; 
            string dlls = string.Format("{0}Resources\\Listdlls.exe", Path.GetFullPath(Path.Combine(runningPath, @"..\..\")));
            Process compiler = new Process();
            compiler.StartInfo.FileName = dlls;
            compiler.StartInfo.Arguments = "-u " + id;
            compiler.StartInfo.CreateNoWindow = true;
            compiler.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            compiler.StartInfo.UseShellExecute = false;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.Start();
            string regex = @"^(([a-zA-Z]:|\\\\\w[ \w\.]*)(\\\w[ \w\.]*|\\%[ \w\.]+%+)+|%[ \w\.]+%(\\\w[ \w\.]*|\\%[ \w\.]+%+)*)";
            string outtext = compiler.StandardOutput.ReadToEnd();
            var reader = new StringReader(outtext);
            string line;
            while (null != (line = reader.ReadLine()))
            {
                try
                {
                    line = reader.ReadLine();

                    if (Regex.IsMatch(line.Substring(30), regex))
                    {
                        bool fileExist = File.Exists(line.Substring(30));
                        if (fileExist)
                            result.Add(line.Substring(30));
                        else
                        {
                            string tmp = ProcessManager.Normalize(line.Substring(30));
                            if (File.Exists(tmp))
                                result.Add(tmp);
                        }
                    }
                }
                catch { }
            }
            compiler.WaitForExit();
            return result;
        }
        private void startWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string a = e.NewEvent.Properties["ProcessName"].Value.ToString();
            if (!a.Contains("Listdll") && !a.Contains("MtaAV"))
            {
                //List<string> rs = await Task.Run(() => printDllLoaded(e.NewEvent.Properties["ProcessName"].Value.ToString()));
                List<string> rs = printDllLoaded(e.NewEvent.Properties["ProcessName"].Value.ToString());
                if (rs.Count == 0) return;
                //foreach (string item in rs) ScanFile(item);
                ParallelLoopResult result = Parallel.ForEach(rs, ScanFile);
            }
        }
        #endregion

        #region Event
        private void btn_Scan_Click(object sender, EventArgs e)
        {
            btn_PauseScan.Enabled = true;
            btn_Scan.Enabled = false;
            startWatch.EventArrived += new EventArrivedEventHandler(startWatch_EventArrived);
            startWatch.Start();
        }

        private void btn_PauseScan_Click(object sender, EventArgs e)
        {
            btn_PauseScan.Enabled = false;
            btn_Scan.Enabled = true;
            startWatch.EventArrived -= new EventArrivedEventHandler(startWatch_EventArrived);
            startWatch.Stop();
        }

        #endregion

        private void btn_CancelScan_Click(object sender, EventArgs e)
        {
            dgv_MonitorProcess.DataSource = null;
        }
    }
}
