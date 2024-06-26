﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechnicalServicesAPI.DataBase;

#nullable disable

namespace TechnicalServicesAPI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("OrderNumberSequence");

            modelBuilder.Entity("TechnicalServicesAPI.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessLevel")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("SocialSecurityNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("SocialSecurityNumber")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.ExtendService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MainServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("MainServiceId");

                    b.ToTable("ExtendServices");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.MainService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MainServices");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ChosenResponseId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("ExtendServiceId")
                        .HasColumnType("int");

                    b.Property<long>("OrderNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("NEXT VALUE FOR OrderNumberSequence");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("XLocation")
                        .HasColumnType("float");

                    b.Property<double>("YLocation")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ChosenResponseId")
                        .IsUnique()
                        .HasFilter("[ChosenResponseId] IS NOT NULL");

                    b.HasIndex("ExtendServiceId");

                    b.HasIndex("OrderNumber")
                        .IsUnique();

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.RatingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("RatingTypes");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.Response", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<double>("EstimatedPrice")
                        .HasColumnType("float");

                    b.Property<double>("EstimatedTime")
                        .HasColumnType("float");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("TechnicianId", "OrderId")
                        .IsUnique();

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.Technician.Technician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<int?>("ApprovedById")
                        .HasColumnType("int");

                    b.Property<int>("ExperienceLevel")
                        .HasColumnType("int");

                    b.Property<DateOnly>("LastSigninDate")
                        .HasColumnType("date");

                    b.Property<string>("SocialSecurityNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("statusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApprovedById");

                    b.HasIndex("SocialSecurityNumber")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.HasIndex("statusId");

                    b.ToTable("Technicians");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.Technician.TechnicianFeedBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("TechniciansFeedBack");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.Technician.TechnicianFeedBackResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("TechnicianFeedBackId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("TechnicianFeedBackId");

                    b.ToTable("TechnicianFeedBackResponses");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.Technician.TechnicianStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TechnicianStatus");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.Technician.TechniciansRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RatingTypeId")
                        .HasColumnType("int");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("RatingTypeId");

                    b.HasIndex("TechnicianId", "RatingTypeId")
                        .IsUnique();

                    b.ToTable("TechniciansRatings");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.Technician.TechniciansServices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExtendServiceId")
                        .HasColumnType("int");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExtendServiceId");

                    b.HasIndex("TechnicianId", "ExtendServiceId")
                        .IsUnique();

                    b.ToTable("TechniciansServices");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTechnician")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("SignUpDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<double>("XLocation")
                        .HasColumnType("float");

                    b.Property<double>("YLocation")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.User.UserFeedBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("UsersFeedBack");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.User.UserFeedBackRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RatingTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserFeedBackId")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("RatingTypeId");

                    b.HasIndex("UserFeedBackId", "RatingTypeId")
                        .IsUnique();

                    b.ToTable("UsersFeedBackRatings");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.User.UserFeedBackResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("UserFeedBackId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("UserFeedBackId");

                    b.ToTable("UserFeedBackResponses");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.User.UserIncom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("amount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsersIncoms");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.User.UserNotifcation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsersNotifcations");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.User.UserPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("PaymentAmount")
                        .HasColumnType("float");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersPayments");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.ExtendService", b =>
                {
                    b.HasOne("TechnicalServicesAPI.Models.MainService", "MainService")
                        .WithMany("ExtendServices")
                        .HasForeignKey("MainServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainService");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.Order", b =>
                {
                    b.HasOne("TechnicalServicesAPI.Models.Response", "ChosenResponse")
                        .WithMany()
                        .HasForeignKey("ChosenResponseId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TechnicalServicesAPI.Models.ExtendService", "ExtendService")
                        .WithMany("Orders")
                        .HasForeignKey("ExtendServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnicalServicesAPI.Models.OrderStatus", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnicalServicesAPI.Models.User.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChosenResponse");

                    b.Navigation("ExtendService");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.Response", b =>
                {
                    b.HasOne("TechnicalServicesAPI.Models.Order", "Order")
                        .WithMany("Responses")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnicalServicesAPI.Models.Technician.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.Technician.Technician", b =>
                {
                    b.HasOne("TechnicalServicesAPI.Models.Admin", "ApprovedBy")
                        .WithMany("ApprovedTechnicians")
                        .HasForeignKey("ApprovedById");

                    b.HasOne("TechnicalServicesAPI.Models.User.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnicalServicesAPI.Models.Technician.TechnicianStatus", "Status")
                        .WithMany("Technicians")
                        .HasForeignKey("statusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApprovedBy");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.Technician.TechnicianFeedBack", b =>
                {
                    b.HasOne("TechnicalServicesAPI.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.Technician.TechnicianFeedBackResponse", b =>
                {
                    b.HasOne("TechnicalServicesAPI.Models.Admin", "Admin")
                        .WithMany("TechnicianFeedbackResponses")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnicalServicesAPI.Models.Technician.TechnicianFeedBack", "TechnicianFeedBack")
                        .WithMany()
                        .HasForeignKey("TechnicianFeedBackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("TechnicianFeedBack");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.Technician.TechniciansRating", b =>
                {
                    b.HasOne("TechnicalServicesAPI.Models.RatingType", "RatingType")
                        .WithMany("TechniciansRatings")
                        .HasForeignKey("RatingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnicalServicesAPI.Models.Technician.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RatingType");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.Technician.TechniciansServices", b =>
                {
                    b.HasOne("TechnicalServicesAPI.Models.ExtendService", "ExtendService")
                        .WithMany("Technicians")
                        .HasForeignKey("ExtendServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnicalServicesAPI.Models.Technician.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtendService");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.User.UserFeedBack", b =>
                {
                    b.HasOne("TechnicalServicesAPI.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.User.UserFeedBackRating", b =>
                {
                    b.HasOne("TechnicalServicesAPI.Models.RatingType", "RatingType")
                        .WithMany("UserFeedBackRatings")
                        .HasForeignKey("RatingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnicalServicesAPI.Models.User.UserFeedBack", null)
                        .WithMany("UserFeedBackRatings")
                        .HasForeignKey("UserFeedBackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RatingType");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.User.UserFeedBackResponse", b =>
                {
                    b.HasOne("TechnicalServicesAPI.Models.Admin", "Admin")
                        .WithMany("UserFeedBackResponses")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnicalServicesAPI.Models.User.UserFeedBack", "UserFeedBack")
                        .WithMany()
                        .HasForeignKey("UserFeedBackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("UserFeedBack");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.User.UserIncom", b =>
                {
                    b.HasOne("TechnicalServicesAPI.Models.User.User", "User")
                        .WithMany("UserIncoms")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.User.UserNotifcation", b =>
                {
                    b.HasOne("TechnicalServicesAPI.Models.User.User", "User")
                        .WithMany("UserNotifcations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.User.UserPayment", b =>
                {
                    b.HasOne("TechnicalServicesAPI.Models.PaymentType", "PaymentType")
                        .WithMany("UserPayments")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnicalServicesAPI.Models.User.User", "User")
                        .WithMany("UserPayments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.Admin", b =>
                {
                    b.Navigation("ApprovedTechnicians");

                    b.Navigation("TechnicianFeedbackResponses");

                    b.Navigation("UserFeedBackResponses");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.ExtendService", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Technicians");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.MainService", b =>
                {
                    b.Navigation("ExtendServices");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.Order", b =>
                {
                    b.Navigation("Responses");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.PaymentType", b =>
                {
                    b.Navigation("UserPayments");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.RatingType", b =>
                {
                    b.Navigation("TechniciansRatings");

                    b.Navigation("UserFeedBackRatings");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.Technician.TechnicianStatus", b =>
                {
                    b.Navigation("Technicians");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.User.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("UserIncoms");

                    b.Navigation("UserNotifcations");

                    b.Navigation("UserPayments");
                });

            modelBuilder.Entity("TechnicalServicesAPI.Models.User.UserFeedBack", b =>
                {
                    b.Navigation("UserFeedBackRatings");
                });
#pragma warning restore 612, 618
        }
    }
}
