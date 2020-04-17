using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using WebCalendar.Services.Sheduler.Models;
using Newtonsoft.Json;
using Task = System.Threading.Tasks.Task;
using WebCalendar.Services.Sheduler;
using WebCalendar.DAL;
using WebCalendar.DAL.Models.Entities;
using WebCalendar.DAL.Repositories.Contracts;
using WebCalendar.Common.Contracts;

public interface IQuartzService : IHostedService
{
    IScheduler Scheduler { get; set; }
    Task ScheduleTaskAsync(SchedulerTask task);
    Task RescheduleTaskAsync(SchedulerTask task);
    Task UnscheduleTaskAsync(SchedulerTask task);
    Task ScheduleEventAsync(SchedulerEvent @event);
    Task RescheduleEventAsync(SchedulerEvent @event);
    Task UnscheduleEventAsync(SchedulerEvent @event);
    Task ScheduleReminderAsync(SchedulerReminder reminder);
    Task RescheduleReminderAsync(SchedulerReminder reminder);
    Task UnscheduleReminderAsync(SchedulerReminder reminder);
}
public class QuartzHostedService : IQuartzService
{
    private readonly ISchedulerFactory _schedulerFactory;
    private readonly IJobFactory _jobFactory;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IMapper _mapper;

    public QuartzHostedService(
        ISchedulerFactory schedulerFactory,
        IJobFactory jobFactory,
        IServiceScopeFactory scopeFactory,
        IMapper mapper)
    {
        _schedulerFactory = schedulerFactory;
        _jobFactory = jobFactory;
        _scopeFactory = scopeFactory;
        _mapper = mapper;
    }
    public IScheduler Scheduler { get; set; }

    async Task IHostedService.StartAsync(CancellationToken cancellationToken)
    {
        Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
        Scheduler.JobFactory = _jobFactory;

        await Scheduler.Start(cancellationToken);

    /*    using (var scope = _scopeFactory.CreateScope())
        {
            var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            await ScheduleTasksFromDb(uow);
            await ScheduleEventsFromDb(uow);
            await ScheduleRemindersFromDb(uow);
        }*/
    }

    async Task IHostedService.StopAsync(CancellationToken cancellationToken)
    {
        await Scheduler?.Shutdown(cancellationToken);
    }

    public async Task ScheduleTaskAsync(SchedulerTask task)
    {
        JobKey jobKey = new JobKey(task.Id.ToString(), ConstantsStorage.TASK_GROUP);
        TriggerKey triggerKey = new TriggerKey(task.Id.ToString(), ConstantsStorage.TASK_GROUP);

        IJobDetail job = JobBuilder.Create<HelloWorldJob>()
            .WithIdentity(jobKey)
            .UsingJobData(HelloWorldJob.JobDataKey, JsonConvert.SerializeObject(task))
            .UsingJobData(HelloWorldJob.JobActivityTypeKey, ConstantsStorage.TASK)
            .Build();

        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity(triggerKey)
            .StartAt(task.StartTime)
            .Build();

        await Scheduler.ScheduleJob(job, trigger);
    }

    public async Task RescheduleTaskAsync(SchedulerTask task)
    {
        await UnscheduleTaskAsync(task);
        await ScheduleTaskAsync(task);
    }

    public async Task UnscheduleTaskAsync(SchedulerTask task)
    {
        JobKey jobKey = new JobKey(task.Id.ToString(), ConstantsStorage.TASK_GROUP);

        await Scheduler.DeleteJob(jobKey);
    }

    public async Task ScheduleEventAsync(SchedulerEvent @event)
    {
        if (@event.NotifyBeforeInterval != null)
        {
            await ScheduleAdvanceEventAsync(@event);
        }

        JobKey jobKey = new JobKey(@event.Id.ToString(), ConstantsStorage.EVENT_GROUP);
        TriggerKey triggerKey = new TriggerKey(@event.Id.ToString(), ConstantsStorage.EVENT_GROUP);

        IJobDetail job = JobBuilder.Create<HelloWorldJob>()
            .WithIdentity(jobKey)
            .UsingJobData(HelloWorldJob.JobDataKey, JsonConvert.SerializeObject(@event))
            .UsingJobData(HelloWorldJob.JobActivityTypeKey, ConstantsStorage.EVENT)
            .Build();

        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity(triggerKey)
            .StartAt(@event.StartTime)
            .WithCronSchedule(@event.CronExpression)
            .EndAt(@event.EndTime)
            .Build();

        await Scheduler.ScheduleJob(job, trigger);
    }

