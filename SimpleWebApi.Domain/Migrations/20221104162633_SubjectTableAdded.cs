using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleWebApi.Domain.Migrations
{
    public partial class SubjectTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Section",
                table: "Grades");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Grades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Grades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PersonalNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Grades");

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
