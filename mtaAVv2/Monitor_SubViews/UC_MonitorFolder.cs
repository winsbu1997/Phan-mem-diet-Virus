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
            bool check = db.EXCLUSION.ToList().Any(x => x.FILENAME == e.FullPath);
            if (check) return;
            FileInfo info  = new FileInfo(e.FullPath);
            long FileLength = info.Length;
            if (FileLength > 5000000) return;
            if (ck_Shortcut.Checked && Path.GetExtension(e.FullPath) == ".lnk")
            {
                string mainLocation = TakeLnk_Location(e.FullPath);
                AddRow(e.FullPath, "Shortcut", mainLocation);
                var scan = Manage.MD5Scan(mainLocation);
                if (!scan.IsEmpty) AddRow(mainLocation, scan.VirusName, "Tĩnh");
                return;
            }
            var scanResult = Manage.MD5Scan(e.FullPath);
            if (!scanResult.IsEmpty)
            {
                Provider.Alert("Phát hiện virus! Kiểm tra trong Tab theo dõi thư mục", frmAlert.alertTypeEnum.Warning);
                AddRow(e.FullPath, scanResult.VirusName, "Tĩnh");
            }
        }
        private void btn_SelectFolder_Click(object sender, EventArgs e)
        {
            string path = Provider.Select_Folder();
            if(Directory.Exists(path)) FileWatcher(path);
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            foreach (FileWatcherEx.FileWatcherEx item in listWatcher)
            {
                item.Stop();
                item.Dispose();
            }
            dgv_Folder.DataSource = null;
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
        #endregion
    }
}
