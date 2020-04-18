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
using System.Collections;

namespace Ladin.mtaAV.Monitor_SubViews
{
    public partial class UC_Process : UserControl
    {
        #region variable
        static ConsoleSetups con = new ConsoleSetups();
        static ManagementEventWatcher startWatch = new ManagementEventWatcher(
              new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
        private AbortableBackgroundWorker backgroundWorker1;
        private AbortableBackgroundWorker backgroundWorker2;
        private AbortableBackgroundWorker backgroundWorker3;
        private long limitSizeFile = 1024 * 1024;
        Queue queue = new Queue();
        Queue qfile = new Queue();
        #endregion 
        public UC_Process()
        {
            InitializeComponent();
            btn_PauseScan.Enabled = true;
        }
        #region Method
        private void AddRow(string FileName, string Virus, string Type_Scan)
        {
            int index = dgv_MonitorProcess.Rows.Add();
            DataGridViewRow row = dgv_MonitorProcess.Rows[index];
            row.Cells["FileName"].Value = FileName;
            row.Cells["Virus"].Value = Virus;
            row.Cells["Type_Scan"].Value = Type_Scan;
            row.Cells["Create_Date"].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        }
        private void ScanFile(string path)
        {
            var scanResult = BinarySearch.Manage.MD5Scan(path);
            if (!scanResult.IsEmpty)
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
                lock (queue)
                {
                    queue.Enqueue(a);
                }
            }
        }
        #endregion

        #region Event
        private void btn_Scan_Click(object sender, EventArgs e)
        {
            dgv_MonitorProcess.DataSource = null;
            btn_PauseScan.Enabled = true;
            btn_Scan.Enabled = false;
            backgroundWorker1 = new AbortableBackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            backgroundWorker2 = new AbortableBackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            backgroundWorker3 = new AbortableBackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();
            backgroundWorker3.RunWorkerAsync();
            timer1.Enabled = true;
            timer1.Start();
        }
        private void btn_PauseScan_Click(object sender, EventArgs e)
        {
            btn_PauseScan.Enabled = false;
            btn_Scan.Enabled = true;
            startWatch.Stop();
            ThreadWatcher.StopThread = true;//t
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                backgroundWorker1.Abort();
                backgroundWorker1.Dispose();
            }
            if (backgroundWorker2.IsBusy)
            {
                backgroundWorker2.Abort();
                backgroundWorker2.Dispose();
            }
            timer1.Stop();
        }

        private void btn_CancelScan_Click(object sender, EventArgs e)
        {
            btn_Scan.Enabled = true;
            btn_CancelScan.Enabled = false;
            startWatch.Stop();
            ThreadWatcher.StopThread = true;//t
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                backgroundWorker1.Abort();
                backgroundWorker1.Dispose();
            }
            if (backgroundWorker2.IsBusy)
            {
                backgroundWorker2.CancelAsync();
                backgroundWorker2.Abort();
                backgroundWorker2.Dispose();
            }
            timer1.Stop();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            startWatch.EventArrived += new EventArrivedEventHandler(startWatch_EventArrived);
            startWatch.Start();
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                if (queue.Count == 0) continue;
                else
                {
                    lock (queue)
                    {
                        object id = queue.Dequeue();
                        List<string> rs = printDllLoaded(id.ToString());
                        if (rs.Count > 0)
                        {
                            foreach (string item in rs)
                            {
                                lock (qfile)
                                {
                                    qfile.Enqueue(item);
                                }
                            }
                        }
                    }
                }
            } while (true);
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            string path = "";
            do
            {
                if (qfile.Count == 0) continue;
                else
                {
                    lock (qfile)
                    {
                        object file = qfile.Dequeue();
                        path = file.ToString();
                    }
                    if (File.Exists(path)) ScanFile(path);
                }
            } while (true);
        }
        #endregion

        #region Thread
        public static class ThreadWatcher
        {
            public static bool StopThread { get; set; }
        }
        public class AbortableBackgroundWorker : BackgroundWorker
        {

            private Thread workerThread;

            protected override void OnDoWork(DoWorkEventArgs e)
            {
                workerThread = Thread.CurrentThread;
                try
                {
                    base.OnDoWork(e);
                }
                catch (ThreadAbortException)
                {
                    e.Cancel = true;
                    Thread.ResetAbort();
                }
            }
            public void Abort()
            {
                if (workerThread != null)
                {
                    workerThread.Abort();
                    workerThread = null;
                }
            }
        }
        #endregion 
    }
}
