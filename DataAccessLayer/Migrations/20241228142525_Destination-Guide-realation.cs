﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class DestinationGuiderealation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuideId",
                table: "Destinations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommentUser",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_GuideId",
                table: "Destinations",
                column: "GuideId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Guides_GuideId",
                table: "Destinations",
                column: "GuideId",
                principalTable: "Guides",
                principalColumn: "GuideId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Guides_GuideId",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_GuideId",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "GuideId",
                table: "Destinations");

            migrationBuilder.AlterColumn<string>(
                name: "CommentUser",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
