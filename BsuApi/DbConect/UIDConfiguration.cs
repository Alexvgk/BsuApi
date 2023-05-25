using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DbApi.DbConect
{
    public class UIDConfiguration : IEntityTypeConfiguration<UID>
    {
        public void Configure(EntityTypeBuilder<UID> builder)
        {
            builder.HasOne(u => u.User)
                .WithMany(r => r.uIDs)
                .HasForeignKey(u => u.UserId);
        }
    }
}
