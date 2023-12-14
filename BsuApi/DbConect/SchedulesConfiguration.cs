using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace DbApi.DbConect
{
    public class SchedulesConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasOne(u => u.CorseGroups)
                .WithMany(r => r.Schedules)
                .HasForeignKey(u => u.CGId);
            builder.HasOne(u => u.DayTimes)
                .WithMany(r => r.Schedules)
                .HasForeignKey(u => u.DayId);
            builder.HasOne(u => u.LessonForms)
                .WithMany(r => r.Schedules)
                .HasForeignKey(u => u.IdForm);
        }
    }
}
