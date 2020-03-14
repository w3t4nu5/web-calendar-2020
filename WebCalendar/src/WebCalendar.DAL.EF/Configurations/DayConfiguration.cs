using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCalendar.DAL.Models.Entities;

namespace WebCalendar.DAL.EF.Configurations
{
    public class DayConfiguration : IEntityTypeConfiguration<Day>
    {
        public void Configure(EntityTypeBuilder<Day> builder)
        {
            builder.HasMany(e => e.EventDays)
                .WithOne(ue => ue.Day)
                .HasForeignKey(ue => ue.DayId);

            builder.HasMany(e => e.ReminderDays)
                .WithOne(ue => ue.Day)
                .HasForeignKey(ue => ue.DayId);

            builder.HasData(
                new Day
                {
                    Id = Guid.NewGuid(),
                    Value = DayOfWeek.Sunday
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Value = DayOfWeek.Monday
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Value = DayOfWeek.Tuesday
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Value = DayOfWeek.Wednesday
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Value = DayOfWeek.Thursday
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Value = DayOfWeek.Friday
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Value = DayOfWeek.Saturday
                }
            );
        }
    }
}
