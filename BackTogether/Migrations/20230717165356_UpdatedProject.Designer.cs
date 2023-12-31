﻿// <auto-generated />
using System;
using BackTogether.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackTogether.Migrations
{
    [DbContext(typeof(BackTogetherContext))]
    [Migration("20230717165356_UpdatedProject")]
    partial class UpdatedProject
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackTogether.Models.Backing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateBacked")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Backings");
                });

            modelBuilder.Entity("BackTogether.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Category")
                        .HasColumnType("int");

                    b.Property<decimal>("CurrentFunding")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FinalGoal")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("BackTogether.Models.ResourceURL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ResourceURL");
                });

            modelBuilder.Entity("BackTogether.Models.Reward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BackingId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnlockAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BackingId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Rewards");
                });

            modelBuilder.Entity("BackTogether.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasAdminPrivileges")
                        .HasColumnType("bit");

                    b.Property<int?>("ImageURLId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageURLId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "example@email.com",
                            HasAdminPrivileges = true,
                            Password = "NZ#7eYB%",
                            Username = "aFEf4w4f"
                        },
                        new
                        {
                            Id = 2,
                            Email = "example1@email.com",
                            HasAdminPrivileges = true,
                            Password = "6*%7rKNd",
                            Username = "fa4gfwff"
                        },
                        new
                        {
                            Id = 3,
                            Email = "example2@email.com",
                            HasAdminPrivileges = false,
                            Password = "K^aB%s6T",
                            Username = "tejh56eu"
                        },
                        new
                        {
                            Id = 4,
                            Email = "example3@email.com",
                            HasAdminPrivileges = false,
                            Password = "Fg75^U@j",
                            Username = "f34g34qg"
                        },
                        new
                        {
                            Id = 5,
                            Email = "example4@email.com",
                            HasAdminPrivileges = false,
                            Password = "#VEGu3it",
                            Username = "fq34gqgf"
                        },
                        new
                        {
                            Id = 6,
                            Email = "example5@email.com",
                            HasAdminPrivileges = false,
                            Password = "Cnk@XH23",
                            Username = "qf34gq3g"
                        },
                        new
                        {
                            Id = 7,
                            Email = "example6@email.com",
                            HasAdminPrivileges = true,
                            Password = "HpKY6N%X",
                            Username = "f34qg4q3"
                        },
                        new
                        {
                            Id = 8,
                            Email = "example7@email.com",
                            HasAdminPrivileges = false,
                            Password = "P6@%R6%a",
                            Username = "n4eh6wqw"
                        });
                });

            modelBuilder.Entity("BackTogether.Models.Backing", b =>
                {
                    b.HasOne("BackTogether.Models.Project", "Project")
                        .WithMany("Backings")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("BackTogether.Models.User", "User")
                        .WithMany("Backings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BackTogether.Models.Project", b =>
                {
                    b.HasOne("BackTogether.Models.User", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("User");
                });

            modelBuilder.Entity("BackTogether.Models.ResourceURL", b =>
                {
                    b.HasOne("BackTogether.Models.Project", null)
                        .WithMany("ImageURLS")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("BackTogether.Models.Reward", b =>
                {
                    b.HasOne("BackTogether.Models.Backing", null)
                        .WithMany("RewardsUnlocked")
                        .HasForeignKey("BackingId");

                    b.HasOne("BackTogether.Models.Project", "Project")
                        .WithMany("Rewards")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("BackTogether.Models.User", b =>
                {
                    b.HasOne("BackTogether.Models.ResourceURL", "ImageURL")
                        .WithMany()
                        .HasForeignKey("ImageURLId");

                    b.Navigation("ImageURL");
                });

            modelBuilder.Entity("BackTogether.Models.Backing", b =>
                {
                    b.Navigation("RewardsUnlocked");
                });

            modelBuilder.Entity("BackTogether.Models.Project", b =>
                {
                    b.Navigation("Backings");

                    b.Navigation("ImageURLS");

                    b.Navigation("Rewards");
                });

            modelBuilder.Entity("BackTogether.Models.User", b =>
                {
                    b.Navigation("Backings");

                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
