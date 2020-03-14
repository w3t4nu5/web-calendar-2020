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
                    Id = new Guid(),
                    Value = DayOfWeek.Sunday
                },
                new Day
                {
                    Id = new Guid(),
                    Value = DayOfWeek.Monday
                }, 
                new Day
                {
                    Id = new Guid(),
                    Value = DayOfWeek.Tuesday
                },
                new Day
                {
                    Id = new Guid(),
                    Value = DayOfWeek.Wednesday
                }, 
                new Day
                {
                    Id = new Guid(),
                    Value = DayOfWeek.Thursday
                }, 
                new Day
                {
                    Id = new Guid(),
                    Value = DayOfWeek.Friday
                }, 
                new Day
                {
                    Id = new Guid(),
                    Value = DayOfWeek.Saturday
                }
            );
        }
    }
}
