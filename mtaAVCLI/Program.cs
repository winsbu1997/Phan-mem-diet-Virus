using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using BinarySearch;
using Ionic.Zip;
using SevenZipExtractor;

namespace mtaAVCLI
{
    class Program
    {
        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(SetConsoleCtrlEventHandler handler, bool add);

        // https://docs.microsoft.com/en-us/windows/console/handlerroutine?WT.mc_id=DT-MVP-5003978
        private delegate bool SetConsoleCtrlEventHandler(CtrlType sig);

        private enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        public static string resultFolderPath = "";
        public static int countDoc = 0;
        public static string logFilePath = "resultScan.txt";
        public static string virusScanFolderPath = "virus";
        private static string smart_ext = "*.exe|*.cpl|*.reg|*.ini|*.bat|*.com|*.dll|*.pif|*.lnk|*.scr|*.vbs|*.ocx|*.drv|*.sys";
        static private string[] doc_ext = { ".docm", ".doc", ".xls", ".xlsm", ".ppt", ".pptm" };
        static bool stt = false;
        static readonly string txtHeader = @"
            ------------------------Chuong trinh quet virus-------------------------            
            ";
        static readonly string txtMain = @"
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
        public static void ExtractFile()
        {

            using (ArchiveFile archiveFile = new ArchiveFile(@"D:\Desktop\RaSoat.zip"))
            {
                foreach (Entry entry in archiveFile.Entries)
                {
                    Console.WriteLine(entry.FileName);

                    // extract to file
                    entry.Extract(entry.FileName);

                    // extract to stream
                    MemoryStream memoryStream = new MemoryStream();
                    entry.Extract(memoryStream);
                }
            }
        }
        private static bool Handler(CtrlType signal)
        {
            switch (signal)
            {
                case CtrlType.CTRL_BREAK_EVENT:
                case CtrlType.CTRL_C_EVENT:
                case CtrlType.CTRL_LOGOFF_EVENT:
                case CtrlType.CTRL_SHUTDOWN_EVENT:
                case CtrlType.CTRL_CLOSE_EVENT:
                    ZipFolder(virusScanFolderPath, resultFolderPath + "\\" + "VirusDetected.zip");
                    Directory.Delete(virusScanFolderPath,true);
                    Environment.Exit(0);
                    return false;

                default:
                    return false;
            }
        }
        static void Main(string[] args)
        {
            // Register the handler
            SetConsoleCtrlHandler(Handler, true);

            //Debug();
            Console.OutputEncoding = Encoding.UTF8;
            resultFolderPath = "Result " + DateTime.Now.ToString("ddMMyyyy_HHmmss", CultureInfo.InvariantCulture);
            Directory.CreateDirectory(resultFolderPath);
            logFilePath = resultFolderPath + "\\" + logFilePath;
            virusScanFolderPath = resultFolderPath + "\\" + virusScanFolderPath;
            Directory.CreateDirectory(virusScanFolderPath);
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
            }
            ZipFolder(virusScanFolderPath, resultFolderPath + "\\" + "VirusDetected.zip");
            Directory.Delete(virusScanFolderPath,true);
        }

