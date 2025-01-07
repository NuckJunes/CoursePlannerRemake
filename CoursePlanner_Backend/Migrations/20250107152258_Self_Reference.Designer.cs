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
    [Migration("20250107152258_Self_Reference")]
    partial class Self_Reference
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
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("semester")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("Id");

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

                    b.Property<int>("Credit_Hours")
                        .HasColumnType("int");

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
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoursePlanner_Backend.Model.Entities.Schedule", "schedule")
                        .WithMany("classes")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("schedule");
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.Schedule", b =>
                {
                    b.HasOne("CoursePlanner_Backend.Model.Entities.User", "user")
                        .WithMany("schedules")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("CoursePlanner_Backend.Model.Entities.Course", b =>
                {
                    b.Navigation("Classes");
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
