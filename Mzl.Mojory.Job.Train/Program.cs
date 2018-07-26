using Mzl.Common.PostHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Mojory.Job.Train
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            string ok = PostHelper.PostUrl("http://192.168.1.117:84/api/MojoryApi/TrainCallBack/MakeUp", "", Encoding.UTF8);
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new Service1()
            //};
            //ServiceBase.Run(ServicesToRun);
        }
    }
}
