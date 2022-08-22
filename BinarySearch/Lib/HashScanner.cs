using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearch.Entity;
using BinarySearch.Interface;
using System.IO;

namespace BinarySearch.Lib
{
    class HashScanner
    {
        private IHash hashHelper;
        private List<string> pathz;
        private FileStream fs;
        private BufferedStream bs;
        private int BufferSize;

        public HashScanner(IHash _hashHelper, List<string> paths)
        {
            hashHelper = _hashHelper;
            BufferSize = hashHelper.BufferSize();
            pathz = new List<string>();
            foreach (string path in paths)
                pathz.Add(path);
        }

        public int ConvertCharToNum(char ch)
        {
            int id = 0;
            switch (ch)
            {
                case '0':
                case '1': id = 0; break;
                case '2':
                case '3': id = 1; break;
                case '4':
                case '5': id = 2; break;
                case '6':
                case '7': id = 3; break;
                case '8':
                case '9': id = 4; break;
                case 'a':
                case 'b': id = 5; break;
                case 'c':
                case 'd': id = 6; break;
                case 'e':
                case 'f': id = 7; break;
            }
            return id;
        }

        public Virus GetVirus(long pos)
        {
            pos--;
            //Console.WriteLine(pos);
            bs.Seek(pos * BufferSize, SeekOrigin.Begin);
            byte[] tmp = new byte[BufferSize];
            bs.Read(tmp, 0, BufferSize);
            for (int i = 0; i < BufferSize; i++) tmp[i] = Convert.ToByte(255 - tmp[i]);
            //for (int i = 0; i < BufferSize; i++) Console.Write(tmp[i] + " "); Console.WriteLine();
            string t = Encoding.Default.GetString(tmp);
            //Console.WriteLine('+' + t + '+');
            t = t.Trim();
            //Console.WriteLine("-->+" + t + '+');
            Virus res = new Virus();
            List<string> lst = t.Split(':').ToList();
            res.HashValue = lst[0];
            res.Name = lst[1];
            lst.Clear();
            return res;
        }

        public ResultScan BinarySearch(string hashValue)
        {
            ResultScan res = new ResultScan { IsEmpty = true, VirusName = "" };
            long inf = 1, sup = fs.Length / BufferSize;
            while (inf <= sup)
            {
                long mid = (inf + sup) / 2;
                Virus tmp = GetVirus(mid);
                //Console.WriteLine("Index= {0} Name= {1} Hash Value= {2}", mid, tmp.Name, tmp.HashValue);
                if (hashValue.Equals(tmp.HashValue, StringComparison.OrdinalIgnoreCase))
                {
                    res.IsEmpty = false;
                    res.VirusName = tmp.Name;
                    return res;
                }
                if (hashValue.CompareTo(tmp.HashValue) > 0) inf = mid + 1;
                else sup = mid - 1;
            }
            return res;
        }

        public ResultScan Search(string hashValue)
        {
            int id = ConvertCharToNum(hashValue[0]);
            fs = new FileStream(pathz[id], FileMode.Open, FileAccess.Read);
            bs = new BufferedStream(fs, BufferSize);
            ResultScan res = BinarySearch(hashValue);
            fs.Close(); bs.Close();
            return res;
        }

        public ResultScan Scan(string path = "")
        {

            string hashValue = hashHelper.HashFile(path);
            ResultScan res = Search(hashValue);
            return res; 
            
        }

        public string GetHash(string path = "")
        {
            string hashVaule = hashHelper.HashFile(path);
            return hashVaule;
        }

        public byte[] ConvertByte(Virus virus)
        {
            byte[] res = new byte[BufferSize];
            int index = 0;
            for (int i = 0; i < virus.HashValue.Length; i++)
            {
                res[index] = Convert.ToByte(255 - Convert.ToByte(virus.HashValue[i]));
                index++;
            }
            res[index] = Convert.ToByte(255 - Convert.ToByte(':'));
            index++;
            for (int i = 0; i < virus.Name.Length; i++)
            {
                res[index] = Convert.ToByte(255 - Convert.ToByte(virus.Name[i]));
                index++;
            }
            while (index < BufferSize)
            {
                res[index] = Convert.ToByte(255 - Convert.ToByte(' '));
                index++;
            }
            // 255 - ??
            return res;
        }

