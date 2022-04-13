using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearch.Entity;
using BinarySearch.Interface;
using BinarySearch.Lib;

namespace BinarySearch
{
    public class Manage
    {
        private static  HashScanner InitDb_Sha1()
        {
            string runningPath = AppDomain.CurrentDomain.BaseDirectory;
            string DllPath = string.Format("db\\");
            List<string> lst = new List<string>();
            lst.Add(DllPath + "SHA1_01");
            lst.Add(DllPath + "SHA1_23");
            lst.Add(DllPath + "SHA1_45");
            lst.Add(DllPath + "SHA1_67");
            lst.Add(DllPath + "SHA1_89");
            lst.Add(DllPath + "SHA1_AB");
            lst.Add(DllPath + "SHA1_CD");
            lst.Add(DllPath + "SHA1_EF");
            SHA1 sha1 = new SHA1();
            HashScanner SHA1Scanner = new HashScanner(sha1, lst);
            return SHA1Scanner;
        }
        private static HashScanner InitDb_Md5()
        {
            string runningPath = Directory.GetCurrentDirectory();
            string DllPath = string.Format("{0}\\db\\", runningPath);
            List<string> lst = new List<string>();
            lst.Add(DllPath + "MD5_01");
            lst.Add(DllPath + "MD5_23");
            lst.Add(DllPath + "MD5_45");
            lst.Add(DllPath + "MD5_67");
            lst.Add(DllPath + "MD5_89");
            lst.Add(DllPath + "MD5_AB");
            lst.Add(DllPath + "MD5_CD");
            lst.Add(DllPath + "MD5_EF");
            MD5 md5 = new MD5();
            HashScanner MD5Scanner = new HashScanner(md5, lst);
            return MD5Scanner;
        }
        public static void UdpateDb_Md5(string path)
        {
            HashScanner MD5Scanner = InitDb_Md5();
            MD5Scanner.Update(path);
        }
        public static void UdpateDb_Sha1(string path)
        {
            HashScanner SHA1Scanner = InitDb_Sha1();
            SHA1Scanner.Update(path);
        }
        public static ResultScan MD5Scan(string path)
        {
            HashScanner MD5Scanner = InitDb_Md5();
            return MD5Scanner.Scan(path);
        }

        public static ResultScan SHA1Scan(string path)
        {
            HashScanner SHA1Scanner = InitDb_Sha1();
            return SHA1Scanner.Scan(path);
        }
    }
}
