using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using Ladin.mtaAV.Model;
using BinarySearch;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Collections;
using System.Diagnostics;

namespace Ladin.mtaAV.Views
{
    public partial class UC_Scan : System.Windows.Forms.UserControl
    {
        #region variable
#pragma warning disable 0618 // removes the obsolete warning
        [DllImport("process-killer.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int KillProcess(IntPtr handle, string proc_name);
        private string wildcard = "*.*";
        private string smart_ext = "*.exe|*.cpl|*.reg|*.ini|*.bat|*.com|*.dll|*.pif|*.lnk|*.scr|*.vbs|*.ocx|*.drv|*.sys";
        private string[] files = null;
        private string loc_to_search = string.Empty;
        DateTime date = DateTime.Now;
        #endregion
        public UC_Scan()
        {
            InitializeComponent();
        }

        #region Method
        public string[] GetFiles(string SourceFolder, string Filter, System.IO.SearchOption searchOption)
        {
            ArrayList alFiles = new ArrayList();
            string[] MultipleFilters = Filter.Split('|');

            if (IsLogicalDrive(SourceFolder))
            {
                foreach (string d in Directory.GetDirectories(SourceFolder))
                {
                    foreach (string FileFilter in MultipleFilters)
                    {
                        try
                        {
                            alFiles.AddRange(Directory.GetFiles(d, FileFilter, searchOption));
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
            else
            {
                foreach (string FileFilter in MultipleFilters)
                {
                    try
                    {
                        alFiles.AddRange(Directory.GetFiles(SourceFolder, FileFilter, searchOption));
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            return (string[])alFiles.ToArray(typeof(string));
        }

        public static bool IsLogicalDrive(string path)
        {
            bool IsRoot = false;
            DirectoryInfo d = new DirectoryInfo(path);
            if (d.Parent == null)
            {
                IsRoot = true;
            }
            return IsRoot;
        }
        // Khoi tao khi chua Scanning
        private void Init()
        {
            btn_PauseScan.Enabled = false;
            btn_CancelScan.Enabled = false;
            btn_Scan.Enabled = true;
            if (!Provider.scanning)
            {
                lb_CountMacro.Text = "0";
                lb_CountVirus.Text = "0";
            }
            lb_LocationFileScan.Text = "...";
            lb_AllFile.Text = "...";
            progressBar_Scan.Value = 0;
            files = null;
            checkFile.Enabled = true;
            checkFolder.Enabled = true;
            checkProcess.Enabled = true;
            Provider.scanning = false;
            try
            {
                Provider.search.Abort();
            }
            catch { }
        }
        private void Init_Scanning()
        {
            btn_Scan.Enabled = false;
            btn_PauseScan.Enabled = true;
            btn_CancelScan.Enabled = true;
            lb_CountMacro.Text = "0";
            lb_CountVirus.Text = "0";
            checkFile.Enabled = false;
            checkFolder.Enabled = false;
            checkProcess.Enabled = false;
            progressBar_Scan.Minimum = 0;
            progressBar_Scan.Value = 0;
            lb_AllFile.Text = "Đang quét ...";
            lb_LocationFileScan.Text = "...";
        }
        //Tra ve các process đang chạy
        private List<string> GetAllRunningProcesses()
        {
            List<string> list = new List<string>();
            var wmiQueryString = "SELECT ProcessId, ExecutablePath, CommandLine FROM Win32_Process";
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            using (var results = searcher.Get())
            {
                var query = from p in Process.GetProcesses()
                            join mo in results.Cast<ManagementObject>()
                                on p.Id equals (int)(uint)mo["ProcessId"]
                            select new
                            {
                                Process = p,
                                Path = (string)mo["ExecutablePath"],
                                CommandLine = (string)mo["CommandLine"],
                            };
                foreach (var item in query)
                {
                    list.Add(item.Path);
                }
            }
            return list;
        }
        private int ScanFile(string loc, bool silent)
        {
            int ret = 0;
            if (File.Exists(loc))
            {
                var scanResult = Manage.MD5Scan(loc);
                if (scanResult.IsEmpty)
                {
                    if (!silent)
                        MessageBox.Show(this, "File không nhiễm virus!", "File sạch",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ret = 0;

                }
                else
                {
                    if (!silent)
                    {
                        DialogResult dr = MessageBox.Show(this,
                            "File nhiễm mã độc!\nMã độc: " + scanResult.VirusName +
                            "\nBạn có muốn xóa mã độc này không?", "Tìm thấy mã độc", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                            try
                            {
                                File.Delete(loc);
                            }
                            catch
                            {
                            }
                    }
                    ret = 1;
                }
                return ret;
            }
            else
            {
                if (!silent)
                    MessageBox.Show(this, "Không quét được file này", "Lỗi", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                ret = 3;
                checkFile.Checked = false;
                return ret;
            }
        }
        private void ScanFolder()
        {
            Provider.scanning = true;
            int infected = 0;
            Invoke(new Action(() =>
            {
                Provider.Alert("MtaAV bắt đầu quét virus", frmAlert.alertTypeEnum.Info);
                Init_Scanning();
            }));

            if (sw_SmartScan.Value) files = GetFiles(loc_to_search, smart_ext, SearchOption.AllDirectories);
            else files = GetFiles(loc_to_search, wildcard, SearchOption.AllDirectories);
            int total = files.Length;

            Invoke(new Action(() =>
            {
                    lb_AllFile.Text = total.ToString() + "  file";
                    progressBar_Scan.Maximum = total;
            }));
            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        lb_LocationFileScan.Text = Path.GetFileName(file);
                        var res = Manage.MD5Scan(file);

                        if (!res.IsEmpty)
                        {
                            infected++;
                            Invoke(new Action(() =>
                            {
                                lb_CountVirus.Text = infected.ToString();
                            }));
                            QUARANTINES quarantine = new QUARANTINES(file, res.VirusName, "Tĩnh", date);
                            Provider.list_NewQuarantines.Add(quarantine);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                Invoke(new Action(() =>
                {
                    progressBar_Scan.Value = progressBar_Scan.Value + 1;
                }));
            }
            files = null;
            Invoke(new Action(() =>
            {
                // file am thanh thong bao
                //SoundPlayer snd = new SoundPlayer(Properties.Resources.virfound);
                //snd.Play();
                if (infected > 0) Provider.Alert("Có virus kiểm tra trong Tab cách ly", frmAlert.alertTypeEnum.Warning);
                else Provider.Alert("Thư mục an toàn", frmAlert.alertTypeEnum.Success);
                checkFolder.Checked = false;
                Init();
            }));
        }
        private void ScanProcess()
        {
            int infected = 0;
            Provider.scanning = true;
            List<string> lst = GetAllRunningProcesses();
            Invoke(new Action(() =>
            {
                Provider.Alert("MtaAV bắt đầu quét các tiến trình", frmAlert.alertTypeEnum.Info);
                Init_Scanning();
                progressBar_Scan.Maximum = lst.Count;
            }));
            foreach (string proc in lst)
            {
                if (File.Exists(proc))
                {
                    try
                    {
                        var res = Manage.MD5Scan(proc);
                        if (!res.IsEmpty)
                        {
                            infected++;
                            Invoke(new Action(() =>
                            {
                                lb_CountVirus.Text = infected.ToString();
                            }));
                            QUARANTINES quarantine = new QUARANTINES(proc, res.VirusName, "Tĩnh", date);
                            Provider.list_NewQuarantines.Add(quarantine);
                        }
                    }
                    catch (Exception) { throw; }
                }
                Invoke(new Action(() =>
                {
                    progressBar_Scan.Value = progressBar_Scan.Value + 1;
                }));
            }
            Invoke(new Action(() =>
            {
                // file am thanh thong bao
                //SoundPlayer snd = new SoundPlayer(Properties.Resources.virfound);
                //snd.Play();
                if (infected == 0) Provider.Alert("Tiến trình sạch", frmAlert.alertTypeEnum.Success);
                else Provider.Alert("Có virus kiểm tra trong Tab cách ly", frmAlert.alertTypeEnum.Success);
                checkProcess.Checked = false;
                Init();
            }));
        }
        #endregion

        #region Event
        private void UC_Scan_Load(object sender, EventArgs e)
        {
            if (!Provider.scanning) Init();
        }
        private void btn_Scan_Click(object sender, EventArgs e)
        {
            if (checkProcess.Checked)
            {
                Provider.search = new Thread(new ThreadStart(ScanProcess));
                Provider.search.Start();
                return;
            }
            if (checkFile.Checked)
            {
                string path = "";
                path = Provider.Select_File();
                if (File.Exists(path))
                {
                    ScanFile(path, false);
                }
                return;
            }

            if (checkFolder.Checked)
            {
                if (Provider.scanning)
                {
                    MessageBox.Show(@"Xin vui lòng chờ, tiến trình quét đang thực hiện..", "Xin chờ trong ít phút...",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                loc_to_search = Provider.Select_Folder();
                if (Directory.Exists(loc_to_search))
                {
                    Provider.search = new Thread(new ThreadStart(ScanFolder));
                    Provider.search.Start();
                }
                return;
            }
            MessageBox.Show(this,"Bạn chưa chọn chế độ quét", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_PauseScan_Click(object sender, EventArgs e)
        {
            if (Provider.scanning)
            {
                if (Provider.suspended)
                {
                    try
                    {
                        Provider.search.Resume();
                        Provider.suspended = false;
                        btn_PauseScan.Text = "Tạm dừng";
                    }
                    catch (Exception) { throw; }
                }
                else
                {
                    try
                    {
                        Provider.search.Suspend();
                        btn_PauseScan.Text = "Tiếp tục";
                        Provider.suspended = true;
                    }
                    catch (Exception) { throw; }
                }
            }
        }

        private void btn_CancelScan_Click(object sender, EventArgs e)
        {
            if (Provider.scanning)
            {
                Init();
            }
        }
        #endregion
    }
}
