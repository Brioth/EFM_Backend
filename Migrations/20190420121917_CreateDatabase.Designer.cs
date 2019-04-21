﻿// <auto-generated />
using System;
using EFM_Backend.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFM_Backend.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190420121917_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFM_Backend.API.Domain.Models.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Assignments");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Assignment");
                });

            modelBuilder.Entity("EFM_Backend.API.Domain.Models.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("EFM_Backend.API.Domain.Models.ResourceAssignment", b =>
                {
                    b.Property<int>("ResourceId");

                    b.Property<int>("AssignmentId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.HasKey("ResourceId", "AssignmentId");

                    b.HasIndex("AssignmentId");

                    b.ToTable("ResourceAssignments");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ResourceAssignment");
                });

            modelBuilder.Entity("EFM_Backend.API.Domain.Models.Assignment_Fixed", b =>
                {
                    b.HasBaseType("EFM_Backend.API.Domain.Models.Assignment");

                    b.Property<double>("HoursPerOccurence");

                    b.Property<byte>("Occurence");

                    b.HasDiscriminator().HasValue("Assignment_Fixed");
                });

            modelBuilder.Entity("EFM_Backend.API.Domain.Models.Assignment_Variable", b =>
                {
                    b.HasBaseType("EFM_Backend.API.Domain.Models.Assignment");

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("ManDays");

                    b.HasDiscriminator().HasValue("Assignment_Variable");
                });

            modelBuilder.Entity("EFM_Backend.API.Domain.Models.ResourceAssignment_Fixed", b =>
                {
                    b.HasBaseType("EFM_Backend.API.Domain.Models.ResourceAssignment");

                    b.Property<double>("HoursPerOccurence");

                    b.Property<byte>("Occurence");

                    b.HasDiscriminator().HasValue("ResourceAssignment_Fixed");
                });

            modelBuilder.Entity("EFM_Backend.API.Domain.Models.ResourceAssignment_Variable", b =>
                {
                    b.HasBaseType("EFM_Backend.API.Domain.Models.ResourceAssignment");

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("ManDays");

                    b.HasDiscriminator().HasValue("ResourceAssignment_Variable");
                });

            modelBuilder.Entity("EFM_Backend.API.Domain.Models.ResourceAssignment", b =>
                {
                    b.HasOne("EFM_Backend.API.Domain.Models.Assignment", "Assignment")
                        .WithMany("ResourceAssignments")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFM_Backend.API.Domain.Models.Resource", "Resource")
                        .WithMany("ResourceAssignments")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
