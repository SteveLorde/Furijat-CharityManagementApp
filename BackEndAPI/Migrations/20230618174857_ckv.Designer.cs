﻿// <auto-generated />
using System;
using BackEndAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEndAPI.Migrations
{
    [DbContext(typeof(FurijatContext))]
    [Migration("20230618174857_ckv")]
    partial class ckv
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEndAPI.Data.Entites.Creditor", b =>
                {
                    b.Property<int>("CreditorID")
                        .HasColumnType("int");

                    b.Property<int>("CaseID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Deserves_Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Payment_Account")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CreditorID", "CaseID");

                    b.HasIndex("CaseID");

                    b.ToTable("Creditor");
                });

            modelBuilder.Entity("BackEndAPI.Data.Entites.Donation", b =>
                {
                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.Property<int>("DonatorId")
                        .HasColumnType("int");

                    b.Property<int>("CharityId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("CaseId", "DonatorId", "CharityId");

                    b.HasIndex("CharityId");

                    b.HasIndex("DonatorId");

                    b.ToTable("Donation");
                });

            modelBuilder.Entity("BackEndAPI.Data.Entites.PaymentToCreditor", b =>
                {
                    b.Property<int>("CharityId")
                        .HasColumnType("int");

                    b.Property<int>("CreditorId")
                        .HasColumnType("int");

                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.Property<int?>("DonatorId")
                        .HasColumnType("int");

                    b.Property<decimal>("Paid_Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("CharityId", "CreditorId", "CaseId");

                    b.HasIndex("CaseId");

                    b.HasIndex("DonatorId");

                    b.HasIndex("CreditorId", "CaseId");

                    b.ToTable("PaymentToCreditors");
                });

            modelBuilder.Entity("BackEndAPI.Models.Charity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bank_Account")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Charities");
                });

            modelBuilder.Entity("BackEndAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BackEndAPI.Data.Entites.Admin", b =>
                {
                    b.HasBaseType("BackEndAPI.Models.User");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("BackEndAPI.Data.Entites.Case", b =>
                {
                    b.HasBaseType("BackEndAPI.Models.User");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CharityId")
                        .HasColumnType("int");

                    b.Property<decimal>("CurrentAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarriageStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasIndex("CharityId");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("BackEndAPI.Data.Entites.Donator", b =>
                {
                    b.HasBaseType("BackEndAPI.Models.User");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PaidAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Phone")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Donators");
                });

            modelBuilder.Entity("BackEndAPI.Data.Entites.Creditor", b =>
                {
                    b.HasOne("BackEndAPI.Data.Entites.Case", "Case")
                        .WithMany()
                        .HasForeignKey("CaseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");
                });

            modelBuilder.Entity("BackEndAPI.Data.Entites.Donation", b =>
                {
                    b.HasOne("BackEndAPI.Data.Entites.Case", "Case")
                        .WithMany("Donation")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndAPI.Models.Charity", "Charity")
                        .WithMany("Donation")
                        .HasForeignKey("CharityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndAPI.Data.Entites.Donator", "Donator")
                        .WithMany("Donation")
                        .HasForeignKey("DonatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");

                    b.Navigation("Charity");

                    b.Navigation("Donator");
                });

            modelBuilder.Entity("BackEndAPI.Data.Entites.PaymentToCreditor", b =>
                {
                    b.HasOne("BackEndAPI.Data.Entites.Case", "Case")
                        .WithMany("PaymentToCreditor")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndAPI.Models.Charity", "Charity")
                        .WithMany("PaymentToCreditor")
                        .HasForeignKey("CharityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndAPI.Data.Entites.Donator", null)
                        .WithMany("PaymentToCreditor")
                        .HasForeignKey("DonatorId");

                    b.HasOne("BackEndAPI.Data.Entites.Creditor", "Creditor")
                        .WithMany("PaymentToCreditor")
                        .HasForeignKey("CreditorId", "CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");

                    b.Navigation("Charity");

                    b.Navigation("Creditor");
                });

            modelBuilder.Entity("BackEndAPI.Data.Entites.Admin", b =>
                {
                    b.HasOne("BackEndAPI.Models.User", null)
                        .WithOne()
                        .HasForeignKey("BackEndAPI.Data.Entites.Admin", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEndAPI.Data.Entites.Case", b =>
                {
                    b.HasOne("BackEndAPI.Models.Charity", "Charity")
                        .WithMany("Cases")
                        .HasForeignKey("CharityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndAPI.Models.User", null)
                        .WithOne()
                        .HasForeignKey("BackEndAPI.Data.Entites.Case", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Charity");
                });

            modelBuilder.Entity("BackEndAPI.Data.Entites.Donator", b =>
                {
                    b.HasOne("BackEndAPI.Models.User", null)
                        .WithOne()
                        .HasForeignKey("BackEndAPI.Data.Entites.Donator", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEndAPI.Data.Entites.Creditor", b =>
                {
                    b.Navigation("PaymentToCreditor");
                });

            modelBuilder.Entity("BackEndAPI.Models.Charity", b =>
                {
                    b.Navigation("Cases");

                    b.Navigation("Donation");

                    b.Navigation("PaymentToCreditor");
                });

            modelBuilder.Entity("BackEndAPI.Data.Entites.Case", b =>
                {
                    b.Navigation("Donation");

                    b.Navigation("PaymentToCreditor");
                });

            modelBuilder.Entity("BackEndAPI.Data.Entites.Donator", b =>
                {
                    b.Navigation("Donation");

                    b.Navigation("PaymentToCreditor");
                });
#pragma warning restore 612, 618
        }
    }
}
