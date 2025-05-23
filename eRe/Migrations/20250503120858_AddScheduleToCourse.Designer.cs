﻿// <auto-generated />
using System;
using ERE.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace eRe.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250503120858_AddScheduleToCourse")]
    partial class AddScheduleToCourse
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ERE.Models.Contact", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Commune")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HomeNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ParentId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Village")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ERE.Models.Course", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int[]>("CourseDays")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<int[]>("CourseTimes")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<int>("LevelId")
                        .HasColumnType("integer");

                    b.Property<float>("MaxScore")
                        .HasColumnType("real");

                    b.Property<float>("PassingRate")
                        .HasColumnType("real");

                    b.Property<int>("SubjectId")
                        .HasColumnType("integer");

                    b.Property<string>("TeacherId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ERE.Models.CourseReport", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("Absences")
                        .HasColumnType("integer");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("EnrollmentId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("GradeId")
                        .HasColumnType("integer");

                    b.Property<string>("MainReportId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MainReport__rId")
                        .HasColumnType("text");

                    b.Property<int>("MonthId")
                        .HasColumnType("integer");

                    b.Property<string>("ParentCmt")
                        .HasColumnType("text");

                    b.Property<float>("Score")
                        .HasColumnType("real");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TeacherCmt")
                        .HasColumnType("text");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("EnrollmentId");

                    b.HasIndex("MainReportId");

                    b.HasIndex("MainReport__rId");

                    b.ToTable("CourseReports");
                });

            modelBuilder.Entity("ERE.Models.Enrollment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LevelId")
                        .HasColumnType("integer");

                    b.Property<string>("StudentEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TeacherId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasAlternateKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("ERE.Models.MainReports", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LevelId")
                        .HasColumnType("integer");

                    b.Property<int>("MonthId")
                        .HasColumnType("integer");

                    b.Property<string>("ParentCmt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("StudentEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasAlternateKey("StudentId", "MonthId", "LevelId");

                    b.ToTable("MainReports");
                });

            modelBuilder.Entity("ERE.Models.Parent", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("ERE.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Teacher"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Student"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Parent"
                        });
                });

            modelBuilder.Entity("ERE.Models.Student", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LevelId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ERE.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Subject");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Math"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Science"
                        },
                        new
                        {
                            Id = 3,
                            Name = "English"
                        },
                        new
                        {
                            Id = 4,
                            Name = "History"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Geography"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Physical Education"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Art"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Music"
                        });
                });

            modelBuilder.Entity("ERE.Models.Teacher", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SubjectId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("ERE.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DefaultPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ERE.Models.Contact", b =>
                {
                    b.HasOne("ERE.Models.Parent", null)
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERE.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ERE.Models.Course", b =>
                {
                    b.HasOne("ERE.Models.Subject", "Subject__r")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERE.Models.Teacher", "Teacher__r")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject__r");

                    b.Navigation("Teacher__r");
                });

            modelBuilder.Entity("ERE.Models.CourseReport", b =>
                {
                    b.HasOne("ERE.Models.Enrollment", "Enrollment__r")
                        .WithMany()
                        .HasForeignKey("EnrollmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERE.Models.MainReports", null)
                        .WithMany("CourseReports")
                        .HasForeignKey("MainReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERE.Models.MainReports", "MainReport__r")
                        .WithMany()
                        .HasForeignKey("MainReport__rId");

                    b.Navigation("Enrollment__r");

                    b.Navigation("MainReport__r");
                });

            modelBuilder.Entity("ERE.Models.Enrollment", b =>
                {
                    b.HasOne("ERE.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERE.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ERE.Models.Parent", b =>
                {
                    b.HasOne("ERE.Models.User", "User__r")
                        .WithOne()
                        .HasForeignKey("ERE.Models.Parent", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User__r");
                });

            modelBuilder.Entity("ERE.Models.Student", b =>
                {
                    b.HasOne("ERE.Models.User", "User__r")
                        .WithOne()
                        .HasForeignKey("ERE.Models.Student", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User__r");
                });

            modelBuilder.Entity("ERE.Models.Teacher", b =>
                {
                    b.HasOne("ERE.Models.Subject", "Subject__r")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERE.Models.User", "User__r")
                        .WithOne()
                        .HasForeignKey("ERE.Models.Teacher", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject__r");

                    b.Navigation("User__r");
                });

            modelBuilder.Entity("ERE.Models.User", b =>
                {
                    b.HasOne("ERE.Models.Role", "Role__r")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role__r");
                });

            modelBuilder.Entity("ERE.Models.MainReports", b =>
                {
                    b.Navigation("CourseReports");
                });
#pragma warning restore 612, 618
        }
    }
}
