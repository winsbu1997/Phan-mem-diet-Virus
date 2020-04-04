namespace Ladin.mtaAV.Manager
{
    class InfectionObject
    {
        public string File { get; set; }

        public string Virus { get; set; }
        public string TypeScan { get; set; }

        public InfectionObject(string File, string Virus, string TypeScan)
        {
            this.File = File;
            this.Virus = Virus;
            this.TypeScan = TypeScan;
        }
    }
}
