﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OdevTakip.Data;

namespace OdevTakip.Data.Migrations
{
    [DbContext(typeof(OdevTakipContext))]
    [Migration("20190529224335_filesadded")]
    partial class filesadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OdevTakip.Data.Model.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("HomeworkId");

                    b.Property<string>("Path");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("HomeworkId");

                    b.HasIndex("StudentId");

                    b.ToTable("File");
                });

            modelBuilder.Entity("OdevTakip.Data.Model.Homework", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("LessonId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("Homeworks");
                });

            modelBuilder.Entity("OdevTakip.Data.Model.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name");

                    b.Property<string>("Period");

                    b.Property<int>("TeacherId");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("OdevTakip.Data.Model.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("SchoolNumber");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("OdevTakip.Data.Model.StudentLesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LessonId");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentLessons");
                });

            modelBuilder.Entity("OdevTakip.Data.Model.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("OdevTakip.Data.Model.File", b =>
                {
                    b.HasOne("OdevTakip.Data.Model.Homework", "Homework")
                        .WithMany("Files")
                        .HasForeignKey("HomeworkId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OdevTakip.Data.Model.Student", "Student")
                        .WithMany("Files")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OdevTakip.Data.Model.Homework", b =>
                {
                    b.HasOne("OdevTakip.Data.Model.Lesson", "Lesson")
                        .WithMany("Homeworks")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OdevTakip.Data.Model.Lesson", b =>
                {
                    b.HasOne("OdevTakip.Data.Model.Teacher", "Teacher")
                        .WithMany("Lessons")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OdevTakip.Data.Model.StudentLesson", b =>
                {
                    b.HasOne("OdevTakip.Data.Model.Lesson", "Lesson")
                        .WithMany("StudentLessons")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OdevTakip.Data.Model.Student", "Student")
                        .WithMany("StudentLessons")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}