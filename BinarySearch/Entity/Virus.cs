using BinarySearch.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch.Entity
{
    public class Virus
    {
        public string Name { get; set; }
        public string HashValue { get; set; }
        public Virus() { }
        public Virus(string Name, string HashValue)
        {
            this.Name = Name;
            this.HashValue = HashValue;
        }
    }

    
    public class ResultScan
    {
        public bool IsEmpty { get; set; }
        public string VirusName { get; set; }
    }
}
