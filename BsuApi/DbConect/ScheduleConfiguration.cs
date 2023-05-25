using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace DbApi.DbConect
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasOne(u => u.CorseGroup)
                .WithMany(r => r.schedules)
                .HasForeignKey(u => u.CGId);
            builder.HasOne(u => u.DayTime)
                .WithMany(r => r.Schedules)
                .HasForeignKey(u => u.DayId);
            builder.HasOne(u => u.LessonForm)
                .WithMany(r => r.Schedules)
                .HasForeignKey(u => u.IdForm);
        }
    }
}
