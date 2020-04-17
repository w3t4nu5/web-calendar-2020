﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCalendar.DAL.Models.Entities;

namespace WebCalendar.DAL.EF.Configurations
{
    public class ReminderConfiguration : RepeatableActivityConfiguration<Reminder>
    {
        public override void Configure(EntityTypeBuilder<Reminder> builder)
        {
            ConvertFieds(builder);
        }
    }
}