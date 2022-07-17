namespace VerifyingFiles
{
    public sealed class Exe : FileType
    {
        public Exe()
        {
            Name = "Exe";
            Description = "Windows|DOS executable file";
            AddExtensions("exe", "dll");
            AddSignatures(
                new byte[] { 0x4D, 0x5A }
            );
        }
    }
}