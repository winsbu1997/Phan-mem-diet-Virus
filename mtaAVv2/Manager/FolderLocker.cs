using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Ladin.mtaAV.Utilities;
using Ladin.mtaAV.Views;
using Microsoft.Win32;

namespace Ladin.mtaAV.Manager
{
    class FolderLocker
    {
        public bool no_valut = true;
        private string salted_pass = string.Empty;
        private string password = string.Empty;
        private string vault_loc = string.Empty;
        private string hashKey = "mtaAV_key_2020@#$%138";
        private List<string> users = new List<string>();
        private ConsoleSetups con = new ConsoleSetups();

        public FolderLocker()
        {
            GetUsers();
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\mtaAV Antivirus");
            if (key != null)
            {
                //using faked sub keys like update and uniqueID to mislead users who are exploring registry
                //so they will not be able to recognize the original password and vault location
                //for more security both password and vault locations are encrypted
                salted_pass = key.GetValue("Update").ToString();
                vault_loc = key.GetValue("UniqueID").ToString();

                //now decrypt the salted_pass and vault_loc to get original one
                no_valut = false;
                salted_pass = Decrypt(salted_pass, hashKey);
                vault_loc = Decrypt(vault_loc, hashKey);
            }
            else
                no_valut = true;

        }

        public void CreateOrUnlockFolder(UserControl main)
        {
            if(no_valut)
            {
                //there's no vault, show user first time info and take vault location and password
                MessageBox.Show(main, "Chọn hoặc mở thư mục cần bảo vệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowNewFolderButton = true;
                fbd.Description = "Chọn thư mục";
                if(fbd.ShowDialog() == DialogResult.OK)
                {
                    //using(var form = new VaultPassword())
                    //{
                    //    form.Text = "Tạo mật khẩu";
                    //    form.gunaButton1.Text = "Tạo Khóa";
                    //    var result = form.ShowDialog();
                    //    if(result == DialogResult.Cancel)
                    //    {
                    //        password = form.password;
                    //        con.RunExternalExe("attrib.exe", "+s +h +r +a " + '"' + fbd.SelectedPath + '"');
                    //        SetPermission(fbd.SelectedPath, AccessControlType.Deny);
                    //        RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\mtaAV Antivirus");
                    //        if(key!=null)
                    //        {
                    //            key.SetValue("Update", Encrypt(password, hashKey));
                    //            key.SetValue("UniqueID", Encrypt(fbd.SelectedPath, hashKey));
                    //        }
                    //        else
                    //        {
                    //            key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\mtaAV Antivirus");
                    //            key.SetValue("Update", Encrypt(password, hashKey));
                    //            key.SetValue("UniqueID", Encrypt(fbd.SelectedPath, hashKey));
                    //        }
                    //        no_valut = false;
                    //        salted_pass = password;
                    //        vault_loc = fbd.SelectedPath;
                    //        MessageBox.Show(main,"Khóa được tạo thành công","Kết thúc",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    //    }//end if
                    //}//end using
                }//end if
            }
            else
            {
                //vault is there, get key and open it
                //using (var form = new VaultPassword())
                //{
                //    form.Text = "Nhập mật khẩu";
                //    form.gunaButton1.Text = "Mở";
                //    var result = form.ShowDialog();
                //    if(result == DialogResult.Cancel)
                //    {
                //        password = form.password;
                //        if (password == salted_pass)
                //        {
                //            SetPermission(vault_loc, AccessControlType.Allow);
                //            con.RunExternalExe("attrib.exe", "-s -h -r -a " + '"' + vault_loc + '"');
                //            Process.Start(vault_loc);
                //        }
                //        else
                //            MessageBox.Show(main, "Mật khẩu không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
            }
        }

        public void LockFolder(UserControl main)
        {
            if(!no_valut)
            {
                con.RunExternalExe("attrib.exe", "+s +h +r +a " + '"' + vault_loc + '"');
                SetPermission(vault_loc, AccessControlType.Deny);
                MessageBox.Show(main, "Khóa được tạo thành công","Kết thúc",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        public bool DestroyFolder(UserControl main)
        {
            if (no_valut)
                return false;
            else
            {
                //destroy the vault and reg settings
                //using (var form = new VaultPassword())
                //{
                //    form.Text = "Nhập mật khẩu";
                //    form.gunaButton1.Text = "Xóa Khóa";
                //    var result = form.ShowDialog();
                //    if (result == DialogResult.Cancel)
                //    {
                //        password = form.password;
                //        if (password == salted_pass)
                //        {
                //            SetPermission(vault_loc, AccessControlType.Allow);
                //            con.RunExternalExe("attrib.exe", "-s -h -r -a " + '"' + vault_loc+ '"');
                //            //EmptyFolder(new DirectoryInfo(vault_loc));
                //            //Directory.Delete(vault_loc);
                //            Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\mtaAV Antivirus");
                            
                //            MessageBox.Show(main, "Khóa đã được hủy", "Kết thúc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            no_valut = true;
                //        }
                //        else
                //            MessageBox.Show(main, "Mật khẩu không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
                return true;
            }

        }

        private void GetUsers()
        {
	        SelectQuery sQuery = new SelectQuery("Win32_UserAccount","Domain='"+ System.Environment.UserDomainName.ToString() + "'");
	        try
	        {
		        ManagementObjectSearcher mSearcher = new ManagementObjectSearcher(sQuery);
		        foreach(ManagementObject mObject in mSearcher.Get())
		        {
                    users.Add(mObject["Name"].ToString());
		        }
	        }
	        catch{}
        }

        private void SetPermission(string folder,AccessControlType type)
        {
            if (type == AccessControlType.Deny)
            {
                DirectoryInfo info = new DirectoryInfo(folder);
                DirectorySecurity security = info.GetAccessControl();

                foreach (string user in users)
                {
                    security.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.ReadAndExecute, type));
                    security.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.Traverse, type));
                    security.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.Write, type));
                    security.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.Delete, type));
                    security.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.DeleteSubdirectoriesAndFiles, type));
                    security.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.ExecuteFile, type));
                    security.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.Modify, type));
                    security.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.Read, type));
                }
                info.SetAccessControl(security);
            }
            else
            {
                string arg = "cmd.exe /c takeown /f " + '"' +folder +'"' + " /r /d y && icacls " + '"' + folder + '"' + " /grant administrators:F /t /c /l /q";
                con.RunExternalExe("cmd.exe", arg);
            }
        }

        private string Encrypt(string strToEncrypt, string strKey)
        {
            try
            {
                TripleDESCryptoServiceProvider objDESCrypto = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();
                byte[] byteHash, byteBuff;
                string strTempKey = strKey;
                byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB
                byteBuff = ASCIIEncoding.ASCII.GetBytes(strToEncrypt);
                return Convert.ToBase64String(objDESCrypto.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }
            catch (Exception ex)
            {
                return "Lỗi khi nhập. " + ex.Message;
            }
        }

        private string Decrypt(string strEncrypted, string strKey)
        {
            try
            {
                TripleDESCryptoServiceProvider objDESCrypto = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();
                byte[] byteHash, byteBuff;
                string strTempKey = strKey;
                byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB
                byteBuff = Convert.FromBase64String(strEncrypted);
                string strDecrypted = ASCIIEncoding.ASCII.GetString(objDESCrypto.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
                objDESCrypto = null;
                return strDecrypted;
            }
            catch (Exception ex)
            {
                return "Lỗi khi nhập. " + ex.Message;
            }
        }

        private void EmptyFolder(DirectoryInfo directoryInfo)
        {
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo subfolder in directoryInfo.GetDirectories())
            {
                EmptyFolder(subfolder);
            }
        }

    } //end of class
} //end of namespace
