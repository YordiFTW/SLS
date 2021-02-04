using Microsoft.EntityFrameworkCore.Migrations;

namespace SLS.Migrations
{
    public partial class _59 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Item",
                newName: "CreationDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Item",
                newName: "Date");
        }
    }
}
