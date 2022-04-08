using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BinarySearch;
namespace mtaAVCLI
{
    class Program
    {
        static readonly string txtHeader= @"
            ------------------------Chuong trinh quet virus-------------------------            
            ";
        static readonly string txtMain= @"
            1. Quet file
            2. Quet folder
            3. Quet Marco
            4. Quet RaSoat
            ";
        static readonly string txtBack = @"
            0. Quay lai
            ";
        static readonly string txt = @"
            ------------------------Chuong trinh quet virus-------------------------            
            ";

        static string txtMess = @"
            Lua chon: ";
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
        static void Main(string[] args)
        {   
            Console.OutputEncoding = Encoding.UTF8;
            

            string loc = "D:\\Project\\TDuong\\Phan-mem-diet-Virus\\mtaAVv2\\bin\\Debug\\Guna.UI.dll";
            //string loc = @"D:\Desktop\ignore_Virus\Test (main)\Virus.Win32.Wit.a";
            //var key = Console.ReadKey();

            //while (key.KeyChar!='0')
            while (true)
            {
                MainState();
                //key = Console.ReadKey();
                //Console.Write("\n" + key.KeyChar);
            }
            //Console.WriteLine();
            //Console.ReadLine();
            //var scanResult = Manage.MD5Scan(loc);
        }
        static void ChangeConsole(string body, bool back=false, string mess = "")
        {
            Console.Clear();
            Console.Write(txtHeader);
            Console.Write(body);
            if (back)
                Console.Write(txtBack);
            Console.Write(mess);
        }
        static void ScanFileState()
        {
            var fileMess = "Nhap duong dan den file: ";
            ChangeConsole("", true, fileMess);
            var strPath = Console.ReadLine();
            if (strPath == "0")
                MainState();
            else
                //Console.WriteLine(strPath);
                ScanFile(strPath);
        }
        static void MainState()
        {
            ChangeConsole(txtMain, false, txtMess);
            var key = Console.ReadKey();
            if (key.KeyChar == '1')
            {
                ScanFileState();
            }

            if (key.KeyChar == '2')
            {
                ScanFolderState();
            }
            if (key.KeyChar == '3')
            {
                Console.WriteLine("Luachon3");
            }
            if (key.KeyChar == '4')
            {
                Console.WriteLine("Luachon4");
            }
            if (key.KeyChar == '0')
            {
                return;
            }
        }
        static void ScanFile(string loc)
        {
            if (File.Exists(loc))
            {
                var scanResult = Manage.MD5Scan(loc);
                if (scanResult.IsEmpty)
                {
                    Console.Write("File sach");
                }
                else
                {
                 Console.Write(
                        @"File nhiễm mã độc!\nMã độc: " + scanResult.VirusName +
                        "\nBạn có muốn xóa mã độc này không?(y/n) ");
                var key = Console.ReadKey();
                    if (key.KeyChar!='n')
                    {
                        Console.Write("\nDa xoa");
                    }
                key = Console.ReadKey();
                if (key.KeyChar == '0')
                        MainState();
                    else
                        ScanFileState();
                    //if (dr == DialogResult.Yes)
                    //    try
                    //    {
                    //        File.Delete(loc);
                    //    }
                    //    catch
                    //    {
                    //    }
                }
            }
            else
            {
                Console.WriteLine(
                        @"Sai duong dan hoac file khong ton tai! ");
                Console.Write(
                        @"An phim bat ky de nhap lai ");
                var key = Console.ReadKey();
                if (key.KeyChar == '0')
                    MainState();                
                else
                    ScanFileState();
            }
        }
        static void ScanFolderState()
        {
            var fileMess = "Nhap duong dan den folder: ";
            ChangeConsole("", true, fileMess);
            var strPath = Console.ReadLine();
            if (strPath == "0")
                MainState();
            else
                Console.WriteLine(strPath);
            //ScanFile(strPath);
        }
        static void ScanFolder(string loc)
        {
            var files = GetFiles(loc, "*.*", SearchOption.AllDirectories);
            int total = files.Length;
            string[] lst_Dynamic = new string[total];
            int count_Dynamic = 0;

            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    FileInfo fi = new FileInfo(file);
                    try
                    {
                        string find = Path.GetExtension(file);
                        //if (sw_macro.Value && Array.Exists(doc_ext, x => x == find))
                        //{
                        //    ScanDoc(file);
                        //};
                        //lb_LocationFileScan.Text = Path.GetFileName(file);
                        var res = Manage.MD5Scan(file);

                        if (!res.IsEmpty)
                        {
                            //infected++;
                            //Invoke(new Action(() =>
                            //{
                            //    lb_CountVirus.Text = infected.ToString();
                            //}));
                            //QUARANTINES quarantine = new QUARANTINES(file, res.VirusName, "Tĩnh", date);
                            //Provider.list_NewQuarantines.Add(quarantine);
                        }
                        else
                        {
                            //lst_Dynamic[count_Dynamic++] = file;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
