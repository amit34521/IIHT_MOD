﻿// <auto-generated />
using MOD.SkillsService.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MOD.SkillsService.Migrations
{
    [DbContext(typeof(SkillContext))]
    partial class SkillContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MOD.SkillsService.Models.Skill", b =>
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
#pragma warning restore 612, 618
        }
    }
}
