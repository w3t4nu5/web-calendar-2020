using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCalendar.DAL.Models.Entities;

namespace WebCalendar.DAL.EF.Configurations
{
    public class ReminderConfiguration : IEntityTypeConfiguration<Reminder>
    {
        public void Configure(EntityTypeBuilder<Reminder> builder)
        {
            builder.HasOne(r => r.Calendar)
                .WithMany(c => c.Reminders)
                .HasForeignKey(r => r.CalendarId);
        }
    }
}