using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_Project.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    resolution = table.Column<int>(type: "int", nullable: false),
                    zoomOptic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stabilisator = table.Column<bool>(type: "bit", nullable: false),
                    isoMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Techno",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techno", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    productDetailsId = table.Column<int>(type: "int", nullable: false),
                    imageId = table.Column<int>(type: "int", nullable: false),
                    productTypeId = table.Column<int>(type: "int", nullable: false),
                    productTechnoId = table.Column<int>(type: "int", nullable: false),
                    productBrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Brand_productBrandId",
                        column: x => x.productBrandId,
                        principalTable: "Brand",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Image_imageId",
                        column: x => x.imageId,
                        principalTable: "Image",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductDetails_productDetailsId",
                        column: x => x.productDetailsId,
                        principalTable: "ProductDetails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_productTypeId",
                        column: x => x.productTypeId,
                        principalTable: "ProductType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Techno_productTechnoId",
                        column: x => x.productTechnoId,
                        principalTable: "Techno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Sony" },
                    { 2, "Kodak" },
                    { 3, "Panasonic" },
                    { 4, "Nikon" },
                    { 5, "Olympus" },
                    { 6, "Fujifilm" },
                    { 7, "Canon" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, null, "Reflex" },
                    { 2, null, "Hybride" },
                    { 3, null, "Bridge" },
                    { 4, null, "Compact" }
                });

            migrationBuilder.InsertData(
                table: "Techno",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, null, "Numérique" },
                    { 2, null, "Argentique" },
                    { 3, null, "Instantanée" },
                    { 4, null, "Jetable" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_imageId",
                table: "Product",
                column: "imageId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_productBrandId",
                table: "Product",
                column: "productBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_productDetailsId",
                table: "Product",
                column: "productDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_productTechnoId",
                table: "Product",
                column: "productTechnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_productTypeId",
                table: "Product",
                column: "productTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Techno");
        }
    }
}
