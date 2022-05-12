using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApp.DAL.Migrations
{
    public partial class CorrectOption_UpdateTypeToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CorrectOption",
                table: "Questions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 12, 21, 11, 52, 996, DateTimeKind.Utc).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 14, 21, 11, 52, 996, DateTimeKind.Utc).AddTicks(9024));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 15, 21, 11, 52, 996, DateTimeKind.Utc).AddTicks(9333));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 16, 21, 11, 52, 996, DateTimeKind.Utc).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 17, 21, 11, 52, 996, DateTimeKind.Utc).AddTicks(9350));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CorrectOption",
                table: "Questions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 9, 22, 32, 46, 540, DateTimeKind.Utc).AddTicks(6220));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 11, 22, 32, 46, 540, DateTimeKind.Utc).AddTicks(7212));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 12, 22, 32, 46, 540, DateTimeKind.Utc).AddTicks(7307));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 13, 22, 32, 46, 540, DateTimeKind.Utc).AddTicks(7311));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedDate",
                value: new DateTime(2022, 5, 14, 22, 32, 46, 540, DateTimeKind.Utc).AddTicks(7312));
        }
    }
}
