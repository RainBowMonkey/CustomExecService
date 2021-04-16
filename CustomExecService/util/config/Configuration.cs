namespace CustomExecService.util.config
{
    class Configuration
    {
        public string ServiceName { get; set; }
        public string BinPath { get; set; }
        public string Param { get; set; }
        public string Description { get; set; }

        public Configuration()
        {
            ServiceName = null;
            BinPath = null;
            Param = null;
            Description = null;
        }

        public bool IsValid()
        {
            return (ServiceName != null) && (BinPath != null);
        }
    }
}
