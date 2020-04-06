using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Ladin.mtaAV.Manager
{
    public class File_Macro
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public File_Macro() { }
        public File_Macro(int ID, string FileName)
        {
            this.ID = ID;
            this.FileName = FileName;
        }
    }
    public class Detail_Macro
    {
        public int ID { get; set; }
        public string Macro_Code { get; set; }
        public Suspecious Suspecious_Patterns { get; set; }
        public Detail_Macro() { }
        public Detail_Macro(int ID,string Macro_Code, Suspecious Suspecious_Patterns)
        {
            this.ID = ID;
            this.Macro_Code = Macro_Code;
            this.Suspecious_Patterns = Suspecious_Patterns;
        }
        public string Split_Macro(List<string> list)
        {
            string macro = "";
            foreach (string item in list)
            {
                macro += item;
                macro += "                                                                                             ";
            }
            return macro;
        }
        public List<string> Check_Macro(string path)
        {
            List<string> s1 = new List<string>();
            try
            {
                using (PowerShell powerShell = PowerShell.Create())
                {
                    string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
                    string Extract_Macro = string.Format("{0}Resources\\Extract-Macro.ps1", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
                    powerShell.AddScript(System.IO.File.ReadAllText(Extract_Macro));
                    powerShell.AddParameter("file", path);
                    Collection<PSObject> PSOutput = powerShell.Invoke();
                    foreach (PSObject pSObject in PSOutput)
                    {
                        s1.Add(pSObject.ToString());
                    }
                    return s1;
                }
            }
            catch { return null; }
        }
        public Suspecious Check_Suspecious(List<string> macro)
        {
            int[] value = new int[12];
            for (int i = 1; i <= 10; i++)
            {
                value[i] = 0;
            }
            foreach (string item in macro)
            {
                using (PowerShell powerShell = PowerShell.Create())
                {
                    string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
                    //H:\Ngiencuukhoahoc\CookuSandBox\Unpack_macro\Unpack_macro\Resources\Extract-Macro.ps1
                    string Check_Macro = string.Format("{0}Resources\\Check-Macro.ps1", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
                    powerShell.AddScript(System.IO.File.ReadAllText(Check_Macro));
                    powerShell.AddParameter("vba", item);
                    powerShell.AddCommand("Format-Table");
                    powerShell.AddCommand("Out-String");
                    Collection<PSObject> PSOutput = powerShell.Invoke();
                    foreach (PSObject pSObject in PSOutput)
                    {
                        string data = pSObject.ToString();
                        data = data.Trim();
                        string[] row = data.Split('\n');
                        for (int i = 2; i < row.Length; i++)
                        {
                            row[i] = row[i].Trim();
                            while (row[i].Contains("  ")) //2 khoảng trắng
                            {
                                row[i] = row[i].Replace("  ", " "); //Replace 2 khoảng trắng thành 1 khoảng trắng
                            }
                            string[] kq = row[i].Split(' ');
                            value[Convert.ToInt32(kq[0])] += Convert.ToInt32(kq[1]);
                        }
                    }
                }
            }
            Suspecious sp = new Suspecious(value[1], value[2], value[3], value[4], value[5], value[6], value[7], value[8], value[9], value[10]);
            return sp;
        }

    }
    public class Suspecious
    {
        public int? PosBackdoor { get; set; }
        public int? Document_Open { get; set; }
        public int? Auto_Open { get; set; }
        public int? Http_Request { get; set; }
        public int? Url_Detected { get; set; }
        public int? Shell_Func { get; set; }
        public int? Char_Encoding { get; set; }
        public int? Base64 { get; set; }
        public int? String_Concat { get; set; }
        public int? IP_Adrr { get; set; }
        public Suspecious() { }
        public Suspecious(int? PosBackdoor, int? Document_Open, int? Auto_Open, int? Http_Request, int? Url_Detected, int? Shell_Func, int? Char_Encoding, int? Base64, int? String_Concat, int? IP_Adrr)
        {
            this.PosBackdoor = PosBackdoor;
            this.Document_Open = Document_Open;
            this.Auto_Open = Auto_Open;
            this.Http_Request = Http_Request;
            this.Url_Detected = Url_Detected;
            this.Shell_Func = Shell_Func;
            this.Char_Encoding = Char_Encoding;
            this.Base64 = Base64;
            this.String_Concat = String_Concat;
            this.IP_Adrr = IP_Adrr;
        }
    }
}
