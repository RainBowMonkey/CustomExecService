using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomExecService.util.args
{
    class ArgsReader
    {
        public static ArgsNode Process(string[] args) 
        {
            return Analyse(args);
        }

        private static bool IsVaild(string[] args)
        {
            if (args.Length == 1)
            {
                string lower = args[0].ToLower();
                if (ArgsFlag.Contain(lower)) {
                    return true;
                }
            }
            else if (args.Length == 0)
            {
                return true;
            }
            return false;
        }
        private static ArgsNode Analyse(string[] args) 
        {
            if (IsVaild(args))
            {
                if (args.Length == 0)
                {
                    return new ArgsNode() { ArgsType = ArgsEnum.Run };
                }
                string lower = args[0].ToLower();
                if (lower == ArgsFlag.INSTALL)
                {
                    return new ArgsNode() { ArgsType = ArgsEnum.Install };
                }
                else if (lower == ArgsFlag.UNINSTALL)
                {
                    return new ArgsNode() { ArgsType = ArgsEnum.Uninstall};
                }
            }
            return new ArgsNode() { ArgsType = ArgsEnum.InVaild };
        }
    }
}
