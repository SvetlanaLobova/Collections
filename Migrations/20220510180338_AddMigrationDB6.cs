using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collections.Migrations
{
    public partial class AddMigrationDB6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FieldName1",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldName2",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeField1",
                table: "Collections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeField2",
                table: "Collections",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldName1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "FieldName2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "TypeField1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "TypeField2",
                table: "Collections");
        }
    }
}
