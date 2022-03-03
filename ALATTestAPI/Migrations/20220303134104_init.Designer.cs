﻿// <auto-generated />
using System;
using ALATTestAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ALATTestAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220303134104_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ALATTestAPI.Models.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("lgaid")
                        .HasColumnType("int");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("stateid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("lgaid");

                    b.HasIndex("stateid");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("ALATTestAPI.Models.LGA", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Stateid")
                        .HasColumnType("int");

                    b.Property<string>("lganame")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Stateid");

                    b.ToTable("lGAs");
                });

            modelBuilder.Entity("ALATTestAPI.Models.OTP", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("count")
                        .HasColumnType("int");

                    b.Property<string>("otpvalue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("oTPs");
                });

            modelBuilder.Entity("ALATTestAPI.Models.State", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("statename")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("ALATTestAPI.Models.Customer", b =>
                {
                    b.HasOne("ALATTestAPI.Models.LGA", "lga")
                        .WithMany()
                        .HasForeignKey("lgaid");

                    b.HasOne("ALATTestAPI.Models.State", "state")
                        .WithMany()
                        .HasForeignKey("stateid");

                    b.Navigation("lga");

                    b.Navigation("state");
                });

            modelBuilder.Entity("ALATTestAPI.Models.LGA", b =>
                {
                    b.HasOne("ALATTestAPI.Models.State", null)
                        .WithMany("lGAs")
                        .HasForeignKey("Stateid");
                });

            modelBuilder.Entity("ALATTestAPI.Models.State", b =>
                {
                    b.Navigation("lGAs");
                });
#pragma warning restore 612, 618
        }
    }
}