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
            uC_Main1.BringToFront();
            my_location = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (!CheckStartup())
            {
                RegisterInStartup(my_location);
            }
        }
        private void Nav_status_Click(object sender, EventArgs e)
        {
            uC_Main1.Reload();
            uC_Main1.BringToFront();
        }

        private void Nav_scan_Click(object sender, EventArgs e)
        {
            uC_Scan1.BringToFront();
        }

        private void Nav_modules_Click(object sender, EventArgs e)
        {
            uC_Setting1.Reload();
            uC_Setting1.BringToFront();
        }

        private void Nav_quarantine_Click(object sender, EventArgs e)
        {
            uC_Quarantine1.Reload();
            uC_Quarantine1.BringToFront();
        }

        private void Nav_activity_Click(object sender, EventArgs e)
        {
            uC_Monitoring1.BringToFront();
        }

        private void Minimized_Click(object sender, EventArgs e)
        {
            if (Visible)
                Hide();
        }

        private void HideWindow_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
