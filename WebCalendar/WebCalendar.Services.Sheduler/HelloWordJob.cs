﻿using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Threading.Tasks;

[DisallowConcurrentExecution]
public class HelloWorldJob : IJob
{
    private readonly ILogger<HelloWorldJob> _logger;
    public static readonly string JobDataKey = "key1";
    public static readonly string JobActivityTypeKey = "key2";

    public HelloWorldJob(ILogger<HelloWorldJob> logger)
    {
        _logger = logger;
    }

    public Task Execute(IJobExecutionContext context)
    {
        JobDataMap jobDataMap = context.JobDetail.JobDataMap;

        string value = jobDataMap.GetString(JobDataKey);
        _logger.LogInformation(value);
        return Task.CompletedTask;
    }
}