using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Viking.DataAccess.Migrations
{
    public partial class UpdateMailColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 25, 14, 41, 37, 369, DateTimeKind.Local).AddTicks(220),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 20, 22, 17, 21, 396, DateTimeKind.Local).AddTicks(9687));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 20, 22, 17, 21, 396, DateTimeKind.Local).AddTicks(9687),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 25, 14, 41, 37, 369, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
