using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_Project.Migrations
{
    public partial class add_address_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    streetNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    streetName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    zipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "id", "city", "country", "streetName", "streetNumber", "zipCode" },
                values: new object[] { 1, "Paris", "France", "rue de pie", "12", "75020" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
