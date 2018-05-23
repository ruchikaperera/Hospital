﻿// <auto-generated />
using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Hospital.Migrations
{
    [DbContext(typeof(HospitalContext))]
    [Migration("20180430173339_g")]
    partial class g
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hospital.Modules.Doctors_Profile.Models.DoctorsLoginModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("password");

                    b.Property<string>("userName");

                    b.HasKey("Id");

                    b.ToTable("DoctorsLoginModel");
                });

            modelBuilder.Entity("Hospital.Modules.Doctors_Profile.Models.LabReportRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DoctorName")
                        .IsRequired();

                    b.Property<string>("DoctorStatus");

                    b.Property<string>("LabReport");

                    b.Property<string>("LabStatus");

                    b.Property<string>("LabType")
                        .IsRequired();

                    b.Property<int>("ReportId");

                    b.Property<string>("SpecialistName");

                    b.Property<DateTime>("date");

                    b.Property<string>("description");

                    b.Property<int>("labNo");

                    b.Property<int>("nicNo");

                    b.Property<string>("patientName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("LabReportRequest");
                });

            modelBuilder.Entity("Hospital.Modules.Doctors_Profile.Models.ReportCount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.HasKey("Id");

                    b.ToTable("ReportCount");
                });

            modelBuilder.Entity("Hospital.Modules.Doctors_Profile.Models.RequestFacility", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Department");

                    b.Property<string>("Description");

                    b.Property<string>("DoctorName");

                    b.Property<string>("Topic");

                    b.HasKey("Id");

                    b.ToTable("RequestFacility");
                });

            modelBuilder.Entity("Hospital.Modules.DrugDetails.Models.Drug", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Drug_ID")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("Price");

                    b.Property<int>("Qty");

                    b.Property<string>("State")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Drug");
                });

            modelBuilder.Entity("Hospital.Modules.InvoiceDetails.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments");

                    b.Property<DateTime>("Date");

                    b.Property<string>("PatienID")
                        .IsRequired();

                    b.Property<string>("Pay_type")
                        .IsRequired();

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<double>("Total_Amount");

                    b.HasKey("InvoiceID");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("Hospital.Modules.LabManagement.Models.LabLogInModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("password");

                    b.Property<string>("userName");

                    b.HasKey("Id");

                    b.ToTable("LabLogInModel");
                });

            modelBuilder.Entity("Hospital.Modules.PatientManagement.Models.PatientDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("Date_Cin");

                    b.Property<string>("Email");

                    b.Property<string>("NicNo")
                        .IsRequired();

                    b.Property<string>("Wardno")
                        .IsRequired();

                    b.Property<string>("avalablity");

                    b.Property<DateTime>("checkedout");

                    b.Property<string>("patientName")
                        .IsRequired();

                    b.Property<int>("telephone");

                    b.HasKey("Id");

                    b.ToTable("PatientDetails");
                });

            modelBuilder.Entity("Hospital.Modules.Prescriptions.Models.BindMedicationPrescription", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Case_history")
                        .IsRequired();

                    b.Property<string>("Note");

                    b.Property<string>("PID")
                        .IsRequired();

                    b.Property<string>("Treatment")
                        .IsRequired();

                    b.Property<string>("When_to_take");

                    b.Property<string>("medication")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("BindMedicationPrescription");
                });

            modelBuilder.Entity("Hospital.Modules.SalaryDetails.Model.SalaryDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NIC")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("Rating");

                    b.Property<double>("WorkingHrs");

                    b.HasKey("ID");

                    b.ToTable("SalaryDetail");
                });

            modelBuilder.Entity("Hospital.Modules.StaffData.Models.Staffdatas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Attendance");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Staffid")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Staffdatas");
                });

            modelBuilder.Entity("Hospital.Modules.StaffManagement.Models.EditProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("EditProfile");
                });

            modelBuilder.Entity("Hospital.Modules.StaffManagement.Models.LogInDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Position");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("LogInDetails");
                });

            modelBuilder.Entity("Hospital.Modules.StaffManagement.Models.Reminder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("Topic");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Reminder");
                });

            modelBuilder.Entity("Hospital.Modules.StaffManagement.Models.staffTasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("taskDetails");

                    b.Property<string>("taskHeading");

                    b.Property<string>("taskHolder");

                    b.Property<string>("taskOwner");

                    b.HasKey("Id");

                    b.ToTable("staffTasks");
                });

            modelBuilder.Entity("Hospital.Modules.Wardassign.Models.Ward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("dateDutyOn");

                    b.Property<string>("empno");

                    b.Property<DateTime>("timeDutyOn");

                    b.Property<string>("wardNo");

                    b.HasKey("Id");

                    b.ToTable("Ward");
                });

            modelBuilder.Entity("Hospital.Modules.Wardddata.Models.Warddatas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NoOfBed");

                    b.Property<DateTime>("date");

                    b.Property<string>("description")
                        .IsRequired();

                    b.Property<string>("status")
                        .IsRequired();

                    b.Property<string>("wardno")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Warddatas");
                });
#pragma warning restore 612, 618
        }
    }
}
