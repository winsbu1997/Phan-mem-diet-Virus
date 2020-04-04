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

namespace Ladin.mtaAV.Views
{
    public partial class UC_Quarantine : System.Windows.Forms.UserControl
    {
        private Database db = Provider.db;
        public void Reload()
        {
            quarantineBinding.DataSource = Provider.list_NewQuarantines.ToList();
            Provider.Reload();
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
            for (int i = 0; i < dgv_Quarantine.Rows.Count - 1; i++)
            {

                DataGridViewCheckBoxCell checkedCell = (DataGridViewCheckBoxCell)dgv_Quarantine.Rows[i].Cells["checkRow"];
                if (checkedCell.Selected)
                {
                    string filePath = dgv_Quarantine.Rows[i].Cells["FILENAME"].Value.ToString();
                    string virus = dgv_Quarantine.Rows[i].Cells["VIRUS"].Value.ToString();
                    string typeScan = dgv_Quarantine.Rows[i].Cells["TYPE_SCAN"].Value.ToString();
                    //DateTime date = DateTime.ParseExact(dgv_Quarantine.Rows[i].Cells["CREATE_DATE"].ToString(), "yyyy-MM-dd HH:mm tt", null);
                    QUARANTINES quarantine = new QUARANTINES(filePath, virus, typeScan, null);
                    db.QUARANTINE.Add(quarantine);
                    Provider.list_NewQuarantines.Remove(quarantine);
                }
            }
            db.SaveChanges();
            Reload();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Quarantine.Rows.Count - 1; i++)
            {
                DataGridViewCheckBoxCell checkedCell = (DataGridViewCheckBoxCell)dgv_Quarantine.Rows[i].Cells["checkRow"];
                if (checkedCell.Selected)
                {
                    string filePath = dgv_Quarantine.Rows[i].Cells["FILENAME"].Value.ToString();
                    QUARANTINES quarantine = Provider.list_NewQuarantines.Where(x => x.FILENAME == filePath).FirstOrDefault();
                    Provider.list_NewQuarantines.Remove(quarantine);
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
            }
            Reload();
        }
        private void ckb_All_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Quarantine.Rows.Count - 1; i++)
            {
                DataGridViewCheckBoxCell checkedCell = (DataGridViewCheckBoxCell)dgv_Quarantine.Rows[i].Cells["checkRow"];
                if (ckb_All.Checked)
                {
                    checkedCell.Selected = true;
                }
                else
                {
                    checkedCell.Selected = true;
                }
            }
            dgv_Quarantine.Refresh();
        }
        #endregion

    }
}
