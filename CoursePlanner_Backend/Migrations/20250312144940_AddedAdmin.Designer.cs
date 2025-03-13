﻿// <auto-generated />
using CoursePlanner_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoursePlanner_Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250312144940_AddedAdmin")]
    partial class AddedAdmin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CampusCourse", b =>
                {
                    b.Property<int>("CampusesId")
                        .HasColumnType("int");

                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.HasKey("CampusesId", "CoursesId");

                    b.HasIndex("CoursesId");

                    b.ToTable("CampusCourse");
                });

            modelBuilder.Entity("CourseCourse", b =>
                {
                    b.Property<int>("PrerequisitesId")
                        .HasColumnType("int");

                    b.Property<int>("RequirementsId")
                        .HasColumnType("int");

                    b.HasKey("PrerequisitesId", "RequirementsId");

                    b.HasIndex("RequirementsId");

                    b.ToTable("CourseCourse");
                });

            modelBuilder.Entity("CourseFeature", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("FeaturesId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "FeaturesId");

                    b.HasIndex("FeaturesId");

                    b.ToTable("CourseFeature");
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.Campus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Campuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Hamilton"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Luxembourg"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Middletown"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Oxford"
                        },
                        new
                        {
                            Id = 5,
                            Name = "West Chester"
                        });
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("courseId")
                        .HasColumnType("int");

                    b.Property<int>("scheduleId")
                        .HasColumnType("int");

                    b.Property<string>("semester")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("courseId");

                    b.HasIndex("scheduleId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Course_Number")
                        .HasColumnType("int");

                    b.Property<double>("Credit_Hours")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Course_Number = 102,
                            Credit_Hours = 1.0,
                            Description = "A entry level course",
                            Name = "Computer Science Entry",
                            Subject = "CSE"
                        });
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Short_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Features");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Advanced Writing",
                            Short_Name = "PA"
                        });
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.Major", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("College")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Credit_Max")
                        .HasColumnType("float");

                    b.Property<double>("Credit_Min")
                        .HasColumnType("float");

                    b.Property<bool>("Graduate")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Major");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            College = "College of Computer Science",
                            Credit_Max = 98.0,
                            Credit_Min = 92.0,
                            Graduate = false,
                            Name = "Software Engineering"
                        });
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Credit_Max")
                        .HasColumnType("float");

                    b.Property<double>("Credit_Min")
                        .HasColumnType("float");

                    b.Property<int>("MajorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MajorId");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Admin = false,
                            Email = "Email@Email.com",
                            Password = "Password",
                            Username = "Username"
                        });
                });

            modelBuilder.Entity("CourseSection", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("SectionsId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "SectionsId");

                    b.HasIndex("SectionsId");

                    b.ToTable("CourseSection");
                });

            modelBuilder.Entity("CampusCourse", b =>
                {
                    b.HasOne("CoursePlanner_Backend.Model.Entities.Campus", null)
                        .WithMany()
                        .HasForeignKey("CampusesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoursePlanner_Backend.Model.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseCourse", b =>
                {
                    b.HasOne("CoursePlanner_Backend.Model.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("PrerequisitesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoursePlanner_Backend.Model.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("RequirementsId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseFeature", b =>
                {
                    b.HasOne("CoursePlanner_Backend.Model.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoursePlanner_Backend.Model.Entities.Feature", null)
                        .WithMany()
                        .HasForeignKey("FeaturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.Class", b =>
                {
                    b.HasOne("CoursePlanner_Backend.Model.Entities.Course", "course")
                        .WithMany("Classes")
                        .HasForeignKey("courseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoursePlanner_Backend.Model.Entities.Schedule", "schedule")
                        .WithMany("classes")
                        .HasForeignKey("scheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("schedule");
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.Schedule", b =>
                {
                    b.HasOne("CoursePlanner_Backend.Model.Entities.User", "user")
                        .WithMany("schedules")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.Section", b =>
                {
                    b.HasOne("CoursePlanner_Backend.Model.Entities.Major", "Major")
                        .WithMany("Sections")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Major");
                });

            modelBuilder.Entity("CourseSection", b =>
                {
                    b.HasOne("CoursePlanner_Backend.Model.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoursePlanner_Backend.Model.Entities.Section", null)
                        .WithMany()
                        .HasForeignKey("SectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.Course", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.Major", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.Schedule", b =>
                {
                    b.Navigation("classes");
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.User", b =>
                {
                    b.Navigation("schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
