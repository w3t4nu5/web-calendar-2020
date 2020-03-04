using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCalendar.DAL.Models.Entities;

namespace WebCalendar.DAL.EF.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.CalendarUsers)
                .WithOne(cu => cu.User)
                .HasForeignKey(cu => cu.UserId);

            builder.HasMany(u => u.UserEvents)
                .WithOne(ue => ue.User)
                .HasForeignKey(ue => ue.UserId);

            builder.HasMany(u => u.Calendars)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
        }
    }
}