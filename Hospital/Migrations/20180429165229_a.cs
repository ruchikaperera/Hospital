using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hospital.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "LabReportRequest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "staffTasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    taskDetails = table.Column<string>(nullable: true),
                    taskHeading = table.Column<string>(nullable: true),
                    taskHolder = table.Column<string>(nullable: true),
                    taskOwner = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffTasks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "staffTasks");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "LabReportRequest");
        }
    }
}
