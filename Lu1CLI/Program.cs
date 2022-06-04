using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using BinarySearch;
namespace mtaAVCLI
{
    class Program
    {
        #region Init
        public static string tempPath = "Temp";
        public static string resultFolderPath = "";
        public static int countDoc = 0;
        public static string logFilePath = "resultScan.txt";
        static private string[] doc_ext = { ".docm", ".doc", ".xls", ".xlsm", ".ppt", ".pptm" };
        static bool stt = false;
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
        static string txtMess = @"
            Lua chon: ";
        #endregion

        #region SupportFunctions
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
        static void ChangeConsole(string body, bool back = false, string mess = "")
        {
            Console.Clear();
            Console.Write(txtHeader);
            Console.Write(body);
            if (back)
                Console.Write(txtBack);
            Console.Write(mess);
            stt = true;
        }
        static char GetKey()
        {
            var key = Console.ReadKey();
            return key.KeyChar;
        }

        #endregion

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            resultFolderPath = "Result " + DateTime.Now.ToString("ddMMyyyy_HHmmss", CultureInfo.InvariantCulture);
            Directory.CreateDirectory(resultFolderPath);
            logFilePath = resultFolderPath + "\\" + logFilePath;
            bool stop = false;
            while (!stop)
            {
                //if (!stt)
                //{
                //    MainState();
                //}
                MainState();
                var key = GetKey();
                stop = (key == '0');
                if (key == '1')
                {
                    ScanFileState();
                }                
                if (key == '2')
                {
                    ScanFolderState();
                }
                if (key == '3')
                {
                    ScanMarcoState();
                }
                if (key == '4')
                {
                    RaSoatState();
                }
                if (key == '5')
                {
                    UpdateDBState();
                }
            }
        }

        #region State
        static void MainState()
        {            
            ChangeConsole(txtMain, false, txtMess);
        }
        static void ScanFileState()
        {
            var fileMess = "Nhap duong dan den file: ";
            ChangeConsole("", true, fileMess);
            var strPath = Console.ReadLine();
            if (strPath == "0")
                MainState();
            else
                ScanFile(strPath);
        }
       
        static void ScanFolderState()
        {
            var fileMess = "Nhap duong dan den folder: ";
            ChangeConsole("", true, fileMess);
            var strPath = Console.ReadLine();
            if (strPath == "0")
                MainState();
            else
                //Console.WriteLine(strPath);
                ScanFolder(strPath);
        }
        static void ScanMarcoState()
        {
            var fileMess = "Nhap duong dan den file/folder: ";
            ChangeConsole("", true, fileMess);
            var strPath = Console.ReadLine();
            if (strPath == "0")
                MainState();
            else
                ScanMarco(strPath);
        }
        static void RaSoatState()
        {
            var fileMess = @"Nhap duong dan den file 'rasoat.bat' : ";
            ChangeConsole("", true, fileMess);
            var strPath = Console.ReadLine();
            if (strPath == "0")
                MainState();
            else
                RunRaSoat(strPath);
        }
        
        static void UpdateDBState()
        {

        }
        #endregion

