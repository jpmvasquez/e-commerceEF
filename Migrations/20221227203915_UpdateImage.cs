using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_Project.Migrations
{
    public partial class UpdateImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "title",
                table: "Image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Image",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
