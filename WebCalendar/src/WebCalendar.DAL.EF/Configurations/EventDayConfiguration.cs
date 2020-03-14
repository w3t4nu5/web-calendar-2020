using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCalendar.DAL.Models.Entities;

namespace WebCalendar.DAL.EF.Configurations
{
    class EventDayConfiguration : IEntityTypeConfiguration<EventDay>
    {
        public void Configure(EntityTypeBuilder<EventDay> builder)
        {
            builder.HasKey(ed => new
            {
                ed.EventId, 
                ed.DayId
            });

            builder.HasOne(ed => ed.Event)
                .WithMany(e => e.EventDays)
                .HasForeignKey(ed => ed.EventId);

            builder.HasOne(ed => ed.Day)
                .WithMany(d => d.EventDays)
                .HasForeignKey(ed => ed.DayId);
        }
    }
}
