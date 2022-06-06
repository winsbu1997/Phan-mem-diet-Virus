using System;
using BinarySearch.Interface;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch.Lib
{
    public class SHA256 : IHash
    {
        public string HashFile(string path)
        {
            try
            {
                using (var sha256 = System.Security.Cryptography.SHA256.Create())
                {
                    using (var stream = File.OpenRead(path))
                    {
                        return BitConverter.ToString(sha256.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
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
            return 120;
        }
        public int HashSize()
        {
            return 64;
        }
    }
}
