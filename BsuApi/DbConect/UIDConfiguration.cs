using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DbApi.DbConect
{
    public class UIDConfiguration : IEntityTypeConfiguration<UID>
    {
        public void Configure(EntityTypeBuilder<UID> builder)
        {
            builder.HasOne(u => u.Users)
                .WithMany(r => r.UIDs)
                .HasForeignKey(u => u.UserId);
        }
    }
}
