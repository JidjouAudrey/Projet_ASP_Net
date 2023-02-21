using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteVitrineEbeniste.Migrations
{
    public partial class PeughouiaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ViewedPeriod",
                table: "UserArticles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewedPeriod",
                table: "UserArticles");
        }
    }
}
