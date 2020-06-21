using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xamApi.Migrations
{
    public partial class fixfilms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatePremier",
                table: "Films",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Films",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Films",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Films",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Films",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Starring",
                table: "Films",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePremier",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Starring",
                table: "Films");
        }
    }
}
