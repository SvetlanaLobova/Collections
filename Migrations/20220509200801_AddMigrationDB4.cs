using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collections.Migrations
{
    public partial class AddMigrationDB4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SpecialBool",
                table: "Items",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SpecialBool1",
                table: "Items",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SpecialBool2",
                table: "Items",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialDataType",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialDataType1",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialDataType2",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialInt",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialInt1",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialInt2",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialString",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialString1",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialString2",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialText",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialText1",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialText2",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialBool",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SpecialBool1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SpecialBool2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SpecialDataType",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SpecialDataType1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SpecialDataType2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SpecialInt",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SpecialInt1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SpecialInt2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SpecialString",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SpecialString1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SpecialString2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SpecialText",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SpecialText1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SpecialText2",
                table: "Items");
        }
    }
}
