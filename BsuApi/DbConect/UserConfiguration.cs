using Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DbConect
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(u => u.Roles)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.IdRole);
            builder.HasOne(u => u.CorseGroup)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.IdCourseGroup);
        }
    }
}
