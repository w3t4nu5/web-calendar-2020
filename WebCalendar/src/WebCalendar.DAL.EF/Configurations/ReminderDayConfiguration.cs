using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCalendar.DAL.Models.Entities;

namespace WebCalendar.DAL.EF.Configurations
{
    public class ReminderDayConfiguration : IEntityTypeConfiguration<ReminderDay>
    {
        public void Configure(EntityTypeBuilder<ReminderDay> builder)
        {
            builder.HasKey(ed => new
            {
                ed.ReminderId,
                ed.DayId
            });

            builder.HasOne(rd => rd.Reminder)
                .WithMany(r => r.ReminderDays)
                .HasForeignKey(rd => rd.ReminderId);

            builder.HasOne(rd => rd.Day)
                .WithMany(d => d.ReminderDays)
                .HasForeignKey(rd => rd.DayId);
        }
    }
}
