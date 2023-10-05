﻿// <auto-generated />
using System;
using BackEndAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEndAPI.Data.DatabaseMigrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("BackEndAPI.Data.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("body")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("subtitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            Id = 8,
                            body = " LOL ",
                            date = "2-12-2023",
                            subtitle = "Subtitle 1",
                            title = "Title 1"
                        },
                        new
                        {
                            Id = 9,
                            body = " LOL ",
                            date = "3-12-2023",
                            subtitle = "Subtitle 2",
                            title = "Title 2"
                        },
                        new
                        {
                            Id = 10,
                            body = " LOL ",
                            date = "4-12-2023",
                            subtitle = "Subtitle 3",
                            title = "Title 3"
                        });
                });

            modelBuilder.Entity("BackEndAPI.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("passwordhash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("usertype")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("BackEndAPI.Data.Models.Admin", b =>
                {
                    b.HasBaseType("BackEndAPI.Data.Models.User");

                    b.Property<int>("AdminId")
                        .HasColumnType("INTEGER");

                    b.ToTable("Admins", (string)null);
                });

            modelBuilder.Entity("BackEndAPI.Data.Models.Case", b =>
                {
                    b.HasBaseType("BackEndAPI.Data.Models.User");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CaseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharityId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DonatorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Totalneeded")
                        .HasColumnType("INTEGER");

                    b.Property<int>("currentdonations")
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasIndex("CharityId");

                    b.HasIndex("DonatorId");

                    b.ToTable("Cases", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 4,
                            email = "ahmed@gmail.com",
                            passwordhash = "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C",
                            username = "ahmedtest",
                            usertype = "case",
                            Address = "Address Test",
                            CaseId = 1,
                            CharityId = 1,
                            Name = "Ahmed",
                            Status = "active",
                            Totalneeded = 5000,
                            currentdonations = 0,
                            description = "Debted for furniture"
                        },
                        new
                        {
                            Id = 5,
                            email = "engy@gmail.com",
                            passwordhash = "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C",
                            username = "engy",
                            usertype = "case",
                            Address = "Address Test",
                            CaseId = 2,
                            CharityId = 1,
                            Name = "Engy",
                            Status = "active",
                            Totalneeded = 5000,
                            currentdonations = 0,
                            description = "Case Description 2"
                        },
                        new
                        {
                            Id = 6,
                            email = "Omar@gmail.com",
                            passwordhash = "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C",
                            username = "omar",
                            usertype = "case",
                            Address = "Address Test",
                            CaseId = 3,
                            CharityId = 2,
                            Name = "Omar",
                            Status = "active",
                            Totalneeded = 5000,
                            currentdonations = 0,
                            description = "Debted for Appliances"
                        });
                });

            modelBuilder.Entity("BackEndAPI.Data.Models.Charity", b =>
                {
                    b.HasBaseType("BackEndAPI.Data.Models.User");

                    b.Property<int>("CharityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("charityname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("phonenumber")
                        .HasColumnType("INTEGER");

                    b.ToTable("Charities", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            email = "Charity1@gmail.com",
                            passwordhash = "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C",
                            username = "charity1",
                            usertype = "charity",
                            CharityId = 1,
                            charityname = "5er Masr",
                            description = "Charity Description 1",
                            phonenumber = 1110746800
                        },
                        new
                        {
                            Id = 2,
                            email = "Charity2@gmail.com",
                            passwordhash = "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C",
                            username = "charity2",
                            usertype = "charity",
                            CharityId = 2,
                            charityname = "2ed fe 2ed",
                            description = "Charity Description 2",
                            phonenumber = 1110746800
                        },
                        new
                        {
                            Id = 3,
                            email = "Charity3@gmail.com",
                            passwordhash = "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C",
                            username = "charity3",
                            usertype = "charity",
                            CharityId = 3,
                            charityname = "Charity 3",
                            description = "Charity Description 3",
                            phonenumber = 1110746800
                        });
                });

            modelBuilder.Entity("BackEndAPI.Data.Models.Donator", b =>
                {
                    b.HasBaseType("BackEndAPI.Data.Models.User");

                    b.Property<int>("DonatorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("paymenttype")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("phonenumber")
                        .HasColumnType("INTEGER");

                    b.ToTable("Donators", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 7,
                            email = "donator@gmail.com",
                            passwordhash = "$2y$10$GG7BIOY/0GdsliwsztYf7OSfjtitqXM57rNe0d.vpI4FBbl54FN4C",
                            username = "donatortest",
                            usertype = "donator",
                            DonatorId = 1,
                            paymenttype = "null",
                            phonenumber = 1110746800
                        });
                });

            modelBuilder.Entity("BackEndAPI.Data.Models.Admin", b =>
                {
                    b.HasOne("BackEndAPI.Data.Models.User", null)
                        .WithOne()
                        .HasForeignKey("BackEndAPI.Data.Models.Admin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEndAPI.Data.Models.Case", b =>
                {
                    b.HasOne("BackEndAPI.Data.Models.Charity", "Charity")
                        .WithMany("Cases")
                        .HasForeignKey("CharityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndAPI.Data.Models.Donator", null)
                        .WithMany("DonatedCase")
                        .HasForeignKey("DonatorId");

                    b.HasOne("BackEndAPI.Data.Models.User", null)
                        .WithOne()
                        .HasForeignKey("BackEndAPI.Data.Models.Case", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Charity");
                });

            modelBuilder.Entity("BackEndAPI.Data.Models.Charity", b =>
                {
                    b.HasOne("BackEndAPI.Data.Models.User", null)
                        .WithOne()
                        .HasForeignKey("BackEndAPI.Data.Models.Charity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEndAPI.Data.Models.Donator", b =>
                {
                    b.HasOne("BackEndAPI.Data.Models.User", null)
                        .WithOne()
                        .HasForeignKey("BackEndAPI.Data.Models.Donator", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEndAPI.Data.Models.Charity", b =>
                {
                    b.Navigation("Cases");
                });

            modelBuilder.Entity("BackEndAPI.Data.Models.Donator", b =>
                {
                    b.Navigation("DonatedCase");
                });
#pragma warning restore 612, 618
        }
    }
}
