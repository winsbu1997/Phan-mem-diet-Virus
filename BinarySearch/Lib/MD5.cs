﻿using BinarySearch.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch.Lib
{
    public class MD5 : IHash
    {
        public string HashFile(string path)
        {
            try
            {
                using (var md5 = System.Security.Cryptography.MD5.Create())
                {
                    using (var stream = File.OpenRead(path))
                    {
                        return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                return "";
            }
        }
        public int BufferSize()
        {
            return 75;
        }
        public int HashSize()
        {
            return 32;
        }
    }
}
