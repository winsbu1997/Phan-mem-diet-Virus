namespace VerifyingFiles
{
    public sealed class Zip : FileType
    {
        public Zip()
        {
            Name = "Zip";
            Description = "Zip compressed archive";
            AddExtensions("zip");
            AddSignatures(
                new byte[] { 0x50, 0x4B, 0x05, 0x06 },
                new byte[] { 0x50, 0x4B, 0x07, 0x08 },
                new byte[] { 0x50, 0x4B, 0x03, 0x04 }
            );
        }
    }
}