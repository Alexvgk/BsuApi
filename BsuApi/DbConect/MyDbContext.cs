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
        public DbSet<User> Users { get; set;} = null!;
        public DbSet<UID> Uids { get; set; } = null!;
        public DbSet<CourseGroup> CourseGroups { get; set; } = null!;
        public DbSet<DayTime> DayTimes { get; set; } = null!;
        public DbSet<LessonForm> lessonForms { get; set; } = null!;
        public DbSet<News> News { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Schedule> Schedules { get; set; } = null!;


        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
           // Database.EnsureCreated();
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
            modelBuilder.Entity<News>()
               .Property(x => x.Id)
               .HasColumnType("char(36)");
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SchedulesConfiguration());
            modelBuilder.ApplyConfiguration(new UIDConfiguration());

        }
    }
}