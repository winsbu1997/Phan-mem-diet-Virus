using System;
using System.IO;

namespace VerifyingFiles
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\nFile Verification Results\n");
            
            while (true)
            {
                string path = Console.ReadLine();
                if (path.ToString() == "0") { return;  }
                var result = FileTypeVerifier.What(path);
                Console.WriteLine($"{path} is a {result.Name} ({result.Description}).");
            }
               
        }
    }
}