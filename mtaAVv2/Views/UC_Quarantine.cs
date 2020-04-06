using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ladin.mtaAV.Model;
using System.IO;
using System.Runtime.InteropServices;
using Ladin.mtaAV.Manager;

namespace Ladin.mtaAV.Views
{
    public partial class UC_Quarantine : System.Windows.Forms.UserControl
    {
#pragma warning disable 0618 // removes the obsolete warning
        [DllImport("process-killer.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int KillProcess(IntPtr handle, string proc_name);
        private Database db = Provider.db;
        private QuarantineManager qr = new QuarantineManager();
        public void Reload()
        {
            quarantineBinding.DataSource = Provider.list_NewQuarantines.ToList();
        }
        public UC_Quarantine()
        {
            InitializeComponent();
        }

        #region Event
        private void UC_Quarantine_Load(object sender, EventArgs e)
        {
            Reload();
        }
        private void btn_Quarantine_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Quarantine.Rows.Count; i++)
            {

                bool checkCell = Convert.ToBoolean(dgv_Quarantine.Rows[i].Cells["checkRow"].Value);
                if (checkCell)
                {
                    string filePath = dgv_Quarantine.Rows[i].Cells["FILENAME"].Value.ToString();
                    string virus = dgv_Quarantine.Rows[i].Cells["VIRUS"].Value.ToString();
                    string typeScan = dgv_Quarantine.Rows[i].Cells["TYPE_SCAN"].Value.ToString();
                    string date = dgv_Quarantine.Rows[i].Cells["CREATE_DATE"].ToString();
                    QUARANTINES quarantine = new QUARANTINES(filePath, virus, typeScan, date);
                    db.QUARANTINE.Add(quarantine);
                    Provider.list_NewQuarantines.Remove(quarantine);
                    KillProcess(this.Handle, filePath); // try to kill the process before deleting it
                    qr.AddQuarantine(filePath);
                }
            }
            db.SaveChanges();
            Reload();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Quarantine.Rows.Count; i++)
            {
                bool checkCell = Convert.ToBoolean(dgv_Quarantine.Rows[i].Cells["checkRow"].Value);
                if (checkCell)
                {
                    string filePath = dgv_Quarantine.Rows[i].Cells["FILENAME"].Value.ToString();
                    QUARANTINES quarantine = Provider.list_NewQuarantines.Where(x => x.FILENAME == filePath).FirstOrDefault();
                    Provider.list_NewQuarantines.Remove(quarantine);
                    if (File.Exists(filePath))
                    {
                        KillProcess(this.Handle, filePath); // try to kill the process before deleting it
                        File.Delete(filePath);
                    }
                }
            }
            Reload();
        }
        private void ckb_All_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Quarantine.Rows.Count; i++)
            {
                bool checkedCell = Convert.ToBoolean(dgv_Quarantine.Rows[i].Cells["checkRow"].Value);
                if (ckb_All.Checked)
                {
                    dgv_Quarantine.Rows[i].Cells["checkRow"].Value = true;
                }
                else
                {
                    dgv_Quarantine.Rows[i].Cells["checkRow"].Value = true;
                }
            }
            dgv_Quarantine.Refresh();
        }
        #endregion

    }
}
