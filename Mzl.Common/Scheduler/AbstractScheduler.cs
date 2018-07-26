using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.Scheduler
{
    public abstract class AbstractScheduler
    {
        public AbstractJob[] Jobs { get; set; }

        static ISchedulerFactory sf = new StdSchedulerFactory();
        static IScheduler sched = sf.GetScheduler();

        public void Run()
        {
            DateTimeOffset runTime = DateBuilder.EvenMinuteDate(DateTimeOffset.UtcNow);

            int num = 0;
            if (Jobs != null && Jobs.Any())
            {
                foreach (var job in Jobs)
                {
                    num++;

                    var detail = JobBuilder.Create(job.GetType())
                        .WithIdentity("Job" + num, "Group" + num)
                        .RequestRecovery()
                        .Build();

                    var trigger = TriggerBuilder.Create()
                        .WithIdentity("Trigger" + num, "Group" + num)
                        .StartAt(runTime)
                        .WithSimpleSchedule(x => x.WithIntervalInSeconds(job.Interval > 0 ? job.Interval : 60).RepeatForever())
                        .Build();

                    sched.ScheduleJob(detail, trigger);
                }
            }
            sched.Start();
        }
    }
}
