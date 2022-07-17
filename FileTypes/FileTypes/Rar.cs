namespace VerifyingFiles
{
    public sealed class Rar : FileType
    {
        public Rar()
        {
            Name = "Rar";
            Description = "WinRAR compressed archive";
            AddExtensions("rar");
            AddSignatures(
                new byte[] {0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x01, 0x00},
                new byte[] { 0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x00 }
            );
        }
    }
}