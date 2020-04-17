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
using WebCalendar.Services.Sheduler.Contracts;

public interface ISchedulerService : IHostedService
{
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
public class QuartzHostedService : ISchedulerService
{
    private readonly ISchedulerFactory _schedulerFactory;
    private readonly IJobFactory _jobFactory;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IMapper _mapper;
    private IScheduler _scheduler;

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

    async Task IHostedService.StartAsync(CancellationToken cancellationToken)
    {
        _scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
        _scheduler.JobFactory = _jobFactory;

        await _scheduler.Start(cancellationToken);

        //using (var scope = _scopeFactory.CreateScope())
        //{
        //    var dataLoader = scope.ServiceProvider.GetRequiredService<ISchedulerDataLoader>();

        //    IEnumerable<SchedulerEvent> @events = await dataLoader.GetSchedulerEvents();
        //    IEnumerable<SchedulerReminder> reminders = await dataLoader.GetSchedulerReminders();
        //    IEnumerable<SchedulerTask> tasks = await dataLoader.GetSchedulerTasks();

        //    foreach (var @event in @events)
        //    {
        //        await _scheduler.ScheduleEvent(@event);
        //    }

        //    foreach (var reminder in reminders)
        //    {
        //        await _scheduler.ScheduleReminder(reminder);
        //    }

        //    foreach (var task in tasks)
        //    {
        //        await _scheduler.ScheduleTask(task);
        //    }
        //}
    }

    async Task IHostedService.StopAsync(CancellationToken cancellationToken)
    {
        await _scheduler?.Shutdown(cancellationToken);
    }

    public async Task ScheduleTaskAsync(SchedulerTask task)
    {
        await _scheduler.ScheduleTask(task);
    }

    public async Task RescheduleTaskAsync(SchedulerTask task)
    {
        await _scheduler.RescheduleTask(task);
    }

    public async Task UnscheduleTaskAsync(SchedulerTask task)
    {
        await _scheduler.UnscheduleTask(task);
    }

    public async Task ScheduleEventAsync(SchedulerEvent @event)
    {
        await _scheduler.ScheduleEvent(@event);
    }

    public async Task RescheduleEventAsync(SchedulerEvent @event)
    {
        await _scheduler.RescheduleEvent(@event);
    }

    public async Task UnscheduleEventAsync(SchedulerEvent @event)
    {
        await _scheduler.UnscheduleEvent(@event);
    }

    public async Task ScheduleReminderAsync(SchedulerReminder reminder)
    {
        await _scheduler.ScheduleReminder(reminder);
    }

    public async Task RescheduleReminderAsync(SchedulerReminder reminder)
    {
        await _scheduler.RescheduleReminder(reminder);
    }

    public async Task UnscheduleReminderAsync(SchedulerReminder reminder)
    {
        await _scheduler.UnscheduleReminder(reminder);
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
}
