using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DbApi.DbConect
{
    public class RegCodeConfiguration : IEntityTypeConfiguration<RegCode>
    {
        public void Configure(EntityTypeBuilder<RegCode> builder)
        {
            builder.HasOne(u => u.User)
                .WithOne(r => r.RegCode)
                .HasForeignKey<RegCode>(u => u.UserId);
        }
    }
}
