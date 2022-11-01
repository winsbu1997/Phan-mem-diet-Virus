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
            string DllPath = string.Format("{0}\\db\\", runningPath);
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

        private static HashScanner InitDb_Sha256()
        {
            string runningPath = AppDomain.CurrentDomain.BaseDirectory;
            string DllPath = string.Format("{0}\\db\\", runningPath);
            List<string> lst = new List<string>();
            lst.Add(DllPath + "SHA256_01");
            lst.Add(DllPath + "SHA256_23");
            lst.Add(DllPath + "SHA256_45");
            lst.Add(DllPath + "SHA256_67");
            lst.Add(DllPath + "SHA256_89");
            lst.Add(DllPath + "SHA256_AB");
            lst.Add(DllPath + "SHA256_CD");
            lst.Add(DllPath + "SHA256_EF");
            SHA256 sha256 = new SHA256();
            HashScanner SHA256Scanner = new HashScanner(sha256, lst);
            return SHA256Scanner;
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

        #region Update
        public static void UdpateDb_Md5(string path, string virusName = "")
        {
            HashScanner MD5Scanner = InitDb_Md5();
            MD5Scanner.Update(path, virusName);
        }
        public static void UdpateDb_Sha1(string path, string virusName = "")
        {
            HashScanner SHA1Scanner = InitDb_Sha1();
            SHA1Scanner.Update(path, virusName);
        }
        public static void UdpateDb_Sha256(string path, string virusName = "")
        {
            HashScanner SHA256Scanner = InitDb_Sha256();
            SHA256Scanner.Update(path, virusName);
        }
        #endregion

        #region Scan
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

        public static ResultScan SHA256Scan(string path)
        {
            HashScanner SHA256Scanner = InitDb_Sha256();
            return SHA256Scanner.Scan(path);
        }

        #endregion

        #region Decrypt
        public static void MD5Print()
        {
            HashScanner MD5Scanner = InitDb_Md5();
            MD5Scanner.PrintDB("MD5");
        }

        public static void SHA1Print()
        {
            HashScanner SHA1Scanner = InitDb_Sha1();
            SHA1Scanner.PrintDB("SHA1");
        }

        public static void SHA256Print()
        {
            HashScanner SHA256Scanner = InitDb_Sha256();
            SHA256Scanner.PrintDB("SHA256");
        }

        #endregion
    }
}
