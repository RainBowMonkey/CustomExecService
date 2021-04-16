using CustomExecService.util.config;
using System.ServiceProcess;

namespace CustomExecService.util.step
{
    class RunStep : IStep
    {
        public void Run()
        {
            if (!ConfigReader.GetConfiguration()) { return; }
            Configuration config = MyContext.Instance().GetConfiguration();
            ServiceController[] serviceControllers = ServiceController.GetServices();

            bool serviceExist = false;
            foreach (ServiceController controller in serviceControllers)
            {
                if (controller.ServiceName == config.ServiceName)
                {
                    serviceExist = true;
                    break;
                }
            }
            if (serviceExist)
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new Service()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
