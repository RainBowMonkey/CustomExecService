using CustomExecService.util.external;
using CustomExecService.util.check;
using CustomExecService.util.config;
using System.ServiceProcess;

namespace CustomExecService
{
    public partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //todo:启动命令行中的程序
            Configuration config = MyContext.Instance().GetConfiguration();
            int processId = Exec.Call(config.BinPath, config.Param);
            Deamon deamon = Deamon.Instance();
            deamon.Launch();
            deamon.Register(processId);
        }

        protected override void OnStop()
        {
            //todo:结束命令行中的程序
            Deamon.Instance().Shutdown();
        }
    }
}
