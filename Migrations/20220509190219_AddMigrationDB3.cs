using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collections.Migrations
{
    public partial class AddMigrationDB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FieldName",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeField",
                table: "Collections",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldName",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "TypeField",
                table: "Collections");
        }
    }
}
