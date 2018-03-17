using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hospital.Migrations
{
    public partial class pet2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nicNo",
                table: "Wardassign");

            migrationBuilder.AddColumn<string>(
                name: "wardnumb",
                table: "Wardassign",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "wardnumb",
                table: "Wardassign");

            migrationBuilder.AddColumn<int>(
                name: "nicNo",
                table: "Wardassign",
                nullable: false,
                defaultValue: 0);
        }
    }
}