        private static void ZipFolder(string path, string saveZipPath, string pass = "0000")
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.Password = pass;
                string[] fileEntries = Directory.GetFiles(path);
                foreach (var file in fileEntries)
                {
                    zip.AddFile(file, "virus");
                }
                zip.Save(saveZipPath);
            }
        }
        private static void Debug()
        {
            //ZipFolder(@"D:\Desktop\ignore_Virus\Test");
            //string tempFolder = Path.GetTempPath();
            //ScanFolder(tempFolder, smart_ext,false);
            //var programDataFolder = "C:\\ProgramData";
            //ScanFolder(programDataFolder, smart_ext, false);
            ////string result = Path.GetTempPath();

            //Console.WriteLine(result);
        }
        private static void ScanUnverifiedFiles(string txtPath)
        {
            //var txtPath = @"D:\Desktop\checkinject_unverified.txt";
            var lsLines = System.IO.File.ReadAllLines(txtPath);
            var lsPath = new string[lsLines.Length];
            for (int i = 0; i < lsLines.Length; i++)
            {
                var processStr = Regex.Match(lsLines[i], @" in process [0-9]*").Value;
                var tmp = lsLines[i].Replace(processStr, "").Replace("Unverify Dll: ", "");
                ScanFile(tmp, false);
                lsPath[i] = tmp;
            }
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
        static void MainState()
        {
            ChangeConsole(txtMain, false, txtMess);
        }
        static void ScanFileState()
        {
            var fileMess = "Nhap duong dan den file: ";
            ChangeConsole("Quet file", true, fileMess);
            var strPath = Console.ReadLine();
            if (strPath == "0")
                MainState();
            else
                ScanFile(strPath);
        }

        static void ScanFolderState()
        {
            var fileMess = "Nhap duong dan den folder: ";
            ChangeConsole("Quet folder", true, fileMess);
            var strPath = Console.ReadLine();
            if (strPath == "0")
                MainState();
            else
                ScanFolder(strPath);
        }
        static void ScanMarcoState()
        {
            var fileMess = "Nhap duong dan den file/folder: ";
            ChangeConsole("Quet Marco", true, fileMess);
            var strPath = Console.ReadLine();
            if (strPath == "0")
                MainState();
            else
                ScanMarco(strPath);
        }
        static void RaSoatState()
        {
            var fileMess = @"Nhap duong dan den file 'rasoat.bat' : ";
            ChangeConsole("Quet RaSoat", true, fileMess);
            var strPath = Console.ReadLine();
            if (strPath == "0")
                MainState();
            else
                RunRaSoat(strPath);
        }

        static void ScanFile(string loc, bool showMess = true)
        {
            if (File.Exists(loc))
            {
                var scanResult = Manage.MD5Scan(loc);
                if (scanResult.IsEmpty)
                {
                    if (showMess)
                    {
                        Console.Write("File sach! An phim bat ky de tiep tuc.");
                        if (GetKey() == '0')
                            MainState();
                        else
                            ScanFileState();
                    }
                }
                else
                {
                    if (showMess)
                    {
                        Console.Write(
                                @"File nhiễm mã độc!\nMã độc: " + scanResult.VirusName +
                                "\nBạn có muốn xóa mã độc này không?(y/n) ");
                    }
                    else
                    {
                        Console.Write(
                                @"File " + loc + "nhiễm mã độc!\nMã độc: " + scanResult.VirusName);
                    }
                    var virusPath = loc;
                    var time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    var resultTxt = time + " | " + virusPath + " | " + scanResult.VirusName;
                    File.AppendAllText(logFilePath, resultTxt + Environment.NewLine);
                    if (showMess)
                    {
                        if (GetKey() != 'n')
                        {
                            File.Copy(virusPath, virusScanFolderPath + "\\" + scanResult.VirusName, true);
                            File.Delete(virusPath);
                            Console.Write("\nDa xoa\n");
                        }
                        if (GetKey() == '0')
                            MainState();
                        else
                            ScanFileState();
                    }
                    else
                    {
                        File.Copy(virusPath, virusScanFolderPath + "\\" + scanResult.VirusName, true);
                        File.Delete(virusPath);
                    }
                }
            }
            else
            {
                if (showMess)
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
        }
        static void ScanFolder(string loc, string filtter = "*.*", bool showMess = true)
        {
            //if (sw_SmartScan.Value) files = Provider.GetFiles(loc_to_search, smart_ext, SearchOption.AllDirectories);
            var files = GetFiles(loc, filtter, SearchOption.AllDirectories);
            if (files.Length == 0)
            {
                if (showMess)
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

                                if (showMess)
                                {
                                    Console.Write(
                                    @"File " + file + " nhiễm mã độc!\nMã độc: " + scanResult.VirusName +
                                    "\n Bạn có muốn xóa mã độc này không?(y/n)");
                                    if (GetKey() != 'n')
                                    {
                                        File.Copy(virusPath, virusScanFolderPath + "\\" + scanResult.VirusName, true);
                                        File.Delete(virusPath);
                                        Console.Write("\nDa xoa\n");
                                    }
                                }
                                else
                                {
                                    Console.Write(
                                    @"File " + file + " nhiễm mã độc!\nMã độc: " + scanResult.VirusName +
                                    "\n");
                                    File.Copy(virusPath, virusScanFolderPath + "\\" + scanResult.VirusName, true);
                                    File.Delete(virusPath);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                if (showMess)
                {

                    if (GetKey() == '0')
                        MainState();
                    else
                        ScanFolderState();
                }
            }
        }
        static void ScanMarco(string loc)
        {
            if (File.Exists(loc))
            {
                ScanDoc(loc);
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
                                    ScanDoc(file);
                                };

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
        static private void ScanDoc(string path)
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
                Console.Write("Phat hien macro trong file: " + path + "\n");
                var macroLogFile = resultFolderPath + "\\" + path.Split('\\').Last() + "_macro.txt";
                var txtlog = codeMacro + "\n" + "------------" + "\n";
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
            }
        }
        static void RunRaSoat(string path)
        {
            if (File.Exists(path) && path.Contains("rasoat.bat"))
            {
                System.Diagnostics.Process.Start(path).WaitForExit();
                AlterRaSoatScan(path);
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

        private static void AlterRaSoatScan(string path)
        {
            Console.Write("\nKiem tra nghi van sau ra soat...");
            var logFolder = System.IO.File.ReadAllLines(path.Replace("rasoat.bat", "runInfo.txt"))[0].Replace("\"", "");
            var logPath = path.Replace("rasoat.bat", "");
            var unverifiedPath = logPath + logFolder + "\\" + "checkinject_unverified.txt";
            if (File.Exists(unverifiedPath))
            {
                Console.Write("\nQuet cac file nghi van :\n");
                ScanUnverifiedFiles(unverifiedPath);

            }
            Console.Write("\nQuet cac folder nghi van :\n");
            string tempFolder = Path.GetTempPath();
            ScanFolder(tempFolder, smart_ext, false);
            var programDataFolder = "C:\\ProgramData";
            ScanFolder(programDataFolder, smart_ext, false);
        }
    }
}
