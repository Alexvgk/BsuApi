﻿// <auto-generated />
using System;
using DbConect;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BsuApi.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.CourseGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Course")
                        .HasColumnType("longtext");

                    b.Property<string>("Group")
                        .HasColumnType("longtext");

                    b.Property<string>("Speciality")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CourseGroups");
                });

            modelBuilder.Entity("Model.DayTime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Day")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DayTimes");
                });

            modelBuilder.Entity("Model.LessonForm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Form")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("lessonForms");
                });

            modelBuilder.Entity("Model.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CourseGroupId")
                        .HasColumnType("char(36)");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("longblob");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CourseGroupId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("Model.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("UserRole")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Model.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CGId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Classroom")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("DayId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("IdForm")
                        .HasColumnType("char(36)");

                    b.Property<string>("Lecture")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Time")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CGId");

                    b.HasIndex("DayId");

                    b.HasIndex("IdForm");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Model.UID", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Uid")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Uids");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("IdCourseGroup")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("IdRole")
                        .HasColumnType("char(36)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("SecondName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdCourseGroup");

                    b.HasIndex("IdRole");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Model.News", b =>
                {
                    b.HasOne("Model.CourseGroup", "CourseGroup")
                        .WithMany("News")
                        .HasForeignKey("CourseGroupId");

                    b.Navigation("CourseGroup");
                });

            modelBuilder.Entity("Model.Schedule", b =>
                {
                    b.HasOne("Model.CourseGroup", "CorseGroups")
                        .WithMany("Schedules")
                        .HasForeignKey("CGId");

                    b.HasOne("Model.DayTime", "DayTimes")
                        .WithMany("Schedules")
                        .HasForeignKey("DayId");

                    b.HasOne("Model.LessonForm", "LessonForms")
                        .WithMany("Schedules")
                        .HasForeignKey("IdForm");

                    b.Navigation("CorseGroups");

                    b.Navigation("DayTimes");

                    b.Navigation("LessonForms");
                });

            modelBuilder.Entity("Model.UID", b =>
                {
                    b.HasOne("Model.User", "Users")
                        .WithMany("UIDs")
                        .HasForeignKey("UserId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.HasOne("Model.CourseGroup", "CorseGroup")
                        .WithMany("Users")
                        .HasForeignKey("IdCourseGroup");

                    b.HasOne("Model.Role", "Roles")
                        .WithMany("Users")
                        .HasForeignKey("IdRole");

                    b.Navigation("CorseGroup");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Model.CourseGroup", b =>
                {
                    b.Navigation("News");

                    b.Navigation("Schedules");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Model.DayTime", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Model.LessonForm", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Model.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.Navigation("UIDs");
                });
#pragma warning restore 612, 618
        }
    }
}