        public void Update(string path = "", string virusName = "")
        {
            //List<Virus>[] lstVirus = new List<Virus>[8];
            List<List<Virus>> lstVirus = new List<List<Virus>>();
            List<Virus> lstVirusZ = new List<Virus>();
            for (int i = 0; i < 8; i++)
            {
                List<Virus> sub = new List<Virus>();
                lstVirus.Add(sub);
            }
            if(virusName != "")
            {
                string hashValue = GetHash(path);
                Virus item = new Virus(virusName, hashValue);
                if (Search(item.HashValue).IsEmpty == true)
                {
                    int id = ConvertCharToNum(item.HashValue[0]);
                    lstVirus[id].Add(item);
                }
            }

            else
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line; //int i = 0;
                                 //int Counter = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Trim();
                        Virus item = new Virus();
                        List<string> lst = line.Split(':').ToList();
                        if (lst.Count >= 2)
                        {
                            item.Name = lst[0];
                            item.HashValue = lst[1];
                            if (Search(item.HashValue).IsEmpty == true)
                            {
                                //Counter++;
                                //if (Counter <= 10)
                                //Console.WriteLine(item.Name + " " + item.HashValue);
                                int id = ConvertCharToNum(item.HashValue[0]);
                                lstVirus[id].Add(item);
                            }
                            //i++;
                            //if (i < 10) 
                            //Console.WriteLine(item.Name + "-------" + item.HashValue + ">>>>");
                            //Update(item);
                        }
                    }
                }
            }
            
            /*foreach (List<Virus> item in lstVirus)
            {
                foreach (Virus tmp in item)
                {
                    Console.WriteLine(tmp.HashValue + "---" + tmp.Name);
                }
                Console.WriteLine();
            }*/
            for (int ii = 0; ii < 8; ii++)
                if (lstVirus[ii].Count > 0)
                {
                    //Console.WriteLine("II= {0}", ii);
                    lstVirusZ = new List<Virus>();
                    fs = new FileStream(pathz[ii], FileMode.Open, FileAccess.Read);
                    bs = new BufferedStream(fs, BufferSize);
                    long Len = fs.Length / BufferSize;
                    for (int i = 1; i <= Len; i++)
                    {
                        Virus tmp = GetVirus(i);
                        lstVirusZ.Add(tmp);
                    }
                    foreach (Virus item in lstVirus[ii])
                        lstVirusZ.Add(item);
                    lstVirusZ = lstVirusZ.OrderBy(p => p.HashValue).ToList();
                    fs.Close(); bs.Close();
                    fs = new FileStream(pathz[ii], FileMode.Open, FileAccess.Write);
                    bs = new BufferedStream(fs, BufferSize);
                    for (int i = 0; i < lstVirusZ.Count; i++)
                    {
                        bs.Write(ConvertByte(lstVirusZ[i]), 0, BufferSize);
                    }
                    lstVirusZ.Clear();
                    fs.Close(); bs.Close();
                }
            lstVirus.Clear();
        }


        public void PrintDB()
        {
            int id = 0;
            fs = new FileStream(pathz[id], FileMode.Open, FileAccess.Read);
            StreamWriter sw = new StreamWriter("Output.txt");
            bs = new BufferedStream(fs, BufferSize);
            long n = fs.Length / BufferSize;
            for (int i = 1; i <= n; i++)
            {
                Virus z = GetVirus(i);
                string tmp = z.HashValue + ":" + z.Name;
                sw.WriteLine(tmp);
                Console.WriteLine("I= {0} Hash= {1} Name={2}", i, z.HashValue, z.Name);
            }
            fs.Close(); bs.Close();
        }
    }
}