        #region Functions
        static void ScanFile(string loc)
        {
            if (File.Exists(loc))
            {
                var scanResult = Manage.MD5Scan(loc);
                if (scanResult.IsEmpty)
                {
                    Console.Write("File sach! An phim bat ky de tiep tuc.");
                    if (GetKey() == '0')
                        MainState();
                    else
                        ScanFileState();
                }
                else
                {
                    Console.Write(
                            @"File nhiễm mã độc!\nMã độc: " + scanResult.VirusName +
                            "\nBạn có muốn xóa mã độc này không?(y/n) ");
                    var virusPath = loc;
                    var time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    var resultTxt = time + " | " + virusPath + " | " + scanResult.VirusName;
                    File.AppendAllText(logFilePath, resultTxt + Environment.NewLine);
                    if (GetKey()!= 'n')
                    {
                        File.Delete(virusPath);
                        Console.Write("\nDa xoa\n");
                    }
                    if (GetKey() == '0')
                        MainState();
                    else
                        ScanFileState();                    
                }
            }
            else
            {
                Console.WriteLine(
                        @"Sai duong dan hoac file khong ton tai! ");
                Console.Write(
                        @"An phim bat ky de nhap lai ");
                if (GetKey() == '0')
                    MainState();                
                else
                    ScanFileState();
            }
        }
        static void ScanFolder(string loc)
        {
            var files = GetFiles(loc, "*.*", SearchOption.AllDirectories);
            if (files.Length==0)
            {
                Console.WriteLine(
                        @"Sai duong dan hoac folder khong ton tai! ");
                Console.Write(
                        @"An phim bat ky de nhap lai ");
                var key = Console.ReadKey();
                if (key.KeyChar == '0')
                    MainState();
                else
                    ScanFolderState();
            }
            else
            {
                int total = files.Length;
                string[] lst_Dynamic = new string[total];

                foreach (string file in files)
                {
                    if (File.Exists(file))
                    {
                        FileInfo fi = new FileInfo(file);
                        try
                        {
                            string find = Path.GetExtension(file);
                            var scanResult = Manage.MD5Scan(file);

                            if (!scanResult.IsEmpty)
                            {
                                var virusPath = file;
                                var time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                                var resultTxt = time + " | " + virusPath + " | " + scanResult.VirusName;
                                File.AppendAllText(logFilePath, resultTxt + Environment.NewLine);
                                Console.Write(
                                @"File " + file +" nhiễm mã độc!\nMã độc: " + scanResult.VirusName +
                                "\n Bạn có muốn xóa mã độc này không?(y/n)");
                                if (GetKey() != 'n')
                                {
                                    File.Delete(virusPath);
                                    Console.Write("\nDa xoa\n");
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                if (GetKey() == '0')
                    MainState();
                else
                    ScanFolderState();
            }
        }
        static void ScanMarco(string loc)
        {
            int countMacro = 0;
            if (File.Exists(loc))
            {
                countMacro = ScanDoc(loc);
                if(countMacro == 0)
                {
                    Console.WriteLine("Không tìm thấy Macro trong tài liệu!");
                }
                GetKey();
                ScanMarcoState();                
            }
            else
            {
                var files = GetFiles(loc, "*.*", SearchOption.AllDirectories);
                if (files.Length == 0)
                {
                    Console.WriteLine(
                            @"Sai duong dan file hoac folder khong ton tai! ");
                    Console.Write(
                            @"An phim bat ky de nhap lai ");
                    var key = Console.ReadKey();
                    if (key.KeyChar == '0')
                        MainState();
                    else
                        ScanMarcoState();
                }
                else
                {
                    int total = files.Length;
                    string[] lst_Dynamic = new string[total];

                    foreach (string file in files)
                    {
                        if (File.Exists(file))
                        {
                            FileInfo fi = new FileInfo(file);
                            try
                            {
                                string find = Path.GetExtension(file);
                                if (Array.Exists(doc_ext, x => x == find))
                                {
                                    countMacro += ScanDoc(file);
                                };
                                if(countMacro == 0)
                                {
                                    Console.WriteLine("Không tìm thấy Macro trong tài liệu!");
                                }

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }
                    if (GetKey() == '0')
                        MainState();
                    else
                        ScanMarcoState();
                }
            }
   
        }
        static private int ScanDoc(string path)
        {
            Detail_Macro tmp = new Detail_Macro();
            File_Macro item = new File_Macro();
            Suspecious sp = new Suspecious();
            List<string> List_Macro = tmp.Check_Macro(path);
            if (List_Macro.Count > 0)
            {
                string codeMacro = tmp.Split_Macro(List_Macro);
                sp = tmp.Check_Suspecious(List_Macro);
                item = new File_Macro(countDoc, path);
                tmp = new Detail_Macro(countDoc, codeMacro, sp);
                Console.Write("Phat hien macro trong file: "+path+"\n");
                var macroLogFile = resultFolderPath + "\\"+ path.Split('\\').Last() + "_macro.txt";
                var txtlog = codeMacro + "\n"+"------------"+"\n";
                txtlog = txtlog + "Document_Open : " + tmp.Suspecious_Patterns.Document_Open.ToString() + "\n";
                txtlog = txtlog + "Auto_Open : " + tmp.Suspecious_Patterns.Auto_Open.ToString() + "\n";
                txtlog = txtlog + "Http_Request :" + tmp.Suspecious_Patterns.Http_Request.ToString() + "\n";
                txtlog = txtlog + "Url_Detected : " + tmp.Suspecious_Patterns.Url_Detected.ToString() + "\n";
                txtlog = txtlog + "Shell_Function : " + tmp.Suspecious_Patterns.Shell_Func.ToString() + "\n";
                txtlog = txtlog + "Char_Encoding : " + tmp.Suspecious_Patterns.Char_Encoding.ToString() + "\n";
                txtlog = txtlog + "Base64 : " + tmp.Suspecious_Patterns.Base64.ToString() + "\n";
                txtlog = txtlog + "String_Concat : " + tmp.Suspecious_Patterns.String_Concat.ToString() + "\n";
                txtlog = txtlog + "IP_Adrress : " + tmp.Suspecious_Patterns.IP_Adrr.ToString() + "\n";
                txtlog = txtlog + "PosBackdoor : " + tmp.Suspecious_Patterns.PosBackdoor.ToString() + "\n";

                File.AppendAllText(macroLogFile, txtlog + Environment.NewLine);
                return 1;
            }
            return 0;
        }
        static void RunRaSoat(string path)
        {
            if (File.Exists(path))
            {
                System.Diagnostics.Process.Start(path);
            }
            else
            {
                Console.WriteLine(
                        @"Sai duong dan hoac file khong ton tai! ");
                Console.Write(
                        @"An phim bat ky de nhap lai ");
                if (GetKey() == '0')
                    MainState();
                else
                    RaSoatState();
            }
        }
        static void Update_DB()
        {

        }
        #endregion
    }
}
