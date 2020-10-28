using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    FullName = table.Column<string>(maxLength: 200, nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 15, nullable: false),
                    Birthday = table.Column<DateTime>(maxLength: 30, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Role = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 300, nullable: true),
                    PriceIn = table.Column<float>(nullable: false),
                    PriceOut = table.Column<float>(nullable: false),
                    PromotionPrice = table.Column<float>(nullable: false),
                    Wanrranty = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    ModifiedByUserId = table.Column<string>(nullable: true),
                    ProviderId = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    CustomerName = table.Column<string>(maxLength: 200, nullable: true),
                    CustomerPhone = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    PaymentMethod = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    ProductId = table.Column<string>(maxLength: 10, nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__orderdetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_Id",
                        column: x => x.Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedByUserId",
                table: "Orders",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProviderId",
                table: "Products",
                column: "ProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}