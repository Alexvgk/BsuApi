using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System.Reflection.Emit;

namespace BsuApi.DbConect
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> modelBuilder)
        {
            modelBuilder.HasOne(n => n.CourseGroup)
            .WithMany(c => c.News)
            .HasForeignKey(n => n.CourseGroupId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
