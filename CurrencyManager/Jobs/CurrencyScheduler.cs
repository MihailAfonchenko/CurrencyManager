using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyManager.Jobs
{
    public class CurrencyScheduler
    {
        public static async void Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<RequestCurrency>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("triggerCur")
                //.WithCronSchedule("")
                .WithSimpleSchedule(x => x.WithIntervalInMinutes(10)
                .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }
    }
}
