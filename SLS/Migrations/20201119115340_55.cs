using Microsoft.EntityFrameworkCore.Migrations;

namespace SLS.Migrations
{
    public partial class _55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Item",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Item",
                newName: "DateCreated");
        }
    }
}
