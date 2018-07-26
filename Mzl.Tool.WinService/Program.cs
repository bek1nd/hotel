using Mzl.Common.Ioc;
using Mzl.Common.Scheduler;
using Mzl.Tool.WinService.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Tool.WinService
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
            */
            new B2TPriceGetJob().Execute();
        }
    }
}
