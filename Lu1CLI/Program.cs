using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Aspose.Zip;
using VerifyingFiles;
using BinarySearch;
using System.Diagnostics;
using Ionic.Zip;
using Aspose.Zip.Rar;

namespace mtaAVCLI
{
    class Program
    {
        #region Init
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
        private static string[] locationScan = { "%ALLUSERSPROFILE%", "%LOCALAPPDATA%", "%TEMP%", "%PUBLIC%", "C:\\ProgramData", System.IO.Path.GetTempPath() };
        public static string tempPath = "Temp";
        public static string resultFolderPath = "";
        public static string virusScanFolderPath = "Collection_virus";
        public static int countDoc = 0;
        private static bool check = false;
        static List<string> arrTypeHash = new List<string> {"tt", "MD5", "SHA1", "SHA256" };
        private static string[] smart_ext = {"exe" , "cpl", "reg", "ini", "bat", "com", "dll", "pif", "lnk", "scr", "vbs", "ocx", "drv", "sys"};
        public static string logFilePath = "resultScan.txt";
        public static string logFileSuspicious = "Suspicious.txt";
        static private string[] doc_ext = { ".docm", ".doc", ".xls", ".xlsm", ".ppt", ".pptm" };
        static readonly string txtHeader= @"
            ------------------------Chương trình diệt virus-------------------------            
            ";
        static readonly string txtMain= @"
            0. Thoát
            1. Quét file
            2. Quét folder
            3. Quét Marco
            4. Quét RaSoat
            5. Cập nhật CSDL
            6. Giải mã CSDL
            ";
        static readonly string txtUpdate = @"
            Chọn loại mã hash Update:
            1. MD5
            2. SHA1
            3. SHA256
            Lựa chọn: ";
        static readonly string txtOptionUpdate = @"
            Chọn kiểu Update:
            1. Kết nối tới máy chủ
            2. Cập nhật từ file
            3. Thu thập file thực thi
            Lựa chọn: ";
        static readonly string txtBack = @"
            0. Quay lại
            ";
        static string txtMess = @"
            Lựa chọn: ";
        #endregion

        #region SupportFunctions
        public static bool AllowScan(string file)
        {
            bool isAllowScan = false;
            FileInfo fi = new FileInfo(file);
            string ext = fi.Extension;

            if(ext == ".docx" || ext == ".xlsx" || doc_ext.Contains(ext))
            {        
                return false;
            }
            if (smart_ext.Contains(ext.ToLower()))
            {
                File.AppendAllText(logFileSuspicious, file + Environment.NewLine);
            }
            if (File.Exists(file) && file.Length <= 52428800)
            {
                if (FileTypeVerifier.What(file).Name.ToString() == "Exe" || FileTypeVerifier.What(file).Name.ToString() == "Rar" || FileTypeVerifier.What(file).Name.ToString() == "Zip") 
                {
                    isAllowScan = true; 
                }
            }
            return isAllowScan;
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
        public static void Empty(System.IO.DirectoryInfo directory)
        {
            foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
            foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
        }
        public static string[] GetFiles(string SourceFolder, string Filter = "*.*", System.IO.SearchOption searchOption = SearchOption.AllDirectories)
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
        }
        static char GetKey()
        {
            var key = Console.ReadKey();
            return key.KeyChar;
        }
        private static void ZipFolder(string path, string saveZipPath, string pass = "infected")
        {
            
            using (ZipFile zip = new ZipFile())
            {
                zip.Password = pass;
                string[] fileEntries = Directory.GetFiles(path);
                foreach (var file in fileEntries)
                {
                    zip.AddFile(file, virusScanFolderPath);
                }
                zip.Save(saveZipPath);
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
                    Directory.Delete(virusScanFolderPath, true);
                    Environment.Exit(0);
                    return false;

                default:
                    return false;
            }
        }
        static string unZip(string path, string type)
        {
            string folder = "Unzipped";
            if (Directory.Exists(folder))
            {
                Directory.Delete(folder, true);
            }
            Directory.CreateDirectory(folder);
            if (type == "Zip")
            {
                try
                {
                    
                    using (FileStream zipFile = File.Open(path, FileMode.Open))
                    {
                        using (var archive = new Archive(zipFile))
                        {
                            // Unzip files to folder
                            archive.ExtractToDirectory(folder);
                            archive.Dispose();
                        }
                    }
                }
                catch
                {
                    Console.WriteLine($"\nFile {path} không thể giải nén vì Không có quyền truy cập hoặc đang được sử dụng bởi tiến trình khác!");
                }
            }
            else if(type == "Rar")
            {
                try
                {
                    RarArchive archive = new RarArchive(path);
                    archive.ExtractToDirectory(folder);
                    archive.Dispose();
                }
                catch
                {
                   Console.WriteLine($"\nFile {path} không thể giải nén vì không có quyền truy cập hoặc đang được sử dụng bởi tiến trình khác!");
                }
            }
            else
            {
                return "0";
            }
            
            string result = ScanFolderZip(folder, path);
            try
            {
                System.IO.DirectoryInfo tmpDirectory = new System.IO.DirectoryInfo(folder);
                Empty(tmpDirectory);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                //{
                Console.WriteLine(e.Message);
            }
            return result;       
        }
        #endregion

