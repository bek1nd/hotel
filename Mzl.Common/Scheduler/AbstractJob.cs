using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.Scheduler
{
    [PersistJobDataAfterExecution]
    [DisallowConcurrentExecution]
    public abstract class AbstractJob : IJob
    {
        /// <summary>
        /// 间隔时间，单位秒，默认60秒
        /// </summary>
        public int Interval { get; set; }
        public abstract void Execute();
        public void Execute(IJobExecutionContext context)
        {
            //Console.WriteLine("Job Running " + this.GetType().Name);
            Execute();
            //Console.WriteLine("Job Completed " + this.GetType().Name);
        }
    }
}
