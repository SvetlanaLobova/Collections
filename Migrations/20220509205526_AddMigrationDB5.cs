using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collections.Migrations
{
    public partial class AddMigrationDB5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpecialDateTime2",
                table: "Items",
                newName: "SpecialDataType2");

            migrationBuilder.RenameColumn(
                name: "SpecialDateTime1",
                table: "Items",
                newName: "SpecialDataType1");

            migrationBuilder.RenameColumn(
                name: "SpecialDateTime",
                table: "Items",
                newName: "SpecialDataType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpecialDataType2",
                table: "Items",
                newName: "SpecialDateTime2");

            migrationBuilder.RenameColumn(
                name: "SpecialDataType1",
                table: "Items",
                newName: "SpecialDateTime1");

            migrationBuilder.RenameColumn(
                name: "SpecialDataType",
                table: "Items",
                newName: "SpecialDateTime");
        }
    }
}
