﻿// <auto-generated />
using System;
using MaterialSupport.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MaterialSupport.DB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220531161902_AddAttributesForTablesFields")]
    partial class AddAttributesForTablesFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MaterialSupport.DB.Models.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.ApplicationsCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ApplicationsCategories");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.ApplicationsDocuments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<int?>("DocumentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("DocumentId");

                    b.ToTable("ApplicationsDocuments");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.ApplicationsSupportTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<int?>("SupportTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("SupportTypeId");

                    b.ToTable("ApplicationsSupportTypes");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Lastname")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Surname")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Birthplace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Citizenship")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Surname")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.StudentContacts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique()
                        .HasFilter("[StudentId] IS NOT NULL");

                    b.ToTable("StudentContacts");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.SupportType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SupportTypes");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.Application", b =>
                {
                    b.HasOne("MaterialSupport.DB.Models.Student", "Student")
                        .WithMany("Applications")
                        .HasForeignKey("StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.ApplicationsCategories", b =>
                {
                    b.HasOne("MaterialSupport.DB.Models.Application", "Application")
                        .WithMany("Categories")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("MaterialSupport.DB.Models.Category", "Category")
                        .WithMany("Applications")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Application");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.ApplicationsDocuments", b =>
                {
                    b.HasOne("MaterialSupport.DB.Models.Application", "Application")
                        .WithMany("Documents")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("MaterialSupport.DB.Models.Document", "Document")
                        .WithMany("Applications")
                        .HasForeignKey("DocumentId");

                    b.Navigation("Application");

                    b.Navigation("Document");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.ApplicationsSupportTypes", b =>
                {
                    b.HasOne("MaterialSupport.DB.Models.Application", "Application")
                        .WithMany("SupportTypes")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("MaterialSupport.DB.Models.SupportType", "SupportType")
                        .WithMany("Applications")
                        .HasForeignKey("SupportTypeId");

                    b.Navigation("Application");

                    b.Navigation("SupportType");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.Employee", b =>
                {
                    b.HasOne("MaterialSupport.DB.Models.User", "User")
                        .WithOne("Employee")
                        .HasForeignKey("MaterialSupport.DB.Models.Employee", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.Student", b =>
                {
                    b.HasOne("MaterialSupport.DB.Models.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("MaterialSupport.DB.Models.Student", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.StudentContacts", b =>
                {
                    b.HasOne("MaterialSupport.DB.Models.Student", "Student")
                        .WithOne("Contacts")
                        .HasForeignKey("MaterialSupport.DB.Models.StudentContacts", "StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.Application", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Documents");

                    b.Navigation("SupportTypes");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.Category", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.Document", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.Student", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.SupportType", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("MaterialSupport.DB.Models.User", b =>
                {
                    b.Navigation("Employee");

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
