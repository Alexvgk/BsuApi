using Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DbConect
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(u => u.userRole)
                .WithMany(r => r.users)
                .HasForeignKey(u => u.IdRole);
            builder.HasOne(u => u.CorseGroup)
                .WithMany(r => r.users)
                .HasForeignKey(u => u.IdCourseGroup);
        }
    }
}