    public async Task RescheduleEventAsync(SchedulerEvent @event)
    {
        await UnscheduleEventAsync(@event);
        await ScheduleEventAsync(@event);
    }

    public async Task UnscheduleEventAsync(SchedulerEvent @event)
    {
        JobKey jobKey = new JobKey(@event.Id.ToString(), ConstantsStorage.EVENT_GROUP);

        if (@event.NotifyBeforeInterval != null)
        {
            await UnscheduleAdvanceEventAsync(@event);
        }

        await Scheduler.DeleteJob(jobKey);
    }

    public async Task ScheduleReminderAsync(SchedulerReminder reminder)
    {
        JobKey jobKey = new JobKey(reminder.Id.ToString(), ConstantsStorage.REMINDER_GROUP);
        TriggerKey triggerKey = new TriggerKey(reminder.Id.ToString(), ConstantsStorage.REMINDER_GROUP);

        IJobDetail job = JobBuilder.Create<HelloWorldJob>()
            .WithIdentity(jobKey)
            .UsingJobData(HelloWorldJob.JobDataKey, JsonConvert.SerializeObject(reminder))
            .UsingJobData(HelloWorldJob.JobActivityTypeKey, ConstantsStorage.REMINDER)
            .Build();

        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity(triggerKey)
            .StartAt(reminder.StartTime)
            .WithCronSchedule(reminder.CronExpression)
            .EndAt(reminder.EndTime)
            .Build();

        await Scheduler.ScheduleJob(job, trigger);
    }

    public async Task RescheduleReminderAsync(SchedulerReminder reminder)
    {
        await UnscheduleReminderAsync(reminder);
        await ScheduleReminderAsync(reminder);
    }

    public async Task UnscheduleReminderAsync(SchedulerReminder reminder)
    {
        JobKey jobKey = new JobKey(reminder.Id.ToString(), ConstantsStorage.REMINDER_GROUP);

        await Scheduler.DeleteJob(jobKey);
    }

    private async Task ScheduleAdvanceEventAsync(SchedulerEvent @event)
    {
        JobKey jobKey = new JobKey(@event.Id.ToString(), ConstantsStorage.ADVANCE_EVENT_GROUP);
        TriggerKey triggerKey = new TriggerKey(@event.Id.ToString(), ConstantsStorage.EVENT_GROUP);
        DateTime startTime = new DateTime(@event.StartTime.Ticks - @event.NotifyBeforeInterval.Value.Ticks);

        IJobDetail job = JobBuilder.Create<HelloWorldJob>()
            .WithIdentity(jobKey)
            .UsingJobData(HelloWorldJob.JobDataKey, JsonConvert.SerializeObject(@event))
            .UsingJobData(HelloWorldJob.JobActivityTypeKey, ConstantsStorage.ADVANCE_EVENT)
            .Build();

        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity(triggerKey)
            .StartAt(startTime)
            .Build();

        await Scheduler.ScheduleJob(job, trigger);
    }

    private async Task UnscheduleAdvanceEventAsync(SchedulerEvent @event)
    {
        JobKey jobKey = new JobKey(@event.Id.ToString(), ConstantsStorage.ADVANCE_EVENT_GROUP);

        await Scheduler.DeleteJob(jobKey);
    }

    private async Task ScheduleTasksFromDb(IUnitOfWork unitOfWork)
    {
        var repository = unitOfWork.GetRepository<WebCalendar.DAL.Models.Entities.Task>();
        var tasks = await repository.GetAllAsync();
        
        foreach(var task in tasks)
        {
            var schedulerTask = _mapper.Map<WebCalendar.DAL.Models.Entities.Task, SchedulerTask>(task);
            await ScheduleTaskAsync(schedulerTask);
        }
    }
    private async Task ScheduleEventsFromDb(IUnitOfWork unitOfWork)
    {
        var repository = unitOfWork.GetRepository<Event>();
        var events = await repository.GetAllAsync();

        foreach (var @event in events)
        {
            var schedulerEvent = _mapper.Map<Event, SchedulerEvent>(@event);
            await ScheduleEventAsync(schedulerEvent);
        }
    }
    private async Task ScheduleRemindersFromDb(IUnitOfWork unitOfWork)
    {
        var repository = unitOfWork.GetRepository<Reminder>();
        var reminders = await repository.GetAllAsync();

        foreach (var reminder in reminders)
        {
            var schedulerReminder = _mapper.Map<Reminder, SchedulerReminder>(reminder);
            await ScheduleReminderAsync(schedulerReminder);
        }
    }
}
