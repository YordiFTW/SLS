using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SLS.Migrations
{
    public partial class _52 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Item",
                type: "datetime2",
                nullable: true);
        }
    }
}
