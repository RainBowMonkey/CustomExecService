using CustomExecService.util.args;
using CustomExecService.util.step;

namespace CustomExecService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main(string[] args)
        {
            ArgsNode argeNode = ArgsReader.Process(args);
            IStep istep = StepFunctory.CreateStep(argeNode);
            istep.Run();
        }
    }
}
