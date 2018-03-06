using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hospital.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorName",
                table: "LabReportRequest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorStatus",
                table: "LabReportRequest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LabStatus",
                table: "LabReportRequest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LabType",
                table: "LabReportRequest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialistName",
                table: "LabReportRequest",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Drug",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drug", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LogInDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogInDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reminder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestFacility",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Department = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DoctorName = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestFacility", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drug");

            migrationBuilder.DropTable(
                name: "LogInDetails");

            migrationBuilder.DropTable(
                name: "Reminder");

            migrationBuilder.DropTable(
                name: "RequestFacility");

            migrationBuilder.DropColumn(
                name: "DoctorName",
                table: "LabReportRequest");

            migrationBuilder.DropColumn(
                name: "DoctorStatus",
                table: "LabReportRequest");

            migrationBuilder.DropColumn(
                name: "LabStatus",
                table: "LabReportRequest");

            migrationBuilder.DropColumn(
                name: "LabType",
                table: "LabReportRequest");

            migrationBuilder.DropColumn(
                name: "SpecialistName",
                table: "LabReportRequest");
        }
    }
}
