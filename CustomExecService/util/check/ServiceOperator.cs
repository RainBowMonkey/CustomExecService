using CustomExecService.util.config;
using System;
using System.Collections;
using System.Configuration.Install;
using System.IO;
using System.ServiceProcess;

namespace CustomExecService.util.check
{
    class ServiceOperator
    {
        public static bool IsServiceExisted(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController sc in services)
            {
                if (sc.ServiceName.ToLower() == serviceName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        //安装服务
        public static void InstallService(Configuration config)
        {
            
            using (AssemblyInstaller installer = new AssemblyInstaller())
            {
                installer.UseNewContext = true;
                installer.Path = MyContext.Instance().GetAppFullName();
                //installer.CommandLine = new string[1] { InstallInfoFlag.RunFlag };
                IDictionary savedState = new Hashtable();
                installer.Install(savedState);
                installer.Commit(savedState);
            }
        }

        //卸载服务
        public static void UninstallService()
        {
            using (AssemblyInstaller installer = new AssemblyInstaller())
            {
                installer.UseNewContext = true;
                installer.Path = MyContext.Instance().GetAppFullName();
                installer.Uninstall(null);
            }
        }
        //启动服务
        public static void ServiceStart(string serviceName)
        {
            using (ServiceController control = new ServiceController(serviceName))
            {
                if (control.Status == ServiceControllerStatus.Stopped)
                {
                    control.Start();
                    control.WaitForStatus(ServiceControllerStatus.Running); //等待启动
                    control.Refresh();
                }
            }
        }

        //停止服务
        public static void ServiceStop(string serviceName)
        {
            using (ServiceController control = new ServiceController(serviceName))
            {
                if (control.Status == ServiceControllerStatus.Running)
                {
                    control.Stop();
                }
            }
        }
    }
}
