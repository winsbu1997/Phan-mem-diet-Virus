using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using Ladin.mtaAV.Model;
namespace Ladin.mtaAV.Manager
{
    class QuarantineManager
    {
        private string loc = string.Empty;
        private Encryption enc = new Encryption();
        private string password = "mtaAVAV_infoSec_2020@2202$%";


        public QuarantineManager()
        {
            loc = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            loc = loc + "\\mtaAV\\Quarantine\\";

            if (!Directory.Exists(loc))
            {
                Directory.CreateDirectory(loc);
            }
        }
        public void AddQuarantine(string file)
        {
            string des = loc + "\\" + Path.GetFileName(file);
            if(File.Exists(des)) File.Delete(des);
            if (!File.Exists(des))
            {
                enc.EncryptFile(file, des, password);
            }
            Thread.Sleep(500);
            try { File.Delete(file); }
            catch { }
        }

        public void RestoreQuarantine(string file)
        {
            string des = loc + "\\" + Path.GetFileName(file);
            if (File.Exists(file)) File.Delete(file);
            if (!File.Exists(file))
            {
                enc.DecryptFile(des, file, password);
            }
            Thread.Sleep(500);
            try { File.Delete(des); }
            catch { }
        }

        public void DeleteQuarantine(string file)
        {
            string des = loc + "\\" + Path.GetFileName(file);
            try { File.Delete(des); }
            catch { }
        }
        public void ClearQuarantine()
        {
            DirectoryInfo d = new DirectoryInfo(loc);
            foreach (var file in d.GetFiles("*.*"))
            {
                try { File.Delete(file.FullName); }
                catch { }
            }
        }
    }
    class Encryption
    {
        private readonly byte[] salt = new byte[] { 0x56, 0x47, 0x98, 0x33, 0x88, 0x13, 0x77, 0x10 };
        private const int iterations = 1042;

        public void DecryptFile(string sourceFilename, string destinationFilename, string password)
        {
            AesManaged aes = new AesManaged();
            aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
            aes.KeySize = aes.LegalKeySizes[0].MaxSize;
            // NB: Rfc2898DeriveBytes initialization and subsequent calls to   GetBytes   must be eactly the same, including order, on both the encryption and decryption sides.
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);
            aes.Mode = CipherMode.CBC;
            ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);
            using (FileStream destination = new FileStream(destinationFilename, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                using (CryptoStream cryptoStream = new CryptoStream(destination, transform, CryptoStreamMode.Write))
                {
                    try
                    {
                        using (FileStream source = new FileStream(sourceFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            source.CopyTo(cryptoStream);
                        }
                    }
                    catch (CryptographicException exception)
                    {
                        if (exception.Message == "Padding is invalid and cannot be removed.")
                            throw new ApplicationException("Universal Microsoft Cryptographic Exception (Not to be believed!)", exception);
                        else
                            throw;
                    }
                }
            }
        }

        public void EncryptFile(string sourceFilename, string destinationFilename, string password)
        {
            AesManaged aes = new AesManaged();
            aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
            aes.KeySize = aes.LegalKeySizes[0].MaxSize;
            // NB: Rfc2898DeriveBytes initialization and subsequent calls to   GetBytes   must be exactly the same, including order, on both the encryption and decryption sides.
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);
            aes.Mode = CipherMode.CBC;
            ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);

            using (FileStream destination = new FileStream(destinationFilename, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                using (CryptoStream cryptoStream = new CryptoStream(destination, transform, CryptoStreamMode.Write))
                {
                    using (FileStream source = new FileStream(sourceFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        source.CopyTo(cryptoStream);
                    }
                }
            }
        }
    }

}
