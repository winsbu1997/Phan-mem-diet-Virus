using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VerifyingFiles
{
    public static class FileTypeVerifier
    {
        private static FileTypeVerifyResult Unknown = new FileTypeVerifyResult
        {
            Name = "Unknown",
            Description = "Unknown File Type",
            IsVerified = false
        };
        
        static FileTypeVerifier()
        {
            Types = new List<FileType>
                {
                    new Exe(),
                    new Rar(),
                    new Zip()
                }
                .OrderByDescending(x => x.SignatureLength)
                .ToList();
        }

        private static IEnumerable<FileType> Types { get; set; }

        public static FileTypeVerifyResult What(string path)
        {
            FileTypeVerifyResult result = null;
            try
            {
                var file = File.OpenRead(path);
                
                foreach (var fileType in Types)
                {
                    result = fileType.Verify(file);
                    if (result.IsVerified)
                        break;
                }
                file.Dispose();
            }
            catch
            {

            }
            return result?.IsVerified == true
                   ? result
                   : Unknown;
        }
    }
}