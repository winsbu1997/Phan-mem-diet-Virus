using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ladin.mtaAV.Model;
using Ladin.mtaAV.Views;

namespace Ladin.mtaAV
{
    class Provider
    {
        #region avariable 
        public static Model.Database db = new Model.Database();
        public static OpenFileDialog openFile = new OpenFileDialog();
        public static FolderBrowserDialog openFolder = new FolderBrowserDialog();
        public static Thread search = null;
        public static Task scanUSB = null;
        public static bool scanning = false;
        //public static bool scanningUSB = false;
        public static bool suspended = false;
        public static int countDoc = 0;
        public static string url = "192.168.126.26";
        public static string port = "5002";
        //public static string runningPath = AppDomain.CurrentDomain.BaseDirectory; database bath, md5 path
        //public static string DllPath = string.Format("{0}Dll\\", Path.GetFullPath(Path.Combine(runningPath, @"..\..\")));
        #endregion

        #region Method
        public static void Reload()
        {
            try
            {
                var context = ((IObjectContextAdapter)db).ObjectContext;
                var refreshableObjects = (from entry in context.ObjectStateManager.GetObjectStateEntries(
                                                           EntityState.Added
                                                           | EntityState.Deleted
                                                           | EntityState.Modified
                                                           | EntityState.Unchanged)
                                          where entry.EntityKey != null
                                          select entry.Entity).ToList();

                context.Refresh(RefreshMode.StoreWins, refreshableObjects);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static string Select_File()
        {
            string file = "";
            openFile.Title = "Select the file please";
            openFile.Multiselect = false;
            openFile.CheckPathExists = true;
            openFile.FileName = "";
            openFile.Filter = "All files|*.*";
            openFile.SupportMultiDottedExtensions = false;
            if (DialogResult.OK == openFile.ShowDialog()) file = openFile.FileName;
            return file;
        }
        public static string Select_Folder()
        {
            string folder = "";
            openFolder.Description = "Select a driver or folder";
            if (DialogResult.OK == openFolder.ShowDialog()) folder = openFolder.SelectedPath;
            return folder;
        }
        public static void Alert(string msg, frmAlert.alertTypeEnum type)
        {
            frmAlert f = new frmAlert();
            f.setAlert(msg, type);
        }

        public static string[] GetFiles(string SourceFolder, string Filter, System.IO.SearchOption searchOption)
        {
            ArrayList alFiles = new ArrayList();
            if (!Directory.Exists(SourceFolder)) return (string[])alFiles.ToArray(typeof(string));
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
        #endregion
        #region Load_Uc
        public static bool firewallOn = false;
        public static bool realtimeOn = false;
        public static bool autorunOn = true;
        public static bool autoUsbOn = true;
        public static bool autoupdateOn = false;
        public static bool monitoring_ProcessOn = false;
        public static bool monitoring_NetworkOn = false;
        public static string currentScan = null;
        public static string[] txt_Alert = { "Máy tính được bảo vệ", "Máy tính của bạn chưa được bảo vệ"};
        #endregion

        #region temp
        public static List<QUARANTINES> list_NewQuarantines = new List<QUARANTINES>();

        #endregion
    }
}
