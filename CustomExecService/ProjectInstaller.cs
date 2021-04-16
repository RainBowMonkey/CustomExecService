using CustomExecService.util.config;
using System.Collections;
using System.ComponentModel;
using System.ServiceProcess;

namespace CustomExecService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }
        protected override void OnBeforeInstall(IDictionary savedState)
        {
            Configuration configuration = MyContext.Instance().GetConfiguration();
            serviceInstaller.Description = string.Format("{0}--{1}",configuration.Description, ExternalConfig.VERSION);
            serviceInstaller.ServiceName = configuration.ServiceName;
            serviceInstaller.DisplayName = serviceInstaller.ServiceName;
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            base.OnBeforeInstall(savedState);
        }
        protected override void OnAfterInstall(IDictionary savedState)
        {
            base.OnAfterInstall(savedState);
        }
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
        }
        protected override void OnCommitting(IDictionary savedState)
        {
            base.OnCommitting(savedState);
        }
        protected override void OnCommitted(IDictionary savedState)
        {
            base.OnCommitted(savedState);
        }
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }
        protected override void OnBeforeRollback(IDictionary savedState)
        {
            base.OnBeforeRollback(savedState);
        }
        protected override void OnAfterRollback(IDictionary savedState)
        {
            base.OnAfterRollback(savedState);
        }
        public override void Uninstall(IDictionary savedState)
        {
            Configuration configuration = MyContext.Instance().GetConfiguration();
            serviceInstaller.Description = configuration.Description;
            serviceInstaller.ServiceName = configuration.ServiceName;
            serviceInstaller.DisplayName = serviceInstaller.ServiceName;
            base.Uninstall(savedState);
        }
        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            base.OnBeforeUninstall(savedState);
        }
        protected override void OnAfterUninstall(IDictionary savedState)
        {
            base.OnAfterUninstall(savedState);
        }
    }
}
