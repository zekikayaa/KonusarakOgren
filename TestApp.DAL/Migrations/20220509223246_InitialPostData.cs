using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApp.DAL.Migrations
{
    public partial class InitialPostData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedDate", "ImageUrl", "Title" },
                values: new object[] { 11, "Karl, a PhD and lecturer at MIT, gave birth to both of his children—and despite being the one with the baby bump, he was routinely asked to wait outside while the nurses attended to his (not pregnant) wife. People were unable, he says, to see both a man and a pregnant body; as a result, Karl became a “fat man” rather than a pregnant person. Despite being assigned female at birth (AFAB) and possessing a uterus and glands for lactating, Karl was not—in the eyes of even the medical staff—the mother. Karl considered himself a PaPa; other transgender parents choose more androgynous terms, largely because of the way motherhood has been construed. At best, says Karl, unconventional pregnant parents cause “total gender confusion” even among medical practitioners, but at worst it results in trauma, violence, and harm, in trans men failing to get emergency care during miscarriages, in trans women being treated as pedophiles, and in nonbinary identities being entirely erased.", new DateTime(2022, 5, 9, 22, 32, 46, 540, DateTimeKind.Utc).AddTicks(6220), null, "Science Is Redefining Motherhood. If Only Society Would Let It" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedDate", "ImageUrl", "Title" },
                values: new object[] { 22, "Karl, a PhD and lecturer at MIT, gave birth to both of his children—and despite being the one with the baby bump, he was routinely asked to wait outside while the nurses attended to his (not pregnant) wife. People were unable, he says, to see both a man and a pregnant body; as a result, Karl became a “fat man” rather than a pregnant person. Despite being assigned female at birth (AFAB) and possessing a uterus and glands for lactating, Karl was not—in the eyes of even the medical staff—the mother. Karl considered himself a PaPa; other transgender parents choose more androgynous terms, largely because of the way motherhood has been construed. At best, says Karl, unconventional pregnant parents cause “total gender confusion” even among medical practitioners, but at worst it results in trauma, violence, and harm, in trans men failing to get emergency care during miscarriages, in trans women being treated as pedophiles, and in nonbinary identities being entirely erased.", new DateTime(2022, 5, 11, 22, 32, 46, 540, DateTimeKind.Utc).AddTicks(7212), null, "Star Wars Ain’t What It Used to Be" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedDate", "ImageUrl", "Title" },
                values: new object[] { 33, "Karl, a PhD and lecturer at MIT, gave birth to both of his children—and despite being the one with the baby bump, he was routinely asked to wait outside while the nurses attended to his (not pregnant) wife. People were unable, he says, to see both a man and a pregnant body; as a result, Karl became a “fat man” rather than a pregnant person. Despite being assigned female at birth (AFAB) and possessing a uterus and glands for lactating, Karl was not—in the eyes of even the medical staff—the mother. Karl considered himself a PaPa; other transgender parents choose more androgynous terms, largely because of the way motherhood has been construed. At best, says Karl, unconventional pregnant parents cause “total gender confusion” even among medical practitioners, but at worst it results in trauma, violence, and harm, in trans men failing to get emergency care during miscarriages, in trans women being treated as pedophiles, and in nonbinary identities being entirely erased.", new DateTime(2022, 5, 12, 22, 32, 46, 540, DateTimeKind.Utc).AddTicks(7307), null, "The Newest iPad Mini Is at Its Lowest Price Ever" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedDate", "ImageUrl", "Title" },
                values: new object[] { 44, "Karl, a PhD and lecturer at MIT, gave birth to both of his children—and despite being the one with the baby bump, he was routinely asked to wait outside while the nurses attended to his (not pregnant) wife. People were unable, he says, to see both a man and a pregnant body; as a result, Karl became a “fat man” rather than a pregnant person. Despite being assigned female at birth (AFAB) and possessing a uterus and glands for lactating, Karl was not—in the eyes of even the medical staff—the mother. Karl considered himself a PaPa; other transgender parents choose more androgynous terms, largely because of the way motherhood has been construed. At best, says Karl, unconventional pregnant parents cause “total gender confusion” even among medical practitioners, but at worst it results in trauma, violence, and harm, in trans men failing to get emergency care during miscarriages, in trans women being treated as pedophiles, and in nonbinary identities being entirely erased.", new DateTime(2022, 5, 13, 22, 32, 46, 540, DateTimeKind.Utc).AddTicks(7311), null, "Fast, Cheap, and Out of Control: Inside Shein’s Sudden Rise" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedDate", "ImageUrl", "Title" },
                values: new object[] { 55, "Karl, a PhD and lecturer at MIT, gave birth to both of his children—and despite being the one with the baby bump, he was routinely asked to wait outside while the nurses attended to his (not pregnant) wife. People were unable, he says, to see both a man and a pregnant body; as a result, Karl became a “fat man” rather than a pregnant person. Despite being assigned female at birth (AFAB) and possessing a uterus and glands for lactating, Karl was not—in the eyes of even the medical staff—the mother. Karl considered himself a PaPa; other transgender parents choose more androgynous terms, largely because of the way motherhood has been construed. At best, says Karl, unconventional pregnant parents cause “total gender confusion” even among medical practitioners, but at worst it results in trauma, violence, and harm, in trans men failing to get emergency care during miscarriages, in trans women being treated as pedophiles, and in nonbinary identities being entirely erased.", new DateTime(2022, 5, 14, 22, 32, 46, 540, DateTimeKind.Utc).AddTicks(7312), null, "24 Last-Minute Mother’s Day Gifts on Sale Now" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 55);
        }
    }
}
