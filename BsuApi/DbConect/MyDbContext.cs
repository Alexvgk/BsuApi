using Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DbApi.DbConect;

namespace DbConect
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> users { get; set;} = null!;
        public DbSet<UID> Uid { get; set; } = null!;
        public DbSet<CourseGroup> CourseGroup { get; set; } = null!;

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                 .HasKey(x => x.Id);
            modelBuilder.Entity<User>()
                .Property(x => x.Id)
                .HasColumnType("char(36)");
            modelBuilder.Entity<UID>()
                .HasKey(r => r.Id);
            modelBuilder.Entity<UID>()
                .Property(x => x.Id)
                .HasColumnType("char(36)");
            modelBuilder.Entity<CourseGroup>()
                 .HasKey(r => r.Id);
            modelBuilder.Entity<CourseGroup>()
                .Property(x => x.Id)
                .HasColumnType("char(36)");
            modelBuilder.Entity<Role>()
                .HasKey(r => r.Id);
            modelBuilder.Entity<Role>()
                .Property(x => x.Id)
                .HasColumnType("char(36)");
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new UIDConfiguration());

        }
    }
}