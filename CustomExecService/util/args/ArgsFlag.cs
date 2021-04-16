namespace CustomExecService.util.args
{
    class ArgsFlag
    {
        public static readonly string INSTALL = "install";
        public static readonly string UNINSTALL = "uninstall";
        public static readonly string RUN = "run";

        public static bool Contain(string str)
        {
            if (str == INSTALL || str == UNINSTALL || str == RUN)
            {
                return true;
            }
            return false;
        }
    }
}
