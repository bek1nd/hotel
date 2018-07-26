using Mzl.Common.Ioc;
using Mzl.Common.Scheduler;
using Mzl.Mojory.WinService.Scheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Mojory.WinService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //var scheduler = IocHelper.Resolve<AbstractScheduler>("Scheduler", "SchedulerContainer");
            //scheduler.Run();
        }

        protected override void OnStop()
        {
        }
    }
}
