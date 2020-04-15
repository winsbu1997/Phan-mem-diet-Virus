using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladin.mtaAV.Manager
{
    class ProcessManager
    {
        public static List<string> GetListFileOfCurrentPath(string Path)
        {
            List<string> ListF = new List<string>();
            DirectoryInfo d = new DirectoryInfo(Path);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*"); //Getting Text files
            foreach (FileInfo f in Files)
                ListF.Add(f.Name);
            DirectoryInfo directory = new DirectoryInfo(Path);
            DirectoryInfo[] directories = directory.GetDirectories();
            foreach (DirectoryInfo folder in directories)
                ListF.Add(folder.Name);
            return ListF;
        }
        public static double CalculateSimilarity(string a, string b)
        {
            int c = 0;
            int k = a.Length;
            if (a.Length != b.Length) return 0;

            else
            {

                for (int i = 0; i < k; i++)
                    if (a[i] == b[i]) c++;
            }
            // c = 9; k = 7;
            return (c * 1000 / k);
        }
        public static string Normalize(string path)
        {
            char a = '\\';
            string[] pathArr = path.Split(a);
            string Path = pathArr[0] + "\\";
            int countNum = pathArr.Count();
            for (int i = 1; i < countNum; i++)
            {
                List<string> ListF = GetListFileOfCurrentPath(Path);
                double max = 0;
                string strMax = "";
                foreach (string f in ListF)
                {
                    double tmp = CalculateSimilarity(f, pathArr[i]);
                    if (tmp > max)
                    {
                        max = tmp;
                        strMax = f;
                    }
                }
                if (i != countNum - 1)
                    Path = Path + strMax + "\\";
                else Path = Path + strMax;
            }
            pathArr[countNum - 1] = Path;
            return Path;
        }
    }
}
