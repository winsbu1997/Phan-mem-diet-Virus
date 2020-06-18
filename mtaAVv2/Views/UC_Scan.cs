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
using System.IO;
using System.Threading;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using Ladin.mtaAV.Manager;
using Ladin.mtaAV.Utilities;

namespace Ladin.mtaAV.Views
{
    public partial class UC_Scan : System.Windows.Forms.UserControl
    {
#pragma warning disable CS0618 // Type or member is obsolete
        #region variable
        private string wildcard = "*.*";
        private string smart_ext = "*.exe|*.cpl|*.reg|*.ini|*.bat|*.com|*.dll|*.pif|*.lnk|*.scr|*.vbs|*.ocx|*.drv|*.sys";
        private string[] doc_ext = { ".docm", ".doc", ".xls", ".xlsm", ".ppt", ".pptm" };
        private string[] files = null;
        private string loc_to_search = string.Empty;
        string date = DateTime.Now.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        private List<Detail_Macro> dt_mc = new List<Detail_Macro>();
        private BindingList<File_Macro> lst_FileMacro = new BindingList<File_Macro>();
        private List<ConnectApi> lst_DynamicMalware = new List<ConnectApi>();
        #endregion
        public UC_Scan()
        {
            InitializeComponent();
        }

        #region Method
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
            Provider.countDoc = 0;
            dt_mc = new List<Detail_Macro>();
            lst_FileMacro = new BindingList<File_Macro>();
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
        private void ScanDoc(string path)
        {
            Detail_Macro tmp = new Detail_Macro();
            File_Macro item = new File_Macro();
            Suspecious sp = new Suspecious();
            List<string> List_Macro = tmp.Check_Macro(path);
            if (List_Macro.Count > 0)
            {
                string codeMacro = tmp.Split_Macro(List_Macro);
                sp = tmp.Check_Suspecious(List_Macro);
                item = new File_Macro(Provider.countDoc, path);
                tmp = new Detail_Macro(Provider.countDoc, codeMacro, sp);
                Provider.countDoc++;
                Invoke(new Action(() =>
                {
                    lb_CountMacro.Text = Provider.countDoc.ToString();
                }));
                lst_FileMacro.Add(item);
                dt_mc.Add(tmp);
            }
        }
        private void ScanFile(string loc)
        {
            int ret = 0;
            if (File.Exists(loc))
            {
                var scanResult = Manage.MD5Scan(loc);
                if (scanResult.IsEmpty)
                {
                    Provider.Alert("Quét tĩnh: File sạch", frmAlert.alertTypeEnum.Success);
                    ret = 1;
                }
                else
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
            }
            else
            {
                Provider.Alert("Không quét được file này!", frmAlert.alertTypeEnum.Error);
            }
            if (sw_DynamicScan.Value && ret == 1)
            {
                Provider.Alert("Bắt đầu phân tích động... !", frmAlert.alertTypeEnum.Info);
                lb_LocationFileScan.Text = Path.GetFileName(loc);
                string[] s = { loc };
                Task.Run(new Action(() =>
               {
                   ConnectApi api = new ConnectApi();
                   try
                   {
                       QUARANTINES kq = api.Upload_MultiFiles<QUARANTINES>("/api/v1/capture/check", s).First();
                       kq.FILENAME = loc;
                       if (kq.VIRUS == "1")
                       {
                           //Provider.Alert(loc + "nhiễm mã độc", frmAlert.alertTypeEnum.Warning);
                           BeginInvoke(new Action(() =>
                           {
                               Provider.Alert(loc + "nhiễm mã độc", frmAlert.alertTypeEnum.Warning);
                               txtListVirus.Text = "1";
                           }));
                           Provider.list_NewQuarantines.Add(kq);
                       }
                       lst_DynamicMalware.AddRange(api.GetResult());
                   }
                   catch
                   {
                       BeginInvoke(new Action(() =>
                       {
                           Provider.Alert("Lỗi kết nối !", frmAlert.alertTypeEnum.Error);
                       }));
                   };
               }));
            }
            checkFile.Checked = false;
        }
        private void ScanFolder()
        {
            Provider.scanning = true;
            int infected = 0;
            Invoke(new Action(() =>
            {
                Provider.Alert("MtaAV bắt đầu quét mã độc", frmAlert.alertTypeEnum.Info);
                Init_Scanning();
            }));

            if (sw_SmartScan.Value) files = Provider.GetFiles(loc_to_search, smart_ext, SearchOption.AllDirectories);
            else files = Provider.GetFiles(loc_to_search, wildcard, SearchOption.AllDirectories);
            int total = files.Length;
            string[] lst_Dynamic = new string[total];
            int count_Dynamic = 0;

            Invoke(new Action(() =>
            {
                lb_AllFile.Text = total.ToString() + "  file";
                progressBar_Scan.Maximum = total;
            }));
            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.Length > 5242880) goto NEXT;
                    try
                    {
                        string find = Path.GetExtension(file);
                        if (sw_macro.Value && Array.Exists(doc_ext, x => x == find))
                        {
                            ScanDoc(file);
                        };
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
                        else
                        {
                            lst_Dynamic[count_Dynamic++] = file;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            NEXT: Invoke(new Action(() =>
           {
               progressBar_Scan.Value = progressBar_Scan.Value + 1;
           }));
            }
            if (sw_DynamicScan.Value)
            {
                Provider.Alert("Bắt đầu phân tích động... !", frmAlert.alertTypeEnum.Info);
                ConnectApi api = new ConnectApi();
                lst_Dynamic = lst_Dynamic.Where(x => x != null).ToArray();
                Task.Run(new Action(() =>
                {
                    try
                    {
                        List<QUARANTINES> kq = api.Upload_MultiFiles<QUARANTINES>("/api/v1/capture/check", lst_Dynamic);
                        foreach (QUARANTINES item in kq)
                        {
                            item.FILENAME = lst_Dynamic.Where(x => x.Contains(item.FILENAME)).First();
                            if (item.VIRUS == "1")
                            {
                                infected++;
                                BeginInvoke(new MethodInvoker(delegate
                                {
                                    lb_CountVirus.Text = infected.ToString();
                                    Provider.Alert(Path.GetFileName(item.FILENAME) + " có mã độc!", frmAlert.alertTypeEnum.Warning);
                                }));
                                Provider.list_NewQuarantines.Add(item);
                            }
                            lst_DynamicMalware.AddRange(api.GetResult());
                        }
                    }
                    catch
                    {
                        BeginInvoke(new Action(() =>
                        {
                            Provider.Alert("Lỗi kết nối !", frmAlert.alertTypeEnum.Error);
                        }));
                    }
                }));
            }
            Invoke(new Action(() =>
           {
               // file am thanh thong bao
               //SoundPlayer snd = new SoundPlayer(Properties.Resources.virfound);
               //snd.Play();
               if (infected > 0) Provider.Alert("Có mã độc kiểm tra trong Tab cách ly", frmAlert.alertTypeEnum.Warning);
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
                        lb_LocationFileScan.Text = Path.GetFileName(proc);
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
                else Provider.Alert("Có mã độc kiểm tra trong Tab cách ly", frmAlert.alertTypeEnum.Success);
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
            Provider.currentScan = DateTime.Now.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
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
                    ScanFile(path);
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
            MessageBox.Show(this, "Bạn chưa chọn chế độ quét", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                checkFolder.Checked = false;
                checkProcess.Checked = false;
            }
        }

        private void lb_ShowMacro_Click(object sender, EventArgs e)
        {
            Unpack_Macro frm = new Unpack_Macro();
            frm.sender(dt_mc, lst_FileMacro);
            frm.ShowDialog();
            lb_CountMacro.Text = Provider.countDoc.ToString();
        }

        private void sw_DynamicScan_OnValueChange(object sender, EventArgs e)
        {
            if (sw_DynamicScan.Value)
            {
                //gunaPanel4.BringToFront();
            }
            else gunaPanel1.BringToFront();
        }

        private void txtListVirus_Click(object sender, EventArgs e)
        {
            Reprot_DynamicScan frm = new Reprot_DynamicScan();
            frm.sender(lst_DynamicMalware);
            frm.ShowDialog();
        }
        #endregion
    }
}
