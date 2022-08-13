using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static string[] GetFiles(string SourceFolder, string Filter = "*.*", System.IO.SearchOption searchOption = SearchOption.AllDirectories)
        {
            ArrayList alFiles = new ArrayList();
            if (!Directory.Exists(SourceFolder)) return (string[])alFiles.ToArray(typeof(string));
            string[] MultipleFilters = Filter.Split('|');

            
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

            return (string[])alFiles.ToArray(typeof(string));
        }
        static void SplitFolder(string path)
        {
            if (!File.Exists(path)) { return; }
            ArrayList loc = new ArrayList();
            foreach(string line in File.ReadAllLines(path))
            {
                string folder = @"C:\ProgramData\" + line;
                try
                {
                    loc.AddRange(GetFiles(folder));
                }
                catch { }

            }
            Console.WriteLine(loc.Count);
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            string path = "abc.txt";
            SplitFolder(path);
        }
    }
}
