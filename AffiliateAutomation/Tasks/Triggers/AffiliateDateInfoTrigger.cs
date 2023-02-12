using AffiliateAutomation.Tasks.Jobs;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AffiliateAutomation.Tasks.Triggers
{
    public class AffiliateDateInfoTrigger
    {
        public static void Start()
        {
            //Create Timer
            IScheduler timer = (IScheduler)StdSchedulerFactory.GetDefaultScheduler().Result;
            //Start Timer
            if (!timer.IsStarted)
            {
                timer.Start();
            }
            //Select The Task to Trigger
            IJobDetail mission = JobBuilder.Create<AffiliateDateInfo>().Build();

            //Create Tiger
            ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
                .WithIdentity("AffiliateDateInfo", "null") //Name of the task to run
                .WithCronSchedule("0 0 22 * * ? *") //Choose what time of day to work
                .Build(); // Activate Trigger

            //Introduce The Task and The Trigger To The Timer
            timer.ScheduleJob(mission, trigger);
        }
    }
}