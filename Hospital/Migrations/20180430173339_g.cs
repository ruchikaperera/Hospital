using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hospital.Migrations
{
    public partial class g : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BindMedicationPrescription",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Case_history = table.Column<string>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    PID = table.Column<string>(nullable: false),
                    Treatment = table.Column<string>(nullable: false),
                    When_to_take = table.Column<string>(nullable: true),
                    medication = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BindMedicationPrescription", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PatienID = table.Column<string>(nullable: false),
                    Pay_type = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Total_Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BindMedicationPrescription");

            migrationBuilder.DropTable(
                name: "Invoice");
        }
    }
}