        static void Main(string[] args)
        {
            // Register the handler
            SetConsoleCtrlHandler(Handler, true);
            Console.OutputEncoding = Encoding.UTF8;
            resultFolderPath = "Result " + DateTime.Now.ToString("ddMMyyyy_HHmmss", CultureInfo.InvariantCulture);
            Directory.CreateDirectory(resultFolderPath);
            logFilePath = Path.Combine(resultFolderPath, logFilePath);
            logFileSuspicious = Path.Combine(resultFolderPath, logFileSuspicious);
            virusScanFolderPath = Path.Combine(resultFolderPath, virusScanFolderPath);
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
                else if (key == '2')
                {
                    ScanFolderState();
                }
                else if (key == '3')
                {
                    ScanMarcoState();
                }
                else if (key == '4')
                {
                    RaSoatState();
                }
                else if (key == '5')
                {
                    UpdateDBState();
                    //UpdateDBStateInternet();
                }
                else if (key == '6')
                {
                    PrintDBState();
                    //UpdateDBStateInternet();
                }
                else
                {
                    MainState();
                }

            }
            ZipFolder(virusScanFolderPath, resultFolderPath + "\\" + "VirusDetected.zip");
            Directory.Delete(virusScanFolderPath, true);
        }

        #region State
        static void MainState()
        {            
            ChangeConsole(txtMain, false, txtMess);
            //string folder = "Unzipped";
            //if (Directory.Exists(folder))
            //{
            //    Directory.Delete(folder, true);
            //}
        }
        static void ScanFileState()
        {
            var fileMess = "Nhập đường dẫn đến file: ";
            ChangeConsole("", true, fileMess);
            var strPath = Console.ReadLine();
            if (strPath == "0")
                MainState();
            else
                ScanFile(strPath);
        }

        static void ScanFolderState()
        {
            var fileMess = "Nhập đường dẫn đến folder: ";
            ChangeConsole("", true, fileMess);
            string strPath = Console.ReadLine();
            if (strPath == "0")
                MainState();
                
            else {
                //Console.WriteLine(strPath);
                //SplitFolder(@"J:\Lu1\Windows\Tools_KT_ATTT_new\programdata.txt");
                ScanFolder(strPath);
                Console.Write("\nĐã quét xong!!");

                if (GetKey() == '0')
                    MainState();
                else
                    ScanFolderState();
            }
        }
        static void ScanMarcoState()
        {
            var fileMess = "Nhập đường dẫn đến file/folder: ";
            ChangeConsole("", true, fileMess);
            var strPath = Console.ReadLine();
            if (strPath == "0")
                MainState();
            else
                ScanMarco(strPath);
        }
        static void RaSoatState()
        {
            var fileMess = @"Nhập đường dẫn thư mục chứa file 'rasoat.bat' : ";
            ChangeConsole("Chạy Rasoat", true, fileMess);
            var strPath = Console.ReadLine();
            if (strPath == "0")
                MainState();
            else
                RunRaSoat(strPath);
        }
        static void UpdateDBState()
        {
            ChangeConsole("", true, txtOptionUpdate); 
             var strHash = Console.ReadLine();
            if(strHash != "1" && strHash != "2" && strHash != "3")
            {
                MainState();
                return;
            }
            int indexArr = Convert.ToInt32(strHash.ToString());
            int res = OptionUpdate(strHash.ToString());//arrTypeHash[indexArr]);
            if(res == 0) Console.WriteLine("Đã cập nhật thành công! Nhấn phím bất kì để thoát!");
           
            UpdateDBState();
        }

        static void PrintDBState() 
        {
            ChangeConsole("", true, txtUpdate);
            var hash = Console.ReadLine().ToString();
            if (hash != "1" && hash != "2" && hash != "3")
            {
                return;
            }
            Console.WriteLine("Đang tạo file giải mã!");
            switch (hash)
            {
                case "1":
                    Manage.MD5Print();
                    break;
                case "2":
                    Manage.SHA1Print();
                    break;
                case "3":
                    Manage.SHA256Print();
                    break;
                default:
                    MainState();
                    break;
            }
            Console.WriteLine("Giải mã thành công!");
            return;
        }

