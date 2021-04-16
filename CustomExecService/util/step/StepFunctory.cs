using CustomExecService.util.args;

namespace CustomExecService.util.step
{
    class StepFunctory
    {
        public static IStep CreateStep(ArgsNode argsNode)
        {
            if (argsNode.ArgsType == ArgsEnum.Install)
            {
                return new InstallStep();
            }
            else if (argsNode.ArgsType == ArgsEnum.Uninstall)
            {
                return new UninstallStep();
            }
            else if (argsNode.ArgsType == ArgsEnum.Run)
            {
                return new RunStep();
            }
            else
            {
                return new NoneStep();
            }
        }
    }
}
