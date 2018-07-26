using Mzl.Common.Ioc;
using Mzl.Common.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Mojory.WinService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
            

            /*
            var scheduler = IocHelper.Resolve<AbstractScheduler>("Scheduler", "SchedulerContainer");
            scheduler.Run();

            Console.ReadLine();
            */
        }
    }
}