        static int OptionUpdate(string strOption)
        {
            ChangeConsole("", true, txtUpdate);
            var hash = Console.ReadLine().ToString();
            if (hash != "1" && hash != "2" && hash != "3")
            {
                return 1;
            }
            switch (strOption)
            {
                case "1":
                    UpdateDBFromInternet(hash);
                    break;
                case "2":
                    UpdateDBFromFile(hash);
                    break;
                case "3":
                    UpdateDBFromHash(hash);
                    break;
                default:
                    MainState();
                    break;
            }
            return 0;
        }
        
        static void UpdateDBFromFile(string hash)
        {
            ChangeConsole("", true, "Nhập đường dẫn file chứa danh sách mã băm: ");
            string path = Console.ReadLine();
            if (File.Exists(path))
            {
                //int indexArr = arrTypeHash.IndexOf(hash);
                Update_DB(path, hash);
            }
            else
            {
                Console.WriteLine(
                        "\nSai đường dẫn hoặc file không tồn tại!! ");
                Console.Write(
                        "\nẤn phím bất kỳ để nhập lại! Hoặc nhập phím 0 để về màn hình chính!");
                if (GetKey() == '0')
                    MainState();
                else
                    UpdateDBState();
            }
        }
        static void UpdateDBFromHash(string hash)
        {
            ChangeConsole("", true, "Nhập đường dẫn file để băm và lưu vào CSDL: ");
            string path = Console.ReadLine();
            if (File.Exists(path))
            {
                //int indexArr = arrTypeHash.IndexOf(hash);
                
                ChangeConsole("", true, "Nhập  loại Malware APT: ");
                string virusName = Console.ReadLine();
                Update_DB_hash(path, hash, virusName);
            }
            else
            {
                Console.WriteLine(
                        "\nSai đường dẫn hoặc file không tồn tại!! ");
                Console.Write(
                        "\nẤn phím bất kỳ để nhập lại! Hoặc nhập phím 0 để về màn hình chính!");
                if (GetKey() == '0')
                    MainState();
                else
                    UpdateDBState();
            }
        }
        static void UpdateDBFromInternet(string hash)
        {
            APIConnect api = new APIConnect();
            string path = api.Download_FileHash(hash);
            //int indexArr = arrTypeHash.IndexOf(hash);
            Update_DB(path, hash);            
        }
        #endregion

        #region Functions
        static void ScanFile(string loc)
        {
            if (File.Exists(loc) && AllowScan(loc))
            {
                Console.Write("\n Nhập đường dẫn đúng để tiếp tục!");
                var scanResult = Manage.MD5Scan(loc);
                if (scanResult.IsEmpty)
                {
                    scanResult = Manage.SHA1Scan(loc);
                }
                if (scanResult.IsEmpty)
                {
                    scanResult = Manage.SHA256Scan(loc);
                }
                if (scanResult.IsEmpty)
                {
                    Console.Write("\nFile sach! Ấn phím bất kỳ để tiếp tục.");
                    if (GetKey() == '0')
                        MainState();
                    else
                        ScanFileState();
                }
                else
                {
                    var virusPath = loc;
                    var time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    var resultTxt = time + " | " + virusPath + " | " + scanResult.VirusName;
                    File.AppendAllText(logFilePath, resultTxt + Environment.NewLine);
                    File.Copy(virusPath, virusScanFolderPath + "\\" + scanResult.VirusName, true);
                    Console.Write(
                            "\nFile nhiễm mã độc!\nMã độc: " + scanResult.VirusName +
                            "\nBạn có muốn xóa mã độc này không?(y/n) ");
                    
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
                        "\nSai đường dẫn hoặc không phải file thực thi!! ");
                Console.Write(
                        "\nẤn phím bất kỳ để nhập lại ");
                if (GetKey() == '0')
                    MainState();                
                else
                    ScanFileState();
            }
        }
        static string ScanFolderZip(string loc, string note)
        {
            int count = 0;
            var files = GetFiles(loc, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                if (AllowScan(file))
                {
                    string checkFileType = FileTypeVerifier.What(file).Name;
                    if (checkFileType == "Rar" || checkFileType == "Zip")
                    {
                        try
                        {
                            count += Convert.ToInt32(unZip(file, checkFileType));
                        }
                        catch
                        {
                            Console.WriteLine("Giải nén file bị lỗi!");
                        }

                    }
                    else
                    {
                        FileInfo fi = new FileInfo(file);
                        try
                        {
                            var scanResult = Manage.MD5Scan(file);
                            if (scanResult.IsEmpty)
                            {
                                scanResult = Manage.SHA1Scan(file);
                            }
                            if (scanResult.IsEmpty)
                            {
                                scanResult = Manage.SHA256Scan(file);
                            }
                            if (!scanResult.IsEmpty)
                            {
                                count++;
                                var virusPath = file;
                                File.Copy(virusPath, virusScanFolderPath + "\\" + scanResult.VirusName, true);

                                var time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                                var resultTxt = time + " | " + virusPath + " | " + scanResult.VirusName;
                                if (note != "")
                                {
                                    resultTxt += " | File Zip: " + note;
                                }

                                File.AppendAllText(logFilePath, resultTxt + Environment.NewLine);

                                Console.Write(
                                "\nFile nén có đường dẫn " + note + ": chứa file" + Path.GetFileName(file) + " nhiễm mã độc " + scanResult.VirusName + "\n");

                                
                            }
                        }
                        catch
                        {
                            //Console.WriteLine(e.Message);
                        }
                    }
                }
            }
            return count.ToString();
        }

