using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using WebCalendar.DAL;
using WebCalendar.DAL.Models.Entities;
using Task = System.Threading.Tasks.Task;

public interface IQuartzService 
{
    IScheduler Scheduler { get; set; }
}
public class QuartzHostedService : IQuartzService, IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ISchedulerFactory _schedulerFactory;
    private readonly IJobFactory _jobFactory;
    //  private readonly IEnumerable<JobSchedule> _jobSchedules;
    //    private readonly IUnitOfWork _uow;

    public QuartzHostedService(
        ISchedulerFactory schedulerFactory,
        IJobFactory jobFactory,
        IServiceProvider serviceProvider
        /*IUnitOfWork uow,
        IEnumerable<JobSchedule> jobSchedules*/)
    {
        _schedulerFactory = schedulerFactory;
        // _jobSchedules = jobSchedules;
        _jobFactory = jobFactory;
        _serviceProvider = serviceProvider;
        //_uow = uow;
    }
    public IScheduler Scheduler { get; set; }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
        Scheduler.JobFactory = _jobFactory;

        /*foreach (var jobSchedule in _jobSchedules)
        {
            var job = CreateJob(jobSchedule);
            var trigger = CreateTrigger(jobSchedule);

            await Scheduler.ScheduleJob(job, trigger, cancellationToken);
        }*/
        await ScheduleReminderAsync(cancellationToken);
        await Scheduler.Start(cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Scheduler?.Shutdown(cancellationToken);
    }

    private static IJobDetail CreateJob(JobSchedule schedule)
    {
        var jobType = schedule.JobType;
        return JobBuilder
            .Create(jobType)
            .WithIdentity(jobType.FullName)
            .WithDescription(jobType.Name)
            .Build();
    }

    private static ITrigger CreateTrigger(JobSchedule schedule)
    {
        return TriggerBuilder
            .Create()
            .WithIdentity($"{schedule.JobType.FullName}.trigger")
            .WithCronSchedule(schedule.CronExpression)
            .WithDescription(schedule.CronExpression)
            .Build();
    }

    public async Task ScheduleReminderAsync(CancellationToken cancellationToken)
    {
        /*IJobDetail job = JobBuilder.Create<HelloWorldJob>()
                .WithIdentity(Guid.NewGuid().ToString())
                .UsingJobData(HelloWorldJob.JobDataKey, "Aniki")
                .Build();

        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity(Guid.NewGuid().ToString())
           // .StartAt(reminder.StartTime)
            .StartNow()
            .WithSimpleSchedule(x => x         
                    .WithIntervalInSeconds(5)    
                    .RepeatForever())
            .Build();

        await Scheduler.ScheduleJob(job, trigger, cancellationToken);*/
    }
}
