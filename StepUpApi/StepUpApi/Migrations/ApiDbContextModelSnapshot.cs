﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StepUpApi.Data;

#nullable disable

namespace StepUpApi.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppointmentExaminationType", b =>
                {
                    b.Property<Guid>("AppointmentsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExaminationTypesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AppointmentsId", "ExaminationTypesId");

                    b.HasIndex("ExaminationTypesId");

                    b.ToTable("AppointmentExaminationType");
                });

            modelBuilder.Entity("AppointmentLogUser", b =>
                {
                    b.Property<Guid>("AppointmentLogsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AppointmentLogsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("AppointmentLogUser");
                });

            modelBuilder.Entity("AppointmentUser", b =>
                {
                    b.Property<Guid>("AppointmentsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AppointmentsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("AppointmentUser");
                });

            modelBuilder.Entity("ContactPersonCustomer", b =>
                {
                    b.Property<Guid>("ContactPersonsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ContactPersonsId", "CustomersId");

                    b.HasIndex("CustomersId");

                    b.ToTable("ContactPersonCustomer");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<Guid>("CollectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CollectionId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("StepUpApi.Models.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HasAttended")
                        .HasColumnType("bit");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NextExamination")
                        .HasColumnType("datetime2");

                    b.Property<string>("PatientCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime>("PatientDateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("PatientJobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Result")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("LocationId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("StepUpApi.Models.AppointmentLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AccessTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AppointmentLos");
                });

            modelBuilder.Entity("StepUpApi.Models.ContactDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContactType")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("ContactDetails");
                });

            modelBuilder.Entity("StepUpApi.Models.ContactPerson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactPersons");
                });

            modelBuilder.Entity("StepUpApi.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BillingInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ContractOnFile")
                        .HasColumnType("bit");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HeadCountA")
                        .HasColumnType("int");

                    b.Property<int>("HeadCountB")
                        .HasColumnType("int");

                    b.Property<int>("HeadCountC")
                        .HasColumnType("int");

                    b.Property<int>("HeadCountD")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceAmount")
                        .HasColumnType("int");

                    b.Property<string>("InvoiceEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceIssuer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvoicePeriod")
                        .HasColumnType("int");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PaymentDeadline")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartOfContract")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Vip")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("StepUpApi.Models.EmployeeType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeTypes");
                });

            modelBuilder.Entity("StepUpApi.Models.ExaminationType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExaminationTypes");
                });

            modelBuilder.Entity("StepUpApi.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("StepUpApi.Models.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("StepUpApi.Models.PeriodicInvoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentDeadline")
                        .HasColumnType("int");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("PeriodicInvoices");
                });

            modelBuilder.Entity("StepUpApi.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("StepUpApi.Models.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCurrentRate")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("StepUpApi.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EmployeeTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AppointmentExaminationType", b =>
                {
                    b.HasOne("StepUpApi.Models.Appointment", null)
                        .WithMany()
                        .HasForeignKey("AppointmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StepUpApi.Models.ExaminationType", null)
                        .WithMany()
                        .HasForeignKey("ExaminationTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppointmentLogUser", b =>
                {
                    b.HasOne("StepUpApi.Models.AppointmentLog", null)
                        .WithMany()
                        .HasForeignKey("AppointmentLogsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StepUpApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppointmentUser", b =>
                {
                    b.HasOne("StepUpApi.Models.Appointment", null)
                        .WithMany()
                        .HasForeignKey("AppointmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StepUpApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ContactPersonCustomer", b =>
                {
                    b.HasOne("StepUpApi.Models.ContactPerson", null)
                        .WithMany()
                        .HasForeignKey("ContactPersonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StepUpApi.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("StepUpApi.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StepUpApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StepUpApi.Models.Appointment", b =>
                {
                    b.HasOne("StepUpApi.Models.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId");

                    b.HasOne("StepUpApi.Models.Location", "Location")
                        .WithMany("Appointments")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("StepUpApi.Models.ContactDetails", b =>
                {
                    b.HasOne("StepUpApi.Models.Customer", "Customer")
                        .WithMany("ContactDetailsCollection")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("StepUpApi.Models.Customer", b =>
                {
                    b.HasOne("StepUpApi.Models.Location", "Location")
                        .WithMany("Customers")
                        .HasForeignKey("LocationId");

                    b.HasOne("StepUpApi.Models.Owner", "Owner")
                        .WithMany("Customers")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Location");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("StepUpApi.Models.PeriodicInvoice", b =>
                {
                    b.HasOne("StepUpApi.Models.Customer", "Customer")
                        .WithMany("PeriodicInvoices")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("StepUpApi.Models.Service", b =>
                {
                    b.HasOne("StepUpApi.Models.Customer", "Customer")
                        .WithMany("Services")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("StepUpApi.Models.User", b =>
                {
                    b.HasOne("StepUpApi.Models.EmployeeType", "EmployeeType")
                        .WithMany("Users")
                        .HasForeignKey("EmployeeTypeId");

                    b.Navigation("EmployeeType");
                });

            modelBuilder.Entity("StepUpApi.Models.Customer", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("ContactDetailsCollection");

                    b.Navigation("PeriodicInvoices");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("StepUpApi.Models.EmployeeType", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("StepUpApi.Models.Location", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("StepUpApi.Models.Owner", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
