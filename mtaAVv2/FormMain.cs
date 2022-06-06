using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ladin.mtaAV.Views;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;
using Ladin.mtaAV.Model;

namespace Ladin.mtaAV
{
    public partial class FormMain : Form
    {
        // check Program
        int flag = 0;
        private bool CheckStartup()
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            // Nếu key này tồn tại thì 
            var rg = registryKey.GetValue("mtaAV");
            if (rg != null)
            {
                return true;
            }
            return false;
        }
        private void RegisterInStartup(string location)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            // Đăng ký stratup cùng Windows
            registryKey.SetValue("mtaAV", location + "\\mtaAV.exe");
        }

        private string my_location = string.Empty;
        private void Init()
        {

        }
        public FormMain()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);
            //uC_Main1.BringToFront();
            my_location = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (!CheckStartup())
            {
                RegisterInStartup(my_location);
            }
            if (!Directory.Exists("log"))
            {
                Directory.CreateDirectory("log");
            }
            if (!Directory.Exists("Update"))
            {
                Directory.CreateDirectory("Update");
            }
            if (!Directory.Exists("Downloads"))
            {
                Directory.CreateDirectory("Downloads");
            }
        }
        #region Load_UC
        private void Nav_status_Click(object sender, EventArgs e)
        {
            //uC_Main1.Reload();
            //uC_Main1.BringToFront();
        }

        private void Nav_scan_Click(object sender, EventArgs e)
        {
            uC_Scan1.BringToFront();
        }

        private void Nav_modules_Click(object sender, EventArgs e)
        {
            //uC_Setting1.Reload();
            //uC_Setting1.BringToFront();
        }

        private void Nav_quarantine_Click(object sender, EventArgs e)
        {
            //uC_Quarantine1.Reload();
            //uC_Quarantine1.BringToFront();
        }

        private void Nav_activity_Click(object sender, EventArgs e)
        {
            //uC_Monitoring1.BringToFront();
        }
        #endregion
        #region Event Close, Open Form
        private void Minimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void HideWindow_Click(object sender, EventArgs e)
        {
            try
            {
                Provider.search.Abort();
            }
            catch { }
            Application.Exit();
        }
        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                Hide();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                notifyIcon1.Visible = true;
                this.Hide();
                e.Cancel = true;
            }
            else if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                Application.Exit();
            }
        }

        private void frmShow_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void frmClose_Click(object sender, EventArgs e)
        {
            Provider.search.Abort();
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void btnSetUp_Server_Click(object sender, EventArgs e)
        {
            //uC_ConnectApi1.BringToFront();
        }
        #endregion

    }
}
