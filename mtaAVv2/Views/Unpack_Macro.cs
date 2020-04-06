using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladin.mtaAV.Manager;
using System.Windows.Forms;
using System.IO;

namespace Ladin.mtaAV.Views
{
    public partial class Unpack_Macro : Form
    {
        public delegate void Send_Macro(List<Detail_Macro> dt, BindingList<File_Macro> dt_File);
        private List<Detail_Macro> lst = new List<Detail_Macro>();
        private BindingList<File_Macro> lst_File = new BindingList<File_Macro>();
        public Send_Macro sender;
        public Unpack_Macro()
        {
            InitializeComponent();
            dgv_DocumentFile.MultiSelect = false;
            sender = new Send_Macro(Get_Macro);
        }
        private void Get_Macro(List<Detail_Macro> dt, BindingList<File_Macro> dt_File)
        {
            lst = dt;
            lst_File = dt_File;
            dgv_DocumentFile.DataSource = dt_File;
            dgv_DocumentFile.Rows[0].Cells["FileName"].Selected = true;
            Detail_Macro tmp = new Detail_Macro();
            tmp = lst[0];
            txtMacro.Text = tmp.Macro_Code.ToString();
            bindingSource1.DataSource = tmp.Suspecious_Patterns;
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            foreach(File_Macro item in lst_File)
            {
                try
                {
                    if (File.Exists(item.FileName))
                    {
                        File.Delete(item.FileName);
                    }
                }
                catch { }
            }
            MessageBox.Show("Xóa thành công");
            Provider.countDoc = 0;
            this.Close();
        }

        private void dgv_DocumentFile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string columnName = dgv_DocumentFile.Columns[e.ColumnIndex].Name;
            int ID = (int)dgv_DocumentFile.Rows[e.RowIndex].Cells["ID"].Value;
            string FileName = dgv_DocumentFile.Rows[e.RowIndex].Cells["FileName"].Value.ToString();
            Detail_Macro tmp = new Detail_Macro();
            tmp = lst.Where(x => x.ID == ID).FirstOrDefault();
            if (columnName == "FileName")
            {
                txtMacro.Text = tmp.Macro_Code.ToString();
                bindingSource1.DataSource = tmp.Suspecious_Patterns;
            }
            else if(columnName == "btn_DeleteExclusion")
            {
                lst.Remove(tmp);
                lst_File.Remove(new File_Macro(ID, FileName));
                dgv_DocumentFile.Rows.RemoveAt(e.RowIndex);
                try
                {
                    if (File.Exists(FileName)) { File.Delete(FileName); }
                }
                catch { }
                if(lst.Count > 0)
                {
                    tmp = lst[0];
                    txtMacro.Text = tmp.Macro_Code.ToString();
                    bindingSource1.DataSource = tmp.Suspecious_Patterns;
                }
                //dgv_DocumentFile.DataSource = lst;
            }
        }

        private void Unpack_Macro_FormClosing(object sender, FormClosingEventArgs e)
        {
            Provider.countDoc = lst_File.Count;
        }
    }
}
