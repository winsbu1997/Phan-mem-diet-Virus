using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch.Interface
{
    interface IHash
    {
        string HashFile(string path);
        int HashSize();
        int BufferSize();
    }
}
