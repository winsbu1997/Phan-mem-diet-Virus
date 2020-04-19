using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ladin.mtaAV.Manager;
using Ladin.mtaAV;
using Ladin.mtaAV.Utilities;
using Ladin.mtaAV.Model;
using System.Globalization;
using System.IO;
using BinarySearch;

namespace Ladin.mtaAV.Views
{
    public partial class UC_Setting : System.Windows.Forms.UserControl
    {
        #region variable
        private Firewall fw = new Firewall();
        private Database db = Provider.db;
        private EXCLUSION exclusion = new EXCLUSION();
        private QUARANTINES quarantine = new QUARANTINES();
        private QuarantineManager qr = new QuarantineManager();
        private TIMER timeMonitor = new TIMER();
        private ConsoleSetups con = new ConsoleSetups();
        private FolderLocker locker = new FolderLocker();

        #endregion

        #region Method
        private void InitProgress()
        {
            progress_Update.Minimum = 0;
            progress_Update.Value = 0;
        }
        #endregion
        #region LoadUserControl
        public UC_Setting()
        {
            InitializeComponent();
        }
        public void Load_Firewall()
        {
            if (Provider.firewallOn)
            {
                Provider.firewallOn = true;
                // xem trang thai cua tuong lua
                sw_Firewall.Value = true;
                foreach (string s in fw.GetAuthorizedAppPaths())
                {
                    lstFilewall.Items.Add(s);
                }
            }
            else
            {
                sw_Firewall.Value = false;
                Provider.firewallOn = false;
            }
        }
        public void Reload()
        {
            dgv_Exclusion.DataSource = db.EXCLUSION.ToList();
            dgv_Quarantine.DataSource = db.QUARANTINE.ToList();
            Provider.Reload();
        }
        private void UC_Setting_Load(object sender, EventArgs e)
        {
            Load_Firewall();
        }
        #endregion

        #region EventControl
        // tab FireWall
        private void sw_Firewall_OnValueChange(object sender, EventArgs e)
        {
            if (sw_Firewall.Value)
            {
                Provider.firewallOn = true;
                fw.FirewallStart(true);
            }
            else
            {
                con.RunExternalExe("netsh.exe", "Firewall set opmode disable");
                Provider.firewallOn = false;
            }
        }

        // Tab Exclusion
        private void btn_SelectFileExclusion_Click(object sender, EventArgs e)
        {
            string path = Provider.Select_File();
            exclusion.FILENAME = path;
            db.EXCLUSION.Add(exclusion);
            db.SaveChanges();
            dgv_Exclusion.DataSource = db.EXCLUSION.ToList();
        }

        private void btn_SelectFolderExclusion_Click(object sender, EventArgs e)
        {
            string path = Provider.Select_Folder();
            exclusion.FILENAME = path;
            db.EXCLUSION.Add(exclusion);
            db.SaveChanges();
            dgv_Exclusion.DataSource = db.EXCLUSION.ToList();
        }

        private void dgv_Exclusion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = dgv_Exclusion.Columns[e.ColumnIndex].Name;
            if (columnName == "btn_DeleteExclusion")
            {
                int ID = (int)dgv_Exclusion.Rows[e.RowIndex].Cells["ID_Exclusion"].Value;
                exclusion = db.EXCLUSION.Where(x => x.ID == ID).FirstOrDefault();

                db.EXCLUSION.Remove(exclusion);
                db.SaveChanges();
                dgv_Exclusion.DataSource = db.EXCLUSION.ToList();
            }
        }

        private void btn_DeleteAllExclusion_Click(object sender, EventArgs e)
        {
            db.EXCLUSION.RemoveRange(db.EXCLUSION);
            dgv_Exclusion.DataSource = null;
            db.SaveChanges();
        }

        // Tab Timer
        private void btn_SelectFolderTimer_Click(object sender, EventArgs e)
        {
            string path = Provider.Select_Folder();
            timeMonitor.FILENAME = path;
            db.TIMER.Add(timeMonitor);
            db.SaveChanges();
            dgvTimer.DataSource = db.TIMER.ToList();
        }

