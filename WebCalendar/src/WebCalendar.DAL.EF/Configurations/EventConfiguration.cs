using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCalendar.DAL.Models.Entities;

namespace WebCalendar.DAL.EF.Configurations
{
    public class EventConfiguration : RepeatableActivityConfiguration<Event>
    {
        public override void Configure(EntityTypeBuilder<Event> builder)
        {
            ConvertFieds(builder);
        }
    }
}