﻿// <auto-generated />
using System;
using MOD.PaymentService.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MOD.PaymentService.Migrations
{
    [DbContext(typeof(PaymentsContext))]
    [Migration("20191114134829_PaymentsMigration")]
    partial class PaymentsMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MOD.PaymentService.Models.Mentor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("TrainingId");

                    b.Property<bool>("active");

                    b.Property<bool>("confirmedSignup");

                    b.Property<long>("contactNumber");

                    b.Property<string>("firstName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("lastName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("linkedinUrl")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("registrationCode")
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("resetPassword");

                    b.Property<DateTime>("resetPasswordDate");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("yearsOfExperience");

                    b.HasKey("Id");

                    b.HasIndex("TrainingId");

                    b.ToTable("Mentors");
                });

            modelBuilder.Entity("MOD.PaymentService.Models.Payment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("amount");

                    b.Property<DateTime>("datetime");

                    b.Property<long>("mentorId");

                    b.Property<string>("mentorName")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("remarks");

                    b.Property<long>("trainingId");

                    b.Property<string>("txnType")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("mentorId");

                    b.HasIndex("trainingId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("MOD.PaymentService.Models.Skill", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Fees");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Prerequisites")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("TOC")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("duration");

                    b.HasKey("ID");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("MOD.PaymentService.Models.Training", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("amountReceived");

                    b.Property<DateTime>("endDate");

                    b.Property<string>("endTime");

                    b.Property<string>("mentorName")
                        .HasColumnType("varchar(100)");

                    b.Property<long>("mentorsId");

                    b.Property<int>("progress");

                    b.Property<float>("rating");

                    b.Property<long>("skillId");

                    b.Property<string>("skillName")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("startDate");

                    b.Property<string>("startTime");

                    b.Property<string>("status")
                        .HasColumnType("varchar(1)");

                    b.Property<long>("userId");

                    b.Property<string>("userName")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("skillId")
                        .IsUnique();

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("MOD.PaymentService.Models.Mentor", b =>
                {
                    b.HasOne("MOD.PaymentService.Models.Training", "Training")
                        .WithMany()
                        .HasForeignKey("TrainingId");
                });

            modelBuilder.Entity("MOD.PaymentService.Models.Payment", b =>
                {
                    b.HasOne("MOD.PaymentService.Models.Mentor", "Mentor")
                        .WithMany()
                        .HasForeignKey("mentorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MOD.PaymentService.Models.Training", "Training")
                        .WithMany()
                        .HasForeignKey("trainingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MOD.PaymentService.Models.Training", b =>
                {
                    b.HasOne("MOD.PaymentService.Models.Skill", "Skill")
                        .WithOne("Training")
                        .HasForeignKey("MOD.PaymentService.Models.Training", "skillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
