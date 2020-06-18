using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FileWatcherEx;
using Shell32;
using Ladin.mtaAV.Model;
using BinarySearch;
using Ladin.mtaAV.Views;
using System.Globalization;
using Ladin.mtaAV.Utilities;

namespace Ladin.mtaAV.Monitor_SubViews
{
    public partial class UC_MonitorFolder : UserControl
    {
        List<FileWatcherEx.FileWatcherEx> listWatcher = new List<FileWatcherEx.FileWatcherEx>();
        private Database db = Provider.db;
        public UC_MonitorFolder()
        {
            InitializeComponent();
        }
        #region Method
        private void ScanFile(string path)
        {
            if (File.Exists(path))
            {
                FileInfo info = new FileInfo(path);
                long FileLength = info.Length;
                if (FileLength > 60000000) return;
                var scanResult = Manage.MD5Scan(path);
                Invoke(new MethodInvoker(delegate
                {
                    int index = dgv_FileDetect.Rows.Add();
                    DataGridViewRow row = dgv_FileDetect.Rows[index];
                    row.Cells["FileName"].Value = Path.GetFileName(path);
                    if (!scanResult.IsEmpty)
                    {
                        row.Cells["Virus"].Value = scanResult.VirusName;
                        Provider.Alert("Phát hiện virus! Kiểm tra trong giám sát thư mục", frmAlert.alertTypeEnum.Warning);
                    }
                    else row.Cells["Virus"].Value = "Không";
                    row.Cells["Type_Scan"].Value = "Tĩnh";
                    row.Cells["Create_Date"].Value = DateTime.Now.ToString("dd/MM/yyyy HH: mm", CultureInfo.InvariantCulture);
                }));
            }
        }
        private string TakeLnk_Location(string shortcut)
        {
            string pathOnly = System.IO.Path.GetDirectoryName(shortcut);
            string filenameOnly = System.IO.Path.GetFileName(shortcut);

            Shell32.Shell shell = new Shell32.Shell();
            Folder folder = shell.NameSpace(pathOnly);
            FolderItem folderItem = folder.ParseName(filenameOnly);
            if (folderItem != null)
            {
                Shell32.ShellLinkObject link = (Shell32.ShellLinkObject)folderItem.GetLink;
                return link.Path.ToString();
            }
            return null; 
        }
        private void AddRow(string FileName, string Virus, string Type_Scan)
        {
            int index = dgv_FileDetect.Rows.Add();
            DataGridViewRow row = dgv_FileDetect.Rows[index];
            row.Cells["FileName"].Value = FileName;
            row.Cells["Virus"].Value = Virus;
            row.Cells["Type_Scan"].Value = Type_Scan;
            row.Cells["Create_Date"].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            //dgv_FileDetect.Refresh();
        }
        private void FileWatcher(string path)
        {
            int index1 = dgv_Folder.Rows.Add();
            DataGridViewRow row = dgv_Folder.Rows[index1];
            row.Cells["FileName_Folder"].Value = path;
            dgv_Folder.Refresh();
            int index = listWatcher.Count;
            listWatcher.Add(new FileWatcherEx.FileWatcherEx(path){} );
            listWatcher[index].OnCreated += Watcher_OnCreated;
            listWatcher[index].SynchronizingObject = this;
            listWatcher[index].Start();
        }
        #endregion

        #region Event
        private void Watcher_OnCreated(object sender, FileChangedEvent e)
        {
            string loc = e.FullPath;
            if (ck_Shortcut.Checked && Path.GetExtension(loc) == ".lnk")
            {
                loc = TakeLnk_Location(loc);
            }
            bool check = db.EXCLUSION.ToList().Any(x => x.FILENAME == loc);
            if (check) return;
            ScanFile(loc);
        }
        private void btn_SelectFolder_Click(object sender, EventArgs e)
        {
            Provider.realtimeOn = true;
            string path = Provider.Select_Folder();
            if(Directory.Exists(path)) FileWatcher(path);
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            Provider.realtimeOn = false;
            int count = dgv_Folder.Rows.Count - 1;
            foreach (FileWatcherEx.FileWatcherEx item in listWatcher)
            {
                item.Stop();
                item.Dispose();
                dgv_Folder.Rows.RemoveAt(count --);
            }
            dgv_Folder.Refresh();
        }
        private void dgv_Folder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnFolder = dgv_Folder.Columns[e.ColumnIndex].Name;
            if(columnFolder == "btn_DeleteFolder")
            {
                string path = dgv_Folder.Rows[e.RowIndex].Cells["FileName_Folder"].Value.ToString();
                int index = listWatcher.FindIndex(x => x.FolderPath == path);
                listWatcher[index].Stop();
                listWatcher[index].Dispose();
                listWatcher.Remove(listWatcher[index]);
                dgv_Folder.Rows.RemoveAt(e.RowIndex);
            }
        }
        private void dgv_FileDetect_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = dgv_FileDetect.Columns[e.ColumnIndex].Name;
            string path = dgv_FileDetect.Rows[e.RowIndex].Cells["FileName"].Value.ToString();
            if (columnName == "Check_File")
            {
                string[] file = { path };
                ConnectApi api = new ConnectApi();
                Provider.Alert("Bắt đầu phân tích động... !", frmAlert.alertTypeEnum.Info);
                dgv_FileDetect.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Properties.Resources.icons8_Loader_32;
                try
                {
                    Task.Run(new Action(() => {
                        var task = api.Upload_MultiFiles<QUARANTINES>("/api/v1/capture/check", file);
                        QUARANTINES kq = task.First();
                        kq.FILENAME = path;
                        dgv_FileDetect.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Properties.Resources.Checked_48px;
                        if (kq.VIRUS == "1")
                        {
                            Provider.list_NewQuarantines.Add(kq);
                            dgv_FileDetect.Rows[e.RowIndex].Cells["Virus"].Value = "Có";
                            dgv_FileDetect.Rows[e.RowIndex].Cells["Type_Scan"].Value = "Động";
                            dgv_FileDetect.Refresh();
                            //Provider.Alert(Path.GetFileName(path) + " nhiễm mã độc! Kiểm tra file tải về", frmAlert.alertTypeEnum.Warning);
                            BeginInvoke(new Action(() =>
                            {
                                Provider.Alert(Path.GetFileName(path) + " nhiễm mã độc! Kiểm tra file tải về", frmAlert.alertTypeEnum.Warning);
                            }));
                        }
                        else
                        {
                            dgv_FileDetect.Rows[e.RowIndex].Cells["Virus"].Value = "Không";
                        }
                    }));
                }
                catch
                {
                    Provider.Alert("Lỗi kết nối", frmAlert.alertTypeEnum.Error);
                }
            }
            else if(columnName == "btn_DeleteFile")
            {
                try
                {
                    File.Delete(path);
                }
                catch { }
            }
        }

        #endregion
    }
}