        // Tab Quarantine
        private void btn_AllowFile_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Quarantine.Rows.Count; i++)
            {
                bool checkCell = Convert.ToBoolean(dgv_Quarantine.Rows[i].Cells["checkRow"].Value);
                if (checkCell)
                {
                    int id = (int)dgv_Quarantine.Rows[i].Cells["ID_Quarantine"].Value;
                    string filePath = dgv_Quarantine.Rows[i].Cells["FileName_Quarantine"].Value.ToString();
                    quarantine = db.QUARANTINE.Where(x => x.ID == id).FirstOrDefault();
                    db.QUARANTINE.Remove(quarantine);
                    qr.RestoreQuarantine(filePath);
                }
            }
            db.SaveChanges();
            dgv_Quarantine.DataSource = db.QUARANTINE.ToList();
        }

        private void btn_DeleteFile_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa File ?",
                                          "Thông báo",
                                          MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Warning);
            if (rs.Equals(DialogResult.Cancel)) return;
            for (int i = 0; i < dgv_Quarantine.Rows.Count; i++)
            {
                bool checkCell = Convert.ToBoolean(dgv_Quarantine.Rows[i].Cells["checkRow"].Value);
                if (checkCell)
                {
                    int id = (int)dgv_Quarantine.Rows[i].Cells["ID_Quarantine"].Value;
                    string filePath = dgv_Quarantine.Rows[i].Cells["FileName_Quarantine"].Value.ToString();
                    quarantine = db.QUARANTINE.Where(x => x.ID == id).FirstOrDefault();
                    db.QUARANTINE.Remove(quarantine);
                    qr.DeleteQuarantine(filePath);
                    //dgv_Quarantine.Rows.RemoveAt(i);
                }
            }
            db.SaveChanges();
            dgv_Quarantine.DataSource = db.QUARANTINE.ToList();
        }

        // Tạo hoặc mở khóa folder
        private void btn_SettingVault_Click(object sender, EventArgs e)
        {
            locker.CreateOrUnlockFolder(this);
        }
        // Khóa thư mục = khóa đã tạo
        private void btn_LockVault_Click(object sender, EventArgs e)
        {
            locker.LockFolder(this);
        }
        // Xóa khóa bảo vệ thư mục
        private void btn_DeleteVault_Click(object sender, EventArgs e)
        {
            if (locker.no_valut)
                MessageBox.Show(this, "Không có khóa để xóa", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult dr = MessageBox.Show(this,
                    "Bạn có muốn xóa khóa không?",
                    "Chấp nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                    locker.DestroyFolder(this);
            }
        }

        // Su kien Switch #
        private void sw_AutoRun_OnValueChange(object sender, EventArgs e)
        {
            Provider.autorunOn = sw_AutoRun.Value;
        }
        private void sw_ScanUSB_OnValueChange(object sender, EventArgs e)
        {
            Provider.autoUsbOn = sw_ScanUSB.Value;
        }

        // Sự kiện Update
        private void btn_UpdateOnline_Click(object sender, EventArgs e)
        {
            InitProgress();
            progress_Update.Maximum = 100;
            Provider.Alert("Kiểm tra cập nhập!", frmAlert.alertTypeEnum.Info);
            ConnectApi api = new ConnectApi();
            Task.Run(new Action(() =>
           {
               string path = api.Download_File("download-file");
               if (path != null)
               {
                   Invoke(new Action(() =>
                  {
                      progress_Update.Value = progress_Update.Value + 20;
                  }));
                   Manage.UdpateDb_Md5(path);
                   Invoke(new Action(() =>
                   {
                       progress_Update.Value = progress_Update.Value + 60;
                       Task.Delay(1000);
                       progress_Update.Value = progress_Update.Value + 20;
                       Provider.Alert("Cập nhập dữ liệu thành công!", frmAlert.alertTypeEnum.Success);
                       InitProgress();
                   }));
               }
               else
               {
                   Invoke(new Action(() =>
                   {
                       Provider.Alert("Không có bản cập nhập!", frmAlert.alertTypeEnum.Info);
                   }));
               }
           }));
            
        }
        private void btn_UpdateOffline_Click(object sender, EventArgs e)
        {
            string path = Provider.Select_File();
            if (path != null)
            {
                progress_Update.Maximum = 100;
                Task.Run(new Action(() =>
                {
                    Invoke(new Action(() =>
                    {
                        progress_Update.Value = progress_Update.Value + 20;
                    }));
                    Manage.UdpateDb_Md5(path);
                    Invoke(new Action(() =>
                    {
                        progress_Update.Value = progress_Update.Value + 60;
                        Task.Delay(1000);
                        progress_Update.Value = progress_Update.Value + 20;
                        Provider.Alert("Cập nhập dữ liệu thành công!", frmAlert.alertTypeEnum.Success);
                        InitProgress();
                    }));
                }));
            }
        }

        #endregion
    }
}
