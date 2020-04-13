using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebCalendar.Services.Sheduler.Models;

namespace WebCalendar.Services.Sheduler
{
    public interface ISchedulerService<T>
    {
        Task Schedule(T activity);
        Task Unschedule(T activity);
        Task Reschedule(T activity);
    }
    public class SchedulerService : ISchedulerService<SchedulerEvent>, ISchedulerService<SchedulerReminder>, ISchedulerService<SchedulerTask>
    {
        private readonly IQuartzService _quartzService;

        public SchedulerService(IQuartzService quartzService)
        {
            _quartzService = quartzService;
        }

        public Task Reschedule(SchedulerEvent activity)
        {
            throw new NotImplementedException();
        }

        public Task Reschedule(SchedulerReminder activity)
        {
            throw new NotImplementedException();
        }

        public Task Reschedule(SchedulerTask activity)
        {
            throw new NotImplementedException();
        }

        public async Task Schedule(SchedulerEvent schedulerEvent)
        {
        /*    IJobDetail job = JobBuilder.Create<HelloWorldJob>()
                .WithIdentity(Guid.NewGuid().ToString())
                .UsingJobData(HelloWorldJob.JobDataKey, "Aniki")
                .Build();

            TriggerBuilder triggerBuilder = TriggerBuilder.Create()
                .WithIdentity(schedulerEvent.Id.ToString())
                .StartAt(schedulerEvent.StartTime);

            if (schedulerEvent.RepetitionInterval != null)
            {
                if (schedulerEvent.RepetitionsCount != 0)
                {

                }
            }
           
               /* .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(5)
                        .RepeatForever())
                .Build();
*/
        //    await _quartzService.Scheduler.ScheduleJob(job, trigger);
        }

        public Task Schedule(SchedulerReminder activity)
        {
            throw new NotImplementedException();
        }

        public async Task Schedule(SchedulerTask schedulerTask)
        {
            IJobDetail job = JobBuilder.Create<HelloWorldJob>()
                            .WithIdentity(Guid.NewGuid().ToString())
                            .UsingJobData(HelloWorldJob.JobDataKey, "Aniki")
                            .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity(schedulerTask.Id.ToString())
                .StartAt(schedulerTask.StartTime)
                .Build();

            await _quartzService.Scheduler.ScheduleJob(job, trigger);
        }

        public Task Unschedule(SchedulerEvent activity)
        {
            throw new NotImplementedException();
        }

        public Task Unschedule(SchedulerReminder activity)
        {
            throw new NotImplementedException();
        }

        public Task Unschedule(SchedulerTask activity)
        {
            throw new NotImplementedException();
        }
    }
}
