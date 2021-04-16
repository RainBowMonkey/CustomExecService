using CustomExecService.util.check;
using CustomExecService.util.config;

namespace CustomExecService.util.step
{
    class InstallStep : IStep
    {
        public void Run()
        {
            if (!ConfigReader.GetConfiguration()) { return; }
            Configuration config = MyContext.Instance().GetConfiguration();
            if (ServiceOperator.IsServiceExisted(config.ServiceName))
            {
                ServiceOperator.UninstallService();
            }
            ServiceOperator.InstallService(config);
        }
    }
}
