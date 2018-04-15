using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RaveUpSite.Migrations
{
    public partial class UpdNewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FloorsCount",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasBathhouse",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasPool",
                table: "Items",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "FloorsCount",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "HasBathhouse",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "HasPool",
                table: "Items");
        }
    }
}
