﻿// <auto-generated />
using System;
using InfuencerAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InfuencerAPI.Migrations
{
    [DbContext(typeof(InfluencerDbContext))]
    [Migration("20230731070355_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InfuencerAPI.Models.Influencers.Influencer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IndustryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("NationalityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("IndustryId");

                    b.HasIndex("NationalityId");

                    b.ToTable("Influencer");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Influencers.RestDay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<Guid>("InfluencerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<Guid>("TimeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InfluencerId");

                    b.ToTable("InfluencerRestDay");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Influencers.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("InfluencerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ServiceSettingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("InfluencerId");

                    b.HasIndex("ServiceSettingId");

                    b.HasIndex("TypeId");

                    b.ToTable("InfluencerServices");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Influencers.Social", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InfluencerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SocialMediaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("InfluencerId");

                    b.HasIndex("SocialMediaId");

                    b.ToTable("InfluencerSocials");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Influencers.Time", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("InfluencerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TimeSettingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("InfluencerId");

                    b.HasIndex("TimeSettingId");

                    b.ToTable("InfluencerTime");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Master.Settings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsManageable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Orders.Calendar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TimeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("TimeId");

                    b.ToTable("OrderCalendars");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Orders.Detail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ServiceTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ServiceTypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Orders.Orders", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid?>("InfluencerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsApproved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Order Received");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("InfluencerId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Orders.Target", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderTargets");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Users.Login", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("EmailVerified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PasswordVerified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsersLogin");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Users.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IndustryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IndustryId");

                    b.HasIndex("TypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Influencers.Influencer", b =>
                {
                    b.HasOne("InfuencerAPI.Models.Master.Settings", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.HasOne("InfuencerAPI.Models.Master.Settings", "Industry")
                        .WithMany()
                        .HasForeignKey("IndustryId");

                    b.HasOne("InfuencerAPI.Models.Master.Settings", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId");

                    b.Navigation("Gender");

                    b.Navigation("Industry");

                    b.Navigation("Nationality");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Influencers.RestDay", b =>
                {
                    b.HasOne("InfuencerAPI.Models.Influencers.Influencer", "Influencer")
                        .WithMany()
                        .HasForeignKey("InfluencerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Influencer");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Influencers.Service", b =>
                {
                    b.HasOne("InfuencerAPI.Models.Influencers.Influencer", "Influencer")
                        .WithMany()
                        .HasForeignKey("InfluencerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InfuencerAPI.Models.Master.Settings", "ServiceSetting")
                        .WithMany()
                        .HasForeignKey("ServiceSettingId");

                    b.HasOne("InfuencerAPI.Models.Master.Settings", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Influencer");

                    b.Navigation("ServiceSetting");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Influencers.Social", b =>
                {
                    b.HasOne("InfuencerAPI.Models.Influencers.Influencer", "Influencer")
                        .WithMany()
                        .HasForeignKey("InfluencerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InfuencerAPI.Models.Master.Settings", "SocialMedia")
                        .WithMany()
                        .HasForeignKey("SocialMediaId");

                    b.Navigation("Influencer");

                    b.Navigation("SocialMedia");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Influencers.Time", b =>
                {
                    b.HasOne("InfuencerAPI.Models.Influencers.Influencer", "Influencer")
                        .WithMany()
                        .HasForeignKey("InfluencerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InfuencerAPI.Models.Master.Settings", "TimeSetting")
                        .WithMany()
                        .HasForeignKey("TimeSettingId");

                    b.Navigation("Influencer");

                    b.Navigation("TimeSetting");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Orders.Calendar", b =>
                {
                    b.HasOne("InfuencerAPI.Models.Orders.Orders", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InfuencerAPI.Models.Master.Settings", "Time")
                        .WithMany()
                        .HasForeignKey("TimeId");

                    b.Navigation("Order");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Orders.Detail", b =>
                {
                    b.HasOne("InfuencerAPI.Models.Orders.Orders", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InfuencerAPI.Models.Master.Settings", "ServiceType")
                        .WithMany()
                        .HasForeignKey("ServiceTypeId");

                    b.HasOne("InfuencerAPI.Models.Master.Settings", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Order");

                    b.Navigation("ServiceType");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Orders.Orders", b =>
                {
                    b.HasOne("InfuencerAPI.Models.Influencers.Influencer", "Influencer")
                        .WithMany()
                        .HasForeignKey("InfluencerId");

                    b.HasOne("InfuencerAPI.Models.Users.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Influencer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Orders.Target", b =>
                {
                    b.HasOne("InfuencerAPI.Models.Orders.Orders", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Users.Login", b =>
                {
                    b.HasOne("InfuencerAPI.Models.Users.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InfuencerAPI.Models.Users.Users", b =>
                {
                    b.HasOne("InfuencerAPI.Models.Master.Settings", "Industry")
                        .WithMany()
                        .HasForeignKey("IndustryId");

                    b.HasOne("InfuencerAPI.Models.Master.Settings", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Industry");

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
