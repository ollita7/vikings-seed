using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Viking.DataAccess.Migrations
{
    public partial class UpdateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Users",
                newName: "updatedAt");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "Users",
                newName: "token");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Users",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedAt",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 25, 15, 12, 42, 882, DateTimeKind.Local).AddTicks(6164),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 25, 14, 41, 37, 369, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 25, 15, 12, 42, 877, DateTimeKind.Local).AddTicks(3981),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Users",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "updatedAt",
                table: "Users",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "token",
                table: "Users",
                newName: "Token");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "Users",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 25, 14, 41, 37, 369, DateTimeKind.Local).AddTicks(220),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 25, 15, 12, 42, 882, DateTimeKind.Local).AddTicks(6164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 25, 15, 12, 42, 877, DateTimeKind.Local).AddTicks(3981));

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary(150)",
                maxLength: 150,
                nullable: true);
        }
    }
}