        static string ScanFolder(string loc, string filter = "*.*", string note="")
        {
            Console.WriteLine("Đang quét thư mục: " + loc);
            int count = 0;

            var files = GetFiles(loc, filter, SearchOption.AllDirectories);
            if (files.Length==0 && note == "")
            {
                Console.WriteLine(
                        "\nSai đường dẫn file hoặc folder không tồn tại!! ");
                Console.Write(
                        @"Ấn phím bất kỳ để nhập lại ");
                //var key = Console.ReadKey();
                //if (key.KeyChar == '0')
                //    MainState();
                //else
                //    ScanFolderState();
            }
            else
            { 
                foreach (string file in files)
                {
                    if (AllowScan(file))
                    {
                        string checkFileType = FileTypeVerifier.What(file).Name;
                        if(checkFileType == "Rar" || checkFileType == "Zip")
                        {
                            try
                            {
                                count += Convert.ToInt32(unZip(file, checkFileType));
                            }
                            catch
                            {
                                Console.WriteLine($"Giải nén file {file} bị lỗi!");
                            }
                            
                        }
                        else
                        {
                            FileInfo fi = new FileInfo(file);
                            try
                            {
                                var scanResult = Manage.MD5Scan(file);
                                if (scanResult.IsEmpty)
                                {
                                    scanResult = Manage.SHA1Scan(file);
                                }
                                if (scanResult.IsEmpty)
                                {
                                    scanResult = Manage.SHA256Scan(file);
                                }
                                if (!scanResult.IsEmpty)
                                {
                                    File.Copy(file, virusScanFolderPath + "\\" + scanResult.VirusName, true);
                                    count++;
                                    var virusPath = file;
                                    var time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                                    var resultTxt = time + " | " + virusPath + " | " + scanResult.VirusName;

                                    if (note!= "")
                                    {
                                        resultTxt += " | File Zip: " + note;
                                    }
                                    File.AppendAllText(logFilePath, resultTxt + Environment.NewLine);
              

                                    if (note != "")
                                    {
                                        
                                    }
                                    else
                                    {
                                        Console.Write(
                                    "\nFile " + file + " nhiễm mã độc " + scanResult.VirusName +
                                    "\n Bạn có muốn xóa mã độc này không?(y/n)");
                                        if (GetKey() != 'n')
                                        {
                                            File.Delete(virusPath);
                                            Console.Write("\nĐã xóa\n");
                                        }
                                    }
                                }
                            }
                            catch
                            {
                                //Console.WriteLine(e.Message);
                            }
                        }          
                    }
                }
            }

            return count.ToString();
        }
        static void ScanMarco(string loc)
        {
            int countMacro = 0;
            if (File.Exists(loc))
            {
                countMacro = ScanDoc(loc);
                if(countMacro == 0)
                {
                    Console.WriteLine("\t\t\t Không tìm thấy Macro trong tài liệu!");
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
                            "\nSai đường dẫn file hoặc folder không tồn tại!! ");
                    Console.Write(
                            @"Ấn phím bất kỳ để nhập lại ");
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

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }
                    if (countMacro == 0)
                    {
                        Console.WriteLine("\t\t\t Không tìm thấy Macro trong tài liệu!");
                        //Console.ReadKey();
                    }
                    Console.WriteLine("Đã quét xong!");
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
                Console.Write("Phát hiện macro trong file: "+path+"\n");
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
            if (Directory.Exists(path))
            {
                System.Diagnostics.Process.Start(Path.Combine(path, "rasoat.bat")).WaitForExit();
                AlterRaSoatScan(path);
            }
            else
            {
                Console.WriteLine(
                        "\nSai đường dẫn hoặc file không tồn tại!! ");
            }
            Console.Write(
                        @"Ấn phím bất kỳ để thoát! ");
            
        }
        public static void ScanLstRaSoat(string[] lst, string nameScan)
        {
            Console.WriteLine("Quét thư mục: " + nameScan);
            int count = 0;
            for (int i = 0; i < lst.Length; i += 3)
            {
                string file = lst[i];
                Console.WriteLine("Quét file: " + file);
                if (file != "" && File.Exists(file) && file.Length <= 52428800 && AllowScan(file))
                {
                    var scanResult = Manage.MD5Scan(file);
                    if (scanResult.IsEmpty)
                    {
                        scanResult = Manage.SHA1Scan(file);
                    }
                    if (scanResult.IsEmpty)
                    {
                        scanResult = Manage.SHA256Scan(file);
                    }
                    if (!scanResult.IsEmpty)
                    {
                        count++;
                        var virusPath = file;
                        var time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        var resultTxt = time + " | " + virusPath + " | " + scanResult.VirusName;
                        File.AppendAllText(logFilePath, resultTxt + Environment.NewLine);
                        Console.Write(
                        "\nFile " + virusPath + " nhiễm mã độc!\nMã độc: " + scanResult.VirusName +
                        "\n Bạn có muốn xóa mã độc này không?(y/n)");
                        if (GetKey() != 'n')
                        {
                            File.Delete(virusPath);
                            Console.Write("\nDa xoa\n");
                        }
                    }
                }
            }
            Console.WriteLine("Tổng số file chứa mã độc= " + count.ToString());
        }
        static void SplitFolder(string path)
        {
            if (!File.Exists(path)) { return; }
            ArrayList locs = new ArrayList();
            foreach (string line in File.ReadAllLines(path))
            {
                string folder = @"C:\ProgramData\" + line;
                Console.WriteLine(folder);
                try
                {
                    int kq = Convert.ToInt32(ScanFolder(folder, "*.*", "not"));
                    if (kq == 0)
                    {
                        Console.WriteLine("Thư mục " + folder + " không phát hiện virus!");
                    }
                }
                catch { }

            }
            Console.WriteLine("Đã quét xong! Ấn phím bất kì!");
            if (GetKey() == '0')
                MainState();
            else
                RaSoatState();
        }
        private static void AlterRaSoatScan(string loc)
        {
            Console.Write("\nKiểm tra nghi vấn sau rà soát...");
            string unverifiedPath = Path.Combine(loc, "unverify_dll.txt");
            string [] lstDllUnverify = File.ReadAllLines(unverifiedPath);

            ScanLstRaSoat(lstDllUnverify, "unverify_dll.txt");

            foreach (string item in locationScan)
            {
                string location = Environment.ExpandEnvironmentVariables(item);
                try
                {
                    int kq = Convert.ToInt32(ScanFolder(location, "*.*", "test"));
                    if (kq == 0)
                    {
                        Console.WriteLine("\nThư mục " + location + " không phát hiện virus!");
                    }
                }
                catch { }
            }
            SplitFolder(Path.Combine(loc, "programdata.txt"));
        }

        static void Update_DB(string path, string indexHash, string virusName = "")
        {
            Console.WriteLine("Đang Cập nhật CSDL!");
            if (path.Contains(".txt"))
            {
                switch (indexHash)
                {
                    case "1":
                        Manage.UdpateDb_Md5(path, virusName);
                        break;
                    case "2":
                        Manage.UdpateDb_Sha1(path, virusName);
                        break;
                    case "3":
                        Manage.UdpateDb_Sha256(path, virusName);
                        break;
                }
            }
            else
            {
                Console.Write(path);
            }
        }

        static void Update_DB_hash(string path, string indexHash, string virusName = "")
        {
            Console.WriteLine("Đang Cập nhật CSDL!");

            switch (indexHash)
            {
                case "1":
                    Manage.UdpateDb_Md5(path, virusName);
                    break;
                case "2":
                    Manage.UdpateDb_Sha1(path, virusName);
                    break;
                case "3":
                    Manage.UdpateDb_Sha256(path, virusName);
                    break;
            }
           
        }
        #endregion
    }
}
