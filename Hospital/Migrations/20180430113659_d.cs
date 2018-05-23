using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hospital.Migrations
{
    public partial class d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wardassign");

            migrationBuilder.AddColumn<string>(
                name: "avalablity",
                table: "PatientDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "checkedout",
                table: "PatientDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Ward",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateDutyOn = table.Column<DateTime>(nullable: false),
                    empno = table.Column<string>(nullable: true),
                    timeDutyOn = table.Column<DateTime>(nullable: false),
                    wardNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ward");

            migrationBuilder.DropColumn(
                name: "avalablity",
                table: "PatientDetails");

            migrationBuilder.DropColumn(
                name: "checkedout",
                table: "PatientDetails");

            migrationBuilder.CreateTable(
                name: "Wardassign",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(nullable: false),
                    patientName = table.Column<int>(nullable: false),
                    wardnumb = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wardassign", x => x.Id);
                });
        }
    }
}
